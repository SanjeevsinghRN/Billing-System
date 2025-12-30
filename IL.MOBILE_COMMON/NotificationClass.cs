using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
   public class NotificationClass
    {
        public string CLAIM_ID { get; set; }
        public string NOTIFICATION_MSG { get; set; }
        public string NOTIFICATION_TITLE { get; set; }
        public string NOTIFICATION_TYPE { get; set; }
        public string USER_ID { get; set; }
        public string SENTON { get; set; }
        public string RESPONSE { get; set; }
        public string ORDERID { get; set; }
        public int ISREFUNDNOTIFICATION { get; set; }
        public string ONEMG_ORDER_ID { get; set; }
        public string NOTIFICATION_DAYS { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public string LastFetchTime { get; set; }
     
    }
}
