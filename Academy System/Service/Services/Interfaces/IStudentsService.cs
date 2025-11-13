using Domain.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
        public interface IStudentService
        {
            Student CreateStudent(int groupId, Student student);
            void UpdateStudent(Student student);
            Student GetStudentById(int id);
            void DeleteStudent(int id);
            List<Student> GetStudentByAge(int age);
            List<Student> GetAllStudentByGroupId(int groupId);
            List<Student> SearchStudent(string searchText);
        }

    
}
