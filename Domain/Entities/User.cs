using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Messages = new HashSet<Message>();
        }

        public string Phone { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
