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
        
      
        public Guid profileID { get; set; }
        
        public Guid slotID { get; set; }
       
        public DateTime timeChooseStart { get; set; }
        public DateTime timeChooseEnd { get; set; }
        public float totalPrice { get; set; }
        public bool isDeleted { get; set; }
    }
    public class BookingScheduleUpdateModel
    {
        public Guid bookingScheduleID { get; set; }
        public Guid userID { get; set; }
        
        public Guid profileID { get; set; }
        
        public Guid slotID { get; set; }
        
        public DateTime timeChooseStart { get; set; }
        public DateTime timeChooseEnd { get; set; }
        public float totalPrice { get; set; }
        public bool isDeleted { get; set; }

    }
    public class BookingScheduleModel : BookingScheduleUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}