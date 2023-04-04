using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid scheduleID { get; set; }
        public Guid slotID { get; set; }
        [ForeignKey("slotID")]
        public virtual Slot Slot { get; set; }
        public Guid physiotherapistID { get; set; }
        [ForeignKey("physiotherapistID")]
        public virtual Physiotherapist PhysiotherapistDetail { get; set; }
        public DateOnly day { get; set; }
    }
}
