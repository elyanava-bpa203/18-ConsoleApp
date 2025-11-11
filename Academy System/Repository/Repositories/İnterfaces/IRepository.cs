using Domain.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.İnterfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create (T data);
        void Update (T data);
        void Delete (T data);

        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
