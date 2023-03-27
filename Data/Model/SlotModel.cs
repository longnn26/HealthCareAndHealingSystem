using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class SlotCreateModel
    {
        public Guid typeOfSlotID { get; set; }
        public Guid physiotherapistID { get; set; }
        public Guid totalScheduleID { get; set; }
        public Guid exerciseID { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public TimeOnly duaration { get; set; }
        public string description { get; set; }
        public float fee { get; set; }
        public bool isDeleted { get; set; }
    }
    public class SlotUpdateModel
    {
        public Guid slotID { get; set; }
        public Guid typeOfSlotID { get; set; }
        public Guid physiotherapistID { get; set; }
        public Guid totalScheduleID { get; set; }
        public Guid exerciseID { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public TimeOnly duaration { get; set; }
        public string description { get; set; }
        public float fee { get; set; }
        public bool isDeleted { get; set; }
    }
    public class SlotModel : SlotUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }

}


