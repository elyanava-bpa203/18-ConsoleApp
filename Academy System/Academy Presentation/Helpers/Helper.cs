using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Presentation.Helpers
{
    public static  class Helper
    {
        private static ConsoleColor color;

        public static void PrintConsole(ConsoleColor console, string text) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
