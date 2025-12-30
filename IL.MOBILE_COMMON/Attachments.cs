using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RN.MOBILE_COMMON
{
    public class OP_Attachments
    {
        public string Claim_Id { get; set; }

        public int PatientId { get; set; }

        public string AttachFileName { get; set; }

        public string AttachmentRemarks { get; set; }

        public string AttachDate { get; set; }

        public int Self_ID { get; set; }

        public string FilePath { get; set; }
        [Ignore]
        public string Member_ID { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public string DEVICEID { get; set; }
        public string VISITORSIP { get; set; }
    }

    public class Rem_Attachments
    {
        public string Rem_Id { get; set; }

        public int PatientId { get; set; }

        public string AttachFileName { get; set; }

        public string AttachmentRemarks { get; set; }

        public string AttachDate { get; set; }

        public int Self_ID { get; set; }

        public string FilePath { get; set; }

        public int ServiceType { get; set; }

        public double? ClaimedAmount { get; set; }

        [Ignore]
        public string Member_ID { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public string DEVICEID { get; set; }
        public string VISITORSIP { get; set; }
        public string AttachFileName_Local { get; set; }
        public string AttachFileName_NEFT { get; set; }
        public string AttachFileName_Bill { get; set; }
        public string AttachFileName_Prescription { get; set; }
        public string AttachFileName_Others { get; set; }
        public string File_Size { get; set; }
    }

}
