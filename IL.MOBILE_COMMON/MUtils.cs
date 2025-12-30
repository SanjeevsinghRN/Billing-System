using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Reflection;
using System.Text;

namespace RN.MOBILE_COMMON
{
    public static class MUtils
    {
        public static DataSet DeSerialize(string xmlString)
        {
            DataSet userDataSet = null;
            StringReader userDataStream = null;
            try
            {
                userDataSet = new DataSet();
                userDataStream = new StringReader(xmlString);
                userDataSet.ReadXml(userDataStream);
                userDataStream.Close();
                return userDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                userDataStream?.Dispose();
                userDataSet?.Dispose();
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
                dataTable.Columns.Add(prop.Name);

            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                    values[i] = Props[i].GetValue(item, null);
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static string Serialize(DataSet dataSet)
        {
            using (var writer = new StringWriter())
            {
                dataSet.WriteXml(writer, XmlWriteMode.WriteSchema);
                return writer.ToString();
            }
        }

        // Placeholder for password encryption
        public static string EncryptPassword(string password)
        {
            return string.Empty;
        }

        public static async Task<string> GetURLContentsAsync(string url)
        {
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            string xml = string.Empty;

            using (var response = (HttpWebResponse)webReq.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                xml = reader.ReadToEnd();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                xml = xmlDoc.InnerText;
            }

            return xml;
        }

        public static async Task<string> SerializeObjectAsync<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static T DeSerializeObject<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                reader.Read();
                return (T)serializer.Deserialize(reader);
            }
        }

        public static string ListSerialize<T>(List<T> obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static string GetEncryptedKey(string key, string message)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes))
            {
                byte[] bytes = cryptographer.ComputeHash(messageBytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private static string RemoveXmlDefinition(string xml)
        {
            XDocument xdoc = XDocument.Parse(xml);
            xdoc.Declaration = null;
            return xdoc.ToString();
        }
        public static string SerializeObject(object obj, Type t)
        {
            XmlSerializer serializer = new XmlSerializer(t);
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }
        public static string EncryptPassword_New(string password)
        {
            string encryptedPassword = "";
            return encryptedPassword;
        }

    }
}
