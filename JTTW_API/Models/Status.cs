using System;
using System.Collections.Generic;

namespace JTTW_API.Models
{
    public partial class Status
    {
        public Status()
        {
            Calamity = new HashSet<Calamity>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Calamity> Calamity { get; set; }
    }
}
