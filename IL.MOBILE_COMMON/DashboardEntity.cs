using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models")]
    public class DashboardEntity
    {
        public DashboardEntity()
        {
        }
        public string Name { get; set; }
        public int Count { get; set; }
        public int InboxType { get; set; }
        public int DashboardType { get; set; }
    }
}
