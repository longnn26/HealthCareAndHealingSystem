﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Token
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public string userID { get; set; }
        public int Expires_in { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string phoneNumber { get; set; }
        public string lastName { get; set; }
    }
}
