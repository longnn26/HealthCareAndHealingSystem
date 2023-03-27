using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Exercise 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid exerciseID { get; set; }
        public string exerciseName { get; set;}
        public int exerciseTimePerWeek { get; set; }
        public bool flag { get; set; }
        public bool status { get; set; }
        public bool isDeleted { get; set; }
    }
}
