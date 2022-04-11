using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NRIAPI.Models
{
    public class ResponseFormat
    {
        public bool IsSuccess { get; set; }
        public bool Status { get; set; }
        public String ResponseMessage { get; set; }
        public object ResponseData { get; set; }


    }
}