using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RN.MOBILE_COMMON
{
   

    public class Diagnosis
    {
        public string ClaimID { get; set; }
        public String Patientname { get; set; }
        public String Date { get; set; }

        public DateTime? order_date { get; set; }

        public Int32 DiagnosisID { get; set; }
        public String AilmentName { get; set; }

        public String DiagnosisCode { get; set; }
        public String DiagnosisName { get; set; }
        public decimal DiagnosisRate { get; set; }
        public int Rowno { get; set; }
        public int patientid { get; set; }
        public string filename { get; set; }
        public int ShowReport { get; set; }
        public int AutoShowReport { get; set; }
        [Ignore]
        public DiagnosticDetails DiagnosticDetails { get; set; }
        [XmlElement]
        public List<Diagnosis> lst;
        public string showavailable { get; set; }
        public int Is_Ordered { get; set; }
        public string HC_CODE { get; set; }
        public string RESULT_VALUE { get; set; }
        public string OrderId { get; set; }

        public Int32 isHc { get; set; }
        public Int16 Discount { get; set; }
        public int Is_Rate_Defined { get; set; }

        public bool Is_Report_Uploaded { get; set; }

        public string Order_Status { get; set; }
        public string Visit_Type { get; set; }

        public int TestEnabled { get; set; }
    }

    public class DiagnosticDetails
    {
        public int DIAGNOSTIC_ID { get; set; }
        public string DIAGNOSTIC_Name { get; set; }
        public decimal DISCOUNT { get; set; }
        public int DIAGNOSTIC_TYPE { get; set; }
        public decimal WALLET_AMOUNT { get; set; }
        public string ENTITYCODE { get; set; }
    }

    public class DiagnosticRange
    {
        public string DIAGNOSTIC_CODE { get; set; }
        public string KEY { get; set; }
        public string VALUE { get; set; }
    }


    public class DiagnosticRate
    {
        public string Diagnostic_Code { get; set; }
        public string Diagnostic_Rate { get; set; }

    }
}
