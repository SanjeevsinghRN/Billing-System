using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Provider
    {
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string ProviderId { get; set; }
    }

    public class IMEIAff_Provider
    {
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string ProviderId { get; set; }
    }

    public class IMEIAff_Payer
    {
        public string payercode { get; set; }
        public string payername { get; set; }     
        public int portal_payer { get; set; }
    }

   

    public class ProviderList
    {
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string ProviderId { get; set; }
        public string Address { get; set; }
        public List<Diagnosis> Diagnosislist { get; set; }
    }
}
