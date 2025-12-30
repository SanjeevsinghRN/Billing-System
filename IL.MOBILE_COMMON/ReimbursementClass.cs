using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RN.MOBILE_COMMON
{
    public class ReimbursementClass
    {
        public string REM_ID { get; set; }
        public string REM_STATUS { get; set; }
        public int HISTORY_ID { get; set; }
        public string DIAG_TOTAL_BILL_AMT { get; set; }
        public string DIAG_PAYER_PAYABLE { get; set; }
        public string DIAG_PAT_PAYABLE { get; set; }
        public string CONS_PAT_PAYABLE { get; set; }
        public string CONS_PAYER_PAYABLE { get; set; }
        public string CONS_TOTAL_BILL_AMT { get; set; }
        public string PHAR_PAT_PAYABLE { get; set; }
        public string PHAR_PAYER_PAYABLE { get; set; }
        public string PHAR_TOTAL_BILL_AMT { get; set; }
        public string PAYER_REMARKS { get; set; }
        public string CONSUMER_REMARKS { get; set; }
        public string REM_Date { get; set; }
        public string LastFetchTime { get; set; }
        public string PatientName { get; set; }
        public string TotalClaimedAmt { get; set; }    
        public string Approved_Amt { get; set; }

        [XmlIgnore]
        public Nullable<DateTime> OrderByModifiedDate { get; set; }
    }

    public class Reimbursement
    {
        public string Rem_id { get; set; }
        public string PATIENT_ID { get; set; }
        public string MEMBER_ID { get; set; }
        public string SUBMIT_DATE { get; set; }
        public double CONSULTATION_FEE { get; set; }
        public int VALIDATIONTYPE { get; set; }
        public int IS_HEALTH_CHECK { get; set; }
        public int NO_BSI_DEDUCT { get; set; }
        public int SERVICE_ACCESS_TYPE_ID { get; set; }
        public int ISREIMBURSEMENT { get; set; }
        public string GUID { get; set; }
        public double REIMCON_BILL_AMOUNT { get; set; }
        public double REIMPHAR_BILL_AMOUNT { get; set; }
        public double REIMDIAG_BILL_AMOUNT { get; set; }
        public double CON_PAYER_PAYABLE { get; set; }
        public double PHAR_PAYER_PAYABLE { get; set; }
        public double DIAG_PAYER_PAYABLE { get; set; }
        public double CON_PAT_PAYABLE { get; set; }
        public double PHAR_PAT_PAYABLE { get; set; }
        public double DIAG_PAT_PAYABLE { get; set; }
        public string IP_ADDRESS { get; set; }
        public string Device_Id { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public List<Reimburse_Attachments> FILES { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string History_id { get; set; }
        public string REM_STATUS { get; set; }
        public string PAYER_REMARKS { get; set; }
        public string CONSUMER_REMARKS { get; set; }
        public string APPROVED_AMOUNT { get; set; }
        public string AUTHORIZATION_LETTER { get; set; }
        public int SAVE_DRAFT { get; set; }
        public double? BILL_AMOUNT { get; set; }
        public int IS_DRAFT { get; set; }
        public Reimburse_Breakup Validation_Breakup { get; set; }

    }

    public class Reimburse_Attachments
    {
        public string Rem_id { get; set; }
        public string History_id { get; set; }
        public string File_Name { get; set; }
        public string Bill_Amt { get; set; }
        public string Transaction_type { get; set; }
        public string Ip_Address { get; set; }
        public string Device_id { get; set; }
        public string FileName_NEFT { get; set; }
        public string FileName_Bill { get; set; }
        public string FileName_Prescription { get; set; }
        public string FileName_Others { get; set; }
    }

    public class Reimburse_Breakup
    {
        public double CON_TOTAL_BILL_AMOUNT { get; set; }
        public List<Rem_Breakup_Details> CON_BREAKUP_DETAILS { get; set; }
        public double PHAR_TOTAL_BILL_AMOUNT { get; set; }
        public List<Rem_Breakup_Details> PHAR_BREAKUP_DETAILS { get; set; }
        public double DIAG_TOTAL_BILL_AMOUNT { get; set; }
        public List<Rem_Breakup_Details> DIAG_BREAKUP_DETAILS { get; set; }
    }

    public class Rem_Breakup_Details
    {
        public string TransactionType { get; set; }
        public string ValidationMsg { get; set; }
        public double ValidationAmount { get; set; }
    }

}
