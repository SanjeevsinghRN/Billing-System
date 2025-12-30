using System;
using System.ComponentModel;
using System.Reflection;

namespace RN.MOBILE_COMMON
{
    public static class Enumerations
    {
        public enum Diagnostic_VisitType
        {
            [Description("Home")]
            Home = 1,
            [Description("Physical")]
            Physical = 2
        }

        public enum PBConsumer_Menu
        {
            [Description("Home")]
            HOME = 1,
            [Description("Cashless")]
            NewPreauth = 2,
            [Description("Logout")]
            Logout = 3
        }


        public enum HospConsumer_Menu
        {
            [Description("Home")]
            HOME = 1,
            [Description("Book Appointment")]
            BookAppointments = 2,
            [Description("View Appointment")]
            ViewAppointments = 3,
            [Description("InPatient Details")]
            InPatient = 4,
            [Description("Cashless")]
            NewPreauth = 5,
            [Description("Logout")]
            Logout = 6
        }


        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
           (DescriptionAttribute[])fi.GetCustomAttributes
           (typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
        public enum Treatment_Method
        {
            [Description("ALLOPATHY")]
            ALLOPATHY = 1,
            [Description("AYUSH")]
            AYUSH = 2,
            [Description("PHYSIOTHERAPY")]
            PHYSIOTHERAPY = 3
        }

        public enum UserType
        {
            [Description("Physician")]
            Physician = 1,
            [Description("Patient")]
            Patient = 2,
            [Description("Diagnostics")]
            Diagnostics = 3,
            [Description("Pharmacy")]
            Pharmacy = 4,
            [Description("DeliveryBoy")]
            DeliveryBoy = 5,
            [Description("Entity")]
            Entity = 6,
            [Description("BilingDesk")]
            BilingDesk = 7,
            [Description("Admin")]
            Admin = 8,
            [Description("Receptionist")]
            Receptionist = 9,
        }

        public enum MenuType
        {
            [Description("My Account")]
            MyAccount = 1,
            [Description("Dashboard")]
            DashBoard = 2,
            [Description("Change Password")]
            ChangePassword = 3,
            [Description("New Prescription")]
            NewPrescription = 4,
        }

        public enum PaymentType
        {
            [Description("Cash")]
            Cash = 1,
            [Description("Cash Less")]
            CashLess = 2,
            [Description("Wallet")]
            Wallet = 3,
            [Description("External")]
            External = 4
        }

        public enum PharmacyType
        {
            [Description("Online")]
            Online = 1,
            [Description("OnlineandPhysical")]
            OnlineandPhysical = 2,
            [Description("Physical")]
            Physical=3
        }


        public enum Navigate_Dashboard
        {
            [Description("Prescription")]
            Prescription = 1,
            [Description("Diagnostic")]
            Diagnostic = 2,
            [Description("Clinicalfinding")]
            Clinicalfinding = 3,
            [Description("Chat")]
            Chat = 4,
            [Description("HealthCheckup")]
            HealthCheckup = 5,
        }

        public enum TRANSACTION_TYPE
        {
            [Description("CONSULTATION")]
            CONSULTATION = 1,
            [Description("PHARMACY")]
            PHARMACY = 3,
            [Description("DIAGNOSTIC")]
            DIAGNOSTIC = 2,
            [Description("PRESCRIPTION")]
            PRESCRIPTION = 4,
            [Description("HOSPITAL")]
            HOSPITAL = 5,
        }

        public enum ServiceType
        {
            [Description("Consultation")]
            CONSULTATION = 1,
            [Description("Pharmacy")]
            PHARMACY = 3,
            [Description("Diagnostic")]
            DIAGNOSTIC = 2,
            [Description("Health Checkup")]
            HEALTH_CHECKUP = 4,
        }

        public enum DisclaimerType
        {
            [Description("REGISTRATION")]
            REGISTRATION = 1,
            [Description("ELIGIBILITY")]
            ELIGIBILITY = 2,
            [Description("APPOINTMENT")]
            APPOINTMENT = 3,
        }

        public enum Consumer_Menu
        {
            [Description("Home")]
            HOME = 1,
            [Description("Policy Copy")]
            Policy_Copy = 2,
            [Description("Appointments")]
            Appointments = 3,
            [Description("Transactions")]
            Transactions = 4,
            [Description("Service Feedback")]
            Service_Feedback = 5,
            [Description("Medicine Reminder")]
            Medicine_Reminder = 6,
            [Description("Vitals")]
            Vitals = 7,
            [Description("Reimbursement")]
            Reimbursement = 8,
            [Description("How to Use")]
            How_to_Use = 9,
            [Description("FAQ")]
            FAQ = 10,
            [Description("Change MPIN")]
            Change_MPIN = 11,
            [Description("Prescription Upload")]
            Prescription_Upload = 12,
            [Description("Customer Support")]
            Contack_Us = 13,
            [Description("Rate Us")]
            Rate_Us = 14,
            [Description("Notification")]
            Notification = 15,
            [Description("App Info")]
            AppInfo = 16,
            [Description("Logout")]
            Logout = 17,
            [Description("Logs")]
            Logs = 18,

        }
        public enum GetItemsOnGroupPoLCover
        {
            [Description("EXCLUDEDDIAGNOSTICSGROUP")]
            EXCLUDEDDIAGNOSTICSGROUP = 1,
            [Description("DIAGNOSISBASEDDIAGNOSTIC")]
            DIAGNOSISBASEDDIAGNOSTIC = 2,
            [Description("DIAGNOSISBASEDDIAGNOSTICGROUP")]
            DIAGNOSISBASEDDIAGNOSTICGROUP = 3,
            [Description("DIAGNOSISBASEDPHARMACY")]
            DIAGNOSISBASEDPHARMACY = 4,
            [Description("DIAGNOSISBASEDPROCEDURE")]
            DIAGNOSISBASEDPROCEDURE = 5,

        }

        public enum ServiceVisitType
        {

            [Description("Home")]
            HOME = 1,
            [Description("PHYSICAL")]
            PHYSICAL = 2,
            [Description("TELE CONSULT")]
            TELE_CONSULT = 3,
            [Description("VIDEO CONSULT")]
            VIDEO = 4,
        }

        public enum OP_UICONTROL_TYPE
        {
            [Description("Check Box")]
            check_box,
            [Description("Radio Button")]
            radio_btn,
            [Description("Button")]
            btn,
            [Description("Textbox")]
            text_box,
            [Description("Label")]
            lbl,
        }

        public enum OP_DATA_TYPE
        {
            [Description("Integer")]
            Integer = 1,
            [Description("Decimal")]
            Decimal = 2,
            [Description("Alphanumeric")]
            Alphanumeric = 3,
            [Description("Y/N")]
            YN = 4
        }

        public enum OP_NOTIFY_TYPE
        {
            [Description("SMS")]
            SMS = 3,
            [Description("EMAIL")]
            EMAIL = 2,
            [Description("SMS and EMAIL")]
            SMSandEMAIL = 1
        }

        public enum OP_NOTIFICATION_TRIGGER_ID
        {
            [Description("Prescription is created")]
            Prescription_is_created = 1,
            [Description("Report is available")]
            Report_is_available = 2,
            [Description("Repeat visit reminder")]
            Repeat_visit_reminder = 3,
            [Description("Appointment reminder")]
            Appointment_reminder = 4,
            [Description("Medicine Reminder")]
            Medicine_Reminder = 5,
            [Description("Order Updated")]
            Order_Updated = 6,
            [Description("Practo Transaction OTP")]
            Practo_Transaction_OTP = 7,
            [Description("Diagnostics transaction")]
            Diagnostics_transaction = 8,
            [Description("Pharmacy Transaction")]
            Pharmacy_Transaction = 9,
            [Description("New Appointment")]
            New_Appointment = 10,
            [Description("Apollo Transaction OTP")]
            Apollo_Transaction_OTP = 11,
            [Description("RN Transaction OTP")]
            RN_Transaction_OTP = 12,
            [Description("Diagnostic_Appointment")]
            Diagnostic_Appointment = 13,
            [Description("Practo Verification code")]
            SendPractoSDKRegOTP = 14,
            [Description("Physician Appointment Confirmation")]
            Physician_Appointment_Confirmation = 15,
            [Description("Physician Appointment Reminder")]
            Physician_Appointment_Reminder = 16,
            [Description("Verification code for claim approval")]
            Verification_code_for_claim_approval = 17,
            [Description("Cashless claim approved")]
            Cashless_claim_approved = 18,
            [Description("Prescription Uploaded")]
            Prescription_Uploaded = 19,
            [Description("BSI")]
            BSI = 20,
            [Description("Physician Feedback")]
            Physician_Feedback = 21,
            [Description("Physician Feedback Acknowledgement")]
            Physician_Feedback_Acknowledgement = 22,
            [Description("Physician Additional Records Uploaded")]
            Physician_Additional_Records_Uploaded = 23,
            [Description("Physician Feedback Call")]
            Physician_Feedback_Call = 24,
            [Description("Diagnostic Center Appointment Confirmation")]
            Diagnostic_Center_Appointment_Confirmation = 25,
            [Description("Diagnostic Center Appointment Walk in")]
            Diagnostic_Center_Appointment_Walk_in = 26,
            [Description("Diagnostic Center Instructions on day of appointment")]
            Diagnostic_Center_Instructions_on_day_of_appointment = 27,
            [Description("Diagnostic Center Appointment Reminder")]
            Diagnostic_Center_Appointment_Reminder = 28,
            [Description("Diagnostic Center Instructions one day before appointment")]
            Diagnostic_Center_Instructions_one_day_before_appointment = 29,
            [Description("Diagnostic Center Verification code for claim approval")]
            Diagnostic_Center_Verification_code_for_claim_approval = 30,
            [Description("Diagnostic Center Cashless claim approved")]
            Diagnostic_Center_Cashless_claim_approved = 31,
            [Description("Reports Pending")]
            Reports_Pending = 32,
            [Description("Full Reports Uploaded")]
            Full_Reports_Uploaded = 33,
            [Description("Partial Reports Uploaded")]
            Partial_Reports_Uploaded = 34,
            [Description("Additional Reports Uploaded")]
            Additional_Reports_Uploaded = 35,
            [Description("Diagnostics BSI")]
            Diagnostics_BSI = 36,
            [Description("Diagnostic Center Feedback")]
            Diagnostic_Center_Feedback = 37,
            [Description("Diagnostic Center Feedback Acknowledgement")]
            Diagnostic_Center_Feedback_Acknowledgement = 38,
            [Description("Diagnostic Center Feedback Call")]
            Diagnostic_Center_Feedback_Call = 39,
            [Description("Pending tests")]
            Pending_tests = 40,
            [Description("Transaction OTP for Third Party")]
            Transaction_OTP_for_Third_Party = 41,
            [Description("Registration OTP")]
            Registration_OTP = 42,
            [Description("Statndard BSI")]
            Statndard_BSI = 43,
            [Description("Downtime")]
            Downtime = 44,
            [Description("Feedback Call")]
            Feedback_Call = 45,
            [Description("Registration Successful")]
            Registration_Successful = 46,
            [Description("Registration Validation Failed")]
            Registration_Validation_Failed = 47,
            [Description("Pharmacy Feedback Call")]
            Pharmacy_Feedback_Call = 48,
            [Description("Pharmacy Feedback")]
            Pharmacy_Feedback = 49,
            [Description("Pharmacy Feedback Acknowledgement")]
            Pharmacy_Feedback_Acknowledgement = 50,
            [Description("Pending Pharmacy")]
            Pending_Pharmacy = 51,
            [Description("Pharmacy verification code for claim approval")]
            Pharmacy_verification_code_for_claim_approval = 52,
            [Description("Pharmacy Cashless claim approved")]
            Pharmacy_Cashless_claim_approved = 53,
            [Description("Signup Activation Link")]
            Signup_Activation_Link = 54,
            [Description("New Members Added Notification")]
            NewMembers_Added_Notification = 55,
            [Description("Pharmacy Refund confirmation")]
            Pharmacy_Refund_confirmation = 56,
            [Description("Consumer Login Otp")]
            Consumer_Login_Otp = 57,
            [Description("Pharmacy Login Otp")]
            Pharmacy_Login_Otp = 58,
            [Description("Diagnostics Login Otp")]
            Diagnostics_Login_Otp = 59,
            [Description("Physician Login Otp")]
            Physician_Login_Otp = 60,
            [Description("User Registration")]
            UserRegistration = 61,
            [Description("Consumer Forgot Mpin Otp")]
            Consumer_ForgotMpin_Otp = 62,
            [Description("Pharmacy Forgot Mpin Otp")]
            Pharmacy_ForgotMpin_Otp = 63,
            [Description("Diagnostics Forgot Mpin Otp")]
            Diagnostics_ForgotMpin_Otp = 64,
            [Description("Physician Forgot Mpin Otp")]
            Physician_ForgotMpin_Otp = 65,
            [Description("Entity Registration")]
            EntityRegistration = 66,
            [Description("Patient Medical History OTP")]
            PatientMedicalHistoryOTP = 67,
            [Description("Payer User Creation Acknowledgement")]
            PayerUser_Creation_Acknowledgement = 68,
            [Description("Physician Appointment Cancellation")]
            Physician_Appointment_Cancellation = 69,
            [Description("Physician Appointment Reschedule")]
            Physician_Appointment_Reschedule = 70,
            [Description("Diagnostic Tests Appointment Confirmation to Entity")]
            Diagnostic_Tests_Appointment_Confirmation_To_Entity = 71,
            [Description("Payer Forgot Password OTP")]
            Payer_Forgot_password_OTP = 72,
            [Description("Apollo Pharmacy verification code for claim approval")]
            Apollo_Pharmacy_verification_code_for_claim_approval = 73,
            [Description("Apollo Pharmacy Order Cancellation")]
            Apollo_Pharmacy_Order_Cancellation = 74,
            [Description("Apollo Pharmacy Order Cancellation Due To No Activity In The Transaction")]
            Apollo_Pharmacy_Order_Cancellation_No_Activity = 75,
            [Description("Appointment Cancellation By Physician")]
            Appointment_Cancellation_By_Physician = 76,
            [Description("Apollo Pharmacy Order Cancellation Due OTP Expired")]
            Apollo_Pharmacy_Order_Cancellation_OTP_Expired = 77,
            [Description("Appointment Confirmation Created By Admin")]
            Appointment_Confirmation_Created_By_Admin = 78,
            [Description("Appointment Cancellation Created By Admin")]
            Appointment_Cancellation_Created_By_Admin = 79,
            [Description("Mayden Member upload")]
            Mayden_Member_Upload = 80,
            [Description("Offline Prescription Digitization Submission")]
            Prescription_Digitization_Submission = 81,
            [Description("Offline Prescription Digitization Approved")]
            Prescription_Digitization_Approved = 82,
            [Description("Offline Prescription Digitization Rejected")]
            Prescription_Digitization_Rejected = 83,
            [Description("Offline Prescription Digitization query raised")]
            Prescription_Digitization_QRaised = 84,
            [Description("DRL Pharmacy Order Cancellation")]
            DRL_Pharmacy_Order_Cancellation = 85,
            [Description("Verification code for DRL claim approval")]
            Verification_code_for_DRL_claim_approval = 86,
            [Description("Physician Video Appointment Reminder")]
            Physician_Video_Appointment_Reminder = 87,
            [Description("Offline Prescription Digitization Submission Intimation")]
            Prescription_Digitization_Submission_Intimation = 88,
        }
        public enum PaymentRequestType
        {
            [Description("Cash")]
            Cash = 1,
            [Description("CashLess")]
            CashLess = 2,
            [Description("Both")]
            Both = 3,
        }

        public enum MobileAppErrorType
        {
            [Description("Camera")]
            Camera = 1,
            [Description("Location")]
            Location = 2,
            [Description("Storage")]
            Storage = 3,
            [Description("Sensor")]
            Sensor = 4,
            [Description("GeomagneticField")]
            GeomagneticField = 5,
            [Description("USB")]
            USB = 6,
            [Description("Network")]
            Network = 7,
            [Description("DeSerialization")]
            DeSerialization = 8,
            [Description("Logical")]
            Logical = 9,
            [Description("Convertion")]
            Convertion = 10,
            [Description("TimeOut")]
            TimeOut = 11,
            [Description("HostNotRechable")]
            HostNotRechable = 12,
            [Description("Other")]
            Other = 13,

        }


        public enum MemberExistCheck
        {
            [Description("MemberExist")]
            MemberExist = 1,
            [Description("MemberNotExist")]
            MemberNotExist = 2,
            [Description("DuplicateMobileNoExist for diffrent policy")]
            DuplicateMobileNoExist = 3,
            [Description("EmployeeIdNotExist")]
            EmployeeIdNotExist = 4,
            [Description("POLICY_INACTIVE")]
            POLICY_INACTIVE = 5,
            [Description("POLICY_EXPIRED")]
            POLICY_EXPIRED = 6,
            [Description("INACTIVE_EMPLOYEE_ID")]
            INACTIVE_EMPLOYEE_ID = 7,
            [Description("EMAIL_MOBILE_NOT_MATCHING")]
            EMAIL_MOBILE_NOT_MATCHING = 8,
            [Description("MEMBER_ALREADY_REGISTERED")]
            MEMBER_ALREADY_REGISTERED = 9,
            [Description("INACTIVE_DEPEDENT")]
            INACTIVE_DEPEDENT = 10,
            [Description("INACTIVE_MEMBER_ID")]
            INACTIVE_MEMBER_ID = 11,
            [Description("MemberIdNotExist")]
            MEMBERID_NOT_EXIST = 12,
        }

        public enum FileActionType
        {
            [Description("Download")]
            Download = 1,
            [Description("Upload")]
            Upload = 2,
        }

        public enum DocumentType
        {
            [Description("ProcessGuide")]
            ProcessGuide = 1,
            [Description("MOU")]
            MOU = 2,
            [Description("VitalReport")]
            VitalReport = 3,
            [Description("ProfilePic")]
            ProfilePic = 4,
            [Description("FamilyCard")]
            FamilyCard = 5,
            [Description("DiagnosticReport")]
            DiagnosticReport = 6,
            [Description("MinorTestReport")]
            MinorTestReport = 7,
            [Description("DiagnosticAllReport")]
            DiagnosticAllReport = 8,
            [Description("PolicyCopy")]
            PolicyCopy = 9,
            [Description("Prescription")]
            Prescription = 10,
            [Description("OrderReceipt")]
            OrderReceipt = 11,
            [Description("Invoice")]
            Invoice = 12,
            [Description("PaymentReport")]
            PaymentReport = 13,
            [Description("ReimbursementAttachment")]
            ReimbursementAttachment = 14,
            [Description("Reimbursement_AL")]
            Reimbursement_AL = 15,
        }

        public enum IntegrationTypeID
        {
            [Description("PRACTO_INTEGRATION")]
            PRACTO_INTEGRATION = 1,
            [Description("Apollo_Integration")]
            Apollo_Integration = 2,
            [Description("ONEMG_INTEGRATION")]
            ONEMG_INTEGRATION = 3,
            [Description("I3SYSTEMS")]
            I3SYSTEMS = 4,
            [Description("FALCK_INTEGRATION")]
            FALCK_INTEGRATION = 5,
            [Description("DRREDDY_INTEGRATION")]
            DRREDDY_INTEGRATION = 6,
            [Description("MEDPAY_INTEGRATION")]
            MEDPAY_INTEGRATION = 7,
            [Description("CLOVEDENTAL_INTEGRATION")]
            CLOVEDENTAL_INTEGRATION = 8
        }
        public enum Physician_Menu
        {
            [Description("MoU")]
            MoU = 1,
            [Description("Process_Guide")]
            Process_Guide = 2
        }

        public enum ReimbursementStatus
        {
            [Description("Submitted")]
            SUBMITTED = 1,
            [Description("Paid")]
            PAID = 2,
            [Description("Approved")]
            APPROVED = 3,
            [Description("Denied")]
            DENIED = 4,
            [Description("Cancelled")]
            CANCELLED = 5,
            [Description("Draft")]
            DRAFT = 6,
            [Description("Information Required")]
            NEED_MORE_INFO = 7,
            [Description("Information Submitted")]
            INFO_SUBMITTED = 8
        }

        public enum AggregatorType
        {
            [Description("1MG")]
            ONEMG=1,
            [Description("APOLLO")]
            APOLLO=2,
            [Description("DRL")]
            DRL=3,
            [Description("MEDPAY")]
            MEDPAY=4,
            [Description("CLOVEDENTAL")]
            CLOVEDENTAL = 5
        }
        public enum ExternalPaymentStatus
        {
            [Description("SUCCESS")]
            SUCCESS = 1,
            [Description("FAILED")]
            FAILED = 2,
            [Description("PENDING")]
            PENDING = 3
        }
        public enum AppointmentStatus
        {
            [Description("CONFIRMED")]
            CONFIRMED = 1,
            [Description("CANCELLED")]
            CANCELLED = 2,
            [Description("EXPIRED")]
            EXPIRED = 3,
            [Description("UTILIZED")]
            UTILIZED = 0,
            [Description("PENDING")]
            PENDING = 4,
        }
        public enum VAL_OTP_ROLE
        {
            [Description("Receptionist")]
            RECEPTIONIST = 1,
            [Description("Physician")]
            PHYSICIAN = 2,
            [Description("Both")]
            BOTH = 3,

        }
        public enum Prescription_type
        {
            [Description("Normal prescription")]
            Normal=0,
            [Description("Teleconsultation prescription")]
            Teleconsultation =2,
        }
    }
}

