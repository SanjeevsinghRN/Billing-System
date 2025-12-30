using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Reminder
    {
        public string Prescription_Id { get; set; }
        public int Patient_Id { get; set; }
        public int HistoryID { get; set; }
        public string MorningTime { get; set; }
        public string AfternoonTime { get; set; }
        public string NightTime { get; set; }
        public int DurationDays { get; set; }
        public int Is_Active { get; set; }
        public string Created_Date { get; set; }
        public string Ailment_Name { get; set; }
        public string ReminderId { get; set; }
        public string MemberId { get; set; }
        public string DrugName { get; set; }        
        public string ReminderDateTime { get; set; }
        [SQLite.Ignore]
        public PrescriptionClass PrescriptionData { get; set; }
        [SQLite.Ignore]
        public List<ReminderData> ReminderDataLst { get; set; }

        public DateTime OrderByDateTime { get; set; }

        public string LastFetchTime { get; set; }

    }


    public class ReminderData
    {
        public string RequestId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }

    public class ReminderList
    {
        public string Prescription_Id { get; set; }
        public string PatientName { get; set; }
        public string MemberId { get; set; }
        public string PrescDate { get; set; }
        public string Ailment_Name { get; set; }
        public List<ReminderV1> lstReminder { get; set; }
        public string Modified_by { get; set; }
        public string Device_id { get; set; }
        public string IP_Address { get; set; }
    }
    public class ReminderV1
    {
        public string ReminderId { get; set; }
        public string MorningTime { get; set; }
        public string AfternoonTime { get; set; }
        public string NightTime { get; set; }
        public int DurationDays { get; set; }
        public int Is_Active { get; set; }
        public string Created_Date { get; set; }
        public string DrugName { get; set; }
        public string DrugCode { get; set; }
        public string ReminderDateTime { get; set; }
        public int Morning { get; set; }
        public int Evening { get; set; }
        public int Night { get; set; }
        public int BeforeFood { get; set; }
        public int IsDeleted { get; set; }
    }
}
