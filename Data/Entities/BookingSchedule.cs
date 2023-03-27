using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BookingSchedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid bookingScheduleID { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }
        public Guid profileID { get; set; }
        [ForeignKey("profileID")]
        public virtual SubProfile SubProfile { get; set; }
        public Guid slotID { get; set; }
        [ForeignKey("slotID")]
        public virtual Slot Slot { get; set; }
        public DateTime timeChooseStart { get; set; }
        public DateTime timeChooseEnd { get; set;}
        public float totalPrice { get; set; }
        public bool isDeleted { get; set; }
    }
}
