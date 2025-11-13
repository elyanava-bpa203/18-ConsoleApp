using Domain.Entities;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Service.Services.Implementations 

{
    public class StudentsService : IStudentService
    {
        private readonly StudentRepository _studentRepository;
        private int _count = 1;

        public StudentsService()
        {
            _studentRepository = new StudentRepository();
        }

        public Student CreateStudent(int groupId, Student student)
        {
            student.Id = _count;

            _studentRepository.CreateStudent(student);

            _count++;

            return student;
        }

        public void DeleteStudent(int id)
        {
            Student student = GetStudentById(id);

            if (student != null)
                _studentRepository.DeleteStudent(student);
        }

        public List<Student> GetAllStudentByGroupId(int groupId)
        {
            return _studentRepository.GetStudentById();
        }

        public List<Student> GetStudentByAge(int age)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchStudent(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return new List<Student>();

            return _studentRepository.GetAll()
                .Where(s =>
                    (!string.IsNullOrEmpty(s.Name) && s.Name.Trim().ToLower() == searchText.Trim().ToLower()) ||
                    (!string.IsNullOrEmpty(s.Surname) && s.Surname.Trim().ToLower() == searchText.Trim().ToLower()) ||
                    (s.Group != null && !string.IsNullOrEmpty(s.Group.Name) && s.Group.Name.Trim().ToLower() == searchText.Trim().ToLower())
                )
                .ToList();
        }

        public void UpdateStudent(Student student)
        {
            Student dbStudent = GetById(id);

            if (dbStudent == null) 

            student.Id = id;
            _studentRepository.UpdateStudent(student);

            return GetById(id);
        }
    }

}