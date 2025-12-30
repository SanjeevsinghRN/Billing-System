using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    class Medpay
    {
    }
    public class Medpay_Response
    {
        public int Status { get; set; }
        public string ErrMsg { get; set; }
    }
    public class MEDPAY_PAYMENT_LINK
    {
        public string appointment_id { get; set; }
        public string payment_link { get; set; }
        public string payment_link_id { get; set; }
        public string expiry_date { get; set; }
        public string payment_amt { get; set; }
        public string active { get; set; }
    }
    public class MEDPAY_PAYMENT_STATUS
    {
        public string appointment_id { get; set; }
        public string payment_STATUS { get; set; }
        public string gateway_trans_id { get; set; }
        public string bank_trans_id { get; set; }
        public string payment_date { get; set; }
        public string payment_amt { get; set; }
        public string payment_mode { get; set; }
    }
    public class MEDPAY_REFUND_STATUS
    {
        public string appointment_id { get; set; }
        public string refund_STATUS { get; set; }
        public string gateway_trans_id { get; set; }
        public string bank_trans_id { get; set; }
        public string refund_date { get; set; }
        public string refund_amt { get; set; }
        public string refund_id { get; set; }
        public string accept_refund_time { get; set; }
    }
    public class MEDPAY_ValidateOTPMain
    {
        public MEDPAY_ValidateOTP data { get; set; }
    }

    public class MEDPAY_ValidateOTP
    {
        public string appointment_id { get; set; }
        public string otp { get; set; }
    }
    public class MEDPAY_ValidateResp
    {
        public int Status { get; set; }
        public string Msg { get; set; }
    }
    public class Medpay_UpdateAppointmentMain
    {
        public Medpay_UpdateAppointmentMain1 data { get; set; }
    }
    public class Medpay_UpdateAppointmentMain1
    {
        public Medpay_UpdateAppointment appointment_details { get; set; }
        public string appointment_id { get; set; }
        public string branch_id { get; set; }
        public string doctor_id { get; set; }
        public string policy_company { get; set; }
        public string policy_id { get; set; }
    }
    public class Medpay_UpdateAppointment
    {
        public string appointment_date { get; set; }
        public string appointment_status { get; set; }
        public string appointment_type { get; set; }
        public string cancellation_reason { get; set; }
        public string cancelled_by { get; set; }
        public string end_time { get; set; }
        public string start_time { get; set; }
    }
    public class MEDPAY_APP_ROOT_REQ_B
    {
        public MEDPAY_APP_REQ_B data { get; set; }
    }
    public class MEDPAY_APP_REQ_B
    {
        public string booking_id { get; set; }
        public string partner_order_id { get; set; }
        public string specialty { get; set; }
        public string partner_name { get; set; }
        public string payment_collection { get; set; }
        public string time_slot { get; set; }
        public string consultation_fees { get; set; }
        public string payer_payable { get; set; }
        public string patient_payable { get; set; }
        public customer_details_Medpay_Request customer_details { get; set; }
        
    }

    public class MEDPAY_APP_CANCEL_REQ_B
    {
        public string partner_name { get; set; }
        public string partner_order_id { get; set; }
        public string cancelled_reason { get; set; }
       
    }
    public class customer_details_Medpay_Request
    {
        public string uhid { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public int? age { get; set; }
        public string alternative_mobile { get; set; }
        public string email { get; set; }
        public address_details address_details { get; set; }
        
    }
    
    public class address_details
    {
        public string address { get; set; }
        public string landmark { get; set; }
        public string pin_code { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string coordinates { get; set; }

    }


}
