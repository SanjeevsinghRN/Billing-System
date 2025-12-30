using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Prescription
    {
        public string PrescriptionNo { get; set; }
        public int Status { get; set; }
        public Patient Patient { get; set; }
    }
}
