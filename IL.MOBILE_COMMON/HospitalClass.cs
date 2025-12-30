using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Hospital
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string EntityCode { get; set; }
        public GeoLocation Geolocation { get; set; }
        public string mobileno { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string city_name { get; set; }
        public string Entity_ContactNo { get; set; }

        public string payer_code { get; set; }
        public string payer_name { get; set; }
        public string memberid { get; set; }
        public string policyno { get; set; }
       
        public string corporate_id { get; set; }
        public string corp_name { get; set; }

        public long isquiclaim { get; set; }
        
        public string city { get; set; }

        public string employee_id { get; set; }

        
    }

    public class HospitalSearch
    {
        public List<Hospital> HospitalLst { get; set; }
     
    }

    public class HospitalDashborad
    {
        public List<Hospital> HospitalDetail { get; set; }
    }
}
