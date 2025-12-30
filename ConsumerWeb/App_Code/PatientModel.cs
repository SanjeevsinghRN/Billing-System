using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RN.MOBILE_COMMON;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using System.Configuration;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.Globalization;

/// <summary>
/// Summary description for PatientModel
/// </summary>
public class PatientModel
{

    public PatientModel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static List<PrescriptionClass> GetTransactionList(string patientId, string transType, int isHC, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetTransactionList?patientId={0}&transType={1}&isHC={2}", patientId, transType, isHC);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetTransactionList_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static DisclaimerClass GetDisclaimerText(string DisclaimerCode, string EntityCode)
    {
        string requestURI = string.Empty;
        if (string.IsNullOrEmpty(EntityCode))
            requestURI = Utils.CLSURL + string.Format("api/Patient/GetDisclaimerText?DisclaimerCode={0}", DisclaimerCode);
        else
            requestURI = Utils.CLSURL + string.Format("api/Patient/GetDisclaimerText?DisclaimerCode={0}&EntityCode={1}", DisclaimerCode, EntityCode);

        DisclaimerClass obj = new DisclaimerClass();



        Utils _utils = new Utils();

        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            obj = JsonConvert.DeserializeObject<DisclaimerClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }

    public static List<Patient> GetPatients(string mobileNo, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Physician/GetPatientDetails?mobileno={0}&PayerCode={1}", mobileNo, Utils.PayerCode);
        List<Patient> objlist = new List<Patient>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPatientDetails_Phy_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
            //				objlist.Error = "006";
            //				objlist.ErrorDesc = ex.Message;
        }
        return objlist;
    }

