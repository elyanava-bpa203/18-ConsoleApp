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
            Student Create(int groupId, Student student);
            void Update(Student student);
            Student GetById(int id);
            void Delete(int id);
            List<Student> GetByAge(int age);
            List<Student> GetAllByGroupId(int groupId);
            List<Student> Search(string searchTerm);
        }

    
}
