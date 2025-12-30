using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Physician : User
    {
        public int PhysicianID { get; set; }

        public string ClinicName { get; set; }

        public string ClinicAddress { get; set; }

        public string RegistrationNo { get; set; }

        public string Speciality { get; set; }

        public int SpecialityID { get; set; }

        public string Qualification { get; set; }

        public int QualificationID { get; set; }

        public int Experience { get; set; }

        public decimal ConsultFee { get; set; }

        public decimal soryby_fee { get; set; }
        [Ignore]
        public GeoLocation Geolocation { get; set; }
        public int Integration_Id { get; set; }
        public string Integration_Code { get; set; }
        public string Distance { get; set; }

        public string PROFILE_CODE { get; set; }

        public string ENTITY_MOBILENO { get; set; }

        public string PAYEE_NAME { get; set; }

        public string BANK_NAME { get; set; }

        public string BRANCH_NAME { get; set; }

        public string ACCOUNT_TYPE { get; set; }

        public string ACCOUNT_NUMBER { get; set; }

        public string MICR_CODE { get; set; }

        public string IFSC_CODE { get; set; }

        public string PHYSICIAN_IMG { get; set; }
        public string OVER_VIEW { get; set; }
        public string AREA_OF_EXPERT { get; set; }
        public string AWARDS { get; set; }
        public int TELE_CONSULT { get; set; }
        public string TELE_CONSULT_NUMBER { get; set; }

        public string VIDEO_CONSULTATION { get; set; }
        public string HOME_VISIT { get; set; }
        public string PHYSICAL_CONSULTATION { get; set; }
    }

    public class ConsultaionMasterClass
    {
        public string FEE { get; set; }
        public string CONSULTATION_TYPE { get; set; }
        public string CONSULTATION_TYPE_CODE { get; set; }
        public string VISIT_TYPE { get; set; }
    }
}
