using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class APIFail
    {
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorType { get; set; }
        public string Message { get; set; }

    }
}