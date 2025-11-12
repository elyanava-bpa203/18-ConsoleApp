using Domain.Entities;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Service.Services.Interfaces;
using Repository.Repositories.Implementations;
using System.Threading.Tasks;


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

      
            
            public Student CreateStudent(int groupId, Student student)
            {
            var group = _groupRepository.GetType(g => g.Id == group.Id);
                if (group is  null) return null;

                student.Id = _count;
                student.Group = group;

                _studentRepository.Create(student);
                _count++;

                return student;
            }

            
            public void Update(Student student)
            {
                var dbStudent = _studentRepository.Get(s => s.Id == student.Id);
                if (dbStudent == null) return;

                dbStudent.Name = student.Name ?? dbStudent.Name;
                dbStudent.Surname = student.Surname ?? dbStudent.Surname;
                dbStudent.Age = student.Age != 0 ? student.Age : dbStudent.Age;

                _studentRepository.Update(dbStudent);
            }

            
            public Student GetById(int id)
            {
                return _studentRepository.Get(s => s.Id == id);
            }

            
            public void Delete(int id)
            {
                var student = _studentRepository.Get(s => s.Id == id);
                if (student != null)
                {
                    _studentRepository.Delete(student);
                }
            }

            
            public List<Student> GetByAge(int age)
            {
                return _studentRepository.GetAll(s => s.Age == age);
            }

            
            public List<Student> GetAllByGroupId(int groupId)
            {
                return _studentRepository.GetAll(s => s.Group != null && s.Group.Id == groupId);
            }

            
            public List<Student> Search(string searchTerm)
            {
                return _studentRepository.GetAll(s => s.Name.Contains(searchTerm) || s.Surname.Contains(searchTerm));
            }
        }

    public interface IStudentsService
    {
    }
}


}
}
