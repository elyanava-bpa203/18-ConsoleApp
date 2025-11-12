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
        public void CreateStudent(Student data)
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

        public void DeleteStudent(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        

        public List<Student> GetAllStudent(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public void UpdateStudent(Student data)
        {
            Student dbStudent = GetStudentById(s => s.Id == data.Id);

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

        private Student GetStudentById(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentByAge(int age)
        {
            return GetAllStudent(s => s.Age == age);
        }

        public List<Student> GetStudentById(int groupId)
        {
            return GetAllStudent(s => s.Group != null && s.Group.Id == groupId);
        }






        public List<Student> SearchStudent(string text)
        {
            return GetAllStudent(s =>
                s.Name.ToLower().Contains(text.ToLower()) ||
                s.Surname.ToLower().Contains(text.ToLower()));
        }

        public void Create(Student data)
        {
            throw new NotImplementedException();
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student data)
        {
            throw new NotImplementedException();
        }

        public Student Get(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }
    }


}

