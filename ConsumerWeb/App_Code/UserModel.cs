using Newtonsoft.Json;
using RN.MOBILE_COMMON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

/// <summary>
/// Summary description for UserModel
/// </summary>
public class UserModel
{


    public UserModel()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //public static bool ValidateOTP(int userID, string OTP, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Patient/ValidateOTPV1");
    //    bool isSuccess = false;
    //    ReqRes_Consumer objReqRes = new ReqRes_Consumer();
    //    try
    //    {
    //        string PostData = objReqRes.ValidateOTP_Request_serialize(userID, OTP, token);
    //        Utils _utils = new Utils();
    //        var response = _utils.PostRequest(requestURI, PostData);
    //        isSuccess = Convert.ToBoolean(objReqRes.ValidateOTP_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token));
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return isSuccess;
    //}
    public static bool ValidateOTP(string userID, string OTP, string token)
    {
        bool isSuccess = false;
        Sast_Utils _utils = new Sast_Utils();
       // DataTable dt_userCredential_Details = _utils.Get_User_Credential_Details(0, Convert.ToString(userID), OTP);
        try
        {
            //DataRow dr = dt_userCredential_Details.Rows[0];
            //if(dr["hhid"].ToString() == userID && dr["otp"].ToString()== OTP)
            {
                isSuccess = true;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    //public static bool ValidateNewPatient(int userType, Patient patient, string IPAddress, string payerCode)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/login/GetUserAvailable_V1?userType={0}&mobileNo={1}&emailID={2}&empID={3}&IP={4}&DeviceID={5}&payerCode={6}", userType, patient.MobileNo, patient.EmailID, patient.EmployeeID, IPAddress, "", payerCode);

    //    bool isSuccess = false;
    //    try
    //    {
    //        Utils _utils = new Utils();
    //        var response = _utils.HttpRequestResponse(requestURI);
    //        isSuccess = JsonConvert.DeserializeObject<bool>(response);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return isSuccess;
    //}
    public static SAST_user_Root ValidateNewPatient(int userType, Patient patient, string IPAddress, string payerCode)
    {
        bool isSuccess = false;
        Sast_Utils sast_Utils = new Sast_Utils();
        Utils utils = new Utils();
        string SAST_client_id = ConfigurationManager.AppSettings["SAST_client_id"];
        string SAST_client_secret = ConfigurationManager.AppSettings["SAST_client_secret"];
        string SAST_grant_type = ConfigurationManager.AppSettings["SAST_grant_type"];
        string Auth_Token = ConfigurationManager.AppSettings["Auth_Token"];
        string uri = ConfigurationManager.AppSettings["SAST_CLURL"] + string.Format("HRMS_Kgid_Share/token");
        string uri1 = ConfigurationManager.AppSettings["SAST_CLURL"] + string.Format("api/GoldenApiServices");
        SAST_user_Root sAST_User_Root = new SAST_user_Root();
        SAST_Root_rsqt sAST_Root_Rsqt = new SAST_Root_rsqt();
        BeneficiaryDetails_rsqt beneficiaryDetails_Rsqt = new BeneficiaryDetails_rsqt();
        RationCardDetails_rsqt rationCardDetails = new RationCardDetails_rsqt();
        try
        {
            beneficiaryDetails_Rsqt.hhId = Convert.ToString(patient.EmployeeID);
            beneficiaryDetails_Rsqt.uuid = string.Empty;
            beneficiaryDetails_Rsqt.rationCardDetails = rationCardDetails;
            sAST_Root_Rsqt.beneficiaryDetails = beneficiaryDetails_Rsqt;
            string RequestJson = JsonConvert.SerializeObject(sAST_Root_Rsqt, new JsonSerializerSettings());
            //string token = sast_Utils.PostRequestKASS(uri, RequestJson, string.Empty);
            string res=sast_Utils.PostRequestKASS(uri1, RequestJson, Auth_Token);
            sAST_User_Root = JsonConvert.DeserializeObject<SAST_user_Root>(res);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return sAST_User_Root;
    }

    //public static User CheckCredential(int userType, string userName, string password)
    //{
    //    User _user = new User();
    //    string uri = Utils.CLSURL + string.Format("api/Patient/GetUserDetails");
    //    Utils _utils = new Utils();
    //    ReqRes_Consumer objSerialize = new ReqRes_Consumer();
    //    try
    //    {
    //        string RequestStr = objSerialize.GetUserDetails_Request_Serialize(userType, userName, password, "", Utils.App_Name, Utils.DeviceId);
    //        var response = _utils.PostRequest(uri, RequestStr);
    //        if (response != null && response != string.Empty)
    //            _user = objSerialize.GetUserDetails_Response_Deserialize(JsonConvert.DeserializeObject<string>(response));
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return _user;
    //}
    public static LoginUser CheckCredential(string userName, string password)
    {
        LoginUser _user = new LoginUser(); string output = string.Empty;
        try
        {

            string uri = Utils.CLSURL + string.Format("api/login");
            Utils _utils = new Utils();
            RequestResponse objReq = new RequestResponse();

            try
            {
                string postData = objReq.PostGenerateLogin_Request_serialize(userName, password);
                var loginRequest = new LoginRequest
                {
                    UserName = userName,
                    Password = password
                };
                postData = JsonConvert.SerializeObject(loginRequest);
                string response = _utils.PostRequestNew(uri, postData);
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response);
                //output = objReq.PostGenerateLogin_Response_Deserialize(JsonConvert.DeserializeObject<string>(response));
                if (!string.IsNullOrEmpty(loginResponse.Token))
                {
                    _user.token = loginResponse.Token;
                    _user.Error = loginResponse.Error;
                    _user.UserID = loginResponse.UserId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _user;
    }
    public static int SendMPIN(string payercode, string mobile, string emailid, string mpin, string App_Guid)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Login/SendMPIN_V1?payercode={0}&mobile={1}&emailid={2}&mpin={3}&App_Guid={4}", payercode, mobile, emailid, mpin, App_Guid);
        int result = 0;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            result = JsonConvert.DeserializeObject<int>(response);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }

    public static string GenerateOTP(int userType, string userID, string MobileNo, string token)
    {
        string OTP = string.Empty;
        string uri = Utils.CLSURL + string.Format("api/Patient/PostGenerateOTP");
        Utils _utils = new Utils();
        RequestResponse objReq = new RequestResponse();

        try
        {
            string postData = objReq.PostGenerateOTP_Request_serialize(userType, userID, MobileNo, token);
            var response = _utils.PostRequest(uri, postData);
            OTP = objReq.PostGenerateOTP_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return OTP;
    }

    public static string ChangePassword(int userID, string password, string oldpassword, string IPAddress, string DeviceID)
    {
        string requestURI = Utils.CLSURL + string.Format("api/login/ChangePassword_V2?userID={0}&password={1}&oldPassword={2}&IPAddress={3}&DeviceID={4}", userID, password, oldpassword,IPAddress,DeviceID);
        string isSuccess = string.Empty;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            var response = _utils.HttpRequestResponse(requestURI);
            //isSuccess = JsonConvert.DeserializeObject<string>(response);
            isSuccess = objReqRes.String_Response_Deserialize_Key(JsonConvert.DeserializeObject<string>(response));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public static string logpassword_change_failed_count(string userID, string entitycode, bool isMpin = false)
    {
        string requestURI = Utils.CLSURL + string.Format("api/login/logpassword_change_failed_count?userID={0}&entitycode={1}&isMpin={2}", userID, entitycode, isMpin);
        string isSuccess = string.Empty;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            var response = _utils.HttpRequestResponse(requestURI);
            //isSuccess = JsonConvert.DeserializeObject<string>(response);
            isSuccess = objReqRes.String_Response_Deserialize_Key(JsonConvert.DeserializeObject<string>(response));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public static Physician_SearchMenu GetPhysicianSplSearchMenu(string Latitude, string Longitude, int RadiusLimit = 0, string SearchKey = "", string Pincode = "", int cityId = 0, string token = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/common/GetPhysicianSplSearchMenu?Latitude={0}&Longitude={1}&RadiusLimit={2}&SearchKey={3}&Pincode={4}&cityId={5}", Latitude, Longitude, RadiusLimit, SearchKey, Pincode, cityId);
        Physician_SearchMenu obj = new Physician_SearchMenu();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            obj = objReqRes.GetPhysicianSplSearchMenu_Com_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
            // obj = JsonConvert.DeserializeObject<Physician_SearchMenu>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }
    public static List<OP_Menu_Search> GetSearchCityMenu(string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/common/GetSearchCityMenu");
        List<OP_Menu_Search> obj = new List<OP_Menu_Search>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            obj = objReqRes.GetSearchCityMenu_Com_Deserialize(JsonConvert.DeserializeObject<string>(response), token);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }

    public static GoogleMapPlaceClass findLocation(string SearchKey)
    {
        GoogleMapPlaceClass _geo = new GoogleMapPlaceClass();
        string uri = Utils.CLSURL + string.Format("api/common/GetGoogleMapAutocompleteData?Searchkey={0}", SearchKey);
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(uri);
            _geo = JsonConvert.DeserializeObject<GoogleMapPlaceClass>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _geo;
    }

    public static int GetCityID(string cityName)
    {
        string requestURI = Utils.CLSURL + string.Format("api/common/GetCityID?cityName={0}&Pincode=", cityName.Trim());
        int obj = 0;
        Utils _utils = new Utils();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            obj = JsonConvert.DeserializeObject<int>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }

    public static string GetPolicyNumber(string PatientID, string payercode)
    {
        string ReturnResponse = string.Empty;
        string requestURI = Utils.CLSURL + string.Format("api/login/GetPolicyNumber?PatientID={0}&payercode={1}", PatientID, payercode);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            ReturnResponse = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnResponse;
    }

    public static List<RN.MOBILE_COMMON.RateUs> GetRateUsValues(string patientid, string token)
    {
        List<RN.MOBILE_COMMON.RateUs> _Rateus = new List<RN.MOBILE_COMMON.RateUs>();
        string uri = Utils.CLSURL + string.Format("api/login/GetRateUsValues?patientid={0}", patientid);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            var response = _utils.HttpRequestResponse(uri);
            _Rateus = objReqRes.GetRateusValues_DeSerialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _Rateus;
    }

    public static List<Lookup> GetLookupList(int lookUpTypeID, string token)
    {
        List<Lookup> _lookup = new List<Lookup>();
        string uri = Utils.CLSURL + string.Format("api/login?lookUpTypeID={0}", lookUpTypeID);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            var response = _utils.HttpRequestResponse(uri);
            _lookup = objReqRes.GetLookupValues_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _lookup;
    }

    public static int SubmitRateUs(RN.MOBILE_COMMON.RateUs ObjRateUs, string token)
    {

        string requestURI = Utils.CLSURL + string.Format("api/login/PostRateUs?");
        string UserId = string.Empty;
        int response = 0;
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.OP_RateUs_Serialize(ObjRateUs, token);
            response = Convert.ToInt32(_utils.PostRequest(requestURI, sData));

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return response;
    }


    public static List<Pharmacy> GetPharmacyAvailableCenters(string Latitude, string Longitude, string token, string SearchKey = "", string Pincode = "", int Radius = 0, int CityId = 0)
    {
        string requestURI = Utils.CLSURL + string.Format("api/pharmacy/GetPharmacyAvailableCenters?Latitude={0}&Longitude={1}&SearchKey={2}&Pincode={3}&RadiusLimit={4}&cityId={5}", Latitude, Longitude, SearchKey, Pincode, Radius, CityId);
        List<Pharmacy> objlist = new List<Pharmacy>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            objlist = objReqRes.GetPharmacyAvailableCenters_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    public static bool SubmitCustomerIssue(CustomerIssue objissue, string token)
    {

        string requestURI = Utils.CLSURL + string.Format("api/patient/PostcustomerIssue?");
        string UserId = string.Empty;
        bool isSuccess = false;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            Utils _utils = new Utils();
            string sData = objReqRes.OP_CustomerIssue_Serialize(objissue, token);
            int response = Convert.ToInt32(_utils.PostRequest(requestURI, sData));
            if (response == 1)
            {
                isSuccess = true;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isSuccess;
    }

    public string GetProfileImageURL(int UserType, string Entity_Code, string token, string Image_Key = "")
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

    public static string GetCityState(string pincode, string token)
    {
        string cityState = string.Empty;
        string uri = Utils.CLSURL + string.Format("api/login/GetCityState?PinCode={0}", pincode);
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            cityState = objReqRes.GetCityState_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return cityState;
    }
    public static string GetRequestedWebURL(string token)
    {
        string obj = null;
        string uri = Utils.CLSURL + string.Format("api/common/GetRequestedWebURL");
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

    public static string GetFAQHTMLBodyContent(string token)
    {
        string obj = null;
        string uri = Utils.CLSURL + string.Format("api/common/GetFAQHTMLContent?UserType={0}", (int)Enumerations.UserType.Patient);
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

    public static string GetHowToUseContentV1(string token)
    {
        string obj = null;
        string uri = Utils.CLSURL + string.Format("api/common/GetHowToUseContentV1?UserType={0}", (int)Enumerations.UserType.Patient);
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

    public static string ForgotMpinSendOTP(int userType, string userID, string MobileNo, string token,string IPAddress="",string DeviceID="")
    {
        string OTP = string.Empty;
        string uri = Utils.CLSURL + string.Format("api/Patient/ForgotMpinSendOTP_V2");
        Utils _utils = new Utils();
        RequestResponse objReq = new RequestResponse();

        try
        {
            string postData = objReq.ForgotMpinSendOTP_Request_serialize_V2(userType, userID, MobileNo, token,IPAddress,DeviceID);
            var response = _utils.PostRequest(uri, postData);
            OTP = objReq.ForgotMpinSendOTP_Response_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return OTP;
    }
    public static void UpdateUserLoginTime(string userId)
    {
        Utils _utils = new Utils();
        string uri = Utils.CLSURL + string.Format("api/Common/UpdateUserLoginTime?userid={0}", userId);
        try
        {
            string response = _utils.HttpRequestResponse(uri);
            bool result = JsonConvert.DeserializeObject<bool>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static List<CustomerIssue> GetCustomerIssueMaster(string token)
    {
        List<CustomerIssue> CustomerIssueMasterList = new List<CustomerIssue>();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetCustomerIssueMaster");
        Utils _utils = new Utils();
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        try
        {
            var response = _utils.HttpRequestResponse(uri);
            CustomerIssueMasterList = objReqRes.GetCustomerIssueMaster_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return CustomerIssueMasterList;
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

    public static string GetCustomerSupportNumber(string token)
    {
        string obj = null;
        string uri = Utils.CLSURL + string.Format("api/common/GetCustomerSupportNumber");
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

    //public static City GetLocationCity(string Latitude, string Longitude, string token)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/common/GetLocalityDetails?Latitude={0}&Longitude={1}", Latitude, Longitude);
    //    City obj = new City();
    //    Utils _utils = new Utils();
    //    ReqRes_Consumer objReqRes = new ReqRes_Consumer();
    //    try
    //    {
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        response = JsonConvert.DeserializeObject<string>(response);
    //        obj = objReqRes.City_Deserialize(response, token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return obj;
    //}

    public static City GetLocationCity(string Latitude, string Longitude, string token, GeoLocation _geo1 =null)
    {
       // Latitude = "10.777011";
        //Longitude = "79.636734";
        string mystring = string.Empty;
        string Pincode = string.Empty;
        ReqRes_Consumer objReqRes = new ReqRes_Consumer();
        GeoCodeJSONClass _geo = new GeoCodeJSONClass();
        City _City = new City();
        Sast_Utils sast_Utils = new Sast_Utils();
        try
        {

            string Key = "AIzaSyBa3-yzoSmr4Vx-rPq5DZ6JUDp3n6minQE";
            if (ConfigurationManager.AppSettings["GoogleMap_Key"] != null)
                Key = ConfigurationManager.AppSettings["GoogleMap_Key"];

            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0}&sensor=false&key={1}", Latitude + "," + Longitude, Key);
            var cts = new CancellationTokenSource();


            using (var client = new HttpClient())
            {
                // HTTP POST
                try
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var response = client.GetAsync(url, cts.Token).Result;
                    mystring = response.Content.ReadAsStringAsync().Result;
                    _geo = JsonConvert.DeserializeObject<GeoCodeJSONClass>(mystring);
                    for (var i = 0; i < _geo.results[0].address_components.Count; i++)
                    {
                        for (var j = 0; j < _geo.results[0].address_components[i].types.Count; j++)
                        {
                            if (_geo.results[0].address_components[i].types[j] == "locality")
                            {
                                _City.CityName = _geo.results[0].address_components[i].long_name;
                                break;
                            }
                        }
                    }

                    for (var i = 0; i < _geo.results[0].address_components.Count; i++)
                    {
                        for (var j = 0; j < _geo.results[0].address_components[i].types.Count; j++)
                        {
                            if (_geo.results[0].address_components[i].types[j] == "postal_code")
                            {
                                Pincode = _geo.results[0].address_components[i].long_name;
                                break;
                            }
                        }
                    }


                    if (!string.IsNullOrWhiteSpace(_City.CityName) || !string.IsNullOrEmpty(Pincode))
                    {
                        //_City.CityID = sast_Utils.GetCityID(_City.CityName, Pincode);
                    }
                    _geo1.PinCode = Pincode;

                }
                catch (Exception ex1)
                {
                    //RN.Common.ErrorLogger.LogMessage(ex1, errorLogPath);
                }
            }

        }
        catch (Exception ex)
        {
            //RN.Common.ErrorLogger.LogMessage(ex, errorLogPath);
        }
        finally
        {
            mystring = objReqRes.City_Serialize(_City, token);
        }
        return _City;
    }

    public static List<GeoLocation> GetLocationByAddress(string ByAddress, string token)
    {
        string requestURI = Utils.CLSURL + string.Format("api/common/GetLocalityDetailsByAddress?SearchKey={0}", ByAddress);
        List<GeoLocation> obj = new List<GeoLocation>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string response = _utils.HttpRequestResponse(requestURI);
            response = JsonConvert.DeserializeObject<string>(response);
            obj = objReqRes.GetGeoLocation_DeSerialize(response, token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }

    public static List<Pharmacy> GetPharmacyAvailableCenters_v1(OP_Consumer_Search objCon, int PageNo, int NumRec, string token,string PolicyNo)
    {
        string requestURI = Utils.CLSURL + string.Format("api/pharmacy/GetPharmacyAvailableCenters_v1?PageNo={0}&NumRec={1}&PolicyNo={2}", PageNo, NumRec, PolicyNo);
        List<Pharmacy> objlist = new List<Pharmacy>();
        Utils _utils = new Utils();
        RequestResponse objReqRes = new RequestResponse();
        try
        {
            string data = objReqRes.GetPhysicianSearch_Com_request_Serialize(objCon, token);
            string response = _utils.PostRequest(requestURI, data);
            objlist = objReqRes.GetPharmacyAvailableCenters_Deserialize(JsonConvert.DeserializeObject<string>(response), token);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objlist;
    }

    //public static List<OP_Menu_Search> GetPhysicianSplSearchMenu_v1(GeoLocation objGeo, int RadiusLimit = 0, string SearchKey = "", string Pincode = "", int cityId = 0, string token = "", string PolicyNo = "")
    //{
    //    List<OP_Menu_Search> obj = new List<OP_Menu_Search>();
    //    try
    //    {
    //        string requestURI = Utils.CLSURL + string.Format("api/common/GetPhysicianSplSearchMenu_v3?Latitude={0}&Longitude={1}&RadiusLimit={2}&SearchKey={3}&Pincode={4}&cityId={5}&PolicyNo={6}", objGeo.GEO_LATITUDE, objGeo.GEO_LONGITUDE, RadiusLimit, SearchKey, Pincode, objGeo.CITY_ID, PolicyNo);
            
    //        Utils _utils = new Utils();
    //        RequestResponse objReqRes = new RequestResponse();
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        obj = objReqRes.GetPhysicianSplSearchMenu_v1_Com_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return obj;
    //}
    public static List<OP_Menu_Search> GetPhysicianSplSearchMenu_v1(GeoLocation objGeo, int RadiusLimit = 0, string SearchKey = "", string Pincode = "", int cityId = 0, string token = "", string PolicyNo = "")
    {
        List<OP_Menu_Search> obj = new List<OP_Menu_Search>();
        Sast_Utils sast_Utils = new Sast_Utils();
        DataTable DT = new DataTable();

        try
        {
            if(string.IsNullOrEmpty(Pincode))
            {
                Pincode = objGeo.PinCode;
            }
             
            DT = sast_Utils.GetPhysicianSplSearchMenu_v1(string.Empty, Pincode);
            foreach (DataRow dr in DT.Rows)
            {
                OP_Menu_Search obj1 = new OP_Menu_Search();
                if (!string.IsNullOrEmpty(dr["PKG_CATEGORY"].ToString()))
                    //    obj1.DISPLAY_ORDER = Convert.ToInt32(dr["SUBCATEGORYID"].ToString());
                    obj1.DISPLAY_TEXT = dr["PKG_CATEGORY"].ToString();
                //obj1.IMAGE_NAME = dr["IMAGE_NAME"].ToString();
                //obj1.IS_DISPLAY = 1;// Convert.ToInt32(dr["IS_DISPLAY"].ToString());
                //obj1.TRANSACTION_TYPE = 1;// Convert.ToInt32(dr["TRANSACTION_TYPE"].ToString());
                //obj1.TYPE_ID = 1;//Convert.ToInt32(dr["TYPE_ID"].ToString());
                if (!string.IsNullOrEmpty(dr["CategoryId"].ToString()))
                    obj1.VALUE_ID = Convert.ToInt32(dr["CategoryId"].ToString());
                //obj1.ALT_IMAGE_NAME = string.Empty;// Convert.ToString(dr["ALT_IMAGE_NAME"]);
                obj1.PKG_CATEGORY =  Convert.ToString(dr["PKG_CATEGORY"]);
                obj1.Image =  Convert.ToString(dr["IMAGE_NAME"]);
                obj.Add(obj1);
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }
    public static List<Physician> GetPhysicianSearch(OP_Consumer_Search objCon, int PageNo, int NumRec, int lastPhysicianId, string token, string PolicyNo = "", GeoLocation objGeo=null)
    {
        List<Physician> obj = new List<Physician>();
        Sast_Utils sast_Utils = new Sast_Utils();
        DataTable DT = new DataTable();
        string Pincode = string.Empty;
        List<RN.MOBILE_COMMON.Physician> lstPhy = new List<RN.MOBILE_COMMON.Physician>();
        try
        {
            if (string.IsNullOrEmpty(Pincode))
            {
                Pincode = objGeo.PinCode;
            }

            DT = sast_Utils.GetPhysicianSearch(string.Empty, Pincode, objGeo);
            if (DT.Rows.Count > 0)
            {
                //DataTable dtPhy = new DataTable("DT");
                //dtPhy.Columns.Add("ENTITYCODE"); //ENTITYCODE
                //dtPhy.Columns.Add("PHYSICIAN_ID"); //PHYSICIAN_ID

                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    DataRow dr1 = dtPhy.NewRow();
                //    dr1[0] = dr["entitycode"].ToString();
                //    dr1[1] = dr["PHYSICIAN_ID"].ToString();
                //    dtPhy.Rows.Add(dr1);
                //}

                //string xmlPhysian = Utils.GetXMLFromDataTable(dtPhy);

                //#region get the consultaion fee
                //try
                //{

                //    string payerCode = ConfigurationManager.AppSettings.Get("PayerCode");
                //    OP_Common objcommonpayer = new OP_Common();
                //    DataSet dsUrl = Utils.DeSerialize(objcommonpayer.GetMappedPayersUrl(payerCode, "OP_CS"));
                //    if (dsUrl != null && dsUrl.Tables.Count > 0 && dsUrl.Tables[0].Rows.Count > 0)
                //    {
                //        objService = new OP_CommonService();
                //        objService.Url = dsUrl.Tables[0].Rows[0]["URL"].ToString();
                //        dsRate = Utils.DeSerialize(objService.GetPhysicanRate(xmlPhysian));

                //    }
                //}
                //catch (Exception ex)
                //{
                //    RN.Common.ErrorLogger.LogMessage(ex, errorLogPath);
                //}
                //#endregion


                foreach (DataRow dr in DT.Rows)
                {
                    RN.MOBILE_COMMON.Physician _phy = new RN.MOBILE_COMMON.Physician();
                    //if (!string.IsNullOrEmpty(dr["SPECIALIST_ID"].ToString()))
                    //    _phy.PhysicianID = Convert.ToInt32(dr["SPECIALIST_ID"].ToString());
                   // _phy.UserName = (dr["SPECIALIST_NAME"].ToString());
                    _phy.ClinicAddress = dr["HNO"].ToString() + " " + dr["STREET"].ToString() +" "+ dr["LOC"].ToString() + " " + dr["AREACODE"].ToString();
                    _phy.ClinicName = (dr["HOSPNAME"].ToString());
                    _phy.EntityCode = dr["HOSPCODE"].ToString();
                    //if (!string.IsNullOrEmpty(dr["EXPERIENCE"].ToString()))
                    //    _phy.Experience = Convert.ToInt32(dr["EXPERIENCE"].ToString());
                    //_phy.Qualification = dr["QUALIFICATION"].ToString();
                    _phy.Speciality = dr["PKG_CATEGORY"].ToString();
                    //if (!string.IsNullOrEmpty(dr["SUBCATEGORYID"].ToString()))
                    //    _phy.SpecialityID = Convert.ToInt32(dr["SUBCATEGORYID"].ToString());
                    _phy.Geolocation = new GeoLocation();
                    if (!string.IsNullOrEmpty(dr["distance"].ToString()))
                        _phy.Geolocation.GEO_DISTANCE = Convert.ToDouble(dr["distance"].ToString());
                    if (!string.IsNullOrEmpty(dr["Latitude"].ToString()))
                        _phy.Geolocation.GEO_LATITUDE = Convert.ToDouble(dr["Latitude"].ToString());
                    if (!string.IsNullOrEmpty(dr["Longitude"].ToString()))
                        _phy.Geolocation.GEO_LONGITUDE = Convert.ToDouble(dr["Longitude"].ToString());
                    if (!string.IsNullOrEmpty(dr["AREACODE"].ToString()))
                        _phy.Geolocation.PinCode = dr["AREACODE"].ToString();
                    //_phy.Geolocation.userId = _phy.PhysicianID;

                    //if (!string.IsNullOrEmpty(dr["INTEGRATION_CODE"].ToString()) && dr["INTEGRATION_CODE"].ToString() != "0")
                    //{
                    //    _phy.Integration_Id = Convert.ToInt32(dr["INTEGRATION_ID"]);
                    //    _phy.Integration_Code = dr["INTEGRATION_CODE"].ToString();
                    //}
                    //if (!string.IsNullOrEmpty(dr["entityid"].ToString()))
                    //    _phy.EntityId = Convert.ToInt32(dr["entityid"].ToString());

                    if (!string.IsNullOrEmpty(dr["Distance"].ToString()))
                    {
                        _phy.Distance = dr["Distance"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["PHONE1"].ToString()))
                    {
                        _phy.MobileNo = dr["PHONE1"].ToString();
                    }
                    //if (!string.IsNullOrEmpty(dr["REGISTRATION_NO"].ToString()))
                    //{
                    //    _phy.PROFILE_CODE = dr["REGISTRATION_NO"].ToString();
                    //}
                    //if (!string.IsNullOrEmpty(dr["REGISTRATION_NO"].ToString()))
                    //{
                    //    _phy.RegistrationNo = dr["REGISTRATION_NO"].ToString();
                    //}

                    //if (!string.IsNullOrEmpty(dr["SPECIALIST_ID"].ToString()))
                    //{
                    //    //_phy.soryby_fee = 999999;
                    //    //if (dsRate != null && dsRate.Tables[0].Rows.Count > 0)
                    //    //{
                    //    //    DataRow[] drphy = dsRate.Tables[0].Select("physician_id='" + dr["PHYSICIAN_ID"].ToString() + "' and entity_code='" + dr["ENTITYCODE"].ToString() + "'");
                    //    //    if (drphy != null && drphy.Count() > 0)
                    //    //    {
                    //    //        if (!string.IsNullOrEmpty(drphy[0]["fee"].ToString()))
                    //    //        {
                    //    //            _phy.ConsultFee = Convert.ToDecimal(drphy[0]["fee"].ToString());
                    //    //            _phy.soryby_fee = Convert.ToDecimal(drphy[0]["fee"].ToString());
                    //    //        }
                    //    //        else
                    //    //        {
                    //    //            _phy.soryby_fee = 999999;
                    //    //        }
                    //    //    }

                    //    //}
                    //}
                    if (!string.IsNullOrEmpty(dr["PHONE1"].ToString()))
                    {
                        _phy.ENTITY_MOBILENO = dr["PHONE1"].ToString();
                    }
                    //if (!string.IsNullOrEmpty(dr["Tele_Consult"].ToString()))
                    //{
                    //    _phy.TELE_CONSULT = Convert.ToInt32(dr["Tele_Consult"]);
                    //}
                    //_phy.TELE_CONSULT_NUMBER = TELE_CONSULT_NUMBER;

                    //if (!string.IsNullOrEmpty(dr["homevisit"].ToString()))
                    //{
                    //    _phy.HOME_VISIT = Convert.ToString(dr["homevisit"]);
                    //}

                    //if (!string.IsNullOrEmpty(dr["physical_consultation"].ToString()))
                    {
                        _phy.PHYSICAL_CONSULTATION = "1";//Convert.ToString(dr["physical_consultation"]);
                    }

                    //if (!string.IsNullOrEmpty(dr["video_consultation"].ToString()))
                    //{
                    //    _phy.VIDEO_CONSULTATION = /Convert.ToString(dr["video_consultation"]);
                    //}

                    lstPhy.Add(_phy);
                }

            }


        }
        catch (Exception ex)
        {
            //throw ex;
        }
        return lstPhy;
    }
    //public static List<Physician> GetPhysicianSearch(OP_Consumer_Search objCon, int PageNo, int NumRec, int lastPhysicianId, string token, string PolicyNo = "")
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/common/GetPhysicianSearch_v1?PageNo={0}&NumRec={1}&lastPhysicianId={2}&PolicyNo={3}", PageNo, NumRec, lastPhysicianId, PolicyNo);
    //    List<Physician> obj = new List<Physician>();
    //    Utils _utils = new Utils();
    //    RequestResponse objReqRes = new RequestResponse();
    //    try
    //    {
    //        string data = objReqRes.GetPhysicianSearch_Com_request_Serialize(objCon, token);
    //        string response = _utils.PostRequest(requestURI, data);
    //        obj = objReqRes.GetPhysicianSearch_Com_Deserialize(JsonConvert.DeserializeObject<string>(response), token);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return obj;
    //}


    public static int SendMPIN_V2(string PayerCode, string MobileNo, string EmailId,string EmployeeId,string mpin, string App_Guid)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Login/SendMPIN_V2?PayerCode={0}&MobileNo={1}&EmailId={2}&EmployeeId={3}&mpin={4}&App_Guid={5}", PayerCode, MobileNo, EmailId, EmployeeId, mpin, App_Guid);
        int result ;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            result = JsonConvert.DeserializeObject<int>(response);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }


    //public static int SendMPIN_V3(string PayerCode, string MobileNo, string EmailId, string EmployeeId, string mpin, string App_Guid, string IPAddress, string DeviceID)
    //{
    //    string requestURI = Utils.CLSURL + string.Format("api/Login/SendMPIN_V3?PayerCode={0}&MobileNo={1}&EmailId={2}&EmployeeId={3}&mpin={4}&App_Guid={5}&IPAddress={6}&DeviceID={7}", PayerCode, MobileNo, EmailId, EmployeeId, mpin, App_Guid, IPAddress, DeviceID);
    //    int result;
    //    try
    //    {
    //        Utils _utils = new Utils();
    //        string response = _utils.HttpRequestResponse(requestURI);
    //        result = JsonConvert.DeserializeObject<int>(response);

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return result;
    //}

    public static int SendMPIN_V3(string PayerCode, string MobileNo, string EmailId, string EmployeeId, string mpin, string App_Guid, string IPAddress, string DeviceID)
    {
        int result = 0;
        Sast_Utils sast_Utils = new Sast_Utils();
        try
        {
            sast_Utils.InsertCredential_Details_op(EmployeeId, MobileNo, mpin, mpin);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }

    public static int SendMPIN_RN(string PayerCode, string MobileNo, string EmailId, string EmployeeId, string mpin, string App_Guid, string IPAddress, string DeviceID, string memberID = "")
    {
        string requestURI = Utils.CLSURL + string.Format("api/Login/SendMPIN_RN?PayerCode={0}&MobileNo={1}&EmailId={2}&EmployeeId={3}&mpin={4}&App_Guid={5}&IPAddress={6}&DeviceID={7}&memberID={8}", PayerCode, MobileNo, EmailId, EmployeeId, mpin, App_Guid, IPAddress, DeviceID, memberID);
        int result;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            result = JsonConvert.DeserializeObject<int>(response);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }

    public string loginAuditLog(string userID, string IPAddress, string DeviceId, string SessionID, string Audit_type, string Event_type)
    {
        string requestURI = Utils.CLSURL + string.Format("api/Login/loginAuditLog?userID={0}&IPAddress={1}&DeviceId={2}&SessionID={3}&Audit_type={4}&Event_type={5}", userID, IPAddress, DeviceId, SessionID, Audit_type, Event_type);
        string Result = null;
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(requestURI);
            Result = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Result;
    }

    public static string loginAuditLog(string userID, string user_type, string IPAddress, string DeviceId, string SessionID, string Audit_type, string Event_type)
    {
        string uri = Utils.CLSURL + string.Format("api/Login/loginAuditLog?userID={0}&user_type={1}&IPAddress={2}&DeviceId={3}&SessionID={4}&Audit_type={5}&Event_type={6}", userID, user_type, IPAddress, DeviceId, SessionID, Audit_type, Event_type);
        string Result = null;
        try
        {
            Utils _utils = new Utils();
          
            string response = _utils.HttpRequestResponse(uri);
            if (response != null && response != string.Empty)
                Result = JsonConvert.DeserializeObject<string>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Result;
    }

    public static bool ResetLoginOTP(string User_Id, string User_Type)
    {
        string uri = Utils.CLSURL + string.Format("api/Login/ResetLoginOTP?User_Id={0}&User_Type={1}", User_Id, User_Type);
        bool Result = false;
        try
        {
            Utils _utils = new Utils();

            string response = _utils.HttpRequestResponse(uri);
            if (response != null && response != string.Empty)
                Result = JsonConvert.DeserializeObject<bool>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Result;
    }

    public static string AutoRegistration(string policyno, string uhid, string mobileno, string emailid, string deviceid)
    {
        string result = string.Empty;
        string uri = Utils.CLSURL + string.Format("api/Patient/AutoRegistrationAPI");
        Utils _utils = new Utils();
        ReqRes_Consumer objSerialize = new ReqRes_Consumer();
        try
        {
            string RequestStr = objSerialize.AutoRegistration_Request_Serialize(policyno, uhid,mobileno,emailid,deviceid);
            var response = _utils.PostRequest(uri, RequestStr);
           if (response != null && response != string.Empty)
                result = objSerialize.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }

    public static User GetAutoLoginData(int userType, string userName, string password, string memberId, string patientId)
    {
        User _user = new User();
        string uri = Utils.CLSURL + string.Format("api/Patient/GetUserDetail_V1");
        Utils _utils = new Utils();
        ReqRes_Consumer objSerialize = new ReqRes_Consumer();
        try
        {
            string RequestStr = objSerialize.GetUserDetails_V1_Request_Serialize(userType, userName, password, memberId, "", Utils.App_Name, Utils.DeviceId, patientId);
            var response = _utils.PostRequest(uri, RequestStr);
            if (response != null && response != string.Empty)
                _user = objSerialize.GetUserDetails_Response_Deserialize(JsonConvert.DeserializeObject<string>(response));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _user;
    }

    public static string AutoLoginLog(string requestUrl, string registrationResponse, string loginResponse, string PolicyNo, string UHID)
    {
        string result = string.Empty;
        string uri = Utils.CLSURL + string.Format("api/Patient/AutoLoginLogAPI");
        Utils _utils = new Utils();
        ReqRes_Consumer objSerialize = new ReqRes_Consumer();
        try
        {
            string RequestStr = objSerialize.AutoLoginLog_Request_Serialize(requestUrl, registrationResponse, loginResponse, PolicyNo, UHID);
            var response = _utils.PostRequest(uri, RequestStr);
            if (response != null && response != string.Empty)
                result = objSerialize.String_Response_Deserialize(JsonConvert.DeserializeObject<string>(response));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }


    public static List<OP_CITY_DATA> Get_Search_City_list(string SearchKey)
    {
        List<OP_CITY_DATA> _geo = new List<OP_CITY_DATA>();
        string uri = Utils.CLSURL + string.Format("api/common/Get_Search_City_list?KeyWord={0}", SearchKey);
        try
        {
            Utils _utils = new Utils();
            string response = _utils.HttpRequestResponse(uri);
            _geo = JsonConvert.DeserializeObject<List<OP_CITY_DATA>>(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _geo;
    }

    public static DataTable PkgDetails(string Entitycode,string catogory)
    {
        //User _user = new User();
        Sast_Utils _utils = new Sast_Utils();
        DataTable dt_Credential_Details = new DataTable();
        //DataTable dt_userCredential_Details = new DataTable();
        try
        {
            dt_Credential_Details = _utils.pkgDetail(Entitycode, catogory);
            //dt_userCredential_Details= _utils.Get_User_Credential_Details(userType, userName, password);
          

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt_Credential_Details;
    }
}

internal class LoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginResponse
{
    public string Token { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Error { get; set; }
}