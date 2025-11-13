using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.İnterfaces
{
    public interface IStudentRepository<T> where T: BaseEntity
    {
        void CreateStudent(T data);
        void UpdateStudent(T data);
        void DeleteStudent(T data);
        T GetStudentById(Predicate<T> predicate);
        List<T> GetAllStudentsByGroupId(Predicate<T> predicate);
        List<T> GetStudentsByAge(Predicate<T> predicate);
        List<T> SearchStudent(Predicate<T> predicate);

    }
}
