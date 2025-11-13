using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupsService
    {
        Group CreateGroup(Group group);
        Group UpdateGroup(int id, Group group);
        void DeleteGroup(int id);
        Group GetGroupById(int id);
        List<Group> GetAllGroup();
        List<Group> SearchGroup(string name);
        List<Group> GetAllGroupByTeacher(string teacher);
        List<Group> GetAllGroupByRoom(int room);

    }
}
