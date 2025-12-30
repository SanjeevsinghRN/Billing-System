using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class PolicySearchColumnConfig
    {
        public string ErrorCode
        {
            get;
            set;
        }

        /// <remarks/>
        public string ErrorDesc
        {
            get;
            set;
        }
        public int isEnable { get; set; }
        public string PayerIdentityKey { get; set; }
        public List<PolicySearchColumn> _getSearchColumn { get; set; }
    }

    public class PolicySearchColumn
    {
        public string COLUMN_NAME { get; set; }
        public string COLUMN_NAME_SERVICE { get; set; }
        public int COLUMN_ISOPTIONAL { get; set; }
        public int COLUMN_PK { get; set; }

    }
}
