using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Deposit 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid depositID { get; set; }
        public float deposit { get; set; }
        public bool isDeleted { get; set; }
    }
}
