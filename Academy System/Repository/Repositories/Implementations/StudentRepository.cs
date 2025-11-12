using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repository.Repositories.Implementations.GroupRepository;

namespace Repository.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found!");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public void Update(Student data)
        {
            Student dbStudent = Get(s => s.Id == data.Id);

            if (dbStudent == null) return;

            if (!string.IsNullOrEmpty(data.Name))
                dbStudent.Name = data.Name;

            if (!string.IsNullOrEmpty(data.Surname))
                dbStudent.Surname = data.Surname;

            if (data.Age > 0)
                dbStudent.Age = data.Age;

            if (data.Group != null)
                dbStudent.Group = data.Group;
        }

       

        public List<Student> GetByAge(int age)
        {
            return GetAll(s => s.Age == age);
        }

        public List<Student> GetByGroupId(int groupId)
        {
            return GetAll(s => s.Group != null && s.Group.Id == groupId);
        }

        public List<Student> Search(string text)
        {
            return GetAll(s =>
                s.Name.ToLower().Contains(text.ToLower()) ||
                s.Surname.ToLower().Contains(text.ToLower()));
        }
    }


}

