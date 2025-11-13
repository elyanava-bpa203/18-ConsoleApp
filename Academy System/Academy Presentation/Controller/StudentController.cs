using Academy_Presentation.Helpers;
using System;
using Domain.Entities;
using Repository.Repository.Implementations;
using Service.Services.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Presentation.Controller
{

    
        public class StudentController
        {
            private readonly StudentService _studentService = new();

            public void Create()
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id for Student");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int groupId))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                    return;
                }

                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Name");
                string name = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Surname");
                string surname = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Age");
                string ageInput = Console.ReadLine();
                if (!int.TryParse(ageInput, out int age))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct age type");
                    return;
                }

                var student = new Student { Name = name, Surname = surname, Age = age };
                var result = _studentService.Cre

                if (result != null)
                    Helper.PrintConsole(ConsoleColor.Green, $"Student created: Id: {result.Id}, Name: {result.Name}, Surname: {result.Surname}, Age: {result.Age}, GroupId: {result.Group.Id}");
                else
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found. Student not created.");
            }

            public void GetById()
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int id))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct Student Id type");
                    return;
                }

                var student = _studentService.GetById(id);
                if (student != null)
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, GroupId: {student.Group?.Id}");
                else
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found.");
            }

            public void GetAllByGroupId()
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int groupId))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct Group Id type");
                    return;
                }

                var students = _studentService.GetAllByGroupId(groupId);
                if (students.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "No students found in this group.");
                    return;
                }

                foreach (var s in students)
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {s.Id}, Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}");
            }

            public void Search()
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add search text for Student");
                string search = Console.ReadLine();

                var students = _studentService.Search(search);
                if (students.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "No students found.");
                    return;
                }

                foreach (var s in students)
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {s.Id}, Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, GroupId: {s.Group?.Id}");
            }

            public void Delete()
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id to delete");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int id))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct Student Id type");
                    return;
                }

                _studentService.Delete(id);
                Helper.PrintConsole(ConsoleColor.Green, "Student deleted successfully.");
            }

            public void Update()
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id to update");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int id))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct Student Id type");
                    return;
                }

                var student = _studentService.GetById(id);
                if (student == null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found.");
                    return;
                }

                Helper.PrintConsole(ConsoleColor.Blue, $"Current Name: {student.Name}. Add new Name (or press Enter to keep current)");
                string newName = Console.ReadLine();
                newName = string.IsNullOrWhiteSpace(newName) ? student.Name : newName;

                Helper.PrintConsole(ConsoleColor.Blue, $"Current Surname: {student.Surname}. Add new Surname (or press Enter to keep current)");
                string newSurname = Console.ReadLine();
                newSurname = string.IsNullOrWhiteSpace(newSurname) ? student.Surname : newSurname;

                Helper.PrintConsole(ConsoleColor.Blue, $"Current Age: {student.Age}. Add new Age (or press Enter to keep current)");
                string ageInput = Console.ReadLine();
                int newAge = student.Age;
                if (!string.IsNullOrWhiteSpace(ageInput))
                {
                    if (!int.TryParse(ageInput, out newAge))
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Add correct age type");
                        return;
                    }
                }

                student.Name = newName;
                student.Surname = newSurname;
                student.Age = newAge;

                _studentService.Update(student);
                Helper.PrintConsole(ConsoleColor.Green, $"Student updated: Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}");
            }
        }

    internal class StudentService
    {
        internal object GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal void Update(object student)
        {
            throw new NotImplementedException();
        }
    }

    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
