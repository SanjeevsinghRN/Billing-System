using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Credential
    {
        public Credential()
        {
        }
        public string UserName
        {
            get;
            set;
        }
        public string ProviderCode
        {
            get;
            set;
        }
        public int ProviderID
        {
            get;
            set;
        }

        public string ProviderName
        {
            get;
            set;
        }

        public string UserRole
        {
            get;
            set;
        }
        public string Noc_Upload
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }
        public string ErrorDesc
        {
            get;
            set;
        }

        public int ViewMode
        { get; set; }

        public bool DashBoardRef { get; set; }

        public int RefDurInSec { get; set; }

        public string Doc_Workflow { get; set; }

        public int NotificationType { get; set; }

        public string EntityLogo { get; set; }

        public int KioskTimeOut { get; set; }

        public int ShowDocSettings { get; set; }

        public int ShowAllDocCase { get; set; }

        public int KIOSK_fontSize_Search_header { get; set; }

        public int KIOSK_fontSize_header { get; set; }

        public int KIOSK_fontSize_content { get; set; }

        public int KIOSK_fontSize_button { get; set; }
    }

    public class EntityCredential
    {
        public EntityCredential()
        {
        }

        public int USER_ID { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL_ID { get; set; }
        public int USER_TYPE { get; set; }
        public string USER_ROLE { get; set; }
        public string LOGIN_ID { get; set; }
        public string USER_NAME { get; set; }
        public string ENTITYCODE { get; set; }
        public string ENTITYNAME { get; set; }
        public string APPROVED { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public int OTP_VERIFIED { get; set; }
        public int ENTITYID { get; set; }
        public int IS_HIS { get; set; }
        public int INVENTORY_CHECK { get; set; }
        public string MOU_FILENAME { get; set; }
        public string FAILEDATTEMPT { get; set; }

        public string MPIN_FAIL_COUNT { get; set; }
        public string CHANGE_PWD_FAIL_COUNT { get; set; }
        public int Minor_Procedure { get; set; }
        public int Minor_Test { get; set; }
        public int Symptoms { get; set; }
        public int Diagnosis { get; set; }
        public int Drug { get; set; }
        public int Lab_Test { get; set; }

        public string VALOTPROLE { get; set; }

    }
}
