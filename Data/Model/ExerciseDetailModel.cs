﻿using Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ExerciseDetailCreateModel
    {
        public Guid exerciseID { get; set; }
       
        public Guid categoryID { get; set; }

        public DateTime exerciseTimePerSet { get; set; }
        public string description { get; set; }
        public bool isDeleted { get; set; }
    }
    public class ExerciseDetailUpdateModel
    {
        public Guid exerciseDetailID { get; set; }
        public Guid exerciseID { get; set; }

        public Guid categoryID { get; set; }

        public DateTime exerciseTimePerSet { get; set; }
        public string description { get; set; }
        public bool isDeleted { get; set; }

    }
    public class ExerciseDetailModel : ExerciseDetailUpdateModel
    {
        
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
