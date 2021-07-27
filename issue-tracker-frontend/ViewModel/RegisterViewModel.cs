using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public RegisterViewModel(string email, string firstName, string lastName, string password)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
        }
    }
}