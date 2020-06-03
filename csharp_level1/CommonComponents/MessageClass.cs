using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public static class MessageClass
    {
        private static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string CutWordsByLenght(string message, int maxLength)
        {
            string[] words = message.Split(new[] { " ", ",", ".", " - ", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                message = message.Replace(word, word.Truncate(maxLength));
            }
            return message;
        }
    }
}