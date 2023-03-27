using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Feedback 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid feedbackID { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }
        public Guid bookingScheduleID { get; set; }
        [ForeignKey("bookingScheduleID")]
        public virtual BookingSchedule BookingSchedule { get; set; }
        public string comment { get; set; }
        public int ratingStar { get; set; }
        public bool isDeleted { get; set; }
    }
}
