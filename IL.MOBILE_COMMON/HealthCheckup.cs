using SQLite;
using System;
using System.Collections.Generic;

namespace RN.MOBILE_COMMON
{
    public class HealthCheckup
    {
        public int HCId { get; set; }
        public string HCCode { get; set; }
        public string HCName { get; set; }
        public string HCDate { get; set; }
        public decimal Rate { get; set; }
        public string filename { get; set; }
        [Ignore]
        public List<Diagnosis> lstDiagTest { get; set; }
        public string Prescription_id { get; set; }

    }
}
