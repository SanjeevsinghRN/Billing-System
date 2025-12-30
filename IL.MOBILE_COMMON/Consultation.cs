using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Consultation
    {
        public string ConsultationNo { get; set; }
        public string ReviewDate { get; set; }
        public string ConsulationRemarks { get; set; }
        public string ConsultationFee { get; set; }
        public string AilmentID { get; set; }

        public string Speciality { get; set; }

        public string prescriptionId { get; set; }
        public string TransactionType { get; set; }
        public Int32 Is_health_check { get; set; }
    }
}
