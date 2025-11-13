using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repository.Repositories.Implementations.GroupRepository;

namespace Repository.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository<Student>
    {
        public void CreateStudent(Student data)
        {
            try
            {
                if (data == null) throw new NotFoundExceptions("Data not found!");
                AppDbContext<Student>.datas.Add(data);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteStudent(Student data)
        {
            try
            {
                if (!AppDbContext<Student>.datas.Remove(data))
                    throw new NotFoundExceptions("Student not found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void UpdateStudent(Student data)
        {
            Student dbStudent = GetStudentById(s => s.Id == data.Id);

            if (dbStudent == null) return;
            if(!string.IsNullOrEmpty(data.Name))
                dbStudent.Name = data.Name;
            if(!string.IsNullOrEmpty(data.Surname))
                dbStudent.Surname = data.Surname;
            if(data.Age>17)
                dbStudent.Age = data.Age;
            if(data.Group != null)
                dbStudent.Group = data.Group;
        }

        public List<Student> GetStudentsByAge(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate): AppDbContext<Student>.datas;
        }

        public List<Student> GetAllStudentsByGroupId(Predicate<Student> predicate)
        {
            return AppDbContext<Student>.datas.FindAll(predicate);
        }


        public Student GetStudentById(Predicate<Student> predicate)
        {
            return AppDbContext<Student>.datas.Find(predicate);
        }

        public List<Student> GetStudentByAge(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchStudent(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }
    }


}

