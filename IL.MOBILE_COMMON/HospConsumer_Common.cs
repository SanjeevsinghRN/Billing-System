using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class HospConsumer_Theme
    {
        public string Canvas_Backgroud { get; set; }
        public string Primary_Color { get; set; }
        public string HeaderLbl_Color { get; set; }
        public string Placeholder_Color { get; set; }
        public string EntryText_Color { get; set; }
        public string MenuBackGround_Color { get; set; }
        public string MenuText_Color { get; set; }
        public string Entry_FontSize { get; set; }
        public string Header_FontSize { get; set; }
        public string Lable_FontSize { get; set; }
        public string Lable_Color { get; set; }
        public string ListView_Background { get; set; }
        public string ListView_Split_Color { get; set; }
        public string TitleColor { get; set; }
        public string TitleFontSize { get; set; }
        public string ButtonText_Color { get; set; }
        public string Button_FontSize { get; set; }
        public string Singlebtn_Endlayout_Color { get; set; }
        public string EndLayoutbtn1_Color { get; set; }
        public string EndLayoutbtn2_Color { get; set; }
        public string Link_Color { get; set; }
        public string Normalbtn_Color { get; set; }
        public string Home_Button1_Color { get; set; }
        public string Home_Button2_Color { get; set; }
        public string Home_Button3_Color { get; set; }
        public string Home_Button4_Color { get; set; }
        public string MenuSep_Color { get; set; }
        public string MenuArrow_Color { get; set; }
        public string LogoBG_Color { get; set; }
    }

    public class HospConsumer_HomeConfig
    {
        public string SECTION_IMAGE { get; set; }
        public string SECTION_TITLE { get; set; }
        public string SECTION_TYPE { get; set; }
    }

    public class HospConsumer_AbtUsConfig
    {        
        public string Abt_Title { get; set; }
        public string Abt_Img { get; set; }
        public string Abt_Desc { get; set; }
    }

    public class HospConsumer_BannerConfig
    {
        public string Banner_Img { get; set; }
        public string Banner_Url { get; set; }
    }

    public class DocWorkflow
    {
        public List<Doc_Workflow> lstWorkflow { get; set; }
    }
    public class Doc_Workflow
    {
        public int VALUE_ID { get; set; }
        public string Doc_WorkflowType { get; set; }
    }

    public class HomePageData
    {
        public string Hosp_Img { get; set; }
        public string Hosp_Logo { get; set; }
        public string Hosp_Logo_Height { get; set; }
        public string Hosp_Logo_width { get; set; }
        public string AboutUs { get; set; }
        public string Address { get; set; }
        public string HospName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        [Ignore]
        public List<HospConsumer_HomeConfig> lstHomeConfig { get; set; }
        [Ignore]
        public List<HospConsumer_AbtUsConfig> lstAbtUsConfig { get; set; }
        [Ignore]
        public List<HospConsumer_BannerConfig> lstBannerConfig { get; set; }
    }
}
