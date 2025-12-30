using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }

        public List<City> Cities { get; set; }
    }
}
