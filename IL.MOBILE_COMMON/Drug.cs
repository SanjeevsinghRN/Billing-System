using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Drug
    {
        public int DrugID { get; set; }

        public string DrugName { get; set; }

        public int DrugQuantity { get; set; }

        public int NoOfDays { get; set; }

        public decimal Morning { get; set; }

        public decimal Afternoon { get; set; }

        public decimal Evening { get; set; }

        public decimal Night { get; set; }

        public decimal Rate { get; set; }

        public int PharmacyID { get; set; }

        public int BeforeFood { get; set; }

        public string DrugCode { get; set; }

        public int No_of_Tablet { get; set; }

        public decimal MRP { get; set; }

        public int DRUG_TYPE { get; set; }

        public string DRUG_TYPE_DESC { get; set; }

        public int Is_Ordered { get; set; }

        public int No_of_Ordered_Tablet { get; set; }

        public int SubstituteWithDrugId { get; set; }

        public string OrderId { get; set; }

        public int IsFullOrdered { get; set; }

        public int QUANTITY_AVAILABLE { get; set; }

        public string DosageM { get; set; }
        public string DosageA { get; set; }

        public string DosageN { get; set; }

        public string Prescription_id { get; set; }

        public int PLACE_ORDER_MULTIPLE { get; set; }

        public string Integration_Code { get; set; }
    }

    public class Drug_Dosage_Range
    {
        public int Dosage_type_id { get; set; }
        public string Dosage_Name { get; set; }
        public decimal Min_Value { get; set; }
        public decimal Max_Value { get; set; }
        public decimal Incr_Value { get; set; }
        public string Unit_Value { get; set; }
    }
}
