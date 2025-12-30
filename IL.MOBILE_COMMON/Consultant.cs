using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Consultant
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

        public List<ConsultantDetails> ConsultantList { get; set; }
    }

    public class ConsultantDetails
    {
        public int Consult_ID { get; set; }
        public string RegNo { get; set; }
        public string ConsultName { get; set; }
        public string USERID { get; set; }
        public string MobileNo { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

    }
}
