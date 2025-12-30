using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using RN.MOBILE_COMMON;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Reflection;
using System.Text;
//using OP.Encryption;

namespace RN.MOBILE_COMMON
{
    public static class MUtils
    {

        /// <summary>
        /// This method will de-serialize an XML string transmission from the web service into
        /// a dataset and return it.
        /// </summary>
        /// <param name="xmlString">The string to be converted into a DataSet.</param>
        /// <returns>A DataSet containing data parsed from the XML string.</returns>
        public static DataSet DeSerialize(string xmlString)
        {
            DataSet userDataSet = null;
            StringReader userDataStream = null;
            try
            {
                userDataSet = new DataSet();
                userDataStream = new StringReader(xmlString);
                //userDataSet.ReadXmlSchema(userDataStream);
                userDataSet.ReadXml(userDataStream);
                //userDataSet.ReadXml(xmlString);
                userDataStream.Close();
                return userDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (userDataStream != null)
                {
                    userDataStream.Dispose();
                    userDataStream = null;
                }
                if (userDataSet != null)
                {
                    userDataSet.Dispose();
                    userDataSet = null;
                }

            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// Serializes the current instance data to an Xml string.
        /// </summary>
        /// <returns>A string containing the Xml representation of the object.</returns>
        public static string Serialize(DataSet dataSet)
        {
            StringWriter writer = null;
            try
            {
                writer = new StringWriter();
                dataSet.WriteXml(writer, XmlWriteMode.WriteSchema);
                //dataSet.WriteXml(writer);
                writer.Close();
                return writer.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }
            }
        }

        public static string EncryptPassword(string password)
        {
            string encryptedPassword = "";
            //try
            //{
            //    OPEncryptDecrypt encryptedPasswordObject = new OPEncryptDecrypt();
            //    string data = password;
            //    string key = password;
            //    encryptedPassword = encryptedPasswordObject.EncryptString(data, key);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return encryptedPassword;
        }
        //public static string decryptpassword(string password)
        //{
        //    string encryptedpassword = "";
        //    try
        //    {
        //        opencryptdecrypt encryptedpasswordobject = new opencryptdecrypt();
        //        string data = password;
        //        string key = password;
        //        encryptedpassword = encryptedpasswordobject.decryptstring(data, key);
        //    }
        //    catch (exception ex)
        //    {
        //        throw ex;
        //    }
        //    return encryptedpassword;
        //}

        public static async Task<string> GetURLContentsAsync(string url)
        {

            // Initialize an HttpWebRequest for the current URL. 

            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for 
            // the response.    
            string xml = string.Empty;
            using (var response = (HttpWebResponse)webReq.GetResponse())
            {
                // Get the data stream that is associated with the specified url. 

                using (Stream responseStream = response.GetResponseStream())
                {

                    xml = new StreamReader(responseStream).ReadToEnd();

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    xml = xmlDoc.InnerText;
                }
            }
            // Return the result as a string. 
            return xml;
        }


        public static async Task<string> UserProfileSerialize(User obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(User));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }
        public static async Task<string> PhysicianSerialize(Physician obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(Physician));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static string CustomerIssueSerialize(CustomerIssue obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(CustomerIssue));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static string RateUsSerialize(RateUs obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(RateUs));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static async Task<string> PatientSerialize(Patient obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(Patient));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static Patient PatientDeSerialize(string xml)
        {
            Patient obj;
            XmlSerializer serializer = new XmlSerializer(typeof(Patient));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (Patient)serializer.Deserialize(reader);
            return obj;
        }

        public static string EntityDataSerialize(EntityData obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(EntityData));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static EntityData EntityDataDeSerialize(string xml)
        {
            EntityData obj;
            XmlSerializer serializer = new XmlSerializer(typeof(EntityData));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (EntityData)serializer.Deserialize(reader);
            return obj;
        }


        public static string PINCODE_CITY_STATE_Serialize(PINCODE_CITY_STATE obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(PINCODE_CITY_STATE));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static PINCODE_CITY_STATE PINCODE_CITY_STATE_DeSerialize(string xml)
        {
            PINCODE_CITY_STATE obj;
            XmlSerializer serializer = new XmlSerializer(typeof(PINCODE_CITY_STATE));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (PINCODE_CITY_STATE)serializer.Deserialize(reader);
            return obj;
        }

