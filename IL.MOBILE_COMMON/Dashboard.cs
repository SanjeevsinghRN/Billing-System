using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models", IsNullable = false)]
    public class Dashboard
    {
        public Dashboard()
        {
        }

        //		[XmlElement("PA")]
        //		public List<DashboardEntity> PA { get; set; }
        //		[XmlElement("PD")]
        //		public List<DashboardEntity> PD { get; set; }
        //		[XmlElement("CL")]
        //		public List<DashboardEntity> CL { get; set; }
        //[System.Xml.Serialization.XmlArrayItemAttribute("DashboardEntity", IsNullable = false)]
        public DashboardEntity[] CL
        {
            get;
            set;
        }

        //[System.Xml.Serialization.XmlArrayItemAttribute("DashboardEntity", IsNullable = false)]
        public DashboardEntity[] PA
        {
            get;
            set;
        }

        //[System.Xml.Serialization.XmlArrayItemAttribute("DashboardEntity", IsNullable = false)]
        public DashboardEntity[] PD
        {
            get;
            set;
        }

        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class MedicalSummaryDashboard
    {
        public List<string> lstMonitorDate { get; set; }
        public List<Vital_Controls> lstVitalsDetails { get; set; }
        public List<Diagnosis> DiagnosisDetail { get; set; }
        public List<DiagnosticRange> Diagnostic_Range { get; set; }
    }

    public class MessageBox_History
    {
        public string msgid { get; set; }
        public string message { get; set; }
        public string refno { get; set; }
        public string postedon { get; set; }
        public string postedby { get; set; }

        public string MESSAGESTATUS { get; set; }
        public string HID { get; set; }
        public string PENWITHPAT { get; set; }
        public string DAFOUP { get; set; }
        public string NOFOLLOW { get; set; }

        public string PATNOTADMIT { get; set; }

    }

    public class AMApp_MessageBox
    {
        public string patientname { get; set; }
        public string hospname { get; set; }
        public string tpaname { get; set; }
        public string tpaid { get; set; }
        public string refno { get; set; }

        public List<MessageBox_History> Messageboxhistory { get; set; }
    }
}
