using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ExerciseFeedback 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid exerciseFeedbackID { get; set; }
        public Guid physiotherapistID { get; set; }
        public Guid exerciseID { get; set; }
        [ForeignKey("exerciseID")]
        public virtual Exercise Exercise { get; set; }
        public string feedbackContent { get; set; }
        public bool isDeleted { get; set; }
    }
}
