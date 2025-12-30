using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    class PerformanceReport
    {
        
    }
    class PerformanceReport_Top_Tpa
    {
        public string TpaName { get; set; }
        public string Count { get; set; }
        public string Perc { get; set; }
    }

  public  class PerformanceReport_Top_Tpa_PDF
    {
        public string month { get; set; }
        public string entityCode { get; set; }
        public string year { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string filterType { get; set; }
        public string periodType { get; set; }
        public bool ISPdf { get; set; }
        public string userID { get; set; }
        public string IPAddress { get; set; }
    }
    public class PerformanceReportAPIStatus
    {
        public string Content { get; set; }
        public bool IsDownloaded { get; set; }
    }
}
