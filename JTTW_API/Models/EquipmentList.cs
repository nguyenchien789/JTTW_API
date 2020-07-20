using System;
using System.Collections.Generic;

namespace JTTW_API.Models
{
    public partial class EquipmentList
    {
        public int EquipmentId { get; set; }
        public int CalamityId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }

        public virtual Calamity Calamity { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
