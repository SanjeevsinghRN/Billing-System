using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
  public  class PasswordValidation
    {
        public static string ValidatePasswordPattern(string password)
        {
            string patternIstChar = @"^[a-zA-Z]{1}";// @"^.*(?=^.\w{1,})(?=.*\d)(?=.*[a-zA-Z])(?=.*[!*@#$%^&+=]).{8,10}";
            string patterndigit = @"\d+";
            string patternSpecialChar = @"[!@#%^&*()]";
            string patternUpperChar = @"[A-Z]";
            string patternLowerChar = @"[a-z]";
            string patternExcludedSpecialChar = @"[^a-zA-Z0-9!@#%^&*()]";

            if (password.Length < 8)
            {
                return "Entered new password must be atleast 8 characters long.";
            }
           else if (password.Length > 20 )
            {
                return "Entered new password should not exceed 20 characters.";
            }
            else if(!Regex.Match(password, patternIstChar).Success)
            {
                return "Entered new password must starts with a character";
            }
            else if (!Regex.Match(password, patterndigit).Success)
            {
                return "Entered new password must include atelast one number.";
            }
            else if (!Regex.Match(password, patternSpecialChar).Success && Regex.Match(password, patternExcludedSpecialChar).Success)
            {
                return "Entered new password should include only these !@#%^&*()  special character.";
            }
            else if (!Regex.Match(password, patternSpecialChar).Success)
            {
                return "Entered new password must include a special character.";
            }
            else if (Regex.Match(password, patternExcludedSpecialChar).Success)
            {
                return "Entered new password should include only these !@#%^&*()  special character.";
            }
            else if (!Regex.Match(password, patternUpperChar).Success)
            {
                return "Entered new password must include a upper case character.";
            }
            else if (!Regex.Match(password, patternLowerChar).Success)
            {
                return "Entered new password must include a lower case character.";
            }
            return "";
        }

        public static  string PasswordValidationPatternMsg = "Entered new password must contain atleast one upper case letter[A-Z], atleast one lower case letter[a-z], atleast one number [0-9], and have a minimum length of 8 characters.Allowed symbols are !@#%^&*()";
    }
}
