using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class TicketDetailsViewModel
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserNameViewModel Assignee { get; set; }
        public UserNameViewModel Owner { get; set; }
        public TicketCategoryViewModel TicketCategory { get; set; }
        public string Status { get; set; }
    }
}