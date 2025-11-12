using Domain.Entities;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.Services.Implementations.StudentsService;

namespace Service.Services.Implementations
{
    public class StudentsService : IStudentsService
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupReposotory;
        private int _count = 1;
        private object _groupRepository;

        public StudentsService()
        {
            _studentRepository = new();
            _groupReposotory = new();
        }

      
            // 8 - Create Student
            public Student Create(int groupId, Student student)
            {
                var group = _groupRepository.GetType(g => g.Id == groupId);
                if (group == null) return null;

                student.Id = _count;
                student.Group = group;

                _studentRepository.Create(student);
                _count++;

                return student;
            }

            // 9 - Update Student
            public void Update(Student student)
            {
                var dbStudent = _studentRepository.Get(s => s.Id == student.Id);
                if (dbStudent == null) return;

                dbStudent.Name = student.Name ?? dbStudent.Name;
                dbStudent.Surname = student.Surname ?? dbStudent.Surname;
                dbStudent.Age = student.Age != 0 ? student.Age : dbStudent.Age;

                _studentRepository.Update(dbStudent);
            }

            // 10 - Get student by id
            public Student GetById(int id)
            {
                return _studentRepository.Get(s => s.Id == id);
            }

            // 11 - Delete student
            public void Delete(int id)
            {
                var student = _studentRepository.Get(s => s.Id == id);
                if (student != null)
                {
                    _studentRepository.Delete(student);
                }
            }

            // 12 - Get students by age
            public List<Student> GetByAge(int age)
            {
                return _studentRepository.GetAll(s => s.Age == age);
            }

            // 13 - Get all students by group id
            public List<Student> GetAllByGroupId(int groupId)
            {
                return _studentRepository.GetAll(s => s.Group != null && s.Group.Id == groupId);
            }

            // 15 - Search method for students by name or surname
            public List<Student> Search(string searchTerm)
            {
                return _studentRepository.GetAll(s => s.Name.Contains(searchTerm) || s.Surname.Contains(searchTerm));
            }
        }

    }


}
}
