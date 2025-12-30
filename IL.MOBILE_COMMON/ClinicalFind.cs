using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RN.MOBILE_COMMON
{
    public class ClinicalFind
    {
        public string VitalId { get; set; }
        public int PatientID { get; set; }
        public string ClaimID { get; set; }
        public string BP { get; set; }
        public string Pulse { get; set; }
        public string CVS { get; set; }
        public string Temperature { get; set; }
        public string Weight { get; set; }
        public string SugarA { get; set; }
        public string SugarB { get; set; }
        public String MonitorDate { get; set; }
        public Ailment Ailment { get; set; }
        public string Remarks { get; set; }
        public string PatientName { get; set; }
        public string MemberId { get; set; }
        public List<OP_Attachments> Reports { get; set; }




        public string Serialize()
        {
            using (var sww = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(this.GetType());
                    xsSubmit.Serialize(writer, this);
                    return sww.ToString();
                }
            }
        }

        public ClinicalFind DeSerialize(string inputString)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StringReader rdr = new StringReader(inputString))
            {
                return (ClinicalFind)serializer.Deserialize(rdr);
            }
        }


    }

    public class Vital_Controls
    {
        public int CONTROL_ID { get; set; }
        public string CONTROL_TEXT { get; set; }
        public string CONTROL_TEXT_VALUE { get; set; }
        public string CONTROL_TYPE { get; set; }
        public int SPECIALITY_ID { get; set; }
        public string SPECIALITY_NAME { get; set; }
        public int IS_EXPAND { get; set; }
        public int DISPLAY_ORDER { get; set; }
        public string CONTROL_TEXT_STYLE { get; set; }
        public string DATA_TYPE { get; set; }
        public string CLAIM_ID { get; set; }
        public int IS_2TEXTBOX { get; set; }
        public int TEXT_LEN { get; set; }
        public string MONITOR_DATE { get; set; }
        public string Vital_ID { get; set; }
        public string STANDARD_VALUE { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public string DEVICEID { get; set; }
        public string VISITORSIP { get; set; }

    }

    public class Vitals_Dashboard
    {
        public List<string> lstMonitorDate { get; set; }
        public List<Vital_Controls> lstVitalsDetails { get; set; }
    }
}
