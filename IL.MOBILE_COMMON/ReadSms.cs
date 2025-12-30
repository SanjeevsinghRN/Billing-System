using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class ReadSms
    {
        public string MSGID { get; set; }
        public string SENDER_ADD { get; set; }
        public string RECEIVER_ADD { get; set; }
        public string Message { get; set; }
        public string DeviceId { get; set; }
        public string GUID { get; set; }
        public string SMS_DATE_TIME { get; set; }
    }

    public class SAVEDSMS
    {
        public string Totalcount { get; set; }
        public string LastUpdatedTime { get; set; }
    }
}
