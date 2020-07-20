using System;
using System.Collections.Generic;

namespace JTTW_API.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? CalamityId { get; set; }
        public int? EquipmentId { get; set; }
        public int? ActorId { get; set; }
        public DateTime? Time { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Calamity Calamity { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual User User { get; set; }
    }
}
