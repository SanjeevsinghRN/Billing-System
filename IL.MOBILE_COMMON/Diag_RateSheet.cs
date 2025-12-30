using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace RN.MOBILE_COMMON
{
   [System.Xml.Serialization.XmlRoot("RATESHEET")]
   public class Diag_RateSheet
    {
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public decimal? StandardDiscount { get; set; }
        public Int32 RateSheetId { get; set; }
        public List<RateList> ObjRateList { get; set; }
        public string ToXML()
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(stringwriter, this);
            return stringwriter.ToString();
        }
    }

    public class RateList
    {
        public string DiagCode { get; set; }
        public string DiagName { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public Int32 RateSheetId { get; set; }
        public int IsUpdated { get; set; }
        public int IsDeleted { get; set; }

        public int VisitType { get; set; }
    }
}
