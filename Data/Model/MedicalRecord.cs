using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class MedicalRecordCreateModel
    {
        public string presentIllness { get; set; }
        public string pastMedical { get; set; }
        public bool isDeleted { get; set; }
        public Guid categoryID { get; set; }
    }
    public class MedicalRecordUpdateModel
    {
        public Guid medicalRecordID { get; set; }
        public string presentIllness { get; set; }
        public string pastMedical { get; set; }
        public bool isDeleted { get; set; }
        public Guid categoryID { get; set; }

    }
    public class MedicalRecordModel : MedicalRecordUpdateModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}