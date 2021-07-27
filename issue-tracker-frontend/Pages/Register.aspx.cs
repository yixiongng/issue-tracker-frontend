using issue_tracker_frontend.Providers;
using issue_tracker_frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace issue_tracker_frontend.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected async void RegisterButton_Click(object sender, EventArgs e)
        {
            var Isvalidated = true;
            FirstNameMessage.Text = "";
            LastNameMessage.Text = "";
            EmailMessage.Text = "";
            PasswordMessage.Text = "";
            ConfirmPasswordError.Text = "";
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                FirstNameMessage.Text = "First Name cannot be empty";
                Isvalidated = false;
            }
            if (string.IsNullOrEmpty(LastName.Text))
            {
                LastNameMessage.Text = "Last Name cannot be empty";
                Isvalidated = false;
            }
            if (string.IsNullOrEmpty(Email.Text))
            {
                EmailMessage.Text = "Email cannot be empty";
                Isvalidated = false;
            }
            else if (!IsValidEmail(Email.Text))
            {
                EmailMessage.Text = "Email syntax not correct";
                Isvalidated = false;
            }
            if (string.IsNullOrEmpty(Password.Text))
            {
                PasswordMessage.Text = "Password cannot be empty";
                Isvalidated = false;
            }
            else if (!IsValidPassword(Password.Text))
            {
                PasswordMessage.Text = "Password must contains upper case, lower case, number, and at least 8 characters long";
                Isvalidated = false;
            }
            if(Password.Text != ConfirmPassword.Text)
            {
                ConfirmPasswordError.Text = "Password does not match";
                Isvalidated = false;
            }
            if(Isvalidated)
            {
                var register = new RegisterViewModel(Email.Text, FirstName.Text, LastName.Text, Password.Text);
                var result = await HttpProvider.PostRequestAsync<bool>("api/v1/User/SignUp", register, this);

                if (result)
                {
                    string scriptText = "alert('Regisiter successfully!'); window.location='" + Request.ApplicationPath + "Pages/Login.aspx'";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
                }
                else
                {
                    string scriptText = "alert('Error! Please try again!')";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
                }
            }
            
        }
        protected bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        protected bool IsValidPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password) && hasLowerChar.IsMatch(password);

            return isValidated;
        }

    }
}