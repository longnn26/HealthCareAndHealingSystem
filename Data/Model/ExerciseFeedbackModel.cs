using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ExerciseFeedbackCreateModel
    {
        public Guid physiotherapistID { get; set; }
        public Guid exerciseID { get; set; }
        public string feebackContent { get; set; }
        public bool isDeleted { get; set; }
    }
    public class ExerciseFeedbackUpdateModel
    {
        public Guid exerciseFeedbackID { get; set; }
        public Guid physiotherapistID { get; set; }
        public Guid exerciseID { get; set; }
        public string feebackContent { get; set; }
        public bool isDeleted { get; set; }
    }

    public class ExerciseFeedbackModel : ExerciseFeedbackUpdateModel

    {
        public DateTime dateCreated { get; set; }
        public DateTime dateUpdated { get; set; }
    }

}

