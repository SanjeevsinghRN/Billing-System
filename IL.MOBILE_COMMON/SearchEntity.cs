using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models")]
    public class SearchEntity
    {
        public string InboxType
        {
            get;
            set;
        }

        /// <remarks/>
        public string Name
        {
            get;
            set;
        }

        /// <remarks/>
        public string Payer
        {
            get;
            set;
        }

        /// <remarks/>
        public string RefNo
        {
            get;
            set;
        }

        /// <remarks/>
        public string TreatmentCost
        {
            get;
            set;
        }
        public string OTP
        {
            get;
            set;
        }

        public string Age
        {
            get;
            set;
        }

        public string DOB
        {
            get;
            set;
        }

        public string ActionStatus
        {
            get;
            set;
        }

        public string Date { get; set; }

        public string ADate { get; set; }

        public string MobileNo { get; set; }

        public string IP_NO { get; set; }
        public string PayerCode { get; set; }
        public string AuthLetter { get; set; }
        public int ClaimType { get; set; }
        public string providercode { get; set; }
        public string providername { get; set; }

        public DateTime? ADateTime { get; set; }
        public int IsQuiclaim { get; set; }

        public string BillAmount { get; set; }
        public string ApprovedAmount { get; set; }
        public string logo_file_name { get; set; }

    }
}
