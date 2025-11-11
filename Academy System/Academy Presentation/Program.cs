using Academy_Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Presentation
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Helper.PrintConsole(ConsoleColor.Green, "Select one options!");
            Helper.PrintConsole(ConsoleColor.Blue, 
                "1 - Create Group\n ," +
                " 2 - Update group\n   " +
                " 3 - Delete Group \n   " +
                "4 - Get group by id\n  " +
                "5 - Get all groups by teacher\n  " +
                "6 - Get all groups by room\n " +
                "7 - Get all groups \n  " +
                "8 - Create Student\n " +
                "9 - Update Student \n  " +
                "10- Get student by id\n" +
                "11 - Delete student\n " +
                "12 - Get students by age\n " +
                "13 - Get all students by group id\n " +
                "14- Search method for groups by name\n  " +
                "15 - Search method for students by name or surname\n");
        }
    }
}
