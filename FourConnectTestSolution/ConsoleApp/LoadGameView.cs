using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json;
using DAL;
using Domain;
using Game;
using Microsoft.EntityFrameworkCore;

namespace FourConnectCore
{
    public class LoadGameView
    {
        private List<Domain.Game> _savedGames = new List<Domain.Game>();
        private int _gameSelected = 0;
        public int GameCount => _savedGames.Count;

        public LoadGameView()
        {
            GameLoadFromDb();
        }
        public void GameSave(GameBoard gameBoard, string gameName)
        {
            var save = new Domain.Game()
            {
                GameName = gameName,
                TimeSaved = DateTime.UtcNow,
                FirstMove = gameBoard.FirstMove,
                Width = gameBoard.Width,
                Height = gameBoard.Height,
                Moves = gameBoard.PlayedColumns.Select(col => new Move()
                {
                    Column = col,

                }).ToList()
            };
            _savedGames.Add(save);

            var json = JsonSerializer.Serialize(_savedGames, new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
                WriteIndented = true
            });
            File.WriteAllText("/home/pearu/Desktop/games.db", json);

        }

        public void DeleteSelectedGameFromDb()
        {
            if (_savedGames.Count > 0)
            {
                using var ctx = new AppDbContext();
                ctx.Games.Remove(ctx.Games.Find(_savedGames[_gameSelected].GameId));
                ctx.SaveChanges();
                GameLoadFromDb();
            }
        }

        public void GameSaveToDb(GameBoard board, string name)
        {
            var moveList = board.PlayedColumns.Select((col, i) => new Move() {Column = col}).ToList();

            var game = new Domain.Game()
            {
                GameName = name, 
                TimeSaved = DateTime.Now,
                Moves = moveList,
                FirstMove = board.FirstMove,
                Height = board.Height,
                SelectedColumn = board.SelectedColumn,
                Width = board.Width
            };

            using (var ctx = new AppDbContext())
            {
                ctx.Games.Add(game);
                ctx.SaveChanges();
            }
        }

        public GameBoard GetSelectedGameBoard()
        {
            var game = _savedGames[_gameSelected];
            var firstMove = game.FirstMove;
            var board = new GameBoard(game.Height, game.Width)
            {
                FirstMove = firstMove,
                SelectedColumn = game.SelectedColumn
            };
            var playedMove = firstMove;
            var secondMove = firstMove == CellType.X ? CellType.X : CellType.O;
            foreach (var move in game.Moves)
            {
                board.Add(move.Column, playedMove);
                playedMove = playedMove == CellType.X ? CellType.O : CellType.X;
            }

            return board;
        }
        
        
        

        public void GameLoad()
        {
            _savedGames.Clear();
            string json;
            using (StreamReader reader = File.OpenText("/home/pearu/Desktop/games.db"))
            {
                json = reader.ReadToEnd();
            }

            _savedGames = JsonSerializer.Deserialize<List<Domain.Game>>(json);
        }

        public void GameLoadFromDb()
        {
            using (var ctx = new AppDbContext())
            {
                 _savedGames = ctx.Games
                     .Include(g => g.Moves)
                     .ToList();

            }
        }

        public override string ToString()
        {
            GameLoadFromDb();
            if (GameCount == 0) return "No games to be found!";
            var builder = new StringBuilder();
            for (int i = 0; i < _savedGames.Count; i++)
            {
                builder.Append(i == _gameSelected ? "> " : "  ");
                var savedGame = _savedGames[i];
                builder.AppendLine(savedGame.GameName);
                builder.AppendLine($"\t {savedGame.TimeSaved.ToLocalTime()}");
                builder.AppendLine();
            }
            return builder.ToString();
        }

        public void NextGame()
        {
            _gameSelected = (_gameSelected + 1) % _savedGames.Count;
        }
    }
}