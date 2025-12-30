using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class OP_OfflineCheckList
    {
        public int Transaction_Count { get; set; }
        //public int ServiceFeedback_Count { get; set; }
        public int InsBenefitUtil_Consult_Count { get; set; }
        public int InsBenefitUtil_Diag_Count { get; set; }
        public int InsBenefitUtil_Phar_Count { get; set; }
        public int InsPolicyCoverData { get; set; }
        public int GetCoverages { get; set; }
        public int Appointment_Count { get; set; }
        public int NotificationDashboard_Count { get; set; }
        public int Medicine_Reminder_Count { get; set; }
        public int RateUs_Count { get; set; }
        public string GetcontactEmalID { get; set; }
        public int VitalsDashboard_Count { get; set; }
        public int FAQ_Count { get; set; }
        public int HowToUse { get; set; }
        public int LookUp_Count { get; set; }
        public int Utils_Config_Count { get; set; }
        public OfflineCheckList_Para Webapi_Para { get; set; }
        public int Reimbursement_Count { get; set; }
    }

    public class OfflineCheckList_Para
    {
        public string UserID { get; set; }
        public int Trans_PageNo { get; set; }
        public int Trans_NumRow { get; set; }
        public string Trans_LastFeatchTime { get; set; }
        public string MemberNo { get; set; }
        public string Mobile { get; set; }
        public string Appointment_LastFeatchTime { get; set; }
        public string Notification_LastFeatchTime { get; set; }
        public string Reminder_LastFeatchTime { get; set; }
        public string PayerCode { get; set; }
        public string Vital_LastFeatchTime { get; set; }
        public int UserType { get; set; }
    }
}
