using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class SubProfileCreateModel
    {
        public Guid medicalRecordID { get; set; }
        public Guid userID { get; set; }
        public string profileName { get; set; }
        public bool isDeleted { get; set; } 
    }
    public class SubProfileUpdateModel
    {
        public Guid profileID { get; set; }
        public Guid medicalRecordID { get; set; }
        public string profileName { get; set; }
        public bool isDeleted { get; set; }
    }
    public class SubProfileModel : SubProfileUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}