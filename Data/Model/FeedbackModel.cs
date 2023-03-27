using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class FeedbackCreateModel
    {


        public Guid userID { get; set; }
        public Guid bookingScheduleID { get; set; }
        public string comment { get; set; }
        public int ratingStar { get; set; }
        public bool isDeleted { get; set; }

    }
    public class FeedbackUpdateModel
    {
        public Guid feedbackID { get; set; }
        public Guid userID { get; set; }
        public Guid bookingScheduleID { get; set; }
        public string comment { get; set; }
        public int ratingStar { get; set; }
        public bool isDeleted { get; set; }
    }
    public class FeedbackModel : FeedbackUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
