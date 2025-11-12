using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Group: BaseEntity
    {    
        
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Room { get; set; }
        public List<Student> Students { get; set; } = new();

        public static implicit operator Group(Type v)
        {
            throw new NotImplementedException();
        }
    }
}
