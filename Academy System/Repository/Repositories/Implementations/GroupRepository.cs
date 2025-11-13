using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class GroupRepository : IGroupRepository<Group>
    {
        public void CreateGroup(Group data)
        {
            try
            {
                if (data == null)
                    throw new NotFoundExceptions("Data not found!");

                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteGroup(Group data)
        {
            try
            {
                if (!AppDbContext<Group>.datas.Remove(data))
                    throw new NotFoundExceptions("Group not found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Group> GetAllGroups(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.FindAll(predicate);
        }

        public List<Group> GetAllGroupsByRoom(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.FindAll(predicate);
        }

        public List<Group> GetAllGroupsByTeacher(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.FindAll(predicate);
        }

        public Group GetGroupById(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.Find(predicate);
        }

        public Group SearchMethodForGroupsByName(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.Find(predicate);
        }

        public void UpdateGroup(Group data)
        {
            try
            {
                var existingGroup = AppDbContext<Group>.datas.Find(g => g.Id == data.Id);
                if (existingGroup == null)
                    throw new NotFoundExceptions("Group not found!");

                if (!string.IsNullOrWhiteSpace(data.Name))
                    existingGroup.Name = data.Name;

                if (!string.IsNullOrWhiteSpace(data.Teacher))
                    existingGroup.Teacher = data.Teacher;

                if (data.Room > 0)
                    existingGroup.Room = data.Room;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
