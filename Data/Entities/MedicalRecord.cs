﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MedicalRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid medicalRecordID { get; set; }
        public string presentIllness { get; set; }
        public string pastMedical { get; set; }
        public bool isDeleted { get; set; }
    }
}
