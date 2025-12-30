using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class TblDia_Phy_data
    {
        public string CLAIM_ID { get; set; }
        public int DRUG_ID { get; set; }
        public string NAME { get; set; }
        public int NO_OF_TABLET { get; set; }
        public decimal BILL_AMOUNT { get; set; }
        public decimal RATE { get; set; }
        public string AILMENT_REMARKS { get; set; }
        public int AILMENT_ID { get; set; }
        public string VPHARMACY_CODE { get; set; }
        public string MEMBER_ID { get; set; }
    }
}
