using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class SearchInput
    {
        public string ENTITYTYPE { get; set; }
        public string LOGINENTITYID { get; set; }
        public string PROVIDERID { get; set; }
        public string FILTERBY { get; set; }
        public string IS_MOBILE { get; set; }
        public string MOBILE_SEARCH_TEXT { get; set; }

        public SearchInput()
        {
            ENTITYTYPE = "H";
            IS_MOBILE = "1";
        }

    }
}
