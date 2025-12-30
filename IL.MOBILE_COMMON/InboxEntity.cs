using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
   // [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models")]
    public partial class InboxEntity
    {
        public string Name { get; set; }
        public string PayerName { get; set; }
        public string ReferenceNumber { get; set; }
        public string RequestedAmount { get; set; }
        public string ActionStatus { get; set; }
        public string Date { get; set; }
        public string MailStatus { get; set; }
        public string CONSULTANT_USERID { get; set; }
        public string PayerCode { get; set; }
        public string ClaimId { get; set; }
        public string SignatureFileName { get; set; }
        public string PAYER_AUTH_LETTER { get; set; }
        public string Is_DayCare { get; set; }
    }
}
