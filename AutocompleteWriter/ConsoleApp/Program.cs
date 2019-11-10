using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace ConsoleApp
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            
            var chars = new Stack<char>();
            var builder = new StringBuilder();
            var tabulation = 0;

            var readKey = new ConsoleKeyInfo();
            var view = new WriterView();
            
            do
            {
                readKey = Console.ReadKey(true);
                Console.Clear();
                switch (readKey.Key)
                {
                    case ConsoleKey.Backspace:
                        var poppedKey = chars.Pop();
                        if (poppedKey == '\t')
                        {
                            tabulation--;
                        }
                        break;
                    case ConsoleKey.Enter:
                    {
                        view.AddLine(chars.ToAcceptableString());
                        chars.Clear();
                        for (int i = 0; i < tabulation; i++)
                        {
                            chars.Push('\t');
                        }

                        break;
                    }
                    case ConsoleKey.Tab:
                        tabulation++;
                        chars.Push('\t');
                        break;
                    default:
                        chars.Push(readKey.KeyChar);
                        break;
                }

                builder.Clear();
                var cs = chars.ToArray();
                for (var index = cs.Length - 1; index > -1; index--)
                {
                    var c = cs[index];
                    builder.Append(c);
                }

                Console.WriteLine(view);
                Console.Write(builder.Replace(":eud", "error").Replace("\t", new string(' ', 4)));
            } while (readKey.Key != ConsoleKey.Escape);
        }
    }
}