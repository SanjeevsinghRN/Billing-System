using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class HISAPIProperty
    {
    }

    public class Identity
    {
        public string his_name { get; set; }
        public string authtoken { get; set; }
    }

    public class PreSubmitModelProperty
    {
        public bool isdraftcase { get; set; }
        public string entitytype { get; set; }
        public string rn_reference_no { get; set; }
        public string tpacode { get; set; }
        public string hospitalcode { get; set; }
        public string status_val { get; set; }
        public string status_id { get; set; }
        public bool isspecialcase { get; set; }
        public string zone_val { get; set; }
        public string zone_id { get; set; }
        public string insurance_val { get; set; }
        public string insurance_id { get; set; }
        public string corporate_val { get; set; }
        public string corporate_id { get; set; }
        public string employeeid { get; set; }
        public string policyno { get; set; }
        public string memberid { get; set; }
        public string idcardno { get; set; }
        public string patientfirstname { get; set; }
        public string patientmiddlename { get; set; }
        public string patientlastname { get; set; }
        public string gender_val { get; set; }
        public string gender_id { get; set; }
        public string relationship_val { get; set; }
        public string relationship_id { get; set; }
        public string dob { get; set; }
        public string age_year { get; set; }
        public string age_month { get; set; }
        public string age_day { get; set; }
        public string emailid { get; set; }
        public string address { get; set; }
        public string city_val { get; set; }
        public string city_id { get; set; }
        public string state_val { get; set; }
        public string state_id { get; set; }
        public string pincode { get; set; }
        public string mobileno { get; set; }
        public string primaryfirstname { get; set; }
        public string primarymiddlename { get; set; }
        public string primarylastname { get; set; }
        public string ailment_val { get; set; }
        public string ailment_id { get; set; }
        public string ailment_duration { get; set; }
        public string tariff_val { get; set; }
        public string tariff_id { get; set; }
        public string tariffrate { get; set; }
        public string investigation { get; set; }
        public string treatment_val { get; set; }
        public string treatment_id { get; set; }
        public string treatmentsubtype_val { get; set; }
        public string treatmentsubtype_id { get; set; }
        public string typeofanesthesia { get; set; }
        public string roomtype_val { get; set; }
        public string roomtype_id { get; set; }
        public string roomrent { get; set; }
        public string doa { get; set; }
        public string doa_time { get; set; }
        public string dod { get; set; }
        public string dod_time { get; set; }
        public string durationofstay { get; set; }
        public string surgerydate { get; set; }
        public string billamount { get; set; }
        public string doctorname_val { get; set; }
        public string doctorname_id { get; set; }
        public string admissiontype_val { get; set; }
        public string admissiontype_id { get; set; }
        public string ipnumber { get; set; }
        public string provisionaldiagnosis_val { get; set; }
        public string provisionaldiagnosis_id { get; set; }
        public string diagnosissubtype_val { get; set; }
        public string diagnosissubtype_id { get; set; }
        public string provisinaltreatment_val { get; set; }
        public string provisinaltreatment_id { get; set; }
        public string billnumber { get; set; }
        public string patienthospitalid { get; set; }
        public string panno { get; set; }
        public string aadharno { get; set; }
        public string suminsured { get; set; }
        public string rohiniid { get; set; }
        public string dateOffirstconsultation { get; set; }
        public string surgerycode { get; set; }
        public string maternity_g { get; set; }
        public string maternity_p { get; set; }
        public string maternity_l { get; set; }
        public string maternity_a { get; set; }
        public string lmp { get; set; }
        public string edd { get; set; }
        public string deliverymode_val { get; set; }
        public string deliverymode_id { get; set; }
        public string hospitalremarks { get; set; }
        public string past_history_of_present_ailment { get; set; }
        public string intensivecare { get; set; }
        public string othertreatments { get; set; }
        public string present_ailment_due_to_ped_remarks { get; set; }
        public bool is_present_ailment_due_to_ped { get; set; }
        public string clinicalfindings { get; set; }
        public string pulse { get; set; }
        public string bp { get; set; }
        public string cns { get; set; }
        public string pa { get; set; }
        public string rs { get; set; }
        public string cvs { get; set; }
        public bool presentillness_alcohol { get; set; }
        public bool presentillness_infertility { get; set; }
        public bool presentillness_congenital_external_disease { get; set; }
        public bool presentillness_self_poisoning_injury { get; set; }
        public bool presentillness_hiv { get; set; }
        public bool presentillness_cosmetic_surgery { get; set; }
        public bool presentillnessisdueto_alcohol { get; set; }
        public bool presentillness_pregnancy_related { get; set; }
        public bool presentillness_none_of_these { get; set; }
        public string hypertension { get; set; }
        public string hypertension_duration { get; set; }
        public string hypertension_remarks { get; set; }
        public string diabetes { get; set; }
        public string diabetes_duration { get; set; }
        public string diabetes_remarks { get; set; }
        public string heartdisease { get; set; }
        public string heartdisease_duration { get; set; }
        public string heartdisease_remarks { get; set; }
        public string copd { get; set; }
        public string copd_duration { get; set; }
        public string copd_remarks { get; set; }
        public string stdhiv { get; set; }
        public string stdhiv_duration { get; set; }
        public string stdhiv_remarks { get; set; }
        public string asthma { get; set; }
        public string asthma_duration { get; set; }
        public string asthma_remarks { get; set; }
        public string epilepsy { get; set; }
        public string epilepsy_duration { get; set; }
        public string epilepsy_remarks { get; set; }
        public string cancer { get; set; }
        public string cancer_duration { get; set; }
        public string cancer_remarks { get; set; }
        public string arthritis { get; set; }
        public string arthritis_duration { get; set; }
        public string arthritis_remarks { get; set; }
        public string congenitaldisease { get; set; }
        public string congenitalmarriage { get; set; }
        public string otherdiseases { get; set; }
        public string otherdiseases_duration { get; set; }
        public string otherdiseases_remarks { get; set; }
        public string alcoholdrugs { get; set; }
        public string alcoholdrugs_duration { get; set; }
        public string alcoholdrugs_remarks { get; set; }
        public string smokinghistory { get; set; }
        public string smokinghistory_duration { get; set; }
        public string smokinghistory_remarks { get; set; }
        public string cause_of_injury { get; set; }
        public bool medico_legal_mlc { get; set; }
        public bool medico_legal_nonmlc { get; set; }
        public bool accident_fir { get; set; }
        public string accident_date { get; set; }
        public string country_val { get; set; }
        public string country_id { get; set; }
        public string member_rank { get; set; }
        public string entitlement_val { get; set; }
        public string entitlement_id { get; set; }
        public bool is_billdetails_packages { get; set; }
        public string query_delay_reason_val { get; set; }
        public string query_delay_reason_id { get; set; }
        public string basic_pay { get; set; }
        public bool isdeathcase { get; set; }
        public string hospTreatmentSubtype_id { get; set; }
        public string hospTreatmentSubtype_val { get; set; }

    }
    public class PreaAuthAttachmentFile
    {
        public string filename { get; set; }
        public string filecontent { get; set; }
        public string attachment_remarks { get; set; }
    }

    public class PreauthDataInternal
    {
        public Identity identity { get; set; }
        public PreSubmitModelProperty preauthdata { get; set; }
        public List<PreaAuthAttachmentFile> attachments { get; set; }
        public string errormsg { get; set; }
        public string ipaddress { get; set; }
    }

    public class preauthsubmitresponse
    {
        public string rn_reference_number { get; set; }
        public string patient_name { get; set; }
    }

    public class IntegrationResult
    {
        public string bajaj_integration_failed { get; set; }
        public string vidal_integraion_failed { get; set; }
        public string paramount_integraion_failed { get; set; }
        public string Hdn_MsgID { get; set; }

    }

    public class PreAuthDBResponse
    {
        public string refno { get; set; }
        public string msg { get; set; }
    }

    public class PreAuthFileSavingClass
    {
        public string refno { get; set; }
        public string hid { get; set; }
        public List<PreAuthFiles> files { get; set; }
    }

    public class PreAuthFileSavingClass_All
    {
        public string refno { get; set; }
        public string hid { get; set; }
        public PreAuthFiles file1 { get; set; }
        public PreAuthFiles file2 { get; set; }
        public PreAuthFiles file3 { get; set; }
        public PreAuthFiles file4 { get; set; }
        public PreAuthFiles file5 { get; set; }
        public PreAuthFiles file6 { get; set; }
        public PreAuthFiles file7 { get; set; }
        public PreAuthFiles file8 { get; set; }
        public PreAuthFiles file9 { get; set; }
        public PreAuthFiles file10 { get; set; }
        public PreAuthFiles file11 { get; set; }
        public PreAuthFiles file12 { get; set; }
        public PreAuthFiles file13 { get; set; }
        public PreAuthFiles file14 { get; set; }
        public PreAuthFiles file15 { get; set; }
        public PreAuthFiles file16 { get; set; }
        public PreAuthFiles file17 { get; set; }
        public PreAuthFiles file18 { get; set; }
        public PreAuthFiles file19 { get; set; }
        public PreAuthFiles file20 { get; set; }
        public PreAuthFiles file21 { get; set; }
        public PreAuthFiles file22 { get; set; }
        public PreAuthFiles file23 { get; set; }
        public PreAuthFiles file24 { get; set; }
        public PreAuthFiles file25 { get; set; }
        public PreAuthFiles file26 { get; set; }
        public PreAuthFiles file27 { get; set; }
        public PreAuthFiles file28 { get; set; }
        public PreAuthFiles file29 { get; set; }
        public PreAuthFiles file30 { get; set; }
    }

    public class PreAuthFiles
    {
        public string filename { get; set; }
        public string filesize { get; set; }
        public string filetype { get; set; }
        public string remarks { get; set; }
        public int isnewfile { get; set; }
    }


    public class Preauth_BO
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
        short vMedical = 0, vNonMedical = 0, vPolicyRelated = 0, vMD_NMIEmail = 0;
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


        public short Medical
        {
            get { return vMedical; }
            set { vMedical = value; }
        }

        public short NonMedical
        {
            get { return vNonMedical; }
            set { vNonMedical = value; }
        }

        public short PolicyRelated
        {
            get { return vPolicyRelated; }
            set { vPolicyRelated = value; }
        }

        public short MD_NMIEmail
        {
            get { return vMD_NMIEmail; }
            set { vMD_NMIEmail = value; }
        }
        #endregion



        #endregion
    }

    public class SMSTRACKBO
    {
        #region CONSTRUCTOR
        public SMSTRACKBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
        #region Private Declaration

        private string _Refno = string.Empty;
        private string _Hospcode = string.Empty;
        private string _TpaCode = string.Empty;
        private string _ToNo = string.Empty;
        private string _SmsText = string.Empty;
        private string _SMSId = string.Empty;


        #endregion

        #region Public Declaration

        public string REFNO
        {
            get
            {
                return _Refno;
            }
            set
            {
                _Refno = value;
            }
        }

        public string HOSPCODE
        {
            get
            {
                return _Hospcode;
            }
            set
            {
                _Hospcode = value;
            }
        }


        public string TPACODE
        {
            get
            {
                return _TpaCode;
            }
            set
            {
                _TpaCode = value;
            }
        }

        public string TONO
        {
            get
            {
                return _ToNo;
            }
            set
            {
                _ToNo = value;
            }
        }

        public string SMSTEXT
        {
            get
            {
                return _SmsText;
            }
            set
            {
                _SmsText = value;
            }
        }

        public string SMSID
        {
            get
            {
                return _SMSId;
            }
            set
            {
                _SMSId = value;
            }
        }
        #endregion
    }

    public class SendEmailInformationBO
    {
        #region Declaration Part

        #region Private Declaration

        private string _refno = string.Empty;
        private int _hid = 0;
        private int _hseid = 0;
        private string _emailfrom = string.Empty;
        private string _emailto = string.Empty;
        private string _emailsub = string.Empty;
        private string _emailcontent = string.Empty;
        private int _status = 0;
        private DateTime _sent_datetime = new DateTime();
        private string _sentby = string.Empty;
        private string _acknowledged = string.Empty;
        private string _acknowledgedby = string.Empty;
        private DateTime _call_date = new DateTime();
        private string _updatedby = string.Empty;
        private DateTime _updatetime = new DateTime();
        private string _case_status = string.Empty;
        private string _case_hid = string.Empty;
        private string _ack_remarks = string.Empty;

        #endregion

        #region Public Declaration

        public string REFNO
        {
            get
            {
                return _refno;
            }
            set
            {
                _refno = value;
            }
        }

        public int HID
        {
            get
            {
                return _hid;
            }
            set
            {
                _hid = value;
            }
        }

        public int HSEID
        {
            get
            {
                return _hseid;
            }
            set
            {
                _hseid = value;
            }
        }

        public string EMAILFROM
        {
            get
            {
                return _emailfrom;
            }
            set
            {
                _emailfrom = value;
            }
        }

        public string EMAILTO
        {
            get
            {
                return _emailto;
            }
            set
            {
                _emailto = value;
            }
        }

        public string EMAILSUB
        {
            get
            {
                return _emailsub;
            }
            set
            {
                _emailsub = value;
            }
        }

        public string EMAILCONTENT
        {
            get
            {
                return _emailcontent;
            }
            set
            {
                _emailcontent = value;
            }
        }

        public int STATUS
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public DateTime SENT_DATETIME
        {
            get
            {
                return _sent_datetime;
            }
            set
            {
                _sent_datetime = value;
            }
        }

        public string SENTBY
        {
            get
            {
                return _sentby;
            }
            set
            {
                _sentby = value;
            }
        }

        public string ACKNOWLEDGED
        {
            get
            {
                return _acknowledged;
            }
            set
            {
                _acknowledged = value;
            }
        }

        public string ACKNOWLEDGEDBY
        {
            get
            {
                return _acknowledgedby;
            }
            set
            {
                _acknowledgedby = value;
            }
        }

        public DateTime CALL_DATE
        {
            get
            {
                return _call_date;
            }
            set
            {
                _call_date = value;
            }
        }

        public string UPDATEDBY
        {
            get
            {
                return _updatedby;
            }
            set
            {
                _updatedby = value;
            }
        }

        public DateTime UPDATETIME
        {
            get
            {
                return _updatetime;
            }
            set
            {
                _updatetime = value;
            }
        }

        public string CASE_STATUS
        {
            get
            {
                return _case_status;
            }
            set
            {
                _case_status = value;
            }
        }

        public string CASE_HID
        {
            get
            {
                return _case_hid;
            }
            set
            {
                _case_hid = value;
            }
        }

        public string ACK_REMARKS
        {
            get
            {
                return _ack_remarks;
            }
            set
            {
                _ack_remarks = value;
            }
        }

        #endregion

        #endregion

        #region Routine and Function Part

        public SendEmailInformationBO()
        {

        }

        #endregion
    }

    public class ServiceBasedEmailSentBO
    {
        #region Declaration Part

        #region Private Declaration

        private string _refNo = string.Empty;
        private string _fromEmailId = string.Empty;
        private string _toEmailId = string.Empty;
        private string _emailSubject = string.Empty;
        private string _emailBody = string.Empty;
        private string _sendStatus = string.Empty;
        private DateTime _sentOn = new DateTime();
        private string _attachments = string.Empty;
        private string _isCompressed = string.Empty;
        private int _alertType;
        private int _historyId;
        private string _moduleName = string.Empty;

        #endregion

        #region Public Declaration

        public string REFNO
        {
            get
            {
                return _refNo;
            }
            set
            {
                _refNo = value;
            }
        }

        public string FROMEMAILID
        {
            get
            {
                return _fromEmailId;
            }
            set
            {
                _fromEmailId = value;
            }
        }

        public string TOEMAILID
        {
            get
            {
                return _toEmailId;
            }
            set
            {
                _toEmailId = value;
            }
        }

        public string EMAILSUBJECT
        {
            get
            {
                return _emailSubject;
            }
            set
            {
                _emailSubject = value;
            }
        }

        public string EMAILBODY
        {
            get
            {
                return _emailBody;
            }
            set
            {
                _emailBody = value;
            }
        }

        public string SENDSTATUS
        {
            get
            {
                return _sendStatus;
            }
            set
            {
                _sendStatus = value;
            }
        }

        public DateTime SENTON
        {
            get
            {
                return _sentOn;
            }
            set
            {
                _sentOn = value;
            }
        }

        public string ATTACHMENTS
        {
            get
            {
                return _attachments;
            }
            set
            {
                _attachments = value;
            }
        }

        public string ISCOMPRESSED
        {
            get
            {
                return _isCompressed;
            }
            set
            {
                _isCompressed = value;
            }
        }

        public int ALERTTYPE
        {
            get
            {
                return _alertType;
            }
            set
            {
                _alertType = value;
            }
        }

        public int HISTORYID
        {
            get
            {
                return _historyId;
            }
            set
            {
                _historyId = value;
            }
        }

        public string MODULENAME
        {
            get
            {
                return _moduleName;
            }
            set
            {
                _moduleName = value;
            }
        }
        #endregion

        #endregion

        #region Routine and Function Part

        public ServiceBasedEmailSentBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion
    }
}
