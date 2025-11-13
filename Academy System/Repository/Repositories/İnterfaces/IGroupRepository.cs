using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.İnterfaces
{
    public interface IGroupRepository<T> where T : BaseEntity  
    {
        void CreateGroup(T data);
        void UpdateGroup(T data);
        void DeleteGroup(T data);
        T GetGroupById(Predicate<T> predicate);
        List<T> GetAllGroups(Predicate<T> predicate);
        List<T> GetAllGroupsByTeacher(Predicate<T> predicate);
        List<T> GetAllGroupsByRoom(Predicate<T> predicate);
        T SearchMethodForGroupsByName(Predicate<T> predicate);
      
      


    }
}
