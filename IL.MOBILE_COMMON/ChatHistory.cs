using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class ChatHistory
    {
        public int ChatID { get; set; }

        public string ChatText { get; set; }

        public string MediaName { get; set; }

        public string ChatDate { get; set; }

        public string PrescriptionID { get; set; }

        public int PatientID { get; set; }

        public int PhysicianID { get; set; }

        public int UserType { get; set; }

        public int IsSeen { get; set; }
    }
}
