using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class User
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public int? Age { get; set; }

        public int GenderID { get; set; }

        public string Gender { get; set; }

        public string MobileNo { get; set; }

        public string EmailID { get; set; }

        public int UserType { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public int CityID { get; set; }

        public string Address { get; set; }

        public string PINCode { get; set; }

        public string OTP { get; set; }

        public bool IsOTPVerified { get; set; }

        public int RelationShipID { get; set; }

        public string DOB { get; set; }

        public decimal WalletAmount { get; set; }

        public int DeliveryBoyPharmacyid { get; set; }
        [Ignore]
        public Pharmacy Pharmacy { get; set; }

        public string Error { get; set; }

        public string ErrorDesc { get; set; }

        public string LoginID { get; set; }

        [Ignore]
        public Diagnostic Diagnostic { get; set; }

        public string CityName { get; set; }

        public string EntityCode { get; set; }

        public int EntityId { get; set; }

        public bool IsBillDeskEnable { get; set; }

        public bool IsActive { get; set; }
        [Ignore]
        public AutoRefreshScreen PageRefreshTimeOut { get; set; }

        public int ShowReportAutomatic { get; set; }

        public int IsDisclaimerAgreed { get; set; }

        public int is_show_prescription_depend { get; set; }

        public string Token { get; set; }

        public string LastLoginTime { get; set; }

        public string EntityName { get; set; }

        public string IsPrimaryMember { get; set; }

        public bool isHIS { get; set; }

        public int Is_Disable_flag { get; set; }

        public int DisableCashlessBtn { get; set; }

        public string StateName { get; set; }

        public bool Is_Entity_Active { get; set; }

        public string MODIFIED_BY { get; set; }

        public string VISITORIP { get; set; }

        public string DEVICEID { get; set; }
        public bool FREETEXT_MINOR_PROCEDURE { get; set; }
        public bool FREETEXT_MINOR_TEST { get; set; }
        public bool FREETEXT_SYPTOMS { get; set; }
        public bool FREETEXT_DIAGNOSIS { get; set; }
        public bool FREETEXT_DRUG { get; set; }
        public bool FREETEXT_LAB_TEST { get; set; }

        public string CorporateCode { get; set; }
        public string broker_code { get; set; }
        public string userRole { get; set; }
        
    }
    public class LoginUser
    {
        public string token { get; set; }
        public string Error { get; set; }
        public string UserID { get; set; }
    }

    public class AutoRefreshScreen
    {
        public int DashBoardTimeOut { get; set; }
        public int ChatPageTimeOut { get; set; }
    }
    public class MenuItemList
    {
        public List<MenuItemData> ParentMenu { get; set; }
        public List<MenuItemData> ChildMenu { get; set; }
    }
    //    public class MenuItemData
    //{
    //    public int ID { get; set; }
    //    public string Title { get; set; }
    //    public string Action { get; set; }
    //    public string Controller { get; set; }
    //    public string Icon { get; set; }
    //    public int ParentMenuId { get; set; }
    //    public bool HasSubMenu { get; set; }
    //    public int NewTab { get; set; }
    //    public string Value_Enum { get; set; }
    //}
    public class MenuItemData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public int ParentMenuId { get; set; }
        public bool HasSubMenu { get; set; }
        public int NewTab { get; set; }
        public string Value_Enum { get; set; }
        //public List<MenuItemData> ChildMenu { get; set; } = new List<MenuItemData>(); // Add this property
    }

}
