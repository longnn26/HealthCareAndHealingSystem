using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ExerciseDetail 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid exerciseDetailID { get; set; }
        public Guid exerciseID { get; set; }
        [ForeignKey("exerciseID")]
        public virtual Exercise Exercise { get; set; }
        public Guid categoryID { get; set; }
        [ForeignKey("categoryID")]
        public virtual Category Category { get; set; }

        public DateTime exerciseTimePerSet { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string description { get; set; }
        public bool isDeleted { get; set; }
    }
}
