﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ZarinPal
{
    public class VerificationResponse
    {

        public bool IsSuccess { get { return Status == 100; } set { this.IsSuccess = value; } }
        public String RefID { get; set; }
        public int Status { get; set; }

    }
}
