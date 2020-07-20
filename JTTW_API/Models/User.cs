using System;
using System.Collections.Generic;

namespace JTTW_API.Models
{
    public partial class User
    {
        public User()
        {
            History = new HashSet<History>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public int? ActorId { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActice { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
