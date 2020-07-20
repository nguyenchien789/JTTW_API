using System;
using System.Collections.Generic;

namespace JTTW_API.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentList = new HashSet<EquipmentList>();
            History = new HashSet<History>();
        }

        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public string Image { get; set; }

        public virtual ICollection<EquipmentList> EquipmentList { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
