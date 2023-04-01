using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Slot
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid slotID { get; set; }
        public Guid typeOfSlotID { get; set; }
        [ForeignKey("typeOfSlotID")]
        public virtual TypeOfSlot TypeOfSlot { get; set; }
        public Guid physiotherapistID { get; set; }
        [ForeignKey("physiotherapistID")]
        public virtual PhysiotherapistDetail PhysiotherapistDetail { get; set; }
        public Guid exerciseID { get; set; }
        [ForeignKey("exerciseID")]
        public virtual Exercise Exercise { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public TimeOnly duaration { get; set; }
        public string description { get; set; }
        public float fee { get; set; }
        public bool isDeleted { get; set; }
    }
}
