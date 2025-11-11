using Service.Services.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repositories.Implementations;

namespace Service.Services.Implementations
{
    public class StudentsService : IStudentsService
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupReposotory;
        private int _count = 1;


        public StudentsService()
        {
            _studentRepository = new();
            _groupReposotory = new();
        }
        public Student Create(int groupId, Student student) 
        {
            var studentRepository = _studentRepository.Get(1 => 1.Id == groupId);

            if (group is null) return null;

            student.Id = _count;

            student.Group = group;

            studentRepository.Create(student);

            _count++;

            return student;

        
        }


    }
}
