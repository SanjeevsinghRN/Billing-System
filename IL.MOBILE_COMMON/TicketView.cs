using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class TicketView : IDisposable
    {
        public string Ref_No { get; set; }
        public string Hid { get; set; }
        public string ProviderName { get; set; }
        public string TicketID { get; set; } 
        public string Status { get; set; }
        public string UserID { get; set; }
        public string Remarks { get; set; }
        public string QueryType { get; set; }
        public string QuerySubType { get; set; } 
        public string CreatedDate { get; set; }
        public string isViewed { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
