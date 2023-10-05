using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TBot.Configuration;
using Telegram.Bot;

namespace TBot.Services
{
    public static class StringHandler
    { 
        static public string GetStringLenght(string s)
        {
            return s.Length.ToString();
        }
        static public string GetSum(string s)
        {
            int sum = 0;
            foreach (var item in s) 
            {
                sum += int.TryParse(item.ToString(), out int result) ? result : 0;
            }
            return sum.ToString();
        }

    }
}
