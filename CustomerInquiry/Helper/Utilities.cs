using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomerInquiry.Helper
{
    public static class Utilities
    {

       public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return true;
            }
            if ( email.Length <= 25 )
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    return true;
                }

            }
            return false;
           
        }
    }
}