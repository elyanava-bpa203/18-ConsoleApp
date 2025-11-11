using Domain.Entities;
using Repository.Repositories.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
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

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
