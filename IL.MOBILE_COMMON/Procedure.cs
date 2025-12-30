using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Procedure
    {
        public int ProcedureID { get; set; }

        public string ProcedureCode { get; set; }

        public string ProcedureName { get; set; }

        public string rate { get; set; }

        public string ReportName { get; set; }

        public string Prescription_id { get; set; }

        public int ProcedureType { get; set; }

        public string UNIT_COST { get; set; }

        public string UNITS { get; set; }

        /// <summary>
        ///   1 - Covered in consultation 
        ///   2 - Consultation included
        ///   3 - Payable along with consultation  
        /// </summary>

        public int FEE_TYPE { get; set; }


        public string PayerPayable { get; set; }

        public string PatientPayable { get; set; }

        public bool ReportUploaded { get; set; }

        public string STANDARD_DISCOUNT { get; set; }

        public string BILL_AMOUNT { get; set; }
        public bool is_rate_enabled { get; set; }
        public bool is_unit_enabled { get; set; }
        public string IS_EXCL { get; set; }
        public string procedureCost { get; set; }
    }
}
