using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Feedback
    {
        public string prescription_id { get; set; }
        public string OrderID { get; set; }
        public int Transaction_Type { get; set; }
        public string Feedback_Review { get; set; }
        public int Patient_Id { get; set; }
        public string Review_Date { get; set; }
        public string Order_Date { get; set; }
        public string PatientName { get; set; }
        public string ServiceEntityName { get; set; }
        public bool Feedback_Done { get; set; }
        [Ignore]
        public List<FeedbackQuestion> FeedbackQDetails { get; set; }
        public string PayerOrderID { get; set; }

    }

    public class FeedbackQuestion
    {
        public string OrderID { get; set; }
        public int Tranaction_Type { get; set; }
        public int Question_ID { get; set; }
        public string Question_Detail { get; set; }
        public int Question_SlNo { get; set; }
        public int Rating { get; set; }
        public int Question_IsActive { get; set; }
    }

    public class feedback_controls
    {
        public int control_id { get; set; }
        public string control_text { get; set; }
        public string control_text_value { get; set; }
        public string control_typ { get; set; }
      
        public string service_type { get; set; }
        public string service_name { get; set; }
        public string display_order { get; set; }
        public string transaction_type { get; set; }
        public string control_style { get; set; }

        public feedbackSercie feedbackfinal_rating { get; set; }
    }

    public class feedback_on_service
    {     
        public string feedback_text { get; set; }
        public int feedback_text_id { get; set; }
        public string feedback_value { get; set; }
        public string feedback_value_type { get; set; }
        public string service_type { get; set; }
        public string transaction_type { get; set; }
        
    }

    public class feedbackSercie
    {

        public List<feedback_on_service> FeedbackonService_Consul { get; set; }
        public List<feedback_on_service> FeedbackonService_Diagnosit { get; set; }
        public List<feedback_on_service> FeedbackonService_PH { get; set; }
        public List<feedback_on_service> FeedbackonService_PS { get; set; }

        public string Claim_ID { get; set; }
        public string Patient_Id { get; set; }
        public int Transaction_Type { get; set; }
        public string Feedback_rating { get; set; }
        public int fb_samplePickup { get; set; }
        public int fb_usabilityapp { get; set; }
        public int fb_orderprocess { get; set; }
        public int fb_reportdelivery { get; set; }
        public int fb_customersupport { get; set; }
        public int fb_others { get; set; }
        public string Feedback_remarks { get; set; }
        public int service_type { get; set; }
        public string Prescription_ID_Val { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public string DEVICEID { get; set; }
        public string VISITORSIP { get; set; }

    }
}
