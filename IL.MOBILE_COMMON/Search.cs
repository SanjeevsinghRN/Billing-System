using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/PROVIDER.SERVICE.Models", IsNullable = false)]
    public class Search
    {
        public string ErrorCode
        {
            get;
            set;
        }

        /// <remarks/>
        public string ErrorDesc
        {
            get;
            set;
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlArrayItemAttribute("SearchEntity", IsNullable = false)]
        public SearchEntity[] SearchList
        {
            get;
            set;
        }

        public SearchEntity[] TransList1 { get; set; }
        public SearchEntity[] TransList2 { get; set; }
    }

    public class AM_App_SortBy
    {
        public int patient_name { get; set; }
        public int provider_namne { get; set; }
        public int DOA { get; set; }


    }
    public class AM_App_FilterBy
    {
        public string provider { get; set; }
        public string payer { get; set; }
        public string noc_payer { get; set; }

        public string provider_name { get; set; }
        public string payer_name { get; set; }
        public string noc_payer_name { get; set; }
    }

    public class APP_STATUS
    {
        public string Status_id { get; set; }
        public string Status_name { get; set; }
    }

    public class HospitalData
    {
        public string HospCode { get; set; }
        public string HospName { get; set; }
        public string HospAddress { get; set; }
        public string HospCity { get; set; }
        public string HospState { get; set; }
        public string HospDistance { get; set; }
        public string ErrorMsg { get; set; }
        public string ErrorCode { get; set; }
        public string PortalUrl { get; set; }
        public string Portal_User_id { get; set; }
        public string Portal_Password { get; set; }
        public string TPACode { get; set; }
    }

    public class ParamountBeneficiaryRequest
    {
        public bool IsCorp { get; set; }
        public string CardNo { get; set; }
        public string EmpId { get; set; }
        public string insCardNo { get; set; }
        public string insName { get; set; }
        public string policyNo { get; set; }
        public string SearchType { get; set; }
        public string PayerCode { get; set; }
        public string IdCardNo { get; set; }
        public string MemberName { get; set; }
        public string CorporateName { get; set; }
        public string GroupCode { get; set; }
        public string InsuranceCo { get; set; }
    }

    public class ParamountInsReq
    {
       public string SearchType { get; set; }
       public string PayerCode { get; set; }
    }

    public class ZresultData
    {
        public string insuranceCompanyname { get; set; }

    }
    public class GetInsuranceDetailsResult
    {
        public string code { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public IList<ZresultData> zresultData { get; set; }

    }
    public class ParamountInsResp
    {
        public GetInsuranceDetailsResult GetInsuranceDetailsResult { get; set; }

    }

    public class ParamountPolicyReq
    {
        public string SearchType { get; set; }
        public string PayerCode { get; set; }
        public string PolicyNo { get; set; }
        public string IdCardNo { get; set; }
        public string MemberName { get; set; }
        public string EmpID { get; set; }
        public string CorporateName { get; set; }
        public string GroupCode { get; set; }
        public string InsuranceCo { get; set; }
        public string InsCardNo { get; set; }

    }


    public class ZresultDataPolResp
    {
        public string Age { get; set; }
        public string DOB { get; set; }
        public string EmailId { get; set; }
        public string EmployeeId { get; set; }
        public string Gender { get; set; }
        public string IDCardNo { get; set; }
        public string InsuredName { get; set; }
        public string MemberStatus { get; set; }
        public string Occupation { get; set; }
        public string PhoneNo { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public string PolicyNo { get; set; }
        public DateTime PolicyStarDate { get; set; }
        public string PolicyStatus { get; set; }

    }
    public class GetPolicyCardDetailsResult
    {
        public string code { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public IList<ZresultDataPolResp> zresultData { get; set; }

    }
    public class ParamountPolicyResp
    {
        public GetPolicyCardDetailsResult getPolicyCardDetailsResult { get; set; }

    }




    public class BajajBeneficiaryRequest
    {
        public string memberId { get; set; }
        public string PolicyNo { get; set; }
        public string EmployeeId { get; set; }
        public bool IsCorporate { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
    }

    public class MediassitBenRequest
    {
        public string MAID { get; set; }
        public string EmpId { get; set; }
        public string PolicyNo { get; set; }
        public string Corporate { get; set; }
        public string Name { get; set; }
        public string portalUrl { get; set; }
        public string portalUserId { get; set; }
        public string portalPwd { get; set; }

    }

    public class MediMemDet
    {
        public string PatName { get; set; }
        public string MAID { get; set; }
        public string Relation { get; set; }
        public string EmpId { get; set; }
        public string Gender { get; set; }
        public string PolicyHolder { get; set; }
        public string Insurance { get; set; }
        public string PolicyNo { get; set; }
        public string Age { get; set; }

    }


    public class BajajMemberDetails
    {
        public string PatName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Policy_No { get; set; }
        public string MemberId { get; set; }
        public string servicename { get; set; }
        public string employeeCode { get; set; }
        public string employeeName { get; set; }
        public string emailid { get; set; }
        public string mobileno { get; set; }
    }

    public class GentricMemDet
    {
        public string PatName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Policy_No { get; set; }
        public string Member_id { get; set; }
        public string EmpId { get; set; }
        public string CorporateName { get; set; }
        public string Age { get; set; }
    }

    public class IciciBeneficiaryRequest
    {
        public string UHID { get; set; }
        public string PolicyNo { get; set; }
        public string EmpId { get; set; }
        public string PolicyName { get; set; }
        public string EmployeeName { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
    }

    public class ReligareBeneficiaryRequest
    {
        public string UHID { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
        public string HospCode { get; set; }
      

    }

    public class StarBeneficiaryRequest
    {
        public string CardNo { get; set; }
        public string PolicyNo { get; set; }
        public string EmployeeId { get; set; }
        public string IntimationNo { get; set; }
        public bool IsCorporate { get; set; }
        public string corporate { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
    }

    public class StarNewBeneficiaryRequest
    {
        public string CardNo { get; set; }
        public string PolicyNo { get; set; }
        public string EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string PatientName { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
    }

    public class FHPLBeneficiaryRequest
    {
        public string UHID { get; set; }
        public string InsuranceId { get; set; }
        
        public string Insurance { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
    }

    public class ApolloMunichBeneficiaryRequest
    {
        public string UHID { get; set; }
        public string InsuranceId { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
    }

    public class HDFCBeneficiaryRequest
    {
        public string CardNo { get; set; }
        public string PolicyNo { get; set; }
        public string EmpID { get; set; }
        public string PolicyType { get; set; }
        public string PortalUrl { get; set; }
        public string PortalUserName { get; set; }
        public string PortalPassword { get; set; }
    }

    public class PBOTPRequest
    {
        public string MobileNo { get; set; }
        public string OTP { get; set; }
        public string IMEI_NO { get; set; }
        public string OTP_Generate { get; set; }
        public string OTP_Validate { get; set; }
        public string TNC_Accept { get; set; }
    }

    public class PBOTPResponse
    {
        public string MobileNo { get; set; }
        public string OTP { get; set; }
        public string OTP_Generated { get; set; }
        public string OTP_Validated { get; set; }
        public string TNC_Accepted { get; set; }
        public string Error_code { get; set; }
        public string Error_msg { get; set; }
    }

    public class BenficiaryPayerTypeResponse
    {
        public string PayerType { get; set; }
        public List<PolInputData> lstInputData { get; set; }
        public string ErrorMsg { get; set; }
        public string ErrorCode { get; set; }

    }

    public class PolInputData
    {
        public string MemberId_Title { get; set; }
        public string Insurance_Title { get; set; }
        public string PolicyNo_Title { get; set; }
        public string PatientName_Title { get; set; }
        public string EmployeeId_Title { get; set; }
        public string Corporate_Title { get; set; }
        public string Intimation_Title { get; set; }
        public string PolicyType { get; set; }
    }

   

    public class StarMemberDetails
    {
        public string PatientName { get; set; }
        public string PolicyNo { get; set; }
        public string CardNo { get; set; }
        public string ErrMsg { get; set; }
        public string MobileNo { get; set; }
        public string CorporateName { get; set; }
    }

    public class ErrorResponse
    {
        public string ErrorMsg { get; set; }
        public string ErrorCode { get; set; }
    }

    public class ReligareMemberDetails
    {
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string PolicyNo { get; set; }
        public string EmployeeId { get; set; }
        public string CorporateName { get; set; }
        public string ErrMsg { get; set; }
    }

    public class RPAStandingData
    {
        public string RPAPAYER_ID { get; set; }
        public string RPAPAYER_NAME { get; set; }
        public string RN_ID { get; set; }
        public string RN_NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string CONFIG_KEY { get; set; }
        public string ErrorMsg { get; set; }
        public string ErrorCode { get; set; }
    }

    public class FHPLMemberDetails
    {
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Relation { get; set; }
        public string Age { get; set; }
        public string PolicyNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
    }
 public class HdfcPolicyDet
    {

        public string Hdfcergo_id { get; set; }
        public string Policy_number { get; set; }
        public string Insured_Name { get; set; }
        public string Industry { get; set; }
        public string EMP_ID { get; set; }
        public int BussinessTransno_Num { get; set; }
        public string POLICY_START_DATE { get; set; }
        public string POLICY_END_DATE { get; set; }
        public string SessionCookie { get; set; }
        public string PortalUrl { get; set; }
    }

    public class IPIntegration_vidal_enroll_request
    {
        public string patientName { get; set; }
        public string enrollmentId { get; set; }
        public string policyNo { get; set; }
        public string employeeNo { get; set; }
        public string corporateName { get; set; }
        public string policyType { get; set; }
        public string payercode { get; set; }

    }
    public class IPIntegration_vidal_enroll_resonse
    {

        public List<result> result { get; set; }
        public string error_message { get; set; }
        public string status { get; set; }
    }

    public class result
    {
        public string patientName { get; set; }
        public string enrollmentId { get; set; }
        public string insCompName { get; set; }
        public string memberStatus { get; set; }
        public string policyEndDate { get; set; }
        public string policyNo { get; set; }
        public string memSumInsured { get; set; }
        public string policyStartDate { get; set; }
        public string emailId { get; set; }
        public string mobileNo { get; set; }
        public string employeeNo { get; set; }
        public string policyStatus { get; set; }
        public string corporateName { get; set; }
        public string dob { get; set; }
        public string age { get; set; }
        public string enrollValidYN { get; set; }
    }

    public class Paramount_Response
    {
        public string ErrMsg { get; set; }
        public List<Paramount_MemberDetails> MemDet { get; set; }

        public class Paramount_MemberDetails
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string DOB { get; set; }
            public string CardNo { get; set; }
            public string PhoneNo { get; set; }
            public string PolicyNo { get; set; }
            public string Gender { get; set; }
            public string EmployeeId { get; set; }
            public string EmailId { get; set; }
            public string InsuredName { get; set; }
            public string PolicyEndDate { get; set; }
            public string PolicyStartDate { get; set; }
            public string PolicyStatus { get; set; }
            public string resignDate { get; set; }
            public string TypeofPolicy { get; set; }
        }
    }

    public class HDFCMemberFullDetails
    {
        public string CardNo { get; set; }
        public string PolNo { get; set; }
        public string PatientName { get; set; }
        public string Relation { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Industry { get; set; }
        public string EMP_ID { get; set; }
        public string POLICY_START_DATE { get; set; }
        public string POLICY_END_DATE { get; set; }
    }
    public class RelianceRequest
    {
        public string PayerCode { get; set; }
        public string PolicyNo { get; set; }
        public string SearchType { get; set; }
        public string IdCardNo { get; set; }
        public string MemberName { get; set; }
        public string EmployeeId { get; set; }
        public string CorporateName { get; set; }
        public string GroupCode { get; set; }
    }
    public class RelianceResponse
    {
        public List<PolicyDetail> PolicyDetails { get; set; }
        public object ErrorCode { get; set; }
        public object Error { get; set; }
        public class PolicyDetail
        {
            public string PolicyNo { get; set; }
            public string IdCardNo { get; set; }
            public string InsuredName { get; set; }
            public DateTime DOB { get; set; }
            public string Age { get; set; }
            public DateTime PolicyStartDate { get; set; }
            public DateTime PolicyEndDate { get; set; }
            public string MemberStatus { get; set; }
            public string PhoneNo { get; set; }
            public string EmailId { get; set; }
            public string Occupation { get; set; }
            public int SumInsured { get; set; }
            public string PolicyStatus { get; set; }
            public string RenewalStatus { get; set; }
        }
    }
    
}
