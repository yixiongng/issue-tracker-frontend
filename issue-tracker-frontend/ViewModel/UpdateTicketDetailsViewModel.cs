using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class UpdateTicketDetailsViewModel
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string Description { get; set; }
        public int? AssigneeId { get; set; }
        public int OwnerId { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; }
    }
}