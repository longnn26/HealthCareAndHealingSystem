using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserExercise 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userExerciseID { get; set; }
        public Guid exerciseID { get; set; }
        [ForeignKey("exerciseID")]
        public virtual Exercise Exercise { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User User { get; set; }
        public DateTime duarationTime { get; set; }
        public bool status { get; set; }
        public bool isDeleted { get; set; }
    }
}
