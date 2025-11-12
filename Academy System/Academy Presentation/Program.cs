using Academy_Presentation.Controller;
using Academy_Presentation.Helpers;
using LibrarySystem.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Presentation 
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();
            StudentController studentController = new();

            Helper.PrintConsole(ConsoleColor.Blue, "Select one option!");

            GetMenus();

            while (true)
            {
            SelectOption:
                string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        
                        case (int)Menus.CreateGroup:
                            groupController.Create();
                            break;

                        case (int)Menus.GetGroupById:
                            groupController.GetById();
                            break;

                        case (int)Menus.GetAllGroups:
                            groupController.GetAll();
                            break;

                        case (int)Menus.DeleteGroup:
                            groupController.Delete();
                            break;

                        case (int)Menus.UpdateGroup:
                            groupController.Update();
                            break;

                        case (int)Menus.SearchMethodForGroupsByName:
                            groupController.Search();
                            break;







                        case (int)Menus.CreateStudent:
                            studentController.Create();
                            break;

                        case (int)Menus.GetStudentsByAge:
                            studentController.GetById();
                            break;

                        case (int)Menus.GetAllStudentsByGroup:
                            studentController.GetAll();
                            break;

                        case (int)Menus.DeleteStudent:
                            studentController.Delete();
                            break;

                        case (int)Menus.UpdateStudent:
                            studentController.Update();
                            break;

                        case (int)Menus.SearchMethodForStudentByNameOrSurname:
                            studentController.Search();
                            break;

                        default:
                            Helper.PrintConsole(ConsoleColor.Red, "Please select a valid option!");
                            break;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Select correct option type!");
                    goto SelectOption;
                }

                Helper.PrintConsole(ConsoleColor.Yellow, "\nSelect next option:");
                GetMenus();
            }
        }

        private static void GetMenus()
        {
            Helper.PrintConsole(ConsoleColor.Yellow,
                "\n1 - Create Group" +
                "\n2 - Get Group" +
                "\n3 - GetAll Groups" +
                "\n4 - Delete Group" +
                "\n5 - Update Group" +
                "\n6 - Search Group" +
                "\n7 - Create Student" +
                "\n8 - Get Student" +
                "\n9 - GetAll Students" +
                "\n10 - Delete Student" +
                "\n11 - Update Student" +
                "\n12 - Search Student");
        }
    }



}




