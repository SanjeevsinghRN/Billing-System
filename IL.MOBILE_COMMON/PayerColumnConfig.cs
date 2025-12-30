using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RN.MOBILE_COMMON
{
    public class PayerColumnConfig 
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
        public List<PayerColumn> _getColumn { get; set; }
    }
    public class PayerColumn
    {
        public String COLUMN_PROPERTIES { get; set; }
        public String COLUMN_DESC { get; set; }
    }
}