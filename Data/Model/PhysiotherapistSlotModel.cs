using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ScheduleCreateModel
    {
        public Guid slotID { get; set; }
        public Guid physiotherapistID { get; set; }
    }
    public class ScheduleUpdateModel
    {
        public Guid physiotherapistSlotID { get; set; }
        public Guid slotID { get; set; }
        public Guid physiotherapistID { get; set; }

    }
    public class ScheduleModel : ScheduleUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}