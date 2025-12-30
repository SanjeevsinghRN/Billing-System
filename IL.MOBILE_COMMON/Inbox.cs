using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models")]
   // [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models", IsNullable = false)]
    public class Inbox
    {
        public Inbox()
        {
        }

        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }



        private InboxEntity[] inboxListField;


        //[System.Xml.Serialization.XmlArrayItemAttribute("InboxEntity", IsNullable = false)]
        public InboxEntity[] InboxList
        {
            get
            {
                return this.inboxListField;
            }
            set
            {
                this.inboxListField = value;
            }
        }
    }
}
