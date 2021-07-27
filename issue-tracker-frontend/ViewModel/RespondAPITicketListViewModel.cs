using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class RespondAPITicketListViewModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalPage { get; set; }
        public bool PreviousPage { get; set; }
        public bool NextPage { get; set; }
        public List<TicketListViewModel> list { get; set; }
    }
}