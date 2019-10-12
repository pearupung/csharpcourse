using System;
using System.ComponentModel.DataAnnotations;

namespace FourConnectCore
{
    public class MenuItem
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = Validate(value, 1, 100, false);
        }

        public Func<string> CommandToExecute { get; set; }
        
        private static string Validate(string item, int minLength, int maxLength, bool toUpper)
        {
            item = item.Trim();
            if (toUpper)
            {
                item = item.ToUpper();
            }

            if (item.Length < minLength || item.Length > maxLength)
            {
                throw new ArgumentException($"String length {item.Length} " +
                                            $"of {item} is invalid, " +
                                            $"must be in range {minLength}-{maxLength}");
            }

            return item;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}