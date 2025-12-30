using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
   public  class PApolicydetails
    {
       public string COLUMN_PROPERTIES { get; set; }
       public string COLUMN_VALUE { get; set; }
       public string VALIDATION_MSG { get; set; }

       public List<PApolicydetails> Policydata { get; set; }
    }
}
