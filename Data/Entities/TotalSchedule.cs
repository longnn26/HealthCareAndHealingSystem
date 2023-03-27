using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TotalSchedule 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid totalScheduleID { get; set; }
        public Guid slotID { get; set; }
        [ForeignKey("slotID")]
        public virtual Slot Slot { get; set; }
        public Guid physiotherapistID { get; set; }
        [ForeignKey("physiotherapistID")]
        public virtual PhysiotherapistDetail PhysiotherapistDetail { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }

        public DateTime day { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public TimeOnly duaration { get; set; }
        public bool isDeleted { get; set; }
    }
}
