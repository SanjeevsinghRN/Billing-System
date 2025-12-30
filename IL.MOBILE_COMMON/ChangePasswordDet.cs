using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class ChangePasswordDet
    {
        public string Error
        {
            get;
            set;
        }
        public string ErrorDesc
        {
            get;
            set;
        }
        public bool PasswordChanged { get; set; }
    }
}
