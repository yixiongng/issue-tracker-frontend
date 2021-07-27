using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class RespondAPIViewModel<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}