    public static string GetProfilePhotoName(string PatientId, string token)
    {

        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetProfilePhoto?PatientId={0}", PatientId);
        string UserId = string.Empty;
        string filename = string.Empty;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            if (!string.IsNullOrEmpty(response))
            {
                filename = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return filename;
    }



    //public static string getotp(string IntegrationAppointmentId, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Patient/GetOTP?IntegrationAppointmentId={0}", IntegrationAppointmentId);
    //    string OTP = string.Empty;
    //    RequestResponse objReqRes = new RequestResponse();

    //    try
    //    {
    //        Utils _utils = new Utils();
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        if (!string.IsNullOrEmpty(response))
    //        {
    //            OTP = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return OTP;

    //}
    public static List<Resend_otp> getotp(string IntegrationAppointmentId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetOTP?IntegrationAppointmentId={0}", IntegrationAppointmentId);
        List<Resend_otp> objlist = new List<Resend_otp>();
        //string OTP = string.Empty;
        RequestResponse objReqRes = new RequestResponse();

        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            if (!string.IsNullOrEmpty(response))
            {
                objlist = objReqRes.String_getresend_Response_Deserialize(JsonConvert.DeserializeObject<string>(response),token);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;

    }







    public static bool UploadProfileFile(string FileName, string FilePath)
    {
        bool IsSuccess = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UploadProfileImage?UserType={0}&FileName={1}", (int)Enumerations.UserType.Patient, FileName);
        try
        {
            if (UploadFileWithFilePath(requestURI, FileName, FilePath))
            {
                IsSuccess = true;
            }
        }
        catch (Exception ex)
        {
            IsSuccess = false;
        }
        return IsSuccess;
    }

    public static bool IsAppointmentExist(string entityCode, string serviceType, string appointmentTime, string appointmentDate, string patientId, string physicianId)
    {
        bool isExsist = false;
        Utils _utils = new Utils();
        try
        {
            string requestURI = Utils.CLSURL + string.Format("api/Patient/IsAppointmentExist?entityCode={0}&serviceType={1}&appointmentTime={2}&appointmentDate={3}&patientId={4}&physicianId={5}", entityCode, serviceType, appointmentTime, appointmentDate, patientId, physicianId);
            string response = _utils.HttpRequestResponse(requestURI);
            if(response=="true")
            {
                isExsist = true;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        return isExsist;
    }

    public static bool UpdateUserDetails(string patientID, Patient patient, string token)
    {
        string physicainXML = string.Empty;// await MUtils.PatientSerialize(patient);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UpdateUserDetails?PatientId={0}&payercode={1}", patientID, Utils.PayerCode);
        bool isSuccess = false;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            physicainXML = objReqRes.UpdateUserDetails_Pat_Serialize_V2(patient, token);
            string response = _utils.PostRequest(requestURI, physicainXML);
            isSuccess = objReqRes.Boolean_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public static bool DownloadProfileFile(string FileName, string path)
    {
        bool ReturnResponse = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadProfileFile?UserType={0}&fileName={1}", (int)Enumerations.UserType.Patient, FileName);
        try
        {
            ReturnResponse = DownloadFileForced(requestURI, FileName, path);
        }
        catch (Exception ex)
        {
            ReturnResponse = false;
        }
        return ReturnResponse;
    }

    public static bool DownloadFileForced(string requestURI, string FileName, string path)
    {
        bool flag = false;
        //string imagepth = ConfigurationManager.AppSettings["ProfilePhotoPath"];
        string docsPath = path;

        FileInfo fileInfo = new FileInfo(docsPath + FileName);
        if (fileInfo.Exists)
        {
            File.Delete(docsPath + FileName);
        }
        //if (CheckFileExists(FileName))
        //{
        //    return true;
        //}
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(Utils.CLSURL);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestURI);
            HttpResponseMessage response = null;
            FileStream fstream = null;
            try
            {
                httpClient.Timeout = TimeSpan.FromSeconds(25);
                response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
                if (response.IsSuccessStatusCode)
                {
                    // GetFolderPath();
                    fstream = new FileStream(docsPath + "/" + FileName, FileMode.Create, System.IO.FileAccess.Write, FileShare.None);
                    response.Content.CopyToAsync(fstream);
                    fstream.Close();
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
                if (fstream != null)
                    fstream.Dispose();
            }
            return flag;
        }
    }
    public static List<PrescriptionClass> GetPatientVitalDashboard(string MobileNo, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPatientVitalDashboard?PatientMobile={0}&PayerCode={1}", MobileNo, Utils.PayerCode);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPatientVitalDashboard_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static List<EcardDetails> GetFamilyDetails(string PatientId, string PayerCode, int EcardDownload, string token = "")
    {
        string uri = Utils.CLSURL + string.Format("api/Patient/GetFamilyDetails?PatientId={0}&PayerCode={1}&EcardDownload={2}", PatientId, PayerCode, EcardDownload);
        List<EcardDetails> EcardDet = null;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(uri);
            EcardDet = objReqRes.GetFamilyDetails_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return EcardDet;
    }

    public static List<EcardDetails> GetFamilyDetails_V1(string PatientId, string PayerCode, int EcardDownload, string memberId, string token = "")
    {
        string uri = Utils.CLSURL + string.Format("api/Patient/GetFamilyDetails?PatientId={0}&PayerCode={1}&EcardDownload={2}&memberId={3}", PatientId, PayerCode, EcardDownload, memberId);
        List<EcardDetails> EcardDet = null;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(uri);
            EcardDet = objReqRes.GetFamilyDetails_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return EcardDet;
    }
    public static List<Vital_Controls> GetVitalsControlsList(string searchKey, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Common/GetVitalsControlsList?searchKey={0}", searchKey);
        List<Vital_Controls> objlist = new List<Vital_Controls>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.VitalsControls_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public async Task<bool> DownloadFile(string requestURI, string FileName, string Path, string DownloadFileName = "")
    {
        bool flag = false;
        string docsPath = Path;

        //FileInfo fileInfo = new FileInfo(docsPath + FileName);
        //if (fileInfo.Exists)
        //{
        //    return true;
        //}

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(Utils.CLSURL);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestURI);
            HttpResponseMessage response = null;
            FileStream fstream = null;
            try
            {
                httpClient.Timeout = TimeSpan.FromSeconds(25);
                response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
                if (response.IsSuccessStatusCode)
                {
                    WebRequest webRequest = WebRequest.Create(requestURI);
                    WebResponse webResp = webRequest.GetResponse();
                    string test = string.Empty;

                    Stream str = webResp.GetResponseStream();
                    byte[] inBuf = new byte[100000000];
                    int bytesToRead = (int)inBuf.Length;
                    int bytesRead = 0;
                    while (bytesToRead > 0)
                    {
                        int n = str.Read(inBuf, bytesRead, bytesToRead);
                        if (n == 0)
                            break;
                        bytesRead += n;
                        bytesToRead -= n;
                    }
                    if (!string.IsNullOrEmpty(DownloadFileName))
                    {
                        FileName = DownloadFileName;

                    }
                    FileStream fstr = new FileStream(docsPath + "/" + FileName, FileMode.OpenOrCreate,
                    FileAccess.Write);
                    fstr.Write(inBuf, 0, bytesRead);
                    str.Close();
                    fstr.Close();

                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
                if (fstream != null)
                    fstream.Dispose();
            }
            return flag;
        }

    }

    public static List<RecieptDetails> GetAvailableRecieptDetails(string prescriptionid, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetAvailableRecieptDetails?prescriptionId={0}", prescriptionid);
        List<RecieptDetails> objlist = new List<RecieptDetails>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();

        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetAvailableRecieptDetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<Appointment> GetAppointmentDashboard(string MobileNo, string token)
    {
        //string requestURI = Utils.CLSURL + string.Format("api/Patient/GetAppointmentDashboard?PatientMobile={0}&PayerCode={1}", MobileNo, Utils.PayerCode);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetAppointmentDashboard_v1?PatientMobile={0}&PayerCode={1}&LastFetchDateTime={2}", MobileNo, Utils.PayerCode, "");
        List<Appointment> objlist = new List<Appointment>();
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetAppDashV1_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static RN.MOBILE_COMMON.PolicyCover GetPolicyCover(string MemberNo, string token)
    {
        RN.MOBILE_COMMON.PolicyCover objlist = new RN.MOBILE_COMMON.PolicyCover();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetPolicyCover?MemberNo={0}", MemberNo);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetPolicyCover_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static bool DownloadRecieptFile(string FileName, int TRANSACTION_TYPE, string prescriptionid, string OrderNo, string reqType, string filepath)
    {
        bool ReturnResponse = false;
        string requestURI = string.Empty;

        if (TRANSACTION_TYPE == (int)Enumerations.TRANSACTION_TYPE.DIAGNOSTIC)
        {
            requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadDiagnosticsReceipt?fileName={0}&orderId={1}&reqType=", FileName, OrderNo);
        }
        else if (TRANSACTION_TYPE == (int)Enumerations.TRANSACTION_TYPE.PHARMACY)
        {
            requestURI = Utils.CLSURL + string.Format("api/Pharmacy/DownloadReceipt?fileName={0}&orderId={1}&reqType=", FileName, OrderNo);
        }
        else
        {
            requestURI = Utils.CLSURL + string.Format("api/Physician/DownloadPhysicianPDFReceipt?fileName={0}&transactionType={1}&prescrptionID={2}&reqType={3}", FileName, TRANSACTION_TYPE, prescriptionid, reqType);
        }

        try
        {
            WebRequest webRequest = WebRequest.Create(requestURI);
            WebResponse webResp = webRequest.GetResponse();
            string test = string.Empty;

            Stream str = webResp.GetResponseStream();
            byte[] inBuf = new byte[100000000];
            int bytesToRead = (int)inBuf.Length;
            int bytesRead = 0;
            while (bytesToRead > 0)
            {
                int n = str.Read(inBuf, bytesRead, bytesToRead);
                if (n == 0)
                    break;
                bytesRead += n;
                bytesToRead -= n;
            }
            FileStream fstr = new FileStream(filepath + FileName, FileMode.OpenOrCreate,
            FileAccess.Write);
            fstr.Write(inBuf, 0, bytesRead);
            str.Close();
            fstr.Close();
            ReturnResponse = true;

        }
        catch (WebException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ReturnResponse = false;
        }
        //finally
        //{
        //    try
        //    {
        //        string strLog = string.Format("FileName={0}, TRANSACTION_TYPE={1}, prescriptionid={2}, OrderNo={3}, reqType={4}, filepath={5}", FileName, Convert.ToString(TRANSACTION_TYPE), prescriptionid, OrderNo, reqType, filepath);
        //        ErrorLogger.CreateLogFile(strLog, Utils.ErrorLogPath);
        //    }
        //    catch (Exception){}
        //}
        return ReturnResponse;
    }

    public static RN.MOBILE_COMMON.BenefitList GetMemberUtilization(string MemberNo, int serviceType, string token)
    {
        RN.MOBILE_COMMON.BenefitList objlist = new RN.MOBILE_COMMON.BenefitList();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetMemberUtilization?MemberNo={0}&serviceType={1}", MemberNo, serviceType);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetMemberUtilization_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<Pharmacy> GetPharmacy(string patientID, string DrugXml = "", string token = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPharmacyDetails?PatientId={0}", patientID);
        List<Pharmacy> objlist = new List<Pharmacy>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.PostRequest(requestURI, DrugXml);
            objlist = objReqRes.GetPharmacyDetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return objlist;
    }

    public static PrescriptionClass GetPartialPrescData(string patientId, string prescriptionId, string pharmacyId, string EntityCode = "", string PayerCode = "", string token = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPartialPrescData?patientId={0}&prescriptionId={1}&pharmacyId={2}&EntityCode={3}&PayerCode={4}", patientId, prescriptionId, pharmacyId, "", "");
        PrescriptionClass objlist = new PrescriptionClass();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPartialPrescriptionDetail_Phar_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
            //              objlist.Error = "006";
            //              objlist.ErrorDesc = ex.Message;
        }
        return objlist;
    }
    public static PaymentBreakupDetails ValidateProductPolicy(PrescriptionClass objPClass, int transactionType = 1, string token = "")
    {
        PaymentBreakupDetails objlist = new PaymentBreakupDetails();
        RequestResponse objReqRes = new RequestResponse();
        string uri = string.Format("api/Patient/ValidateProductPolicy_V1");
        try
        {
            Utils _utils = new Utils();
            objPClass.payerCode = Utils.PayerCode;
            objPClass.TransactionType = transactionType.ToString();
            string sData = objReqRes.PrescriptionClass_Serialize(objPClass, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData);
            objlist = objReqRes.ValidateProductPolicy_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objlist;
    }
    //public static List<AppointmentSlotList> GetAppointmentTimeSlot(int entityID, int physicianID, string appointmentDate, int slotType)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Patient/GetAppointmentTimeSlot?entityID={0}&physicianID={1}&appointmentDate={2}&slotType={3}", entityID, physicianID, appointmentDate.Replace("-", "/"), slotType);
    //    List<AppointmentSlotList> objlist = new List<AppointmentSlotList>();
    //    Utils _utils = new Utils();
    //    try
    //    {
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        objlist = JsonConvert.DeserializeObject<List<AppointmentSlotList>>(response);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return objlist;
    //}
    public static List<AppointmentSlotList> GetAppointmentTimeSlot(int entityID, int physicianID, string appointmentDate, int slotType)
    {
        List<AppointmentSlotList> objlist = new List<AppointmentSlotList>();
        Utils _utils = new Utils();
        Sast_Utils sast_Utils = new Sast_Utils();
        try
        {
            List<AppointmentSlotList> dummySlotList = new List<AppointmentSlotList>();

            // Define slot start and end times
            TimeSpan slotStartTime = new TimeSpan(10, 0, 0); // 10:00 AM
            TimeSpan slotEndTime = new TimeSpan(20, 0, 0);   // 8:00 PM

            // Generate slots
            DateTime currentDate = DateTime.Today;
            DateTime slotStartDateTime = currentDate.Date + slotStartTime;
            DateTime slotEndDateTime = currentDate.Date + slotEndTime;
            TimeSpan slotDuration = TimeSpan.FromMinutes(30); // Assuming slot duration is 30 minutes

            while (slotStartDateTime < slotEndDateTime)
            {
                dummySlotList.Add(new AppointmentSlotList
                {
                    SlotID = dummySlotList.Count + 1,
                    SlotType = 1, // Assuming all slots have the same type
                    Slot = slotStartDateTime.ToString("HH:mm"),
                    SlotStatus = "AVAILABLE",
                    SlotEndTime = slotStartDateTime.Add(slotDuration).ToString("HH:mm"),
                    transaction_id = Guid.NewGuid().ToString() // Generate a unique transaction ID for each slot
                });

                slotStartDateTime = slotStartDateTime.Add(slotDuration);
            }

            // Define time intervals
            TimeSpan morningStart = TimeSpan.FromHours(6);    // Adjust as needed
            TimeSpan afternoonStart = TimeSpan.FromHours(12); // Adjust as needed
            TimeSpan eveningStart = TimeSpan.FromHours(18);   // Adjust as needed

            // Initialize lists for each group
            List<AppointmentSlotList> morningSlots = new List<AppointmentSlotList>();
            List<AppointmentSlotList> afternoonSlots = new List<AppointmentSlotList>();
            List<AppointmentSlotList> eveningSlots = new List<AppointmentSlotList>();

            foreach (var slot in dummySlotList)
            {
                // Convert slot time string to TimeSpan
                TimeSpan slotTime = DateTime.Parse(slot.Slot).TimeOfDay;

                // Categorize the slot based on the time of day and set the SlotType accordingly
                if (slotTime >= morningStart && slotTime < afternoonStart)
                {
                    slot.SlotType = 1;
                    morningSlots.Add(slot);
                }
                else if (slotTime >= afternoonStart && slotTime < eveningStart)
                {
                    slot.SlotType = 2;
                    afternoonSlots.Add(slot);
                }
                else
                {
                    slot.SlotType = 3;
                    eveningSlots.Add(slot);
                }
            }

            objlist = dummySlotList;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static string SaveAppointment(Appointment objAppointment)
    {
        objAppointment.PayerCode = Utils.PayerCode;
        string xmldata = MUtils.SerializeObject(objAppointment, typeof(Appointment));
        string requestURI = Utils.CLSURL + string.Format("api/Patient/SaveAppointmentV1");
        string appointmentId = string.Empty;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, xmldata);
            appointmentId = JsonConvert.DeserializeObject<string>(response);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return appointmentId;
    }

    public static string CancelAppointment(Appointment objApp, string token)
    {
        string obj = null;
        string uri = string.Format("api/Patient/CancelAppointment");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            List<Appointment> objClass = new List<Appointment>();
            objClass.Add(objApp);
            string sData = objReqRes.GetAppointmentDashbroad_Pat_Serialize(objClass, token);//  JsonConvert.SerializeObject(objPClass);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData);
            obj = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }

    public static List<Physician> GetPhysicianSearch(string Latitude, string Longitude, string SearchKey = "", string Pincode = "", int Radius = 0, string token = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPhysicianSearch?payerCode={0}&Latitude={1}&Longitude={2}&SearchKey={3}&Pincode={4}&RadiusLimit={5}", Utils.PayerCode, Latitude, Longitude, SearchKey, Pincode, Radius);
        List<Physician> objlist = new List<Physician>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPhysicianSearch_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static string GetcontactEmalID()
    {
        string uri = Utils.CLSURL + string.Format("api/common/GetcontactEmalID?");
        Utils _utils = new Utils();
        string returnval = string.Empty;
        try
        {
            var response = _utils.HttpRequestResponse(uri);
            returnval = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnval;
    }

    public static string GetMemberID(string PatientID, string payercode)
    {
        string uri = Utils.CLSURL + string.Format("api/Patient/GetMemberID?PatientID={0}&payercode={1}", PatientID, payercode);
        Utils _utils = new Utils();
        string returnval = string.Empty;
        try
        {
            var response = _utils.HttpRequestResponse(uri);
            returnval = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnval;
    }

    public static string GetCorporateCode(string UserID, string payercode)
    {
        string uri = Utils.CLSURL + string.Format("api/Patient/GetCorporateCode?memberID={0}&payercode={1}", UserID, payercode);
        Utils _utils = new Utils();
        string returnval = string.Empty;
        try
        {
            var response = _utils.HttpRequestResponse(uri);
            returnval = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnval;
    }


    public static Consumer_Theme GetConsumerTheme(string UserId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetConsumerTheme?UserId={0}", UserId);
        Consumer_Theme obj = new Consumer_Theme();
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            response = JsonConvert.DeserializeObject<string>(response);
            obj = objReqRes.GetConsumerTheme_Response_Deserialize(response, token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }

    public static GetPolicyCoverGroupItems GetPolicyCoverGroupItems(string MemberNo, string Code, string Type, string token)
    {
        GetPolicyCoverGroupItems objlist = new GetPolicyCoverGroupItems();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetPolicyCoverGroupItems?MemberNo={0}&Code={1}&Type={2}", MemberNo, Code, Type);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetPolicyCoverGroupItems_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static bool SaveVitals(PrescriptionClass objPresc, string token)
    {
        bool isSuccess = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/SaveVitals");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            List<PrescriptionClass> PrescLst = new List<PrescriptionClass>();
            PrescLst.Add(objPresc);
            string sData = objReqRes.GetPatientVitalDashboard_Pat_Serialize(PrescLst, token);// JsonConvert.SerializeObject(objPClass);
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, sData);
            isSuccess = JsonConvert.DeserializeObject<bool>(response);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public static bool UploadAttachmentFile(string PrescriptionId, int PATIENT_ID, int SELF_ID, string ATTACH_REMARKS, string ATTACH_FILENAME, string FilePath)
    {
        bool IsSuccess = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UploadAttachmentFile?CLAIM_ID={0}&PATIENT_ID={1}&SELF_ID={2}&ATTACH_REMARKS={3}&ATTACH_FILENAME={4}", PrescriptionId, PATIENT_ID, SELF_ID, ATTACH_REMARKS, ATTACH_FILENAME);
        try
        {
            if (UploadFileWithFilePath(requestURI, ATTACH_FILENAME, FilePath))
            {
                IsSuccess = true;
            }
        }
        catch (Exception ex)
        {
            IsSuccess = false;
        }
        return IsSuccess;
    }

    public static bool UploadFileWithFilePath(string requestURI, string fileName, string Attachpath)
    {
        bool Uploaded = false;
        try
        {
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();

            if (System.IO.File.Exists(Attachpath))
            {
                StreamContent file = new StreamContent(new FileStream(Attachpath, FileMode.Open, FileAccess.Read));
                file.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                file.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                file.Headers.ContentDisposition.FileName = System.IO.Path.GetFileName(Attachpath);
                formDataContent.Add(file);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestURI);
                request.Content = formDataContent;
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Utils.CLSURL);
                    var response = httpClient.SendAsync(request).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Uploaded = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Uploaded = false;
        }
        return Uploaded;
    }

    public static bool UploadMultipleFileWithFilePath(string requestURI, List<string> fileNames, string Attachpath)
    {
        bool Uploaded = false;
        bool submit_required = false;
        try
        {
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();

            foreach (string fileName in fileNames)
            {
                if (!string.IsNullOrEmpty(fileName) && File.Exists(Attachpath + fileName))
                {
                    submit_required = true;
                    string Attachpath_new = Attachpath + fileName;
                    StreamContent file = new StreamContent(new FileStream(Attachpath_new, FileMode.Open, FileAccess.Read));
                    file.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                    file.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    file.Headers.ContentDisposition.FileName = System.IO.Path.GetFileName(Attachpath_new);
                    if (System.IO.File.Exists(Attachpath_new))
                        formDataContent.Add(file);
                }
            }
            if (!submit_required)
                return true;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestURI);
            request.Content = formDataContent;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Utils.CLSURL);
                var response = httpClient.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    Uploaded = true;
                }
            }
        }
        catch (Exception ex)
        {
            Uploaded = false;
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
        return Uploaded;
    }

    public static bool UploadFile(string requestURI, string fileName, string docsPath)
    {

        bool Uploaded = false;
        int count = 0;
        try
        {
            string Attachpath = docsPath + "/" + fileName;
            if (System.IO.File.Exists(Attachpath))
            {
                while (count <= 0)
                {
                    MultipartFormDataContent formDataContent = new MultipartFormDataContent();
                    StreamContent file = new StreamContent(new FileStream(Attachpath, FileMode.Open, System.IO.FileAccess.Read));
                    try
                    {
                        file.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                        file.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        file.Headers.ContentDisposition.FileName = System.IO.Path.GetFileName(Attachpath);
                        formDataContent.Add(file);
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestURI);
                        request.Content = formDataContent;
                        using (HttpClient httpClient = new HttpClient())
                        {
                            httpClient.Timeout = TimeSpan.FromSeconds(Utils.PostTimeOut);
                            httpClient.BaseAddress = new Uri(Utils.RN_CLSURL);
                            var response = httpClient.SendAsync(request).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Uploaded = true;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (count == 0)
                        {
                            throw ex;
                        }
                        count++;
                    }
                    finally
                    {
                        file.Dispose();
                        formDataContent.Dispose();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Uploaded = false;
        }
        return Uploaded;
    }
    //public static async Task<PrescriptionClass> GetPrescriptionDetail(string patientID, string PrescriptionId, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPrescriptionDetail?PatientId={0}&PrescriptionId={1}", patientID, PrescriptionId);
    //    PrescriptionClass objlist = new PrescriptionClass();
    //    Utils _utils = new Utils();
    //    RequestResponse objReqRes = new RequestResponse();

    //    try
    //    {
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        objlist = objReqRes.GetPrescriptionDetail_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return objlist;
    //}

    public static async Task<PrescriptionClass> GetPrescriptionDetail(string patientID, string PrescriptionId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPrescriptionDetail?PatientId={0}&PrescriptionId={1}", patientID, PrescriptionId);
        PrescriptionClass objlist = new PrescriptionClass();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();

        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPrescriptionDetail_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static bool DownloadAttachmentFile(string Patient_id, string FileName, string docsPath)
    {
        bool ReturnResponse = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadAttachmentFile?PATIENT_ID={0}&ATTACH_FILENAME={1}", Patient_id, FileName);
        try
        {
            ReturnResponse = DownloadFileForced_new(requestURI, FileName, docsPath);
        }
        catch (Exception ex)
        {
            ReturnResponse = false;
        }
        return ReturnResponse;
    }

    public static bool DownloadFileForced_new(string requestURI, string FileName, string path)
    {
        bool flag = false;
        string docsPath = path;

        FileInfo fileInfo = new FileInfo(docsPath + FileName);
        if (fileInfo.Exists)
        {
            return true;
        }

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(Utils.CLSURL);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestURI);
            HttpResponseMessage response = null;
            FileStream fstream = null;
            try
            {
                httpClient.Timeout = TimeSpan.FromSeconds(25);
                response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
                if (response.IsSuccessStatusCode)
                {
                    WebRequest webRequest = WebRequest.Create(requestURI);
                    WebResponse webResp = webRequest.GetResponse();
                    string test = string.Empty;

                    Stream str = webResp.GetResponseStream();
                    byte[] inBuf = new byte[100000000];
                    int bytesToRead = (int)inBuf.Length;
                    int bytesRead = 0;
                    while (bytesToRead > 0)
                    {
                        int n = str.Read(inBuf, bytesRead, bytesToRead);
                        if (n == 0)
                            break;
                        bytesRead += n;
                        bytesToRead -= n;
                    }
                    FileStream fstr = new FileStream(docsPath + "/" + FileName, FileMode.OpenOrCreate,
                    FileAccess.Write);
                    fstr.Write(inBuf, 0, bytesRead);
                    str.Close();
                    fstr.Close();



                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
                if (fstream != null)
                    fstream.Dispose();
            }
            return flag;



        }
    }
    public static string GetProfileImageURL(int UserType, string Entity_Code, string Image_Key = "", string token = "")
    {
        if (string.IsNullOrWhiteSpace(Image_Key))
            Image_Key = Entity_Code;

        string obj = null;
        string uri = Utils.CLSURL + string.Format("api/common/GetProfileImageURL?UserType={0}&Image_Key={1}&Entity_Code={2}", UserType, Image_Key, Entity_Code);
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(uri);
            obj = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
            if (!string.IsNullOrWhiteSpace(obj))
                obj = Utils.CLSURL + obj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }


    public static List<ShippingAddress> GetShippingAddress(string patientId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetShippingAddress?patientId={0}", patientId);
        List<ShippingAddress> objlist = new List<ShippingAddress>();
        RequestResponse objReqRes = new RequestResponse();

        Utils _utils = new Utils();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetShippingAddress_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static ErrorClass SubmitPrescription(PrescriptionClass prescription, string prescriptionId, string token)
    {
        ErrorClass objerror = new ErrorClass();
        string prescriptionXML = string.Empty;// await MUtils.PrescSerialize(prescription);
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string requestURI = Utils.CLSURL + string.Format("api/Patient/SubmitPrescription?PrescriptionId={0}", prescriptionId);
            Utils _utils = new Utils();
            prescriptionXML = objReqRes.GetPartialPrescriptionDetail_Phar_Serialize(prescription, token);
            string response = _utils.PostRequest(requestURI, prescriptionXML, 30);
            if (!string.IsNullOrEmpty(response))
            {
                objerror = JsonConvert.DeserializeObject<ErrorClass>(response);
            }
            else
            {
                objerror.Errormessage = Resources.AlertMessage.Drug_Order_Place_Failed;
            }
        }
        catch (Exception ex)
        {
            objerror.Errormessage = Resources.AlertMessage.Drug_Order_Place_Failed;

        }
        return objerror;
    }

    public bool DownloadDiagnosisFile(string FileName, string innerFolder,string filepath, string docType)
    {
        bool downloaded = false;
        try
        {
            string requestURI = string.Format("api/Patient/DownloadFileV2?fileName={0}&innerFolder={1}&docType={2}", FileName, innerFolder, docType);

            WebRequest webRequest = WebRequest.Create(Utils.CLSURL + requestURI);
            WebResponse webResp = webRequest.GetResponse();
            string test = string.Empty;

            Stream str = webResp.GetResponseStream();
            byte[] inBuf = new byte[100000000];
            int bytesToRead = (int)inBuf.Length;
            int bytesRead = 0;
            while (bytesToRead > 0)
            {
                int n = str.Read(inBuf, bytesRead, bytesToRead);
                if (n == 0)
                    break;
                bytesRead += n;
                bytesToRead -= n;
            }
            FileStream fstr = new FileStream(filepath + FileName, FileMode.OpenOrCreate,
            FileAccess.Write);
            fstr.Write(inBuf, 0, bytesRead);
            str.Close();
            fstr.Close();
            downloaded = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return downloaded;
    }

    public bool DownloadMinorTestReport(string FileName, string root, string filepath)
    {
        bool downloaded = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadMinorTestReport?prescriptionid={0}&fileName={1}", root, FileName);
        try
        {
            WebRequest webRequest = WebRequest.Create(requestURI);
            WebResponse webResp = webRequest.GetResponse();
            string test = string.Empty;

            Stream str = webResp.GetResponseStream();
            byte[] inBuf = new byte[100000000];
            int bytesToRead = (int)inBuf.Length;
            int bytesRead = 0;
            while (bytesToRead > 0)
            {
                int n = str.Read(inBuf, bytesRead, bytesToRead);
                if (n == 0)
                    break;
                bytesRead += n;
                bytesToRead -= n;
            }
            FileStream fstr = new FileStream(filepath + FileName, FileMode.OpenOrCreate,
            FileAccess.Write);
            fstr.Write(inBuf, 0, bytesRead);
            str.Close();
            fstr.Close();
            downloaded = true;


        }
        catch (Exception ex)
        {
            throw ex;
        }

        return downloaded;
    }
    public static List<PrescriptionClass> GetPrescriptionList(string PatientMobile, string transType, int isHC, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPrescriptionList?PatientMobile={0}&TransactionType={1}&payerCode={2}", PatientMobile, transType, Utils.PayerCode);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPrescriptionList_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static DiagTestSearch GetDiagTestAvailableCenters(string Presc_Id, string Latitude, string Longitude, string SearchKey = "", string Pincode = "", int Radius = 0, int IsAvailable = 0, int CityId = 0, string token = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetDiagTestAvailableCentersV1?Presc_Id={0}&payerCode={1}&Latitude={2}&Longitude={3}&SearchKey={4}&Pincode={5}&RadiusLimit={6}&IsAvailable={7}&CityId={8}", Presc_Id, Utils.PayerCode, Latitude, Longitude, SearchKey, Pincode, Radius, IsAvailable, CityId);
        DiagTestSearch objlist = new DiagTestSearch();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetDiagTestAvailableCenters_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static HospitalSearch GetHospitals(string Latitude, string Longitude, string SearchKey = "", string Pincode = "", int Radius = 0, int IsAvailable = 0, int CityId = 0, string token = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetHospitals?payerCode={0}&Latitude={1}&Longitude={2}&SearchKey={3}&Pincode={4}&RadiusLimit={5}&IsAvailable={6}&CityId={7}", Utils.PayerCode, Latitude, Longitude, SearchKey, Pincode, Radius, IsAvailable, CityId);
        HospitalSearch objlist = new HospitalSearch();
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetHospital_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<Diagnostic> GetHCAvailableCenters(string Presc_Id, string Latitude, string Longitude, string SearchKey = "", string Pincode = "", int Radius = 0, int CityId = 0, string token = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Diagnostic/GetHCAvailableCenters?HC_Code={0}&payerCode={1}&Latitude={2}&Longitude={3}&SearchKey={4}&Pincode={5}&RadiusLimit={6}&CityId={7}", Presc_Id, Utils.PayerCode, Latitude, Longitude, SearchKey, Pincode, Radius, CityId, token);
        List<Diagnostic> objlist = new List<Diagnostic>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetHCAvailableCenters_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<HealthCheckup> GetProductPolicyHealthCheckup(string MobileNo, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Diagnostic/GetProductPolicyHealthCheckup?MobileNo={0}&payerCode={1}", MobileNo, Utils.PayerCode);
        List<HealthCheckup> objlist = new List<HealthCheckup>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetProductPolicyHealthCheckup_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static GetPolicyType GetPolicyType(string PatientId, string token)
    {
        GetPolicyType objlist = new GetPolicyType();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetPolicyType?PatientId={0}", PatientId);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetPolicyType_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static Patient GetPatientDetail(string UserId, string token)
    {
        Patient objlist = new Patient();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetPatientDetails?PatientId={0}", UserId);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetPatientDetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }



    public static List<PaymentBreakupDetails> GetPaymentBreakupDetails(string prescriptionid, int flag, int transactionType, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPaymentBreakupDetails_V1?prescriptionId={0}&flag={1}&transactionType={2}", prescriptionid, flag, transactionType);
        List<PaymentBreakupDetails> objlist = new List<PaymentBreakupDetails>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPaymentBreakupDetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
            //				objlist.Error = "006";
            //				objlist.ErrorDesc = ex.Message;
        }
        return objlist;
    }


        public static IntegrationAuthTokens GetAccessToken(string PatientId, string token)
    {
        IntegrationAuthTokens ObjToken = null;
        string uri = Utils.CLSURL + string.Format("api/Patient/GetAccessToken?PatientId={0}", PatientId);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            ObjToken = objReqRes.GetIntegrationAuthTokens_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ObjToken;
    }


    public static List<OTPIntegrationDetails> GetIntegrationDetails(string Orderid, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetIntegrationDetails?Orderid={0}", Orderid);
        List<OTPIntegrationDetails> objlist = new List<OTPIntegrationDetails>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetIntegrationDetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
            //				objlist.Error = "006";
            //				objlist.ErrorDesc = ex.Message;
        }
        return objlist;
    }
    public static IntegrationAuthTokens GetIntegrationTokenByAuthCode(IntegrationAuthTokens objintAuthToken, string token)
    {
        string xmldata = MUtils.SerializeObject(objintAuthToken, typeof(IntegrationAuthTokens));
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetIntegrationTokenByAuthCode");
        RequestResponse objReqRes = new RequestResponse();
        IntegrationAuthTokens objToken = new IntegrationAuthTokens();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.GetIntegrationAuthTokens_Serialize(objintAuthToken, token);
            string response = _utils.PostRequest(requestURI, sData);
            objToken = objReqRes.GetIntegrationAuthTokens_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objToken;
    }

    public static bool DownloadEcard(string PatientId, String FileName, string filepath)
    {
        bool ReturnResponse = false;
        string requestURI = string.Empty;
        requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadEcardDetails?PatientId={0}&PayerCode={1}", PatientId, Utils.PayerCode);
        try
        {
            WebRequest webRequest = WebRequest.Create(requestURI);
            WebResponse webResp = webRequest.GetResponse();
            string test = string.Empty;

            Stream str = webResp.GetResponseStream();
            byte[] inBuf = new byte[100000000];
            int bytesToRead = (int)inBuf.Length;
            int bytesRead = 0;
            while (bytesToRead > 0)
            {
                int n = str.Read(inBuf, bytesRead, bytesToRead);
                if (n == 0)
                    break;
                bytesRead += n;
                bytesToRead -= n;
            }
            FileStream fstr = new FileStream(filepath + FileName, FileMode.OpenOrCreate,
            FileAccess.Write);
            fstr.Write(inBuf, 0, bytesRead);
            str.Close();
            fstr.Close();
            ReturnResponse = true;


        }
        catch (Exception ex)
        {
            ReturnResponse = false;
        }
        return ReturnResponse;
    }

    public static bool DownloadEcard_V1(string PatientId, String FileName, string filepath, string memberId)
    {
        bool ReturnResponse = false;
        string requestURI = string.Empty;
        requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadEcardDetails_V1?PatientId={0}&PayerCode={1}&memberId={2}", PatientId, Utils.PayerCode, memberId);
        try
        {
            WebRequest webRequest = WebRequest.Create(requestURI);
            WebResponse webResp = webRequest.GetResponse();
            string test = string.Empty;

            Stream str = webResp.GetResponseStream();
            byte[] inBuf = new byte[100000000];
            int bytesToRead = (int)inBuf.Length;
            int bytesRead = 0;
            while (bytesToRead > 0)
            {
                int n = str.Read(inBuf, bytesRead, bytesToRead);
                if (n == 0)
                    break;
                bytesRead += n;
                bytesToRead -= n;
            }
            FileStream fstr = new FileStream(filepath + FileName, FileMode.OpenOrCreate,
            FileAccess.Write);
            fstr.Write(inBuf, 0, bytesRead);
            str.Close();
            fstr.Close();
            ReturnResponse = true;


        }
        catch (Exception ex)
        {
            ReturnResponse = false;
        }
        return ReturnResponse;
    }

    public static List<RN.MOBILE_COMMON.Reminder> GetReminderlist(string userId, string mobileNo, string token)
    {
        List<RN.MOBILE_COMMON.Reminder> objlist = new List<RN.MOBILE_COMMON.Reminder>();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetReminder_V1?PatientId={0}&mobileNo={1}&payerCode={2}&LastFetchDateTime=", userId, mobileNo, Utils.PayerCode);
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetReminder_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static List<PrescriptionClass> GetReminderPrecList(string patientId, string memberID, string transType, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetReminderPrecList?patientId={0}&memberID={1}&transType={2}", patientId, memberID, transType);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetTransactionList_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;


        }
        return objlist;
    }
    public static ReminderList GetReminderDetails(string prescId, string reminderId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetReminderDetails?prescId={0}&reminderId={1}", prescId, reminderId);
        ReminderList objlist = new ReminderList();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetReminderDetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static bool SavePatientRemindersV1(ReminderList _reminder, string token)
    {
        bool ReturnResponse = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/SavePatientRemindersV1");
        RequestResponse objReqRes = new RequestResponse();

        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.GetReminderDetails_Serialize(_reminder, token);
            string response = _utils.PostRequest(requestURI, sData);
            ReturnResponse = JsonConvert.DeserializeObject<bool>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnResponse;
    }
    public static bool DeleteReminders(string Prescription_id, string reminderId)
    {
        bool ReturnResponse = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/DeleteReminders_V1?Pre_id={0}&reminderId={1}", Prescription_id, reminderId);

        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            ReturnResponse = JsonConvert.DeserializeObject<bool>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnResponse;
    }
    public static List<NotificationClass> GetNotificationDashboard(string UserID, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetNotificationDashboard?UserID={0}&PayerCode={1}", UserID, Utils.PayerCode);
        List<NotificationClass> objlist = new List<NotificationClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetNotificationDashbroad_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<Oderdetails> GetOrderdetails(string PrescriptionId, string Orderid, int transType, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetOrderdetails?PrescriptionId={0}&Orderid={1}&transType={2}", PrescriptionId, Orderid, transType);
        List<Oderdetails> objlist = new List<Oderdetails>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetOrderdetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<OrderItemDetails> GetPrescriptionItemDetails(string PrescriptionId, string Orderid, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetOrderitemsdetails?PrescriptionId={0}&orderid={1}", PrescriptionId, Orderid);
        List<OrderItemDetails> objlist = new List<OrderItemDetails>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetOrderItemsDetails_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static ErrorClass Confirm1MGPharmacyOrder(PrescriptionClass objPClass, string token)
    {
        ErrorClass obj = new ErrorClass();
        string uri = string.Format("api/Patient/Confirm1MGPharmacyOrder");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.PrescriptionClass_Serialize(objPClass, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData, 30);
            obj = JsonConvert.DeserializeObject<ErrorClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }


    public static ErrorClass ConfirmDRLPharmacyOrder(PrescriptionClass objPClass, string token)
    {
        ErrorClass obj = new ErrorClass();
        string uri = string.Format("api/Patient/ConfirmDRLPharmacyOrder");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.PrescriptionClass_Serialize(objPClass, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData, 30);
            obj = JsonConvert.DeserializeObject<ErrorClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }

    public static ErrorClass ConfirmMedPayPharmacyOrder(PrescriptionClass objPClass, string token)
    {
        ErrorClass obj = new ErrorClass();
        string uri = string.Format("api/Patient/ConfirmMedPayPharmacyOrder");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.PrescriptionClass_Serialize(objPClass, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData, 30);
            obj = JsonConvert.DeserializeObject<ErrorClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }


    public static ErrorClass CancelDRLPharmacyOrder(PrescriptionClass objPClass, string token)
    {
        ErrorClass obj = new ErrorClass();
        string uri = string.Format("api/Patient/CancelDRLPharmacyOrder");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.PrescriptionClass_Serialize(objPClass, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData, 30);
            obj = JsonConvert.DeserializeObject<ErrorClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }


    public static ErrorClass CancelMedPayPharmacyOrder(PrescriptionClass objPClass, string token)
    {
        ErrorClass obj = new ErrorClass();
        string uri = string.Format("api/Patient/CancelMedPayPharmacyOrder");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.PrescriptionClass_Serialize(objPClass, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData, 30);
            obj = JsonConvert.DeserializeObject<ErrorClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }

    public static ErrorClass Cancel1MGPharmacyOrder(PrescriptionClass objPClass, string token)
    {
        ErrorClass obj = new ErrorClass();
        string uri = string.Format("api/Patient/Cancel1MGPharmacyOrder");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.PrescriptionClass_Serialize(objPClass, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData, 30);
            obj = JsonConvert.DeserializeObject<ErrorClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }
    public static bool DownloadCombinedDiagnosisFile(string FileName, string root, string filepath)
    {
        bool downloaded = false;
        string FileName1 = root + "_Diagnostic.pdf";
        string requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadCombinedFile?fileName=" + FileName + "&innerFolder=" + root + "");
        try
        {
            WebRequest webRequest = WebRequest.Create(requestURI);
            WebResponse webResp = webRequest.GetResponse();
            string test = string.Empty;

            Stream str = webResp.GetResponseStream();
            byte[] inBuf = new byte[100000000];
            int bytesToRead = (int)inBuf.Length;
            int bytesRead = 0;
            while (bytesToRead > 0)
            {
                int n = str.Read(inBuf, bytesRead, bytesToRead);
                if (n == 0)
                    break;
                bytesRead += n;
                bytesToRead -= n;
            }
            FileStream fstr = new FileStream(filepath + FileName1, FileMode.OpenOrCreate,
            FileAccess.Write);
            fstr.Write(inBuf, 0, bytesRead);
            str.Close();
            fstr.Close();
            downloaded = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return downloaded;
    }
    public static string GetPayerHelpLineNumber(string token)
    {
        string obj = null;
        string uri = Utils.CLSURL + string.Format("api/common/GetPayerHelpLineNumber");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(uri);
            obj = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }
    public static ProfileDetails GetProfileDetails(int userID, int transType, string entityCode, string token)
    {
        ProfileDetails result = null;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetProfileDetails?userID={0}&transType={1}&entityCode={2}", userID, transType, entityCode);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            result = objReqRes.GetProfileDetails_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }

    public static string RefundUpdateFromConsumer(string ORDER_ID, string USER_ID, int ISRECIVED, string OneMgOrderId, string token)
    {
        string result = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/RefundUpdateFromConsumer?ORDER_ID={0}&USER_ID={1}&ISRECIVED={2}&PayerCode={3}&OneMgOrderId={4}", ORDER_ID, USER_ID, ISRECIVED, Utils.PayerCode, OneMgOrderId);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            result = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }

    public static bool DownloadInvoice(string prescriptionid, int Trans_Type, string OrderNo, string FileName, string filepath)
    {
        bool ReturnResponse = false;
        string requestURI = string.Empty;
        requestURI = Utils.CLSURL + string.Format("api/Physician/DownloadInvoice?prescrptionID={0}&transactionType={1}&OrderNo={2}", prescriptionid, Trans_Type, OrderNo, filepath);
        try
        {
            WebRequest webRequest = WebRequest.Create(requestURI);
            WebResponse webResp = webRequest.GetResponse();
            if (webResp != null)
            {
                string test = string.Empty;

                Stream str = webResp.GetResponseStream();
                byte[] inBuf = new byte[100000000];
                int bytesToRead = (int)inBuf.Length;
                int bytesRead = 0;
                while (bytesToRead > 0)
                {
                    int n = str.Read(inBuf, bytesRead, bytesToRead);
                    if (n == 0)
                        break;
                    bytesRead += n;
                    bytesToRead -= n;
                }
                FileStream fstr = new FileStream(filepath + FileName, FileMode.OpenOrCreate,
                FileAccess.Write);
                fstr.Write(inBuf, 0, bytesRead);
                str.Close();
                fstr.Close();
                ReturnResponse = true;
            }
        }
        catch (WebException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnResponse;
    }

    public static MAPPInfoService GetCurrentMobileAppVersionDetails(string App_Name, string DeviceOS)
    {
        MAPPInfoService _app = new MAPPInfoService();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {

            string requestURI = Utils.CLSURL + string.Format("api/common/GetCurrentMobileAppVersionDetails?App_Name={0}&DeviceOS={1}", App_Name, DeviceOS);
            string response = _utils.HttpRequestResponse(requestURI);
            _app = objReqRes.MAPPInfoService_Response_Deserialize(JsonConvert.DeserializeObject<string>(response));

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return _app;
    }
    public static bool UpdatePatientAddress(string patientID, List<ShippingAddress> objlstAdrs, string token)
    {
        string xmldata = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UpdatePatientAddress_V1?PatientId={0}", patientID);
        bool isSuccess = false;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            Utils _utils = new Utils();
            xmldata = objReqRes.GetPatientAddress_Serialize_V1(objlstAdrs, token);
            string response = _utils.PostRequest(requestURI, xmldata);
            isSuccess = objReqRes.Boolean_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }



    public static bool UpDiagnosisShowReport(List<Diagnosis> Diagnosis)
    {
        bool ReturnResponse = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UpDiagnosisShowReport");

        try
        {
            Utils _utils = new Utils();
            string sData = JsonConvert.SerializeObject(Diagnosis);
            string response = _utils.PostRequest(requestURI, sData);
            ReturnResponse = JsonConvert.DeserializeObject<bool>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnResponse;
    }
    public static bool FlagForRescheduleAppointment(string Appointment_Id, string Integration_Appointment_Id, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/FlagForRescheduleAppointment?Appointment_Id={0}&Integration_Appointment_Id={1}", Appointment_Id, Integration_Appointment_Id);
        bool isSuccess = false;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            isSuccess = objReqRes.Boolean_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }
    public static string ChekIntigrationDoctorBookEnabled(string IntegrationDoctorId, string IntegrationCode, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/ChekIntigrationDoctorBookEnabled?IntegrationDoctorId={0}&IntegrationCode={1}", IntegrationDoctorId, IntegrationCode);
        string isSuccess = string.Empty;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            isSuccess = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }
    public static bool LogTheIntegrationRequests(IntegrationRequestLogs Obj, string token)
    {
        string IntLogXML = string.Empty;// await MUtils.PatientSerialize(patient);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/LogTheIntegrationRequests");
        bool isSuccess = false;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            Utils _utils = new Utils();
            IntLogXML = objReqRes.OP_IntegrationRequestLogs_Serialize(Obj, token);
            string response = _utils.PostRequest(requestURI, IntLogXML);
            isSuccess = objReqRes.Boolean_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public static DiagTestSearch GetDiagTestAvailableCenters_V2(OP_Consumer_Search objCon, string Presc_Id, int PageNo, int NumRec, string token, int IsAvailable = 0, string PolicyNo = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetDiagTestAvailableCentersV2?Presc_Id={0}&payerCode={1}&PageNo={2}&NumRec={3}&IsAvailable={4}&PolicyNo={5}", Presc_Id, Utils.PayerCode, PageNo, NumRec, IsAvailable, PolicyNo);
        DiagTestSearch objlist = new DiagTestSearch();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string data = objReqRes.GetPhysicianSearch_Com_request_Serialize(objCon, token);
            string response = _utils.PostRequest(requestURI, data);
            objlist = objReqRes.GetDiagTestAvailableCenters_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static HospitalSearch GetHospitalAvailableCenters(OP_Consumer_Search objCon, int PageNo, int NumRec, string token, int IsAvailable = 0)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetHospitalAvailableCenters?payerCode={0}&PageNo={1}&NumRec={2}&IsAvailable={3}", Utils.PayerCode, PageNo, NumRec, IsAvailable);
        HospitalSearch objlist = new HospitalSearch();
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        RequestResponse objReqRes1 = new RequestResponse();
        try
        {
            string data = objReqRes1.GetPhysicianSearch_Com_request_Serialize(objCon, token);
            string response = _utils.PostRequest(requestURI, data);
            objlist = objReqRes.GetHospital_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static string GetInSuranceCode(string policyNo)
    {
        string insuranceCode = string.Empty;
        string uri = Utils.CLSURL + string.Format("api/Patient/GetInSuranceCode?PolicyNo={0}&payercode={1}", policyNo, Utils.PayerCode);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            insuranceCode = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return insuranceCode;
    }
    public static int CheckMobileNumExist(string MobileNo, string PatinetId)
    {
        int IsMobileNoExist = 1;
        string uri = Utils.CLSURL + string.Format("api/Patient/CheckMobileNumExist?MobileNo={0}&PatinetId={1}&payercode={2}", MobileNo, PatinetId, Utils.PayerCode);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            IsMobileNoExist = JsonConvert.DeserializeObject<int>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return IsMobileNoExist;
    }
    //public static string SaveAppointmentV2(Appointment objAppointment)
    //{
    //    objAppointment.PayerCode = Utils.PayerCode;
    //    string xmldata = MUtils.SerializeObject(objAppointment, typeof(Appointment));
    //    string requestURI = Utils.CLSURL + string.Format("api/Patient/SaveAppointmentV2");
    //    string appointmentId = string.Empty;
    //    try
    //    {
    //        Utils _utils = new Utils();
    //        string response = _utils.PostRequest(requestURI, xmldata);
    //        appointmentId = JsonConvert.DeserializeObject<string>(response);

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return appointmentId;
    //}

    public static string SaveAppointmentV2(Appointment objAppointment)
    {
        Sast_Utils _utils = new Sast_Utils();
        string appointmentId = string.Empty;
        try
        {

            // Create XmlSerializer instance for the Appointment type
            XmlSerializer serializer = new XmlSerializer(typeof(Appointment));

            // Write Appointment object to XML string
            string xmlString;
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                {
                    // Serialize the object to XML
                    serializer.Serialize(xmlWriter, objAppointment);
                    xmlString = stringWriter.ToString();
                }
            }
            appointmentId = _utils.SaveAppointment(xmlString);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return appointmentId;
    }
    public static bool DeleteAppointmentId(string AppointmentId)
    {
      
        string requestURI = Utils.CLSURL + string.Format("api/Patient/DeleteAppointment?AppointmentId="+ AppointmentId);
        bool flag = false;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, "");
            flag = JsonConvert.DeserializeObject<bool>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return flag;
    }
    public static string CancelAppointmentV1(Appointment objApp, string token)
    {
        string obj = null;
        string uri = string.Format("api/Patient/CancelAppointmentV1");
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            List<Appointment> objClass = new List<Appointment>();
            objClass.Add(objApp);
            string sData = objReqRes.GetAppointmentDashbroad_Pat_Serialize(objClass, token);//  JsonConvert.SerializeObject(objPClass);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData);
            obj = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return obj;
    }

    public static int InsertAuditFileLog(string Ip_Address, string User_Id, string Session_Id, string Device_Id, string File_Name, int Type, RN.MOBILE_COMMON.Enumerations.DocumentType DocumentType)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Common/InsertAuditFileLog?Ip_Address={0}&User_Id={1}&Session_Id={2}&Device_Id={3}&File_Name={4}&&Type={5}&DocumentType={6}", Ip_Address, User_Id, Session_Id, Device_Id, File_Name, Type, DocumentType);
        int Audit_Id = 0;
        Utils _utils = new Utils();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            Audit_Id = JsonConvert.DeserializeObject<int>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Audit_Id;
    }

    public static string RefundUpdateFromConsumerV1(PharmacyRefundUpdate objpharref, string token)
    {
        string Response = null;
        string uri = string.Format("api/Patient/RefundUpdateFromConsumerV1");
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();

        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.PharmacyRefundUpdate_Serialize(objpharref, token);//  JsonConvert.SerializeObject(objPClass);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData);
            Response = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Response;
    }

    //public static List<Patient> GetPatients_V1(string patientId, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Physician/GetPatientDetails_V1?patientId={0}&PayerCode={1}", patientId, Utils.PayerCode);
    //    List<Patient> objlist = new List<Patient>();
    //    Utils _utils = new Utils();
    //    RequestResponse objReqRes = new RequestResponse();
    //    try
    //    {
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        objlist = objReqRes.GetPatientDetails_Phy_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //        //				objlist.Error = "006";
    //        //				objlist.ErrorDesc = ex.Message;
    //    }
    //    return objlist;
    //}
    public static List<Patient> GetPatients_V1(string patientId, string token)
    {
       
        List<Patient> objlist = new List<Patient>();
        List<FamilyMember> objlist_sast = new List<FamilyMember>();
        Sast_Utils _utils = new Sast_Utils();
        try
        {
            DataTable dt_userCredential_Details = _utils.GetPatients_SAST(Convert.ToString(patientId));
            foreach (DataRow row in dt_userCredential_Details.Rows)
            {
                FamilyMember item = new FamilyMember();
                Address add = new Address();
                item.aaa_enrollment_date = Convert.ToString(row["aaa_enrollment_date"]); 
                item.aaa_expiry_date = Convert.ToString(row["aaa_expiry_date"]);
                item.aaa_flag = Convert.ToString(row["aaa_flag"]);
                item.aaa_URN = Convert.ToString(row["aaa_URN"]);
                item.agegroup = Convert.ToString(row["agegroup"]);
                item.card_delivery_date = Convert.ToString(row["card_delivery_date"]);
                item.card_delivery_status = Convert.ToString(row["card_delivery_status"]);
                item.careOfDec = Convert.ToString(row["careOfDec"]);
                item.careOfTypeDec = Convert.ToString(row["careOfTypeDec"]);
                item.dateofbirth = Convert.ToString(row["dateofbirth"]);
                item.dependent_flag = Convert.ToString(row["dependent_flag"]);
                item.familyDocId = Convert.ToString(row["familyDocId"]);
                item.familyDocTyp = Convert.ToString(row["familyDocTyp"]);
                item.fatherName = Convert.ToString(row["fatherName"]);
                item.gender = Convert.ToString(row["gender"]);
                item.health_id = Convert.ToString(row["health_id"]);
                item.memberName = Convert.ToString(row["memberName"]);
                item.member_id = Convert.ToString(row["member_id"]);
                item.mobileNumber = Convert.ToString(row["mobileNumber"]);
                item.nhaid = Convert.ToString(row["nhaid"]);
                item.photo = Convert.ToString(row["photo"]);
                item.s_flag = Convert.ToString(row["s_flag"]);
                item.tempId = Convert.ToString(row["tempId"]);
                item.venderToken = Convert.ToString(row["venderToken"]);
                item.yearOfBirth = Convert.ToString(row["yearOfBirth"]);

                add.address = Convert.ToString(row["address"]);
                add.bendistrictlgdCode = Convert.ToString(row["bendistrictlgdCode"]);
                add.benstatelgdCode = Convert.ToString(row["benstatelgdCode"]);
                add.districtlgdCode = Convert.ToString(row["districtlgdCode"]);
                add.pinCode = Convert.ToString(row["pinCode"]);
                add.ruralUrban = Convert.ToString(row["ruralUrban"]);
                add.statelgdCode = Convert.ToString(row["statelgdCode"]);
                add.subdistrictlgdCode = Convert.ToString(row["subdistrictlgdCode"]);
                add.village_townlgdCode = Convert.ToString(row["village_townlgdCode"]);
                item.address = add;
                objlist_sast.Add(item);

                Patient objpat = new Patient();
                objpat.AadharNo = Convert.ToString(row["AadharVaultno"]);
                objpat.Address= Convert.ToString(row["address"]);
                objpat.Address1= Convert.ToString(row["stateName"]);
                objpat.Age = 0;
                //objpat.CityID = Convert.ToInt32(row["districtlgdCode"]);
                objpat.CityName = Convert.ToString(row["CITY"]);
                objpat.DOB = Convert.ToString(row["DOB"]);
                if(row["gender"].ToString() == "F")
                {
                    objpat.Gender = "FEMALE";
                }
                else
                {
                    objpat.Gender = "MALE";
                }
               
                objpat.IsActive = true;
                if (row["dependent_flag"].ToString() == "S")
                {
                    objpat.IsPrimaryMember = "1";
                }
                else
                {
                    objpat.IsPrimaryMember = "0";
                }
                objpat.MemberNo= Convert.ToString(row["member_id"]);
                objpat.MobileNo= Convert.ToString(row["mobileNumber"]);
                objpat.PatienID = Convert.ToInt32(patientId);
                objpat.PINCode= Convert.ToString(row["pinCode"]);
                objpat.PrimaryMemberID= Convert.ToInt32(patientId);
                objpat.RelationShipName= Convert.ToString(row["careOfTypeDec"]);
                objpat.UserName= Convert.ToString(row["memberName"]);
                objpat.IsActive = true;
                objpat.Status = "1";
                objlist.Add(objpat);
            }

        }
        catch (Exception ex)
        {
            throw ex;
            //				objlist.Error = "006";
            //				objlist.ErrorDesc = ex.Message;
        }
        return objlist;
    }
    //Nik_231122_start
    public static List<Patient> GetPatients_V1_WYN(string patientId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Physician/GetPatientDetails_V1_WYN?patientId={0}&PayerCode={1}", patientId, Utils.PayerCode_wyn);
        List<Patient> objlist = new List<Patient>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPatientDetails_Phy_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
            //				objlist.Error = "006";
            //				objlist.ErrorDesc = ex.Message;
        }
        return objlist;
    }
    //Nik_231122_end

    //public static List<Appointment> GetAppointmentDashboard_V1(string patientId, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Patient/GetAppointmentDashboard_V2?PatientId={0}&PayerCode={1}&LastFetchDateTime={2}", patientId, Utils.PayerCode, "");
    //    List<Appointment> objlist = new List<Appointment>();
    //    Utils _utils = new Utils();
    //    ReqRes_Consumer objReqRes = new ReqRes_Consumer();
    //    try
    //    {
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        objlist = objReqRes.GetAppDashV1_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return objlist;
    //}
    public static List<Appointment> GetAppointmentDashboard_V1(string patientId, string token)
    {
        List<Appointment> lstobj = new List<Appointment>();
        Sast_Utils _utils = new Sast_Utils();
        DataTable dt = new DataTable();
        try
        {
            dt = _utils.GetAppointmentDashboard_V1(patientId);
            if (dt != null && dt.Rows.Count > 0)
            {
                Appointment _obj = new Appointment();
                foreach (DataRow row in dt.Rows)
                {
                    _obj = new Appointment();
                    _obj.OrderByAppDate = Convert.ToDateTime(row["Appointment_Date"], new CultureInfo("en-IN"));
                    _obj.AppointmentDate = Convert.ToString(row["Appointment_Date"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(row["Appointment_ID"])))
                        _obj.AppointmentID = Convert.ToInt32(row["Appointment_ID"].ToString());
                    if (!string.IsNullOrEmpty(Convert.ToString(row["EntityCode"])))
                        _obj.EntityCode = Convert.ToString(row["EntityCode"].ToString());
                    _obj.MemberID = Convert.ToString(row["Member_ID"]);
                    _obj.PatientName = (Convert.ToString(row["memberName"]).ToUpper());
                    if (!string.IsNullOrEmpty(Convert.ToString(row["PATIENT_ID"])))
                        _obj.PatientId = Convert.ToInt32(row["PATIENT_ID"].ToString());
                    if (!string.IsNullOrEmpty(Convert.ToString(row["PHYSICIAN_ID"])))
                        _obj.PhysicianId = Convert.ToInt32(row["PHYSICIAN_ID"].ToString().ToUpper());
                    _obj.PhysicianName =(Convert.ToString(row["SPECIALIST_NAME"]).ToUpper());
                    if (!string.IsNullOrEmpty(Convert.ToString(row["SERVICE_TYPE"])))
                        _obj.ServiceType = Convert.ToInt32(row["SERVICE_TYPE"].ToString());
                    _obj.ServiceTypeDesc = Convert.ToString(row["SERVICE_TYPE"].ToString());
                    if (!string.IsNullOrEmpty(Convert.ToString(row["SLOT_ID"])))
                        _obj.SlotID = Convert.ToInt32(row["SLOT_ID"].ToString());
                    _obj.SlotTime = Convert.ToString(row["APPOINTMENT_TIME"]);
                    _obj.SpecialityDec =(Convert.ToString(row["SPECIALITYNAME"]).ToUpper());
                    if (!string.IsNullOrEmpty(Convert.ToString(row["STATUS"])))
                        _obj.Status = Convert.ToInt32(row["STATUS"].ToString());
                    if(_obj.Status==1)
                    {
                        _obj.Status_Desc = RN.MOBILE_COMMON.Enumerations.AppointmentStatus.CONFIRMED.ToString();
                    }
                    if (_obj.Status == 0)
                    {
                        _obj.Status_Desc = RN.MOBILE_COMMON.Enumerations.AppointmentStatus.UTILIZED.ToString();
                    }
                    if (_obj.Status == 2)
                    {
                        _obj.Status_Desc = RN.MOBILE_COMMON.Enumerations.AppointmentStatus.CANCELLED.ToString();
                    }
                    if (_obj.Status == 3)
                    {
                        _obj.Status_Desc = RN.MOBILE_COMMON.Enumerations.AppointmentStatus.EXPIRED.ToString();
                    }
                    if (_obj.Status == 4)
                    {
                        _obj.Status_Desc = RN.MOBILE_COMMON.Enumerations.AppointmentStatus.PENDING.ToString();
                    }
                    //_obj.Status_Desc = (Convert.ToString(row["STATUS"]).ToLower());
                  
                    _obj.EntityName = Convert.ToString(row["HOSPNAME"]);
                    _obj.PatientMobileNo = Convert.ToString(row["Mobile_No"]);
                    _obj.PatientEmailID = string.Empty;//Convert.ToString(row["EMAIL_ID"]);
                    _obj.EntityMobileNo = Convert.ToString(row["PHONE1"]);
                    _obj.Vist_Type = Convert.ToString(row["visit_type"]);
                    lstobj.Add(_obj);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return lstobj;
    }
    //Nik_251122_start
    public static List<Appointment> GetAppointmentDashboard_V1_WYN(string patientId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetAppointmentDashboard_V2_WYN?PatientId={0}&PayerCode={1}&LastFetchDateTime={2}", patientId, Utils.PayerCode_wyn, "");
        List<Appointment> objlist = new List<Appointment>();
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetAppDashV1_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    //Nik_251122_end
    public static string GetReloadVideoLink(string appId)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetReloadVideoLink?appid={0}", appId);
        Utils _utils = new Utils();
        string response = string.Empty;
        try
        {
             response = _utils.HttpRequestResponse(requestURI);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }




    public static List<PrescriptionClass> GetPatientVitalDashboard_V2(string patientid, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPatientVitalDashboard_V2?PatientId={0}&PayerCode={1}", patientid, Utils.PayerCode);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPatientVitalDashboard_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    public static string GetOnemgPhyUrl(OnemgTokenClassRequest objtokendet, string AppointmentID, string token)
    {
        string Response = null;
        if (string.IsNullOrEmpty(AppointmentID))
            AppointmentID = "0";
        string uri = string.Format("api/Patient/GetOnemgPhyUrl_V1?AppointmentID={0}", AppointmentID);
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.GetOnemgURLToken_Serialize(objtokendet, token);
            string response = _utils.PostRequest(Utils.CLSURL + uri, sData);
            Response = objReqRes.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Response;
    }
    public static List<Lookup> GetOPLookUpValues(int lookupType)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Common/GetOPLookUpValues?lookupType={0}", lookupType);
        List<Lookup> objlist = new List<Lookup>();
        Utils _utils = new Utils();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = JsonConvert.DeserializeObject<List<Lookup>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    //public static List<PrescriptionClass> GetPrescriptionList_v1(string PatientID, string transType, int isHC, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPrescriptionList_V1?PatientID={0}&TransactionType={1}&payerCode={2}", PatientID, transType, Utils.PayerCode);
    //    List<PrescriptionClass> objlist = new List<PrescriptionClass>();
    //    Utils _utils = new Utils();
    //    RequestResponse objReqRes = new RequestResponse();
    //    try
    //    {
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        objlist = objReqRes.GetPrescriptionList_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return objlist;
    //}

    public static List<PrescriptionClass> GetPrescriptionList_v1(string PatientID, string transType, int isHC, string token)
    {
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        Sast_Utils sast_Utils = new Sast_Utils();
        DataTable dt = new DataTable();
        try
        {
            objlist = sast_Utils.GetPrescriptionList_v1(PatientID, transType);
            //objlist = 
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    //Nik 281122 -start
    public static List<PrescriptionClass> GetPrescriptionList_v1_WYN(string PatientID, string transType, int isHC, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPrescriptionList_V1_WYN?PatientID={0}&TransactionType={1}&payerCode={2}", PatientID, transType, Utils.PayerCode_wyn);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPrescriptionList_Pat_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    //Nik 281122 -end

    public static List<HealthCheckup> GetProductPolicyHealthCheckup_V1(string PatientId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Diagnostic/GetProductPolicyHealthCheckup_V1?PatientId={0}&payerCode={1}", PatientId, Utils.PayerCode);
        List<HealthCheckup> objlist = new List<HealthCheckup>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetProductPolicyHealthCheckup_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<ReimbursementClass> GetReimbursementData(string patientId, int pageNo, int RecCount, string LastFeatchTime, string token, int DraftOnly)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetReimbursementData?patientId={0}&PageNo={1}&NumRec={2}&LastFeatchTime={3}&DraftOnly={4}", patientId, pageNo, RecCount, LastFeatchTime, DraftOnly);
        List<ReimbursementClass> objlist = new List<ReimbursementClass>();
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetReimbursementData_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static Reimbursement Submit_Reimbursement(Reimbursement objReimbursement, string token)
    {
        //objAppointment.PayerCode = Utils.PayerCode;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        string sData = objReqRes.Reimbursement_Serialize(objReimbursement, token);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/Submit_Reimbursement");
        string remId = string.Empty;
        Reimbursement objReimbursementResponse = new Reimbursement();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, sData, 30);
            objReimbursementResponse = objReqRes.Reimbursement_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objReimbursementResponse;
    }

    public static bool UploadReimburseAttachmentFile(string PrescriptionId, int PATIENT_ID, string ATTACH_REMARKS, List<string> ATTACH_FILENAMES, string FilePath)
    {
        bool IsSuccess = false;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UploadReimburseAttachmentFile?CLAIM_ID={0}&PATIENT_ID={1}", PrescriptionId, PATIENT_ID);
        try
        {
            if (UploadMultipleFileWithFilePath(requestURI, ATTACH_FILENAMES, FilePath))
            {
                IsSuccess = true;
            }
        }
        catch (Exception ex)
        {
            IsSuccess = false;
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
        return IsSuccess;
    }

    public static List<Reimbursement> getReimbursementDetails(string RemID, string token)
    {
        List<Reimbursement> objlist = new List<Reimbursement>();
        string uri = Utils.CLSURL + string.Format("api/Patient/getReimbursementDetails?RemID={0}", RemID);
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetReimbursementList_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static Reimbursement Cancel_Reimbursement(Reimbursement objReimbursement, string token)
    {
        //objAppointment.PayerCode = Utils.PayerCode;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        string sData = objReqRes.Reimbursement_Serialize(objReimbursement, token);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/Cancel_Reimbursement");
        string remId = string.Empty;
        Reimbursement objReimbursementResponse = new Reimbursement();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, sData, 30);
            objReimbursementResponse = objReqRes.Reimbursement_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objReimbursementResponse;
    }

    public static bool DownloadRemAttachmentFile(string Patient_id, string FileName, string filepath)
    {
        bool ReturnResponse = false;
        string requestURI = string.Empty;
        requestURI = Utils.CLSURL + string.Format("api/Patient/DownloadRemAttachmentFile?PATIENT_ID={0}&ATTACH_FILENAME={1}", Patient_id, FileName);
        try
        {
            WebRequest webRequest = WebRequest.Create(requestURI);
            WebResponse webResp = webRequest.GetResponse();
            if (webResp != null)
            {
                string test = string.Empty;

                Stream str = webResp.GetResponseStream();
                byte[] inBuf = new byte[100000000];
                int bytesToRead = (int)inBuf.Length;
                int bytesRead = 0;
                while (bytesToRead > 0)
                {
                    int n = str.Read(inBuf, bytesRead, bytesToRead);
                    if (n == 0)
                        break;
                    bytesRead += n;
                    bytesToRead -= n;
                }
                FileStream fstr = new FileStream(filepath + FileName, FileMode.OpenOrCreate,
                FileAccess.Write);
                fstr.Write(inBuf, 0, bytesRead);
                str.Close();
                fstr.Close();
                ReturnResponse = true;
            }
        }
        catch (WebException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnResponse;
    }

    public static string SaveOfflinePrescription(PrescriptionUpload objAppointment)
    {
        objAppointment.PayerCode = Utils.PayerCode;
        string data = JsonConvert.SerializeObject(objAppointment);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UploadPrescription_NEW");
        string PrescriptionId = string.Empty;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, data);
            PrescriptionId = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return PrescriptionId;
    }

    public static List<PrescriptionClass> GetTransactionList_OffPrescription(string patientId, string transType, int isHC, string token, int OfflinePrescription)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetTransactionList_1mgPrescription?patientId={0}&transType={1}&isHC={2}&OfflinePrescription={3}", patientId, transType, isHC, OfflinePrescription);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetTransactionList_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    //Nik 051222 -start
    public static List<PrescriptionClass> GetTransactionList_OffPrescription_WYN(string patientId, string transType, int isHC, string token, int OfflinePrescription)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetTransactionList_1mgPrescription_WYN?patientId={0}&transType={1}&isHC={2}&OfflinePrescription={3}", patientId, transType, isHC, OfflinePrescription);
        List<PrescriptionClass> objlist = new List<PrescriptionClass>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetTransactionList_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }
    //Nik 051222 -end

    public static PrescriptionClass GetPrescriptionDetail_OffPrescription(string patientID, string PrescriptionId, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetPrescriptionDetail_1mgPrescription?PatientId={0}&PrescriptionId={1}", patientID, PrescriptionId);
        PrescriptionClass objlist = new PrescriptionClass();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();

        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPrescriptionDetail_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static string CHECK_PHARMACY_RESPONSE(string TransactionType, string presId)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/CHECK_PHARMACY_RESPONSE?TransactionType={0}&PrescriptionId={1}", TransactionType, presId);
        string Response_count = string.Empty;
        Utils _utils = new Utils();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            Response_count = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Response_count;
    }

    public static List<Entity> GetEntityList(string Name, int CityID, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetEntityList?prefixText={0}&CityID={1}&token={2}", Name.ToUpper(), CityID, token);

        List<Entity> entityList = null;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            entityList = objReqRes.GetEntityList_Search_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return entityList;
    }

    public static string UploadTeleConsultFile(PrescriptionUpload objAppointment, string Prescription_id)
    {
        objAppointment.PayerCode = Utils.PayerCode;
        string data = JsonConvert.SerializeObject(objAppointment);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UploadTeleConsultFile?Prescription_id={0}", Prescription_id);
        string UpoladResponse = string.Empty;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, data);
            UpoladResponse = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return UpoladResponse;
    }

    public static void SendDetailsToFalck(FalckSendDetails _FalckSendDetails, int PatienID, string IsPrimaryMember, int SpecialityID)
    {
        string jsondata = JsonConvert.SerializeObject(_FalckSendDetails);
        string requestURI = Utils.CLSURL + string.Format("api/Patient/FalckSendDetails?PatienID={0}&IsPrimaryMember={1}&SpecialityID={2}", PatienID, IsPrimaryMember, SpecialityID);
        string result = string.Empty;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, jsondata);
            result = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static string GetClaimsConfigValue(string itemKey)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Common/GetClaimsConfigValue?itemKey={0}", itemKey);
        string result = string.Empty;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            result = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }

    public Search GetSearchData(string searchData, int searchType)
    {
        string searchServiceUrl = string.Format(Utils.RN_CLSURL + "api/search/GetSearchData?searchdataxml={0}&searchType={1}", searchData, searchType);
        Search Searchdet = null;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(searchServiceUrl);
            Searchdet = JsonConvert.DeserializeObject<Search>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Searchdet;
    }

    public PreauthData GetPreauthData(string refno, string hid, string hospcode, int isDraft)
    {
        PreauthData padata = new PreauthData();
        string uri = string.Format("api/PreAuthData/GetPreauthData_v2?refno={0}&hid={1}&hospCode={2}&isDraft={3}&IMEI={4}&AppName={5}", refno, hid, hospcode, isDraft, string.Empty, "HospConsumer");
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(Utils.RN_CLSURL + uri);
            padata = JsonConvert.DeserializeObject<PreauthData>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return padata;
    }

    public PreauthClasses GetPayerData(string hospCode, string payerCode)
    {
        string uri = string.Format("api/PreAuthData/GetPreauthStaticData?hospCode={0}&payerCode={1}", hospCode, payerCode);
        PreauthClasses objpaclass = null;
        Utils _utils = new Utils();
        try
        {
            var response = _utils.HttpRequestResponse(Utils.RN_CLSURL + uri);
            objpaclass = JsonConvert.DeserializeObject<PreauthClasses>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objpaclass;
    }
    //public static MenuItemList GenerateMenuListConsumer(string CorporateCode, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Common/GenerateMenuListConsumer?CorporateCode={0}", CorporateCode);
    //    MenuItemList obj = new MenuItemList();
    //    Utils _utils = new Utils();
    //    ReqRes_Consumer objReqRes = new ReqRes_Consumer();
    //    try
    //    {
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        obj = objReqRes.Consumer_Menu_DeSerialize(JsonConvert.DeserializeObject<string>(response), token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return obj;
    //}

    public static MenuItemList GenerateMenuListConsumer(string CorporateCode, string token)
    {
        Sast_Utils _utils = new Sast_Utils();
        DataTable dt = new DataTable();
        List<MenuItemData> lstParentMenuItemData = new List<MenuItemData>();
        List<MenuItemData> lstChildMenuItemData = new List<MenuItemData>();
        MenuItemList menuItemList = new MenuItemList();
        try
        {
            dt = _utils.GenerateMenuListConsumer("0");
            DataTable dtMenu = dt;
            if (dtMenu.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMenu.Rows)
                {
                    string parent = Convert.ToString(dr["parent_MENU"]);
                    string menu_id = Convert.ToString(dr["MENU_ID"]);
                    if (parent == "1")
                    {
                        //  parentMenuList[0] = menu_id;
                        DataRow[] drParent = dtMenu.Select("parent_menu_id=" + menu_id + "");

                        MenuItemData menuItemData = new MenuItemData();
                        menuItemData.Action = Convert.ToString(dr["WEB_URL"]);
                        menuItemData.HasSubMenu = Convert.ToString(dr["parent_MENU"]) == "1" ? true : false;
                        menuItemData.Icon = Convert.ToString(dr["TITLE"]);
                        menuItemData.ID = Convert.ToInt32(dr["MENU_ID"]);
                        menuItemData.ParentMenuId = Convert.ToInt32(dr["parent_MENU_id"]);
                        menuItemData.Title = Convert.ToString(dr["TITLE"]);
                        menuItemData.NewTab = Convert.ToInt32(dr["NEW_TAB"]);
                        menuItemData.Action = Convert.ToString(dr["web_url"]);
                        menuItemData.Value_Enum = Convert.ToString(dr["VALUE_ENUM"]);
                        lstChildMenuItemData.Add(menuItemData);
                        foreach (DataRow drChild in drParent)
                        {
                            MenuItemData menuItem = new MenuItemData();
                            menuItem.Action = Convert.ToString(drChild["WEB_URL"]);
                            menuItem.HasSubMenu = Convert.ToString(drChild["parent_MENU"]) == "1" ? true : false;
                            menuItem.Icon = Convert.ToString(drChild["TITLE"]);
                            menuItem.ID = Convert.ToInt32(drChild["MENU_ID"]);
                            menuItem.ParentMenuId = Convert.ToInt32(drChild["parent_MENU_id"]);
                            menuItem.Title = Convert.ToString(drChild["TITLE"]);
                            menuItem.NewTab = Convert.ToInt32(drChild["NEW_TAB"]);
                            menuItem.Action = Convert.ToString(drChild["web_url"]);
                            menuItem.Value_Enum = Convert.ToString(dr["VALUE_ENUM"]);
                            lstChildMenuItemData.Add(menuItem);
                        }
                    }
                    else
                    {
                        MenuItemData menuItemData = new MenuItemData();
                        menuItemData.Action = Convert.ToString(dr["WEB_URL"]);
                        menuItemData.HasSubMenu = Convert.ToString(dr["parent_MENU"]) == "1" ? true : false;
                        menuItemData.Icon = Convert.ToString(dr["TITLE"]);
                        menuItemData.ID = Convert.ToInt32(dr["MENU_ID"]);
                        menuItemData.ParentMenuId = Convert.ToInt32(dr["parent_MENU_id"]);
                        menuItemData.Title = Convert.ToString(dr["TITLE"]);
                        menuItemData.NewTab = Convert.ToInt32(dr["NEW_TAB"]);
                        menuItemData.Action = Convert.ToString(dr["web_url"]);
                        menuItemData.Value_Enum = Convert.ToString(dr["VALUE_ENUM"]);
                        lstParentMenuItemData.Add(menuItemData);
                    }
                }
                menuItemList.ParentMenu = lstParentMenuItemData;
                menuItemList.ChildMenu = lstChildMenuItemData;


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return menuItemList;
    }

    public static string GetEntityLogo(string brokerCode, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Login/GetEntityLogo?brokerCode={0}", brokerCode);
        MenuItemList obj = new MenuItemList();
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        string response = string.Empty;
        try
        {
            response = _utils.HttpRequestResponse(requestURI);
            //  obj = objReqRes.Consumer_Menu_DeSerialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

    public PreauthErrorList SubmitPreauth(PreauthData objpreauth, int isDraft)
    {
        PreauthErrorList _preData = null;
        try
        {
            //var client = new HttpClient ();

            string ServiceUrl = string.Format(Utils.RN_CLSURL + "api/PreAuthData/CreateDraft");
            string sData = Newtonsoft.Json.JsonConvert.SerializeObject(objpreauth);
            //var content = new StringContent (sData);
            //var response = client.PostAsync (ServiceUrl, content).Result;
            //				if (response.IsSuccessStatusCode) {
            //					var placesJson = response.Content.ReadAsStringAsync ().Result; 
            //					DataContractJsonSerializer ser = new DataContractJsonSerializer (typeof(MCN.PreauthErrorList));
            //					MemoryStream stream = new MemoryStream (Encoding.UTF8.GetBytes (placesJson));
            //					_preData = (MCN.PreauthErrorList)ser.ReadObject (stream);
            //
            //				}
            Utils objUtil = new Utils();
            var response = objUtil.PostRequest(ServiceUrl, sData);
            _preData = JsonConvert.DeserializeObject<PreauthErrorList>(response);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _preData;

    }

    public List<ConsultantDetails> SearchConsultant(string Provider_code, string SearchKey)
    {
        string uri = string.Format("api/PreAuthData/GetConsultantList?provider_code={0}&SearchKey={1}", Provider_code, SearchKey);

        List<ConsultantDetails> objConsultant = new List<ConsultantDetails>();

        try
        {
            //				using (var client = new HttpClient ()) {
            //					var response = client.GetAsync (Constants.BaseURI + uri).Result;
            //
            //					if (response.IsSuccessStatusCode) {
            //						objConsultant = await response.Content.ReadAsAsync<List<ConsultantDetails>> ();
            //					}
            //				}
            Utils objUtil = new Utils();
            var response = objUtil.HttpRequestResponse(Utils.RN_CLSURL + uri);
            objConsultant = JsonConvert.DeserializeObject<List<ConsultantDetails>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objConsultant;
    }

    public void SendNotification(string RefNo)
    {
        string uri = string.Format("api/login/SendDraftNotification?RefNo={0}", RefNo);
        try
        {
            Utils objUtil = new Utils();
            objUtil.HttpRequestResponse(Utils.RN_CLSURL + uri);
        }
        catch (Exception ex)
        {

        }
    }

    public static string GetAvailable_Rem_Count(string MemberID, string PolicyNo)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetAvailable_Rem_Count?MemberId={0}&PolicyNo={1}", MemberID, PolicyNo);
        string result = string.Empty;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            result = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }
    public static List<RN.MOBILE_COMMON.RN_INTEGRATION.HII_Result_Details> GetEntityList_RN(string tpaCode, string searchText)
    {
        List<RN.MOBILE_COMMON.RN_INTEGRATION.HII_Result_Details> lstHospObj = null;
        string insuranceCode = string.Empty;
        string uri = Utils.RN_CLSURL + string.Format("api/PreAuthData/GetHospitalList_RN?tpaCode={0}&search={1}", tpaCode, searchText);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            lstHospObj = new List<RN.MOBILE_COMMON.RN_INTEGRATION.HII_Result_Details>();
            lstHospObj = JsonConvert.DeserializeObject<List<RN.MOBILE_COMMON.RN_INTEGRATION.HII_Result_Details>>(JsonConvert.DeserializeObject<string>(response));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return lstHospObj;
    }
    public static List<string> GetAffliatedHospital(string tpacode)
    {
        List<string> padata = new List<string>();
        string uri = string.Format("api/PreAuthData/GetAffliatedHospital?tpacode={0}", tpacode);
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(Utils.RN_CLSURL + uri);
            padata = JsonConvert.DeserializeObject<List<string>>(JsonConvert.DeserializeObject<string>(response));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return padata;
    }

    public static RN.MOBILE_COMMON.TeleConsultUtilization GetTeleConsultCount(string MemberNo, string token)
    {
        RN.MOBILE_COMMON.TeleConsultUtilization objlist = new RN.MOBILE_COMMON.TeleConsultUtilization();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetTeleConsultCount?MemberNo={0}", MemberNo);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            objlist = objReqRes.GetTeleConsultCount_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static List<AppointmentSlotList> GetAppointmentTimeSlot_DrReddy(string bookingType,string branchId, string docId, string Appdate)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/get-doctor-slot");
        List<AppointmentSlotList> objlist = new List<AppointmentSlotList>();
        Utils _utils = new Utils();
        try
        {
            DR_DocSlotRequest req = new DR_DocSlotRequest();
            req.bookingType = bookingType;
            req.branchId = branchId;
            req.docId = docId;
            req.from_date = Appdate;
            req.to_date = Appdate;

            string reqJson = JsonConvert.SerializeObject(req);
            string response = _utils.PostRequest(requestURI, reqJson);
            objlist = JsonConvert.DeserializeObject<List<AppointmentSlotList>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    

    public static string PushAppointmentToDR(string requestJsonData, string appType)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/PushAppointmentToDR?appType=" + appType);
        string response = string.Empty;
        Utils _utils = new Utils();
        try
        {
            response = _utils.PostRequestV1(requestURI, requestJsonData);
            //objlist = JsonConvert.DeserializeObject<Root_DRLResponse>(response.Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\""));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }
    public static string PushAppointmentToMedpay(string requestJsonData)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/medpay/PushAppointmentToMedpay");
        string response = string.Empty;
        Utils _utils = new Utils();
        try
        {
            response = _utils.PostRequestV1(requestURI, requestJsonData);
            //objlist = JsonConvert.DeserializeObject<Root_DRLResponse>(response.Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\""));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }
    public static string PushCancelAppointmentToMedpay(string requestJsonData)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/medpay/PushCancelAppointmentToMedpay");
        string response = string.Empty;
        Utils _utils = new Utils();
        try
        {
            response = _utils.PostRequestV1(requestURI, requestJsonData);
            //objlist = JsonConvert.DeserializeObject<Root_DRLResponse>(response.Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\""));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

    public static string PushAppointmentDiagToDR(string requestJsonData, string appType)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/PushAppointmentDiagToDR?appType=" + appType);
        string response = string.Empty;
        Utils _utils = new Utils();
        try
        {
            response = _utils.PostRequestV1(requestURI, requestJsonData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }
    public static bool UpdateIntegrationAppointmentID(Appointment Obj)
    {
        string IntLogXML = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UpdateIntegrationAppointmentID");
        bool isSuccess = false;
        string result = string.Empty;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            Utils _utils = new Utils();
            IntLogXML = JsonConvert.SerializeObject(Obj);
            string response = _utils.PostRequest(requestURI, IntLogXML);
            result = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public static bool OP_BLOCK_BSI_INT(BSI_DEDUCTION_INT Obj)
    {
        string IntLogXML = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Common/OP_BLOCK_BSI_INT");
        bool isSuccess = false;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            Utils _utils = new Utils();
            IntLogXML = JsonConvert.SerializeObject(Obj);
            string response = _utils.PostRequest(requestURI, IntLogXML);

            if (!string.IsNullOrEmpty(response) && response.ToUpper() == "TRUE")
                isSuccess = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }
    public static bool OP_UNBLOCK_BSI_INT(BSI_DEDUCTION_INT Obj)
    {
        string IntLogXML = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Common/OP_UNBLOCK_BSI_INT");
        bool isSuccess = false;
        try
        {
            Utils _utils = new Utils();
            IntLogXML = JsonConvert.SerializeObject(Obj);
            string response = _utils.PostRequest(requestURI, IntLogXML);

            if (!string.IsNullOrEmpty(response) && response.ToUpper() == "TRUE")
                isSuccess = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }
    public static bool OP_UPDATE_BLOCK_BSI_INT(BSI_DEDUCTION_INT Obj)
    {
        string IntLogXML = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Common/OP_UPDATE_BLOCK_BSI_INT");
        bool isSuccess = false;
        try
        {
            Utils _utils = new Utils();
            IntLogXML = JsonConvert.SerializeObject(Obj);
            string response = _utils.PostRequest(requestURI, IntLogXML);

            if (!string.IsNullOrEmpty(response) && response.ToUpper() == "TRUE")
                isSuccess = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }
    public static string INSERT_INTEGRATION_REQ_RES_DATA(INTEGRATION_REQ_RES_DATA Obj)
    {
        string IntLogXML = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Common/INSERT_INTEGRATION_REQ_RES_DATA");
        string response = string.Empty;
        try
        {
            Utils _utils = new Utils();
            IntLogXML = JsonConvert.SerializeObject(Obj);
            response = _utils.PostRequest(requestURI, IntLogXML);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

    public static string InsertUpdatePaymentLink(DR_PAYMENT_LINK requestJsonData)
    {
        string requestURI = Utils.CLSURL + string.Format("api/common/InsertUpdatePaymentLink");
        string response = string.Empty;
        Utils _utils = new Utils();
        string IntLogXML = string.Empty;
        try
        {
            IntLogXML = JsonConvert.SerializeObject(requestJsonData);
            response = _utils.PostRequest(requestURI, IntLogXML);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }
    public static ErrorClass CheckMedicineAvailability(string data)
    {
        ErrorClass objerror = new ErrorClass();
        string prescriptionXML = string.Empty;// await MUtils.PrescSerialize(prescription);
        DR_Response drResp = new DR_Response();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/CheckMedicineAvailability");
            Utils _utils = new Utils();
            string response = _utils.PostRequest(requestURI, data, 30);
            if (!string.IsNullOrEmpty(response))
            {
                drResp = JsonConvert.DeserializeObject<DR_Response>(response);
                if (drResp.Status == 0)
                {
                    objerror.Errormessage = "Some of the medicine not available";
                }
                else objerror.Errormessage = "";

            }
            else
            {
                objerror.Errormessage = "";
            }
        }
        catch (Exception ex)
        {
            objerror.Errormessage = Resources.AlertMessage.Drug_Order_Place_Failed;

        }
        return objerror;
    }

    public static List<ShippingAddress> GetShippingAddress_V2(string patientId)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Patient/GetShippingAddress_V2?patientId={0}", patientId);
        List<ShippingAddress> objlist = new List<ShippingAddress>();
        Utils _utils = new Utils();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = JsonConvert.DeserializeObject<List<ShippingAddress>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static bool UpdatePatientLatLong(ShippingAddress shippingAddress)
    {
        string IntLogXML = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/Patient/UpdatePatientLatLong");
        bool isSuccess = false;
        try
        {
            Utils _utils = new Utils();
            IntLogXML = JsonConvert.SerializeObject(shippingAddress);
            string response = _utils.PostRequest(requestURI, IntLogXML);

            if (!string.IsNullOrEmpty(response) && response.ToUpper() == "TRUE")
                isSuccess = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public static List<AppointmentSlotList> GetTimeSlotDiagnostic_DrReddy(DR_Diagnostic_Slot_Req dR_Diagnostic_Slot_Req)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/get-Diagnostic-slot");
        List<AppointmentSlotList> objlist = new List<AppointmentSlotList>();
        Utils _utils = new Utils();
        try
        {
            string reqJson = JsonConvert.SerializeObject(dR_Diagnostic_Slot_Req);
            string response = _utils.PostRequest(requestURI, reqJson);
            objlist = JsonConvert.DeserializeObject<List<AppointmentSlotList>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static string GetIntegrationDiagnosisCode(string rnDiagnosisCode, string integrationID)
    {
        string requestURI = Utils.CLSURL + string.Format("api/patient/GetIntegrationDiagnosisCode?integrationid=" + integrationID);
        string response = "";
        Utils _utils = new Utils();
        try
        {
            //string reqJson = JsonConvert.SerializeObject(dR_Diagnostic_Slot_Req);
            response = _utils.PostRequest(requestURI, rnDiagnosisCode);
            //objlist = JsonConvert.DeserializeObject<List<AppointmentSlotList>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }

    public static Root_User_Res_drl RegisterUserToDrl(string patientId, string patientRNAddressId, string appointmentid)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/RegisterUserToDrl?patientid={0}&patientaddressid={1}&appointmentid={2}", patientId, patientRNAddressId, appointmentid);
        string response = "";
        Utils _utils = new Utils();
        Root_User_Res_drl res = new Root_User_Res_drl();
        try
        {
            //string reqJson = JsonConvert.SerializeObject(dR_Diagnostic_Slot_Req);
            response = _utils.PostRequest(requestURI, "");
            res = JsonConvert.DeserializeObject<Root_User_Res_drl>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return res;
    }

    public static DRL_Address_Res_main RegisterAddressToDrl(string patientid, string patientaddressid, string custmrnid, string appointmentid)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/RegisterAddressToDrl?patientid={0}&patientaddressid={1}&custmrnid={2}&appointmentid={3}", patientid, patientaddressid, custmrnid, appointmentid);
        string response = "";
        Utils _utils = new Utils();
        DRL_Address_Res_main objres = new DRL_Address_Res_main();
        try
        {
            //string reqJson = JsonConvert.SerializeObject(dR_Diagnostic_Slot_Req);
            response = _utils.PostRequest(requestURI, "");
            objres = JsonConvert.DeserializeObject<DRL_Address_Res_main>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objres;
    }

    public static DRL_DiagOrder_response CreateDiagnosticOrderToDRL(DiagOrderRequest rnDiagnosisCode)
    {
        string requestURI = Utils.INT_CLURL + string.Format("api/drreddy/CreateDiagnosticOrder");
        string response = "";
        Utils _utils = new Utils();
        DRL_DiagOrder_response dRL_DiagOrder_Response = new DRL_DiagOrder_response();
        try
        {
            string reqJson = JsonConvert.SerializeObject(rnDiagnosisCode);
            response = _utils.PostRequest(requestURI, reqJson);
            dRL_DiagOrder_Response = JsonConvert.DeserializeObject<DRL_DiagOrder_response>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dRL_DiagOrder_Response;
    }

    public static IntegrationDiagOrderData_Response GetIntegrationDiagnosisOrderRelatedData(IntegrationDiagOrderData_Request integrationDiagOrderData_Request, string integrationid)
    {
        string requestURI = Utils.CLSURL + string.Format("api/patient/GetIntegrationDiagnosisOrderRelatedData?integrationid=" + integrationid);
        string response = "";
        Utils _utils = new Utils();
        IntegrationDiagOrderData_Response integrationDiagOrderData_Response = new IntegrationDiagOrderData_Response();
        try
        {
            string reqJson = JsonConvert.SerializeObject(integrationDiagOrderData_Request);
            response = _utils.PostRequest(requestURI, reqJson);
            integrationDiagOrderData_Response = JsonConvert.DeserializeObject<IntegrationDiagOrderData_Response>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return integrationDiagOrderData_Response;
    }

    public static string UpdateDiagnosticOrderInegrationDet(DataToUpdateForDiagOrder integrationDiagOrderData_Request)
    {
        string requestURI = Utils.CLSURL + string.Format("api/patient/UpdateDiagnosticOrderInegrationDet");
        string response = "";
        Utils _utils = new Utils();
        try
        {
            string reqJson = JsonConvert.SerializeObject(integrationDiagOrderData_Request);
            response = _utils.PostRequest(requestURI, reqJson);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }
    public static string GetUnMapped_IL_DiagnosisCode(string rnDiagnosisCode, string integrationID)
    {
        string requestURI = Utils.CLSURL + string.Format("api/patient/GetUnMapped_IL_DiagnosisCode?integrationid=" + integrationID);
        string response = "";
        Utils _utils = new Utils();
        try
        {
            //string reqJson = JsonConvert.SerializeObject(dR_Diagnostic_Slot_Req);
            response = _utils.PostRequest(requestURI, rnDiagnosisCode);
            //objlist = JsonConvert.DeserializeObject<List<AppointmentSlotList>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }



    public static bool SaveOtpInInt(string RequestId,string MemberId,string OTP)
    {
        string requestURI = Utils.CLSURL + string.Format("api/patient/Save_Update_Integration_request?RequestId=" + RequestId+ "&MemberId="+ MemberId+ "&OTP="+ OTP);
        Utils _utils = new Utils();
        bool strIntAppDet = false;

        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            if (response != "0")
            {
                strIntAppDet = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return strIntAppDet;
    }
    public static void TriggerOtp(string Otp, string entityCode, string patPayable, string eleAmt, string mobileno, string patientId)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Notification/SendPractoClaimApprovalOTP?OTP={0}&EntityCode={1}&PatientPay={2}&PayerPay={3}&MobileNo={4}&NotifyType={5}&PATIENT_ID={6}", Otp, entityCode, patPayable, eleAmt, mobileno.Replace("+91", ""), (int)RN.MOBILE_COMMON.Enumerations.OP_NOTIFY_TYPE.SMSandEMAIL, patientId);
        Utils _utils = new Utils();
        try
        {
            string otpresponse = _utils.HttpRequestResponse(requestURI);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void TriggerOtpDRL(string Otp, string entityCode, string patPayable, string eleAmt, string mobileno,string AppointmentId, string patientId)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Notification/SendDRLClaimApprovalOTP?OTP={0}&EntityCode={1}&PatientPay={2}&PayerPay={3}&MobileNo={4}&Appointment_Id={5}&NotifyType={6}&PATIENT_ID={7}", Otp, entityCode, patPayable, eleAmt, mobileno.Replace("+91", ""),AppointmentId, (int)RN.MOBILE_COMMON.Enumerations.OP_NOTIFY_TYPE.SMSandEMAIL, patientId);
        Utils _utils = new Utils();
        try
        {
            string otpresponse = _utils.HttpRequestResponse(requestURI);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void TriggerOtpDRLServiceType2(string Otp, string entityCode, string patPayable, string eleAmt, string mobileno, string AppointmentId, string patientId,string entityname,string VISITORIP)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Notification/SendTransOTP_V2?Patient_Id={0}&OTP={1}&payer_payable={2}&patient_payable={3}&Clinic_Name={4}&VisitorIp={5}&DeviceId={6}&triggerdUserId={7}&TransactionType={8}&AppointmentId={9}", patientId, Otp, eleAmt, patPayable, entityname, VISITORIP, "", "3", (int)RN.MOBILE_COMMON.Enumerations.TRANSACTION_TYPE.DIAGNOSTIC, AppointmentId);
        Utils _utils = new Utils();
        try
        {
            string response1 = _utils.PostRequest(requestURI, "");
            JsonConvert.DeserializeObject<string>(response1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void TriggerOtpDRL_pharmacy(string Otp,string patientid)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Notification/SendTransactionOTP?OTP={0}&PatientID={1}&NotifyType={2}&SendMobileNoti={3}", Otp, patientid,(int)RN.MOBILE_COMMON.Enumerations.OP_NOTIFY_TYPE.SMSandEMAIL, "0");
        Utils _utils = new Utils();
        try
        {
            string response1 = _utils.PostRequest(requestURI, "");
            JsonConvert.DeserializeObject<string>(response1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}