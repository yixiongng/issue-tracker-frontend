using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issue_tracker_frontend.ViewModel
{
    public class UserDetails
    {
        public static int UserID;
        public static string FirstName;
        public static string LastName;
        public static string Token;
        public static void Logout()
        {
            UserID = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Token = string.Empty;
        }

    }
}