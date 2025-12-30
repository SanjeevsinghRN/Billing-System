using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class DiagnosticOrderDetail
    {
        public PrescriptionClass PrescriptionDet { get; set; }
        public string OrderNo { get; set; }
        public string OrderAmt { get; set; }
        public string OrderStatus { get; set; }
        public Payment PaymentDet { get; set; }
    }
}
