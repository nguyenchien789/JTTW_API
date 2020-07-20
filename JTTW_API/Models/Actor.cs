using System;
using System.Collections.Generic;

namespace JTTW_API.Models
{
    public partial class Actor
    {
        public Actor()
        {
            ActorList = new HashSet<ActorList>();
            History = new HashSet<History>();
            User = new HashSet<User>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ActorList> ActorList { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
