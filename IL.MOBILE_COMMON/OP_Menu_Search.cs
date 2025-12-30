using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RN.MOBILE_COMMON
{
    public class OP_Menu_Search
    {
        public int TYPE_ID { get; set; }
        public int VALUE_ID { get; set; }
        public int DISPLAY_ORDER { get; set; }
        public string DISPLAY_TEXT { get; set; }
        public string IMAGE_NAME { get; set; }
        public string IMAGE_NAME1 { get; set; }
        public int IS_DISPLAY { get; set; }
        public int TRANSACTION_TYPE { get; set; }
        [Ignore]
        public GeoLocation Geolocation { get; set; }
        public string ALT_IMAGE_NAME { get; set; }
        public string PKG_CATEGORY { get; set; }
        public string Image { get; set; }
    }

    public class Physician_SearchMenu
    {
        public List<Physician> Physician_lst { get; set; }
        public List<OP_Menu_Search> SpecialityMenu_lst { get; set; }
    }

    public class FilterBy
    {
        public int Online { get; set; }
        public int Physical { get; set; }
        public int DiagnosticName { get; set; }
        public int DistanceSort { get; set; }
        public int ExperienceSort { get; set; }
        public int All_Test { get; set; }
        public int RateSheet { get; set; }
        public int DiscountSort { get; set; }

    }

    public class OP_Consumer_Search
    {
        public GeoLocation GeoLoc { get; set; }
        public string PinCode { get; set; }
        public string SearchKey { get; set; }
        public int Radius { get; set; }
        public FilterBy filterBy { get; set; }
        public int IsMapDataRequest { get; set; }
        public int visitType { get; set; }
    }

    public class OP_CITY_DATA
    {
        public string CITY_NAME { get; set; }
        public string CITY_ID { get; set; }
        public string STATE_ID { get; set; }
        public string STATE_NAME { get; set; }
    }
}
