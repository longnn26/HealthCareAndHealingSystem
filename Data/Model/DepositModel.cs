using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class DepositCreateModel
    {
        public float deposit { get; set; }
        public bool isDeleted { get; set; }
    }
    public class DepositUpdateModel
    {
        public Guid depositID { get; set; }
        public float deposit { get; set; }
        public bool isDeleted { get; set; }
    }
    public class DepositModel : DepositUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}