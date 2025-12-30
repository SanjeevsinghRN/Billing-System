using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class ProfileDetails
    {
        public string VoteInPerc { get; set; }
        public string Vote { get; set; }
        public string ServiceImageUrl { get; set; }
        public List<WorkDayTiming> lstWorkTime { get; set; }
        public List<WorkingHours> lstWorkHours { get; set; }
        public List<EntityServices> lstService { get; set; }
        public List<ServiceFeedBack> lstFeedback { get; set; }
        public List<ServiceImage> lstServiceImage { get; set; }
        public List<ServiceFacilities> lstFacilities { get; set; }
        public string feedback_rating { get; set; }
    }

    public class WorkDayTiming
    {
        public string Day { get; set; }
        public string Timing { get; set; }
    }
    public class EntityServices
    {
        public string Service { get; set; }
    }
    public class ServiceFeedBack
    {
        public string FeedbackRemarks { get; set; }
        public string PatientName { get; set; }
        public string FeedbackDate { get; set; }
    }
    public class ServiceImage
    {
        public string ImageName { get; set; }
    }
    public class ServiceFacilities
    {
        public string Facilities { get; set; }
    }

    public class WorkingHours
    {
        public string Day { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string SlotType { get; set; }
        public string userID { get; set; }
        public string Timings { get; set; }
        public string Interval { get; set; }
    }
}