        public static async Task<string> CFSerialize(ClinicalFind obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(ClinicalFind));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static PrescriptionClass PrescDeSerialize(string xml)
        {
            PrescriptionClass obj;
            XmlSerializer serializer = new XmlSerializer(typeof(PrescriptionClass));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (PrescriptionClass)serializer.Deserialize(reader);
            return obj;
        }

        public static async Task<string> PrescSerialize(PrescriptionClass obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(PrescriptionClass));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static async Task<string> PrescListSerialize(MultiplePrescripton obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(MultiplePrescripton));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static async Task<string> ChatHistorySerialize(ChatHistory obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(ChatHistory));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
                //handle Exception
            }

            return xml;
        }

        public static ChatHistory ChatHistoryDeSerialize(string xml)
        {
            ChatHistory obj;
            XmlSerializer serializer = new XmlSerializer(typeof(ChatHistory));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (ChatHistory)serializer.Deserialize(reader);
            return obj;
        }

        public static async Task<string> SearchDataSerialize(NewDataSet obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;

            try
            {
                xmlSerail = new XmlSerializer(typeof(NewDataSet));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }
        public static async Task<string> Diagnosisserializer(Diagnosis obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(Diagnosis));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static string PharmacySerialize(Pharmacy obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(Pharmacy));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }
        public static Pharmacy PharmacyDeSerialize(string xml)
        {
            Pharmacy obj;
            XmlSerializer serializer = new XmlSerializer(typeof(Pharmacy));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (Pharmacy)serializer.Deserialize(reader);
            return obj;
        }

        public static string DrugSerialize(Drug obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(Drug));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }
        public static Drug DrugDeSerialize(string xml)
        {
            Drug obj;
            XmlSerializer serializer = new XmlSerializer(typeof(Drug));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (Drug)serializer.Deserialize(reader);
            return obj;
        }

        public static string SerializeObject(object obj, Type t)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(t);

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static DiagnosticOrderDetail DiagnosticOrderDetailDeSerialize(string xml)
        {
            DiagnosticOrderDetail obj;
            XmlSerializer serializer = new XmlSerializer(typeof(DiagnosticOrderDetail));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (DiagnosticOrderDetail)serializer.Deserialize(reader);
            return obj;
        }

        public static string ValidaionDeliverySerialize(List<TblDia_Phy_data> objphy, TblValidate objvalidate)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", ""); 
                xmlSerail = new XmlSerializer(typeof(TblValidate));
                var sw = new StringWriter();
                xmlSerail.Serialize(sw, objvalidate,ns);
                xml = RemoveXmlDefinition( sw.ToString());


                xmlSerail = new XmlSerializer(typeof(List<TblDia_Phy_data>));
                sw = new StringWriter();
                xmlSerail.Serialize(sw, objphy,ns);

                xml += RemoveXmlDefinition( sw.ToString());
               
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml.Trim();
        }

        private static string RemoveXmlDefinition(string xml)
        {
            XDocument xdoc = XDocument.Parse(xml);
            xdoc.Declaration = null;

            return xdoc.ToString();
        }
        public static string ListDiagnosisserializer(List<Diagnosis> obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(List<Diagnosis>));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static string GetEncryptedKey(string key, string message)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);
            System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);
            byte[] bytes = cryptographer.ComputeHash(messageBytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public static string OP_OfflineCheckListSerialize(OP_OfflineCheckList obj)
        {
            XmlSerializer xmlSerail = null;
            string xml = string.Empty;
            try
            {
                xmlSerail = new XmlSerializer(typeof(OP_OfflineCheckList));

                var sw = new StringWriter();
                xmlSerail.Serialize(sw, obj);

                xml = sw.ToString();
            }
            catch (Exception ex)
            {

                //handle Exception
            }

            return xml;
        }

        public static OP_OfflineCheckList OP_OfflineCheckListDeSerialize(string xml)
        {
            OP_OfflineCheckList obj;
            XmlSerializer serializer = new XmlSerializer(typeof(OP_OfflineCheckList));
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));
            reader.Read();
            obj = (OP_OfflineCheckList)serializer.Deserialize(reader);
            return obj;
        }

        public static string EncryptPassword_New(string password)
        {
            string encryptedPassword = "";
            //try
            //{
            //    opencryptdecrypt objnewencrypt = new opencryptdecrypt();
            //    string inputpassword = password;
            //    encryptedpassword = objnewencrypt.encryptstring(inputpassword);
            //}
            //catch (exception ex)
            //{
            //    throw ex;
            //}
            return encryptedPassword;
        }
    }
}

