using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    int GetTimeOut = 30;
    public static string RN_CLSURL = ConfigurationSettings.AppSettings.Get("RN_CLURL");
    public static string CLSURL = ConfigurationSettings.AppSettings.Get("CLURL");
    public static string INT_CLURL = ConfigurationSettings.AppSettings.Get("INT_CLURL");

    static string err_timeout = "OOPS! Something went wrong. Try again.";
    // public static string UserId = "0";
    public static string UserName = string.Empty;
    public static string App_Name = "Consumer Web";
    //public static string token = string.Empty;
    public static string DeviceId = string.Empty;
    public static string PayerCode = "T_18727";
    //Nik_241122_start
    public static string PayerCode_wyn = "T_18728";
    //Nik_241122_start
    //public static string BrokerCode = HttpContext.Current.Request.Cookies["EntityCode"].ToString();
    public static string ErrorLogPath = ConfigurationSettings.AppSettings.Get("ErrorLogPath");
    public static string AlertHeader = Resources.AlertMessage.Alert_Msg_Header;
    public static int PostTimeOut = 15;
    public static string EncryptionKey = "MAKV2SPBNI99212";
    static Regex MobileCheck = new Regex(@"android|(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
    static Regex MobileVersionCheck = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
    public static string Broker_name = ConfigurationSettings.AppSettings.Get("Broker_name");
    public static string broker_code = string.Empty;

    public static string SAST_CLURL = ConfigurationSettings.AppSettings.Get("SAST_CLURL");
    public Utils()
    {
        //
        // TODO: Add constructor logic here
        //

        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("is_broker")))
        {
            if (ConfigurationManager.AppSettings.Get("is_broker") == "1")
            {
                AlertHeader = Broker_name;

                // PayerCode = HttpContext.Current.Request.Cookies["EntityCode"].ToString();
            }
        }
    }
    public static bool CreateDirectoryRecursive(string path)
    {
        bool result = true;
        try
        {
            string[] pathParts = path.Split('\\');

            for (int i = 0; i < pathParts.Length; i++)
            {
                if (i > 0)
                    pathParts[i] = Path.Combine(pathParts[i - 1], pathParts[i]);

                if (!Directory.Exists(pathParts[i]))
                    Directory.CreateDirectory(pathParts[i]);
            }
        }
        catch (Exception)
        {
            result = false;
        }
        return result;
    }
    public string HttpRequestResponse(string url)
    {
        var cts = new CancellationTokenSource();
        int count = 0;
        try
        {
            string earthquakesJson = string.Empty;
            while (count <= 2)
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var task = Task.Run(() =>
                        {
                            client.Timeout = TimeSpan.FromSeconds(GetTimeOut);
                            client.DefaultRequestHeaders.Add("Accept", "application/json");
                            var response = client.GetAsync(url, cts.Token).Result;
                            earthquakesJson = response.Content.ReadAsStringAsync().Result;
                        });
                        if (!task.Wait(TimeSpan.FromSeconds(GetTimeOut)))
                        {
                            throw new Exception(err_timeout);
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (count == 5)
                        {
                            throw ex;
                        }
                        count++;
                    }
                }
            }
            return earthquakesJson;
        }
        catch (WebException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (TaskCanceledException ex)
        {
            if (ex.CancellationToken == cts.Token)
            {
                // a real cancellation, triggered by the caller
                throw new Exception("No Internet Connection. We can not detect any internet connectivity. Please check your internet connection and try again.");
            }
            else
            {
                throw new Exception("No Internet Connection. We can not detect any internet connectivity. Please check your internet connection and try again.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("No Internet Connection. We can not detect any internet connectivity. Please check your internet connection and try again.");
        }

    }
    public string PostRequestNew(string url, string postData, string token = "")
    {
        string result = string.Empty;
        WebResponse response;
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            if (token != string.Empty)
                request.Headers.Add("AccessToken", token);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            var task = Task.Run(() =>
            {
                try
                {
                    response = request.GetResponse();
                    using (dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        result = reader.ReadToEnd();
                    }
                    response.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
            if (!task.Wait(TimeSpan.FromSeconds(30)))
            {
                throw new Exception("Timeout");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {

        }
        return result;
    }
    public string PostRequest(string url, string PostData, int Timeout = 0)
    {

        var cts = new CancellationTokenSource();
        string Output = string.Empty;
        int count = 0;
        try
        {
            while (count <= 2)
            {
                using (var client = new HttpClient())
                {
                    if (Timeout == 0)
                    {
                        Timeout = GetTimeOut;
                    }

                    client.Timeout = TimeSpan.FromSeconds(Timeout);
                    try
                    {
                        var task = Task.Run(() =>
                        {
                            var content = new StringContent(PostData);
                            var response = client.PostAsync(url, content).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Output = response.Content.ReadAsStringAsync().Result;
                            }
                        });
                        if (!task.Wait(TimeSpan.FromSeconds(Timeout)))
                        {
                            throw new Exception(err_timeout);
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (count == 5)
                        {
                            throw ex;
                        }
                        count++;
                    }
                }
            }

            return Output;
        }
        catch (WebException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (TaskCanceledException ex)
        {
            if (ex.CancellationToken == cts.Token)
            {
                // a real cancellation, triggered by the caller
                throw new Exception("No Internet Connection. We can not detect any internet connectivity. Please check your internet connection and try again.");
            }
            else
            {
                throw new Exception("No Internet Connection. We can not detect any internet connectivity. Please check your internet connection and try again.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("No Internet Connection. We can not detect any internet connectivity. Please check your internet connection and try again.");
        }

    }

    public string PostRequestV1(string url, string PostData)
    {
        var client = new HttpClient();
        var cts = new CancellationTokenSource();
        string Output = string.Empty;
        client.Timeout = TimeSpan.FromSeconds(20);
        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = PostData;
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            httpWebRequest.ContentType = "application/json";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Output = Convert.ToString(result);
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            Output = Convert.ToString(error);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, ErrorLogPath);
        }
        finally
        {
        }
        return Output;
    }
    public async Task PostRequest_SAST()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string SAST_client_id = ConfigurationManager.AppSettings["SAST_client_id"];
                string SAST_client_secret = ConfigurationManager.AppSettings["SAST_client_secret"];
                string SAST_grant_type = ConfigurationManager.AppSettings["SAST_grant_type"];
                string uri = ConfigurationManager.AppSettings["SAST_CLURL"] + string.Format("HRMS_Kgid_Share/token");
                var requestContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", SAST_client_id),
                    new KeyValuePair<string, string>("client_secret",SAST_client_secret),
                    new KeyValuePair<string, string>("grant_type", SAST_grant_type)
                });

                HttpResponseMessage response = await client.PostAsync(uri, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                   // Console.WriteLine($"Failed with status code {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
               // Console.WriteLine($"Request exception: {e.Message}");
            }
        }
    }

    public string PostRequestV2(string url, string PostData, FormUrlEncodedContent[] formUrlEncodedContents)
    {
        var client = new HttpClient();
        var cts = new CancellationTokenSource();
        string Output = string.Empty;
        client.Timeout = TimeSpan.FromSeconds(20);
        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = PostData;
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            httpWebRequest.ContentType = "application/json";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Output = Convert.ToString(result);
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            Output = Convert.ToString(error);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, ErrorLogPath);
        }
        finally
        {
        }
        return Output;
    }

    public static string Encrypt(string clearText)
    {

        try
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, ErrorLogPath);
        }

        return clearText;
    }

    public static string Decrypt(string cipherText)
    {
        try
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            cipherText = "";
            ErrorLogger.LogMessage(ex, ErrorLogPath);
        }
        return cipherText;
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
    public string GetToken(string key)
    {
        Utils _utils = new Utils();
        string requestURI = Utils.CLSURL + string.Format("api/Common/GetToken?key={0}", key);
        string Token = "";
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            Token = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Token;
    }


    public static bool fBrowserIsMobile()
    {
        Debug.Assert(HttpContext.Current != null);

        if (HttpContext.Current.Request != null && HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            var u = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToString();

            if (u.Length < 4)
                return false;

            if (MobileCheck.IsMatch(u) || MobileVersionCheck.IsMatch(u.Substring(0, 4)))
                return true;
        }

        return false;
    }

    private static Random random = new Random();
    //public static string RandomAlphaNumericString(int length)
    //{
    //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    //    return new string(Enumerable.Repeat(chars, length)
    //      .Select(s => s[random.Next(s.Length)]).ToArray());
    //}

    [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
    static extern int FindMimeFromData(IntPtr pBC,
      [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)] byte[] pBuffer,
      int cbSize,
      [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
      int dwMimeFlags, out IntPtr ppwzMimeOut, int dwReserved);

    public static string getMimeTypeFromFile(System.Web.HttpPostedFile file)
    {
        IntPtr mimeout;

        int MaxContent = (int)file.ContentLength;
        if (MaxContent > 4096) MaxContent = 4096;

        byte[] buf = new byte[MaxContent];
        file.InputStream.Read(buf, 0, MaxContent);
        int result = FindMimeFromData(IntPtr.Zero, file.FileName, buf, MaxContent, null, 0, out mimeout, 0);

        if (result != 0)
        {
            Marshal.FreeCoTaskMem(mimeout);
            return "";
        }

        string mime = Marshal.PtrToStringUni(mimeout);
        Marshal.FreeCoTaskMem(mimeout);

        return mime.ToLower();
    }

    public static bool ValidateMimeType(string[] extensions, System.Web.HttpPostedFile file)
    {
        bool isValid = false;
        string MimeType = getMimeTypeFromFile(file);
        string SuppliedExt = Path.GetExtension(Convert.ToString(file.FileName)).Replace(".", "").ToLower();
        foreach (string ext in extensions)
        {
            string extension = ext.Replace(".", "").ToLower();
            if (extension == "pdf" && SuppliedExt == "pdf" && (MimeType == "application/pdf" || MimeType == "application/octet-stream"))
                isValid = true;
            else if ((extension == "xlsx" || extension == "xls") && (SuppliedExt == "xlsx" || SuppliedExt == "xls") && (MimeType == "application/vnd.ms-excel" || MimeType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                isValid = true;
            else if ((extension == "jpg" || extension == "jpeg" || extension == "png") && (SuppliedExt == "jpg" || SuppliedExt == "jpeg" || SuppliedExt == "png") && (MimeType == "image/pjpeg" || MimeType == "image/png" || MimeType == "image/x-png"))
                isValid = true;
            else if ((extension == "docx" || extension == "doc") && (SuppliedExt == "docx" || SuppliedExt == "doc") && (MimeType == "application/msword" || MimeType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
                isValid = true;
            else if (extension == "txt" && SuppliedExt == "txt" && MimeType == "text/plain")
                isValid = true;

        }
        return isValid;
    }

    public static string GetIPAddress()

    {
        string ipaddress;
        ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
            ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        return ipaddress;


    }

    public static bool AlphabetNumeric(string value)
    {
        Regex regex = new Regex("^[a-zA-Z0-9]*$");

        if (regex.IsMatch(value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool VerifyNumericforString(string stringToValidate)
    {
        if ((stringToValidate != null) && (stringToValidate != String.Empty))
        {
            return Regex.IsMatch(stringToValidate, @"^[0-9]+$");
        }
        else
        {
            return true;
        }
    }

    public static bool VerifyMobile(string mobileNumber)
    {
        if (mobileNumber != null)
        {
            if (VerifyNumericforString(mobileNumber))
            {
                return (mobileNumber.ToString().Trim().Length == 10);
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static bool VerifyEmailId(string stringToValidate)
    {
        if (stringToValidate != null)
        {
            string EmailFormatRegx = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,9}|[0-9]{1,3})(\]?)$";
            return Regex.IsMatch(stringToValidate, EmailFormatRegx);
        }
        else
        {
            return false;
        }
    }
    public static void ExpireAllCookies()
    {
        if (HttpContext.Current != null)
        {
            int cookieCount = HttpContext.Current.Request.Cookies.Count;
            dynamic[] cookie = {HttpContext.Current.Request.Cookies["LogoutQuery"],
                  HttpContext.Current.Request.Cookies["EntityName"], HttpContext.Current.Request.Cookies["EntityCode"] };
            for (var i = 0; i < cookie.Length; i++)
            {

                if (cookie != null)
                {

                    var expiredCookie = new HttpCookie(cookie[i].Name)
                    {
                        Expires = DateTime.Now.AddDays(-1),
                        Domain = cookie[i].Domain
                    };
                    HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                }
            }

            // clear cookies server side
            HttpContext.Current.Request.Cookies.Clear();

        }
    }
}