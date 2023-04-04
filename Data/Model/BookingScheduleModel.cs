using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class BookingScheduleCreateModel
    {

        
        public Guid userID { get; set; }
        
        
        public Guid? profileID { get; set; }
        
        
        public Guid physiotherapistID { get; set; }
        
        public Guid slotID { get; set; }
        
        public Guid medicalRecordID { get; set; }
        
        public DateTime timeBooking { get; set; }
        public float price { get; set; }
        public bool status { get; set; }
    }
    public class BookingScheduleUpdateModel
    {


    }
    public class BookingScheduleModel : BookingScheduleUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}