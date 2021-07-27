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
    public partial class TicketCategory : System.Web.UI.Page
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

        private async void BindListView()
        {
            var ticketList = await HttpProvider.GetRequestAsync<List<TicketCategoryViewModel>>("api/v1/TicketCategory/List", this, true);

            lvTicketCategory.DataSource = ticketList;
            lvTicketCategory.DataBind();
        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvTicketCategory.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }
        protected async void EditButton_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            var categoryId = Convert.ToInt32(myButton.CommandArgument.ToString());
            var result = await HttpProvider.GetRequestAsync<TicketCategoryViewModel>("api/v1/TicketCategory/View?CategoryId=" + categoryId, this, true);

            CategoryName.Text = result.Name;
            CategoryId.Text = result.CategoryId.ToString();
            EditTable.Visible = true;

        }
        protected async void SaveBotton_Click(object sender, EventArgs e)
        {
            var category = new TicketCategoryViewModel
            {
                CategoryId = Int32.Parse(CategoryId.Text),
                Name = CategoryName.Text
            };
            var result = await HttpProvider.PostRequestAsync<int>("api/v1/TicketCategory/Update", category, this, true);

            if(result != 0)
            {
                EditTable.Visible = false;
                this.BindListView();
            }
        }
        protected async void DeleteButton_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            var CategororyId = Convert.ToInt32(myButton.CommandArgument.ToString());

            var result = await HttpProvider.GetRequestAsync<bool>("api/v1/TicketCategory/Delete?CategoryId=" + CategororyId, this, true);

            if(result)
            {
                this.BindListView();
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            EditTable.Visible = false;
        }
        protected async void NewButton_Click(object sender, EventArgs e)
        {
            var categoryName = NewCategory.Text;
            var result = await HttpProvider.PostRequestAsync<int>("api/v1/TicketCategory/Create?CategoryName=" + categoryName, null, this, true);
            if (result != 0)
            {
                this.BindListView();
            }
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            UserDetails.Logout();
            Response.Redirect("Login.aspx");
        }
    }
}