using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FourConnectCore
{
    public class LoadGameView
    {
        private List<SavedGame> _savedGames = new List<SavedGame>();
        private int _gameSelected = 0;

        public LoadGameView()
        {
            GameLoad();
        }
        public void GameSave(GameBoard gameBoard, string gameName)
        {
            var save = new SavedGame()
            {
                GameBoard = gameBoard,
                GameName = gameName,
                TimeSaved = DateTime.UtcNow
            };
            _savedGames.Add(save);

            var json = JsonSerializer.Serialize(_savedGames, new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
                WriteIndented = true
            });
            File.WriteAllText("/home/pearu/Desktop/games.db", json);

        }

        public GameBoard GetSelectedGameBoard()
        {
            var gameBoard = _savedGames[_gameSelected].GameBoard;
            return new GameBoard(gameBoard);
        }
        

        public void GameLoad()
        {
            _savedGames.Clear();
            string json;
            using (StreamReader reader = File.OpenText("/home/pearu/Desktop/games.db"))
            {
                json = reader.ReadToEnd();
            }

            _savedGames = JsonSerializer.Deserialize<List<SavedGame>>(json);
        }

        public override string ToString()
        {
            GameLoad();
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