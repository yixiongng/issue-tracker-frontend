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
    public partial class TicketDetails : System.Web.UI.Page
    {
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
        protected async void BindListView()
        {
            var TicketID = Request.QueryString["TicketId"];
            var ticket = await HttpProvider.GetRequestAsync<TicketDetailsViewModel>("api/v1/Ticket/View?TicketId=" + TicketID, this, true);
            var categoryList = await HttpProvider.GetRequestAsync<List<TicketCategoryViewModel>>("api/v1/TicketCategory/List", this, true);
            var userList = await HttpProvider.GetRequestAsync<List<UserNameViewModel>>("api/v1/User/List", this, true);
            var statusList = await HttpProvider.GetRequestAsync<List<TicketStatusViewModel>>("api/v1/Ticket/StatusList", this, true);

            DdlCategory.DataSource = categoryList;
            DdlCategory.DataBind();

            DdlAssignee.DataSource = from x in userList
                                     select new
                                     {
                                         x.UserId,
                                         FullName = String.Format("{0} {1}", x.FirstName, x.LastName)
                                     }; ;
            DdlAssignee.DataBind();
            DdlAssignee.Items.Insert(0, new ListItem("", ""));


            DdlStatus.DataSource = statusList;
            DdlStatus.DataBind();

            TicketId.Text = ticket.TicketId.ToString();
            TicketName.Text = ticket.TicketName;
            Description.Text = ticket.Description;
            OwnerName.Text = ticket.Owner.FirstName + " " + ticket.Owner.LastName;
            DdlAssignee.SelectedValue = ticket.Assignee.UserId.ToString();
            DdlStatus.SelectedValue = ticket.Status.ToString();

            if(ticket.Owner.UserId == UserDetails.UserID || ticket.Assignee.UserId == UserDetails.UserID)
            {
                EditButton.Visible = true;
                DeleteButton.Visible = true;
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        protected async void SubmitButton_Click(object sender, EventArgs e)
        {
            var ticket = new UpdateTicketDetailsViewModel
            {
                TicketId = Int32.Parse(TicketId.Text),
                TicketName = TicketName.Text,
                Description = Description.Text,
                OwnerId = UserDetails.UserID,
                CategoryId = Int32.Parse(DdlCategory.SelectedValue),
                Status = DdlStatus.SelectedValue
            };
            if (!string.IsNullOrEmpty(DdlAssignee.SelectedValue))
            {
                ticket.AssigneeId = Int32.Parse(DdlAssignee.SelectedValue);
            }
            var result = await HttpProvider.PostRequestAsync<int>("api/v1/Ticket/Update", ticket, this, true);
            if (result != 0)
            {
                string scriptText = "alert('Update Ticket successfully!'); window.location='" + Request.ApplicationPath + "Pages/Home.aspx'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
            }
            else
            {
                string scriptText = "alert('Error, please try again!')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
            }
        }
        protected void EditButton_Click(object sender, EventArgs e)
        {
            TicketName.Enabled = true;
            Description.Enabled = true;
            DdlAssignee.Enabled = true;
            DdlCategory.Enabled = true;
            DdlStatus.Enabled = true;
            CancelButton.Visible = true;
            SubmitButton.Visible = true;
            EditButton.Visible = false;
            DeleteButton.Visible = false;
        }
        protected async void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = await HttpProvider.GetRequestAsync<bool>("api/v1/Ticket/Delete?TicketId=" + TicketId.Text, this, true);

            if (result)
            {
                Response.Redirect("Home.aspx");
            }
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            UserDetails.Logout();
            Response.Redirect("Login.aspx");
        }
    }
}