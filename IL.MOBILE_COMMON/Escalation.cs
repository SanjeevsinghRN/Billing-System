using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Escalation:IDisposable
    {
        public string Ref_No { get; set; }
        public string Hid { get; set; }
        public string Remarks { get; set; }
        public string SubmittedBy { get; set; }
        public string DEVICE_ID { get; set; }
        public string Esclation_Id { get; set; }
        public string Status { get; set; }
        public string SubmittedDate { get; set; }
        public string ResponseDate { get; set; }
        public string Rn_Remarks { get; set; }
        public string ClosedBy { get; set; }
        public string PatientName { get; set; }
        public string HospCode { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class EsclationDashBoardCount : IDisposable
    {
        public string OpenCaseCount { get; set; }
        public string ClosedCaseCount { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class EscalationDashBoardData:IDisposable
    {

        public string Ref_No { get; set; }
        public string Hid { get; set; }
        public string PatientName { get; set; }
        public string Esclation_id { get; set; }
        public string Status { get; set; }
        public string PayerName { get; set; }
        public string SubmittedDate { get; set; }
        public string HospCode { get; set; }
        public string HospName { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    

    public class AMRemarks : IDisposable
    {       
        public string Lookup_Value { get; set; }
        public string Lookup_Descrption { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
