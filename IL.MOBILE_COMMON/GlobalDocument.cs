using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class GlobalDocument
    {
        public string Document_id{get;set;}
        public string Document_code{get;set;}
        public string Document_name { get; set; }
        public string Document_type { get; set; }
        public string FileName { get; set; }
        public string Mandatory { get; set; }
        public string Claim_id { get; set; }
        public string PA_LEVEL { get; set; }
        public string PD_LEVEL { get; set; }
        public string CL_LEVEL { get; set; }
        public string REFER_DOC_ID { get; set; }
        public string REFER_DOCUMENT { get; set; }
        public string REFER_DOCUMENT_NAME { get; set; }
        public Int32 IsEnable { get; set; }
    }
}
