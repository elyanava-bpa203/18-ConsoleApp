using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found!");

                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public void Update(Group data)
        {
            Group dbGroup = Get(g => g.Id == data.Id);

            if (dbGroup == null) return;

            if (!string.IsNullOrEmpty(data.Name))
            {
                dbGroup.Name = data.Name;
            }
            if (!string.IsNullOrEmpty(data.Teacher))
                dbGroup.Teacher = data.Teacher;

            if (data.Room > 0)
                dbGroup.Room = data.Room;

        }


        public List<Group> GetByTeacher(string teacher)
        {
            return GetAll(g => g.Teacher == teacher);
        }

        public List<Group> GetByRoom(int room)
        {
            return GetAll(g => g.Room == room);
        }

        public List<Group> SearchByName(string name)
        {
            return GetAll(g => g.Name.ToLower().Contains(name.ToLower()));
        }

        public void Update(object updatedGroup)
        {
            throw new NotImplementedException();
        }

        public void Create(System.Text.RegularExpressions.Group group)
        {
            throw new NotImplementedException();
        }











        [Serializable]
        internal class NotFoundException : Exception
        {
            public NotFoundException()
            {
            }

            public NotFoundException(string? message) : base(message)
            {
            }

            public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }

        internal class Library
        {
        }




    }
}
