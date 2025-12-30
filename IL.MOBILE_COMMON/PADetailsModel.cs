using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class PADetailsModel
    {
        public string ErrorCode
        {
            get;
            set;
        }

        /// <remarks/>
        public string ErrorDesc
        {
            get;
            set;
        }

        public string FetchingError { get; set; }

        public List<PADetails> _getPADetails { get; set; }
    }

    public class PADetails
    {
        public string PAName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string PolicyNo { get; set; }
        public string MemberID { get; set; }
        public string CorporateName { get; set; }
        public string EmployeeID { get; set; }
        public string IDCardNo { get; set; }
        public string DOB { get; set; }
        public string PayerCode { get; set;}
    }
}
