using Academy_Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Presentation.Controller
{
    public class GroupController
    {
        
            private readonly GroupService _groupService = new();

            public void Create()
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add Group Name");
                string groupName = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add Teacher Name");
                string teacher = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add Room");
                string room = Console.ReadLine();

                Group group = new Group { Name = groupName, Teacher = teacher, Room = room };
                var result = _groupService.Create(group);

                Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {result.Id}, Name : {result.Name}, Teacher : {result.Teacher}, Room : {result.Room}");
            }

            public void GetById()
            {
            GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int id))
                {
                    var group = _groupService.GetById(id);
                    if (group != null)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Teacher : {group.Teacher}, Room : {group.Room}");
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                        goto GroupId;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                    goto GroupId;
                }
            }

            public void GetAll()
            {
                var groups = _groupService.GetAll();
                if (groups.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Please create groups first!");
                    return;
                }

                foreach (var g in groups)
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {g.Id}, Name : {g.Name}, Teacher : {g.Teacher}, Room : {g.Room}");
            }

            public void Delete()
            {
            GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id to delete");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int id))
                {
                    _groupService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.Green, "Group deleted successfully.");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                    goto GroupId;
                }
            }

            public void Update()
            {
            GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id to update (or press Enter to cancel)");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Update cancelled.");
                    return;
                }

                if (int.TryParse(input, out int id))
                {
                    var group = _groupService.GetById(id);
                    if (group == null)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group not found");
                        goto GroupId;
                    }

                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Name: {group.Name}. Add new Name (or press Enter to keep current)");
                    string newName = Console.ReadLine();
                    newName = string.IsNullOrWhiteSpace(newName) ? group.Name : newName;

                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Teacher: {group.Teacher}. Add new Teacher (or press Enter to keep current)");
                    string newTeacher = Console.ReadLine();
                    newTeacher = string.IsNullOrWhiteSpace(newTeacher) ? group.Teacher : newTeacher;

                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Room: {group.Room}. Add new Room (or press Enter to keep current)");
                    string newRoom = Console.ReadLine();
                    newRoom = string.IsNullOrWhiteSpace(newRoom) ? group.Room : newRoom;

                    Group updatedGroup = new Group { Name = newName, Teacher = newTeacher, Room = newRoom };
                    var result = _groupService.Update(id, updatedGroup);

                    Helper.PrintConsole(ConsoleColor.Green, $"Updated: Id: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                    goto GroupId;
                }
            }

            public void Search()
            {
            SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Add Group search text");
                string search = Console.ReadLine();

                var groups = _groupService.Search(search);
                if (groups.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "No groups found for this search!");
                    goto SearchText;
                }

                foreach (var g in groups)
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {g.Id}, Name : {g.Name}, Teacher : {g.Teacher}, Room : {g.Room}");
            }
        









        internal void Create()
        {
            throw new NotImplementedException();
        }

        internal void GetAll()
        {
            throw new NotImplementedException();
        }

        internal void GetById()
        {
            throw new NotImplementedException();
        }
    }

    internal class GroupService
    {
    }
}
