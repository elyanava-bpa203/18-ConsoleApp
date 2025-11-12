using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    
    
        public class GroupService : IGroupService
        {
            private GroupRepository _groupRepository;
            private int _count = 1;

            public GroupService()
            {
                _groupRepository = new GroupRepository();
            }

            public Group Create(Group group)
            {
                group.Id = _count;
                _groupRepository.Create(group);
                _count++;
                return group;
            }

            public void Delete(int id)
            {
                Group group = GetById(id);
                if (group != null)
                    _groupRepository.Delete(group);
            }

            public List<Group> GetAll()
            {
                return _groupRepository.GetAll();
            }

            public Group GetById(int id)
            {
                Group group = _groupRepository.Get(g => g.Id == id);
                return group;
            }

            public Group Update(int id, Group group)
            {
                Group dbGroup = GetById(id);
                if (dbGroup is null) return null;

                group.Id = id;
                _groupRepository.Update(group);

                return GetById(id);
            }

            public List<Group> Search(string name)
            {
                return _groupRepository.GetAll(g =>
                    g.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
            }

            public List<Group> GetAllByTeacher(string teacher)
            {
                return _groupRepository.GetAll(g =>
                    g.Teacher.Trim().ToLower() == teacher.Trim().ToLower());
            }

            public List<Group> GetAllByRoom(int room)
            {
                return _groupRepository.GetAll(g => g.Room == room);
            }
        }

    public interface IGroupService
    {
    }
}






