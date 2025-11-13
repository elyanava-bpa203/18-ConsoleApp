using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace Service.Services.Implementations
{
    
    public class GroupsService : IGroupsService
    {

        private GroupRepository _groupRepository = new();
        private int _count = 1;

        public GroupsService()
        {
            _groupRepository = new GroupRepository();
        }
         Group IGroupsService.CreateGroup(Group group)
        {
            group.Id = _count;
            _groupRepository.CreateGroup(group);
            _count++;
            return group;
        }

         void IGroupsService.DeleteGroup(int id)
        {
            Group group = GetGroupById(id);

            _groupRepository.DeleteGroup(group);
        }
         Group IGroupsService.UpdateGroup(int id, Group group)
        {
            Group dbGroup = GetGroupById(id);

            if (dbGroup is null) return null;

            group.Id = id;

            _groupRepository.UpdateGroup(group);

            return GetGroupById(id);
        }

         List<Group> IGroupsService.GetAllGroup()
        {
            return _groupRepository.GetAllGroup();
        }

        public List<Group> GetAllGroupByRoom(int room)
        {
            return _groupRepository.GetAllGroupByRoom(g => g.Room == room);
        }

        public List<Group> IGroupsService.GetAllGroupByTeacher(string teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher))
                return new List<Group>();
        }

        public Group IGroupsService.GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> IGroupsService.SearchGroup(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<Group>();

            return _groupRepository.GetAllGroup(g => g.Name != null && g.Name.Trim().ToLower() == name.Trim().ToLower());
        }

       
    }
}






