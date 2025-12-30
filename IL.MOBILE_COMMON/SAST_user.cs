using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    class SAST_user
    {
    }
    public class Address
    {
        public string statelgdCode { get; set; }
        public string benstatelgdCode { get; set; }
        public string districtlgdCode { get; set; }
        public string subdistrictlgdCode { get; set; }
        public string bendistrictlgdCode { get; set; }
        public string address { get; set; }
        public string village_townlgdCode { get; set; }
        public string ruralUrban { get; set; }
        public string pinCode { get; set; }
    }

    

    public class Family
    {
        public string hhid { get; set; }
        public string scode { get; set; }
        public string bentype { get; set; }
        public string hhdtype { get; set; }
        public string stateName { get; set; }
        public List<FamilyMember> familyMember { get; set; }
        public string WardEntitlement { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string BasicPay { get; set; }
    }

    public class FamilyMember
    {
        public string careOfTypeDec { get; set; }
        public string careOfDec { get; set; }
        public string memberName { get; set; }
        public string fatherName { get; set; }
        
        public string EmployeeName { get; set; }
        public string gender { get; set; }
        public string yearOfBirth { get; set; }
        public string photo { get; set; }
        public string mobileNumber { get; set; }
        public Address address { get; set; }
        public string venderToken { get; set; }
        public string AadharVaultno { get; set; }
        public string tempId { get; set; }
        public string dependent_flag { get; set; }
        public string member_id { get; set; }
        public string dateofbirth { get; set; }
        public string agegroup { get; set; }
        public string card_delivery_status { get; set; }
        public string card_delivery_date { get; set; }
        public string health_id { get; set; }
        public string nhaid { get; set; }
        public string aaa_URN { get; set; }
        public string aaa_enrollment_date { get; set; }
        public string aaa_expiry_date { get; set; }
        public string aaa_flag { get; set; }
        public string s_flag { get; set; }
        public string familyDocTyp { get; set; }
        public string familyDocId { get; set; }
    }

    public class FamilySearchDetails
    {
        public List<Family> family { get; set; }
    }

    public class Header
    {
        public string errorCode { get; set; }
        public string version { get; set; }
        public BeneficiaryDetails beneficiaryDetails { get; set; }
    }
    public class BeneficiaryDetails
    {
        public string ahlTinId { get; set; }
        public string uuid { get; set; }
        public string hhId { get; set; }
        public string mobileNumber { get; set; }
        public string aadharToken { get; set; }
        public RationCardDetails rationCardDetails { get; set; }
        public string familyType { get; set; }
        public string health_id { get; set; }
    }

    public class RationCardDetails
    {
        public string rationCard { get; set; }
        public string stateCode { get; set; }
    }

    public class SAST_user_Root
    {
        public bool status { get; set; }
        public string operation { get; set; }
        public string errorcode { get; set; }
        public string errorMessage { get; set; }
        public Header header { get; set; }
        public FamilySearchDetails familySearchDetails { get; set; }
    }

    public class BeneficiaryDetails_rsqt
    {
        public string ahlTinId { get; set; }
        public string uuid { get; set; }
        public string hhId { get; set; }
        public string mobileNumber { get; set; }
        public string aadharToken { get; set; }
        public RationCardDetails_rsqt rationCardDetails { get; set; }
        public string familyType { get; set; }
        public string health_id { get; set; }
    }

    public class RationCardDetails_rsqt
    {
        public string rationCard { get; set; }
        public string stateCode { get; set; }
    }

    public class SAST_Root_rsqt
    {
        public string hmac { get; set; }
        public string token { get; set; }
        public string errorCode { get; set; }
        public BeneficiaryDetails_rsqt beneficiaryDetails { get; set; }
    }


}
