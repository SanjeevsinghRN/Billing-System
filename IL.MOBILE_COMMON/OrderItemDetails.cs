using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class OrderItemDetails
    {
        public string order_id { get; set; }
        public string drug_name { get; set; }
        public string mg_ml { get; set; }
        public string quntity { get; set; }
        public string drug_type { get; set; }
        public string mrp { get; set; }
        public string discount { get; set; }
        public string offer_price { get; set; }
        public string  Status { get; set; }
        public int drugid { get; set; }
        public string drugcode { get; set; }
        public string Mobile_no { get; set; }
        public string billAmount { get; set; }
        public string Rate { get; set; }
        public int PLACE_ORDER_MULTIPLE { get; set; }
        public string payerdrugcode { get; set; }
    }
}
