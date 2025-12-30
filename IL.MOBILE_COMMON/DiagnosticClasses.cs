using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Diagnostic
    {
        public int DiagnosticID { get; set; }
        public string DiagnosticName { get; set; }
        public int DiagnosticType { get; set; }
        public decimal Discount { get; set; }
        public string EntityCode { get; set; }
        public decimal WalletAmt { get; set; }
        [Ignore]
        public GeoLocation Geolocation { get; set; }
        public string mobileno { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string city_name { get; set; }
        public string prescriptionId { get; set; }
        public string TransactionType { get; set; }
        public Int32 Is_health_check { get; set; }
        public string AvilTestList { get; set; }
        public string NonAvilTestList { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }
        public string Entity_ContactNo { get; set; }
        public string AGGREGATOR_TYPE { get; set; }
        public decimal ServiceCharge { get; set; }

    }

    public class DiagTestSearch
    {
        public List<Diagnostic> diagnosticLst { get; set; }
        public List<Diagnosis> diagnosisLst { get; set; }

        public List<Diagnosis> EntityProvidedTest { get; set; }
    }

    public class DiagnosticDashborad
    {
        public List<string> lstMonitorDate { get; set; }
        public List<DiagnosticRange> Diagnostic_Range { get; set; }
        public List<Diagnosis> DiagnosisDetail { get; set; }
    }
}
