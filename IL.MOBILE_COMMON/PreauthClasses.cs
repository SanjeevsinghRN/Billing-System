using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace RN.MOBILE_COMMON
{
    public class PreauthClasses
    {
        public List<Relation> _relation { get; set; }
        public List<PAPayer> _payer { get; set; }
        public List<Gender> _gender { get; set; }
        public List<AdmissionType> _admissionType { get; set; }
        public List<PADelivery> _delivery { get; set; }
        public List<PATreatmentType> _treatmentType { get; set; }
        public List<PATreatmentSubType> _treatmentSub { get; set; }
        public List<PAZone> _zone { get; set; }
        public List<PAInsurance> _insurance { get; set; }
        public List<PACorporate> _corporate { get; set; }
        public List<PARoomType> _roomType { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
    }
    public class Relation
    {
        public int VALUE_ID { get; set; }
        public string VALUE_DESC { get; set; }
        public string VALUE_CODE { get; set; }
    }
    public class PAPayer
    {
        public string PAYERCODE { get; set; }
        public string PAYERNAME { get; set; }
        public int ISQUICLAIM { get; set; }
        public int ISCLAIMPAYER { get; set; }
        public int CLAIMS_MASTER_DATA { get; set; }
        public string UPLOAD_FILE_TYPES { get; set; }
        public int UPLOAD_FILE_SIZE { get; set; }
        public int IS_BENEFICIARY_SEARCH { get; set; }
    }
    public class Gender
    {
        public int VALUE_ID { get; set; }
        public string VALUE_DESC { get; set; }
    }

    public class ClaimsConfig
    {
        public string ITEM_KEY { get; set; }
        public string ITEM_VALUE { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class AdmissionType
    {
        public int VALUE_ID { get; set; }
        public string VALUE_DESC { get; set; }
    }
    public class PADelivery
    {
        public Int64 VALUE_ID { get; set; }
        public string VALUE_DESC { get; set; }
        public int ISQUICLAIM { get; set; }
    }
    public class PATreatmentType
    {
        public Int64 VALUE_ID { get; set; }
        public string VALUE_DESC { get; set; }
        public string PAYERCODE { get; set; }
        public int ISQUICLAIM { get; set; }
    }
    public class PATreatmentSubType
    {
        public Int64 VALUE_ID { get; set; }
        public string VALUE_DESC { get; set; }
        public Int64 PARENT_ID { get; set; }
        public string PAYERCODE { get; set; }
        public int ISQUICLAIM { get; set; }
    }
    public class PAZone
    {
        public Int32 ZONE_ID { get; set; }
        public string ZONE_NAME { get; set; }
        public string PAYERCODE { get; set; }
        public int ISQUICLAIM { get; set; }
    }
    public class PAInsurance
    {
        public string INSURANCE_ID { get; set; }
        public string INSURANCE_NAME { get; set; }
        public string PAYERCODE { get; set; }
        public int ISQUICLAIM { get; set; }
    }
    public class PACorporate
    {
        public string CODE { get; set; }
        public string NAME { get; set; }
        public int CORPORATE_ID { get; set; }
        public string PAYERCODE { get; set; }
        public int ISQUICLAIM { get; set; }
    }
    public class PARoomType
    {
        public int PROVIDER_ROOM_TYPE_ID { get; set; }
        public string ROOM_TYPE { get; set; }
        public string PROVIDERCODE { get; set; }
        public string PAYERCODE { get; set; }

    }
    public class PAModified
    {
        public string PROVIDERCODE { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    #region Preauth Transaction Class

    public class PreauthData
    {
        public PreauthData()
        {
        }
        private ObservableCollection<GlobalDocument> _GlobalDoc;
        public string Refno { get; set; }
        public int claimID { get; set; }
        public string HID { get; set; }
        public int IsDraft { get; set; }
        public string userID { get; set; }
        public string requestDate { get; set; }
        public bool IsQuicClaim { get; set; }
        public bool IsRequestEnable { get; set; }
        public string SpecialCase { get; set; }
        public string PayerRefNo { get; set; }
        public string PayerRefID { get; set; }
        public string PayerIdentityKey { get; set; }
        public PatientDetails patient { get; set; }
        public Treatment treatment { get; set; }
        public Admission admission { get; set; }
        public List<Attachment> attach { get; set; }
        public PastIllness pillness { get; set; }
        public ProcedureDetails Proc { get; set; }
        public Billing bill { get; set; }
        public PolicyDetails policyDetails { get; set; }
        //public PatientMediDetails patientMediDetails { get; set; }
        public List<TariffDetails> tariffDetails { get; set; }
        public List<CaseStatus> caseStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public List<Message> messages { get; set; }
        public string GUID { get; set; }
        public int callIntegrationMethod { get; set; }
        public PayerAction payerAction { get; set; }
        public List<HistoryDetails> lstHistory { get; set; }
        public string AppName { get; set; }
        public int PatientDraft { get; set; }
        public int CheckValidData { get; set; }
        public int Draft_Type { get; set; }
        public string Consultant_USERID { get; set; }
        public ObservableCollection<GlobalDocument> GlobalDoc { get { return _GlobalDoc; } set { _GlobalDoc = value; } }
        public int IsQuiClaimPDEnable { get; set; }
        public string PAYER_AUTH_LETTER { get; set; }
        public string DeviceID { get; set; }
        public string ModuleName { get; set; }
        public string UserId { get; set; }
        public MobileAppUsage mobileAppUsage { get; set; }
        public int IsRedrafted { get; set; }
        public string IPAddress { get; set; }
        public string DraftPreauthStatus { get; set; }
        public string DraftForStatus { get; set; }
        public int SUBMISSION_PLATFORM { get; set; }
    }
    public class PatientDetails
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int GenderId { get; set; }
        public string Relation { get; set; }
        public int RelationID { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string EmailID { get; set; }
        public string Pin { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int AgeMonth { get; set; }
        public int AgeDays { get; set; }
        public int AgeYears { get; set; }
        public string PrimaryMemberName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
    }

    public class TariffDetails
    {
        public string TARIFF_ID { get; set; }
        public string TARIFF_CODE { get; set; }
        public string TARIFF_NAME { get; set; }
        public string TARIFF_PROVIDER_CODE { get; set; }
        public string TARIFF_AMOUNT { get; set; }
        public string TARIFFMAPPING_ID { get; set; }
        public string TTYPE { get; set; }
        public string TARIFF_PROVIDER_NAME { get; set; }
    }


    public class Treatment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Ailment;
        private string _ProDiagnosis;
        private string _ProTreatment;
        private string _PriDiagnosis;
        private string _PriTreatment;
        private string _SignaturePath;
        public string Ailment
        {
            get
            {
                return _Ailment;
            }

            set
            {
                if (value != _Ailment)
                {
                    _Ailment = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Duration { get; set; }
        public string TreatmentType { get; set; }
        public string TreatmentTypeID { get; set; }
        public string TreatmentSub { get; set; }
        public string TreatmentSubID { get; set; }
        public string IPNo { get; set; }
        public string Investigation { get; set; }
        public string ProDiagnosis
        {
            get
            {
                return _ProDiagnosis;
            }

            set
            {
                if (value != _ProDiagnosis)
                {
                    _ProDiagnosis = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string ProTreatment
        {
            get
            {
                return _ProTreatment;
            }

            set
            {
                if (value != _ProTreatment)
                {
                    _ProTreatment = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string PriDiagnosis
        {
            get
            {
                return _PriDiagnosis;
            }

            set
            {
                if (value != _PriDiagnosis)
                {
                    _PriDiagnosis = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string PriTreatment
        {
            get
            {
                return _PriTreatment;
            }

            set
            {
                if (value != _PriTreatment)
                {
                    _PriTreatment = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int GA { get; set; }
        public int SA { get; set; }
        public int LA { get; set; }
        public int EA { get; set; }
        public string TypeOfAneshthesia { get; set; }
        
        public string SignaturePath
        {
            get
            {
                return _SignaturePath;
            }

            set
            {
                if (value != _SignaturePath)
                {
                    _SignaturePath = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
    public class Admission : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string DOA { get; set; }
        public string DOD { get; set; }
     
        public string DocRegNo { get; set; }
        public string RoomType { get; set; }
        public Int64 RoomType_ID { get; set; }
        public string RoomCharge { get; set; }
        public string AdmissionType { get; set; }
        public string BillAmt { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string Status { get; set; }
        public string DOS { get; set; }
        public string Remarks { get; set; }
        public string CauseOfInjury { get; set; }
        public string DateOfInjury { get; set; }
        public string G { get; set; }
        public string P { get; set; }
        public string L { get; set; }
        public string A { get; set; }
        public string LMP { get; set; }
        public string EDD { get; set; }
        public string DeliveryMode { get; set; }
        public string DeliveryModeID { get; set; }
        public string Medico { get; set; }
        public string DurationOfStay { get; set; }
        public string EnhancementType { get; set; }
        public string DischargeStatus { get; set; }
        public string TotalAppAmt { get; set; } //Preauth Amount
        public string PatientPaidAmt { get; set; }
        public int CopayType { get; set; }
        public string CopayValue { get; set; }
        public int StatusID { get; set; }
        public string StatusDisplay { get; set; }
        public int FIR { get; set; }
        public int authorized { get; set; }
        
        private string _ConsultName;
        public int CONSULT_ID { get; set; }

        public string ConsultName
        {
            get
            {
                return _ConsultName;
            }

            set
            {
                if (value != _ConsultName)
                {
                    _ConsultName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _Doctor;
        public string Doctor
        {
            get
            {
                return _Doctor;
            }

            set
            {
                if (value != _Doctor)
                {
                    _Doctor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Attachment
    {
        public string Remarks { get; set; }
        public string Filename { get; set; }
        public int IsEnable { get; set; }
        public int ReqType { get; set; }
        public int PreAuthDoc { get; set; }
        public int Drafted_File { get; set; }
    }
    public class PastIllness
    {
        public string PHistAilment { get; set; }
        public string IntensiveCare { get; set; }
        public string PED { get; set; }
        public string Pulse { get; set; }
        public string BP { get; set; }
        public string CVS { get; set; }
        public string CNS { get; set; }
        public string PA { get; set; }
        public string RS { get; set; }
        public string PresentIlnessDueTo { get; set; }
        public int Alcohol { get; set; }
        public int HIV { get; set; }
        public int Infertility { get; set; }
        public int CosmeticSurgy { get; set; }
        public int CongenitalExt { get; set; }
        public int Pregnancy { get; set; }
        public int PoisonInjury { get; set; }
        public int NoneOfthese { get; set; }
        public string Hypertension { get; set; }
        public string Diabetes { get; set; }
        public string Heart { get; set; }
        public string COPD { get; set; }
        public string STD { get; set; }
        public string Asthma { get; set; }
        public string Epilepsy { get; set; }
        public string Cancer { get; set; }
        public string Arthritis { get; set; }
        public string Congenital { get; set; }
        public string Consanguineous { get; set; }
        public string OtherDisease { get; set; }
        public string AlcoholDrugs { get; set; }
        public string Smoking { get; set; }
    }
    public class ProcedureDetails
    {
        public string Disease { get; set; }
        public string Procedure { get; set; }

    }
    public class Billing
    {
        public string Surgeon { get; set; }
        public string AsstSurgeon { get; set; }
        public string Consult { get; set; }
        public string OT { get; set; }
        public string Medicine { get; set; }
        public string Nursing { get; set; }
        public string Anesthesia { get; set; }
        public string DutyDoc { get; set; }
        public string Consumables { get; set; }
        public string BedSideProc { get; set; }
        public string ICU { get; set; }
        public string Investigation { get; set; }
        public string Diet { get; set; }
        public string Implant { get; set; }
        public string Other { get; set; }
        public string ImplantName { get; set; }
    }

    public class PolicyDetails
    {
        public string Payer { get; set; }
        public string PayerName { get; set; }
        public string Zone { get; set; }
        public Int64 Zone_ID { get; set; }
        public string Zone_Name { get; set; }
        public string Insurance { get; set; }
        public Int32 InsuranceID { get; set; }
        public string Corporate { get; set; }
        public Int32 CorporateId { get; set; }
        public string EmployeeId { get; set; }
        public string PolicyNo { get; set; }
        public string MemberId { get; set; }
        public string IDCardNo { get; set; }
        public string Provider { get; set; }
        public string ProviderName { get; set; }
        public int ISQUICLAIMSDATA { get; set; }
        public string PayerCode { get; set; }
    }

    public class PayerAction
    {
        public string PayerLOS { get; set; }
        public string PayerRoomType { get; set; }
        public string PayerInsuranceName { get; set; }
        public string AppAmt { get; set; }
        public string Deduction { get; set; }
        public string CopayType { get; set; }
        public string CopayValue { get; set; }
        public string TotalPayable { get; set; }
        public string ApprovalAttach { get; set; }
        public string BSI { get; set; }
        public string NetPayableAmt { get; set; }
        public string TDS { get; set; }
        public string PayerRemarks { get; set; }
        public string Buffer { get; set; }
        public string PayerStatus { get; set; }
    }
    public class HistoryDetails
    {
        public string Status { get; set; }
        public string ProcessTime { get; set; }
        public string AuthLettter { get; set; }
        public string ReqType { get; set; }
        public string EntityType { get; set; }
        public bool IsVisible { get; set; }
        public string Status_Original { get; set; }

    }

    #endregion
    public class PreauthErrorList
    {
        public List<PreauthError> _PreauthErrorlst { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string Refno { get; set; }
        public string HID { get; set; }
        public string PayerRefNo { get; set; }
        public string PayerRefID { get; set; }
    }
    public class PreauthError
    {
        public string Error { get; set; }
    }

    public class PreauthFieldUpdate
    {
        #region Private Fields

        string vRefNo = string.Empty, vPR_Age_Unit = string.Empty;

        string[] vPEDDesc = new string[14];
        string[] vPEDDurUnit = new string[14];
        string[] vPEDRemarks = new string[14];
        string[] vPackageCat = new string[5];
        string[] vProc_Code = new string[5];
        string[] vProc_Desc = new string[5];
        string[] vDescription = new string[8];

        int[] vPEDDurVal = new int[14];
        int[] vPkgNo = new int[5];
        int[] vSrNo = new int[8];

        short[] vPEDStatus = new short[14];

        int vHistoryID = 0, vPR_Age_Value = 0, vHIST_TABLE_SIZE_N = 0, vCLAIM_HIST_TABLE_SZ_N = 0;

        double[] vPackageRate = new double[5];

        DateTime? vDateofInjury_Dt = new DateTime(), vLMP_Dt = new DateTime(), vEDD_Dt = new DateTime(), vADate_Dt = new DateTime()
            , vDDate_Dt = new DateTime(), vUPLOADEDTIME_DT = new DateTime(), vReceiptDate_Dt = new DateTime(),
            vRECEIPTDATE_UPDATEDTIME_Dt = new DateTime();

        short vGA = 0, vLA = 0, vSA = 0, vEA = 0;

        DataTable vdtTbl_PatMedDtl_PED = new DataTable();
        DataTable vdtTbl_Pat_Pkgs = new DataTable();
        DataTable vdtTbl_PresentIllnessDueTo = new DataTable();

        #endregion

        #region  PROPERTIES

        #region values for Tbl_PatMedDtl_PED table

        public string RefNo
        {
            get { return vRefNo; }
            set { vRefNo = value; }
        }

        public int HistoryID
        {
            get { return vHistoryID; }
            set { vHistoryID = value; }
        }

        public string[] PEDDesc
        {
            get { return vPEDDesc; }
            set { vPEDDesc = value; }
        }

        public short[] PEDStatus
        {
            get { return vPEDStatus; }
            set { vPEDStatus = value; }
        }

        public int[] PEDDurVal
        {
            get { return vPEDDurVal; }
            set { vPEDDurVal = value; }
        }

        public string[] PEDDurUnit
        {
            get { return vPEDDurUnit; }
            set { vPEDDurUnit = value; }
        }

        public string[] PEDRemarks
        {
            get { return vPEDRemarks; }
            set { vPEDRemarks = value; }
        }

        public DataTable dtTbl_PatMedDtl_PED
        {
            get { return vdtTbl_PatMedDtl_PED; }
            set { vdtTbl_PatMedDtl_PED = value; }
        }

        #endregion

        #region values for Tbl_Pat_Pkgs table

        public int[] PkgNo
        {
            get { return vPkgNo; }
            set { vPkgNo = value; }
        }

        public string[] PackageCat
        {
            get { return vPackageCat; }
            set { vPackageCat = value; }
        }

        public string[] Proc_Code
        {
            get { return vProc_Code; }
            set { vProc_Code = value; }
        }

        public string[] Proc_Desc
        {
            get { return vProc_Desc; }
            set { vProc_Desc = value; }
        }

        public double[] PackageRate
        {
            get { return vPackageRate; }
            set { vPackageRate = value; }
        }

        public DataTable dtTbl_Pat_Pkgs
        {
            get { return vdtTbl_Pat_Pkgs; }
            set { vdtTbl_Pat_Pkgs = value; }
        }

        #endregion

        #region values for Tbl_PresentIllnessDueTo table

        public int[] SrNo
        {
            get { return vSrNo; }
            set { vSrNo = value; }
        }

        public string[] Description
        {
            get { return vDescription; }
            set { vDescription = value; }
        }

        public DataTable dtTbl_PresentIllnessDueTo
        {
            get { return vdtTbl_PresentIllnessDueTo; }
            set { vdtTbl_PresentIllnessDueTo = value; }
        }

        #endregion

        #region values for PATIENTINFODETAILS table

        public int PR_Age_Value
        {
            get { return vPR_Age_Value; }
            set { vPR_Age_Value = value; }
        }

        public string PR_Age_Unit
        {
            get { return vPR_Age_Unit; }
            set { vPR_Age_Unit = value; }
        }

        #endregion

        #region values for PATIENTMEDIDETAIL table

        public DateTime? DateofInjury_Dt
        {
            get { return vDateofInjury_Dt; }
            set { vDateofInjury_Dt = value; }
        }

        public DateTime? LMP_Dt
        {
            get { return vLMP_Dt; }
            set { vLMP_Dt = value; }
        }

        public DateTime? EDD_Dt
        {
            get { return vEDD_Dt; }
            set { vEDD_Dt = value; }
        }

        #endregion

        #region values for HOSPDETAILS table

        public DateTime? ADate_Dt
        {
            get { return vADate_Dt; }
            set { vADate_Dt = value; }
        }

        public DateTime? DDate_Dt
        {
            get { return vDDate_Dt; }
            set { vDDate_Dt = value; }
        }

        public int HIST_TABLE_SIZE_N
        {
            get { return vHIST_TABLE_SIZE_N; }
            set { vHIST_TABLE_SIZE_N = value; }
        }

        public int CLAIM_HIST_TABLE_SZ_N
        {
            get { return vCLAIM_HIST_TABLE_SZ_N; }
            set { vCLAIM_HIST_TABLE_SZ_N = value; }
        }

        #endregion

        #region values for TPADETAILS table

        public DateTime? UPLOADEDTIME_DT
        {
            get { return vUPLOADEDTIME_DT; }
            set { vUPLOADEDTIME_DT = value; }
        }

        #endregion

        #region values for PPN_PATADDINFO and PPN_PATADDINFO_HIST tables

        public short GA
        {
            get { return vGA; }
            set { vGA = value; }
        }

        public short LA
        {
            get { return vLA; }
            set { vLA = value; }
        }

        public short SA
        {
            get { return vSA; }
            set { vSA = value; }
        }

        public short EA
        {
            get { return vEA; }
            set { vEA = value; }
        }

        public DateTime? ReceiptDate_Dt
        {
            get { return vReceiptDate_Dt; }
            set { vReceiptDate_Dt = value; }
        }

        public DateTime? RECEIPTDATE_UPDATEDTIME_Dt
        {
            get { return vRECEIPTDATE_UPDATEDTIME_Dt; }
            set { vRECEIPTDATE_UPDATEDTIME_Dt = value; }
        }

        #endregion

        #endregion
    }
    public class CancelPreauth
    {
        public string Refno { get; set; }
        public string PreauthStatus { get; set; }
        public string PayerStatus { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public string FileRemarks { get; set; }
        public string Remarks { get; set; }
        public string ColumnFile { get; set; }
        public string ColumnRemark { get; set; }
        public string PayerCode { get; set; }
        public string ProviderCode { get; set; }
        public string TotalAppAmount { get; set; }
        public string HID { get; set; }
        public string PayerRefNo { get; set; }
    }
    public class CaseStatus
    {
        public string Status { get; set; }
        public string StatusID { get; set; }
        public string Display { get; set; }
    }
    public class SendEmailInformation
    {
        public string Refno { get; set; }
        public int HID { get; set; }
        public int Hseid { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string EmailSub { get; set; }
        public string EmailContent { get; set; }
        public int Status { get; set; }
        public DateTime SentDatetime { get; set; }
        public string Sentby { get; set; }
        public string Acknowledged { get; set; }
        public string Acknowledgedby { get; set; }
        public DateTime Call_date { get; set; }
        public string Updatedby { get; set; }
        public DateTime Updatetime { get; set; }
        public string Case_status { get; set; }
        public string Case_hid { get; set; }
        public string Ack_remarks { get; set; }
        public string Attachments { get; set; }
        public string IsCompressed { get; set; }
        public int AlertType { get; set; }
        public string SendStatus { get; set; }
        public string HistoryId { get; set; }
    }
    public class SmsTrack
    {
        public string Refno { get; set; }
        public string Hospcode { get; set; }
        public string TpaCode { get; set; }
        public string ToNo { get; set; }
        public string SmsText { get; set; }
        public string SMSId { get; set; }
    }
    public class PreauthSms
    {
        public string Name { get; set; }
        public string Hospcode { get; set; }
        public string TpaCode { get; set; }
        public string TPaName { get; set; }
        public string ToNo { get; set; }
        public string SmsText { get; set; }
        public string SMSId { get; set; }
        public string EmailId { get; set; }
        public string Remarks { get; set; }
        public string HospName { get; set; }
        public string DateTime { get; set; }
        public string DateTime_New { get; set; }
    }

    public class CallCenter
    {
        public string Refno { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
        public double TotalApprovedAmt { get; set; }
        public string AmountInWord { get; set; }
        public string Remarks { get; set; }
        public string ApprovedBy { get; set; }
        public string HID { get; set; }
        public string HSID { get; set; }
        public string ReAssign { get; set; }
        public string Filename { get; set; }
        public string PatientName { get; set; }
        public string PatientFlag { get; set; }
        public string PayerRefno { get; set; }
        public string tpaAuthLetter { get; set; }
        public string Hospcode { get; set; }
        public string ISBrowseAndUpload { get; set; }
        public bool FailedFile { get; set; }
        public string TpaCode { get; set; }
        public string FilePath { get; set; }
        public string Tomobile { get; set; }
        public string ToEmail { get; set; }
        public string PayerName { get; set; }

    }

    public class MandatoryList
    {
        public List<MandatoryField> lstMandatory { get; set; }
    }
    public class MandatoryField
    {
        public string FieldName { get; set; }

    }

    public class ProvisionalTreatment
    {
        public int TreatmentID { get; set; }
        public string TreatmentName { get; set; }
        public string TreatmentType { get; set; }
    }
    public class NotificationData
    {
        public string FetchDateTime { get; set; }
        public string UserId { get; set; }
        public List<Notification> ListNotification { get; set; }
    }

    public class Notification
    {
        public string PatientName { get; set; }
        public string Refno { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }        
    }

    public class NotificationList
    {
        public List<NotificationData> NotifyList { get; set; }
    }
    public class PreauthStatus
    {
        public string STATUS_DISP { get; set; }
    }

    public class MediassistBenfiSearch
    {
        public List<MediassistBenfiDet> lstBenfitDet { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class MediassistBenfiDet
    {
        public string Name { get; set; }
        public string Relation { get; set; }
        public string MAID { get; set; }
        public string PolicyNo { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string InsuranceName { get; set; }
        public string EmployeeId { get; set; }
        public string CorporateName { get; set; }
    }

    public class PBPayerList
    {
        public List<PAPayer> Payer { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }

}
