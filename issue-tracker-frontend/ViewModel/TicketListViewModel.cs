using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class TicketListViewModel
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public UserNameViewModel AssigneeName { get; set; }
        public UserNameViewModel OwnerName { get; set; }
        public string Status { get; set; }
        public string CategoryName { get; set; }


    }
}