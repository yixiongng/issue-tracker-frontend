using issue_tracker_frontend.Providers;
using issue_tracker_frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace issue_tracker_frontend.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        public static List<TicketListViewModel> ticketList = new List<TicketListViewModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserDetails.Token))
            {
                Response.Redirect("Login.aspx");
            }
            if (!this.IsPostBack)
            {
                this.BindListView();
            }
        }

        private async void BindListView()
        {
            ticketList = await HttpProvider.GetRequestAsync<List<TicketListViewModel>>("api/v1/Ticket/FullList", this, true);
            var statusList = await HttpProvider.GetRequestAsync<List<TicketStatusViewModel>>("api/v1/Ticket/StatusList", this, true);
            DdlStatus.DataSource = statusList;
            DdlStatus.DataBind();
            DdlStatus.Items.Insert(0, new ListItem("", ""));
            lvTicket.DataSource = ticketList;
            lvTicket.DataBind();
        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvTicket.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }
        protected void EditButton_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            var TicketId = Convert.ToInt32(myButton.CommandArgument.ToString());

            string url;
            url = "TicketDetails.aspx?TicketId=" + TicketId;
            Response.Redirect(url);
        }
        protected void AllButton_Click(object sender, EventArgs e)
        {
            Title.Text = "All Tickets";
            this.BindListView();
        }
        protected async void AssignedButton_Click(object sender, EventArgs e)
        {
            var userId = UserDetails.UserID;
            Title.Text = "Assigned Tickets";
            ticketList = await HttpProvider.GetRequestAsync<List<TicketListViewModel>>("api/v1/Ticket/AssignedToUser?UserId=" + userId, this, true);

            Search.Text = "";
            DdlStatus.SelectedValue = "";
            lvTicket.DataSource = ticketList;
            lvTicket.DataBind();
        }
        protected async void OwnedButton_Click(object sender, EventArgs e)
        {
            var userId = UserDetails.UserID;
            Title.Text = "Owned Tickets";
            ticketList = await HttpProvider.GetRequestAsync<List<TicketListViewModel>>("api/v1/Ticket/OwnedByUser?UserId=" + userId, this, true);

            Search.Text = "";
            DdlStatus.SelectedValue = "";
            lvTicket.DataSource = ticketList;
            lvTicket.DataBind();
        }

        protected void NewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateTicket.aspx");
        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string text = Search.Text;
            lvTicket.DataSource = ticketList.Where(x => x.TicketName.ToLower().Contains(text.ToLower())).ToList();
            lvTicket.DataBind();
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Search.Text = "";
            var status = DdlStatus.SelectedValue;
            lvTicket.DataSource = ticketList.Where(x => x.Status == status).ToList();
            lvTicket.DataBind();
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            UserDetails.Logout();
            Response.Redirect("Login.aspx");
        }
    }
}