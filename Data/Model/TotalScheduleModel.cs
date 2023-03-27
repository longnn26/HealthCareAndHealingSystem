using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class TotalScheduleCreateModel
    {
        public Guid physiotherapistID { get; set; }
        public Guid? Id { get; set; }

        public Guid freeScheduleID { get; set; }

        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public int duaration { get; set; }
    }
    public class TotalScheduleUpdateModel
    {
        public Guid totalScheduleID { get; set; }
        public Guid physiotherapistID { get; set; }
        public Guid? Id { get; set; }

        public Guid freeScheduleID { get; set; }

        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }
        public int duaration { get; set; }

    }
    public class TotalScheduleModel : TotalScheduleUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
