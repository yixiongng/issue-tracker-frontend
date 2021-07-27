using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginViewModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}