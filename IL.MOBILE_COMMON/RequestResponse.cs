using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class QueryRequest
    {
        public List<string> param { get; set; }
    }
    public class RequestResponse
    {
        const string GentricMsg = "Something went wrong. Please contact admin.";
        CultureInfo culture = new CultureInfo("en-IN");
        char split = '¶';
        char ListIdentifier_Start = 'Á';
        char ListIdentifier_End = 'À';
        char ListElement_Start = 'É';
        char ListElement_End = 'È';
        char ListProperty_Split = '»';

        char Inner_ListIdentifier_Start = 'Ó';
        char Inner_ListIdentifier_End = 'Ù';
        char Inner_ListElement_Start = 'Ò';
        char Inner_ListElement_End = 'Ú';
        char Inner_ListProperty_Split = '¬';

        string key = EncryptKey();

        public string GetUserDetails_Request_Serialize(int userType, string userID, string password, string entityCode = null, string AppName = null, string DeviceId = null)
        {

            string outPut = string.Empty;

            outPut = userType.ToString() + split + userID + split + password + split + entityCode + split + AppName + split + DeviceId;

            return StringCipher.Encrypt(outPut, key);
        }

        public QueryRequest GetUserDetails_Request_Deserialize(string Request)
        {
            QueryRequest obj = new QueryRequest();
            string[] values = StringCipher.Decrypt(Request, key).Split(split);
            obj.param = new List<string>();
            foreach (string strval in values)
            {
                if (!strval.Contains(ListIdentifier_Start))
                {
                    obj.param.Add(strval);
                }
            }
            return obj;
        }


        public string GetUserDetails_Response_Serialize(User obj)
        {
            StringBuilder strOutPut = new StringBuilder();

            strOutPut.Append(obj.EmailID);
            strOutPut.Append(split);
            strOutPut.Append(obj.LoginID);
            strOutPut.Append(split);
            strOutPut.Append(obj.MobileNo);
            strOutPut.Append(split);
            strOutPut.Append(obj.UserID);
            strOutPut.Append(split);
            strOutPut.Append(obj.UserName);
            strOutPut.Append(split);
            strOutPut.Append(obj.UserType);
            strOutPut.Append(split);
            strOutPut.Append(obj.IsDisclaimerAgreed);
            strOutPut.Append(split);
            strOutPut.Append(obj.Error);

            //AutoRefreshScreen class
            strOutPut.Append(split);
            if (obj.PageRefreshTimeOut != null)
            {
                strOutPut.Append(obj.PageRefreshTimeOut.DashBoardTimeOut);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.PageRefreshTimeOut.ChatPageTimeOut);
            }
            else
                strOutPut.Append("");

            strOutPut.Append(split);
            strOutPut.Append(obj.Token);

            strOutPut.Append(split);
            strOutPut.Append(obj.IsOTPVerified);
            strOutPut.Append(split);
            strOutPut.Append(obj.EntityCode);
            strOutPut.Append(split);
            strOutPut.Append(obj.IsBillDeskEnable);
            //Diagnostic
            strOutPut.Append(split);
            if (obj.Diagnostic != null)
            {
                strOutPut.Append(obj.Diagnostic.DiagnosticID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.DiagnosticName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.DiagnosticType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.Discount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.EntityCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.WalletAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.address);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.state);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.city_name);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Diagnostic.pincode);
            }
            else
            {
                strOutPut.Append(string.Empty);
            }
            strOutPut.Append(split);
            if (obj.Pharmacy != null)
            {
                strOutPut.Append(obj.Pharmacy.PharmacyID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.PharmacyName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.PharmacyType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.Discount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.WalletAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.EntityCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.address);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.state);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.city);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Pharmacy.pincode);
            }
            else
            {
                strOutPut.Append(string.Empty);
            }

            strOutPut.Append(split);

            strOutPut.Append(obj.ErrorDesc);
            strOutPut.Append(split);
            strOutPut.Append(obj.LastLoginTime);
            strOutPut.Append(split);
            strOutPut.Append(obj.EntityName);
            strOutPut.Append(split);
            strOutPut.Append(obj.IsPrimaryMember);
            strOutPut.Append(split);
            strOutPut.Append(obj.isHIS);

            strOutPut.Append(split);
            strOutPut.Append(obj.Is_Disable_flag);
            strOutPut.Append(split);
            strOutPut.Append(obj.DisableCashlessBtn);
            strOutPut.Append(split);
            strOutPut.Append(obj.CityName);
            strOutPut.Append(split);
            strOutPut.Append(obj.Address);
            strOutPut.Append(split);
            strOutPut.Append(obj.StateName);
            strOutPut.Append(split);
            strOutPut.Append(obj.PINCode);
            strOutPut.Append(split);
            strOutPut.Append(obj.FREETEXT_MINOR_PROCEDURE);
            strOutPut.Append(split);
            strOutPut.Append(obj.FREETEXT_MINOR_TEST);
            strOutPut.Append(split);
            strOutPut.Append(obj.FREETEXT_SYPTOMS);
            strOutPut.Append(split);
            strOutPut.Append(obj.FREETEXT_DIAGNOSIS);
            strOutPut.Append(split);
            strOutPut.Append(obj.FREETEXT_DRUG);
            strOutPut.Append(split);
            strOutPut.Append(obj.FREETEXT_LAB_TEST);
            return StringCipher.Encrypt(strOutPut.ToString(), key);
        }

        public User GetUserDetails_Response_Deserialize(string Response)
        {
            User obj = new User();
            string[] values = StringCipher.Decrypt(Response, key).Split(split);

            obj.EmailID = values[0];
            obj.LoginID = values[1];
            obj.MobileNo = values[2];
            if (values[3] != string.Empty)
                obj.UserID = Convert.ToString(values[3]);
            obj.UserName = values[4];
            if (values[5] != string.Empty)
                obj.UserType = Convert.ToInt32(values[5]);
            if (values[6] != string.Empty)
                obj.IsDisclaimerAgreed = Convert.ToInt32(values[6]);
            obj.Error = values[7];

            if (values[8] != string.Empty)
            {
                AutoRefreshScreen objAutoRef = new AutoRefreshScreen();
                if (values[8] != string.Empty && values[8].Split(ListProperty_Split)[0] != string.Empty)
                    objAutoRef.DashBoardTimeOut = Convert.ToInt32(values[8].Split(ListProperty_Split)[0]);
                if (values[8] != string.Empty && values[8].Split(ListProperty_Split)[1] != string.Empty)
                    objAutoRef.ChatPageTimeOut = Convert.ToInt32(values[8].Split(ListProperty_Split)[1]);
                obj.PageRefreshTimeOut = objAutoRef;
            }

            obj.Token = values[9];

            obj.IsOTPVerified = values[10].ToUpper() == "TRUE" ? true : false;
            obj.EntityCode = values[11];
            if (values[12] != string.Empty)
            {
                obj.IsBillDeskEnable = values[12] == "true" ? true : false;
            }

            if (values[13] != string.Empty)
            {
                Diagnostic objDiag = new Diagnostic();
                string[] attr = values[13].Split(ListProperty_Split);
                if (attr[0] != string.Empty)
                    objDiag.DiagnosticID = Convert.ToInt32(attr[0]);
                objDiag.DiagnosticName = attr[1];
                if (attr[2] != string.Empty)
                    objDiag.DiagnosticType = Convert.ToInt32(attr[2]);
                if (attr[3] != string.Empty)
                    objDiag.Discount = Convert.ToDecimal(attr[3]);
                objDiag.EntityCode = attr[4];
                if (attr[5] != string.Empty)
                    objDiag.WalletAmt = Convert.ToDecimal(attr[5]);
                if (attr[6] != string.Empty)
                    objDiag.address = Convert.ToString(attr[6]);
                if (attr[7] != string.Empty)
                    objDiag.state = Convert.ToString(attr[7]);
                if (attr[8] != string.Empty)
                    objDiag.city_name = Convert.ToString(attr[8]);
                if (attr[9] != string.Empty)
                    objDiag.pincode = Convert.ToString(attr[9]);

                obj.Diagnostic = objDiag;
            }

            if (values[14] != string.Empty)
            {
                Pharmacy objphr = new Pharmacy();
                string[] attr = values[14].Split(ListProperty_Split);
                if (attr[0] != string.Empty)
                    objphr.PharmacyID = Convert.ToInt32(attr[0]);
                objphr.PharmacyName = attr[1];
                if (attr[2] != string.Empty)
                    objphr.PharmacyType = Convert.ToInt32(attr[2]);
                if (attr[3] != string.Empty)
                    objphr.Discount = Convert.ToDecimal(attr[3]);
                if (attr[4] != string.Empty)
                    objphr.WalletAmt = Convert.ToDecimal(attr[4]);

                objphr.EntityCode = attr[5];
                if (attr[6] != string.Empty)
                    objphr.address = attr[6];
                if (attr[7] != string.Empty)
                    objphr.state = attr[7];
                if (attr[8] != string.Empty)
                    objphr.city = attr[8];
                if (attr[9] != string.Empty)
                    objphr.pincode = attr[9];

                obj.Pharmacy = objphr;
            }
            obj.ErrorDesc = values[15];
            obj.LastLoginTime = values[16];
            obj.EntityName = values[17];
            obj.IsPrimaryMember = values[18];
            obj.isHIS = values[19].ToUpper() == "TRUE" ? true : false;

            obj.Is_Disable_flag = Convert.ToInt32(values[20]);
            if (!string.IsNullOrEmpty(values[21]))
                obj.DisableCashlessBtn = Convert.ToInt32(values[21]);
            if (values.Count() > 22)
            {
                obj.CityName = values[22];
                obj.Address = values[23];
                obj.StateName = values[24];
                obj.PINCode = values[25];
            }
            if (values.Count() > 26)
            {
                obj.FREETEXT_MINOR_PROCEDURE = Convert.ToBoolean(values[26]);
                obj.FREETEXT_MINOR_TEST = Convert.ToBoolean(values[27]);
                obj.FREETEXT_SYPTOMS = Convert.ToBoolean(values[28]);
                obj.FREETEXT_DIAGNOSIS = Convert.ToBoolean(values[29]);
                obj.FREETEXT_DRUG = Convert.ToBoolean(values[30]);
                obj.FREETEXT_LAB_TEST = Convert.ToBoolean(values[31]);
            }

            return obj;
        }


        public QueryRequest PostGenerateOTP_Request_Deserialize(string Request, string token)
        {
            token = key;
            QueryRequest obj = new QueryRequest();
            string[] values = StringCipher.Decrypt(Request, token).Split(split);
            obj.param = new List<string>();
            foreach (string strval in values)
            {
                if (!strval.Contains(ListIdentifier_Start))
                {
                    obj.param.Add(strval);
                }
            }
            return obj;
        }
        public string PostGenerateOTP_Request_serialize(int userType, string userID, string mobileNo = null, string token = "")
        {
            string outPut = string.Empty;
            token = key;
            outPut = userType.ToString() + split + userID + split + mobileNo;

            return StringCipher.Encrypt(outPut, token);
        }
        public string PostGenerateLogin_Request_serialize( string userID, string passowrd )
        {
            string outPut = string.Empty;
            string token = key;
            outPut =  userID + split + passowrd;

            return StringCipher.Encrypt(outPut, token);
        }
        public string PostGenerateLogin_Response_Deserialize(string Request)
        {
            string outPut = string.Empty;
           string token = key;
            outPut = StringCipher.Decrypt(Request, token);

            return outPut;
        }
        public string PostGenerateOTP_Response_serialize(string Otp, string token)
        {
            string outPut = string.Empty;

            outPut = Otp;
            token = key;
            return StringCipher.Encrypt(outPut, token);
        }


        public string PostGenerateOTP_Response_Deserialize(string Request, string token)
        {
            string outPut = string.Empty;
            token = key;
            outPut = StringCipher.Decrypt(Request, token);

            return outPut;
        }

        public string ValidateOTP_Request_serialize(int userID, string OTP, string token)
        {
            string outPut = string.Empty;

            outPut = userID.ToString() + split + OTP;

            return StringCipher.Encrypt(outPut, token);
        }

        public QueryRequest ValidateOTP_Request_Deserialize(string Request, string token)
        {
            QueryRequest obj = new QueryRequest();
            string[] values = StringCipher.Decrypt(Request, token).Split(split);
            obj.param = new List<string>();
            foreach (string strval in values)
            {
                if (!strval.Contains(ListIdentifier_Start))
                {
                    obj.param.Add(strval);
                }
            }
            return obj;
        }

        public string ValidateOTP_Response_serialize(string Response, string token)
        {
            string outPut = string.Empty;
            token = key;
            outPut = Response.ToString();

            return StringCipher.Encrypt(outPut, token);
        }

        public string ValidateOTP_Response_Deserialize(string Resposne, string token)
        {
            string outPut = "false";
            token = key;
            if (!string.IsNullOrEmpty(Resposne))
            {
                outPut = StringCipher.Decrypt(Resposne, token);
            }

            return outPut;
        }


        public string GetDashboardPrescription_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ChatDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ailmentName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.BillAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ChatPayable);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.UnreadMsgCount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.pharmacyId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physician_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ailmentCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.PrescriptionType);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetDashboardPrescription_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] attri = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = attri[0];
                                    objPres.ChatDate = attri[1];
                                    objPres.physicianName = attri[2];
                                    objPres.patientName = attri[3];
                                    objPres.ailmentName = attri[4];
                                    objPres.prescriptionDate = attri[5];
                                    if (attri[6] != string.Empty)
                                        objPres.BillAmt = Convert.ToInt32(attri[6]);
                                    if (attri[7] != string.Empty)
                                        objPres.ChatPayable = Convert.ToInt16(attri[7]);
                                    if (attri[8] != string.Empty)
                                        objPres.UnreadMsgCount = Convert.ToInt32(attri[8]);
                                    objPres.patient_id = attri[9];
                                    objPres.pharmacyId = attri[10];
                                    objPres.physician_id = attri[11];
                                    objPres.ailmentCode = attri[12];
                                    if (attri[13] != string.Empty)
                                        objPres.PrescriptionType = Convert.ToInt16(attri[13]);
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetOrderItemsDetails_Serialize(List<OrderItemDetails> ObjResponse, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (OrderItemDetails ObjitemDet in ObjResponse)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(ObjitemDet.Mobile_no);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.Rate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.Status);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.billAmount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.discount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.drug_name);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.drug_type);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.drugcode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.drugid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.mg_ml);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.mrp);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.offer_price);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.order_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ObjitemDet.quntity);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<OrderItemDetails> GetOrderItemsDetails_Deserialize(string Response, string Token)
        {
            List<OrderItemDetails> objList = new List<OrderItemDetails>();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    OrderItemDetails objPres = new OrderItemDetails();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    objPres.Mobile_no = attri[0];
                                    objPres.Rate = attri[1];
                                    objPres.Status = attri[2];
                                    objPres.billAmount = attri[3];
                                    objPres.discount = attri[4];
                                    objPres.drug_name = attri[5];
                                    objPres.drug_type = attri[6];
                                    objPres.drugcode = attri[7];
                                    if (attri[8] != string.Empty)
                                        objPres.drugid = Convert.ToInt32(attri[8]);
                                    objPres.mg_ml = attri[9];
                                    objPres.mrp = attri[10];
                                    objPres.offer_price = attri[11];
                                    objPres.order_id = attri[12];
                                    objPres.quntity = attri[13];
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetPrescriptionDetail_Serialize(PrescriptionClass objpre, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objpre.prescriptionId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.physicianName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.patientName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.prescriptionDate);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ailmentName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.procedureName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PrescriptionType);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryCity);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryState);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryAddress);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryPinCode);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PrecFileName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PatientAge);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ServiceAccessTypeID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PatientGender);
            strOutPut.Append(split);
            strOutPut.Append(objpre.Remarks);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PharmacyRemarks);
            strOutPut.Append(split);
            strOutPut.Append(objpre.TreatmentMethod);
            strOutPut.Append(split);

            //consultation
            if (objpre.Consultation != null)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.Consultation.ConsultationFee);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Consultation.ReviewDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Consultation.Speciality);
                strOutPut.Append(ListElement_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //DrugList
            if (objpre.Druglist != null && objpre.Druglist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Drug objdrug in objpre.Druglist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objdrug.DrugID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DrugName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.NoOfDays);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DrugQuantity);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Afternoon);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Morning);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Night);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.BeforeFood);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DRUG_TYPE_DESC);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageA);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageM);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageN);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Evening);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //pharmacyDetail
            if (objpre.pharmacyDetail != null)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.pharmacyDetail.PharmacyID);
                strOutPut.Append(ListProperty_Split);
                _PharmacyId = objpre.pharmacyDetail.PharmacyID.ToString();
                strOutPut.Append(objpre.pharmacyDetail.PharmacyName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.ShippingCharge);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.DeliveryMinTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.DeliveryMaxTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.Discount);
                strOutPut.Append(ListElement_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Diagnostic list
            if (objpre.DiagnosisDetail != null && objpre.DiagnosisDetail.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis objdia in objpre.DiagnosisDetail)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objdia.DiagnosisID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.ClaimID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.patientid);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.filename);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.ShowReport);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.AutoShowReport);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.RESULT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.OrderId);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //Orderdetails
            if (objpre.Orderdetails != null && objpre.Orderdetails.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Oderdetails objOrder in objpre.Orderdetails)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objOrder.order_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.prescription_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.address);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.pin);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.mobile_no);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.city);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.state);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.orderdate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.pharmacyname);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.Order_Amt);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.diagnosticname);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.order_type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.OrderStatus);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.PayerOrderId);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);

            //minor procedure list
            if (objpre.Proclist != null && objpre.Proclist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Procedure objProc in objpre.Proclist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objProc.ProcedureID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objProc.ProcedureCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objProc.ProcedureName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objProc.ReportName);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            //minor Test list
            if (objpre.Testlist != null && objpre.Testlist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Procedure objTest in objpre.Testlist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objTest.ProcedureID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.ProcedureCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.ProcedureName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.ReportName);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            //Diagnosis or Ailment 
            if (objpre.Diagnosis_ailment_Detail != null && objpre.Diagnosis_ailment_Detail.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis ObjDiag in objpre.Diagnosis_ailment_Detail)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(ObjDiag.DiagnosisCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(ObjDiag.DiagnosisName);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            //Diagnosis or Ailment 
            if (objpre.complaints != null && objpre.complaints.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PrescriptionClass.complaint Complaints in objpre.complaints)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Complaints.name);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);

            strOutPut.Append(_PharmacyId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.Is_health_check);
            strOutPut.Append(split);

            //Health checkup 
            if (objpre.HCU != null)
            {
                strOutPut.Append(ListIdentifier_Start);
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.HCU.HCName);
                strOutPut.Append(ListElement_End);
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            strOutPut.Append(objpre.AutoShowReport);

            strOutPut.Append(split);
            //Attachment
            if (objpre.AttachmentsLst != null && objpre.AttachmentsLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (OP_Attachments obj in objpre.AttachmentsLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.AttachDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AttachFileName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AttachmentRemarks);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Claim_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.FilePath);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Self_ID);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Vitals 
            if (objpre.VitalsLst != null && objpre.VitalsLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Vital_Controls obj in objpre.VitalsLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.CONTROL_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_STYLE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXPAND);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_2TEXTBOX);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Diagnostic_Range
            if (objpre.Diagnostic_Range != null && objpre.Diagnostic_Range.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (DiagnosticRange obj in objpre.Diagnostic_Range)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DIAGNOSTIC_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.KEY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.VALUE);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            if (objpre.secondaryAilments != null && objpre.secondaryAilments.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PrescriptionClass.SecondaryAilment Complaints in objpre.secondaryAilments)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Complaints.SecondaryAilmentname);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            if (objpre.Ailment_Details != null && objpre.Ailment_Details.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Ailment objAil in objpre.Ailment_Details)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objAil.AilmentID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objAil.AilmentName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objAil.code);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            strOutPut.Append(objpre.Action_status);

            strOutPut.Append(split);
            strOutPut.Append(objpre.Action_status_Id);

            strOutPut.Append(split);
            strOutPut.Append(objpre.Payer_remarks);

            strOutPut.Append(split);
            strOutPut.Append(objpre.MemberID);

            strOutPut.Append(split);
            strOutPut.Append(objpre.patient_id);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass GetPrescriptionDetail_Deserialize(string Response, string token)
        {
            PrescriptionClass objPres = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split); ;

            objPres.prescriptionId = values[0];
            objPres.physicianName = values[1];
            objPres.patientName = values[2];
            objPres.prescriptionDate = values[3];
            objPres.ailmentName = values[4];
            objPres.procedureName = values[5];
            if (values[6] != string.Empty)
                objPres.PrescriptionType = Convert.ToInt32(values[6]);
            objPres.DeliveryCity = values[7];
            objPres.DeliveryState = values[8];
            objPres.DeliveryAddress = values[9];
            objPres.DeliveryPinCode = values[10];
            objPres.PrecFileName = values[11];
            objPres.PatientAge = values[12];
            objPres.ServiceAccessTypeID = values[13];
            objPres.PatientGender = values[14];
            objPres.Remarks = values[15];
            objPres.PharmacyRemarks = values[16];
            objPres.TreatmentMethod = values[17];

            if (values[18] != null && values[18] != string.Empty)
            {
                Consultation obj = new Consultation();
                foreach (string innerlist in values[18].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        obj.ConsultationFee = attri[0];
                        obj.ReviewDate = attri[1];
                        obj.Speciality = attri[2];
                    }
                }
                objPres.Consultation = obj;
            }

            if (values[19] != null && values[19] != string.Empty)
            {
                List<Drug> objList = new List<Drug>();
                foreach (string list in values[19].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Drug objDrug = new Drug();
                                if (attri[0] != string.Empty)
                                    objDrug.DrugID = Convert.ToInt32(attri[0]);
                                objDrug.DrugName = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.NoOfDays = Convert.ToInt32(attri[2]);
                                if (attri[3] != string.Empty)
                                    objDrug.DrugQuantity = Convert.ToInt32(attri[3]);
                                if (attri[4] != string.Empty)
                                    objDrug.Afternoon = Convert.ToDecimal(attri[4]);
                                if (attri[5] != string.Empty)
                                    objDrug.Morning = Convert.ToDecimal(attri[5]);
                                if (attri[6] != string.Empty)
                                    objDrug.Night = Convert.ToDecimal(attri[6]);
                                if (attri[7] != string.Empty)
                                    objDrug.BeforeFood = Convert.ToInt32(attri[7]);
                                objDrug.DRUG_TYPE_DESC = attri[8];
                                objDrug.DosageA = attri[9];
                                objDrug.DosageM = attri[10];
                                objDrug.DosageN = attri[11];
                                if (attri[12] != string.Empty)
                                    objDrug.Evening = Convert.ToDecimal(attri[12]);
                                objList.Add(objDrug);
                            }
                        }
                    }
                }
                objPres.Druglist = objList;
            }

            if (values[20] != null && values[20] != string.Empty)
            {
                Pharmacy objPhr = new Pharmacy();
                foreach (string innerlist in values[20].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        if (attri[0] != string.Empty)
                            objPhr.PharmacyID = Convert.ToInt32(attri[0]);
                        objPhr.PharmacyName = attri[1];
                        if (attri[2] != string.Empty)
                            objPhr.ShippingCharge = Convert.ToDecimal(attri[2]);
                        objPhr.DeliveryMinTime = Convert.ToInt32(attri[3]);
                        objPhr.DeliveryMaxTime = Convert.ToInt32(attri[4]);
                        objPhr.Discount = Convert.ToDecimal(attri[5]);
                    }
                }

                objPres.pharmacyDetail = objPhr;
            }

            if (values[21] != null && values[21] != string.Empty)
            {

                List<Diagnosis> objList = new List<Diagnosis>();
                foreach (string list in values[21].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Diagnosis objDrug = new Diagnosis();
                                if (attri[0] != string.Empty)
                                    objDrug.DiagnosisID = Convert.ToInt32(attri[0]);
                                objDrug.DiagnosisName = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.ClaimID = attri[2];
                                if (attri[3] != string.Empty)
                                    objDrug.patientid = Convert.ToInt32(attri[3]);
                                objDrug.filename = attri[4];
                                if (attri[5] != string.Empty)
                                    objDrug.ShowReport = Convert.ToInt32(attri[5]);
                                if (attri[6] != string.Empty)
                                    objDrug.AutoShowReport = Convert.ToInt32(attri[6]);
                                if (attri[7] != string.Empty)
                                    objDrug.DiagnosisCode = Convert.ToString(attri[7]);
                                if (attri[8] != string.Empty)
                                    objDrug.RESULT_VALUE = Convert.ToString(attri[8]);
                                objDrug.OrderId = Convert.ToString(attri[9]);
                                objList.Add(objDrug);
                            }
                        }
                    }
                }
                objPres.DiagnosisDetail = objList;
            }

            if (values[22] != null && values[22] != string.Empty)
            {
                List<Oderdetails> objList = new List<Oderdetails>();
                foreach (string list in values[22].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Oderdetails ObjOrder = new Oderdetails();
                                ObjOrder.order_id = attri[0];
                                ObjOrder.prescription_id = attri[1];
                                ObjOrder.address = attri[2];
                                ObjOrder.pin = attri[3];
                                ObjOrder.mobile_no = attri[4];
                                ObjOrder.city = attri[5];
                                ObjOrder.state = attri[6];
                                ObjOrder.orderdate = attri[7];
                                ObjOrder.pharmacyname = attri[8];
                                ObjOrder.Order_Amt = attri[9];

                                ObjOrder.diagnosticname = attri[10];
                                ObjOrder.order_type = attri[11];
                                ObjOrder.OrderStatus = attri[12];
                                ObjOrder.PayerOrderId = attri[13];
                                objList.Add(ObjOrder);
                            }
                        }
                    }
                }

                objPres.Orderdetails = objList;
            }


            if (values[23] != null && values[23] != string.Empty)
            {
                List<Procedure> objList = new List<Procedure>();
                foreach (string list in values[23].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Procedure ObjProc = new Procedure();
                                ObjProc.ProcedureID = Convert.ToInt32(attri[0]);
                                ObjProc.ProcedureCode = attri[1];
                                ObjProc.ProcedureName = attri[2];
                                ObjProc.ReportName = attri[3];
                                objList.Add(ObjProc);
                            }
                        }
                    }
                }

                objPres.Proclist = objList;
            }

            if (values[24] != null && values[24] != string.Empty)
            {
                List<Procedure> objList = new List<Procedure>();
                foreach (string list in values[24].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Procedure ObjTest = new Procedure();
                                ObjTest.ProcedureID = Convert.ToInt32(attri[0]);
                                ObjTest.ProcedureCode = attri[1];
                                ObjTest.ProcedureName = attri[2];
                                ObjTest.ReportName = attri[3];

                                objList.Add(ObjTest);
                            }
                        }
                    }
                }

                objPres.Testlist = objList;
            }

            if (values[25] != null && values[25] != string.Empty)
            {
                List<Diagnosis> objList = new List<Diagnosis>();
                foreach (string list in values[25].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Diagnosis ObjDiag = new Diagnosis();
                                ObjDiag.DiagnosisCode = attri[0];
                                ObjDiag.DiagnosisName = attri[1];

                                objList.Add(ObjDiag);
                            }
                        }
                    }
                }

                objPres.Diagnosis_ailment_Detail = objList;
            }

            if (values[26] != null && values[26] != string.Empty)
            {
                List<PrescriptionClass.complaint> objList = new List<PrescriptionClass.complaint>();
                foreach (string list in values[26].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                PrescriptionClass.complaint ObjComplaints = new PrescriptionClass.complaint();
                                ObjComplaints.name = attri[0];

                                objList.Add(ObjComplaints);
                            }
                        }
                    }
                }

                objPres.complaints = objList;
            }

            objPres.pharmacyId = values[27];
            if (values[28] != string.Empty)
                objPres.Is_health_check = Convert.ToInt32(values[28]);

            if (values[29] != null && values[29] != string.Empty)
            {
                objPres.HCU = new HealthCheckup();
                foreach (string list in values[29].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);

                                objPres.HCU.HCName = attri[0];

                            }
                        }
                    }
                }

            }
            if (values[30] != string.Empty)
                objPres.AutoShowReport = Convert.ToInt32(values[30]);


            if (values[31] != null && values[31] != string.Empty)
            {
                objPres.AttachmentsLst = new List<OP_Attachments>();
                foreach (string list in values[31].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                OP_Attachments objatt = new OP_Attachments();
                                objatt.AttachDate = attri[0];
                                objatt.AttachFileName = attri[1];
                                objatt.AttachmentRemarks = attri[2];
                                objatt.Claim_Id = attri[3];
                                objatt.FilePath = attri[4];
                                if (attri[5] != string.Empty)
                                    objatt.PatientId = Convert.ToInt32(attri[5]);
                                if (attri[6] != string.Empty)
                                    objatt.Self_ID = Convert.ToInt32(attri[6]);
                                objPres.AttachmentsLst.Add(objatt);
                            }
                        }
                    }
                }

            }

            if (values.Length > 32 && values[32] != null && values[32] != string.Empty)
            {
                objPres.VitalsLst = new List<Vital_Controls>();
                foreach (string list in values[32].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Vital_Controls obj1 = new Vital_Controls();
                                string[] attri = innerlist.Split(ListProperty_Split);
                                obj1.CONTROL_TEXT = attri[0];
                                obj1.CONTROL_TEXT_STYLE = attri[1];
                                obj1.CONTROL_TEXT_VALUE = attri[2];
                                obj1.CONTROL_TYPE = attri[3];
                                if (!string.IsNullOrWhiteSpace(attri[4]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(attri[4]);
                                if (!string.IsNullOrWhiteSpace(attri[5]))
                                    obj1.IS_EXPAND = Convert.ToInt32(attri[5]);
                                if (!string.IsNullOrWhiteSpace(attri[6]))
                                    obj1.IS_2TEXTBOX = Convert.ToInt32(attri[6]);
                                objPres.VitalsLst.Add(obj1);
                            }
                        }
                    }
                }

            }

            if (values.Length > 33 && values[33] != null && values[33] != string.Empty)
            {
                objPres.Diagnostic_Range = new List<DiagnosticRange>();
                foreach (string list in values[33].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                DiagnosticRange objDR = new DiagnosticRange();
                                objDR.DIAGNOSTIC_CODE = attri[0];
                                objDR.KEY = attri[1];
                                objDR.VALUE = attri[2];
                                objPres.Diagnostic_Range.Add(objDR);
                            }
                        }
                    }
                }

            }

            if (values[34] != null && values[34] != string.Empty)
            {
                List<PrescriptionClass.SecondaryAilment> objList = new List<PrescriptionClass.SecondaryAilment>();
                foreach (string list in values[34].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                PrescriptionClass.SecondaryAilment ObjComplaints = new PrescriptionClass.SecondaryAilment();
                                ObjComplaints.SecondaryAilmentname = attri[0];

                                objList.Add(ObjComplaints);
                            }
                        }
                    }
                }

                objPres.secondaryAilments = objList;
            }
            if (values[35] != null && values[35] != string.Empty)
            {
                objPres.Ailment_Details = new List<Ailment>();
                foreach (string list in values[35].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Ailment objail = new Ailment();
                                if (!string.IsNullOrEmpty(attri[0]))
                                    objail.AilmentID = Convert.ToInt16(attri[0]);
                                objail.AilmentName = attri[1];
                                objail.code = attri[2];
                                objPres.Ailment_Details.Add(objail);
                            }
                        }
                    }
                }

            }

            if (values.Length > 36)
            {
                objPres.Action_status = values[36];
            }
            if (values.Length > 37)
            {
                objPres.Action_status_Id = values[37];
            }
            if (values.Length > 38)
            {
                objPres.Payer_remarks = values[38];
            }
            if (values.Length > 39)
            {
                objPres.MemberID = values[39];
            }
            if (values.Length > 40)
            {
                objPres.patient_id = values[40];
            }
            return objPres;
        }


        public string GetPrescriptionDetail_Serialize_new(PrescriptionClass objpre, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objpre.prescriptionId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.physicianName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.patientName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.prescriptionDate);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ailmentName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.procedureName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PrescriptionType);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryCity);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryState);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryAddress);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryPinCode);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PrecFileName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PatientAge);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ServiceAccessTypeID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PatientGender);
            strOutPut.Append(split);
            strOutPut.Append(objpre.Remarks);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PharmacyRemarks);
            strOutPut.Append(split);
            strOutPut.Append(objpre.TreatmentMethod);
            strOutPut.Append(split);

            //consultation
            if (objpre.Consultation != null)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.Consultation.ConsultationFee);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Consultation.ReviewDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Consultation.Speciality);
                strOutPut.Append(ListElement_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //DrugList
            if (objpre.Druglist != null && objpre.Druglist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Drug objdrug in objpre.Druglist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objdrug.DrugID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DrugName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.NoOfDays);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DrugQuantity);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Afternoon);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Morning);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Night);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.BeforeFood);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DRUG_TYPE_DESC);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageA);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageM);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageN);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Evening);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //pharmacyDetail
            if (objpre.pharmacyDetail != null)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.pharmacyDetail.PharmacyID);
                strOutPut.Append(ListProperty_Split);
                _PharmacyId = objpre.pharmacyDetail.PharmacyID.ToString();
                strOutPut.Append(objpre.pharmacyDetail.PharmacyName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.ShippingCharge);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.DeliveryMinTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.DeliveryMaxTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.Discount);
                strOutPut.Append(ListElement_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Diagnostic list
            if (objpre.DiagnosisDetail != null && objpre.DiagnosisDetail.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis objdia in objpre.DiagnosisDetail)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objdia.DiagnosisID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.ClaimID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.patientid);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.filename);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.ShowReport);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.AutoShowReport);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.RESULT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.OrderId);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //Orderdetails
            if (objpre.Orderdetails != null && objpre.Orderdetails.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Oderdetails objOrder in objpre.Orderdetails)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objOrder.order_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.prescription_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.address);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.pin);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.mobile_no);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.city);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.state);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.orderdate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.pharmacyname);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.Order_Amt);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.diagnosticname);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.order_type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.OrderStatus);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.PayerOrderId);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);

            //minor procedure list
            if (objpre.Proclist != null && objpre.Proclist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Procedure objProc in objpre.Proclist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objProc.ProcedureID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objProc.ProcedureCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objProc.ProcedureName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objProc.ReportName);

                    //strOutPut.Append(ListProperty_Split);
                    //strOutPut.Append(objProc.UNITS);
                    //strOutPut.Append(ListProperty_Split);
                    //strOutPut.Append(objProc.UNIT_COST);
                    //strOutPut.Append(ListProperty_Split);
                    //strOutPut.Append(objProc.STANDARD_DISCOUNT);

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            //minor Test list
            if (objpre.Testlist != null && objpre.Testlist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Procedure objTest in objpre.Testlist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objTest.ProcedureID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.ProcedureCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.ProcedureName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.ReportName);

                    //strOutPut.Append(ListProperty_Split);
                    //strOutPut.Append(objTest.UNITS);
                    //strOutPut.Append(ListProperty_Split);
                    //strOutPut.Append(objTest.UNIT_COST);
                    //strOutPut.Append(ListProperty_Split);
                    //strOutPut.Append(objTest.STANDARD_DISCOUNT);

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            //Diagnosis or Ailment 
            if (objpre.Diagnosis_ailment_Detail != null && objpre.Diagnosis_ailment_Detail.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis ObjDiag in objpre.Diagnosis_ailment_Detail)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(ObjDiag.DiagnosisCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(ObjDiag.DiagnosisName);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            //Diagnosis or Ailment 
            if (objpre.complaints != null && objpre.complaints.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PrescriptionClass.complaint Complaints in objpre.complaints)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Complaints.name);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);

            strOutPut.Append(_PharmacyId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.Is_health_check);
            strOutPut.Append(split);

            //Health checkup 
            if (objpre.HCU != null)
            {
                strOutPut.Append(ListIdentifier_Start);
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.HCU.HCName);
                strOutPut.Append(ListElement_End);
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            strOutPut.Append(objpre.AutoShowReport);

            strOutPut.Append(split);
            //Attachment
            if (objpre.AttachmentsLst != null && objpre.AttachmentsLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (OP_Attachments obj in objpre.AttachmentsLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.AttachDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AttachFileName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AttachmentRemarks);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Claim_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.FilePath);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Self_ID);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Vitals 
            if (objpre.VitalsLst != null && objpre.VitalsLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Vital_Controls obj in objpre.VitalsLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.CONTROL_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_STYLE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXPAND);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_2TEXTBOX);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Diagnostic_Range
            if (objpre.Diagnostic_Range != null && objpre.Diagnostic_Range.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (DiagnosticRange obj in objpre.Diagnostic_Range)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DIAGNOSTIC_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.KEY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.VALUE);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            if (objpre.secondaryAilments != null && objpre.secondaryAilments.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PrescriptionClass.SecondaryAilment Complaints in objpre.secondaryAilments)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Complaints.SecondaryAilmentname);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            if (objpre.Ailment_Details != null && objpre.Ailment_Details.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Ailment objAil in objpre.Ailment_Details)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objAil.AilmentID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objAil.AilmentName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objAil.code);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);

            strOutPut.Append(objpre.is_checkbalance);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PayerPayable);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PatientPayable);
            strOutPut.Append(split);
            strOutPut.Append(objpre.total_billAmount);
            strOutPut.Append(split);

            //check balacne trans list
            if (objpre.checkbalance_trans_list != null && objpre.checkbalance_trans_list.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Procedure objTest in objpre.checkbalance_trans_list)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objTest.ProcedureID);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.ProcedureName);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.PayerPayable);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.PatientPayable);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.UNITS);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.UNIT_COST);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objTest.STANDARD_DISCOUNT);

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            strOutPut.Append(objpre.prescription_type);
            strOutPut.Append(split);
            strOutPut.Append(objpre.offlinePrescription.Presc_Date);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ReferalID);
            strOutPut.Append(split);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass GetPrescriptionDetail_Deserialize_new(string Response, string token)
        {
            PrescriptionClass objPres = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split); ;

            objPres.prescriptionId = values[0];
            objPres.physicianName = values[1];
            objPres.patientName = values[2];
            objPres.prescriptionDate = values[3];
            objPres.ailmentName = values[4];
            objPres.procedureName = values[5];
            if (values[6] != string.Empty)
                objPres.PrescriptionType = Convert.ToInt32(values[6]);
            objPres.DeliveryCity = values[7];
            objPres.DeliveryState = values[8];
            objPres.DeliveryAddress = values[9];
            objPres.DeliveryPinCode = values[10];
            objPres.PrecFileName = values[11];
            objPres.PatientAge = values[12];
            objPres.ServiceAccessTypeID = values[13];
            objPres.PatientGender = values[14];
            objPres.Remarks = values[15];
            objPres.PharmacyRemarks = values[16];
            objPres.TreatmentMethod = values[17];

            if (values[18] != null && values[18] != string.Empty)
            {
                Consultation obj = new Consultation();
                foreach (string innerlist in values[18].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        obj.ConsultationFee = attri[0];
                        obj.ReviewDate = attri[1];
                        obj.Speciality = attri[2];
                    }
                }
                objPres.Consultation = obj;
            }

            if (values[19] != null && values[19] != string.Empty)
            {
                List<Drug> objList = new List<Drug>();
                foreach (string list in values[19].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Drug objDrug = new Drug();
                                if (attri[0] != string.Empty)
                                    objDrug.DrugID = Convert.ToInt32(attri[0]);
                                objDrug.DrugName = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.NoOfDays = Convert.ToInt32(attri[2]);
                                if (attri[3] != string.Empty)
                                    objDrug.DrugQuantity = Convert.ToInt32(attri[3]);
                                if (attri[4] != string.Empty)
                                    objDrug.Afternoon = Convert.ToDecimal(attri[4]);
                                if (attri[5] != string.Empty)
                                    objDrug.Morning = Convert.ToDecimal(attri[5]);
                                if (attri[6] != string.Empty)
                                    objDrug.Night = Convert.ToDecimal(attri[6]);
                                if (attri[7] != string.Empty)
                                    objDrug.BeforeFood = Convert.ToInt32(attri[7]);
                                objDrug.DRUG_TYPE_DESC = attri[8];
                                objDrug.DosageA = attri[9];
                                objDrug.DosageM = attri[10];
                                objDrug.DosageN = attri[11];
                                if (attri[12] != string.Empty)
                                    objDrug.Evening = Convert.ToDecimal(attri[12]);
                                objList.Add(objDrug);
                            }
                        }
                    }
                }
                objPres.Druglist = objList;
            }

            if (values[20] != null && values[20] != string.Empty)
            {
                Pharmacy objPhr = new Pharmacy();
                foreach (string innerlist in values[20].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        if (attri[0] != string.Empty)
                            objPhr.PharmacyID = Convert.ToInt32(attri[0]);
                        objPhr.PharmacyName = attri[1];
                        if (attri[2] != string.Empty)
                            objPhr.ShippingCharge = Convert.ToDecimal(attri[2]);
                        objPhr.DeliveryMinTime = Convert.ToInt32(attri[3]);
                        objPhr.DeliveryMaxTime = Convert.ToInt32(attri[4]);
                        objPhr.Discount = Convert.ToDecimal(attri[5]);
                    }
                }

                objPres.pharmacyDetail = objPhr;
            }

            if (values[21] != null && values[21] != string.Empty)
            {

                List<Diagnosis> objList = new List<Diagnosis>();
                foreach (string list in values[21].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Diagnosis objDrug = new Diagnosis();
                                if (attri[0] != string.Empty)
                                    objDrug.DiagnosisID = Convert.ToInt32(attri[0]);
                                objDrug.DiagnosisName = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.ClaimID = attri[2];
                                if (attri[3] != string.Empty)
                                    objDrug.patientid = Convert.ToInt32(attri[3]);
                                objDrug.filename = attri[4];
                                if (attri[5] != string.Empty)
                                    objDrug.ShowReport = Convert.ToInt32(attri[5]);
                                if (attri[6] != string.Empty)
                                    objDrug.AutoShowReport = Convert.ToInt32(attri[6]);
                                if (attri[7] != string.Empty)
                                    objDrug.DiagnosisCode = Convert.ToString(attri[7]);
                                if (attri[8] != string.Empty)
                                    objDrug.RESULT_VALUE = Convert.ToString(attri[8]);
                                objDrug.OrderId = Convert.ToString(attri[9]);
                                objList.Add(objDrug);
                            }
                        }
                    }
                }
                objPres.DiagnosisDetail = objList;
            }

            if (values[22] != null && values[22] != string.Empty)
            {
                List<Oderdetails> objList = new List<Oderdetails>();
                foreach (string list in values[22].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Oderdetails ObjOrder = new Oderdetails();
                                ObjOrder.order_id = attri[0];
                                ObjOrder.prescription_id = attri[1];
                                ObjOrder.address = attri[2];
                                ObjOrder.pin = attri[3];
                                ObjOrder.mobile_no = attri[4];
                                ObjOrder.city = attri[5];
                                ObjOrder.state = attri[6];
                                ObjOrder.orderdate = attri[7];
                                ObjOrder.pharmacyname = attri[8];
                                ObjOrder.Order_Amt = attri[9];

                                ObjOrder.diagnosticname = attri[10];
                                ObjOrder.order_type = attri[11];
                                ObjOrder.OrderStatus = attri[12];
                                ObjOrder.PayerOrderId = attri[13];
                                objList.Add(ObjOrder);
                            }
                        }
                    }
                }

                objPres.Orderdetails = objList;
            }


            if (values[23] != null && values[23] != string.Empty)
            {
                List<Procedure> objList = new List<Procedure>();
                foreach (string list in values[23].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Procedure ObjProc = new Procedure();
                                ObjProc.ProcedureID = Convert.ToInt32(attri[0]);
                                ObjProc.ProcedureCode = attri[1];
                                ObjProc.ProcedureName = attri[2];
                                ObjProc.ReportName = attri[3];
                                objList.Add(ObjProc);
                            }
                        }
                    }
                }

                objPres.Proclist = objList;
            }

            if (values[24] != null && values[24] != string.Empty)
            {
                List<Procedure> objList = new List<Procedure>();
                foreach (string list in values[24].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Procedure ObjTest = new Procedure();
                                ObjTest.ProcedureID = Convert.ToInt32(attri[0]);
                                ObjTest.ProcedureCode = attri[1];
                                ObjTest.ProcedureName = attri[2];
                                ObjTest.ReportName = attri[3];

                                objList.Add(ObjTest);
                            }
                        }
                    }
                }

                objPres.Testlist = objList;
            }

            if (values[25] != null && values[25] != string.Empty)
            {
                List<Diagnosis> objList = new List<Diagnosis>();
                foreach (string list in values[25].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Diagnosis ObjDiag = new Diagnosis();
                                ObjDiag.DiagnosisCode = attri[0];
                                ObjDiag.DiagnosisName = attri[1];

                                objList.Add(ObjDiag);
                            }
                        }
                    }
                }

                objPres.Diagnosis_ailment_Detail = objList;
            }

            if (values[26] != null && values[26] != string.Empty)
            {
                List<PrescriptionClass.complaint> objList = new List<PrescriptionClass.complaint>();
                foreach (string list in values[26].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                PrescriptionClass.complaint ObjComplaints = new PrescriptionClass.complaint();
                                ObjComplaints.name = attri[0];

                                objList.Add(ObjComplaints);
                            }
                        }
                    }
                }

                objPres.complaints = objList;
            }

            objPres.pharmacyId = values[27];
            if (values[28] != string.Empty)
                objPres.Is_health_check = Convert.ToInt32(values[28]);

            if (values[29] != null && values[29] != string.Empty)
            {
                objPres.HCU = new HealthCheckup();
                foreach (string list in values[29].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);

                                objPres.HCU.HCName = attri[0];

                            }
                        }
                    }
                }

            }
            if (values[30] != string.Empty)
                objPres.AutoShowReport = Convert.ToInt32(values[30]);


            if (values[31] != null && values[31] != string.Empty)
            {
                objPres.AttachmentsLst = new List<OP_Attachments>();
                foreach (string list in values[31].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                OP_Attachments objatt = new OP_Attachments();
                                objatt.AttachDate = attri[0];
                                objatt.AttachFileName = attri[1];
                                objatt.AttachmentRemarks = attri[2];
                                objatt.Claim_Id = attri[3];
                                objatt.FilePath = attri[4];
                                if (attri[5] != string.Empty)
                                    objatt.PatientId = Convert.ToInt32(attri[5]);
                                if (attri[6] != string.Empty)
                                    objatt.Self_ID = Convert.ToInt32(attri[6]);
                                objPres.AttachmentsLst.Add(objatt);
                            }
                        }
                    }
                }

            }

            if (values.Length > 32 && values[32] != null && values[32] != string.Empty)
            {
                objPres.VitalsLst = new List<Vital_Controls>();
                foreach (string list in values[32].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Vital_Controls obj1 = new Vital_Controls();
                                string[] attri = innerlist.Split(ListProperty_Split);
                                obj1.CONTROL_TEXT = attri[0];
                                obj1.CONTROL_TEXT_STYLE = attri[1];
                                obj1.CONTROL_TEXT_VALUE = attri[2];
                                obj1.CONTROL_TYPE = attri[3];
                                if (!string.IsNullOrWhiteSpace(attri[4]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(attri[4]);
                                if (!string.IsNullOrWhiteSpace(attri[5]))
                                    obj1.IS_EXPAND = Convert.ToInt32(attri[5]);
                                if (!string.IsNullOrWhiteSpace(attri[6]))
                                    obj1.IS_2TEXTBOX = Convert.ToInt32(attri[6]);
                                objPres.VitalsLst.Add(obj1);
                            }
                        }
                    }
                }

            }

            if (values.Length > 33 && values[33] != null && values[33] != string.Empty)
            {
                objPres.Diagnostic_Range = new List<DiagnosticRange>();
                foreach (string list in values[33].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                DiagnosticRange objDR = new DiagnosticRange();
                                objDR.DIAGNOSTIC_CODE = attri[0];
                                objDR.KEY = attri[1];
                                objDR.VALUE = attri[2];
                                objPres.Diagnostic_Range.Add(objDR);
                            }
                        }
                    }
                }

            }

            if (values[34] != null && values[34] != string.Empty)
            {
                List<PrescriptionClass.SecondaryAilment> objList = new List<PrescriptionClass.SecondaryAilment>();
                foreach (string list in values[34].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                PrescriptionClass.SecondaryAilment ObjComplaints = new PrescriptionClass.SecondaryAilment();
                                ObjComplaints.SecondaryAilmentname = attri[0];

                                objList.Add(ObjComplaints);
                            }
                        }
                    }
                }

                objPres.secondaryAilments = objList;
            }
            if (values[35] != null && values[35] != string.Empty)
            {
                objPres.Ailment_Details = new List<Ailment>();
                foreach (string list in values[35].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Ailment objail = new Ailment();
                                if (!string.IsNullOrEmpty(attri[0]))
                                    objail.AilmentID = Convert.ToInt16(attri[0]);
                                objail.AilmentName = attri[1];
                                objail.code = attri[2];
                                objPres.Ailment_Details.Add(objail);
                            }
                        }
                    }
                }

            }

            if (values[36] != null && values[36] != string.Empty)
            {
                objPres.is_checkbalance = values[36];
            }
            if (values[37] != null && values[37] != string.Empty)
            {
                objPres.PayerPayable = values[37];
            }
            if (values[38] != null && values[38] != string.Empty)
            {
                objPres.PatientPayable = values[38];
            }
            if (values[39] != null && values[39] != string.Empty)
            {
                objPres.total_billAmount = values[39];
            }

            if (values[39] != null && values[39] != string.Empty)
            {
                objPres.total_billAmount = values[39];
            }

            if (values[40] != null && values[40] != string.Empty)
            {
                List<Procedure> objList = new List<Procedure>();
                foreach (string list in values[40].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Procedure ObjProc = new Procedure();
                                ObjProc.ProcedureID = Convert.ToInt32(attri[0]);
                                ObjProc.ProcedureName = attri[1];
                                ObjProc.PayerPayable = attri[2];
                                ObjProc.PatientPayable = attri[3];

                                ObjProc.UNITS = attri[4];
                                ObjProc.UNIT_COST = attri[5];
                                ObjProc.STANDARD_DISCOUNT = attri[6];
                                objList.Add(ObjProc);
                            }
                        }
                    }
                }



                objPres.checkbalance_trans_list = objList;
            }

            if (values[41] != null && values[41] != string.Empty)
            {
                objPres.prescription_type = Convert.ToInt32(values[41]);
            }
            if (values.Count() > 42 && values[42] != null)
            {
                PrescriptionUpload offlinePresc = new PrescriptionUpload();
                objPres.offlinePrescription = offlinePresc;
                objPres.offlinePrescription.Presc_Date = values[42];
            }
            if (values[43] != null)
            {
                objPres.ReferalID = values[43];
            }
            return objPres;
        }


        public string GetPaymentBreakupDetails_Serialize(List<PaymentBreakupDetails> objPay, string token)
        {
            StringBuilder strPayemnt = new StringBuilder();
            strPayemnt.Append(ListIdentifier_Start);
            foreach (PaymentBreakupDetails PayBreak in objPay)
            {
                strPayemnt.Append(ListElement_Start);

                strPayemnt.Append(PayBreak.CLAIM_ID);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.Transcation_Type);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.Bill_Amt);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.PatientPay_Amt);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.PayerPay_Amt);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.EntityName);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.OrderID);
                strPayemnt.Append(ListProperty_Split);

                //PolicyValDetails
                strPayemnt.Append(Inner_ListIdentifier_Start);
                foreach (PolicyValDetails polval in PayBreak.PolValDet)
                {
                    strPayemnt.Append(Inner_ListElement_Start);
                    strPayemnt.Append(polval.Message);
                    strPayemnt.Append(Inner_ListProperty_Split);
                    strPayemnt.Append(polval.Value);
                    strPayemnt.Append(Inner_ListProperty_Split);
                    strPayemnt.Append(polval.transaction_type);
                    strPayemnt.Append(Inner_ListProperty_Split);
                    // strPayemnt.Append(polval.value_desc);
                    // strPayemnt.Append(Inner_ListProperty_Split);
                    strPayemnt.Append(polval.Message_type);
                    strPayemnt.Append(Inner_ListElement_End);
                }
                strPayemnt.Append(Inner_ListIdentifier_End);

                strPayemnt.Append(ListProperty_Split);

                //IncluExcluDetails
                strPayemnt.Append(Inner_ListIdentifier_Start);
                foreach (IncluExcluDetails objIncExl in PayBreak.IncExcDet)
                {
                    strPayemnt.Append(Inner_ListElement_Start);
                    strPayemnt.Append(objIncExl.Message);
                    strPayemnt.Append(Inner_ListElement_End);
                }
                strPayemnt.Append(Inner_ListIdentifier_End);

                strPayemnt.Append(ListProperty_Split);

                //CappingDetails
                strPayemnt.Append(Inner_ListIdentifier_Start);
                foreach (CappingDetails objCapping in PayBreak.CappingDet)
                {
                    strPayemnt.Append(Inner_ListElement_Start);
                    strPayemnt.Append(objCapping.Name);
                    strPayemnt.Append(Inner_ListProperty_Split);
                    strPayemnt.Append(objCapping.Value);
                    strPayemnt.Append(Inner_ListElement_End);
                }
                strPayemnt.Append(Inner_ListIdentifier_End);
                strPayemnt.Append(ListProperty_Split);
                //CopayDetails
                strPayemnt.Append(Inner_ListIdentifier_Start);
                foreach (CopayDetails objCopay in PayBreak.CopayDet)
                {
                    strPayemnt.Append(Inner_ListElement_Start);
                    strPayemnt.Append(objCopay.Name);
                    strPayemnt.Append(Inner_ListProperty_Split);
                    strPayemnt.Append(objCopay.Value);
                    strPayemnt.Append(Inner_ListElement_End);
                }
                strPayemnt.Append(Inner_ListIdentifier_End);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.OneMgOrderId);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(PayBreak.PayerOrderID);
                strPayemnt.Append(ListProperty_Split);
                //service charge added
                strPayemnt.Append(PayBreak.Service_charge);
                strPayemnt.Append(ListElement_End);
            }
           

            strPayemnt.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strPayemnt.ToString(), token);
        }


        public List<PaymentBreakupDetails> GetPaymentBreakupDetails_Deserialize(string Response, string token)
        {
            List<PaymentBreakupDetails> objPayBreakList = new List<PaymentBreakupDetails>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    PaymentBreakupDetails objbreak = new PaymentBreakupDetails();
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        objbreak = new PaymentBreakupDetails();
                        if (innerlist != string.Empty)
                        {
                            string[] objbreakPro = innerlist.Split(ListProperty_Split);
                            if (objbreakPro[0] != string.Empty)
                                objbreak.CLAIM_ID = objbreakPro[0];
                            if (objbreakPro[1] != string.Empty)
                                objbreak.Transcation_Type = Convert.ToInt32(objbreakPro[1]);
                            if (objbreakPro[2] != string.Empty)
                                objbreak.Bill_Amt = Convert.ToDecimal(objbreakPro[2]);
                            if (objbreakPro[3] != string.Empty)
                                objbreak.PatientPay_Amt = Convert.ToDecimal(objbreakPro[3]);
                            if (objbreakPro[4] != string.Empty)
                                objbreak.PayerPay_Amt = Convert.ToDecimal(objbreakPro[4]);
                            objbreak.EntityName = objbreakPro[5];
                            if (objbreakPro[6] != string.Empty)
                                objbreak.OrderID = objbreakPro[6];
                           
                            if (objbreakPro[7] != null && objbreakPro[7] != string.Empty)
                            {
                                List<PolicyValDetails> objpollist = new List<PolicyValDetails>();
                                foreach (string innerlist1 in objbreakPro[7].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (innerlist1 != string.Empty)
                                    {
                                        foreach (string innerElement1 in innerlist1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerElement1 != string.Empty)
                                            {
                                                PolicyValDetails objPol = new PolicyValDetails();
                                                string[] PolAttri = innerElement1.Split(Inner_ListProperty_Split);
                                                objPol.Message = PolAttri[0];
                                                objPol.Value = PolAttri[1];
                                                objPol.transaction_type = PolAttri[2];
                                                //objPol.value_desc = PolAttri[3];
                                                objPol.Message_type = PolAttri[3];
                                                objpollist.Add(objPol);
                                            }
                                        }

                                    }
                                }
                                objbreak.PolValDet = objpollist;
                            }

                            if (objbreakPro[8] != null && objbreakPro[8] != string.Empty)
                            {
                                List<IncluExcluDetails> objExcllist = new List<IncluExcluDetails>();
                                foreach (string innerlist1 in objbreakPro[8].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (innerlist1 != string.Empty)
                                    {
                                        foreach (string innerElement1 in innerlist1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerElement1 != string.Empty)
                                            {
                                                IncluExcluDetails objExcl = new IncluExcluDetails();
                                                string[] PolAttri = innerElement1.Split(Inner_ListProperty_Split);
                                                objExcl.Message = PolAttri[0];
                                                objExcllist.Add(objExcl);
                                            }
                                        }

                                    }
                                }
                                objbreak.IncExcDet = objExcllist;
                            }

                            if (objbreakPro[9] != null && objbreakPro[9] != string.Empty)
                            {
                                List<CappingDetails> objcaplist = new List<CappingDetails>();
                                foreach (string innerlist1 in objbreakPro[9].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (innerlist1 != string.Empty)
                                    {
                                        foreach (string innerElement1 in innerlist1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerElement1 != string.Empty)
                                            {
                                                CappingDetails objCap = new CappingDetails();
                                                string[] PolAttri = innerElement1.Split(Inner_ListProperty_Split);
                                                objCap.Name = PolAttri[0];
                                                objCap.Value = PolAttri[1];
                                                objcaplist.Add(objCap);
                                            }
                                        }

                                    }
                                }
                                objbreak.CappingDet = objcaplist;
                            }

                            if (objbreakPro[10] != null && objbreakPro[10] != string.Empty)
                            {
                                List<CopayDetails> objcopaylist = new List<CopayDetails>();
                                foreach (string innerlist1 in objbreakPro[10].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (innerlist1 != string.Empty)
                                    {
                                        foreach (string innerElement1 in innerlist1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerElement1 != string.Empty)
                                            {
                                                CopayDetails objcopay = new CopayDetails();
                                                string[] PolAttri = innerElement1.Split(Inner_ListProperty_Split);
                                                objcopay.Name = PolAttri[0];
                                                objcopay.Value = PolAttri[1];
                                                objcopaylist.Add(objcopay);
                                            }
                                        }

                                    }
                                }
                                objbreak.CopayDet = objcopaylist;
                            }
                            if (objbreakPro[11] != null && objbreakPro[11] != string.Empty)
                            {
                                objbreak.OneMgOrderId = objbreakPro[11];
                            }
                            if (objbreakPro[12] != null && objbreakPro[12] != string.Empty)
                            {
                                objbreak.PayerOrderID = objbreakPro[12];
                            }

                            //service charge added
                            if (objbreakPro[13] != null && objbreakPro[13] != string.Empty)
                                objbreak.Service_charge = Convert.ToDecimal(objbreakPro[13]);

                            objPayBreakList.Add(objbreak);
                        }

                    }

                }
            }

            return objPayBreakList;
        }


        //for resendotp

        public string GetIntegrationDetails_Serialize(List<OTPIntegrationDetails> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();

            outPut.Append(ListIdentifier_Start);
            foreach (OTPIntegrationDetails objDrug in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objDrug.OTP_VALUE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.EntityCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.PatientPayable);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.PatientMobileNo);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.AppointmentID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.patient_id);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        //end resend otp

        //resend

        public List<OTPIntegrationDetails> GetIntegrationDetails_Deserialize(string Response, string token)
        {
            List<OTPIntegrationDetails> OtpList = new List<OTPIntegrationDetails>();
            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            OTPIntegrationDetails objRecpt = new OTPIntegrationDetails();
                            string[] attri = innerlist.Split(ListProperty_Split);

                            objRecpt.OTP_VALUE = attri[0];
                            objRecpt.EntityCode = attri[1];
                            objRecpt.PatientPayable = attri[2];
                            objRecpt.PatientMobileNo = attri[3];
                            objRecpt.AppointmentID = attri[4];
                            objRecpt.patient_id = attri[5];
                            OtpList.Add(objRecpt);
                        }
                    }
                }
            }

            return OtpList;
        }


        //end resend

        public string GetClinicalFindings_Serialize(List<ClinicalFind> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            if (Response != null)
            {
                foreach (ClinicalFind objClincFind in Response)
                {
                    outPut.Append(ListElement_Start);
                    outPut.Append(objClincFind.BP);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.CVS);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Pulse);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.SugarA);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.SugarB);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Temperature);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Weight);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Remarks);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.MemberId);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.PatientID);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.ClaimID);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.VitalId);
                    outPut.Append(ListProperty_Split);

                    if (objClincFind.Reports != null)
                    {
                        outPut.Append(Inner_ListIdentifier_Start);
                        foreach (OP_Attachments objreport in objClincFind.Reports)
                        {
                            outPut.Append(Inner_ListElement_Start);
                            outPut.Append(objreport.PatientId);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objreport.AttachFileName);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objreport.AttachmentRemarks);
                            outPut.Append(Inner_ListElement_End);
                        }

                        outPut.Append(Inner_ListIdentifier_End);

                    }
                    else
                    {
                        outPut.Append("");
                    }

                    outPut.Append(ListElement_End);
                }
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }


        public List<ClinicalFind> GetClinicalFindings_Deserialize(string Response, string token)
        {
            List<ClinicalFind> objClFindList = new List<ClinicalFind>();
            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {

                        if (innerlist != string.Empty)
                        {
                            ClinicalFind objClFind = new ClinicalFind();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objClFind.BP = attri[0];
                            objClFind.CVS = attri[1];
                            objClFind.Pulse = attri[2];
                            objClFind.SugarA = attri[3];
                            objClFind.SugarB = attri[4];
                            objClFind.Temperature = attri[5];
                            objClFind.Weight = attri[6];
                            objClFind.Remarks = attri[7];
                            objClFind.MemberId = attri[8];
                            if (!string.IsNullOrEmpty(attri[9]))
                                objClFind.PatientID = Convert.ToInt32(attri[9]);
                            objClFind.ClaimID = attri[10];
                            objClFind.VitalId = attri[11];

                            if (!string.IsNullOrEmpty(attri[12]))
                            {
                                List<OP_Attachments> Objreports = new List<OP_Attachments>();
                                foreach (string innerlist1 in attri[12].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (innerlist1 != string.Empty)
                                    {
                                        foreach (string innerElement1 in innerlist1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerElement1 != string.Empty)
                                            {
                                                OP_Attachments objAttachment = new OP_Attachments();
                                                string[] attri1 = innerElement1.Split(Inner_ListProperty_Split);
                                                if (attri1[0] != string.Empty)
                                                    objAttachment.PatientId = Convert.ToInt32(attri1[0]);
                                                objAttachment.AttachFileName = attri1[1];
                                                objAttachment.AttachmentRemarks = attri1[2];
                                                Objreports.Add(objAttachment);
                                            }
                                        }
                                    }
                                    objClFind.Reports = Objreports;
                                }

                            }
                            objClFindList.Add(objClFind);
                        }

                    }
                }
            }
            return objClFindList;
        }

        public string GetDrugMaster_Serialize(List<Drug> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();

            outPut.Append(ListIdentifier_Start);
            foreach (Drug objDrug in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objDrug.DrugID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.DrugName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.DrugCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.DrugQuantity);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDrug.DRUG_TYPE_DESC);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Drug> GetDrugMaster_Deserialize(string Response, string token)
        {
            List<Drug> ObjDrugList = new List<Drug>();

            string StrResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in StrResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {

                        if (innerlist != string.Empty)
                        {
                            Drug objDrug = new Drug();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objDrug.DrugID = Convert.ToInt32(attri[0]);
                            objDrug.DrugName = attri[1];
                            objDrug.DrugCode = attri[2];
                            if (attri[3] != string.Empty)
                                objDrug.DrugQuantity = Convert.ToInt32(attri[3]);
                            objDrug.DRUG_TYPE_DESC = attri[4];
                            ObjDrugList.Add(objDrug);
                        }

                    }
                }
            }
            return ObjDrugList;
        }


        public string GetPharmacyDetails_Serialize(List<RN.MOBILE_COMMON.Pharmacy> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (Pharmacy objPhar in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objPhar.PharmacyID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.PharmacyName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.PharmacyType);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.ShippingCharge);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.DeliveryMinTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.DeliveryMaxTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.Discount);
                outPut.Append(ListProperty_Split);
                //Drug list
                if (objPhar.Drugs != null)
                {
                    outPut.Append(Inner_ListIdentifier_Start);
                    foreach (Drug objDrug in objPhar.Drugs)
                    {
                        outPut.Append(Inner_ListElement_Start);
                        outPut.Append(objDrug.DrugID);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.DrugName);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.Rate);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.NoOfDays);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.Morning);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.Afternoon);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.Night);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.Evening);
                        outPut.Append(Inner_ListElement_End);
                    }
                    outPut.Append(Inner_ListIdentifier_End);
                }
                outPut.Append(ListProperty_Split);

                outPut.Append(objPhar.BillAmt);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.EntityCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.EntityKey);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.onlineOrderFlow);
                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<RN.MOBILE_COMMON.Pharmacy> GetPharmacyDetails_Deserialize(string Response, string token)
        {
            List<RN.MOBILE_COMMON.Pharmacy> objListPhar = new List<Pharmacy>();

            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {

                        if (innerlist != string.Empty)
                        {
                            Pharmacy objPhar = new Pharmacy();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objPhar.PharmacyID = Convert.ToInt32(attri[0]);
                            objPhar.PharmacyName = attri[1];
                            if (attri[2] != string.Empty)
                                objPhar.PharmacyType = Convert.ToInt32(attri[2]);
                            if (attri[3] != string.Empty)
                                objPhar.ShippingCharge = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                objPhar.DeliveryMinTime = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                objPhar.DeliveryMaxTime = Convert.ToInt32(attri[5]);
                            if (attri[6] != string.Empty)
                                objPhar.Discount = Convert.ToInt32(attri[6]);
                            if (attri[7] != null && attri[7] != string.Empty)
                            {
                                foreach (string List1 in attri[7].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (List1 != string.Empty)
                                    {
                                        List<Drug> objListDrug = new List<Drug>();

                                        foreach (string innerlist1 in list.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Drug objDrug = new Drug();
                                                string[] attri1 = innerlist.Split(Inner_ListProperty_Split);
                                                if (attri1[0] != string.Empty)
                                                    objDrug.DrugID = Convert.ToInt32(attri1[0]);
                                                objDrug.DrugName = attri1[1];
                                                objDrug.DrugCode = attri1[2];
                                                if (attri1[3] != string.Empty)
                                                    objDrug.Rate = Convert.ToDecimal(attri1[3]);
                                                if (attri1[4] != string.Empty)
                                                    objDrug.NoOfDays = Convert.ToInt32(attri1[4]);
                                                if (attri1[5] != string.Empty)
                                                    objDrug.Morning = Convert.ToDecimal(attri1[5]);
                                                if (attri1[6] != string.Empty)
                                                    objDrug.Afternoon = Convert.ToDecimal(attri1[6]);
                                                if (attri1[7] != string.Empty)
                                                    objDrug.Night = Convert.ToDecimal(attri1[7]);
                                                if (attri1[8] != string.Empty)
                                                    objDrug.Evening = Convert.ToDecimal(attri1[8]);
                                                objListDrug.Add(objDrug);
                                            }
                                        }

                                        objPhar.Drugs = objListDrug;
                                    }
                                }
                            }
                            if (attri[8] != string.Empty)
                                objPhar.BillAmt = Convert.ToDecimal(attri[8]);
                            objPhar.EntityCode = attri[9];
                            objPhar.EntityKey = attri[10];
                            objPhar.onlineOrderFlow = Convert.ToInt32(attri[11]);
                            objListPhar.Add(objPhar);
                        }

                    }
                }
            }
            return objListPhar;
        }

        public string GetAvailableRecieptDetails_Serialize(List<RecieptDetails> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();

            objOutPut.Append(ListIdentifier_Start);

            foreach (RecieptDetails objRecipt in Response)
            {
                objOutPut.Append(ListElement_Start);

                objOutPut.Append(objRecipt.BILL_AMOUNT);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.CLAIM_ID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.ORDER_ID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.PATIENT_PAYABLE);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.PAYABLE_AMOUNT);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.PAYER_PAYABLE);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.TRANSACTION_TYPE);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.PAYER_ORDER_ID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.PHARMACY_TYPE);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.AGGREGATOR_TYPE);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.INVOICE_FILENAME);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objRecipt.online_order_flow);
                objOutPut.Append(ListElement_End);
            }

            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }

        public List<RecieptDetails> GetAvailableRecieptDetails_Deserialize(string Response, string token)
        {
            List<RecieptDetails> RecptList = new List<RecieptDetails>();
            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            RecieptDetails objRecpt = new RecieptDetails();
                            string[] attri = innerlist.Split(ListProperty_Split);

                            objRecpt.BILL_AMOUNT = attri[0];
                            objRecpt.CLAIM_ID = attri[1];
                            objRecpt.ORDER_ID = attri[2];
                            objRecpt.PATIENT_PAYABLE = attri[3];
                            objRecpt.PAYABLE_AMOUNT = attri[4];
                            objRecpt.PAYER_PAYABLE = attri[5];
                            if (attri[6] != string.Empty)
                                objRecpt.TRANSACTION_TYPE = Convert.ToInt32(attri[6]);
                            if (attri[7] != string.Empty)
                                objRecpt.PAYER_ORDER_ID = Convert.ToString(attri[7]);
                            if (attri[8] != string.Empty)
                                objRecpt.PHARMACY_TYPE = Convert.ToString(attri[8]);
                            if (attri[9] != string.Empty)
                                objRecpt.AGGREGATOR_TYPE = Convert.ToString(attri[9]);
                            if (attri[10] != string.Empty)
                                objRecpt.INVOICE_FILENAME = Convert.ToString(attri[10]);
                            if (attri[11] != string.Empty)
                                objRecpt.online_order_flow = Convert.ToString(attri[11]);
                            RecptList.Add(objRecpt);
                        }
                    }
                }
            }

            return RecptList;
        }

        public string GetDiagnosisDashboarddetails_Serialize(List<RN.MOBILE_COMMON.Diagnosis> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Diagnosis objDiag in Response)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objDiag.ClaimID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objDiag.Patientname);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objDiag.patientid);
                strOutPut.Append(ListProperty_Split);
                if (objDiag.lst != null && objDiag.lst.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Diagnosis objlst in objDiag.lst)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objlst.DiagnosisName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.DiagnosisID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.ClaimID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.Date);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.filename);
                        strOutPut.Append(Inner_ListElement_End);
                    }

                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<RN.MOBILE_COMMON.Diagnosis> GetDiagnosisDashboarddetails_Deserialize(string Resposne, string token)
        {
            List<RN.MOBILE_COMMON.Diagnosis> lstDiag = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Resposne, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnosis objDiag = new Diagnosis();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objDiag.ClaimID = attri[0];
                            objDiag.Patientname = attri[1];
                            if (attri[2] != string.Empty)
                                objDiag.patientid = Convert.ToInt32(attri[2]);

                            if (attri[3] != string.Empty)
                            {
                                List<RN.MOBILE_COMMON.Diagnosis> lstDiag1 = new List<Diagnosis>();
                                foreach (string list1 in attri[3].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Diagnosis objDiag1 = new Diagnosis();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objDiag1.DiagnosisName = attri1[0];
                                                if (attri1[1] != string.Empty)
                                                    objDiag1.DiagnosisID = Convert.ToInt32(attri1[1]);
                                                if (attri1[2] != string.Empty)
                                                    objDiag1.ClaimID = attri1[2];
                                                objDiag1.Date = attri1[3];
                                                objDiag1.filename = attri1[4];
                                                lstDiag1.Add(objDiag1);
                                            }
                                        }
                                    }
                                }
                                objDiag.lst = lstDiag1;
                            }
                            lstDiag.Add(objDiag);
                        }
                    }
                }
            }
            return lstDiag;
        }

        public string GetDependant_Serialize(List<Patient> Resposne, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            if (Resposne != null)
            {
                foreach (Patient objPat in Resposne)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objPat.UserName);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.PatienID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.MobileNo);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.Address);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.PINCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.EmailID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.GenderID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.Age);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.DOB);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.RelationShipID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objPat.RelationShipName);
                    objOutPut.Append(ListElement_End);
                }

            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }

        public List<Patient> GetDependant_Deserialize(string Response, string token)
        {
            List<Patient> objpatlist = new List<Patient>();
            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Patient objpat = new Patient();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objpat.UserName = attri[0];
                            if (attri[1] != string.Empty)
                                objpat.PatienID = Convert.ToInt32(attri[1]);
                            objpat.MobileNo = attri[2];
                            objpat.Address = attri[3];
                            objpat.PINCode = attri[4];
                            objpat.EmailID = attri[5];
                            if (attri[6] != string.Empty)
                                objpat.CityID = Convert.ToInt32(attri[6]);
                            if (attri[7] != string.Empty)
                                objpat.GenderID = Convert.ToInt32(attri[7]);
                            if (attri[8] != string.Empty)
                                objpat.Age = Convert.ToInt32(attri[8]);
                            objpat.DOB = attri[9];
                            if (attri[10] != string.Empty)
                                objpat.RelationShipID = Convert.ToInt32(attri[10]);
                            objpat.RelationShipName = attri[11];
                            objpatlist.Add(objpat);
                        }
                    }
                }
            }
            return objpatlist;
        }

        public string GetClinicalFindHistory_Serialize(List<ClinicalFind> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            foreach (ClinicalFind objClinic in Response)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(objClinic.PatientID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.ClaimID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.BP);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.Pulse);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.Temperature);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.Weight);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.SugarA);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.SugarB);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.Remarks);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.PatientName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.MonitorDate);
                objOutPut.Append(ListProperty_Split);
                if (objClinic.Ailment != null)
                {
                    objOutPut.Append(objClinic.Ailment.AilmentName);
                }
                else
                {
                    objOutPut.Append("");
                }
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.CVS);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objClinic.VitalId);
                objOutPut.Append(ListElement_End);
            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }

        public List<ClinicalFind> GetClinicalFindHistory_Deserialize(string Resposne, string token)
        {
            List<ClinicalFind> ClincList = new List<ClinicalFind>();
            string strResponse = StringCipher.Decrypt(Resposne, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            ClinicalFind objClinic = new ClinicalFind();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objClinic.PatientID = Convert.ToInt32(attri[0]);
                            if (attri[1] != string.Empty)
                                objClinic.ClaimID = attri[1];
                            objClinic.BP = attri[2];
                            objClinic.Pulse = attri[3];
                            objClinic.Temperature = attri[4];
                            objClinic.Weight = attri[5];
                            objClinic.SugarA = attri[6];
                            objClinic.SugarB = attri[7];
                            objClinic.Remarks = attri[8];
                            objClinic.PatientName = attri[9];
                            objClinic.MonitorDate = attri[10];
                            if (attri[11] != string.Empty)
                            {
                                Ailment ailment = new Ailment();
                                ailment.AilmentName = attri[11];
                                objClinic.Ailment = ailment;
                            }
                            objClinic.CVS = attri[12];
                            objClinic.VitalId = attri[13];
                            ClincList.Add(objClinic);
                        }
                    }
                }
            }

            return ClincList;
        }

        public string GetPatientCheckUpDashboardDetails_Serialize(List<RN.MOBILE_COMMON.Diagnosis> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            foreach (Diagnosis objDiag in Response)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(objDiag.ClaimID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objDiag.Date);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objDiag.DiagnosisName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objDiag.Patientname);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objDiag.DiagnosisRate);
                objOutPut.Append(ListProperty_Split);
                if (objDiag.DiagnosticDetails != null)
                {
                    objOutPut.Append(objDiag.DiagnosticDetails.DIAGNOSTIC_Name);
                }
                else
                {
                    objOutPut.Append("");
                }
                objOutPut.Append(ListElement_End);
            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }

        public List<RN.MOBILE_COMMON.Diagnosis> GetPatientCheckUpDashboardDetails_Deserialize(string Response, string token)
        {
            List<RN.MOBILE_COMMON.Diagnosis> objDiagList = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnosis objDiag = new Diagnosis();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objDiag.ClaimID = attri[0];
                            objDiag.Date = attri[1];
                            objDiag.DiagnosisName = attri[2];
                            objDiag.Patientname = attri[3];
                            if (attri[4] != string.Empty)
                                objDiag.DiagnosisRate = Convert.ToDecimal(attri[4]);
                            if (attri[5] != string.Empty)
                            {
                                DiagnosticDetails objdet = new DiagnosticDetails();
                                objdet.DIAGNOSTIC_Name = attri[5];
                                objDiag.DiagnosticDetails = objdet;
                            }
                            objDiagList.Add(objDiag);
                        }
                    }
                }
            }
            return objDiagList;
        }

        public string GetPatientDetails_Serialize(Patient Response, string token)
        {
            StringBuilder objOutput = new StringBuilder();
            objOutput.Append(Response.Error);
            objOutput.Append(split);
            objOutput.Append(Response.ErrorDesc);
            objOutput.Append(split);
            objOutput.Append(Response.UserName);
            objOutput.Append(split);
            objOutput.Append(Response.MobileNo);
            objOutput.Append(split);
            objOutput.Append(Response.Address);
            objOutput.Append(split);
            objOutput.Append(Response.PINCode);
            objOutput.Append(split);
            objOutput.Append(Response.EmailID);
            objOutput.Append(split);
            objOutput.Append(Response.CityID);
            objOutput.Append(split);
            objOutput.Append(Response.GenderID);
            objOutput.Append(split);
            objOutput.Append(Response.Age);
            objOutput.Append(split);
            objOutput.Append(Response.DOB);
            objOutput.Append(split);
            objOutput.Append(Response.RelationShipID);
            objOutput.Append(split);
            objOutput.Append(Response.RelationShipName);
            objOutput.Append(split);
            objOutput.Append(Response.WalletAmount);
            objOutput.Append(split);
            objOutput.Append(Response.PatienID);
            objOutput.Append(split);
            objOutput.Append(Response.ShowReportAutomatic);
            objOutput.Append(split);
            objOutput.Append(Response.is_show_prescription_depend);
            objOutput.Append(split);
            //Shipping Details
            if (Response.lstShippingAdd != null && Response.lstShippingAdd.Count > 0)
            {
                objOutput.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstShippingAdd)
                {

                    objOutput.Append(ListElement_Start);
                    objOutput.Append(objS.AddressId);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.AddressTitle);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street1);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street2);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.PinCode);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.CityID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.StateID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Country);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.MobileNo);
                    objOutput.Append(ListProperty_Split);

                    objOutput.Append(objS.consumer_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.primary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.secondary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.company_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.address_type);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.City);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.State);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.locality);

                    objOutput.Append(ListElement_End);
                }
                objOutput.Append(ListIdentifier_End);
            }
            else
            {
                objOutput.Append("");
            }

            objOutput.Append(split);
            //Shipping Details 1
            if (Response.lstShippingAdd1 != null && Response.lstShippingAdd1.Count > 0)
            {
                objOutput.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstShippingAdd1)
                {

                    objOutput.Append(ListElement_Start);
                    objOutput.Append(objS.AddressId);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.AddressTitle);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street1);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street2);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.PinCode);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.CityID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.StateID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Country);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.MobileNo);
                    objOutput.Append(ListProperty_Split);

                    objOutput.Append(objS.consumer_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.primary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.secondary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.company_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.address_type);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.City);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.State);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.locality);

                    objOutput.Append(ListElement_End);
                }
                objOutput.Append(ListIdentifier_End);
            }
            else
            {
                objOutput.Append("");
            }

            objOutput.Append(split);
            //home address Details 1
            if (Response.lstHomeaddress != null && Response.lstHomeaddress.Count > 0)
            {
                objOutput.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstHomeaddress)
                {

                    objOutput.Append(ListElement_Start);
                    objOutput.Append(objS.AddressId);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.AddressTitle);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street1);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street2);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.PinCode);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.CityID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.StateID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Country);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.MobileNo);
                    objOutput.Append(ListProperty_Split);

                    objOutput.Append(objS.consumer_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.primary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.secondary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.company_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.address_type);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.City);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.State);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.locality);

                    objOutput.Append(ListElement_End);
                }
                objOutput.Append(ListIdentifier_End);
            }
            else
            {
                objOutput.Append("");
            }

            objOutput.Append(split);
            //Office address Details 1
            if (Response.lstOfficeAddress != null && Response.lstOfficeAddress.Count > 0)
            {
                objOutput.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstOfficeAddress)
                {

                    objOutput.Append(ListElement_Start);
                    objOutput.Append(objS.AddressId);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.AddressTitle);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street1);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Street2);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.PinCode);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.CityID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.StateID);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.Country);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.MobileNo);
                    objOutput.Append(ListProperty_Split);

                    objOutput.Append(objS.consumer_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.primary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.secondary_emailid);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.company_name);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.address_type);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.City);
                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.State);

                    objOutput.Append(ListProperty_Split);
                    objOutput.Append(objS.locality);

                    objOutput.Append(ListElement_End);
                }
                objOutput.Append(ListIdentifier_End);
            }
            else
            {
                objOutput.Append("");
            }

            objOutput.Append(split);

            objOutput.Append(Response.Secondary_mobileno);
            objOutput.Append(split);
            objOutput.Append(Response.Secondary_emailid);
            objOutput.Append(split);
            objOutput.Append(Response.Address1);
            objOutput.Append(split);
            objOutput.Append(Response.AadharNo);
            objOutput.Append(split);
            objOutput.Append(Response.PanNo);
            objOutput.Append(split);
            objOutput.Append(Response.IsRegistred);
            objOutput.Append(split);

            objOutput.Append(Response.AccountNumber);
            objOutput.Append(split);
            objOutput.Append(Response.AccountType);
            objOutput.Append(split);
            objOutput.Append(Response.BankName);
            objOutput.Append(split);
            objOutput.Append(Response.BranchName);
            objOutput.Append(split);
            objOutput.Append(Response.IFSCCode);
            objOutput.Append(split);
            objOutput.Append(Response.PayeeName);
            objOutput.Append(split);


            return StringCipher.Encrypt(objOutput.ToString(), token);
        }

        public Patient GetPatientDetails_Deserialize(string Response, string token)
        {
            Patient objPat = new Patient();
            string strResponse = StringCipher.Decrypt(Response, token);
            string[] attri = strResponse.Split(split);
            if (attri != null && attri.Count() > 0)
            {
                objPat.Error = attri[0];
                objPat.ErrorDesc = attri[1];
                objPat.UserName = attri[2];
                objPat.MobileNo = attri[3];
                objPat.Address = attri[4];
                objPat.PINCode = attri[5];
                objPat.EmailID = attri[6];
                if (attri[7] != string.Empty)
                    objPat.CityID = Convert.ToInt32(attri[7]);
                if (attri[8] != string.Empty)
                    objPat.GenderID = Convert.ToInt32(attri[8]);
                if (attri[9] != string.Empty)
                    objPat.Age = Convert.ToInt32(attri[9]);
                objPat.DOB = attri[10];
                if (attri[11] != string.Empty)
                    objPat.RelationShipID = Convert.ToInt32(attri[11]);
                objPat.RelationShipName = attri[12];
                if (attri[13] != string.Empty)
                    objPat.WalletAmount = Convert.ToInt32(attri[13]);
                if (attri[14] != string.Empty)
                    objPat.PatienID = Convert.ToInt32(attri[14]);
                if (attri[15] != string.Empty)
                    objPat.ShowReportAutomatic = Convert.ToInt32(attri[15]);
                if (attri[16] != string.Empty)
                    objPat.is_show_prescription_depend = Convert.ToInt32(attri[16]);
                if (attri[17] != null && attri[17] != string.Empty)
                {
                    objPat.lstShippingAdd = new List<ShippingAddress>();
                    foreach (string list in attri[17].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] values = innerlist.Split(ListProperty_Split);
                                    ShippingAddress objS = new ShippingAddress();
                                    objS.AddressId = values[0];
                                    objS.AddressTitle = values[1];
                                    objS.Street1 = values[2];
                                    objS.Street2 = values[3];
                                    objS.PinCode = values[4];
                                    objS.CityID = values[5];
                                    objS.StateID = values[6];
                                    objS.Country = values[7];
                                    objS.MobileNo = values[8];

                                    objS.consumer_name = values[9];
                                    objS.primary_emailid = values[10];
                                    objS.secondary_emailid = values[11];
                                    objS.company_name = values[12];
                                    objS.address_type = values[13];

                                    objS.City = values[14];
                                    objS.State = values[15];

                                    objS.locality = values[16];

                                    objPat.lstShippingAdd.Add(objS);
                                }
                            }
                        }
                    }
                }

                if (attri[18] != null && attri[18] != string.Empty)
                {
                    objPat.lstShippingAdd1 = new List<ShippingAddress>();
                    foreach (string list in attri[18].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] values = innerlist.Split(ListProperty_Split);
                                    ShippingAddress objS = new ShippingAddress();
                                    objS.AddressId = values[0];
                                    objS.AddressTitle = values[1];
                                    objS.Street1 = values[2];
                                    objS.Street2 = values[3];
                                    objS.PinCode = values[4];
                                    objS.CityID = values[5];
                                    objS.StateID = values[6];
                                    objS.Country = values[7];
                                    objS.MobileNo = values[8];

                                    objS.consumer_name = values[9];
                                    objS.primary_emailid = values[10];
                                    objS.secondary_emailid = values[11];
                                    objS.company_name = values[12];
                                    objS.address_type = values[13];

                                    objS.City = values[14];
                                    objS.State = values[15];
                                    objS.locality = values[16];
                                    objPat.lstShippingAdd1.Add(objS);
                                }
                            }
                        }
                    }
                }

                if (attri[19] != null && attri[19] != string.Empty)
                {
                    objPat.lstHomeaddress = new List<ShippingAddress>();
                    foreach (string list in attri[19].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] values = innerlist.Split(ListProperty_Split);
                                    ShippingAddress objS = new ShippingAddress();
                                    objS.AddressId = values[0];
                                    objS.AddressTitle = values[1];
                                    objS.Street1 = values[2];
                                    objS.Street2 = values[3];
                                    objS.PinCode = values[4];
                                    objS.CityID = values[5];
                                    objS.StateID = values[6];
                                    objS.Country = values[7];
                                    objS.MobileNo = values[8];

                                    objS.consumer_name = values[9];
                                    objS.primary_emailid = values[10];
                                    objS.secondary_emailid = values[11];
                                    objS.company_name = values[12];
                                    objS.address_type = values[13];

                                    objS.City = values[14];
                                    objS.State = values[15];
                                    objS.locality = values[16];
                                    objPat.lstHomeaddress.Add(objS);
                                }
                            }
                        }
                    }
                }

                if (attri[20] != null && attri[20] != string.Empty)
                {
                    objPat.lstOfficeAddress = new List<ShippingAddress>();
                    foreach (string list in attri[20].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] values = innerlist.Split(ListProperty_Split);
                                    ShippingAddress objS = new ShippingAddress();
                                    objS.AddressId = values[0];
                                    objS.AddressTitle = values[1];
                                    objS.Street1 = values[2];
                                    objS.Street2 = values[3];
                                    objS.PinCode = values[4];
                                    objS.CityID = values[5];
                                    objS.StateID = values[6];
                                    objS.Country = values[7];
                                    objS.MobileNo = values[8];

                                    objS.consumer_name = values[9];
                                    objS.primary_emailid = values[10];
                                    objS.secondary_emailid = values[11];
                                    objS.company_name = values[12];
                                    objS.address_type = values[13];

                                    objS.City = values[14];
                                    objS.State = values[15];
                                    objS.locality = values[16];
                                    objPat.lstOfficeAddress.Add(objS);
                                }
                            }
                        }
                    }
                }

                if (attri[21] != string.Empty)
                    objPat.Secondary_mobileno = Convert.ToString(attri[21]);
                if (attri[22] != string.Empty)
                    objPat.Secondary_emailid = Convert.ToString(attri[22]);
                if (attri[23] != string.Empty)
                    objPat.Address1 = Convert.ToString(attri[23]);
                if (attri[24] != string.Empty)
                    objPat.AadharNo = Convert.ToString(attri[24]);
                if (attri[25] != string.Empty)
                    objPat.PanNo = Convert.ToString(attri[25]);
                if (attri.Count() > 26)
                {
                    if (attri[26] != string.Empty)
                        objPat.IsRegistred = Convert.ToInt32(attri[26]);
                }

                if (attri.Count() > 27)
                {
                    if (attri[27] != string.Empty)
                        objPat.AccountNumber = Convert.ToString(attri[27]);
                    if (attri[28] != string.Empty)
                        objPat.AccountType = Convert.ToString(attri[28]);
                    if (attri[29] != string.Empty)
                        objPat.BankName = Convert.ToString(attri[29]);
                    if (attri[30] != string.Empty)
                        objPat.BranchName = Convert.ToString(attri[30]);
                    if (attri[31] != string.Empty)
                        objPat.IFSCCode = Convert.ToString(attri[31]);
                    if (attri[32] != string.Empty)
                        objPat.PayeeName = Convert.ToString(attri[32]);
                }
            }
            return objPat;
        }

        public string GetPayers_Serialize(List<Entity> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);

            foreach (Entity objEntity in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objEntity.EntityID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objEntity.EntityCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objEntity.EntityName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Entity> GetPayers_Deserialize(string Response, string token)
        {
            List<Entity> EntityList = new List<Entity>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Entity objEntity = new Entity();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objEntity.EntityID = Convert.ToInt32(attri[0]);
                            objEntity.EntityCode = attri[1];
                            objEntity.EntityName = attri[2];
                            EntityList.Add(objEntity);
                        }
                    }
                }
            }


            return EntityList;
        }

        public string GetPatientPayerMembers_Serialize(List<PatientPayer> Response, string token)
        {
            StringBuilder output = new StringBuilder();
            output.Append(ListIdentifier_Start);
            if (Response != null)
            {
                foreach (PatientPayer objPatPay in Response)
                {
                    output.Append(ListElement_Start);
                    output.Append(objPatPay.PayerID);
                    output.Append(ListProperty_Split);
                    output.Append(objPatPay.PayerName);
                    output.Append(ListProperty_Split);
                    output.Append(objPatPay.MemberNo);
                    output.Append(ListProperty_Split);
                    output.Append(objPatPay.PayerCode);
                    output.Append(ListElement_End);
                }
            }
            output.Append(ListIdentifier_End);
            return StringCipher.Encrypt(output.ToString(), token);

        }

        public ObservableCollection<PatientPayer> GetPatientPayerMembers_Deserialize(string Response, string token)
        {
            ObservableCollection<PatientPayer> objPatPayList = new ObservableCollection<PatientPayer>();
            string strResposne = StringCipher.Decrypt(Response, token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PatientPayer objPatPay = new PatientPayer();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objPatPay.PayerID = Convert.ToInt32(attri[0]);
                            objPatPay.PayerName = attri[1];
                            objPatPay.MemberNo = attri[2];
                            objPatPay.PayerCode = attri[3];
                            objPatPayList.Add(objPatPay);
                        }
                    }
                }
            }
            return objPatPayList;
        }

        public string GetCityState_Serialize(string Response, string token)
        {
            return StringCipher.Encrypt(Response, token);
        }

        public string GetCityState_Deserialize(string Response, string token)
        {
            return StringCipher.Decrypt(Response, token);
        }

        public string GetRateusValues_Serialize(List<RateUs> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();

            outPut.Append(ListIdentifier_Start);
            foreach (RateUs objRateus in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objRateus.apprate_desc);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRateus.AppRating);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRateus.shareus_desc);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRateus.thoughts_desc);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRateus.recommened_msg);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRateus.recommened_rate);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRateus.trans_id);
                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<RateUs> GetRateusValues_DeSerialize(string Response, string token)
        {
            List<RateUs> objRateusList = new List<RateUs>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            RateUs objRateus = new RateUs();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objRateus.apprate_desc = Convert.ToString(attri[0]);
                            objRateus.AppRating = Convert.ToString(attri[1]);
                            objRateus.shareus_desc = Convert.ToString(attri[2]);
                            objRateus.thoughts_desc = Convert.ToString(attri[3]);
                            objRateus.recommened_msg = Convert.ToString(attri[4]);
                            objRateus.recommened_rate = Convert.ToString(attri[5]);
                            objRateus.trans_id = Convert.ToString(attri[6]);

                            objRateusList.Add(objRateus);
                        }
                    }
                }
            }

            return objRateusList;
        }

        public string GetLookupValues_Serialize(List<Lookup> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();

            outPut.Append(ListIdentifier_Start);
            foreach (Lookup objLookup in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objLookup.ValueID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objLookup.ValueDesc);
                outPut.Append(ListProperty_Split);
                outPut.Append(objLookup.TYPE_ID);
                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Lookup> GetLookupValues_Deserialize(string Response, string token)
        {
            List<Lookup> objLookupList = new List<Lookup>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Lookup objLookup = new Lookup();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objLookup.ValueID = Convert.ToInt32(attri[0]);
                            objLookup.ValueDesc = attri[1];
                            if (attri.Length > 2 && attri[2] != string.Empty)
                                objLookup.TYPE_ID = Convert.ToInt32(attri[2]);
                            objLookupList.Add(objLookup);
                        }
                    }
                }
            }

            return objLookupList;
        }

        public string GetState_Serialize(State Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            if (Response != null)
            {
                outPut.Append(Response.StateID);
                outPut.Append(split);
                outPut.Append(Response.StateName);
            }
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public State GetState_Deserialize(string Response, string token)
        {
            string strResponse = StringCipher.Decrypt(Response, token);
            State objState = new State();
            string[] attri = strResponse.Split(split);
            if (attri.Length == 2)
            {
                if (attri[0] != string.Empty)
                    objState.StateID = Convert.ToInt32(attri[0]);
                objState.StateName = attri[1];
            }
            return objState;
        }


        public string GetPatientDetails_Phy_Serialize(List<Patient> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            foreach (Patient objPat in Response)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(objPat.PatienID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.UserName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.PINCode);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.Address);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.Age);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.Gender);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.RelationShipName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.MobileNo);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.MemberNo);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.PolicyNo);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.Status);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.EmailID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.CorporateName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.IsRegistred);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.IsSelfMemberRegistered);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.IsSelfMemberActive);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.PolicyStatus);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.PolicyExpired);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.DOB);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.corporate_id);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.RelationShipID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.rn_relation_id);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.REM_ENABLED);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.user_name_without_mrms);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.OFFLINE_PRESC_ENABLED);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.CityName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.StateName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(objPat.PolicyID);
                objOutPut.Append(ListElement_End);
            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }


        public List<Patient> GetPatientDetails_Phy_Deserialize(string Response, string token)
        {
            List<Patient> objPatList = new List<Patient>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Patient objPat = new Patient();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objPat.PatienID = Convert.ToInt32(attri[0]);
                            objPat.UserName = attri[1];
                            objPat.PINCode = attri[2];
                            objPat.Address = attri[3];
                            if (attri[4] != string.Empty)
                                objPat.Age = Convert.ToInt32(attri[4]);
                            objPat.Gender = attri[5];
                            objPat.RelationShipName = attri[6];
                            objPat.MobileNo = attri[7];
                            objPat.MemberNo = attri[8];
                            objPat.PolicyNo = attri[9];
                            objPat.Status = attri[10];
                            if (attri[11] != string.Empty)
                                objPat.EmailID = attri[11];
                            if (attri[12] != string.Empty)
                                objPat.CorporateName = attri[12];
                            if (attri.Length > 13 && attri[13] != string.Empty)
                                objPat.IsRegistred = Convert.ToInt16(attri[13]);
                            if (attri.Length > 14 && attri[14] != string.Empty)
                                objPat.IsSelfMemberRegistered = Convert.ToInt16(attri[14]);
                            if (attri.Length > 15 && attri[15] != string.Empty)
                                objPat.IsSelfMemberActive = Convert.ToInt16(attri[15]);
                            if (attri.Length > 16 && attri[16] != string.Empty)
                                objPat.PolicyStatus = Convert.ToInt16(attri[16]);
                            if (attri.Length > 17 && attri[17] != string.Empty)
                                objPat.PolicyExpired = Convert.ToInt16(attri[17]);
                            if (attri.Length > 18 && attri[18] != string.Empty)
                                objPat.DOB = attri[18];
                            if (attri.Length > 19 && attri[19] != string.Empty)
                                objPat.corporate_id = attri[19];
                            if (attri.Length > 20 && attri[20] != string.Empty)
                                objPat.RelationShipID = Convert.ToInt32(attri[20]);
                            if (attri.Length > 21 && attri[21] != string.Empty)
                                objPat.rn_relation_id = Convert.ToInt32(attri[21]);
                            if (attri.Length > 22 && attri[22] != string.Empty)
                                objPat.REM_ENABLED = Convert.ToInt32(attri[22]);
                            if (attri.Length > 23 && attri[23] != string.Empty)
                                objPat.user_name_without_mrms = Convert.ToString(attri[23]);
                            if (attri.Length > 24 && attri[24] != string.Empty)
                                objPat.OFFLINE_PRESC_ENABLED = Convert.ToString(attri[24]);
                            if (attri.Length > 25 && attri[25] != string.Empty)
                                objPat.CityName = Convert.ToString(attri[25]);
                            if (attri.Length > 26 && attri[26] != string.Empty)
                                objPat.StateName = Convert.ToString(attri[26]);
                            if (attri.Length > 27 && attri[27] != string.Empty)
                                objPat.PolicyID = Convert.ToString(attri[27]);
                            objPatList.Add(objPat);
                        }
                    }
                }
            }

            return objPatList;
        }


        public string GetEntityList_Serialize(List<ProviderList> Response, string token)
        {
            StringBuilder objOut = new StringBuilder();
            objOut.Append(ListIdentifier_Start);
            foreach (ProviderList objPList in Response)
            {
                objOut.Append(ListElement_Start);
                objOut.Append(objPList.ProviderCode);
                objOut.Append(ListProperty_Split);
                objOut.Append(objPList.ProviderName);
                objOut.Append(ListProperty_Split);
                objOut.Append(objPList.ProviderId);
                objOut.Append(ListProperty_Split);
                objOut.Append(objPList.Address);
                objOut.Append(ListElement_End);
            }
            objOut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOut.ToString(), token);
        }

        public List<ProviderList> GetEntityList_Deserialize(string Response, string token)
        {
            List<ProviderList> objProviderList = new List<ProviderList>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            ProviderList objProvider = new ProviderList();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objProvider.ProviderCode = attri[0];
                            objProvider.ProviderName = attri[1];
                            objProvider.ProviderId = attri[2];
                            objProvider.Address = attri[3];
                            objProviderList.Add(objProvider);
                        }
                    }
                }
            }

            return objProviderList;
        }

        


        public string GetEntityListTreatmentMethod_Serialize(List<ProviderList> Response, string token)
        {
            StringBuilder objOut = new StringBuilder();
            objOut.Append(ListIdentifier_Start);
            foreach (ProviderList objPList in Response)
            {
                objOut.Append(ListElement_Start);
                objOut.Append(objPList.ProviderCode);
                objOut.Append(ListProperty_Split);
                objOut.Append(objPList.ProviderName);
                objOut.Append(ListProperty_Split);
                objOut.Append(objPList.ProviderId);
                objOut.Append(ListProperty_Split);
                objOut.Append(objPList.Address);
                objOut.Append(ListProperty_Split);

                if (objPList.Diagnosislist != null)
                {
                    foreach (Diagnosis objDiag in objPList.Diagnosislist)
                    {
                        objOut.Append(Inner_ListElement_Start);
                        objOut.Append(objDiag.DiagnosisName);
                        objOut.Append(Inner_ListElement_End);
                    }
                }


                objOut.Append(ListElement_End);

            }
            objOut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOut.ToString(), token);
        }

        public List<ProviderList> GetEntityListTreatmentMethod_Deserialize(string Response, string token)
        {
            List<ProviderList> objProviderList = new List<ProviderList>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            ProviderList objProvider = new ProviderList();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objProvider.ProviderCode = attri[0];
                            objProvider.ProviderName = attri[1];
                            objProvider.ProviderId = attri[2];
                            objProvider.Address = attri[3];
                            if (attri[4] != string.Empty)
                            {
                                List<Diagnosis> objDiagList = new List<Diagnosis>();
                                foreach (string innerlist1 in attri[4].Split(Inner_ListElement_Start, Inner_ListElement_End))
                                {
                                    if (innerlist1 != string.Empty)
                                    {
                                        Diagnosis objdiag = new Diagnosis();
                                        string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                        objdiag.DiagnosisName = attri1[0];
                                        objDiagList.Add(objdiag);
                                    }
                                }
                                objProvider.Diagnosislist = objDiagList;
                            }

                            objProviderList.Add(objProvider);
                        }
                    }
                }
            }

            return objProviderList;
        }


        public string GetDiagnosisList_Serialize(List<RN.MOBILE_COMMON.Diagnosis> Response, string token)
        {
            StringBuilder objOut = new StringBuilder();
            objOut.Append(ListIdentifier_Start);
            foreach (Diagnosis objDiag in Response)
            {
                objOut.Append(ListElement_Start);

                objOut.Append(objDiag.DiagnosisCode);
                objOut.Append(ListProperty_Split);
                objOut.Append(objDiag.DiagnosisName);
                objOut.Append(ListElement_End);
            }
            objOut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOut.ToString(), token);
        }


        public List<RN.MOBILE_COMMON.Diagnosis> GetDiagnosisList_Deserialize(string Response, string token)
        {
            List<Diagnosis> objDiagList = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnosis objDiag = new Diagnosis();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objDiag.DiagnosisCode = attri[0];
                            objDiag.DiagnosisName = attri[1];
                            objDiagList.Add(objDiag);
                        }
                    }
                }
            }
            return objDiagList;
        }


        public string GetGeoLocation_Serialize(List<GeoLocation> Response, string token)
        {
            StringBuilder objOut = new StringBuilder();
            objOut.Append(ListIdentifier_Start);
            foreach (GeoLocation objGeo in Response)
            {
                objOut.Append(ListElement_Start);
                objOut.Append(objGeo.LOC_ID);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.LOC_NAME);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.SEARCH_TYPE);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.DISCOUNT);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.LOC_ADDRESS);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.GEO_LATITUDE);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.GEO_LONGITUDE);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.GEO_DISTANCE);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.CITY_ID);
                objOut.Append(ListProperty_Split);
                objOut.Append(objGeo.CITY);
                objOut.Append(ListElement_End);
            }
            objOut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOut.ToString(), token);
        }

        public List<GeoLocation> GetGeoLocation_DeSerialize(string Response, string token)
        {
            List<GeoLocation> GeoList = new List<GeoLocation>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            GeoLocation objGeo = new GeoLocation();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objGeo.LOC_ID = Convert.ToInt32(attri[0]);
                            objGeo.LOC_NAME = attri[1];
                            objGeo.SEARCH_TYPE = attri[2];
                            if (attri[3] != string.Empty)
                                objGeo.DISCOUNT = Convert.ToDecimal(attri[3]);
                            objGeo.LOC_ADDRESS = attri[4];
                            if (attri[5] != string.Empty)
                                objGeo.GEO_LATITUDE = Convert.ToDouble(attri[5]);
                            if (attri[6] != string.Empty)
                                objGeo.GEO_LONGITUDE = Convert.ToDouble(attri[6]);
                            if (attri[7] != string.Empty)
                                objGeo.GEO_DISTANCE = Convert.ToDouble(attri[7]);
                            if (attri[8] != string.Empty)
                                objGeo.CITY_ID = Convert.ToInt16(attri[8]);
                            objGeo.CITY = attri[9];
                            GeoList.Add(objGeo);
                        }
                    }
                }
            }


            return GeoList;
        }


        public string ValidateProductPolicy_Serialize(PaymentBreakupDetails PayBreak, string token)
        {
            StringBuilder strPayemnt = new StringBuilder();

            strPayemnt.Append(PayBreak.EntityCode);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.MemberId);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.MemberName);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.PolicyNo);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.PolicyStartDate);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.PolicyEndDate);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.PolicyBSI);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.ProductName);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.PolicySI);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.Transcation_Type);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.Bill_Amt);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.PatientPay_Amt);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.PayerPay_Amt);
            strPayemnt.Append(split);
            //PolicyValDetails
            strPayemnt.Append(ListIdentifier_Start);
            foreach (PolicyValDetails polval in PayBreak.PolValDet)
            {
                strPayemnt.Append(ListElement_Start);
                strPayemnt.Append(polval.Message);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(polval.Value);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(polval.transaction_type);
                //strPayemnt.Append(Inner_ListProperty_Split);
                // strPayemnt.Append(polval.value_desc);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(polval.Message_type);
                strPayemnt.Append(ListElement_End);

            }
            strPayemnt.Append(ListIdentifier_End);

            strPayemnt.Append(split);

            //IncluExcluDetails
            strPayemnt.Append(ListIdentifier_Start);
            foreach (IncluExcluDetails objIncExl in PayBreak.IncExcDet)
            {
                strPayemnt.Append(Inner_ListElement_Start);
                strPayemnt.Append(objIncExl.Message);
                strPayemnt.Append(Inner_ListElement_End);
            }
            strPayemnt.Append(ListIdentifier_End);

            strPayemnt.Append(split);

            //CappingDetails
            strPayemnt.Append(ListIdentifier_Start);
            foreach (CappingDetails objCapping in PayBreak.CappingDet)
            {
                strPayemnt.Append(ListElement_Start);
                strPayemnt.Append(objCapping.Name);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(objCapping.Value);
                strPayemnt.Append(ListElement_End);
            }
            strPayemnt.Append(ListIdentifier_End);
            strPayemnt.Append(split);
            //CopayDetails
            strPayemnt.Append(ListIdentifier_Start);
            foreach (CopayDetails objCopay in PayBreak.CopayDet)
            {
                strPayemnt.Append(ListElement_Start);
                strPayemnt.Append(objCopay.Name);
                strPayemnt.Append(ListProperty_Split);
                strPayemnt.Append(objCopay.Value);
                strPayemnt.Append(ListElement_End);
            }
            strPayemnt.Append(ListIdentifier_End);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.HideCntInsured);
            strPayemnt.Append(split);
            strPayemnt.Append(PayBreak.HideTariff);
            return StringCipher.Encrypt(strPayemnt.ToString(), token);
        }

        public PaymentBreakupDetails ValidateProductPolicy_Deserialize(string Response, string token)
        {
            string strResponse = StringCipher.Decrypt(Response, token);
            PaymentBreakupDetails objbreak = new PaymentBreakupDetails();

            string[] attri = strResponse.Split(split);
            objbreak.EntityCode = attri[0];
            objbreak.MemberId = attri[1];
            objbreak.MemberName = attri[2];
            objbreak.PolicyNo = attri[3];
            objbreak.PolicyStartDate = attri[4];
            objbreak.PolicyEndDate = attri[5];
            if (attri[6] != string.Empty)
                objbreak.PolicyBSI = Convert.ToDecimal(attri[6]);
            objbreak.ProductName = attri[7];
            if (attri[8] != string.Empty)
                objbreak.PolicySI = Convert.ToDecimal(attri[8]);
            if (attri[9] != string.Empty)
                objbreak.Transcation_Type = Convert.ToInt32(attri[9]);
            if (attri[10] != string.Empty)
                objbreak.Bill_Amt = Convert.ToDecimal(attri[10]);
            if (attri[11] != string.Empty)
                objbreak.PatientPay_Amt = Convert.ToDecimal(attri[11]);
            if (attri[12] != string.Empty)
                objbreak.PayerPay_Amt = Convert.ToDecimal(attri[12]);

            if (attri[13] != null && attri[13] != string.Empty)
            {
                List<PolicyValDetails> objpollist = new List<PolicyValDetails>();
                foreach (string innerlist1 in attri[13].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (innerlist1 != string.Empty)
                    {
                        foreach (string innerElement1 in innerlist1.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerElement1 != string.Empty)
                            {
                                PolicyValDetails objPol = new PolicyValDetails();
                                string[] PolAttri = innerElement1.Split(ListProperty_Split);
                                objPol.Message = PolAttri[0];
                                objPol.Value = PolAttri[1];
                                objPol.transaction_type = PolAttri[2];
                                //objPol.value_desc = PolAttri[3];
                                objPol.Message_type = PolAttri[3];
                                objpollist.Add(objPol);
                            }
                        }

                    }
                }
                objbreak.PolValDet = objpollist;
            }

            if (attri[14] != null && attri[14] != string.Empty)
            {
                List<IncluExcluDetails> objExcllist = new List<IncluExcluDetails>();
                foreach (string innerlist1 in attri[14].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (innerlist1 != string.Empty)
                    {
                        foreach (string innerElement1 in innerlist1.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerElement1 != string.Empty)
                            {
                                IncluExcluDetails objExcl = new IncluExcluDetails();
                                string[] PolAttri = innerElement1.Split(Inner_ListProperty_Split);
                                objExcl.Message = PolAttri[0];
                                objExcllist.Add(objExcl);
                            }
                        }

                    }
                }
                objbreak.IncExcDet = objExcllist;
            }

            if (attri[15] != null && attri[15] != string.Empty)
            {
                List<CappingDetails> objcaplist = new List<CappingDetails>();
                foreach (string innerlist1 in attri[15].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (innerlist1 != string.Empty)
                    {
                        foreach (string innerElement1 in innerlist1.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerElement1 != string.Empty)
                            {
                                CappingDetails objCap = new CappingDetails();
                                string[] PolAttri = innerElement1.Split(ListProperty_Split);
                                objCap.Name = PolAttri[0];
                                objCap.Value = PolAttri[1];
                                objcaplist.Add(objCap);
                            }
                        }

                    }
                }
                objbreak.CappingDet = objcaplist;
            }

            if (attri[16] != null && attri[16] != string.Empty)
            {
                List<CopayDetails> objcopaylist = new List<CopayDetails>();
                foreach (string innerlist1 in attri[16].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (innerlist1 != string.Empty)
                    {
                        foreach (string innerElement1 in innerlist1.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerElement1 != string.Empty)
                            {
                                CopayDetails objcopay = new CopayDetails();
                                string[] PolAttri = innerElement1.Split(ListProperty_Split);
                                objcopay.Name = PolAttri[0];
                                objcopay.Value = PolAttri[1];
                                objcopaylist.Add(objcopay);
                            }
                        }

                    }
                }
                objbreak.CopayDet = objcopaylist;
            }
            if (attri[17] != string.Empty)
                objbreak.HideCntInsured = Convert.ToInt16(attri[17]);
            if (attri[18] != string.Empty)
                objbreak.HideTariff = Convert.ToInt16(attri[18]);
            return objbreak;
        }


        public string GetPolicyCover_Serialize(PolicyCover Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(Response.BSI);

            outPut.Append(split);

            outPut.Append(Response.SumInsured);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (WPonAilment WPA in Response.lstWPAilment)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(WPA.AilmentName);
                outPut.Append(ListProperty_Split);
                outPut.Append(WPA.period_type);
                outPut.Append(ListProperty_Split);
                outPut.Append(WPA.WPDays);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (maxClaim objMax in Response.lstMaxclaim)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objMax.Service);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMax.MaxClaim);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMax.AvailClaim);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (RelapsedPeriod objRp in Response.lstRP)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objRp.Service);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRp.RPDays);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (maxClaim objMax in Response.lstMaxClaimPerDay)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objMax.Service);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMax.MaxClaim);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMax.AvailClaim);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (MaxClaimAmt objMaxAmt in Response.lstMaxClailAmtPerDay)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objMaxAmt.service);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMaxAmt.maxClaimAmt);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMaxAmt.availClaimAmt);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (MaxClaimAmt objMaxAmt in Response.lstMaxClaimAmt)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objMaxAmt.service);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMaxAmt.maxClaimAmt);
                outPut.Append(ListProperty_Split);
                outPut.Append(objMaxAmt.availClaimAmt);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);

            foreach (CoPay objCopay in Response.lstCopay)
            {
                outPut.Append(ListElement_Start);

                outPut.Append(objCopay.ServiceName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objCopay.AppOn);
                outPut.Append(ListProperty_Split);
                outPut.Append(objCopay.PerCent);

                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);

            foreach (InclusionAil objIncAil in Response.lstInclusionAilment)
            {
                outPut.Append(ListElement_Start);

                outPut.Append(objIncAil.AilmentName);

                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionAil objExcAil in Response.lstExclusionAilment)
            {
                outPut.Append(ListElement_Start);

                outPut.Append(objExcAil.AilmentName);

                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);


            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);

            foreach (InclusionAilDiag objIncAilDig in Response.lstIncluAilDiag)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objIncAilDig.AilmentName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objIncAilDig.DiagnosticName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);


            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (InclusionAilDrug objIncAilDrug in Response.lstIncluAilDrug)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objIncAilDrug.AilmentName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objIncAilDrug.DurgName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);


            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);

            foreach (InclusionHealthChk objIncHchk in Response.lstIncluHC)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objIncHchk.HealthChkName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);

            foreach (ExClusionHealthChk objExcHchk in Response.lstExclusionHC)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExcHchk.HealthChkName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(Response.WPonPolicy);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionPharDrug objExcPharDrug in Response.lstExClusionPharDrug)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExcPharDrug.Code);
                outPut.Append(ListProperty_Split);
                outPut.Append(objExcPharDrug.DurgName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionDiagnostic objExClusionDiagnostic in Response.lstExClusionDiagnostic)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExClusionDiagnostic.DiagnosticName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionDiagnosticGroup objExClusionDiagnosticGroup in Response.lstExClusionDiagnosticGroup)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExClusionDiagnosticGroup.DiagnosticGroupCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objExClusionDiagnosticGroup.DiagnosticGroupName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionAilDiag objExClusionAilDiag in Response.lstExClusionAilDiag)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExClusionAilDiag.AilmentID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objExClusionAilDiag.AilmentName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionAilDiagGroup objExClusionAilDiagGroup in Response.lstExClusionAilDiagGroup)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExClusionAilDiagGroup.AilmentCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objExClusionAilDiagGroup.AilmentName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionAilDrug objExClusionAilDrug in Response.lstExClusionAilDrug)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExClusionAilDrug.AilmentCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objExClusionAilDrug.AilmentName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExClusionAilPro objExClusionAilPro in Response.lstExClusionAilPro)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExClusionAilPro.AilmentCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objExClusionAilPro.AilmentName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (ExcluMinorPro objExcluMinorPro in Response.lstExcluMinorPro)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objExcluMinorPro.ProcedureName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (CoPayOnRelation objCoPayOnRelation in Response.lstCoPayOnRelation)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objCoPayOnRelation.Relationship);
                outPut.Append(ListProperty_Split);
                outPut.Append(objCoPayOnRelation.Percentage);
                outPut.Append(ListProperty_Split);
                outPut.Append(objCoPayOnRelation.Flat);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (CoPayOnAge objCoPayOnAge in Response.lstCoPayOnAge)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objCoPayOnAge.AgeMin);
                outPut.Append(ListProperty_Split);
                outPut.Append(objCoPayOnAge.AgeMax);
                outPut.Append(ListProperty_Split);
                outPut.Append(objCoPayOnAge.Percentage);
                outPut.Append(ListProperty_Split);
                outPut.Append(objCoPayOnAge.Flat);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (DeductionOnPhysical objDeductionOnPhysical in Response.lstDeductionOnPhysical)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objDeductionOnPhysical.ServiceType);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDeductionOnPhysical.MaxLimit);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDeductionOnPhysical.Percentage);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDeductionOnPhysical.Flat);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(ListIdentifier_Start);
            foreach (DeductionOnHome objDeductionOnHome in Response.lstDeductionOnHome)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objDeductionOnHome.ServiceType);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDeductionOnHome.MaxLimit);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDeductionOnHome.Percentage);
                outPut.Append(ListProperty_Split);
                outPut.Append(objDeductionOnHome.Flat);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            outPut.Append(split);
            outPut.Append(Response.HideCntInsured);
            outPut.Append(split);
            outPut.Append(Response.HideTariff);

            return StringCipher.Encrypt(outPut.ToString(), token);
        }


        public PolicyCover GetPolicyCover_Deserialize(string Response, string token)
        {
            PolicyCover objPolyCov = new PolicyCover();
            string strResponse = StringCipher.Decrypt(Response, token);
            string[] attri = strResponse.Split(split);
            objPolyCov.BSI = attri[0];
            objPolyCov.SumInsured = attri[1];

            if (attri[2] != string.Empty)
            {
                List<WPonAilment> lstWp = new List<WPonAilment>();
                foreach (string list in attri[2].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                WPonAilment obj = new WPonAilment();
                                obj.AilmentName = attri1[0];
                                obj.period_type = attri1[1];
                                obj.WPDays = attri1[2];
                                lstWp.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstWPAilment = lstWp;
            }

            if (attri[3] != string.Empty)
            {
                List<maxClaim> lstMaxclaim = new List<maxClaim>();
                foreach (string list in attri[3].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                maxClaim obj = new maxClaim();
                                obj.Service = attri1[0];
                                obj.MaxClaim = attri1[1];
                                obj.AvailClaim = attri1[2];
                                lstMaxclaim.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstMaxclaim = lstMaxclaim;
            }

            if (attri[4] != string.Empty)
            {
                List<RelapsedPeriod> lstRP = new List<RelapsedPeriod>();
                foreach (string list in attri[4].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                RelapsedPeriod obj = new RelapsedPeriod();
                                obj.Service = attri1[0];
                                obj.RPDays = attri1[1];
                                lstRP.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstRP = lstRP;
            }

            if (attri[5] != string.Empty)
            {
                List<maxClaim> lstMaxPerday = new List<maxClaim>();
                foreach (string list in attri[5].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                maxClaim obj = new maxClaim();
                                obj.Service = attri1[0];
                                obj.MaxClaim = attri1[1];
                                obj.AvailClaim = attri1[2];
                                lstMaxPerday.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstMaxClaimPerDay = lstMaxPerday;
            }

            if (attri[6] != string.Empty)
            {
                List<MaxClaimAmt> lstMaxAmtPerDay = new List<MaxClaimAmt>();
                foreach (string list in attri[6].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                MaxClaimAmt obj = new MaxClaimAmt();
                                obj.service = attri1[0];
                                obj.maxClaimAmt = attri1[1];
                                obj.availClaimAmt = attri1[2];
                                lstMaxAmtPerDay.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstMaxClailAmtPerDay = lstMaxAmtPerDay;
            }

            if (attri[7] != string.Empty)
            {
                List<MaxClaimAmt> lstMaxAmt = new List<MaxClaimAmt>();
                foreach (string list in attri[7].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                MaxClaimAmt obj = new MaxClaimAmt();
                                obj.service = attri1[0];
                                obj.maxClaimAmt = attri1[1];
                                obj.availClaimAmt = attri1[2];
                                lstMaxAmt.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstMaxClaimAmt = lstMaxAmt;
            }


            if (attri[8] != string.Empty)
            {
                List<CoPay> lstCoPay = new List<CoPay>();
                foreach (string list in attri[8].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                CoPay obj = new CoPay();
                                obj.ServiceName = attri1[0];
                                obj.AppOn = attri1[1];
                                obj.PerCent = attri1[2];
                                lstCoPay.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstCopay = lstCoPay;
            }

            if (attri[9] != string.Empty)
            {
                List<InclusionAil> lstInclusionAil = new List<InclusionAil>();
                foreach (string list in attri[9].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                InclusionAil obj = new InclusionAil();
                                obj.AilmentName = attri1[0];
                                lstInclusionAil.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstInclusionAilment = lstInclusionAil;
            }

            if (attri[10] != string.Empty)
            {
                List<ExClusionAil> lstExClusionAil = new List<ExClusionAil>();
                foreach (string list in attri[10].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionAil obj = new ExClusionAil();
                                obj.AilmentName = attri1[0];
                                lstExClusionAil.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExclusionAilment = lstExClusionAil;
            }

            if (attri[11] != string.Empty)
            {
                List<InclusionAilDiag> lstIncAilDiag = new List<InclusionAilDiag>();
                foreach (string list in attri[11].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                InclusionAilDiag obj = new InclusionAilDiag();
                                obj.AilmentName = attri1[0];
                                obj.DiagnosticName = attri1[1];
                                lstIncAilDiag.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstIncluAilDiag = lstIncAilDiag;
            }


            if (attri[12] != string.Empty)
            {
                List<InclusionAilDrug> lstIncAilDrug = new List<InclusionAilDrug>();
                foreach (string list in attri[12].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                InclusionAilDrug obj = new InclusionAilDrug();
                                obj.AilmentName = attri1[0];
                                obj.DurgName = attri1[1];
                                lstIncAilDrug.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstIncluAilDrug = lstIncAilDrug;
            }

            if (attri[13] != string.Empty)
            {
                List<InclusionHealthChk> lstIncHC = new List<InclusionHealthChk>();
                foreach (string list in attri[13].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                InclusionHealthChk obj = new InclusionHealthChk();
                                obj.HealthChkName = attri1[0];
                                lstIncHC.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstIncluHC = lstIncHC;
            }

            if (attri[14] != string.Empty)
            {
                List<ExClusionHealthChk> lstExcHC = new List<ExClusionHealthChk>();
                foreach (string list in attri[14].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionHealthChk obj = new ExClusionHealthChk();
                                obj.HealthChkName = attri1[0];
                                lstExcHC.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExclusionHC = lstExcHC;
            }
            objPolyCov.WPonPolicy = attri[15];
            if (attri[16] != string.Empty)
            {
                List<ExClusionPharDrug> lstPharExclDrug = new List<ExClusionPharDrug>();
                foreach (string list in attri[16].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionPharDrug obj = new ExClusionPharDrug();
                                obj.Code = attri1[0];
                                obj.DurgName = attri1[1];
                                lstPharExclDrug.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExClusionPharDrug = lstPharExclDrug;
            }
            if (attri[17] != string.Empty)
            {
                List<ExClusionDiagnostic> lstExClusionDiagnostic = new List<ExClusionDiagnostic>();
                foreach (string list in attri[17].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionDiagnostic obj = new ExClusionDiagnostic();
                                obj.DiagnosticName = attri1[0];
                                lstExClusionDiagnostic.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExClusionDiagnostic = lstExClusionDiagnostic;
            }
            if (attri[18] != string.Empty)
            {
                List<ExClusionDiagnosticGroup> lstExClusionDiagnosticGroup = new List<ExClusionDiagnosticGroup>();
                foreach (string list in attri[18].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionDiagnosticGroup obj = new ExClusionDiagnosticGroup();
                                obj.DiagnosticGroupCode = attri1[0];
                                obj.DiagnosticGroupName = attri1[1];
                                lstExClusionDiagnosticGroup.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExClusionDiagnosticGroup = lstExClusionDiagnosticGroup;
            }
            if (attri[19] != string.Empty)
            {
                List<ExClusionAilDiag> lstExClusionAilDiag = new List<ExClusionAilDiag>();
                foreach (string list in attri[19].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionAilDiag obj = new ExClusionAilDiag();
                                obj.AilmentID = attri1[0];
                                obj.AilmentName = attri1[1];
                                lstExClusionAilDiag.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExClusionAilDiag = lstExClusionAilDiag;
            }
            if (attri[20] != string.Empty)
            {
                List<ExClusionAilDiagGroup> lstExClusionAilDiagGroup = new List<ExClusionAilDiagGroup>();
                foreach (string list in attri[20].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionAilDiagGroup obj = new ExClusionAilDiagGroup();
                                obj.AilmentCode = attri1[0];
                                obj.AilmentName = attri1[1];
                                lstExClusionAilDiagGroup.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExClusionAilDiagGroup = lstExClusionAilDiagGroup;
            }
            if (attri[21] != string.Empty)
            {
                List<ExClusionAilDrug> lstExClusionAilDrug = new List<ExClusionAilDrug>();
                foreach (string list in attri[21].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionAilDrug obj = new ExClusionAilDrug();
                                obj.AilmentCode = attri1[0];
                                obj.AilmentName = attri1[1];
                                lstExClusionAilDrug.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExClusionAilDrug = lstExClusionAilDrug;
            }
            if (attri[22] != string.Empty)
            {
                List<ExClusionAilPro> lstExClusionAilPro = new List<ExClusionAilPro>();
                foreach (string list in attri[22].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                ExClusionAilPro obj = new ExClusionAilPro();
                                obj.AilmentCode = attri1[0];
                                obj.AilmentName = attri1[1];
                                lstExClusionAilPro.Add(obj);
                            }
                        }
                    }
                }
                objPolyCov.lstExClusionAilPro = lstExClusionAilPro;
            }
            if (attri[23] != string.Empty)
            {
                List<ExcluMinorPro> lstExcluMinorPro = new List<ExcluMinorPro>();
                foreach (string list in attri[23].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                ExcluMinorPro obj = new ExcluMinorPro();
                                obj.ProcedureName = innerlist;
                                lstExcluMinorPro.Add(obj);
                            }
                        }
                    }
                }

                objPolyCov.lstExcluMinorPro = lstExcluMinorPro;
            }
            if (attri[24] != string.Empty)
            {
                List<CoPayOnRelation> lstCoPayOnRelation = new List<CoPayOnRelation>();
                foreach (string list in attri[24].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                CoPayOnRelation obj = new CoPayOnRelation();
                                obj.Relationship = attri1[0];
                                obj.Percentage = attri1[1];
                                obj.Flat = attri1[2];
                                lstCoPayOnRelation.Add(obj);
                            }
                        }
                    }
                }

                objPolyCov.lstCoPayOnRelation = lstCoPayOnRelation;
            }
            if (attri[25] != string.Empty)
            {
                List<CoPayOnAge> lstCoPayOnAge = new List<CoPayOnAge>();
                foreach (string list in attri[25].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                CoPayOnAge obj = new CoPayOnAge();
                                obj.AgeMin = attri1[0];
                                obj.AgeMax = attri1[1];
                                obj.Percentage = attri1[2];
                                obj.Flat = attri1[3];
                                lstCoPayOnAge.Add(obj);
                            }
                        }
                    }
                }

                objPolyCov.lstCoPayOnAge = lstCoPayOnAge;
            }
            if (attri[26] != string.Empty)
            {
                List<DeductionOnPhysical> lstDeductionOnPhysical = new List<DeductionOnPhysical>();
                foreach (string list in attri[26].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                DeductionOnPhysical obj = new DeductionOnPhysical();
                                obj.ServiceType = attri1[0];
                                obj.MaxLimit = attri1[1];
                                obj.Percentage = attri1[2];
                                obj.Flat = attri1[3];
                                lstDeductionOnPhysical.Add(obj);
                            }
                        }
                    }
                }

                objPolyCov.lstDeductionOnPhysical = lstDeductionOnPhysical;
            }
            if (attri[27] != string.Empty)
            {
                List<DeductionOnHome> lstDeductionOnHome = new List<DeductionOnHome>();
                foreach (string list in attri[27].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                DeductionOnHome obj = new DeductionOnHome();
                                obj.ServiceType = attri1[0];
                                obj.MaxLimit = attri1[1];
                                obj.Percentage = attri1[2];
                                obj.Flat = attri1[3];
                                lstDeductionOnHome.Add(obj);
                            }
                        }
                    }
                }

                objPolyCov.lstDeductionOnHome = lstDeductionOnHome;
            }
            if (attri[28] != string.Empty)
                objPolyCov.HideCntInsured = Convert.ToInt16(attri[28]);
            if (attri[29] != string.Empty)
                objPolyCov.HideTariff = Convert.ToInt16(attri[29]);

            return objPolyCov;
        }

        public string GetPatientPrescriptionList_Serialize(List<PrescriptionClass> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass obj in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.prescriptionId);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.physicianName);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.patientName);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.patient_id);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.physician_id);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<PrescriptionClass> GetPatientPrescriptionList_Deserialize(string Response, string token)
        {
            List<PrescriptionClass> preList = new List<PrescriptionClass>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PrescriptionClass objpre = new PrescriptionClass();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objpre.prescriptionId = attri[0];
                            objpre.physicianName = attri[1];
                            objpre.patientName = attri[2];
                            objpre.patient_id = attri[3];
                            objpre.physician_id = attri[4];
                            preList.Add(objpre);
                        }
                    }
                }
            }
            return preList;
        }

        public string GetPhysicianTimeSlot_Serialize(List<PhysicianSlotList> Response, string token)
        {
            StringBuilder objOut = new StringBuilder();
            objOut.Append(ListIdentifier_Start);
            foreach (PhysicianSlotList obj in Response)
            {
                objOut.Append(ListElement_Start);
                objOut.Append(obj.PhysicianID);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.PhysicianName);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.Speciality);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.ConsultFee);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.Experience);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.MorningSlot);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.SlotActiveM);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.AfternoonSlot);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.SlotActiveA);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.EveningSlot);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.SlotActiveE);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.SpecialityId);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.ProviderName);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.ProviderID);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.ProviderCode);
                objOut.Append(ListElement_End);
            }

            objOut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOut.ToString(), token);
        }

        public List<PhysicianSlotList> GetPhysicianTimeSlot_Deserialize(string Response, string token)
        {
            List<PhysicianSlotList> objPhysician = new List<PhysicianSlotList>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PhysicianSlotList objPhyList = new PhysicianSlotList();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objPhyList.PhysicianID = Convert.ToInt32(attri[0]);
                            objPhyList.PhysicianName = attri[1];
                            objPhyList.Speciality = attri[2];
                            if (attri[3] != string.Empty)
                                objPhyList.ConsultFee = Convert.ToDecimal(attri[3]);
                            objPhyList.Experience = attri[4];
                            objPhyList.MorningSlot = attri[5];
                            if (attri[6] != string.Empty)
                                objPhyList.SlotActiveM = Convert.ToInt32(attri[6]);
                            objPhyList.AfternoonSlot = attri[7];
                            if (attri[8] != string.Empty)
                                objPhyList.SlotActiveA = Convert.ToInt32(attri[8]);
                            objPhyList.EveningSlot = attri[9];
                            if (attri[10] != string.Empty)
                                objPhyList.SlotActiveE = Convert.ToInt32(attri[10]);
                            objPhyList.SpecialityId = attri[11];
                            objPhyList.ProviderName = attri[12];
                            if (attri[13] != string.Empty)
                                objPhyList.ProviderID = Convert.ToInt32(attri[13]);
                            objPhyList.ProviderCode = attri[14];
                            objPhysician.Add(objPhyList);
                        }
                    }
                }
            }
            return objPhysician;
        }


        public string GetReminder_Serialize(List<Reminder> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);

            foreach (Reminder objRem in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objRem.Prescription_Id);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Patient_Id);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.HistoryID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.MorningTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.AfternoonTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.NightTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.DurationDays);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Is_Active);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Created_Date);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Ailment_Name);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.DrugName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.MemberId);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.ReminderDateTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.ReminderId);
                outPut.Append(ListProperty_Split);
                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Reminder> GetReminder_Deserialize(string Response, string token)
        {
            List<Reminder> RemList = new List<Reminder>();
            string strResposne = StringCipher.Decrypt(Response, token);

            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Reminder objRem = new Reminder();
                            objRem.Prescription_Id = attri[0];
                            if (attri[1] != string.Empty)
                                objRem.Patient_Id = Convert.ToInt32(attri[1]);
                            if (attri[2] != string.Empty)
                                objRem.HistoryID = Convert.ToInt32(attri[2]);
                            objRem.MorningTime = attri[3];
                            objRem.AfternoonTime = attri[4];
                            objRem.NightTime = attri[5];
                            if (attri[6] != string.Empty)
                                objRem.DurationDays = Convert.ToInt32(attri[6]);
                            if (attri[7] != string.Empty)
                                objRem.Is_Active = Convert.ToInt32(attri[7]);
                            objRem.Created_Date = attri[8];
                            objRem.Ailment_Name = attri[9];
                            objRem.DrugName = attri[10];
                            objRem.MemberId = attri[11];
                            objRem.ReminderDateTime = attri[12];
                            objRem.ReminderId = attri[13];
                            RemList.Add(objRem);
                        }
                    }
                }
            }
            return RemList;
        }

        public string GetDiagnosisMaster_Serialize(List<Diagnosis> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (Diagnosis obj in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.DiagnosisID);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.DiagnosisCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.DiagnosisName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }


        public List<Diagnosis> GetDiagnosisMaster_Deserialize(string Response, string token)
        {
            List<Diagnosis> objDiagList = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Diagnosis obj = new Diagnosis();
                            if (attri[0] != string.Empty)
                                obj.DiagnosisID = Convert.ToInt32(attri[0]);
                            obj.DiagnosisCode = attri[1];
                            obj.DiagnosisName = attri[2];
                            objDiagList.Add(obj);
                        }
                    }
                }
            }

            return objDiagList;

        }


        public string GetPhysicianlist_Serialize(List<PhysicianSlotList> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (PhysicianSlotList obj in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.PhysicianID);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.PhysicianName);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.PractoDoctorId);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<PhysicianSlotList> GetPhysicianlist_Deserialize(string Response, string token)
        {
            List<PhysicianSlotList> objPhyList = new List<PhysicianSlotList>();
            string strResposne = StringCipher.Decrypt(Response, token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            PhysicianSlotList obj = new PhysicianSlotList();
                            if (attri[0] != string.Empty)
                                obj.PhysicianID = Convert.ToInt32(attri[0]);
                            obj.PhysicianName = attri[1];
                            obj.PractoDoctorId = attri[2];
                            objPhyList.Add(obj);
                        }
                    }
                }
            }
            return objPhyList;
        }

        public string GetPhysicianlist_Pat_Serialize(List<Physician> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (Physician obj in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.PhysicianID);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.UserName);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.EntityId);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.EntityCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Speciality);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.SpecialityID);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Physician> GetPhysicianlist_Pat_Deserialize(string Response, string token)
        {
            List<Physician> objPhyList = new List<Physician>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Physician objPhy = new Physician();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objPhy.PhysicianID = Convert.ToInt32(attri[0]);
                            objPhy.UserName = attri[1];
                            if (attri[2] != string.Empty)
                                objPhy.EntityId = Convert.ToInt32(attri[2]);
                            objPhy.EntityCode = attri[3];
                            objPhy.Speciality = attri[4];
                            if (attri[5] != string.Empty)
                                objPhy.SpecialityID = Convert.ToInt32(attri[5]);
                            objPhyList.Add(objPhy);
                        }
                    }
                }
            }
            return objPhyList;
        }

        public string OPLookupValues_Pat_Serialize(List<Lookup> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (Lookup obj in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.ValueID);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.ValueDesc);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Lookup> OPLookupValues_Pat_Deserialize(string Response, string token)
        {
            List<Lookup> objLkVal = new List<Lookup>();
            string strResposne = StringCipher.Decrypt(Response, token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Lookup obj = new Lookup();
                            if (attri[0] != string.Empty)
                                obj.ValueID = Convert.ToInt32(attri[0]);
                            obj.ValueDesc = attri[1];
                            objLkVal.Add(obj);
                        }
                    }
                }
            }
            return objLkVal;
        }

        public string GetPatientInsurances_Phy_Serialize(List<Patient> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (Patient obj in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.MemberNo);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Status);
                outPut.Append(ListProperty_Split);
                if (obj.Entity != null)
                {
                    outPut.Append(Inner_ListElement_Start);
                    outPut.Append(obj.Entity.EntityName);
                    outPut.Append(Inner_ListProperty_Split);
                    outPut.Append(obj.Entity.EntityID);
                    outPut.Append(Inner_ListProperty_Split);
                    outPut.Append(obj.Entity.EntityCode);
                    outPut.Append(Inner_ListElement_End);
                }
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.UserName);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.PatienID);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.IsActive);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Status);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.RelationShipName);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.UserName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Patient> GetPatientInsurances_Phy_Deserialize(string Response, string token)
        {
            List<Patient> objPatList = new List<Patient>();
            string strResposne = StringCipher.Decrypt(Response, token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Patient obj = new Patient();
                            string[] attri = innerlist.Split(ListProperty_Split);

                            obj.MemberNo = attri[0];
                            obj.Status = attri[1];
                            if (attri[2] != string.Empty)
                            {
                                foreach (string innerlist1 in attri[2].Split(Inner_ListElement_Start, Inner_ListElement_End))
                                {
                                    if (innerlist1 != string.Empty)
                                    {
                                        string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                        Entity objEntity = new Entity();
                                        objEntity.EntityName = attri1[0];
                                        if (attri1[1] != string.Empty)
                                            objEntity.EntityID = Convert.ToInt32(attri1[1]);
                                        objEntity.EntityCode = attri1[2];
                                        obj.Entity = objEntity;
                                        break;
                                    }
                                }
                            }

                            obj.UserName = attri[3];
                            if (attri[4] != string.Empty)
                                obj.PatienID = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                obj.IsActive = Convert.ToBoolean(attri[5]);
                            obj.Status = attri[6];
                            obj.RelationShipName = attri[7];
                            obj.UserName = attri[8];
                            objPatList.Add(obj);
                        }
                    }
                }
            }
            return objPatList;
        }

        public static string EncryptKey()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes("M+PRbWXZn4j3QIJjMfjtltFkRS4A4XgdH9zfLY4NKG0=");
            byte[] messageBytes = encoding.GetBytes("SanjeevSingh");
            System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);

            byte[] bytes = cryptographer.ComputeHash(messageBytes);

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public void fullobject()
        {
            string[] values = "".Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] test = innerlist.Split(ListProperty_Split);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //obj.param.Add(strval);
                }
            }

        }
        public string GetDiagnosisSearch_Pat_Serialize(List<RN.MOBILE_COMMON.Diagnosis> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Diagnosis objDiag in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objDiag.ClaimID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objDiag.Patientname);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objDiag.patientid);
                strOutPut.Append(ListProperty_Split);
                if (objDiag.lst != null && objDiag.lst.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Diagnosis objlst in objDiag.lst)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objlst.DiagnosisName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.DiagnosisID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.ClaimID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.Date);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.filename);
                        strOutPut.Append(Inner_ListElement_End);
                    }

                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<RN.MOBILE_COMMON.Diagnosis> GetDiagnosisSearch_Pat_Deserialize(string Response, string Token)
        {
            List<RN.MOBILE_COMMON.Diagnosis> lstDiag = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnosis objDiag = new Diagnosis();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objDiag.ClaimID = attri[1];
                            objDiag.Patientname = attri[2];
                            if (attri[3] != string.Empty)
                                objDiag.patientid = Convert.ToInt32(attri[3]);

                            if (attri[4] != null && attri[4] != string.Empty)
                            {
                                List<RN.MOBILE_COMMON.Diagnosis> lstDiag1 = new List<Diagnosis>();
                                foreach (string list1 in attri[4].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Diagnosis objDiag1 = new Diagnosis();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objDiag1.DiagnosisName = attri1[0];
                                                if (attri1[1] != string.Empty)
                                                    objDiag1.DiagnosisID = Convert.ToInt32(attri1[1]);
                                                if (attri1[2] != string.Empty)
                                                    objDiag1.ClaimID = attri1[2];
                                                objDiag1.Date = attri1[3];
                                                objDiag1.filename = attri1[4];
                                                lstDiag1.Add(objDiag1);
                                            }
                                        }
                                    }
                                }
                                objDiag.lst = lstDiag1;
                            }
                            lstDiag.Add(objDiag);
                        }
                    }
                }
            }
            return lstDiag;
        }

        #region Physician

        public string Physician_GetDashboardDeatails_Serialize_new(List<PrescriptionClass> objResposne, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass objpre in objResposne)
            {
                strOutPut.Append(objpre.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.physicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ailmentName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.procedureName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.PrescriptionType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.DeliveryCity);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.DeliveryState);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.DeliveryAddress);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.DeliveryPinCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.PrecFileName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.PatientAge);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ServiceAccessTypeID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.PatientGender);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Remarks);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.PharmacyRemarks);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.TreatmentMethod);

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.BillAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ChatDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.UnreadMsgCount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.physician_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.LastFetchTime);
                strOutPut.Append(ListProperty_Split);

                //consultation
                if (objpre.Consultation != null)
                {
                    strOutPut.Append(Inner_ListElement_Start);
                    strOutPut.Append(objpre.Consultation.ConsultationFee);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.Consultation.ReviewDate);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.Consultation.Speciality);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.Consultation.prescriptionId);
                    strOutPut.Append(Inner_ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }


                strOutPut.Append(ListProperty_Split);
                //DrugList
                if (objpre.Druglist != null && objpre.Druglist.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Drug objdrug in objpre.Druglist)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objdrug.DrugID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DrugName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.NoOfDays);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DrugQuantity);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.Afternoon);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.Morning);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.Night);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.BeforeFood);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DRUG_TYPE_DESC);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DosageA);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DosageM);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DosageN);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.Prescription_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DrugCode);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.DRUG_TYPE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdrug.Evening);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);
                //pharmacyDetail
                if (objpre.pharmacyDetail != null)
                {
                    strOutPut.Append(Inner_ListElement_Start);
                    strOutPut.Append(objpre.pharmacyDetail.PharmacyID);
                    strOutPut.Append(Inner_ListProperty_Split);
                    _PharmacyId = objpre.pharmacyDetail.PharmacyID.ToString();
                    strOutPut.Append(objpre.pharmacyDetail.PharmacyName);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.pharmacyDetail.ShippingCharge);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.pharmacyDetail.DeliveryMinTime);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.pharmacyDetail.DeliveryMaxTime);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.pharmacyDetail.Discount);
                    strOutPut.Append(Inner_ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListProperty_Split);
                //Diagnostic list
                if (objpre.DiagnosisDetail != null && objpre.DiagnosisDetail.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Diagnosis objdia in objpre.DiagnosisDetail)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objdia.DiagnosisID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.ClaimID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.patientid);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.filename);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.ShowReport);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.AutoShowReport);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisCode);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.RESULT_VALUE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.OrderId);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objdia.isHc);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);
                //Orderdetails
                if (objpre.Orderdetails != null && objpre.Orderdetails.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Oderdetails objOrder in objpre.Orderdetails)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objOrder.order_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.prescription_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.address);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.pin);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.mobile_no);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.city);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.state);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.orderdate);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.pharmacyname);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.Order_Amt);

                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.diagnosticname);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.order_type);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.OrderStatus);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.PayerOrderId);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.Is_health_check);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.hasFeedback);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListProperty_Split);



                //minor procedure list
                if (objpre.Proclist != null && objpre.Proclist.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Procedure objProc in objpre.Proclist)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objProc.ProcedureID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.ProcedureCode);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.ProcedureName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.ReportName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.Prescription_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.ProcedureType);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);

                //minor Test list
                if (objpre.Testlist != null && objpre.Testlist.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Procedure objTest in objpre.Testlist)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objTest.ProcedureID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.ProcedureCode);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.ProcedureName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.ReportName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.Prescription_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.ProcedureType);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);

                //Diagnosis or Ailment 
                if (objpre.Ailment_Details != null && objpre.Ailment_Details.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Ailment ObjAilment in objpre.Ailment_Details)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(ObjAilment.code);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(ObjAilment.AilmentName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(ObjAilment.Prescription_id);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);

                //Diagnosis or Ailment 
                if (objpre.complaints != null && objpre.complaints.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (PrescriptionClass.complaint Complaints in objpre.complaints)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(Complaints.name);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(Complaints.Prescription_id);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListProperty_Split);

                strOutPut.Append(_PharmacyId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Is_health_check);
                strOutPut.Append(ListProperty_Split);

                //Health checkup 
                if (objpre.HCU != null)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    strOutPut.Append(Inner_ListElement_Start);
                    strOutPut.Append(objpre.HCU.HCName);
                    strOutPut.Append(Inner_ListProperty_Split);
                    strOutPut.Append(objpre.HCU.Prescription_id);
                    strOutPut.Append(Inner_ListElement_End);
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.AutoShowReport);

                strOutPut.Append(ListProperty_Split);
                //Attachment
                if (objpre.AttachmentsLst != null && objpre.AttachmentsLst.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (OP_Attachments obj in objpre.AttachmentsLst)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(obj.AttachDate);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.AttachFileName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.AttachmentRemarks);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Claim_Id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.FilePath);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.PatientId);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Self_ID);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListProperty_Split);
                //Vitals 
                if (objpre.VitalsLst != null && objpre.VitalsLst.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Vital_Controls obj in objpre.VitalsLst)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(obj.CONTROL_TEXT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TEXT_STYLE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TYPE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.DISPLAY_ORDER);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.IS_EXPAND);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.IS_2TEXTBOX);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CLAIM_ID);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListProperty_Split);
                //Diagnostic_Range
                if (objpre.Diagnostic_Range != null && objpre.Diagnostic_Range.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (DiagnosticRange obj in objpre.Diagnostic_Range)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(obj.DIAGNOSTIC_CODE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.KEY);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.VALUE);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);

                if (objpre.secondaryAilments != null && objpre.secondaryAilments.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (PrescriptionClass.SecondaryAilment Complaints in objpre.secondaryAilments)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(Complaints.SecondaryAilmentname);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);

                strOutPut.Append(objpre.HasDiagnostic);
                strOutPut.Append(ListProperty_Split);

                strOutPut.Append(objpre.HasDiagnosticOrder);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.OrderByOrderDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.OrderByPrescDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.IsView);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.HasDrug);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.patient_id);

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.HasPharmachyOrder);

                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> Physician_GetDashboardDeatails_Deserialize_new(string Response, string Token)
        {
            List<PrescriptionClass> lstpres = new List<PrescriptionClass>();
            string[] valuesArr = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in valuesArr)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] values = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = values[0];
                                    objPres.physicianName = values[1];
                                    objPres.patientName = values[2];
                                    objPres.prescriptionDate = values[3];
                                    objPres.ailmentName = values[4];
                                    objPres.procedureName = values[5];
                                    if (values[6] != string.Empty)
                                        objPres.PrescriptionType = Convert.ToInt32(values[6]);
                                    objPres.DeliveryCity = values[7];
                                    objPres.DeliveryState = values[8];
                                    objPres.DeliveryAddress = values[9];
                                    objPres.DeliveryPinCode = values[10];
                                    objPres.PrecFileName = values[11];
                                    objPres.PatientAge = values[12];
                                    objPres.ServiceAccessTypeID = values[13];
                                    objPres.PatientGender = values[14];
                                    objPres.Remarks = values[15];
                                    objPres.PharmacyRemarks = values[16];
                                    objPres.TreatmentMethod = values[17];

                                    objPres.patient_id = values[18];
                                    if (values[19] != string.Empty)
                                        objPres.BillAmt = Convert.ToInt32(values[19]);
                                    objPres.ChatDate = values[20];
                                    if (values[21] != string.Empty)
                                        objPres.UnreadMsgCount = Convert.ToInt32(values[21]);
                                    objPres.physician_id = values[22];
                                    objPres.pharmacyId = values[23];
                                    objPres.LastFetchTime = values[24];

                                    if (values[25] != null && values[25] != string.Empty)
                                    {
                                        Consultation obj = new Consultation();
                                        foreach (string innerElement in values[25].Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerElement != string.Empty)
                                            {
                                                string[] attri = innerElement.Split(Inner_ListProperty_Split);
                                                obj.ConsultationFee = attri[0];
                                                obj.ReviewDate = attri[1];
                                                obj.Speciality = attri[2];
                                                obj.prescriptionId = attri[3];
                                            }
                                        }
                                        objPres.Consultation = obj;
                                    }

                                    if (values[26] != null && values[26] != string.Empty)
                                    {
                                        List<Drug> objList = new List<Drug>();
                                        foreach (string innerIdentifier in values[26].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (innerIdentifier != string.Empty)
                                            {
                                                foreach (string innerElement in innerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (innerElement != string.Empty)
                                                    {
                                                        string[] attri = innerElement.Split(Inner_ListProperty_Split);
                                                        Drug objDrug = new Drug();
                                                        if (attri[0] != string.Empty)
                                                            objDrug.DrugID = Convert.ToInt32(attri[0]);
                                                        objDrug.DrugName = attri[1];
                                                        if (attri[2] != string.Empty)
                                                            objDrug.NoOfDays = Convert.ToInt32(attri[2]);
                                                        if (attri[3] != string.Empty)
                                                            objDrug.DrugQuantity = Convert.ToInt32(attri[3]);
                                                        if (attri[4] != string.Empty)
                                                            objDrug.Afternoon = Convert.ToDecimal(attri[4]);
                                                        if (attri[5] != string.Empty)
                                                            objDrug.Morning = Convert.ToDecimal(attri[5]);
                                                        if (attri[6] != string.Empty)
                                                            objDrug.Night = Convert.ToDecimal(attri[6]);
                                                        if (attri[7] != string.Empty)
                                                            objDrug.BeforeFood = Convert.ToInt32(attri[7]);
                                                        objDrug.DRUG_TYPE_DESC = attri[8];
                                                        objDrug.DosageA = attri[9];
                                                        objDrug.DosageM = attri[10];
                                                        objDrug.DosageN = attri[11];
                                                        objDrug.Prescription_id = attri[12];
                                                        if (attri[13] != string.Empty)
                                                            objDrug.DrugCode = Convert.ToString(attri[13]);
                                                        if (attri[14] != string.Empty)
                                                            objDrug.DRUG_TYPE = Convert.ToInt32(attri[14]);
                                                        if (attri[15] != string.Empty)
                                                            objDrug.Evening = Convert.ToDecimal(attri[15]);
                                                        objList.Add(objDrug);
                                                    }
                                                }
                                            }
                                        }
                                        objPres.Druglist = objList;
                                    }

                                    if (values[27] != null && values[27] != string.Empty)
                                    {
                                        Pharmacy objPhr = new Pharmacy();
                                        foreach (string innerElement in values[27].Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerElement != string.Empty)
                                            {
                                                string[] attri = innerElement.Split(Inner_ListProperty_Split);
                                                if (attri[0] != string.Empty)
                                                    objPhr.PharmacyID = Convert.ToInt32(attri[0]);
                                                objPhr.PharmacyName = attri[1];
                                                if (attri[2] != string.Empty)
                                                    objPhr.ShippingCharge = Convert.ToDecimal(attri[2]);
                                                objPhr.DeliveryMinTime = Convert.ToInt32(attri[3]);
                                                objPhr.DeliveryMaxTime = Convert.ToInt32(attri[4]);
                                                objPhr.Discount = Convert.ToDecimal(attri[5]);
                                            }
                                        }

                                        objPres.pharmacyDetail = objPhr;
                                    }

                                    if (values[28] != null && values[28] != string.Empty)
                                    {

                                        List<Diagnosis> objList = new List<Diagnosis>();
                                        foreach (string innerIdentifier in values[28].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (innerIdentifier != string.Empty)
                                            {
                                                foreach (string innerElement in innerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (innerElement != string.Empty)
                                                    {
                                                        string[] attri = innerElement.Split(Inner_ListProperty_Split);
                                                        Diagnosis objDiag = new Diagnosis();
                                                        if (attri[0] != string.Empty)
                                                            objDiag.DiagnosisID = Convert.ToInt32(attri[0]);
                                                        objDiag.DiagnosisName = attri[1];
                                                        if (attri[2] != string.Empty)
                                                            objDiag.ClaimID = attri[2];
                                                        if (attri[3] != string.Empty)
                                                            objDiag.patientid = Convert.ToInt32(attri[3]);
                                                        objDiag.filename = attri[4];
                                                        if (attri[5] != string.Empty)
                                                            objDiag.ShowReport = Convert.ToInt32(attri[5]);
                                                        if (attri[6] != string.Empty)
                                                            objDiag.AutoShowReport = Convert.ToInt32(attri[6]);
                                                        if (attri[7] != string.Empty)
                                                            objDiag.DiagnosisCode = Convert.ToString(attri[7]);
                                                        if (attri[8] != string.Empty)
                                                            objDiag.RESULT_VALUE = Convert.ToString(attri[8]);
                                                        objDiag.OrderId = Convert.ToString(attri[9]);
                                                        objDiag.isHc = Convert.ToInt32(attri[10]);
                                                        objList.Add(objDiag);
                                                    }
                                                }
                                            }
                                        }
                                        objPres.DiagnosisDetail = objList;
                                    }

                                    if (values[29] != null && values[29] != string.Empty)
                                    {
                                        List<Oderdetails> objList = new List<Oderdetails>();
                                        foreach (string InnerIdentifier in values[29].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        Oderdetails ObjOrder = new Oderdetails();
                                                        ObjOrder.order_id = attri[0];
                                                        ObjOrder.prescription_id = attri[1];
                                                        ObjOrder.address = attri[2];
                                                        ObjOrder.pin = attri[3];
                                                        ObjOrder.mobile_no = attri[4];
                                                        ObjOrder.city = attri[5];
                                                        ObjOrder.state = attri[6];
                                                        ObjOrder.orderdate = attri[7];
                                                        ObjOrder.pharmacyname = attri[8];
                                                        ObjOrder.Order_Amt = attri[9];

                                                        ObjOrder.diagnosticname = attri[10];
                                                        ObjOrder.order_type = attri[11];
                                                        ObjOrder.OrderStatus = attri[12];
                                                        ObjOrder.PayerOrderId = attri[13];
                                                        if (attri[14] != string.Empty)
                                                            ObjOrder.Is_health_check = Convert.ToInt32(attri[14]);
                                                        if (attri[15] != string.Empty)
                                                            ObjOrder.hasFeedback = Convert.ToInt32(attri[15]);

                                                        objList.Add(ObjOrder);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.Orderdetails = objList;
                                    }


                                    if (values[30] != null && values[30] != string.Empty)
                                    {
                                        List<Procedure> objList = new List<Procedure>();
                                        foreach (string InnerIdentifier in values[30].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        Procedure ObjProc = new Procedure();
                                                        ObjProc.ProcedureID = Convert.ToInt32(attri[0]);
                                                        ObjProc.ProcedureCode = attri[1];
                                                        ObjProc.ProcedureName = attri[2];
                                                        ObjProc.ReportName = attri[3];
                                                        ObjProc.Prescription_id = attri[4];
                                                        ObjProc.ProcedureType = Convert.ToInt32(attri[5]);
                                                        objList.Add(ObjProc);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.Proclist = objList;
                                    }

                                    if (values[31] != null && values[31] != string.Empty)
                                    {
                                        List<Procedure> objList = new List<Procedure>();
                                        foreach (string InnerIdentifier in values[31].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        if (attri[0] != string.Empty)
                                                        {
                                                            Procedure ObjTest = new Procedure();
                                                            ObjTest.ProcedureID = Convert.ToInt32(attri[0]);
                                                            ObjTest.ProcedureCode = attri[1];
                                                            ObjTest.ProcedureName = attri[2];
                                                            ObjTest.ReportName = attri[3];
                                                            ObjTest.Prescription_id = attri[4];
                                                            ObjTest.ProcedureType = Convert.ToInt32(attri[5]);
                                                            objList.Add(ObjTest);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        objPres.Testlist = objList;
                                    }

                                    if (values[32] != null && values[32] != string.Empty)
                                    {
                                        List<Ailment> objList = new List<Ailment>();
                                        foreach (string InnerIdentifier in values[32].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        Ailment ObjAilmnet = new Ailment();
                                                        ObjAilmnet.code = attri[0];
                                                        ObjAilmnet.AilmentName = attri[1];
                                                        ObjAilmnet.Prescription_id = attri[2];
                                                        objList.Add(ObjAilmnet);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.Ailment_Details = objList;
                                    }


                                    if (values[33] != null && values[33] != string.Empty)
                                    {
                                        List<PrescriptionClass.complaint> objList = new List<PrescriptionClass.complaint>();
                                        foreach (string InnerIdentifier in values[33].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        PrescriptionClass.complaint ObjComplaints = new PrescriptionClass.complaint();
                                                        ObjComplaints.name = attri[0];
                                                        ObjComplaints.Prescription_id = attri[1];
                                                        objList.Add(ObjComplaints);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.complaints = objList;
                                    }

                                    objPres.pharmacyId = values[34];
                                    if (values[35] != string.Empty)
                                        objPres.Is_health_check = Convert.ToInt32(values[35]);


                                    if (values[36] != null && values[36] != string.Empty)
                                    {
                                        objPres.HCU = new HealthCheckup();
                                        foreach (string InnerIdentifier in values[36].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);

                                                        objPres.HCU.HCName = attri[0];
                                                        objPres.HCU.Prescription_id = attri[1];

                                                    }
                                                }
                                            }
                                        }

                                    }
                                    if (values[37] != string.Empty)
                                        objPres.AutoShowReport = Convert.ToInt32(values[37]);

                                    if (values[38] != null && values[38] != string.Empty)
                                    {
                                        objPres.AttachmentsLst = new List<OP_Attachments>();
                                        foreach (string InnerIdentifier in values[38].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        OP_Attachments objatt = new OP_Attachments();
                                                        objatt.AttachDate = attri[0];
                                                        objatt.AttachFileName = attri[1];
                                                        objatt.AttachmentRemarks = attri[2];
                                                        objatt.Claim_Id = attri[3];
                                                        objatt.FilePath = attri[4];
                                                        if (attri[5] != string.Empty)
                                                            objatt.PatientId = Convert.ToInt32(attri[5]);
                                                        if (attri[6] != string.Empty)
                                                            objatt.Self_ID = Convert.ToInt32(attri[6]);
                                                        objPres.AttachmentsLst.Add(objatt);
                                                    }
                                                }
                                            }
                                        }

                                    }

                                    if (values.Length > 39 && values[39] != null && values[39] != string.Empty)
                                    {
                                        objPres.VitalsLst = new List<Vital_Controls>();
                                        foreach (string InnerIdentifier in values[39].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        Vital_Controls obj1 = new Vital_Controls();
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        obj1.CONTROL_TEXT = attri[0];
                                                        obj1.CONTROL_TEXT_STYLE = attri[1];
                                                        obj1.CONTROL_TEXT_VALUE = attri[2];
                                                        obj1.CONTROL_TYPE = attri[3];
                                                        if (!string.IsNullOrWhiteSpace(attri[4]))
                                                            obj1.DISPLAY_ORDER = Convert.ToInt32(attri[4]);
                                                        if (!string.IsNullOrWhiteSpace(attri[5]))
                                                            obj1.IS_EXPAND = Convert.ToInt32(attri[5]);
                                                        if (!string.IsNullOrWhiteSpace(attri[6]))
                                                            obj1.IS_2TEXTBOX = Convert.ToInt32(attri[6]);
                                                        obj1.CLAIM_ID = attri[7];
                                                        objPres.VitalsLst.Add(obj1);
                                                    }
                                                }
                                            }
                                        }

                                    }


                                    if (values.Length > 40 && values[40] != null && values[40] != string.Empty)
                                    {
                                        objPres.Diagnostic_Range = new List<DiagnosticRange>();
                                        foreach (string InnerIdentifier in values[40].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        DiagnosticRange objDR = new DiagnosticRange();
                                                        objDR.DIAGNOSTIC_CODE = attri[0];
                                                        objDR.KEY = attri[1];
                                                        objDR.VALUE = attri[2];
                                                        objPres.Diagnostic_Range.Add(objDR);
                                                    }
                                                }
                                            }
                                        }

                                    }

                                    if (values[41] != null && values[41] != string.Empty)
                                    {
                                        List<PrescriptionClass.SecondaryAilment> objList = new List<PrescriptionClass.SecondaryAilment>();
                                        foreach (string InnerIdentifier in values[41].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (InnerIdentifier != string.Empty)
                                            {
                                                foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (InnerElement != string.Empty)
                                                    {
                                                        string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                        PrescriptionClass.SecondaryAilment ObjComplaints = new PrescriptionClass.SecondaryAilment();
                                                        ObjComplaints.SecondaryAilmentname = attri[0];

                                                        objList.Add(ObjComplaints);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.secondaryAilments = objList;
                                    }

                                    if (values[42] != null && values[42] != string.Empty)
                                    {
                                        objPres.HasDiagnostic = Convert.ToInt32(values[42].ToString());
                                    }


                                    if (values[43] != null && values[43] != string.Empty)
                                    {
                                        objPres.HasDiagnosticOrder = Convert.ToInt32(values[43].ToString());
                                    }
                                    if (values[44] != null && values[44] != string.Empty)
                                    {
                                        objPres.OrderByOrderDate = Convert.ToDateTime(values[44].ToString(), culture);
                                    }
                                    if (values[45] != null && values[45] != string.Empty)
                                    {
                                        objPres.OrderByPrescDate = Convert.ToDateTime(values[45].ToString(), culture);
                                    }
                                    if (values[46] != null && values[46] != string.Empty)
                                    {
                                        objPres.IsView = Convert.ToBoolean(values[46].ToString());
                                    }
                                    if (values[47] != null && values[47] != string.Empty)
                                    {
                                        objPres.HasDrug = Convert.ToInt32(values[47].ToString());
                                    }
                                    if (values[48] != null && values[48] != string.Empty)
                                    {
                                        objPres.patient_id = Convert.ToString(values[48]);
                                    }
                                    if (values[49] != null && values[49] != string.Empty)
                                    {
                                        objPres.HasPharmachyOrder = Convert.ToInt32(values[49]);
                                    }

                                    lstpres.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return lstpres;
        }


        public string Physician_GetDashboardDeatails_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ailmentName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.BillAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ChatDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.UnreadMsgCount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physician_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.pharmacyId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.LastFetchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.AppointmentId);
                //consultation
                //if (PreClass.Consultation != null)
                //{
                //    strOutPut.Append(Inner_ListIdentifier_Start);
                //    strOutPut.Append(PreClass.Consultation.Speciality);
                //    strOutPut.Append(Inner_ListIdentifier_End);
                //}
                //else
                //{
                //    strOutPut.Append("");
                //}

                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> Physician_GetDashboardDeatails_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] attri = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = attri[0];
                                    objPres.patientName = attri[1];
                                    objPres.patient_id = attri[2];
                                    objPres.ailmentName = attri[3];
                                    objPres.prescriptionDate = attri[4];
                                    if (attri[5] != string.Empty)
                                        objPres.BillAmt = Convert.ToDecimal(attri[5]);
                                    objPres.ChatDate = attri[6];
                                    if (attri[7] != string.Empty)
                                        objPres.UnreadMsgCount = Convert.ToInt32(attri[7]);
                                    objPres.physicianName = attri[8];
                                    objPres.physician_id = attri[9];
                                    objPres.pharmacyId = attri[10];
                                    objPres.LastFetchTime = attri[11];
                                    objPres.AppointmentId = Convert.ToInt32(attri[12]);
                                    // objPres.Consultation.Speciality = attri[11];

                                    //if (!string.IsNullOrEmpty(attri[12]))
                                    //{
                                    //    foreach (string list1 in attri[12].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                    //    {
                                    //        if (list1 != string.Empty)
                                    //        {
                                    //            //foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                    //            {
                                    //                // if (innerlist1 != string.Empty)
                                    //                {
                                    //                    Consultation obj = new Consultation();
                                    //                    string[] values1 = list1.Split(Inner_ListProperty_Split);
                                    //                    obj.Speciality = values1[0];
                                    //                    objPres.Consultation = obj;
                                    //                }
                                    //            }

                                    //        }
                                    //    }
                                    //}

                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string Physician_GetDiagnosisDashboarddetails_Serialize(List<RN.MOBILE_COMMON.Diagnosis> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Diagnosis objDiag in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objDiag.ClaimID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objDiag.Patientname);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objDiag.patientid);
                strOutPut.Append(ListProperty_Split);
                if (objDiag.lst != null && objDiag.lst.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Diagnosis objlst in objDiag.lst)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objlst.DiagnosisName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.DiagnosisID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.ClaimID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.Date);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objlst.filename);
                        strOutPut.Append(Inner_ListElement_End);
                    }

                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<RN.MOBILE_COMMON.Diagnosis> Physician_GetDiagnosisDashboarddetails_Deserialize(string Response, string Token)
        {
            List<RN.MOBILE_COMMON.Diagnosis> lstDiag = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnosis objDiag = new Diagnosis();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objDiag.ClaimID = attri[0];
                            objDiag.Patientname = attri[1];
                            if (attri[2] != string.Empty)
                                objDiag.patientid = Convert.ToInt32(attri[2]);

                            if (attri[3] != null && attri[3] != string.Empty)
                            {
                                List<RN.MOBILE_COMMON.Diagnosis> lstDiag1 = new List<Diagnosis>();
                                foreach (string list1 in attri[3].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Diagnosis objDiag1 = new Diagnosis();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objDiag1.DiagnosisName = attri1[0];
                                                if (attri1[1] != string.Empty)
                                                    objDiag1.DiagnosisID = Convert.ToInt32(attri1[1]);
                                                if (attri1[2] != string.Empty)
                                                    objDiag1.ClaimID = attri1[2];
                                                objDiag1.Date = attri1[3];
                                                objDiag1.filename = attri1[4];
                                                lstDiag1.Add(objDiag1);
                                            }
                                        }
                                    }
                                }
                                objDiag.lst = lstDiag1;
                            }
                            lstDiag.Add(objDiag);
                        }
                    }
                }
            }
            return lstDiag;
        }
        public string GetDashboardDeatailsSearch_Phy_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ailmentName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.BillAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ChatDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.UnreadMsgCount);

                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetDashboardDeatailsSearch_Phy_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] attri = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = attri[0];
                                    objPres.patientName = attri[1];
                                    objPres.patient_id = attri[2];
                                    objPres.ailmentName = attri[3];
                                    objPres.prescriptionDate = attri[4];
                                    if (attri[5] != string.Empty)
                                        objPres.BillAmt = Convert.ToDecimal(attri[5]);
                                    objPres.ChatDate = attri[6];
                                    if (attri[7] != string.Empty)
                                        objPres.UnreadMsgCount = Convert.ToInt32(attri[7]);


                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetAccountDetails_Phy_Serialize(Physician objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objResposne.UserName);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.MobileNo);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.RegistrationNo);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.SpecialityID);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.ClinicName);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.ClinicAddress);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.PINCode);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.EmailID);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.CityID);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.Speciality);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.CityName);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.Qualification);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.QualificationID);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public Physician GetAccountDetails_Phy_Deserialize(string Response, string Token)
        {
            Physician obj = new Physician();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);

            obj.UserName = values[0];
            obj.MobileNo = values[1];
            obj.RegistrationNo = values[2];
            if (values[3] != string.Empty)
                obj.SpecialityID = Convert.ToInt32(values[3]);
            obj.ClinicName = values[4];
            obj.ClinicAddress = values[5];
            obj.PINCode = values[6];
            obj.EmailID = values[7];
            if (values[8] != string.Empty)
                obj.CityID = Convert.ToInt32(values[8]);
            obj.Speciality = values[9];
            obj.CityName = values[10];
            obj.Qualification = values[11];
            if (values[12] != string.Empty)
                obj.QualificationID = Convert.ToInt32(values[12]);
            return obj;
        }
        public string GetPrescriptionHistory_Phy_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ailmentName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physician_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.MobileNo);

                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetPrescriptionHistory_Phy_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] attri = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = attri[0];
                                    objPres.patientName = attri[1];
                                    objPres.patient_id = attri[2];
                                    objPres.ailmentName = attri[3];
                                    objPres.prescriptionDate = attri[4];
                                    objPres.physicianName = attri[5];
                                    objPres.physician_id = attri[6];
                                    objPres.MobileNo = attri[7];


                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetPatientDetail_Phy_Serialize(Patient Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();

            objOutPut.Append(Response.PatienID);
            objOutPut.Append(split);
            objOutPut.Append(Response.UserName);
            objOutPut.Append(split);
            objOutPut.Append(Response.Age);
            objOutPut.Append(split);
            objOutPut.Append(Response.Gender);
            objOutPut.Append(split);
            objOutPut.Append(Response.MobileNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.WalletAmount);
            objOutPut.Append(split);
            if (Response.Consultation != null)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(Response.Consultation.ConsultationFee);
                objOutPut.Append(ListElement_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);

            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }


        public Patient GetPatientDetail_Phy_Deserialize(string Response, string token)
        {
            Patient objPat = new Patient();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objPat.PatienID = Convert.ToInt32(values[0]);
            objPat.UserName = values[1];
            if (values[2] != string.Empty)
                objPat.Age = Convert.ToInt16(values[2]);
            objPat.Gender = values[3];
            objPat.MobileNo = values[4];
            if (values[5] != string.Empty)
                objPat.WalletAmount = Convert.ToDecimal(values[5]);

            if (values[6] != null && values[6] != string.Empty)
            {
                Consultation obj = new Consultation();
                foreach (string innerlist in values[6].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        obj.ConsultationFee = attri[0];
                    }
                }
                objPat.Consultation = obj;
            }


            return objPat;
        }

        public string GetAilmentMaster_Phy_Serialize(List<Ailment> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Ailment objAil in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objAil.AilmentID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objAil.AilmentName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objAil.code);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Ailment> GetAilmentMaster_Phy_Deserialize(string Response, string Token)
        {
            List<Ailment> objail = new List<Ailment>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Ailment obj = new Ailment();
                            if (attri[0] != string.Empty)
                                obj.AilmentID = Convert.ToInt32(attri[0]);
                            obj.AilmentName = attri[1];
                            obj.code = attri[2];
                            objail.Add(obj);
                        }
                    }
                }
            }
            return objail;
        }

        public string GetAppointment_Phy_Serialize(List<Appointment> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Appointment objApp in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objApp.AppointmentID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.AppointmentDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.BookedDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EligibleAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.MemberID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PhysicianId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PhysicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PolicyNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SpecialityID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SpecialityDec);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientAge);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientGender);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientRelationShip);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Status);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Status_Desc);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.CAN_CANCEL);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientEmailID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientMobileNo);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }


        public List<Appointment> GetAppointment_Phy_Deserialize(string Response, string Token)
        {
            List<Appointment> objapp = new List<Appointment>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Appointment obj = new Appointment();
                            if (attri[0] != string.Empty)
                                obj.AppointmentID = Convert.ToInt32(attri[0]);
                            obj.AppointmentDate = attri[1];
                            obj.BookedDate = attri[2];
                            if (attri[3] != string.Empty)
                                obj.EligibleAmt = Convert.ToDecimal(attri[3]);
                            if (attri[4] != string.Empty)
                                obj.EntityID = Convert.ToInt32(attri[4]);
                            obj.EntityName = attri[5];
                            obj.MemberID = attri[6];
                            if (attri[7] != string.Empty)
                                obj.PatientId = Convert.ToInt32(attri[7]);
                            obj.PatientName = attri[8];
                            if (attri[9] != string.Empty)
                                obj.PhysicianId = Convert.ToInt32(attri[9]);
                            obj.PhysicianName = attri[10];
                            obj.PolicyNo = attri[11];
                            if (attri[12] != string.Empty)
                                obj.SlotID = Convert.ToInt32(attri[12]);
                            if (attri[13] != string.Empty)
                                obj.SpecialityID = Convert.ToInt32(attri[13]);
                            obj.SpecialityDec = attri[14];
                            obj.SlotTime = attri[15];
                            obj.PatientAge = attri[16];
                            obj.PatientGender = attri[17];
                            obj.PatientRelationShip = attri[18];
                            if (attri[19] != string.Empty)
                                obj.Status = Convert.ToInt32(attri[19]);
                            obj.Status_Desc = attri[20];
                            if (attri[21] != string.Empty)
                                obj.CAN_CANCEL = Convert.ToInt32(attri[21]);
                            if (attri.Length > 22)
                                obj.PatientEmailID = attri[22];
                            if (attri.Length > 23)
                                obj.PatientMobileNo = attri[23];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }


        public string GetAppointment_Phy_Serialize_new(List<Appointment> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Appointment objApp in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objApp.AppointmentID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.AppointmentDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.BookedDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EligibleAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.MemberID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PhysicianId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PhysicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PolicyNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SpecialityID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SpecialityDec);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientAge);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientGender);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientRelationShip);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Status);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Status_Desc);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.CAN_CANCEL);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.LastFetchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.OrderByAppDate);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }


        public List<Appointment> GetAppointment_Phy_Deserialize_new(string Response, string Token)
        {
            List<Appointment> objapp = new List<Appointment>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Appointment obj = new Appointment();
                            if (attri[0] != string.Empty)
                                obj.AppointmentID = Convert.ToInt32(attri[0]);
                            obj.AppointmentDate = attri[1];
                            obj.BookedDate = attri[2];
                            if (attri[3] != string.Empty)
                                obj.EligibleAmt = Convert.ToDecimal(attri[3]);
                            if (attri[4] != string.Empty)
                                obj.EntityID = Convert.ToInt32(attri[4]);
                            obj.EntityName = attri[5];
                            obj.MemberID = attri[6];
                            if (attri[7] != string.Empty)
                                obj.PatientId = Convert.ToInt32(attri[7]);
                            obj.PatientName = attri[8];
                            if (attri[9] != string.Empty)
                                obj.PhysicianId = Convert.ToInt32(attri[9]);
                            obj.PhysicianName = attri[10];
                            obj.PolicyNo = attri[11];
                            if (attri[12] != string.Empty)
                                obj.SlotID = Convert.ToInt32(attri[12]);
                            if (attri[13] != string.Empty)
                                obj.SpecialityID = Convert.ToInt16(attri[13]);
                            obj.SpecialityDec = attri[14];
                            obj.SlotTime = attri[15];
                            obj.PatientAge = attri[16];
                            obj.PatientGender = attri[17];
                            obj.PatientRelationShip = attri[18];
                            if (attri[19] != string.Empty)
                                obj.Status = Convert.ToInt16(attri[19]);
                            obj.Status_Desc = attri[20];
                            if (attri[21] != string.Empty)
                                obj.CAN_CANCEL = Convert.ToInt16(attri[21]);
                            if (attri[22] != string.Empty)
                                obj.LastFetchTime = Convert.ToString(attri[22]);
                            if (attri[23] != string.Empty)
                                obj.SlotType = Convert.ToInt16(attri[23]);
                            if (attri[24] != string.Empty)
                                obj.OrderByAppDate = Convert.ToDateTime(attri[24], culture);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }
        public string GetProcedureMaster_Phy_Serialize(List<Procedure> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Procedure objPro in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objPro.ProcedureID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.ProcedureName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.ProcedureCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.ProcedureType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.FEE_TYPE);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Procedure> GetProcedureMaster_Phy_Deserialize(string Response, string Token)
        {
            List<Procedure> objapp = new List<Procedure>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Procedure obj = new Procedure();
                            if (attri[0] != string.Empty)
                                obj.ProcedureID = Convert.ToInt32(attri[0]);
                            obj.ProcedureName = attri[1];
                            obj.ProcedureCode = attri[2];
                            if (attri.Length > 3 && attri[3] != string.Empty)
                                obj.ProcedureType = Convert.ToInt32(attri[3]);
                            if (attri.Length > 4 && attri[4] != string.Empty)
                                obj.FEE_TYPE = Convert.ToInt32(attri[4]);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetDrugMaster_Phy_Serialize(List<Drug> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Drug objPro in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objPro.DrugID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DrugName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DrugCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.QUANTITY_AVAILABLE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DrugQuantity);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DRUG_TYPE_DESC);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DRUG_TYPE);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Drug> GetDrugMaster_Phy_Deserialize(string Response, string Token)
        {
            List<Drug> objapp = new List<Drug>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Drug obj = new Drug();
                            if (attri[0] != string.Empty)
                                obj.DrugID = Convert.ToInt32(attri[0]);
                            obj.DrugName = attri[1];
                            obj.DrugCode = attri[2];
                            if (attri[3] != string.Empty)
                                obj.QUANTITY_AVAILABLE = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                obj.DrugQuantity = Convert.ToInt32(attri[4]);
                            obj.DRUG_TYPE_DESC = attri[5];
                            if (attri[6] != string.Empty)
                                obj.DRUG_TYPE = Convert.ToInt32(attri[6]);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetRecentAilmentDetails_Phy_Serialize(List<Drug> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Drug objPro in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objPro.DrugID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DrugName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DrugQuantity);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.NoOfDays);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.Morning);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.Afternoon);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.Night);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DRUG_TYPE_DESC);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.Evening);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Drug> GetRecentAilmentDetails_Phy_Deserialize(string Response, string Token)
        {
            List<Drug> objapp = new List<Drug>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Drug obj = new Drug();
                            if (attri[0] != string.Empty)
                                obj.DrugID = Convert.ToInt32(attri[0]);
                            obj.DrugName = attri[1];
                            if (attri[2] != string.Empty)
                                obj.DrugQuantity = Convert.ToInt32(attri[2]);
                            if (attri[3] != string.Empty)
                                obj.NoOfDays = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                obj.Morning = Convert.ToDecimal(attri[4]);
                            if (attri[5] != string.Empty)
                                obj.Afternoon = Convert.ToDecimal(attri[5]);
                            if (attri[6] != string.Empty)
                                obj.Night = Convert.ToDecimal(attri[6]);
                            obj.DRUG_TYPE_DESC = attri[7];
                            if (attri[8] != string.Empty)
                                obj.Evening = Convert.ToDecimal(attri[8]);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetPharmacyDetails_Phy_Serialize(List<RN.MOBILE_COMMON.Pharmacy> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (Pharmacy objPhar in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objPhar.PharmacyID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.PharmacyName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.PharmacyType);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.ShippingCharge);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.DeliveryMinTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.DeliveryMaxTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objPhar.Discount);
                outPut.Append(ListProperty_Split);
                //Drug list
                if (objPhar.Drugs != null)
                {
                    outPut.Append(Inner_ListIdentifier_Start);
                    foreach (Drug objDrug in objPhar.Drugs)
                    {
                        outPut.Append(Inner_ListElement_Start);
                        outPut.Append(objDrug.DrugID);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.DrugName);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.Rate);
                        outPut.Append(Inner_ListProperty_Split);
                        outPut.Append(objDrug.PharmacyID);
                        outPut.Append(Inner_ListElement_End);
                    }
                    outPut.Append(Inner_ListIdentifier_End);
                }
                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<RN.MOBILE_COMMON.Pharmacy> GetPharmacyDetails_Phy_Deserialize(string Response, string token)
        {
            List<RN.MOBILE_COMMON.Pharmacy> objListPhar = new List<Pharmacy>();

            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {

                        if (innerlist != string.Empty)
                        {
                            Pharmacy objPhar = new Pharmacy();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objPhar.PharmacyID = Convert.ToInt32(attri[0]);
                            objPhar.PharmacyName = attri[1];
                            if (attri[2] != string.Empty)
                                objPhar.PharmacyType = Convert.ToInt32(attri[2]);
                            if (attri[3] != string.Empty)
                                objPhar.ShippingCharge = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                objPhar.DeliveryMinTime = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                objPhar.DeliveryMaxTime = Convert.ToInt32(attri[5]);
                            if (attri[6] != string.Empty)
                                objPhar.Discount = Convert.ToInt32(attri[6]);
                            if (attri[7] != null && attri[7] != string.Empty)
                            {
                                foreach (string List1 in attri[7].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (List1 != string.Empty)
                                    {
                                        List<Drug> objListDrug = new List<Drug>();

                                        foreach (string innerlist1 in list.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Drug objDrug = new Drug();
                                                string[] attri1 = innerlist.Split(Inner_ListProperty_Split);
                                                if (attri1[0] != string.Empty)
                                                    objDrug.DrugID = Convert.ToInt32(attri1[0]);
                                                objDrug.DrugName = attri1[1];
                                                if (attri1[2] != string.Empty)
                                                    objDrug.Rate = Convert.ToDecimal(attri1[2]);
                                                if (attri1[3] != string.Empty)
                                                    objDrug.PharmacyID = Convert.ToInt32(attri1[3]);

                                                objListDrug.Add(objDrug);
                                            }
                                        }

                                        objPhar.Drugs = objListDrug;
                                    }
                                }
                            }
                            objListPhar.Add(objPhar);
                        }

                    }
                }
            }
            return objListPhar;
        }

        public string SavePatientDetails_Phy_Serialize(PolicyValidation objpolicyval, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objpolicyval != null)
            {
                strOutPut.Append(objpolicyval.PrescriptionID);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.ClaimID);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.order_id);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.BillAmount);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.PatientPayable);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.PayerPayable);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.EligibleAmt);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.CoPay);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.CoPayRelation);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.MaxCoPay);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.OTP);
                strOutPut.Append(split);
                if (objpolicyval.ValDet != null && objpolicyval.ValDet.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (polval objval in objpolicyval.ValDet)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objval.valName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objval.valMsg);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);
                if (objpolicyval.PPBreakUp != null && objpolicyval.PPBreakUp.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (PayerPayableBreakUp obj in objpolicyval.PPBreakUp)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(obj.ValLabel);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Value);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);
                if (objpolicyval.validationDataTable != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objpolicyval.validationDataTable.CLAIM_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.REMARKS);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.GROUP_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.ERROR_FLAG);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_LABEL);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_MESSAGE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.TARIFF_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.ELIGIBLE_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.DISALLOWED_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.PAYABLE_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.INFO_FLAG);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.DISPLAY_FLAG);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.BILL_ITEM_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.GROUP_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_MESSAGE_1);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_MESSAGE_2);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.NO_CO_PAY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.COPAY_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.COPAY_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.ORDER_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.validationDataTable.PAYMENT_ID);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);
                if (objpolicyval.tranDataTable != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objpolicyval.tranDataTable.CLAIM_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.PRODUCT_COPAY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.COPAY_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.TOTAL_COPAY_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.TOTAL_BILL_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.TOTAL_ELIGIBLE_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.TOTAL_APPROVED_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.TOTAL_PATIENT_PAYABLE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.MOBILE_NO);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.TOTAL_PAYABLE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.EMAIL_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.MEMBER_FIRST_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.MEMBER_LAST_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.MEMBER_MIDDLE_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.PAYER_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.tranDataTable.POLICY_NO);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.ValidationResult);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.ErrorCode);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.ErrorDesc);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.MemberId);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.Payer_Code);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.TransactionTimeOut);
                strOutPut.Append(split);
            }

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PolicyValidation SavePatientDetails_Phy_Deserialize(string Response, string token)
        {
            PolicyValidation objpolicyval = new PolicyValidation();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 0)
            {
                objpolicyval.PrescriptionID = values[0];
                if (!string.IsNullOrEmpty(values[1]))
                    objpolicyval.ClaimID = Convert.ToString(values[1]);
                objpolicyval.order_id = values[2];
                if (!string.IsNullOrEmpty(values[3]))
                    objpolicyval.BillAmount = Convert.ToDecimal(values[3]);
                if (!string.IsNullOrEmpty(values[4]))
                    objpolicyval.PatientPayable = Convert.ToDecimal(values[4]);
                if (!string.IsNullOrEmpty(values[5]))
                    objpolicyval.PayerPayable = Convert.ToDecimal(values[5]);
                if (!string.IsNullOrEmpty(values[6]))
                    objpolicyval.EligibleAmt = Convert.ToDecimal(values[6]);
                if (!string.IsNullOrEmpty(values[7]))
                    objpolicyval.CoPay = Convert.ToDecimal(values[7]);
                objpolicyval.CoPayRelation = values[8];
                objpolicyval.MaxCoPay = values[9];
                objpolicyval.OTP = values[10];

                if (values[11] != null && values[11] != string.Empty)
                {
                    foreach (string list in values[11].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    objpolicyval.ValDet = new List<polval>();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        polval objval = new polval();
                                        objval.valName = attri[0];
                                        objval.valMsg = attri[1];
                                        objpolicyval.ValDet.Add(objval);
                                    }
                                }
                            }
                        }
                    }
                }

                if (values[12] != null && values[12] != string.Empty)
                {
                    foreach (string list in values[12].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    objpolicyval.PPBreakUp = new List<PayerPayableBreakUp>();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        PayerPayableBreakUp obj1 = new PayerPayableBreakUp();
                                        obj1.ValLabel = attri[0];
                                        if (!string.IsNullOrEmpty(attri[1]))
                                            obj1.Value = Convert.ToDecimal(attri[1]);

                                        objpolicyval.PPBreakUp.Add(obj1);
                                    }
                                }
                            }
                        }
                    }
                }


                if (values[13] != null && values[13] != string.Empty)
                {
                    foreach (string innerlist in values[13].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri.Length > 0)
                            {
                                ValidationSummary obj = new ValidationSummary();
                                obj.CLAIM_ID = attri[0];
                                obj.REMARKS = attri[1];
                                obj.GROUP_ID = attri[2];
                                obj.ERROR_FLAG = attri[3];
                                obj.VALIDATION_NAME = attri[4];
                                obj.VALIDATION_LABEL = attri[5];
                                obj.VALIDATION_MESSAGE = attri[6];
                                obj.TARIFF_AMOUNT = attri[7];
                                obj.ELIGIBLE_AMOUNT = attri[8];
                                obj.DISALLOWED_AMOUNT = attri[9];
                                obj.PAYABLE_AMOUNT = attri[10];
                                obj.INFO_FLAG = attri[11];
                                obj.DISPLAY_FLAG = attri[12];
                                obj.BILL_ITEM_ID = attri[13];
                                obj.GROUP_NAME = attri[14];
                                obj.VALIDATION_MESSAGE_1 = attri[15];
                                obj.VALIDATION_MESSAGE_2 = attri[16];
                                obj.NO_CO_PAY = attri[17];
                                obj.COPAY_AMOUNT = attri[18];
                                obj.COPAY_TYPE = attri[19];
                                obj.DISPLAY_ORDER = attri[20];
                                obj.ORDER_ID = attri[21];
                                obj.PAYMENT_ID = attri[22];

                                objpolicyval.validationDataTable = obj;
                            }
                        }
                    }
                }

                if (values[14] != null && values[14] != string.Empty)
                {
                    foreach (string innerlist in values[14].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri.Length > 0)
                            {
                                TranSummary obj = new TranSummary();
                                obj.CLAIM_ID = attri[0];
                                obj.PRODUCT_COPAY = attri[1];
                                obj.COPAY_TYPE = attri[2];
                                obj.TOTAL_COPAY_AMOUNT = attri[3];
                                obj.TOTAL_BILL_AMOUNT = attri[4];
                                obj.TOTAL_ELIGIBLE_AMOUNT = attri[5];
                                obj.TOTAL_APPROVED_AMOUNT = attri[6];
                                obj.TOTAL_PATIENT_PAYABLE = attri[7];
                                obj.MOBILE_NO = attri[8];
                                obj.TOTAL_PAYABLE = attri[9];
                                obj.EMAIL_ID = attri[10];
                                obj.MEMBER_FIRST_NAME = attri[11];
                                obj.MEMBER_LAST_NAME = attri[12];
                                obj.MEMBER_MIDDLE_NAME = attri[13];
                                obj.PAYER_CODE = attri[14];
                                obj.POLICY_NO = attri[15];

                                objpolicyval.tranDataTable = obj;
                            }
                        }
                    }
                }
                objpolicyval.ValidationResult = values[15];
                objpolicyval.ErrorCode = values[16];
                objpolicyval.ErrorDesc = values[17];
                objpolicyval.MemberId = values[18];
                objpolicyval.Payer_Code = values[19];
                if (!string.IsNullOrEmpty(values[20]))
                    objpolicyval.TransactionTimeOut = Convert.ToInt16(values[20]);
            }
            return objpolicyval;
        }


        #endregion

        public string ValidatePrescriptionNo_Com_Serialize(PatientPolicyDetails _obj, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (_obj != null)
            {
                if (_obj.Patient != null)
                    strOutPut.Append(_obj.Patient.PatienID);
                else
                    strOutPut.Append("");
                strOutPut.Append(split);
                strOutPut.Append(_obj.IsOrderCompleted);
                strOutPut.Append(split);
                if (_obj.Patient_LIST != null && _obj.Patient_LIST.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Patient pat in _obj.Patient_LIST)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(pat.MemberNo);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(pat.Status);
                        strOutPut.Append(ListProperty_Split);
                        if (pat.Entity != null)
                        {
                            strOutPut.Append(pat.Entity.EntityName);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(pat.Entity.EntityID);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(pat.Entity.EntityCode);
                        }
                        else
                        {
                            strOutPut.Append("");
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append("");
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append("");
                        }
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(pat.UserName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(pat.IsActive);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(pat.PatienID);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PatientPolicyDetails ValidatePrescriptionNo_Com_Deserialize(string Response, string token)
        {
            PatientPolicyDetails _obj = new PatientPolicyDetails();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 0)
            {
                _obj.Patient = new Patient();
                if (!string.IsNullOrEmpty(values[0]))
                    _obj.Patient.PatienID = Convert.ToInt32(values[0]);
                if (!string.IsNullOrEmpty(values[1]))
                    _obj.IsOrderCompleted = Convert.ToInt32(values[1]);
                if (values[2] != null && values[2] != string.Empty)
                {
                    _obj.Patient_LIST = new List<Patient>();
                    foreach (string list in values[2].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    Patient pat = new Patient();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        pat.MemberNo = attri[0];
                                        pat.Status = attri[1];
                                        pat.Entity = new Entity();
                                        pat.Entity.EntityName = attri[2];
                                        if (!string.IsNullOrEmpty(attri[3]))
                                            pat.Entity.EntityID = Convert.ToInt32(attri[3]);
                                        pat.Entity.EntityCode = attri[4];
                                        pat.UserName = attri[5];
                                        if (!string.IsNullOrEmpty(attri[6]))
                                            pat.IsActive = Convert.ToBoolean(attri[6]);
                                        if (!string.IsNullOrEmpty(attri[7]))
                                            pat.PatienID = Convert.ToInt32(attri[7]);
                                        _obj.Patient_LIST.Add(pat);
                                    }

                                }
                            }
                        }
                    }
                }
            }

            return _obj;
        }

        public string SavePrescriptionOrder_Dia_Serialize(PolicyValidation objpolicyval, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objpolicyval != null)
            {
                strOutPut.Append(objpolicyval.PrescriptionID);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.ClaimID);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.order_id);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.BillAmount);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.PatientPayable);
                strOutPut.Append(split);
                strOutPut.Append(objpolicyval.PayerPayable);
                strOutPut.Append(split);
                if (objpolicyval.ValDet != null && objpolicyval.ValDet.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (polval objval in objpolicyval.ValDet)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objval.valName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objval.valMsg);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);
                if (objpolicyval.PPBreakUp != null && objpolicyval.PPBreakUp.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (PayerPayableBreakUp obj in objpolicyval.PPBreakUp)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(obj.ValLabel);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Value);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);

            }

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PolicyValidation SavePrescriptionOrder_Dia_Deserialize(string Response, string token)
        {
            PolicyValidation objpolicyval = new PolicyValidation();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 0)
            {
                objpolicyval.PrescriptionID = values[0];
                if (!string.IsNullOrEmpty(values[1]))
                    objpolicyval.ClaimID = Convert.ToString(values[1]);
                objpolicyval.order_id = values[2];
                if (!string.IsNullOrEmpty(values[3]))
                    objpolicyval.BillAmount = Convert.ToDecimal(values[3]);
                if (!string.IsNullOrEmpty(values[4]))
                    objpolicyval.PatientPayable = Convert.ToDecimal(values[4]);
                if (!string.IsNullOrEmpty(values[5]))
                    objpolicyval.PayerPayable = Convert.ToDecimal(values[5]);
                if (values[6] != null && values[6] != string.Empty)
                {
                    foreach (string list in values[6].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    objpolicyval.ValDet = new List<polval>();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        polval objval = new polval();
                                        objval.valName = attri[0];
                                        objval.valMsg = attri[1];
                                        objpolicyval.ValDet.Add(objval);
                                    }
                                }
                            }
                        }
                    }
                }
                if (values[7] != null && values[7] != string.Empty)
                {
                    foreach (string list in values[7].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    objpolicyval.PPBreakUp = new List<PayerPayableBreakUp>();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        PayerPayableBreakUp obj1 = new PayerPayableBreakUp();
                                        obj1.ValLabel = attri[0];
                                        if (!string.IsNullOrEmpty(attri[1]))
                                            obj1.Value = Convert.ToDecimal(attri[1]);

                                        objpolicyval.PPBreakUp.Add(obj1);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return objpolicyval;
        }


        public string GetHealthCheckPackage_Dia_Serialize(List<HealthCheckup> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            foreach (HealthCheckup obj in Response)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(obj.HCId);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.HCCode);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.HCName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.Rate);
                objOutPut.Append(ListElement_End);
            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }

        public List<HealthCheckup> GetHealthCheckPackage_Dia_Deserialize(string Response, string token)
        {
            List<HealthCheckup> objList = new List<HealthCheckup>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            HealthCheckup obj = new HealthCheckup();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                obj.HCId = Convert.ToInt32(attri[0]);
                            if (attri[1] != string.Empty)
                                obj.HCCode = attri[1];
                            if (attri[2] != string.Empty)
                                obj.HCName = attri[2];
                            if (attri[2] != string.Empty)
                                obj.Rate = Convert.ToDecimal(attri[3]);
                            objList.Add(obj);
                        }
                    }
                }
            }
            return objList;
        }

        public string GetCheckUpDashboardDetails_Dia_Serialize(List<Diagnosis> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            foreach (Diagnosis obj in Response)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(obj.ClaimID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.Date);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.DiagnosisName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.Patientname);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.DiagnosisRate);
                objOutPut.Append(ListElement_End);
            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }

        public List<Diagnosis> GetCheckUpDashboardDetails_Dia_Deserialize(string Response, string token)
        {
            List<Diagnosis> objList = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnosis obj = new Diagnosis();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                obj.ClaimID = attri[0];
                            if (attri[1] != string.Empty)
                                obj.Date = attri[1];
                            if (attri[2] != string.Empty)
                                obj.DiagnosisName = attri[2];
                            if (attri[3] != string.Empty)
                                obj.Patientname = attri[3];
                            if (attri[4] != string.Empty)
                                obj.DiagnosisRate = Convert.ToDecimal(attri[4]);
                            objList.Add(obj);
                        }
                    }
                }
            }
            return objList;
        }

        public string HealthCheckup_Serialize(HealthCheckup obj, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (obj != null)
            {
                strOutPut.Append(obj.HCId);
                strOutPut.Append(split);
                strOutPut.Append(obj.HCCode);
                strOutPut.Append(split);
                strOutPut.Append(obj.HCName);
                strOutPut.Append(split);
                strOutPut.Append(obj.HCDate);
                strOutPut.Append(split);
                strOutPut.Append(obj.Rate);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public HealthCheckup HealthCheckup_Deserialize(string Response, string token)
        {
            HealthCheckup _HC_OUT = new HealthCheckup();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length == 5)
            {
                if (!string.IsNullOrEmpty(values[0]))
                    _HC_OUT.HCId = Convert.ToInt32(values[0]);
                _HC_OUT.HCCode = values[1];
                _HC_OUT.HCName = values[2];
                _HC_OUT.HCDate = values[3];
                if (!string.IsNullOrEmpty(values[4]))
                    _HC_OUT.Rate = Convert.ToDecimal(values[4]);
            }
            return _HC_OUT;
        }

        public string Boolean_Response_serialize(string Response, string token)
        {
            string outPut = string.Empty;

            outPut = Response.ToString();

            return StringCipher.Encrypt(outPut, token);
        }

        public bool Boolean_Response_Deserialize(string Resposne, string token)
        {
            bool outPut = false;

            outPut = Convert.ToBoolean(StringCipher.Decrypt(Resposne, token));

            return outPut;
        }

        public string Response_Deserialize(string Resposne, string token)
        {
            string outPut = string.Empty;

            outPut = StringCipher.Decrypt(Resposne, token);

            return outPut;
        }

        public string String_Response_serialize(string Response, string token)
        {
            string outPut = string.Empty;

            outPut = Response.ToString();
            return StringCipher.Encrypt(outPut, token);
        }

        public string String_Response_Deserialize(string Resposne, string token)
        {
            string outPut = string.Empty;
            // "EMPTY" need to handle at page level.. if empty string return
            outPut = StringCipher.Decrypt(Resposne, token);

            return outPut;
        }

        public string String_Response_serialize_Key(string Response)
        {
            string outPut = string.Empty;

            outPut = Response.ToString();
            return StringCipher.Encrypt(outPut, key);
        }

        public string String_Response_Deserialize_Key(string Resposne)
        {
            string outPut = string.Empty;
            // "EMPTY" need to handle at page level.. if empty string return
            outPut = StringCipher.Decrypt(Resposne, key);

            return outPut;
        }

        public string GetHealthCheckDiagnostic_Dia_Serialize(List<Diagnosis> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            foreach (Diagnosis obj in Response)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(obj.DiagnosisID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.DiagnosisName);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.DiagnosisCode);
                objOutPut.Append(ListElement_End);
            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }

        public List<Diagnosis> GetHealthCheckDiagnostic_Dia_Deserialize(string Response, string token)
        {
            List<Diagnosis> objList = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnosis obj = new Diagnosis();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                obj.DiagnosisID = Convert.ToInt32(attri[0]);
                            if (attri[1] != string.Empty)
                                obj.DiagnosisName = attri[1];
                            obj.DiagnosisCode = attri[2];
                            objList.Add(obj);
                        }
                    }
                }
            }
            return objList;
        }

        public string GetPrescriptionDetail_Phar_Serialize(PrescriptionClass Prescription, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Prescription != null)
            {
                strOutPut.Append(Prescription.Is_health_check);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.prescriptionId);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.physicianName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.physician_id);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.patientName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.prescriptionDate);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.patient_id);//7
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentid);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PrescriptionType);//11
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryCity);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryAddress);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryPinCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PrecFileName);//15
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PatientGender);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PatientAge);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.MobileNo);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PharmacyRemarks);//19
                strOutPut.Append(split);

                #region Drug List

                if (Prescription.Druglist != null && Prescription.Druglist.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Drug obj in Prescription.Druglist)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(obj.DrugID);//1
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.NoOfDays);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugQuantity);//5
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Afternoon);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Morning);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Night);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Rate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.No_of_Tablet);//10
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.MRP);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DRUG_TYPE_DESC);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Evening);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.BillAmt);//21
                strOutPut.Append(split);

                #region Pharmacy List

                if (Prescription.pharmacyDetail != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Prescription.pharmacyDetail.PharmacyID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.PharmacyName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.ShippingCharge);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.DeliveryMinTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.DeliveryMaxTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.Discount);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.diagnosticId);//23
                strOutPut.Append(split);

                #region Diagnosis List

                if (Prescription.DiagnosisDetail != null && Prescription.DiagnosisDetail.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Diagnosis objdia in Prescription.DiagnosisDetail)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objdia.DiagnosisID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.filename);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisRate);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);

                #region Oderdetails List

                if (Prescription.Orderdetails != null && Prescription.Orderdetails.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Oderdetails objorder in Prescription.Orderdetails)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objorder.order_id);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.prescription_id);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.orderdate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.Order_Amt);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.IsView);//26
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass GetPrescriptionDetail_Phar_Deserialize(string Response, string token)
        {
            PrescriptionClass Prescription = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 1)
            {
                if (!string.IsNullOrEmpty(values[0]))
                    Prescription.Is_health_check = Convert.ToInt32(values[0]);
                Prescription.prescriptionId = values[1];
                Prescription.physicianName = values[2];
                Prescription.physician_id = values[3];
                Prescription.patientName = values[4];
                Prescription.prescriptionDate = values[5];
                Prescription.patient_id = values[6];
                Prescription.ailmentName = values[7];
                Prescription.ailmentCode = values[8];
                Prescription.ailmentid = values[9];
                if (!string.IsNullOrEmpty(values[10]))
                    Prescription.PrescriptionType = Convert.ToInt32(values[10]);
                Prescription.DeliveryCity = values[11];
                Prescription.DeliveryAddress = values[12];
                Prescription.DeliveryPinCode = values[13];
                Prescription.PrecFileName = values[14];
                Prescription.PatientGender = values[15];
                Prescription.PatientAge = values[16];
                Prescription.MobileNo = values[17];
                Prescription.PharmacyRemarks = values[18];

                if (values[19] != null && values[19] != string.Empty)
                {
                    #region Drug List
                    Prescription.Druglist = new List<Drug>();
                    foreach (string list in values[19].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Drug objDrug = new Drug();
                                    if (attri[0] != string.Empty)
                                        objDrug.DrugID = Convert.ToInt32(attri[0]);
                                    objDrug.DrugCode = attri[1];
                                    objDrug.DrugName = attri[2];
                                    if (attri[3] != string.Empty)
                                        objDrug.NoOfDays = Convert.ToInt32(attri[3]);
                                    if (attri[4] != string.Empty)
                                        objDrug.DrugQuantity = Convert.ToInt32(attri[4]);
                                    if (attri[5] != string.Empty)
                                        objDrug.Afternoon = Convert.ToDecimal(attri[5]);
                                    if (attri[6] != string.Empty)
                                        objDrug.Morning = Convert.ToDecimal(attri[6]);
                                    if (attri[7] != string.Empty)
                                        objDrug.Night = Convert.ToDecimal(attri[7]);
                                    if (attri[8] != string.Empty)
                                        objDrug.Rate = Convert.ToInt32(attri[8]);
                                    if (attri[9] != string.Empty)
                                        objDrug.No_of_Tablet = Convert.ToInt32(attri[9]);
                                    if (attri[10] != string.Empty)
                                        objDrug.MRP = Convert.ToDecimal(attri[10]);
                                    objDrug.DRUG_TYPE_DESC = attri[11];
                                    if (attri[12] != string.Empty)
                                        objDrug.Evening = Convert.ToDecimal(attri[12]);
                                    Prescription.Druglist.Add(objDrug);
                                }
                            }
                        }
                    }
                    #endregion
                }
                if (!string.IsNullOrEmpty(values[20]))
                    Prescription.BillAmt = Convert.ToDecimal(values[20]);

                if (values[21] != null && values[21] != string.Empty)
                {
                    #region Pharmacy List
                    Prescription.pharmacyDetail = new Pharmacy();
                    foreach (string innerlist in values[21].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                Prescription.pharmacyDetail.PharmacyID = Convert.ToInt32(attri[0]);
                            Prescription.pharmacyDetail.PharmacyName = attri[1];
                            if (attri[2] != string.Empty)
                                Prescription.pharmacyDetail.ShippingCharge = Convert.ToDecimal(attri[2]);
                            if (attri[3] != string.Empty)
                                Prescription.pharmacyDetail.DeliveryMinTime = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                Prescription.pharmacyDetail.DeliveryMaxTime = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                Prescription.pharmacyDetail.Discount = Convert.ToDecimal(attri[5]);
                        }
                    }
                    #endregion Pharmacy List
                }
                Prescription.diagnosticId = values[22];
                if (values[23] != null && values[23] != string.Empty)
                {
                    #region Diagnosis List
                    Prescription.DiagnosisDetail = new List<Diagnosis>();
                    foreach (string list in values[21].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    Diagnosis objDrug = new Diagnosis();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        if (attri[0] != string.Empty)
                                            objDrug.DiagnosisID = Convert.ToInt32(attri[0]);
                                        objDrug.DiagnosisName = attri[1];
                                        objDrug.DiagnosisCode = attri[2];
                                        objDrug.filename = attri[3];
                                        if (attri[4] != string.Empty)
                                            objDrug.DiagnosisRate = Convert.ToDecimal(attri[4]);
                                        Prescription.DiagnosisDetail.Add(objDrug);
                                    }
                                }
                            }
                        }
                    }

                    #endregion Diagnosis List
                }

                if (values[24] != null && values[24] != string.Empty)
                {

                    #region Oderdetails List
                    Prescription.Orderdetails = new List<Oderdetails>();
                    foreach (string list in values[24].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Oderdetails ObjOrder = new Oderdetails();
                                    if (attri.Length > 0)
                                    {
                                        ObjOrder.order_id = attri[0];
                                        ObjOrder.prescription_id = attri[1];
                                        ObjOrder.orderdate = attri[2];
                                        if (attri[3] != string.Empty)
                                            ObjOrder.Order_Amt = attri[3];
                                        Prescription.Orderdetails.Add(ObjOrder);
                                    }
                                }
                            }
                        }
                    }

                    #endregion Oderdetails List
                }

                if (values[25] != null && values[25] != string.Empty)
                {
                    Prescription.IsView = values[25].ToUpper() == "TRUE" ? true : false;
                }
            }
            return Prescription;
        }

        public string GetPartialPrescriptionDetail_Phar_Serialize(PrescriptionClass Prescription, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Prescription != null)
            {
                strOutPut.Append(Prescription.Is_health_check);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.prescriptionId);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.physicianName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.physician_id);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.patientName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.prescriptionDate);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.patient_id);//7
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentid);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PrescriptionType);//11
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryCity);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryAddress);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryPinCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PrecFileName);//15
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PatientGender);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PatientAge);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.MobileNo);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PharmacyRemarks);//19
                strOutPut.Append(split);

                #region Drug List

                if (Prescription.Druglist != null && Prescription.Druglist.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Drug obj in Prescription.Druglist)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(obj.DrugID);//1
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.NoOfDays);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugQuantity);//5
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Afternoon);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Morning);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Night);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Rate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.OrderId);//10
                        strOutPut.Append(ListProperty_Split);//new
                        strOutPut.Append(obj.No_of_Ordered_Tablet);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Is_Ordered);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.IsFullOrdered);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.No_of_Tablet);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.SubstituteWithDrugId);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.MRP);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.PLACE_ORDER_MULTIPLE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Integration_Code);
                        strOutPut.Append(ListProperty_Split);//end
                        strOutPut.Append(obj.Evening);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.BillAmt);//21
                strOutPut.Append(split);

                #region Pharmacy List

                if (Prescription.pharmacyDetail != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Prescription.pharmacyDetail.PharmacyID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.PharmacyName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.ShippingCharge);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.DeliveryMinTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.DeliveryMaxTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.Discount);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.onlineOrderFlow);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.PharmacyType);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.diagnosticId);//23
                strOutPut.Append(split);

                #region Diagnosis List

                if (Prescription.DiagnosisDetail != null && Prescription.DiagnosisDetail.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Diagnosis objdia in Prescription.DiagnosisDetail)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objdia.DiagnosisID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.filename);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisRate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.Is_Ordered);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);

                #region Oderdetails List

                if (Prescription.Orderdetails != null && Prescription.Orderdetails.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Oderdetails objorder in Prescription.Orderdetails)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objorder.order_id);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.prescription_id);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.orderdate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.Order_Amt);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.OrderStatus);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.OrderStatusID);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.IsView);//26
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ErrorCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ErrorDesc);
                strOutPut.Append(split);
                #region Shipping Address

                if (Prescription.ShippingAdr != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Prescription.ShippingAdr.AddressId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.AddressTitle);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.Street1);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.Street2);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.StateID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.CityID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.PinCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.Country);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.MobileNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.consumer_name);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.latitude);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.longitude);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.State);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.City);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.locality);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.primary_emailid);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion
                strOutPut.Append(split);
                strOutPut.Append(Prescription.TransactionType);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.EntityKey);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.GUID);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.EntityCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.CREATED_BY);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.MODIFIED_BY);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.VISITORIP);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DEVICEID);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.Latitude);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.Longitude);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.City_ID);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.Aggregator_type);

            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass GetPartialPrescriptionDetail_Phar_Deserialize(string Response, string token)
        {
            PrescriptionClass Prescription = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 1)
            {
                if (!string.IsNullOrEmpty(values[0]))
                    Prescription.Is_health_check = Convert.ToInt32(values[0]);
                Prescription.prescriptionId = values[1];
                Prescription.physicianName = values[2];
                Prescription.physician_id = values[3];
                Prescription.patientName = values[4];
                Prescription.prescriptionDate = values[5];
                Prescription.patient_id = values[6];
                Prescription.ailmentName = values[7];
                Prescription.ailmentCode = values[8];
                Prescription.ailmentid = values[9];
                if (!string.IsNullOrEmpty(values[10]))
                    Prescription.PrescriptionType = Convert.ToInt32(values[10]);
                Prescription.DeliveryCity = values[11];
                Prescription.DeliveryAddress = values[12];
                Prescription.DeliveryPinCode = values[13];
                Prescription.PrecFileName = values[14];
                Prescription.PatientGender = values[15];
                Prescription.PatientAge = values[16];
                Prescription.MobileNo = values[17];
                Prescription.PharmacyRemarks = values[18];

                if (values[19] != null && values[19] != string.Empty)
                {
                    #region Drug List
                    Prescription.Druglist = new List<Drug>();
                    foreach (string list in values[19].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Drug objDrug = new Drug();
                                    if (attri[0] != string.Empty)
                                        objDrug.DrugID = Convert.ToInt32(attri[0]);
                                    objDrug.DrugCode = attri[1];
                                    objDrug.DrugName = attri[2];
                                    if (attri[3] != string.Empty)
                                        objDrug.NoOfDays = Convert.ToInt32(attri[3]);
                                    if (attri[4] != string.Empty)
                                        objDrug.DrugQuantity = Convert.ToInt32(attri[4]);
                                    if (attri[5] != string.Empty)
                                        objDrug.Afternoon = Convert.ToDecimal(attri[5]);
                                    if (attri[6] != string.Empty)
                                        objDrug.Morning = Convert.ToDecimal(attri[6]);
                                    if (attri[7] != string.Empty)
                                        objDrug.Night = Convert.ToDecimal(attri[7]);
                                    if (attri[8] != string.Empty)
                                        objDrug.Rate = Convert.ToDecimal(attri[8]);
                                    objDrug.OrderId = attri[9];
                                    if (attri[10] != string.Empty)
                                        objDrug.No_of_Ordered_Tablet = Convert.ToInt32(attri[10]);
                                    if (attri[11] != string.Empty)
                                        objDrug.Is_Ordered = Convert.ToInt32(attri[11]);
                                    if (attri[12] != string.Empty)
                                        objDrug.IsFullOrdered = Convert.ToInt32(attri[12]);
                                    if (attri[13] != string.Empty)
                                        objDrug.No_of_Tablet = Convert.ToInt32(attri[13]);
                                    if (attri[14] != string.Empty)
                                        objDrug.SubstituteWithDrugId = Convert.ToInt32(attri[14]);
                                    if (attri[15] != string.Empty)
                                        objDrug.MRP = Convert.ToDecimal(attri[15]);
                                    if (attri.Count() > 16)
                                    {
                                        if (!string.IsNullOrEmpty(attri[16]))
                                            objDrug.PLACE_ORDER_MULTIPLE = Convert.ToInt16(attri[16]);
                                    }

                                    if (attri.Count() > 17)
                                    {
                                        if (!string.IsNullOrEmpty(attri[17]))
                                            objDrug.Integration_Code = Convert.ToString(attri[17]);
                                    }
                                    if (attri.Count() > 18)
                                    {
                                        if (!string.IsNullOrEmpty(attri[18]))
                                            objDrug.Evening = Convert.ToDecimal(attri[18]);
                                    }

                                    Prescription.Druglist.Add(objDrug);
                                }
                            }
                        }
                    }
                    #endregion
                }
                if (!string.IsNullOrEmpty(values[20]))
                    Prescription.BillAmt = Convert.ToDecimal(values[20]);

                if (values[21] != null && values[21] != string.Empty)
                {
                    #region Pharmacy List
                    Prescription.pharmacyDetail = new Pharmacy();
                    foreach (string innerlist in values[21].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                Prescription.pharmacyDetail.PharmacyID = Convert.ToInt32(attri[0]);
                            Prescription.pharmacyDetail.PharmacyName = attri[1];
                            if (attri[2] != string.Empty)
                                Prescription.pharmacyDetail.ShippingCharge = Convert.ToDecimal(attri[2]);
                            if (attri[3] != string.Empty)
                                Prescription.pharmacyDetail.DeliveryMinTime = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                Prescription.pharmacyDetail.DeliveryMaxTime = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                Prescription.pharmacyDetail.Discount = Convert.ToDecimal(attri[5]);
                            if (attri[6] != string.Empty)
                                Prescription.pharmacyDetail.onlineOrderFlow = Convert.ToInt32(attri[6]);
                            if (attri[7] != string.Empty)
                                Prescription.pharmacyDetail.PharmacyType = Convert.ToInt32(attri[7]);
                        }
                    }
                    #endregion Pharmacy List
                }
                Prescription.diagnosticId = values[22];
                if (values[23] != null && values[23] != string.Empty)
                {
                    #region Diagnosis List
                    Prescription.DiagnosisDetail = new List<Diagnosis>();
                    foreach (string list in values[23].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    Diagnosis objDrug = new Diagnosis();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        if (attri[0] != string.Empty)
                                            objDrug.DiagnosisID = Convert.ToInt32(attri[0]);
                                        objDrug.DiagnosisName = attri[1];
                                        objDrug.DiagnosisCode = attri[2];
                                        objDrug.filename = attri[3];
                                        if (attri[4] != string.Empty)
                                            objDrug.DiagnosisRate = Convert.ToDecimal(attri[4]);
                                        if (attri[5] != string.Empty)
                                            objDrug.Is_Ordered = Convert.ToInt16(attri[5]);
                                        Prescription.DiagnosisDetail.Add(objDrug);
                                    }
                                }
                            }
                        }
                    }

                    #endregion Diagnosis List
                }

                if (values[24] != null && values[24] != string.Empty)
                {

                    #region Oderdetails List
                    Prescription.Orderdetails = new List<Oderdetails>();
                    foreach (string list in values[24].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Oderdetails ObjOrder = new Oderdetails();
                                    if (attri.Length > 0)
                                    {
                                        ObjOrder.order_id = attri[0];
                                        ObjOrder.prescription_id = attri[1];
                                        ObjOrder.orderdate = attri[2];
                                        ObjOrder.Order_Amt = attri[3];
                                        ObjOrder.OrderStatus = attri[4];
                                        ObjOrder.OrderStatusID = attri[5];
                                        Prescription.Orderdetails.Add(ObjOrder);
                                    }
                                }
                            }
                        }
                    }

                    #endregion Oderdetails List
                }

                if (values[25] != null && values[25] != string.Empty)
                {
                    Prescription.IsView = values[25].ToUpper() == "TRUE" ? true : false;
                }
                Prescription.ErrorCode = values[26];
                Prescription.ErrorDesc = values[27];
                if (values[28] != null && values[28] != string.Empty)
                {
                    #region Shipping Address
                    Prescription.ShippingAdr = new ShippingAddress();
                    foreach (string innerlist in values[28].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Prescription.ShippingAdr.AddressId = attri[0];
                            Prescription.ShippingAdr.AddressTitle = attri[1];
                            Prescription.ShippingAdr.Street1 = attri[2];
                            Prescription.ShippingAdr.Street2 = attri[3];
                            Prescription.ShippingAdr.StateID = attri[4];
                            Prescription.ShippingAdr.CityID = attri[5];
                            Prescription.ShippingAdr.PinCode = attri[6];
                            Prescription.ShippingAdr.Country = attri[7];
                            Prescription.ShippingAdr.MobileNo = attri[8];
                            Prescription.ShippingAdr.consumer_name = attri[9];
                            Prescription.ShippingAdr.latitude = attri[10];
                            Prescription.ShippingAdr.longitude = attri[11];
                            Prescription.ShippingAdr.State = attri[12];
                            Prescription.ShippingAdr.City = attri[13];
                            Prescription.ShippingAdr.locality = attri[14];
                            Prescription.ShippingAdr.primary_emailid = attri[15];

                        }
                    }
                    #endregion
                }
                Prescription.TransactionType = values[29];
                Prescription.EntityKey = values[30];
                Prescription.GUID = values[31];
                Prescription.EntityCode = values[32];
                if (values.Count() > 33)
                {
                    Prescription.CREATED_BY = values[33];
                    Prescription.MODIFIED_BY = values[34];
                    Prescription.VISITORIP = values[35];
                    Prescription.DEVICEID = values[36];
                }
                if (values.Count() > 37)
                {
                    Prescription.Latitude = values[37];
                    Prescription.Longitude = values[38];
                    if (!string.IsNullOrEmpty(values[39]))
                        Prescription.City_ID = Convert.ToInt32(values[39]);
                    if (!string.IsNullOrEmpty(values[39]))
                        Prescription.Aggregator_type = Convert.ToInt32(values[40]);
                }

            }
            return Prescription;
        }

        public string GetCheckUpDetails_Dia_Serialize(PrescriptionClass Pres, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Pres != null)
            {
                strOutPut.Append(Pres.Is_health_check);
                strOutPut.Append(split);
                strOutPut.Append(Pres.PatientGender);
                strOutPut.Append(split);
                strOutPut.Append(Pres.patientName);
                strOutPut.Append(split);
                strOutPut.Append(Pres.prescriptionDate);
                strOutPut.Append(split);
                strOutPut.Append(Pres.prescriptionId);
                strOutPut.Append(split);
                strOutPut.Append(Pres.PatientAge);
                strOutPut.Append(split);
                strOutPut.Append(Pres.BillAmt);//7
                strOutPut.Append(split);

                if (Pres.Diagnosis != null && !string.IsNullOrEmpty(Pres.Diagnosis.DiagnosisName))
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Pres.Diagnosis.DiagnosisName);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);

                if (Pres.paymentList != null && Pres.paymentList.Count > 0)//9
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Payment _Payment in Pres.paymentList)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(_Payment.PatientPayable);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(_Payment.PayerPayable);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(Pres.IsCashLess);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);

                if (Pres.DiagnosisDetail != null && Pres.DiagnosisDetail.Count > 0)//10
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Diagnosis Dia in Pres.DiagnosisDetail)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(Dia.DiagnosisID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(Dia.DiagnosisName);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
            }

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass GetCheckUpDetails_Dia_Deserialize(string Response, string token)
        {
            PrescriptionClass Pres = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length == 10)
            {
                if (values[0] != string.Empty)
                    Pres.Is_health_check = Convert.ToInt32(values[0]);

                Pres.PatientGender = values[1];
                Pres.patientName = values[2];
                Pres.prescriptionDate = values[3];
                Pres.prescriptionId = values[4];
                Pres.PatientAge = values[5];
                if (values[6] != string.Empty)
                    Pres.BillAmt = Convert.ToDecimal(values[6]);
                if (values[7] != null && values[7] != string.Empty)
                {
                    foreach (string innerlist in values[7].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Pres.Diagnosis = new Diagnosis();
                            if (attri.Length > 0)
                                Pres.Diagnosis.DiagnosisName = attri[0];
                        }
                    }
                }

                if (values[8] != null && values[8] != string.Empty)
                {
                    Payment _Payment = new Payment();
                    Pres.paymentList = new List<Payment>();
                    foreach (string list in values[8].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    _Payment = new Payment();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (!string.IsNullOrEmpty(attri[0]))
                                        _Payment.PatientPayable = Convert.ToDecimal(attri[0]);
                                    if (!string.IsNullOrEmpty(attri[1]))
                                        _Payment.PayerPayable = Convert.ToDecimal(attri[1]);
                                    if (!string.IsNullOrEmpty(attri[2]))
                                        Pres.IsCashLess = attri[2].ToUpper() == "TRUE" ? true : false;
                                    Pres.paymentList.Add(_Payment);
                                }
                            }
                        }
                    }
                }

                if (values[9] != null && values[9] != string.Empty)
                {
                    Diagnosis Dia = new Diagnosis();
                    Pres.DiagnosisDetail = new List<Diagnosis>();
                    foreach (string list in values[9].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    Dia = new Diagnosis();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (!string.IsNullOrEmpty(attri[0]))
                                        Dia.DiagnosisID = Convert.ToInt32(attri[0]);

                                    Dia.DiagnosisName = attri[1];
                                    Pres.DiagnosisDetail.Add(Dia);
                                }
                            }
                        }
                    }
                }
            }
            return Pres;
        }

        public string GetOrderDashboardDetails_V1_Dia_Serialize(List<PrescriptionClass> lstPre, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (lstPre != null && lstPre.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PrescriptionClass objPre in lstPre)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objPre.prescriptionId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.physicianName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.patientName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.diagnosticId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.patient_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.ailmentName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.BillAmt);
                    strOutPut.Append(ListProperty_Split);
                    if (objPre.Orderdetails != null && objPre.Orderdetails.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (Oderdetails objlst in objPre.Orderdetails)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.order_id);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.prescription_id);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.orderdate);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.OrderTime);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.pharmacyname);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Order_Amt);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    strOutPut.Append(ListProperty_Split);
                    if (objPre.DiagnosisDetail != null && objPre.DiagnosisDetail.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (Diagnosis objlst in objPre.DiagnosisDetail)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.DiagnosisName);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.DiagnosisID);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.ClaimID);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.filename);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetOrderDashboardDetails_V1_Dia_Deserialize(string Response, string token)
        {
            List<PrescriptionClass> lstPre = new List<PrescriptionClass>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PrescriptionClass objPre = new PrescriptionClass();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objPre.prescriptionId = attri[0];
                            objPre.physicianName = attri[1];
                            objPre.patientName = attri[2];
                            objPre.diagnosticId = attri[3];
                            objPre.patient_id = attri[4];
                            objPre.ailmentName = attri[5];
                            if (!string.IsNullOrEmpty(attri[6]))
                                objPre.BillAmt = Convert.ToDecimal(attri[6]);

                            if (!string.IsNullOrEmpty(attri[7]))
                            {
                                objPre.Orderdetails = new List<Oderdetails>();
                                foreach (string list1 in attri[7].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Oderdetails objlst = new Oderdetails();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objlst.order_id = attri1[0];
                                                objlst.prescription_id = attri1[1];
                                                objlst.orderdate = attri1[2];
                                                objlst.OrderTime = attri1[3];
                                                objlst.pharmacyname = attri1[4];
                                                objlst.Order_Amt = attri1[5];
                                                objPre.Orderdetails.Add(objlst);
                                            }
                                        }

                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(attri[8]))
                            {
                                objPre.DiagnosisDetail = new List<Diagnosis>();
                                foreach (string list1 in attri[8].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Diagnosis objlst = new Diagnosis();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objlst.DiagnosisName = attri1[0];
                                                if (!string.IsNullOrEmpty(attri1[1]))
                                                    objlst.DiagnosisID = Convert.ToInt32(attri1[1]);
                                                if (!string.IsNullOrEmpty(attri1[2]))
                                                    objlst.ClaimID = attri1[2];
                                                objlst.filename = attri1[3];
                                                objPre.DiagnosisDetail.Add(objlst);
                                            }
                                        }

                                    }
                                }
                            }
                            lstPre.Add(objPre);
                        }

                    }
                }
            }
            return lstPre;
        }

        public string PaymentDetailForService_List_Serialize(List<PaymentDetailForService> lstPayDet, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (lstPayDet != null && lstPayDet.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PaymentDetailForService obj in lstPayDet)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.Payment_Narration);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Payer_Cheque_Refno);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Paid);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Payment_Amt);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Payment_Date);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Prescription_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Patient_name);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.OrderId);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ApprovedDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PaidDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.NeftNumber);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TDS);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.SettlementLetter);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Status);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PaymentDetailForService> PaymentDetailForService_List_Deserialize(string Response, string token)
        {
            List<PaymentDetailForService> lstPayDet = new List<PaymentDetailForService>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PaymentDetailForService obj = new PaymentDetailForService();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            obj.Payment_Narration = attri[0];
                            obj.Payer_Cheque_Refno = attri[1];
                            if (!string.IsNullOrEmpty(attri[2]))
                                obj.Paid = Convert.ToInt32(attri[2]);
                            obj.Payment_Amt = attri[3];
                            obj.Payment_Date = attri[4];
                            obj.Prescription_Id = attri[5];
                            obj.Patient_name = attri[6];
                            obj.OrderId = attri[7];
                            obj.ApprovedDate = attri[8];
                            obj.PaidDate = attri[9];
                            obj.NeftNumber = attri[10];
                            obj.TDS = attri[11];
                            obj.SettlementLetter = attri[12];
                            obj.Status = attri[13];
                            lstPayDet.Add(obj);
                        }
                    }
                }
            }
            return lstPayDet;
        }

        public string GetPaymentDetails_Serialize(Payment objPayment, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objPayment != null)
            {
                strOutPut.Append(objPayment.BillAmount);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.PayerPayable);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.PatientPayable);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.PaymentReceipt);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.ErrorCode);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.ErrorDesc);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public Payment GetPaymentDetails_Deserialize(string Response, string token)
        {
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            Payment objPayment = new Payment();
            if (values.Length > 0)
            {
                if (!string.IsNullOrEmpty(values[0]))
                    objPayment.BillAmount = Convert.ToDecimal(values[0]);
                if (!string.IsNullOrEmpty(values[1]))
                    objPayment.PayerPayable = Convert.ToDecimal(values[1]);
                if (!string.IsNullOrEmpty(values[2]))
                    objPayment.PatientPayable = Convert.ToDecimal(values[2]);
                objPayment.PaymentReceipt = values[3];
                objPayment.ErrorCode = values[4];
                objPayment.ErrorDesc = values[5];
            }
            return objPayment;
        }

        public string OP_Pay_DashBoard_List_Serialize(List<OP_Pay_DashBoard> objPayDashBoard, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objPayDashBoard != null && objPayDashBoard.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (OP_Pay_DashBoard obj in objPayDashBoard)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.BillAmt);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.FromDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Paid);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PaidAmt);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PayerCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PayerId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PayerName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PaymentAmt);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ToDate);


                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<OP_Pay_DashBoard> OP_Pay_DashBoard_List_Deserialize(string Response, string token)
        {
            List<OP_Pay_DashBoard> objPayDashBoard = new List<OP_Pay_DashBoard>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            OP_Pay_DashBoard obj = new OP_Pay_DashBoard();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            obj.BillAmt = attri[0];
                            obj.FromDate = attri[1];
                            if (!string.IsNullOrEmpty(attri[2]))
                                obj.Paid = Convert.ToInt32(attri[2]);
                            obj.PaidAmt = attri[3];
                            obj.PayerCode = attri[4];
                            if (!string.IsNullOrEmpty(attri[5]))
                                obj.PayerId = Convert.ToInt32(attri[5]);
                            obj.PayerName = attri[6];
                            obj.PaymentAmt = attri[7];
                            obj.ToDate = attri[8];

                            objPayDashBoard.Add(obj);
                        }
                    }
                }
            }
            return objPayDashBoard;
        }

        public string PaymentList_List_Serialize(List<PaymentList> objPayment, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objPayment != null && objPayment.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PaymentList obj in objPayment)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.BillAmt);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ErrorCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ErrorDesc);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PayerPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.prescriptionId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TotalBillAmt);
                    strOutPut.Append(ListProperty_Split);
                    if (obj.lstPayment != null && obj.lstPayment.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (Payment objlst in obj.lstPayment)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.BillAmount);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.PayerPayable);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.PatientPayable);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.PaymentReceipt);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.OrderNo);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.PaymentID);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.PaymentDate);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PaymentList> PaymentList_List_Deserialize(string Response, string token)
        {
            List<PaymentList> objPayment = new List<PaymentList>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PaymentList obj = new PaymentList();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(attri[0]))
                                    obj.BillAmt = Convert.ToDecimal(attri[0]);
                                obj.ErrorCode = attri[1];
                                obj.ErrorDesc = attri[2];
                                if (!string.IsNullOrEmpty(attri[3]))
                                    obj.PatientPayable = Convert.ToDecimal(attri[3]);
                                if (!string.IsNullOrEmpty(attri[4]))
                                    obj.PayerPayable = Convert.ToDecimal(attri[4]);
                                obj.prescriptionId = attri[5];
                                if (!string.IsNullOrEmpty(attri[6]))
                                    obj.TotalBillAmt = Convert.ToDecimal(attri[6]);

                                if (!string.IsNullOrEmpty(attri[7]))
                                {
                                    obj.lstPayment = new List<Payment>();
                                    foreach (string list1 in attri[7].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                    {
                                        if (list1 != string.Empty)
                                        {
                                            foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                            {
                                                Payment pay = new Payment();
                                                if (innerlist1 != string.Empty)
                                                {
                                                    string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                    if (attri1.Length > 0)
                                                    {
                                                        if (!string.IsNullOrEmpty(attri1[0]))
                                                            pay.BillAmount = Convert.ToDecimal(attri1[0]);
                                                        if (!string.IsNullOrEmpty(attri1[1]))
                                                            pay.PayerPayable = Convert.ToDecimal(attri1[1]);
                                                        if (!string.IsNullOrEmpty(attri1[2]))
                                                            pay.PatientPayable = Convert.ToDecimal(attri1[2]);
                                                        pay.PaymentReceipt = attri1[3];
                                                        pay.OrderNo = attri1[4];
                                                        if (!string.IsNullOrEmpty(attri1[5]))
                                                            pay.PaymentID = Convert.ToInt32(attri1[5]);
                                                        pay.PaymentDate = attri1[6];

                                                        obj.lstPayment.Add(pay);
                                                    }
                                                }

                                            }
                                        }

                                    }
                                }
                                objPayment.Add(obj);
                            }
                        }
                    }
                }
            }

            return objPayment;
        }

        public string PaymentList_Serialize(PaymentList objPayment, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objPayment != null)
            {
                strOutPut.Append(objPayment.BillAmt);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.ErrorCode);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.ErrorDesc);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.PatientPayable);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.PayerPayable);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.prescriptionId);
                strOutPut.Append(split);
                strOutPut.Append(objPayment.TotalBillAmt);
                strOutPut.Append(split);
                if (objPayment.lstPayment != null && objPayment.lstPayment.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Payment obj in objPayment.lstPayment)
                    {
                        if (obj != null)
                        {
                            strOutPut.Append(ListElement_Start);
                            strOutPut.Append(obj.BillAmount);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(obj.PayerPayable);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(obj.PatientPayable);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(obj.PaymentReceipt);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(obj.OrderNo);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(obj.PaymentID);
                            strOutPut.Append(ListProperty_Split);
                            strOutPut.Append(obj.PaymentDate);
                            strOutPut.Append(ListElement_End);
                        }
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PaymentList PaymentList_Deserialize(string Response, string token)
        {
            PaymentList objPayment = new PaymentList();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 0)
            {
                if (!string.IsNullOrEmpty(values[0]))
                    objPayment.BillAmt = Convert.ToDecimal(values[0]);
                objPayment.ErrorCode = values[1];
                objPayment.ErrorDesc = values[2];
                if (!string.IsNullOrEmpty(values[3]))
                    objPayment.PatientPayable = Convert.ToDecimal(values[3]);
                if (!string.IsNullOrEmpty(values[4]))
                    objPayment.PayerPayable = Convert.ToDecimal(values[4]);
                objPayment.prescriptionId = values[5];
                if (!string.IsNullOrEmpty(values[6]))
                    objPayment.TotalBillAmt = Convert.ToDecimal(values[6]);
                if (!string.IsNullOrEmpty(values[7]))
                {
                    if (objPayment.lstPayment == null)
                        objPayment.lstPayment = new List<Payment>();
                    foreach (string list in values[7].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Payment objPay = new Payment();
                                    if (attri.Length > 0)
                                    {
                                        if (!string.IsNullOrEmpty(attri[0]))
                                            objPay.BillAmount = Convert.ToDecimal(attri[0]);
                                        if (!string.IsNullOrEmpty(attri[1]))
                                            objPay.PayerPayable = Convert.ToDecimal(attri[1]);
                                        if (!string.IsNullOrEmpty(attri[2]))
                                            objPay.PatientPayable = Convert.ToDecimal(attri[2]);
                                        objPay.PaymentReceipt = attri[3];
                                        objPay.OrderNo = attri[4];
                                        if (!string.IsNullOrEmpty(attri[5]))
                                            objPay.PaymentID = Convert.ToInt32(attri[5]);
                                        objPay.PaymentDate = attri[6];
                                        objPayment.lstPayment.Add(objPay);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return objPayment;
        }

        public List<OP_Pay_DashBoard> GET_PAYMENT_DASHBOARD_Comm_Deserialize(string Response, string Token)
        {
            List<OP_Pay_DashBoard> objapp = new List<OP_Pay_DashBoard>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            OP_Pay_DashBoard obj = new OP_Pay_DashBoard();
                            if (attri[0] != string.Empty)
                                obj.PayerId = Convert.ToInt16(attri[0]);
                            obj.PayerCode = attri[1];
                            obj.PayerName = attri[2];
                            obj.PaymentAmt = attri[3];
                            obj.BillAmt = attri[4];
                            obj.PaidAmt = attri[5];
                            obj.FromDate = attri[6];
                            obj.ToDate = attri[7];
                            if (attri[8] != string.Empty)
                                obj.Paid = Convert.ToInt16(attri[8]);

                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetCFSearch_Pat_Serialize(List<ClinicalFind> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            if (Response != null && Response.Count > 0)
            {
                foreach (ClinicalFind objClincFind in Response)
                {
                    outPut.Append(ListElement_Start);
                    outPut.Append(objClincFind.PatientID);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.ClaimID);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.BP);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Pulse);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Temperature);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Weight);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.SugarA);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.SugarB);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.Remarks);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.PatientName);
                    outPut.Append(ListProperty_Split);
                    outPut.Append(objClincFind.MonitorDate);
                    outPut.Append(ListProperty_Split);
                    if (objClincFind.Ailment != null)
                    {
                        outPut.Append(objClincFind.Ailment.AilmentName);
                    }
                    else
                    {
                        outPut.Append("");
                    }
                    outPut.Append(ListElement_End);
                }
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }


        public List<ClinicalFind> GetCFSearch_Pat_Deserialize(string Response, string token)
        {
            List<ClinicalFind> objClFindList = new List<ClinicalFind>();
            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {

                        if (innerlist != string.Empty)
                        {
                            ClinicalFind objClFind = new ClinicalFind();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objClFind.PatientID = Convert.ToInt16(attri[0]);
                            if (attri[1] != string.Empty)
                                objClFind.ClaimID = attri[1];
                            objClFind.BP = attri[2];
                            objClFind.Pulse = attri[3];
                            objClFind.Temperature = attri[4];
                            objClFind.Weight = attri[5];
                            objClFind.SugarA = attri[6];
                            objClFind.SugarB = attri[7];
                            objClFind.Remarks = attri[8];
                            objClFind.PatientName = attri[9];
                            objClFind.MonitorDate = attri[10];
                            if (attri[11] != null && attri[11] != string.Empty)
                            {
                                Ailment obj = new Ailment();
                                obj.AilmentName = attri[11];
                                objClFind.Ailment = obj;
                            }
                            objClFindList.Add(objClFind);
                        }

                    }
                }
            }
            return objClFindList;
        }

        public string GetCityList_Serialize(List<City> Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(ListIdentifier_Start);
            foreach (City obj in Response)
            {
                objOutPut.Append(ListElement_Start);
                objOutPut.Append(obj.CityID);
                objOutPut.Append(ListProperty_Split);
                objOutPut.Append(obj.CityName);
                objOutPut.Append(ListElement_End);
            }
            objOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }


        public List<City> GetCityList_Deserialize(string Response, string token)
        {
            List<City> objList = new List<City>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            City obj = new City();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                obj.CityID = Convert.ToInt16(attri[0]);
                            obj.CityName = attri[1];
                            objList.Add(obj);
                        }
                    }
                }
            }

            return objList;
        }

        public string OP_ROLLBACK_BSI_DEDUCTION_Resp_Serialize(PrescriptionClass objpre, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objpre.prescriptionId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ErrorCode);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ErrorDesc);
            strOutPut.Append(split);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass OP_ROLLBACK_BSI_DEDUCTION_Resp_Deserialize(string Response, string token)
        {
            PrescriptionClass objPres = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split); ;

            objPres.prescriptionId = values[0];
            objPres.ErrorCode = values[1];
            objPres.ErrorDesc = values[2];
            return objPres;
        }

        #region Chat
        public string GetChatHistory_Chat_Serialize(List<ChatHistory> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (ChatHistory objPro in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objPro.ChatText);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.MediaName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.PrescriptionID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.PatientID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.PhysicianID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.UserType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.ChatDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.IsSeen);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<ChatHistory> GetChatHistory_Chat_Deserialize(string Response, string Token)
        {
            List<ChatHistory> objapp = new List<ChatHistory>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            ChatHistory obj = new ChatHistory();
                            obj.ChatText = attri[0];
                            obj.MediaName = attri[1];
                            if (attri[2] != string.Empty)
                                obj.PrescriptionID = attri[2];
                            if (attri[3] != string.Empty)
                                obj.PatientID = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                obj.PhysicianID = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                obj.UserType = Convert.ToInt16(attri[5]);
                            if (attri[6] != string.Empty)
                                obj.ChatDate = attri[6];
                            if (attri[7] != string.Empty)
                                obj.IsSeen = Convert.ToInt16(attri[7]);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }
        #endregion

        public string ValidateProductPolicy_Phy_Serialize(PrescriptionClass _objPclass, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (_objPclass != null)
            {
                strOutPut.Append(_objPclass.prescriptionId);
                strOutPut.Append(split);
                strOutPut.Append(_objPclass.IsFollowUpCase);
                strOutPut.Append(split);
                strOutPut.Append(_objPclass.FollowUp_prescriptionId);
                strOutPut.Append(split);
                strOutPut.Append(_objPclass.ErrorCode);
                strOutPut.Append(split);
                strOutPut.Append(_objPclass.ErrorDesc);
                strOutPut.Append(split);
                if (_objPclass.policyValidation != null)
                {
                    PolicyValidation objpolicyval = _objPclass.policyValidation;
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objpolicyval.ClaimID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.order_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.BillAmount);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.PatientPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.PayerPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.EligibleAmt);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.CoPay);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.CoPayRelation);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.MaxCoPay);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.OTP);
                    strOutPut.Append(ListProperty_Split);
                    if (objpolicyval.ValDet != null && objpolicyval.ValDet.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (polval objval in objpolicyval.ValDet)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objval.valName);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objval.valMsg);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }
                    strOutPut.Append(ListProperty_Split);
                    if (objpolicyval.PPBreakUp != null && objpolicyval.PPBreakUp.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (PayerPayableBreakUp obj in objpolicyval.PPBreakUp)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(obj.ValLabel);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(obj.Value);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }
                    strOutPut.Append(ListProperty_Split);
                    if (objpolicyval.validationDataTable != null)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objpolicyval.validationDataTable.CLAIM_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.REMARKS);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.GROUP_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.ERROR_FLAG);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_NAME);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_LABEL);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_MESSAGE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.TARIFF_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.ELIGIBLE_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.DISALLOWED_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.PAYABLE_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.INFO_FLAG);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.DISPLAY_FLAG);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.BILL_ITEM_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.GROUP_NAME);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_MESSAGE_1);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.VALIDATION_MESSAGE_2);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.NO_CO_PAY);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.COPAY_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.COPAY_TYPE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.DISPLAY_ORDER);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.ORDER_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.validationDataTable.PAYMENT_ID);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }
                    strOutPut.Append(ListProperty_Split);
                    if (objpolicyval.tranDataTable != null)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objpolicyval.tranDataTable.CLAIM_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.PRODUCT_COPAY);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.COPAY_TYPE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.TOTAL_COPAY_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.TOTAL_BILL_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.TOTAL_ELIGIBLE_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.TOTAL_APPROVED_AMOUNT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.TOTAL_PATIENT_PAYABLE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.MOBILE_NO);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.TOTAL_PAYABLE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.EMAIL_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.MEMBER_FIRST_NAME);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.MEMBER_LAST_NAME);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.MEMBER_MIDDLE_NAME);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.PAYER_CODE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objpolicyval.tranDataTable.POLICY_NO);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.ValidationResult);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.ErrorCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.ErrorDesc);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.MemberId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.Payer_Code);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.TransactionTimeOut);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objpolicyval.PrescriptionID);
                    strOutPut.Append(ListElement_End);
                }

            }

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass ValidateProductPolicy_Phy_Deserialize(string Response, string token)
        {
            PrescriptionClass objPres = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split); ;
            int i = 0;
            objPres.prescriptionId = values[i];
            if (values[++i] != string.Empty)
                objPres.IsFollowUpCase = Convert.ToInt16(values[i]);
            objPres.FollowUp_prescriptionId = values[++i];
            objPres.ErrorCode = values[++i];
            objPres.ErrorDesc = values[++i];
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                PolicyValidation objPolVal = new PolicyValidation();
                foreach (string innerlist in values[i].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        int r = 0;
                        if (attri[r] != string.Empty)
                            objPolVal.ClaimID = Convert.ToString(attri[r]);
                        objPolVal.order_id = attri[++r];
                        if (!string.IsNullOrEmpty(attri[++r]))
                            objPolVal.BillAmount = Convert.ToDecimal(attri[r]);
                        if (!string.IsNullOrEmpty(attri[++r]))
                            objPolVal.PatientPayable = Convert.ToDecimal(attri[r]);
                        if (!string.IsNullOrEmpty(attri[++r]))
                            objPolVal.PayerPayable = Convert.ToDecimal(attri[r]);
                        if (!string.IsNullOrEmpty(attri[++r]))
                            objPolVal.EligibleAmt = Convert.ToDecimal(attri[r]);
                        if (!string.IsNullOrEmpty(attri[++r]))
                            objPolVal.CoPay = Convert.ToDecimal(attri[r]);
                        objPolVal.CoPayRelation = attri[++r];
                        objPolVal.MaxCoPay = attri[++r];
                        objPolVal.OTP = attri[++r];
                        r++;
                        if (attri[r] != null && attri[r] != string.Empty)
                        {
                            foreach (string list in attri[r].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                            {
                                if (list != string.Empty)
                                {
                                    objPolVal.ValDet = new List<polval>();
                                    foreach (string innerlist1 in list.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                    {
                                        if (innerlist1 != string.Empty)
                                        {

                                            string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                            if (attri.Length > 0)
                                            {
                                                polval objval = new polval();
                                                objval.valName = attri1[0];
                                                objval.valMsg = attri1[1];
                                                objPolVal.ValDet.Add(objval);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        r++;
                        if (attri[r] != null && attri[r] != string.Empty)
                        {
                            foreach (string list in attri[r].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                            {
                                if (list != string.Empty)
                                {
                                    objPolVal.PPBreakUp = new List<PayerPayableBreakUp>();
                                    foreach (string innerlist1 in list.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                    {
                                        if (innerlist1 != string.Empty)
                                        {

                                            string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                            if (attri1.Length > 0)
                                            {
                                                PayerPayableBreakUp obj1 = new PayerPayableBreakUp();
                                                obj1.ValLabel = attri1[0];
                                                if (!string.IsNullOrEmpty(attri1[1]))
                                                    obj1.Value = Convert.ToDecimal(attri1[1]);

                                                objPolVal.PPBreakUp.Add(obj1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        r++;
                        if (attri[r] != null && attri[r] != string.Empty)
                        {
                            ValidationSummary obj = new ValidationSummary();
                            foreach (string innerlist1 in attri[r].Split(Inner_ListElement_Start, Inner_ListElement_End))
                            {
                                if (innerlist1 != string.Empty)
                                {
                                    string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                    obj.CLAIM_ID = attri1[0];
                                    obj.REMARKS = attri1[1];
                                    obj.GROUP_ID = attri1[2];
                                    obj.ERROR_FLAG = attri1[3];
                                    obj.VALIDATION_NAME = attri1[4];
                                    obj.VALIDATION_LABEL = attri1[5];
                                    obj.VALIDATION_MESSAGE = attri1[6];
                                    obj.TARIFF_AMOUNT = attri1[7];
                                    obj.ELIGIBLE_AMOUNT = attri1[8];
                                    obj.DISALLOWED_AMOUNT = attri1[9];
                                    obj.PAYABLE_AMOUNT = attri1[10];
                                    obj.INFO_FLAG = attri1[11];
                                    obj.DISPLAY_FLAG = attri1[12];
                                    obj.BILL_ITEM_ID = attri1[13];
                                    obj.GROUP_NAME = attri1[14];
                                    obj.VALIDATION_MESSAGE_1 = attri1[15];
                                    obj.VALIDATION_MESSAGE_2 = attri1[16];
                                    obj.NO_CO_PAY = attri1[17];
                                    obj.COPAY_AMOUNT = attri1[18];
                                    obj.COPAY_TYPE = attri1[19];
                                    obj.DISPLAY_ORDER = attri1[20];
                                    obj.ORDER_ID = attri1[21];
                                    obj.PAYMENT_ID = attri1[22];
                                }
                            }
                            objPolVal.validationDataTable = obj;
                        }

                        r++;
                        if (attri[r] != null && attri[r] != string.Empty)
                        {
                            TranSummary obj = new TranSummary();
                            foreach (string innerlist1 in attri[r].Split(Inner_ListElement_Start, Inner_ListElement_End))
                            {
                                if (innerlist1 != string.Empty)
                                {
                                    string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                    obj.CLAIM_ID = attri1[0];
                                    obj.PRODUCT_COPAY = attri1[1];
                                    obj.COPAY_TYPE = attri1[2];
                                    obj.TOTAL_COPAY_AMOUNT = attri1[3];
                                    obj.TOTAL_BILL_AMOUNT = attri1[4];
                                    obj.TOTAL_ELIGIBLE_AMOUNT = attri1[5];
                                    obj.TOTAL_APPROVED_AMOUNT = attri1[6];
                                    obj.TOTAL_PATIENT_PAYABLE = attri1[7];
                                    obj.MOBILE_NO = attri1[8];
                                    obj.TOTAL_PAYABLE = attri1[9];
                                    obj.EMAIL_ID = attri1[10];
                                    obj.MEMBER_FIRST_NAME = attri1[11];
                                    obj.MEMBER_LAST_NAME = attri1[12];
                                    obj.MEMBER_MIDDLE_NAME = attri1[13];
                                    obj.PAYER_CODE = attri1[14];
                                    obj.POLICY_NO = attri1[15];
                                }
                            }
                            objPolVal.tranDataTable = obj;
                        }
                        objPolVal.ValidationResult = attri[++r];
                        objPolVal.ErrorCode = attri[++r];
                        objPolVal.ErrorDesc = attri[++r];
                        objPolVal.MemberId = attri[++r];
                        objPolVal.Payer_Code = attri[++r];
                        if (!string.IsNullOrEmpty(attri[++r]))
                            objPolVal.TransactionTimeOut = Convert.ToInt16(attri[r]);
                        objPolVal.PrescriptionID = attri[++r];
                    }
                }
                objPres.policyValidation = objPolVal;
            }



            return objPres;
        }

        public string PrescriptionClass_Serialize(PrescriptionClass objpre, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objpre.prescriptionId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.physicianName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.patientName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.prescriptionDate);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ailmentName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.procedureName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PrescriptionType);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryCity);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryState);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryAddress);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DeliveryPinCode);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PrecFileName);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PatientAge);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ServiceAccessTypeID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PatientGender);
            strOutPut.Append(split);
            strOutPut.Append(objpre.Remarks);
            strOutPut.Append(split);
            strOutPut.Append(objpre.PharmacyRemarks);
            strOutPut.Append(split);
            strOutPut.Append(objpre.TreatmentMethod);
            strOutPut.Append(split);



            //consultation
            if (objpre.Consultation != null)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.Consultation.ConsultationFee);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Consultation.ReviewDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Consultation.ConsulationRemarks);
                strOutPut.Append(ListElement_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //Clinical Find
            if (objpre.ClinicalFind != null)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.ClinicalFind.BP);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ClinicalFind.Pulse);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ClinicalFind.CVS);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ClinicalFind.Temperature);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ClinicalFind.Weight);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ClinicalFind.SugarA);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ClinicalFind.SugarB);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.ClinicalFind.Remarks);
                strOutPut.Append(ListElement_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //DrugList
            if (objpre.Druglist != null && objpre.Druglist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Drug objdrug in objpre.Druglist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objdrug.DrugID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DrugName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.NoOfDays);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DrugQuantity);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Evening);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Morning);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Night);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.BeforeFood);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Is_Ordered);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.IsFullOrdered);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.SubstituteWithDrugId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.MRP);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.No_of_Ordered_Tablet);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.Rate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.No_of_Tablet);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DrugCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageA);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageM);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DosageN);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdrug.DRUG_TYPE_DESC);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //pharmacyDetail
            if (objpre.pharmacyDetail != null)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objpre.pharmacyDetail.PharmacyID);
                strOutPut.Append(ListProperty_Split);
                _PharmacyId = objpre.pharmacyDetail.PharmacyID.ToString();
                strOutPut.Append(objpre.pharmacyDetail.PharmacyName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.ShippingCharge);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.DeliveryMinTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.DeliveryMaxTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.pharmacyDetail.Discount);
                strOutPut.Append(ListElement_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Diagnostic list
            if (objpre.DiagnosisDetail != null && objpre.DiagnosisDetail.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis objdia in objpre.DiagnosisDetail)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objdia.DiagnosisID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.ClaimID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.patientid);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.filename);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.ShowReport);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.AutoShowReport);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisRate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.Is_Ordered);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.Visit_Type);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //Orderdetails
            if (objpre.Orderdetails != null && objpre.Orderdetails.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Oderdetails objOrder in objpre.Orderdetails)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objOrder.order_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.prescription_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.address);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.pin);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.mobile_no);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.city);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.state);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.orderdate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.pharmacyname);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objOrder.Order_Amt);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            strOutPut.Append(objpre.pharmacyId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.AppointmentId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.IsAppointment);
            strOutPut.Append(split);
            strOutPut.Append(objpre.Is_health_check);
            strOutPut.Append(split);
            strOutPut.Append(objpre.NoBSIDeduct);
            strOutPut.Append(split);
            strOutPut.Append(objpre.IsBillingDesk);
            strOutPut.Append(split);
            strOutPut.Append(objpre.IsFollowUpCase);
            strOutPut.Append(split);
            strOutPut.Append(objpre.FollowUp_prescriptionId);
            strOutPut.Append(split);
            strOutPut.Append(objpre.GUID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.IsCashLess);
            strOutPut.Append(split);
            strOutPut.Append(objpre.paymentID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.orderID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.BillAmt);
            strOutPut.Append(split);
            strOutPut.Append(objpre.Discount);
            strOutPut.Append(split);
            strOutPut.Append(objpre.TotalBillAmt);
            strOutPut.Append(split);
            strOutPut.Append(objpre.physician_id);
            strOutPut.Append(split);
            strOutPut.Append(objpre.patient_id);
            strOutPut.Append(split);
            strOutPut.Append(objpre.MemberID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.TransactionType);
            strOutPut.Append(split);
            strOutPut.Append(objpre.payerCode);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ailmentid);
            strOutPut.Append(split);
            strOutPut.Append(objpre.procedureid);
            strOutPut.Append(split);
            strOutPut.Append(objpre.IsView);
            strOutPut.Append(split);
            strOutPut.Append(objpre.diagnosticId);
            strOutPut.Append(split);
            //payment
            if (objpre.paymentList != null && objpre.paymentList.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Payment objPay in objpre.paymentList)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objPay.PresNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.Transaction_type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.User_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.Payment_GUID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.Member_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.Payer_code);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.Payment_Type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.PayerPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.PatientPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.ErrorCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.ErrorDesc);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPay.BillAmount);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //ProcList
            if (objpre.Proclist != null && objpre.Proclist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Procedure obj in objpre.Proclist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.ProcedureID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ProcedureName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ProcedureCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.rate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ProcedureType);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PayerPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientPayable);


                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.UNITS);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.UNIT_COST);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.STANDARD_DISCOUNT);

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //TestList
            if (objpre.Testlist != null && objpre.Testlist.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Procedure obj in objpre.Testlist)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.ProcedureID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ProcedureName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ProcedureCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.rate);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PayerPayable);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientPayable);


                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.UNITS);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.UNIT_COST);

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.STANDARD_DISCOUNT);

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);

            strOutPut.Append(objpre.ErrorCode);
            strOutPut.Append(split);
            strOutPut.Append(objpre.ErrorDesc);
            strOutPut.Append(split);
            strOutPut.Append(objpre.EntityCode);
            strOutPut.Append(split);
            strOutPut.Append(objpre.INTERNALINVOICENO);
            strOutPut.Append(split);
            //Symptoms
            if (objpre.complaints != null && objpre.complaints.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (PrescriptionClass.complaint obj in objpre.complaints)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.name);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            //Attachment
            if (objpre.AttachmentsLst != null && objpre.AttachmentsLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (OP_Attachments obj in objpre.AttachmentsLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.AttachDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AttachFileName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AttachmentRemarks);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Claim_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.FilePath);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Self_ID);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Vitals 
            if (objpre.VitalsLst != null && objpre.VitalsLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Vital_Controls obj in objpre.VitalsLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.CONTROL_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_STYLE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXPAND);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_2TEXTBOX);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);

            if (objpre.Ailment_Details != null && objpre.Ailment_Details.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Ailment obj in objpre.Ailment_Details)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.AilmentID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AilmentName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.code);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            strOutPut.Append(objpre.CREATED_BY);
            strOutPut.Append(split);
            strOutPut.Append(objpre.MODIFIED_BY);
            strOutPut.Append(split);
            strOutPut.Append(objpre.DEVICEID);
            strOutPut.Append(split);
            strOutPut.Append(objpre.VISITORIP);
            strOutPut.Append(split);
            strOutPut.Append(objpre.prescription_type);
            strOutPut.Append(split);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass PrescriptionClass_Deserialize(string Response, string token)
        {
            PrescriptionClass objPres = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split); ;
            int i = 0;
            objPres.prescriptionId = values[i];
            objPres.physicianName = values[++i];
            objPres.patientName = values[++i];
            objPres.prescriptionDate = values[++i];
            objPres.ailmentName = values[++i];
            objPres.procedureName = values[++i];
            if (values[++i] != string.Empty)
                objPres.PrescriptionType = Convert.ToInt32(values[i]);
            objPres.DeliveryCity = values[++i];
            objPres.DeliveryState = values[++i];
            objPres.DeliveryAddress = values[++i];
            objPres.DeliveryPinCode = values[++i];
            objPres.PrecFileName = values[++i];
            objPres.PatientAge = values[++i];
            objPres.ServiceAccessTypeID = values[++i];
            objPres.PatientGender = values[++i];
            objPres.Remarks = values[++i];
            objPres.PharmacyRemarks = values[++i];
            objPres.TreatmentMethod = values[++i];
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                Consultation obj = new Consultation();
                foreach (string innerlist in values[i].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        obj.ConsultationFee = attri[0];
                        obj.ReviewDate = attri[1];
                        obj.ConsulationRemarks = attri[2];
                    }
                }
                objPres.Consultation = obj;
            }
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                ClinicalFind obj = new ClinicalFind();
                foreach (string innerlist in values[i].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        obj.BP = attri[0];
                        obj.Pulse = attri[1];
                        obj.CVS = attri[2];
                        obj.Temperature = attri[3];
                        obj.Weight = attri[4];
                        obj.SugarA = attri[5];
                        obj.SugarB = attri[6];
                        obj.Remarks = attri[7];
                    }
                }
                objPres.ClinicalFind = obj;
            }
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                List<Drug> objList = new List<Drug>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Drug objDrug = new Drug();
                                if (attri[0] != string.Empty)
                                    objDrug.DrugID = Convert.ToInt32(attri[0]);
                                objDrug.DrugName = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.NoOfDays = Convert.ToInt32(attri[2]);
                                if (attri[3] != string.Empty)
                                    objDrug.DrugQuantity = Convert.ToInt32(attri[3]);
                                if (attri[4] != string.Empty)
                                    objDrug.Evening = Convert.ToDecimal(attri[4]);
                                if (attri[5] != string.Empty)
                                    objDrug.Morning = Convert.ToDecimal(attri[5]);
                                if (attri[6] != string.Empty)
                                    objDrug.Night = Convert.ToDecimal(attri[6]);
                                if (attri[7] != string.Empty)
                                    objDrug.BeforeFood = Convert.ToInt32(attri[7]);
                                if (attri[8] != string.Empty)
                                    objDrug.Is_Ordered = Convert.ToInt32(attri[8]);
                                if (attri[9] != string.Empty)
                                    objDrug.IsFullOrdered = Convert.ToInt32(attri[9]);
                                if (attri[10] != string.Empty)
                                    objDrug.SubstituteWithDrugId = Convert.ToInt32(attri[10]);
                                if (attri[11] != string.Empty)
                                    objDrug.MRP = Convert.ToDecimal(attri[11]);
                                if (attri[12] != string.Empty)
                                    objDrug.No_of_Ordered_Tablet = Convert.ToInt32(attri[12]);
                                if (attri[13] != string.Empty)
                                    objDrug.Rate = Convert.ToDecimal(attri[13]);
                                if (attri[14] != string.Empty)
                                    objDrug.No_of_Tablet = Convert.ToInt32(attri[14]);
                                if (attri[15] != string.Empty)
                                    objDrug.DrugCode = attri[15];
                                if (attri[16] != string.Empty)
                                    objDrug.DosageA = attri[16];
                                if (attri[17] != string.Empty)
                                    objDrug.DosageM = attri[17];
                                if (attri[18] != string.Empty)
                                    objDrug.DosageN = attri[18];
                                if (attri.Length > 19 && attri[19] != string.Empty)
                                    objDrug.DRUG_TYPE_DESC = attri[19];
                                objList.Add(objDrug);
                            }
                        }
                    }
                }
                objPres.Druglist = objList;
            }
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                Pharmacy objPhr = new Pharmacy();
                foreach (string innerlist in values[i].Split(ListElement_Start, ListElement_End))
                {
                    if (innerlist != string.Empty)
                    {
                        string[] attri = innerlist.Split(ListProperty_Split);
                        if (attri[0] != string.Empty)
                            objPhr.PharmacyID = Convert.ToInt32(attri[0]);
                        objPhr.PharmacyName = attri[1];
                        if (attri[2] != string.Empty)
                            objPhr.ShippingCharge = Convert.ToDecimal(attri[2]);
                        objPhr.DeliveryMinTime = Convert.ToInt32(attri[3]);
                        objPhr.DeliveryMaxTime = Convert.ToInt32(attri[4]);
                        objPhr.Discount = Convert.ToDecimal(attri[5]);
                    }
                }

                objPres.pharmacyDetail = objPhr;
            }
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {

                List<Diagnosis> objList = new List<Diagnosis>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Diagnosis objDrug = new Diagnosis();
                                if (attri[0] != string.Empty)
                                    objDrug.DiagnosisID = Convert.ToInt32(attri[0]);
                                objDrug.DiagnosisName = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.ClaimID = attri[2];
                                if (attri[3] != string.Empty)
                                    objDrug.patientid = Convert.ToInt32(attri[3]);
                                objDrug.filename = attri[4];
                                if (attri[5] != string.Empty)
                                    objDrug.ShowReport = Convert.ToInt32(attri[5]);
                                if (attri[6] != string.Empty)
                                    objDrug.AutoShowReport = Convert.ToInt32(attri[6]);
                                if (attri[7] != string.Empty)
                                    objDrug.DiagnosisRate = Convert.ToDecimal(attri[7]);
                                if (attri[8] != string.Empty)
                                    objDrug.Is_Ordered = Convert.ToInt32(attri[8]);
                                objDrug.DiagnosisCode = attri[9];
                                objDrug.Visit_Type = attri[10];
                                objList.Add(objDrug);
                            }
                        }
                    }
                }
                objPres.DiagnosisDetail = objList;
            }
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                List<Oderdetails> objList = new List<Oderdetails>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Oderdetails ObjOrder = new Oderdetails();
                                ObjOrder.order_id = attri[0];
                                ObjOrder.prescription_id = attri[1];
                                ObjOrder.address = attri[2];
                                ObjOrder.pin = attri[3];
                                ObjOrder.mobile_no = attri[4];
                                ObjOrder.city = attri[5];
                                ObjOrder.state = attri[6];
                                ObjOrder.orderdate = attri[7];
                                ObjOrder.pharmacyname = attri[8];
                                ObjOrder.Order_Amt = attri[9];

                                objList.Add(ObjOrder);
                            }
                        }
                    }
                }

                objPres.Orderdetails = objList;
            }

            objPres.pharmacyId = values[++i];
            if (values[++i] != string.Empty)
                objPres.AppointmentId = Convert.ToInt32(values[i]);
            if (values[++i] != string.Empty)
                objPres.IsAppointment = Convert.ToInt16(values[i]);
            if (values[++i] != string.Empty)
                objPres.Is_health_check = Convert.ToInt16(values[i]);
            if (values[++i] != string.Empty)
                objPres.NoBSIDeduct = Convert.ToInt16(values[i]);
            if (values[++i] != string.Empty)
                objPres.IsBillingDesk = Convert.ToBoolean(values[i]);
            if (values[++i] != string.Empty)
                objPres.IsFollowUpCase = Convert.ToInt16(values[i]);
            objPres.FollowUp_prescriptionId = values[++i];
            objPres.GUID = values[++i];
            if (values[++i] != string.Empty)
                objPres.IsCashLess = Convert.ToBoolean(values[i]);
            objPres.paymentID = values[++i];
            objPres.orderID = values[++i];
            if (values[++i] != string.Empty)
                objPres.BillAmt = Convert.ToDecimal(values[i]);
            if (values[++i] != string.Empty)
                objPres.Discount = Convert.ToDecimal(values[i]);
            if (values[++i] != string.Empty)
                objPres.TotalBillAmt = Convert.ToDecimal(values[i]);
            objPres.physician_id = values[++i];
            objPres.patient_id = values[++i];
            objPres.MemberID = values[++i];
            objPres.TransactionType = values[++i];
            objPres.payerCode = values[++i];
            objPres.ailmentid = values[++i];
            objPres.procedureid = values[++i];
            if (values[++i] != string.Empty)
                objPres.IsView = Convert.ToBoolean(values[i]);
            objPres.diagnosticId = values[++i];

            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                objPres.paymentList = new List<Payment>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Payment Objpay = new Payment();
                                Objpay.PresNo = attri[0];
                                if (!string.IsNullOrEmpty(attri[1]))
                                    Objpay.Transaction_type = Convert.ToInt16(attri[1]);
                                if (!string.IsNullOrEmpty(attri[2]))
                                    Objpay.User_Id = Convert.ToInt32(attri[2]);
                                Objpay.Payment_GUID = attri[3];
                                Objpay.Member_Id = attri[4];
                                Objpay.Payer_code = attri[5];
                                if (!string.IsNullOrEmpty(attri[6]))
                                    Objpay.Payment_Type = Convert.ToInt16(attri[6]);
                                if (!string.IsNullOrEmpty(attri[7]))
                                    Objpay.PayerPayable = Convert.ToDecimal(attri[7]);
                                if (!string.IsNullOrEmpty(attri[8]))
                                    Objpay.PatientPayable = Convert.ToDecimal(attri[8]);
                                Objpay.ErrorCode = attri[9];
                                Objpay.ErrorDesc = attri[10];
                                if (!string.IsNullOrEmpty(attri[11]))
                                    Objpay.BillAmount = Convert.ToDecimal(attri[11]);
                                objPres.paymentList.Add(Objpay);
                            }
                        }
                    }
                }

            }
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                List<Procedure> objList = new List<Procedure>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Procedure objP = new Procedure();
                                if (attri[0] != string.Empty)
                                    objP.ProcedureID = Convert.ToInt32(attri[0]);
                                objP.ProcedureName = attri[1];
                                objP.ProcedureCode = attri[2];
                                objP.rate = attri[3];
                                if (attri.Count() > 4)
                                {
                                    if (!string.IsNullOrEmpty(attri[4]))
                                        objP.ProcedureType = Convert.ToInt32(attri[4]);
                                }

                                if (attri[5] != string.Empty)
                                    objP.PayerPayable = Convert.ToString(attri[5]);

                                if (attri[6] != string.Empty)
                                    objP.PatientPayable = Convert.ToString(attri[6]);

                                if (attri[7] != string.Empty)
                                    objP.UNITS = Convert.ToString(attri[7]);

                                if (attri[8] != string.Empty)
                                    objP.UNIT_COST = Convert.ToString(attri[8]);

                                if (attri[9] != string.Empty)
                                    objP.STANDARD_DISCOUNT = Convert.ToString(attri[9]);

                                objList.Add(objP);
                            }
                        }
                    }
                }
                objPres.Proclist = objList;
            }
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                List<Procedure> objList = new List<Procedure>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Procedure objP = new Procedure();
                                if (attri[0] != string.Empty)
                                    objP.ProcedureID = Convert.ToInt32(attri[0]);
                                objP.ProcedureName = attri[1];
                                objP.ProcedureCode = attri[2];
                                objP.rate = attri[3];

                                if (attri[4] != string.Empty)
                                    objP.PayerPayable = Convert.ToString(attri[4]);

                                if (attri[5] != string.Empty)
                                    objP.PatientPayable = Convert.ToString(attri[5]);

                                if (attri[6] != string.Empty)
                                    objP.UNITS = Convert.ToString(attri[6]);

                                if (attri[7] != string.Empty)
                                    objP.UNIT_COST = Convert.ToString(attri[7]);

                                if (attri[8] != string.Empty)
                                    objP.STANDARD_DISCOUNT = Convert.ToString(attri[8]);

                                objList.Add(objP);
                            }
                        }
                    }
                }
                objPres.Testlist = objList;
            }
            objPres.ErrorCode = values[++i];
            objPres.ErrorDesc = values[++i];
            objPres.EntityCode = values[++i];
            objPres.INTERNALINVOICENO = values[++i];
            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                List<PrescriptionClass.complaint> objList = new List<PrescriptionClass.complaint>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                PrescriptionClass.complaint objP = new PrescriptionClass.complaint();
                                objP.name = attri[0];
                                objList.Add(objP);
                            }
                        }
                    }
                }
                objPres.complaints = objList;
            }

            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                objPres.AttachmentsLst = new List<OP_Attachments>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                OP_Attachments objatt = new OP_Attachments();
                                objatt.AttachDate = attri[0];
                                objatt.AttachFileName = attri[1];
                                objatt.AttachmentRemarks = attri[2];
                                objatt.Claim_Id = attri[3];
                                objatt.FilePath = attri[4];
                                if (attri[5] != string.Empty)
                                    objatt.PatientId = Convert.ToInt32(attri[5]);
                                if (attri[6] != string.Empty)
                                    objatt.Self_ID = Convert.ToInt32(attri[6]);
                                objPres.AttachmentsLst.Add(objatt);
                            }
                        }
                    }
                }

            }

            i++;
            if (values[i] != null && values[i] != string.Empty)
            {
                objPres.VitalsLst = new List<Vital_Controls>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Vital_Controls obj1 = new Vital_Controls();
                                string[] attri = innerlist.Split(ListProperty_Split);
                                obj1.CONTROL_TEXT = attri[0];
                                obj1.CONTROL_TEXT_STYLE = attri[1];
                                obj1.CONTROL_TEXT_VALUE = attri[2];
                                obj1.CONTROL_TYPE = attri[3];
                                if (!string.IsNullOrWhiteSpace(attri[4]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(attri[4]);
                                if (!string.IsNullOrWhiteSpace(attri[5]))
                                    obj1.IS_EXPAND = Convert.ToInt32(attri[5]);
                                if (!string.IsNullOrWhiteSpace(attri[6]))
                                    obj1.IS_2TEXTBOX = Convert.ToInt32(attri[6]);
                                objPres.VitalsLst.Add(obj1);
                            }
                        }
                    }
                }

            }
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
            {
                objPres.Ailment_Details = new List<Ailment>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Ailment obj1 = new Ailment();
                                string[] attri = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrEmpty(attri[0]))
                                    obj1.AilmentID = Convert.ToInt32(attri[0]);
                                obj1.AilmentName = attri[1];
                                obj1.code = attri[2];
                                objPres.Ailment_Details.Add(obj1);
                            }
                        }
                    }
                }

            }
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
                objPres.CREATED_BY = values[i];
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
                objPres.MODIFIED_BY = values[i];
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
                objPres.DEVICEID = values[i];
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
                objPres.VISITORIP = values[i];
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
                objPres.prescription_type = Convert.ToInt32(values[i]);
            return objPres;
        }
        public string ValidateValidateUserExists_Request_serialize(int userType, string userID, string EntityCode)
        {
            string outPut = string.Empty;

            outPut = userType + split + userID.ToString() + split + EntityCode;

            return StringCipher.Encrypt(outPut, key);
        }

        public QueryRequest ValidateValidateUserExists_Request_Deserialize(string Request)
        {
            QueryRequest obj = new QueryRequest();
            string[] values = StringCipher.Decrypt(Request, key).Split(split);
            obj.param = new List<string>();
            foreach (string strval in values)
            {
                if (!strval.Contains(ListIdentifier_Start))
                {
                    obj.param.Add(strval);
                }
            }
            return obj;
        }

        public string ValidateUser_Response_serialize(string Response)
        {
            string outPut = string.Empty;

            outPut = Response.ToString();

            return StringCipher.Encrypt(outPut, key);
        }

        public string ValidateUser_Response_Deserialize(string Resposne)
        {
            string outPut = string.Empty;

            outPut = StringCipher.Decrypt(Resposne, key);

            return outPut;
        }

        public string GetEntityItemsRateFromPayer_Req_Serialize(ItemList objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objResposne.transactionType);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.ProviderCode);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.IsHC);
            strOutPut.Append(split);
            if (objResposne.lstItem != null)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (ItemDetails lst in objResposne.lstItem)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(lst.ItemCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(lst.Item);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(lst.Value);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public ItemList GetEntityItemsRateFromPayer_Req_Deserialize(string Response, string token)
        {
            ItemList objlst = new ItemList();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 0)
            {
                objlst.transactionType = values[0];
                objlst.ProviderCode = values[1];
                objlst.IsHC = values[2];
                if (!string.IsNullOrEmpty(values[3]))
                {
                    objlst.lstItem = new List<ItemDetails>();
                    foreach (string list in values[3].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);

                                    if (attri.Length > 0)
                                    {
                                        ItemDetails obj = new ItemDetails();
                                        obj.ItemCode = attri[0];
                                        obj.Item = attri[1];
                                        obj.Value = attri[2];
                                        objlst.lstItem.Add(obj);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return objlst;
        }

        public string GetOrderDashboardDetails_Phar_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                //Orderdetails
                if (PreClass.Orderdetails != null && PreClass.Orderdetails.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Oderdetails objOrder in PreClass.Orderdetails)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objOrder.order_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.prescription_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.orderdate);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objOrder.Order_Amt);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetOrderDashboardDetails_Phar_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] arr = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in arr)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] values = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = values[0];
                                    objPres.patientName = values[1];
                                    objPres.patient_id = values[2];

                                    if (values[3] != null && values[3] != string.Empty)
                                    {
                                        List<Oderdetails> objLstOrd = new List<Oderdetails>();
                                        foreach (string list1 in values[3].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (innerlist1 != string.Empty)
                                                    {
                                                        string[] attri = innerlist1.Split(Inner_ListProperty_Split);
                                                        Oderdetails ObjOrder = new Oderdetails();
                                                        ObjOrder.order_id = attri[0];
                                                        ObjOrder.prescription_id = attri[1];
                                                        ObjOrder.orderdate = attri[2];
                                                        ObjOrder.Order_Amt = attri[3];

                                                        objLstOrd.Add(ObjOrder);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.Orderdetails = objLstOrd;
                                    }
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetActiveAppointment_Pat_Serialize(List<Appointment> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Appointment objApp in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objApp.AppointmentID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.AppointmentDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PhysicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SpecialityDec);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Status);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Appointment> GetActiveAppointment_Pat_Deserialize(string Response, string Token)
        {
            List<Appointment> objapp = new List<Appointment>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Appointment obj = new Appointment();
                            if (attri[0] != string.Empty)
                                obj.AppointmentID = Convert.ToInt32(attri[0]);
                            obj.AppointmentDate = attri[1];
                            obj.EntityName = attri[2];
                            obj.PatientName = attri[3];
                            obj.PhysicianName = attri[4];
                            if (attri[5] != string.Empty)
                                obj.SlotID = Convert.ToInt16(attri[5]);
                            obj.SpecialityDec = attri[6];
                            if (attri[7] != string.Empty)
                                obj.Status = Convert.ToInt16(attri[7]);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string UpdateUserDetails_Pat_Serialize(Patient Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();

            objOutPut.Append(Response.PatienID);
            objOutPut.Append(split);
            objOutPut.Append(Response.UserName);
            objOutPut.Append(split);
            objOutPut.Append(Response.Age);
            objOutPut.Append(split);
            objOutPut.Append(Response.Gender);
            objOutPut.Append(split);
            objOutPut.Append(Response.MobileNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.PINCode);
            objOutPut.Append(split);
            objOutPut.Append(Response.EmailID);
            objOutPut.Append(split);
            objOutPut.Append(Response.DOB);
            objOutPut.Append(split);
            objOutPut.Append(Response.Address);
            objOutPut.Append(split);
            objOutPut.Append(Response.CityID);
            objOutPut.Append(split);
            objOutPut.Append(Response.GenderID);
            objOutPut.Append(split);
            objOutPut.Append(Response.MemberNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.ShowReportAutomatic);
            objOutPut.Append(split);
            objOutPut.Append(Response.is_show_prescription_depend);
            objOutPut.Append(split);
            objOutPut.Append(Response.WalletAmount);
            objOutPut.Append(split);

            if (Response.PatientPayerList != null && Response.PatientPayerList.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (PatientPayer obj in Response.PatientPayerList)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(obj.MemberNo);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(obj.PayerID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(obj.PayerCode);
                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            objOutPut.Append(Response.UserID);
            objOutPut.Append(split);
            objOutPut.Append(Response.UserType);
            objOutPut.Append(split);
            objOutPut.Append(Response.IsOTPVerified);
            objOutPut.Append(split);
            objOutPut.Append(Response.RelationShipID);
            objOutPut.Append(split);

            //Primary Address
            if (Response.lstHomeaddress != null && Response.lstHomeaddress.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstHomeaddress)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            //Secondary Address
            if (Response.lstOfficeAddress != null && Response.lstOfficeAddress.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstOfficeAddress)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            //Shipping Details
            if (Response.lstShippingAdd != null && Response.lstShippingAdd.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstShippingAdd)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            //Shipping Details
            if (Response.lstShippingAdd1 != null && Response.lstShippingAdd1.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstShippingAdd1)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }

            objOutPut.Append(split);
            objOutPut.Append(Response.Secondary_mobileno);
            objOutPut.Append(split);
            objOutPut.Append(Response.Secondary_emailid);
            objOutPut.Append(split);
            objOutPut.Append(Response.Address1);
            objOutPut.Append(split);
            objOutPut.Append(Response.AadharNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.PanNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.MobEMaiReverseUpdateReq);


            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }


        public Patient UpdateUserDetails_Pat_Deserialize(string Response, string token)
        {
            Patient objPat = new Patient();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objPat.PatienID = Convert.ToInt32(values[0]);
            objPat.UserName = values[1];
            if (values[2] != string.Empty)
                objPat.Age = Convert.ToInt16(values[2]);
            objPat.Gender = values[3];
            objPat.MobileNo = values[4];
            objPat.PINCode = values[5];
            objPat.EmailID = values[6];
            objPat.DOB = values[7];
            objPat.Address = values[8];
            if (values[9] != string.Empty)
                objPat.CityID = Convert.ToInt16(values[9]);
            if (values[10] != string.Empty)
                objPat.GenderID = Convert.ToInt16(values[10]);
            objPat.MemberNo = values[11];
            if (values[12] != string.Empty)
                objPat.ShowReportAutomatic = Convert.ToInt16(values[12]);
            if (values[13] != string.Empty)
                objPat.is_show_prescription_depend = Convert.ToInt16(values[13]);
            if (values[14] != string.Empty)
                objPat.WalletAmount = Convert.ToDecimal(values[14]);



            if (values[15] != null && values[15] != string.Empty)
            {
                objPat.PatientPayerList = new List<PatientPayer>();
                foreach (string list in values[15].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                PatientPayer objp = new PatientPayer();
                                objp.MemberNo = attri[0];
                                if (attri[1] != string.Empty)
                                    objp.PayerID = Convert.ToInt32(attri[1]);
                                objp.PayerCode = attri[2];

                                objPat.PatientPayerList.Add(objp);
                            }
                        }
                    }
                }
            }
            if (values[16] != string.Empty)
                objPat.UserID = Convert.ToString(values[16]);
            if (values[17] != string.Empty)
                objPat.UserType = Convert.ToInt16(values[17]);
            if (values[18] != string.Empty)
                objPat.IsOTPVerified = Convert.ToBoolean(values[18]);
            if (values[19] != string.Empty)
                objPat.RelationShipID = Convert.ToInt16(values[19]);

            if (values[20] != null && values[20] != string.Empty)
            {
                objPat.lstHomeaddress = new List<ShippingAddress>();
                foreach (string list in values[20].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];

                                objS.locality = attri[16];

                                objPat.lstHomeaddress.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[21] != null && values[21] != string.Empty)
            {
                objPat.lstOfficeAddress = new List<ShippingAddress>();
                foreach (string list in values[21].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];
                                objS.locality = attri[16];

                                objPat.lstOfficeAddress.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[22] != null && values[22] != string.Empty)
            {
                objPat.lstShippingAdd = new List<ShippingAddress>();
                foreach (string list in values[22].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];

                                objS.locality = attri[16];

                                objPat.lstShippingAdd.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[23] != null && values[23] != string.Empty)
            {
                objPat.lstShippingAdd1 = new List<ShippingAddress>();
                foreach (string list in values[23].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];

                                objS.locality = attri[16];

                                objPat.lstShippingAdd1.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[24] != string.Empty)
                objPat.Secondary_mobileno = Convert.ToString(values[24]);
            if (values[25] != string.Empty)
                objPat.Secondary_emailid = Convert.ToString(values[25]);
            if (values[26] != string.Empty)
                objPat.Address1 = Convert.ToString(values[26]);
            if (values[27] != string.Empty)
                objPat.AadharNo = values[27];
            if (values[28] != string.Empty)
                objPat.PanNo = values[28];
            if (values.Count() > 29)
            {
                if (values[29] != string.Empty)
                    objPat.MobEMaiReverseUpdateReq = Convert.ToInt32(values[29]);
            }
            return objPat;
        }


        public string UpdateUserDetails_Pat_Serialize_V2(Patient Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();

            objOutPut.Append(Response.PatienID);
            objOutPut.Append(split);
            objOutPut.Append(Response.UserName);
            objOutPut.Append(split);
            objOutPut.Append(Response.Age);
            objOutPut.Append(split);
            objOutPut.Append(Response.Gender);
            objOutPut.Append(split);
            objOutPut.Append(Response.MobileNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.PINCode);
            objOutPut.Append(split);
            objOutPut.Append(Response.EmailID);
            objOutPut.Append(split);
            objOutPut.Append(Response.DOB);
            objOutPut.Append(split);
            objOutPut.Append(Response.Address);
            objOutPut.Append(split);
            objOutPut.Append(Response.CityID);
            objOutPut.Append(split);
            objOutPut.Append(Response.GenderID);
            objOutPut.Append(split);
            objOutPut.Append(Response.MemberNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.ShowReportAutomatic);
            objOutPut.Append(split);
            objOutPut.Append(Response.is_show_prescription_depend);
            objOutPut.Append(split);
            objOutPut.Append(Response.WalletAmount);
            objOutPut.Append(split);


            if (Response.PatientPayerList != null && Response.PatientPayerList.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (PatientPayer obj in Response.PatientPayerList)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(obj.MemberNo);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(obj.PayerID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(obj.PayerCode);
                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            objOutPut.Append(Response.UserID);
            objOutPut.Append(split);
            objOutPut.Append(Response.UserType);
            objOutPut.Append(split);
            objOutPut.Append(Response.IsOTPVerified);
            objOutPut.Append(split);
            objOutPut.Append(Response.RelationShipID);
            objOutPut.Append(split);

            //Primary Address
            if (Response.lstHomeaddress != null && Response.lstHomeaddress.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstHomeaddress)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            //Secondary Address
            if (Response.lstOfficeAddress != null && Response.lstOfficeAddress.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstOfficeAddress)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            //Shipping Details
            if (Response.lstShippingAdd != null && Response.lstShippingAdd.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstShippingAdd)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }
            objOutPut.Append(split);
            //Shipping Details
            if (Response.lstShippingAdd1 != null && Response.lstShippingAdd1.Count > 0)
            {
                objOutPut.Append(ListIdentifier_Start);
                foreach (ShippingAddress objS in Response.lstShippingAdd1)
                {
                    objOutPut.Append(ListElement_Start);
                    objOutPut.Append(objS.AddressId);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.AddressTitle);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street1);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Street2);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.PinCode);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.CityID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.StateID);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.Country);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.MobileNo);
                    objOutPut.Append(ListProperty_Split);

                    objOutPut.Append(objS.consumer_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.primary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.secondary_emailid);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.company_name);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.address_type);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.City);
                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.State);

                    objOutPut.Append(ListProperty_Split);
                    objOutPut.Append(objS.locality);

                    objOutPut.Append(ListElement_End);
                }
                objOutPut.Append(ListIdentifier_End);
            }
            else
            {
                objOutPut.Append("");
            }

            objOutPut.Append(split);
            objOutPut.Append(Response.Secondary_mobileno);
            objOutPut.Append(split);
            objOutPut.Append(Response.Secondary_emailid);
            objOutPut.Append(split);
            objOutPut.Append(Response.Address1);
            objOutPut.Append(split);
            objOutPut.Append(Response.AadharNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.PanNo);
            objOutPut.Append(split);
            objOutPut.Append(Response.MobEMaiReverseUpdateReq);
            objOutPut.Append(split);

            objOutPut.Append(Response.UserID);
            objOutPut.Append(split);

            objOutPut.Append(Response.VISITORIP);
            objOutPut.Append(split);

            objOutPut.Append(Response.DEVICEID);
            objOutPut.Append(split);

            objOutPut.Append(Response.AccountNumber);
            objOutPut.Append(split);
            objOutPut.Append(Response.AccountType);
            objOutPut.Append(split);
            objOutPut.Append(Response.BankName);
            objOutPut.Append(split);
            objOutPut.Append(Response.BranchName);
            objOutPut.Append(split);
            objOutPut.Append(Response.IFSCCode);
            objOutPut.Append(split);
            objOutPut.Append(Response.PayeeName);
            objOutPut.Append(split);

            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }


        public Patient UpdateUserDetails_Pat_Deserialize_V2(string Response, string token)
        {
            Patient objPat = new Patient();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objPat.PatienID = Convert.ToInt32(values[0]);
            objPat.UserName = values[1];
            if (values[2] != string.Empty)
                objPat.Age = Convert.ToInt16(values[2]);
            objPat.Gender = values[3];
            objPat.MobileNo = values[4];
            objPat.PINCode = values[5];
            objPat.EmailID = values[6];
            objPat.DOB = values[7];
            objPat.Address = values[8];
            if (values[9] != string.Empty)
                objPat.CityID = Convert.ToInt16(values[9]);
            if (values[10] != string.Empty)
                objPat.GenderID = Convert.ToInt16(values[10]);
            objPat.MemberNo = values[11];
            if (values[12] != string.Empty)
                objPat.ShowReportAutomatic = Convert.ToInt16(values[12]);
            if (values[13] != string.Empty)
                objPat.is_show_prescription_depend = Convert.ToInt16(values[13]);
            if (values[14] != string.Empty)
                objPat.WalletAmount = Convert.ToDecimal(values[14]);



            if (values[15] != null && values[15] != string.Empty)
            {
                objPat.PatientPayerList = new List<PatientPayer>();
                foreach (string list in values[15].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                PatientPayer objp = new PatientPayer();
                                objp.MemberNo = attri[0];
                                if (attri[1] != string.Empty)
                                    objp.PayerID = Convert.ToInt32(attri[1]);
                                objp.PayerCode = attri[2];

                                objPat.PatientPayerList.Add(objp);
                            }
                        }
                    }
                }
            }
            if (values[16] != string.Empty)
                objPat.UserID = Convert.ToString(values[16]);
            if (values[17] != string.Empty)
                objPat.UserType = Convert.ToInt16(values[17]);
            if (values[18] != string.Empty)
                objPat.IsOTPVerified = Convert.ToBoolean(values[18]);
            if (values[19] != string.Empty)
                objPat.RelationShipID = Convert.ToInt16(values[19]);

            if (values[20] != null && values[20] != string.Empty)
            {
                objPat.lstHomeaddress = new List<ShippingAddress>();
                foreach (string list in values[20].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];

                                objS.locality = attri[16];

                                objPat.lstHomeaddress.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[21] != null && values[21] != string.Empty)
            {
                objPat.lstOfficeAddress = new List<ShippingAddress>();
                foreach (string list in values[21].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];
                                objS.locality = attri[16];

                                objPat.lstOfficeAddress.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[22] != null && values[22] != string.Empty)
            {
                objPat.lstShippingAdd = new List<ShippingAddress>();
                foreach (string list in values[22].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];

                                objS.locality = attri[16];

                                objPat.lstShippingAdd.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[23] != null && values[23] != string.Empty)
            {
                objPat.lstShippingAdd1 = new List<ShippingAddress>();
                foreach (string list in values[23].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ShippingAddress objS = new ShippingAddress();
                                objS.AddressId = attri[0];
                                objS.AddressTitle = attri[1];
                                objS.Street1 = attri[2];
                                objS.Street2 = attri[3];
                                objS.PinCode = attri[4];
                                objS.CityID = attri[5];
                                objS.StateID = attri[6];
                                objS.Country = attri[7];
                                objS.MobileNo = attri[8];

                                objS.consumer_name = attri[9];
                                objS.primary_emailid = attri[10];
                                objS.secondary_emailid = attri[11];
                                objS.company_name = attri[12];
                                objS.address_type = attri[13];

                                objS.City = attri[14];
                                objS.State = attri[15];

                                objS.locality = attri[16];

                                objPat.lstShippingAdd1.Add(objS);
                            }
                        }
                    }
                }
            }

            if (values[24] != string.Empty)
                objPat.Secondary_mobileno = Convert.ToString(values[24]);
            if (values[25] != string.Empty)
                objPat.Secondary_emailid = Convert.ToString(values[25]);
            if (values[26] != string.Empty)
                objPat.Address1 = Convert.ToString(values[26]);
            if (values[27] != string.Empty)
                objPat.AadharNo = values[27];
            if (values[28] != string.Empty)
                objPat.PanNo = values[28];
            if (values.Count() > 29)
            {
                if (values[29] != string.Empty)
                    objPat.MobEMaiReverseUpdateReq = Convert.ToInt32(values[29]);
            }

            if (values.Count() > 30)
            {
                if (values[30] != string.Empty)
                    objPat.UserID = Convert.ToString(values[30]);
            }

            if (values.Count() > 31)
            {
                if (values[31] != string.Empty)
                    objPat.VISITORIP = Convert.ToString(values[31]);
            }

            if (values.Count() > 32)
            {
                if (values[32] != string.Empty)
                    objPat.DEVICEID = Convert.ToString(values[32]);
            }

            if (values.Count() > 33 && values[33] != string.Empty)
                objPat.AccountNumber = Convert.ToString(values[33]);
            if (values.Count() > 34 && values[34] != string.Empty)
                objPat.AccountType = Convert.ToString(values[34]);
            if (values.Count() > 35 && values[35] != string.Empty)
                objPat.BankName = Convert.ToString(values[35]);
            if (values.Count() > 36 && values[36] != string.Empty)
                objPat.BranchName = Convert.ToString(values[36]);
            if (values.Count() > 37 && values[37] != string.Empty)
                objPat.IFSCCode = Convert.ToString(values[37]);
            if (values.Count() > 38 && values[38] != string.Empty)
                objPat.PayeeName = Convert.ToString(values[38]);

            return objPat;
        }

        public string Boolean_Response_serialize(bool Response, string token)
        {
            string outPut = string.Empty;

            outPut = Response.ToString();

            return StringCipher.Encrypt(outPut, token);
        }

        public string GetMemberUtilization_Serialize(BenefitList Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            if (Response != null)
            {
                outPut.Append(Response.BSI);

                outPut.Append(split);
                outPut.Append(Response.SI);

                outPut.Append(split);
                if (Response.lstBenefit != null)
                {
                    outPut.Append(ListIdentifier_Start);
                    foreach (BenefitDashB obj in Response.lstBenefit)
                    {
                        outPut.Append(ListElement_Start);
                        outPut.Append(obj.BenefitType);
                        outPut.Append(ListProperty_Split);
                        outPut.Append(obj.TotalCnt);
                        outPut.Append(ListProperty_Split);
                        outPut.Append(obj.UtilizedCnt);
                        outPut.Append(ListProperty_Split);
                        outPut.Append(obj.BalanceCnt);
                        outPut.Append(ListProperty_Split);
                        outPut.Append(obj.TotalAmt);
                        outPut.Append(ListProperty_Split);
                        outPut.Append(obj.UtilizedAmt);
                        outPut.Append(ListProperty_Split);
                        outPut.Append(obj.BalanceAmt);
                        outPut.Append(ListElement_End);
                    }
                    outPut.Append(ListIdentifier_End);
                }
                else
                {
                    outPut.Append("");
                }
                outPut.Append(split);
                outPut.Append(Response.Header);
                outPut.Append(split);
                if (Response.objItemBenefit != null)
                {
                    outPut.Append(ListIdentifier_Start);
                    outPut.Append(ListElement_Start);
                    outPut.Append(Response.objItemBenefit.Header);
                    outPut.Append(ListProperty_Split);
                    if (Response.objItemBenefit.lstItem != null)
                    {
                        outPut.Append(Inner_ListIdentifier_Start);
                        foreach (BenefitDashB obj in Response.objItemBenefit.lstItem)
                        {
                            outPut.Append(Inner_ListElement_Start);
                            outPut.Append(obj.BenefitType);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(obj.TotalCnt);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(obj.UtilizedCnt);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(obj.BalanceCnt);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(obj.TotalAmt);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(obj.UtilizedAmt);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(obj.BalanceAmt);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(obj.ItemName);
                            outPut.Append(Inner_ListElement_End);
                        }
                        outPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        outPut.Append("");
                    }
                    outPut.Append(ListElement_End);
                    outPut.Append(ListIdentifier_End);
                }
                outPut.Append(split);
                outPut.Append(Response.HideCntInsured);
                outPut.Append(split);
                outPut.Append(Response.HideTariff);
            }
            return StringCipher.Encrypt(outPut.ToString(), token);
        }


        public BenefitList GetMemberUtilization_Deserialize(string Response, string token)
        {
            BenefitList objBLst = new BenefitList();
            if (!string.IsNullOrEmpty(Response))
            {
                string strResponse = StringCipher.Decrypt(Response, token);
                string[] attri = strResponse.Split(split);
                objBLst.BSI = attri[0];
                objBLst.SI = attri[1];

                if (attri[2] != string.Empty)
                {
                    objBLst.lstBenefit = new List<BenefitDashB>();
                    foreach (string list in attri[2].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri1 = innerlist.Split(ListProperty_Split);
                                    BenefitDashB obj = new BenefitDashB();
                                    obj.BenefitType = attri1[0];
                                    obj.TotalCnt = attri1[1];
                                    obj.UtilizedCnt = attri1[2];
                                    obj.BalanceCnt = attri1[3];
                                    obj.TotalAmt = attri1[4];
                                    obj.UtilizedAmt = attri1[5];
                                    obj.BalanceAmt = attri1[6];
                                    objBLst.lstBenefit.Add(obj);
                                }
                            }
                        }
                    }
                }
                objBLst.Header = attri[3];

                if (attri[4] != string.Empty)
                {
                    objBLst.objItemBenefit = new ItemWiseBenefit();
                    foreach (string list in attri[4].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri1 = innerlist.Split(ListProperty_Split);

                                    objBLst.objItemBenefit.Header = attri1[0];
                                    if (attri1[1] != string.Empty)
                                    {
                                        objBLst.objItemBenefit.lstItem = new List<BenefitDashB>();
                                        foreach (string list1 in attri1[1].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (innerlist1 != string.Empty)
                                                    {
                                                        string[] attri2 = innerlist1.Split(Inner_ListProperty_Split);
                                                        BenefitDashB obj = new BenefitDashB();
                                                        obj.BenefitType = attri2[0];
                                                        obj.TotalCnt = attri2[1];
                                                        obj.UtilizedCnt = attri2[2];
                                                        obj.BalanceCnt = attri2[3];
                                                        obj.TotalAmt = attri2[4];
                                                        obj.UtilizedAmt = attri2[5];
                                                        obj.BalanceAmt = attri2[6];
                                                        obj.ItemName = attri2[7];
                                                        objBLst.objItemBenefit.lstItem.Add(obj);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                if (attri[5] != string.Empty)
                    objBLst.HideCntInsured = Convert.ToInt16(attri[5]);
                if (attri[6] != string.Empty)
                    objBLst.HideTariff = Convert.ToInt16(attri[6]);
            }
            return objBLst;
        }

        public string Feedback_Serialize(Feedback Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(Response.Feedback_Review);
            outPut.Append(split);
            outPut.Append(Response.OrderID);
            outPut.Append(split);
            outPut.Append(Response.Order_Date);
            outPut.Append(split);
            outPut.Append(Response.PatientName);
            outPut.Append(split);
            outPut.Append(Response.Patient_Id);
            outPut.Append(split);
            outPut.Append(Response.Review_Date);
            outPut.Append(split);
            outPut.Append(Response.ServiceEntityName);
            outPut.Append(split);
            outPut.Append(Response.Transaction_Type);
            outPut.Append(split);

            outPut.Append(ListIdentifier_Start);
            foreach (FeedbackQuestion obj in Response.FeedbackQDetails)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.OrderID);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Question_ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Question_SlNo);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Rating);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Tranaction_Type);
                outPut.Append(ListProperty_Split);
                outPut.Append(obj.Question_Detail);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public Feedback Feedback_Deserialize(string Response, string token)
        {
            Feedback objfeed = new Feedback();
            string strResponse = StringCipher.Decrypt(Response, token);
            string[] attri = strResponse.Split(split);
            objfeed.Feedback_Review = attri[0];
            objfeed.OrderID = attri[1];
            objfeed.Order_Date = attri[2];
            objfeed.PatientName = attri[3];
            if (!string.IsNullOrEmpty(attri[4]))
                objfeed.Patient_Id = Convert.ToInt32(attri[4]);
            objfeed.Review_Date = attri[5];
            objfeed.ServiceEntityName = attri[6];
            if (!string.IsNullOrEmpty(attri[7]))
                objfeed.Transaction_Type = Convert.ToInt32(attri[7]);

            if (attri[8] != string.Empty)
            {
                objfeed.FeedbackQDetails = new List<FeedbackQuestion>();
                foreach (string list in attri[8].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                FeedbackQuestion obj = new FeedbackQuestion();
                                obj.OrderID = attri1[0];
                                if (!string.IsNullOrEmpty(attri1[1]))
                                    obj.Question_ID = Convert.ToInt32(attri1[1]);
                                if (!string.IsNullOrEmpty(attri1[2]))
                                    obj.Question_SlNo = Convert.ToInt32(attri1[2]);
                                if (!string.IsNullOrEmpty(attri1[3]))
                                    obj.Rating = Convert.ToInt32(attri1[3]);
                                if (!string.IsNullOrEmpty(attri1[4]))
                                    obj.Tranaction_Type = Convert.ToInt32(attri1[4]);
                                obj.Question_Detail = attri1[5];
                                objfeed.FeedbackQDetails.Add(obj);
                            }
                        }
                    }
                }
            }
            return objfeed;
        }

        public string Feedback_List_Serialize(List<Feedback> objfeedback, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objfeedback != null && objfeedback.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Feedback obj in objfeedback)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.Feedback_Review);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.OrderID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Order_Date);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Patient_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Review_Date);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ServiceEntityName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Transaction_Type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Feedback_Done);
                    strOutPut.Append(ListProperty_Split);

                    if (obj.FeedbackQDetails != null && obj.FeedbackQDetails.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (FeedbackQuestion objlst in obj.FeedbackQDetails)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.OrderID);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Question_ID);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Question_SlNo);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Rating);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Tranaction_Type);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Question_Detail);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.prescription_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PayerOrderID);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Feedback> Feedback_List_Deserialize(string Response, string token)
        {
            List<Feedback> objFeedback = new List<Feedback>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Feedback obj = new Feedback();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri.Length > 0)
                            {
                                obj.Feedback_Review = attri[0];
                                obj.OrderID = attri[1];
                                obj.Order_Date = attri[2];
                                obj.PatientName = attri[3];
                                if (!string.IsNullOrEmpty(attri[4]))
                                    obj.Patient_Id = Convert.ToInt32(attri[4]);
                                obj.Review_Date = attri[5];
                                obj.ServiceEntityName = attri[6];
                                if (!string.IsNullOrEmpty(attri[7]))
                                    obj.Transaction_Type = Convert.ToInt32(attri[7]);
                                if (!string.IsNullOrEmpty(attri[8]))
                                    obj.Feedback_Done = Convert.ToBoolean(attri[8]);

                                if (!string.IsNullOrEmpty(attri[9]))
                                {
                                    obj.FeedbackQDetails = new List<FeedbackQuestion>();
                                    foreach (string list1 in attri[9].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                    {
                                        if (list1 != string.Empty)
                                        {
                                            foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                            {
                                                FeedbackQuestion feedQ = new FeedbackQuestion();
                                                if (innerlist1 != string.Empty)
                                                {
                                                    string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                    if (attri1.Length > 0)
                                                    {
                                                        feedQ.OrderID = attri1[0];
                                                        if (!string.IsNullOrEmpty(attri1[1]))
                                                            feedQ.Question_ID = Convert.ToInt32(attri1[1]);
                                                        if (!string.IsNullOrEmpty(attri1[2]))
                                                            feedQ.Question_SlNo = Convert.ToInt32(attri1[2]);
                                                        if (!string.IsNullOrEmpty(attri1[3]))
                                                            feedQ.Rating = Convert.ToInt32(attri1[3]);
                                                        if (!string.IsNullOrEmpty(attri1[4]))
                                                            feedQ.Tranaction_Type = Convert.ToInt32(attri1[4]);
                                                        feedQ.Question_Detail = attri1[5];
                                                        obj.FeedbackQDetails.Add(feedQ);
                                                    }
                                                }

                                            }
                                        }

                                    }
                                }
                                if (!string.IsNullOrEmpty(attri[10]))
                                    obj.prescription_id = Convert.ToString(attri[10]);
                                if (!string.IsNullOrEmpty(attri[11]))
                                    obj.PayerOrderID = Convert.ToString(attri[11]);
                                objFeedback.Add(obj);
                            }
                        }
                    }
                }
            }

            return objFeedback;
        }

        public string FeedbackQuestion_List_Serialize(List<FeedbackQuestion> objfeedback, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (objfeedback != null && objfeedback.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (FeedbackQuestion objlst in objfeedback)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objlst.OrderID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objlst.Question_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objlst.Question_SlNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objlst.Rating);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objlst.Tranaction_Type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objlst.Question_Detail);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }


        public List<FeedbackQuestion> FeedbackQuestion_List_Deserialize(string Response, string token)
        {
            List<FeedbackQuestion> objFeedback = new List<FeedbackQuestion>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            FeedbackQuestion feedQ = new FeedbackQuestion();
                            string[] attri1 = innerlist.Split(ListProperty_Split);
                            if (attri1.Length > 0)
                            {
                                feedQ.OrderID = attri1[0];
                                if (!string.IsNullOrEmpty(attri1[1]))
                                    feedQ.Question_ID = Convert.ToInt32(attri1[1]);
                                if (!string.IsNullOrEmpty(attri1[2]))
                                    feedQ.Question_SlNo = Convert.ToInt32(attri1[2]);
                                if (!string.IsNullOrEmpty(attri1[3]))
                                    feedQ.Rating = Convert.ToInt32(attri1[3]);
                                if (!string.IsNullOrEmpty(attri1[4]))
                                    feedQ.Tranaction_Type = Convert.ToInt32(attri1[4]);
                                feedQ.Question_Detail = attri1[5];
                                objFeedback.Add(feedQ);
                            }
                        }
                    }
                }
            }

            return objFeedback;
        }



        public string OP_RateUs_Serialize(RateUs ObjRateUs, string token)
        {

            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ObjRateUs.apprate_desc);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.AppRating);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.shareus_desc);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.thoughts_desc);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.recommened_msg);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.recommened_rate);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.patient_id);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.CREATED_BY);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.MODIFIED_BY);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.DEVICEID);
            strOutPut.Append(split);
            strOutPut.Append(ObjRateUs.VISITORSIP);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public RateUs OP_RateUs_DeSerialize(string Response, string token)
        {
            RateUs objRateUs = new RateUs();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objRateUs.apprate_desc = Convert.ToString(values[0]);
            if (values[1] != string.Empty)
                objRateUs.AppRating = Convert.ToString(values[1]);
            if (values[2] != string.Empty)
                objRateUs.shareus_desc = Convert.ToString(values[2]);
            if (values[3] != string.Empty)
                objRateUs.thoughts_desc = Convert.ToString(values[3]);
            if (values[4] != string.Empty)
                objRateUs.recommened_msg = Convert.ToString(values[4]);
            if (values[5] != string.Empty)
                objRateUs.recommened_rate = Convert.ToString(values[5]);
            if (values[6] != string.Empty)
                objRateUs.patient_id = Convert.ToString(values[6]);
            if (values.Length >= 8 && values[7] != string.Empty)
                objRateUs.CREATED_BY = Convert.ToString(values[7]);
            if (values.Length >= 9 && values[8] != string.Empty)
                objRateUs.MODIFIED_BY = Convert.ToString(values[8]);
            if (values.Length >= 10 && values[9] != string.Empty)
                objRateUs.DEVICEID = Convert.ToString(values[9]);
            if (values.Length >= 11 && values[10] != string.Empty)
                objRateUs.VISITORSIP = Convert.ToString(values[10]);
            return objRateUs;
        }

        public string GetShippingAddress_Serialize(List<ShippingAddress> objRes, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (ShippingAddress objS in objRes)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objS.AddressId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.AddressTitle);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.Street1);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.Street2);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.City);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.State);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.MobileNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.CityID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.StateID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.PinCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.consumer_name);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<ShippingAddress> GetShippingAddress_Deserialize(string Response, string Token)
        {
            List<ShippingAddress> objapp = new List<ShippingAddress>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            ShippingAddress obj = new ShippingAddress();
                            obj.AddressId = attri[0];
                            obj.AddressTitle = attri[1];
                            obj.Street1 = attri[2];
                            obj.Street2 = attri[3];
                            obj.City = attri[4];
                            obj.State = attri[5];
                            obj.MobileNo = attri[6];
                            obj.CityID = attri[7];
                            obj.StateID = attri[8];
                            obj.PinCode = attri[9];
                            obj.consumer_name = attri[10];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetFeedbackControls_Serialize(List<feedback_controls> objRes, string token)
        {
            StringBuilder strOutPut = new StringBuilder();

            strOutPut.Append(objRes[0].feedbackfinal_rating.Feedback_rating);
            strOutPut.Append(split);
            strOutPut.Append(objRes[0].feedbackfinal_rating.fb_samplePickup);
            strOutPut.Append(split);
            strOutPut.Append(objRes[0].feedbackfinal_rating.fb_usabilityapp);
            strOutPut.Append(split);
            strOutPut.Append(objRes[0].feedbackfinal_rating.fb_orderprocess);
            strOutPut.Append(split);
            strOutPut.Append(objRes[0].feedbackfinal_rating.fb_reportdelivery);
            strOutPut.Append(split);
            strOutPut.Append(objRes[0].feedbackfinal_rating.fb_customersupport);
            strOutPut.Append(split);
            strOutPut.Append(objRes[0].feedbackfinal_rating.fb_others);
            strOutPut.Append(split);
            strOutPut.Append(objRes[0].feedbackfinal_rating.Feedback_remarks);
            strOutPut.Append(split);

            strOutPut.Append(ListIdentifier_Start);
            foreach (feedback_controls objS in objRes)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objS.control_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.control_text);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.control_typ);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.service_type);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.service_name);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.display_order);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.transaction_type);

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.control_style);

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.control_text_value);

                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }


        public List<feedback_controls> GetFeedbackControls_DeSerialize(string Response, string Token)
        {
            List<feedback_controls> objapp = new List<feedback_controls>();

            feedbackSercie objFS = new feedbackSercie();
            string strResposne = StringCipher.Decrypt(Response, Token);

            string[] attri = strResposne.Split(split);
            if (!string.IsNullOrEmpty(attri[0]))
                objFS.Feedback_rating = attri[0];
            if (!string.IsNullOrEmpty(attri[1]))
                objFS.fb_samplePickup = Convert.ToInt32(attri[1]);
            if (!string.IsNullOrEmpty(attri[2]))
                objFS.fb_usabilityapp = Convert.ToInt32(attri[2]);
            if (!string.IsNullOrEmpty(attri[3]))
                objFS.fb_orderprocess = Convert.ToInt32(attri[3]);
            if (!string.IsNullOrEmpty(attri[4]))
                objFS.fb_reportdelivery = Convert.ToInt32(attri[4]);
            if (!string.IsNullOrEmpty(attri[5]))
                objFS.fb_customersupport = Convert.ToInt32(attri[5]);
            if (!string.IsNullOrEmpty(attri[6]))
                objFS.fb_others = Convert.ToInt32(attri[6]);
            if (!string.IsNullOrEmpty(attri[7]))
                objFS.Feedback_remarks = Convert.ToString(attri[7]);



            if (attri[8] != string.Empty)
            {

                foreach (string list in attri[8].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri1 = innerlist.Split(ListProperty_Split);
                                feedback_controls obj = new feedback_controls();
                                obj.control_id = Convert.ToInt32(attri1[0]);
                                obj.control_text = attri1[1];
                                obj.control_typ = attri1[2];
                                obj.service_type = attri1[3];
                                obj.service_name = attri1[4];
                                obj.display_order = attri1[5];
                                obj.transaction_type = attri1[6];

                                obj.control_style = attri1[7];
                                obj.control_text_value = attri1[8];

                                objapp.Add(obj);
                            }
                        }
                    }
                }
            }

            objapp[0].feedbackfinal_rating = objFS;

            return objapp;
        }

        public string GetFamilyDetails_Pat_Serialize(List<EcardDetails> objEcardDretails, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (EcardDetails objEcard in objEcardDretails)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objEcard.CompanyName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.EmployeeId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.ValidTo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.PatientId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.PrimaryPatientId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.PatientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.Age);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.CardNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.ValidFrom);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.Gender);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.MobileNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.MemeberId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.RelationShipName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.PolicyNumber);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objEcard.Status);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<EcardDetails> GetFamilyDetails_Pat_Deserialize(string Response, string token)
        {

            List<EcardDetails> objEcardList = null;
            if (Response != string.Empty)
            {
                string strResposne = StringCipher.Decrypt(Response, token);
                foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        objEcardList = new List<EcardDetails>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                EcardDetails objEcard = new EcardDetails();
                                string[] values = innerlist.Split(ListProperty_Split);
                                objEcard.CompanyName = values[0];
                                objEcard.EmployeeId = values[1];
                                objEcard.ValidTo = values[2];
                                objEcard.PatientId = values[3];
                                objEcard.PrimaryPatientId = values[4];
                                objEcard.PatientName = values[5];
                                objEcard.Age = values[6];
                                objEcard.CardNo = values[7];
                                objEcard.ValidFrom = values[8];
                                objEcard.Gender = values[9];
                                objEcard.MobileNo = values[10];
                                objEcard.MemeberId = values[11];
                                objEcard.RelationShipName = values[12];
                                objEcard.PolicyNumber = values[13];
                                objEcard.Status = Convert.ToInt32(values[14]);
                                objEcardList.Add(objEcard);
                            }

                        }
                    }
                }
            }
            else
            {
                throw new Exception(GentricMsg);
            }
            return objEcardList;
        }

        public string OP_Menu_Search_Serialize(List<OP_Menu_Search> objMenu, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (OP_Menu_Search obj in objMenu)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(obj.DISPLAY_ORDER);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.DISPLAY_TEXT);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.IMAGE_NAME);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.IS_DISPLAY);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.TRANSACTION_TYPE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.TYPE_ID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.VALUE_ID);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<OP_Menu_Search> OP_Menu_Search_Deserialize(string Response, string token)
        {

            List<OP_Menu_Search> obj = null;
            string strResposne = StringCipher.Decrypt(Response, token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    obj = new List<OP_Menu_Search>();
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            OP_Menu_Search obj1 = new OP_Menu_Search();
                            string[] values = innerlist.Split(ListProperty_Split);
                            if (!string.IsNullOrWhiteSpace(values[0]))
                                obj1.DISPLAY_ORDER = Convert.ToInt32(values[0]);
                            obj1.DISPLAY_TEXT = values[1];
                            obj1.IMAGE_NAME = values[2];
                            if (!string.IsNullOrWhiteSpace(values[3]))
                                obj1.IS_DISPLAY = Convert.ToInt32(values[3]);
                            if (!string.IsNullOrWhiteSpace(values[4]))
                                obj1.TRANSACTION_TYPE = Convert.ToInt32(values[4]);
                            if (!string.IsNullOrWhiteSpace(values[5]))
                                obj1.TYPE_ID = Convert.ToInt32(values[5]);
                            if (!string.IsNullOrWhiteSpace(values[6]))
                                obj1.VALUE_ID = Convert.ToInt32(values[6]);
                            obj.Add(obj1);
                        }

                    }
                }
            }
            return obj;
        }

        public string GetTransactionList_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ChatDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.pharmacyId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.physician_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.PrescriptionType);
                strOutPut.Append(ListProperty_Split);
                //consultation
                if (PreClass.Consultation != null)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    //strOutPut.Append(Inner_ListElement_Start);
                    strOutPut.Append(PreClass.Consultation.Speciality);
                    //strOutPut.Append(Inner_ListElement_End);
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);
                if (PreClass.DiagnosticDetail != null)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    //strOutPut.Append(Inner_ListElement_Start);
                    strOutPut.Append(PreClass.DiagnosticDetail.DiagnosticName);
                    //strOutPut.Append(Inner_ListElement_End);
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListProperty_Split);
                if (PreClass.pharmacyDetail != null)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    //strOutPut.Append(Inner_ListElement_Start);
                    strOutPut.Append(PreClass.pharmacyDetail.PharmacyName);
                    //strOutPut.Append(Inner_ListElement_End);
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.Is_health_check);
                strOutPut.Append(ListProperty_Split);
                if (PreClass.Orderdetails != null && PreClass.Orderdetails.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Oderdetails objorder in PreClass.Orderdetails)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objorder.order_id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objorder.orderdate);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objorder.OrderStatus);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objorder.PayerOrderId);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objorder.OrderStatusID);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.IsView);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.OrderByModifiedDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.Ispharmacyordered);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.IsOfflinePrescription);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.PRESC_CONSULTATION_FILENAME);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.Action_status);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.Action_status_Id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.consultInvoiceFileName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.Aggregator_type);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.intAppointmentId);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetTransactionList_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] attri = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = attri[0];
                                    objPres.ChatDate = attri[1];
                                    objPres.physicianName = attri[2];
                                    objPres.patientName = attri[3];
                                    objPres.prescriptionDate = attri[4];
                                    objPres.patient_id = attri[5];
                                    objPres.pharmacyId = attri[6];
                                    objPres.physician_id = attri[7];
                                    if (attri[8] != string.Empty)
                                        objPres.PrescriptionType = Convert.ToInt16(attri[8]);
                                    if (!string.IsNullOrEmpty(attri[9]))
                                    {
                                        foreach (string list1 in attri[9].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                //foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    // if (innerlist1 != string.Empty)
                                                    {
                                                        Consultation obj = new Consultation();
                                                        string[] values1 = list1.Split(Inner_ListProperty_Split);
                                                        obj.Speciality = values1[0];
                                                        objPres.Consultation = obj;
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(attri[10]))
                                    {
                                        foreach (string list1 in attri[10].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                //foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    //if (innerlist1 != string.Empty)
                                                    {
                                                        objPres.DiagnosticDetail = new Diagnostic();
                                                        string[] values1 = list1.Split(Inner_ListProperty_Split);
                                                        objPres.DiagnosticDetail.DiagnosticName = values1[0];
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(attri[11]))
                                    {
                                        foreach (string list1 in attri[11].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                //foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    //if (innerlist1 != string.Empty)
                                                    {
                                                        objPres.pharmacyDetail = new MOBILE_COMMON.Pharmacy();
                                                        string[] values1 = list1.Split(Inner_ListProperty_Split);
                                                        objPres.pharmacyDetail.PharmacyName = values1[0];
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    if (attri[12] != string.Empty)
                                        objPres.Is_health_check = Convert.ToInt16(attri[12]);
                                    if (attri[13] != null && attri[13] != string.Empty)
                                    {

                                        #region Oderdetails List
                                        objPres.Orderdetails = new List<Oderdetails>();
                                        foreach (string list1 in attri[13].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (innerlist1 != string.Empty)
                                                    {
                                                        string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                        Oderdetails ObjOrder = new Oderdetails();
                                                        if (attri1.Length > 0)
                                                        {
                                                            ObjOrder.order_id = attri1[0];
                                                            ObjOrder.orderdate = attri1[1];
                                                            ObjOrder.OrderStatus = attri1[2];
                                                            ObjOrder.PayerOrderId = attri1[3];
                                                            ObjOrder.OrderStatusID = attri1[4];
                                                            objPres.Orderdetails.Add(ObjOrder);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        #endregion Oderdetails List
                                    }
                                    if (attri[14] != string.Empty)
                                        objPres.IsView = Convert.ToBoolean(attri[14]);
                                    if (attri[15].Length > 15 && attri[15] != string.Empty)
                                        objPres.OrderByModifiedDate = Convert.ToDateTime(attri[15], culture);
                                    if (attri.Count() > 16 && attri[16] != string.Empty)
                                        objPres.Ispharmacyordered = Convert.ToBoolean(attri[16]);
                                    if (attri.Count() > 17 && attri[17] != string.Empty)
                                        objPres.IsOfflinePrescription = Convert.ToInt32(attri[17]);
                                    if (attri.Count() > 18 && attri[18] != string.Empty)
                                        objPres.PRESC_CONSULTATION_FILENAME = Convert.ToString(attri[18]);
                                    if (attri.Count() > 19 && attri[19] != string.Empty)
                                        objPres.Action_status = Convert.ToString(attri[19]);
                                    if (attri.Count() > 20 && attri[20] != string.Empty)
                                        objPres.Action_status_Id = Convert.ToString(attri[20]);
                                    if (attri.Count() > 21 && attri[21] != string.Empty)
                                        objPres.consultInvoiceFileName = Convert.ToString(attri[21]);
                                    if (attri.Count() > 22 && attri[22] != string.Empty)
                                        objPres.Aggregator_type = Convert.ToInt32(attri[22]);
                                    if (attri.Count() > 23 && attri[23] != string.Empty)
                                        objPres.intAppointmentId = Convert.ToString(attri[23]);
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetPhysicianSplSearchMenu_Com_Serialize(Physician_SearchMenu Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response.SpecialityMenu_lst != null && Response.SpecialityMenu_lst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (OP_Menu_Search obj in Response.SpecialityMenu_lst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IMAGE_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_DISPLAY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TRANSACTION_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TYPE_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.VALUE_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ALT_IMAGE_NAME);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);
            if (Response.Physician_lst != null && Response.Physician_lst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Physician obj in Response.Physician_lst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.PhysicianID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.UserName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ClinicAddress);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.EntityCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Experience);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Qualification);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Speciality);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.SpecialityID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Integration_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Integration_Code);
                    if (obj.Geolocation != null)
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_DISTANCE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LATITUDE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LONGITUDE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.CITY_ID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.CITY);
                    }
                    else
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.EntityId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ClinicName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Distance);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.MobileNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PROFILE_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.RegistrationNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ConsultFee);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.soryby_fee);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ENTITY_MOBILENO);
                    strOutPut.Append(ListElement_End);

                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public Physician_SearchMenu GetPhysicianSplSearchMenu_Com_Deserialize(string Response, string token)
        {
            Physician_SearchMenu _searchMenu = new Physician_SearchMenu();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                List<OP_Menu_Search> obj = null;
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<OP_Menu_Search>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                OP_Menu_Search obj1 = new OP_Menu_Search();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(values[0]);
                                obj1.DISPLAY_TEXT = values[1];
                                obj1.IMAGE_NAME = values[2];
                                if (!string.IsNullOrWhiteSpace(values[3]))
                                    obj1.IS_DISPLAY = Convert.ToInt32(values[3]);
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.TRANSACTION_TYPE = Convert.ToInt32(values[4]);
                                if (!string.IsNullOrWhiteSpace(values[5]))
                                    obj1.TYPE_ID = Convert.ToInt32(values[5]);
                                if (!string.IsNullOrWhiteSpace(values[6]))
                                    obj1.VALUE_ID = Convert.ToInt32(values[6]);
                                obj1.ALT_IMAGE_NAME = values[7];
                                obj.Add(obj1);
                            }

                        }
                    }
                }
                _searchMenu.SpecialityMenu_lst = obj;
            }

            if (values1[1] != string.Empty)
            {
                List<Physician> obj = null;
                foreach (string list in values1[1].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<Physician>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Physician obj1 = new Physician();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.PhysicianID = Convert.ToInt32(values[0]);
                                obj1.UserName = values[1];
                                obj1.ClinicAddress = values[2];
                                obj1.EntityCode = values[3];
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.Experience = Convert.ToInt32(values[4]);
                                obj1.Qualification = values[5];
                                obj1.Speciality = values[6];
                                if (!string.IsNullOrWhiteSpace(values[7]))
                                    obj1.SpecialityID = Convert.ToInt32(values[7]);
                                if (!string.IsNullOrWhiteSpace(values[8]))
                                    obj1.Integration_Id = Convert.ToInt32(values[8]);
                                obj1.Integration_Code = values[9];
                                obj1.Geolocation = new GeoLocation();
                                if (values.Length > 10)
                                {
                                    if (!string.IsNullOrWhiteSpace(values[10]))
                                        obj1.Geolocation.GEO_DISTANCE = Convert.ToDouble(values[10]);
                                    if (!string.IsNullOrWhiteSpace(values[11]))
                                        obj1.Geolocation.GEO_LATITUDE = Convert.ToDouble(values[11]);
                                    if (!string.IsNullOrWhiteSpace(values[12]))
                                        obj1.Geolocation.GEO_LONGITUDE = Convert.ToDouble(values[12]);
                                    if (!string.IsNullOrWhiteSpace(values[13]))
                                        obj1.Geolocation.CITY_ID = Convert.ToInt16(values[13]);
                                    obj1.Geolocation.CITY = values[14];
                                }
                                if (!string.IsNullOrWhiteSpace(values[15]))
                                    obj1.EntityId = Convert.ToInt32(values[15]);
                                if (!string.IsNullOrWhiteSpace(values[16]))
                                    obj1.ClinicName = values[16];
                                if (!string.IsNullOrWhiteSpace(values[17]))
                                    obj1.Distance = values[17];
                                if (!string.IsNullOrWhiteSpace(values[18]))
                                    obj1.MobileNo = values[18];
                                if (!string.IsNullOrWhiteSpace(values[19]))
                                    obj1.PROFILE_CODE = values[19];
                                if (!string.IsNullOrWhiteSpace(values[20]))
                                    obj1.RegistrationNo = values[20];
                                if (!string.IsNullOrWhiteSpace(values[21]))
                                    obj1.ConsultFee = Convert.ToDecimal(values[21]);
                                if (!string.IsNullOrWhiteSpace(values[22]))
                                    obj1.soryby_fee = Convert.ToDecimal(values[22]);
                                if (!string.IsNullOrWhiteSpace(values[23]))
                                    obj1.ENTITY_MOBILENO = Convert.ToString(values[23]);
                                obj.Add(obj1);
                            }

                        }
                    }
                }
                _searchMenu.Physician_lst = obj;
            }

            return _searchMenu;
        }

        public string GetPrescriptionList_Pat_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.MemberID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.MobileNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.ailmentid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.IsOfflinePrescription);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.PrecFileName);
                strOutPut.Append(ListElement_End);
                //consultation
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetPrescriptionList_Pat_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in values)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] attri = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = attri[0];
                                    objPres.prescriptionDate = attri[1];
                                    objPres.patientName = attri[2];
                                    objPres.MemberID = attri[3];
                                    objPres.MobileNo = attri[4];
                                    objPres.patient_id = attri[5];
                                    objPres.ailmentid = attri[6];
                                    if (attri.Count() > 7 && !string.IsNullOrWhiteSpace(attri[7]))
                                        objPres.IsOfflinePrescription = Convert.ToInt32(attri[7]);
                                    objPres.PrecFileName = attri[8];
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetDiagTestAvailableCenters_Serialize(DiagTestSearch Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response.diagnosisLst != null && Response.diagnosisLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis obj in Response.diagnosisLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DiagnosisCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DiagnosisID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DiagnosisName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Visit_Type);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);
            if (Response.EntityProvidedTest != null && Response.EntityProvidedTest.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis obj in Response.EntityProvidedTest)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.Visit_Type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DiagnosisCode);
                    if (obj.DiagnosticDetails.ENTITYCODE != null)
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DiagnosticDetails.ENTITYCODE);
                    }

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);
            if (Response.diagnosticLst != null && Response.diagnosticLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnostic obj in Response.diagnosticLst)
                {


                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DiagnosticID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DiagnosticName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.EntityCode);
                    if (obj.Geolocation != null)
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_DISTANCE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LATITUDE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LONGITUDE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.LOC_ADDRESS);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.LOC_NAME);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.CITY);
                    }
                    else
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                    }

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.mobileno);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.address);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.location);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.city_name);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Entity_ContactNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AGGREGATOR_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ServiceCharge);

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public DiagTestSearch GetDiagTestAvailableCenters_Deserialize(string Response, string token)
        {
            DiagTestSearch _search = new DiagTestSearch();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                List<Diagnosis> obj = null;
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<Diagnosis>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Diagnosis obj1 = new Diagnosis();
                                string[] values = innerlist.Split(ListProperty_Split);
                                obj1.DiagnosisCode = values[0];
                                if (!string.IsNullOrWhiteSpace(values[1]))
                                    obj1.DiagnosisID = Convert.ToInt32(values[1]);
                                obj1.DiagnosisName = values[2];
                                obj1.Visit_Type = values[3];
                                obj.Add(obj1);
                            }

                        }
                    }
                }
                _search.diagnosisLst = new List<Diagnosis>();
                _search.diagnosisLst = obj;
            }

            if (values1[1] != string.Empty)
            {
                List<Diagnosis> obj = null;
                foreach (string list in values1[1].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<Diagnosis>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Diagnosis obj1 = new Diagnosis();
                                string[] values = innerlist.Split(ListProperty_Split);
                                obj1.Visit_Type = values[0];
                                obj1.DiagnosisCode = values[1];
                                obj1.DiagnosticDetails = new DiagnosticDetails();
                                obj1.DiagnosticDetails.ENTITYCODE = values[2];
                                obj.Add(obj1);
                            }

                        }
                    }
                }
                _search.EntityProvidedTest = new List<Diagnosis>();
                _search.EntityProvidedTest = obj;
            }

            if (values1[2] != string.Empty)
            {
                List<Diagnostic> obj = null;
                foreach (string list in values1[2].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<Diagnostic>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Diagnostic obj1 = new Diagnostic();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.DiagnosticID = Convert.ToInt32(values[0]);
                                obj1.DiagnosticName = values[1];
                                obj1.EntityCode = values[2];

                                obj1.Geolocation = new GeoLocation();
                                if (values.Length > 3)
                                {
                                    if (!string.IsNullOrWhiteSpace(values[3]))
                                        obj1.Geolocation.GEO_DISTANCE = Convert.ToDouble(values[3]);
                                    if (!string.IsNullOrWhiteSpace(values[4]))
                                        obj1.Geolocation.GEO_LATITUDE = Convert.ToDouble(values[4]);
                                    if (!string.IsNullOrWhiteSpace(values[5]))
                                        obj1.Geolocation.GEO_LONGITUDE = Convert.ToDouble(values[5]);
                                    obj1.Geolocation.LOC_ADDRESS = values[6];
                                    obj1.Geolocation.LOC_NAME = values[7];
                                    if (!string.IsNullOrWhiteSpace(values[8]))
                                        obj1.Geolocation.CITY = values[8];
                                }
                                if (!string.IsNullOrWhiteSpace(values[9]))
                                    obj1.mobileno = Convert.ToString(values[9]);

                                obj1.address = values[10];
                                obj1.location = values[11];
                                obj1.city_name = values[12];

                                if (!string.IsNullOrWhiteSpace(values[13]))
                                    obj1.Entity_ContactNo = Convert.ToString(values[13]);

                                if (!string.IsNullOrWhiteSpace(values[14]))
                                    obj1.AGGREGATOR_TYPE = Convert.ToString(values[14]);
                                
                                if (!string.IsNullOrWhiteSpace(values[15]))
                                    obj1.ServiceCharge = Convert.ToDecimal(Convert.ToString(values[15]));

                                obj.Add(obj1);
                            }
                        }
                    }
                }
                _search.diagnosticLst = new List<Diagnostic>();
                _search.diagnosticLst = obj;
            }

            return _search;
        }

        public string GetPharmacyAvailableCenters_Serialize(List<Pharmacy> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Pharmacy obj in Response)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(obj.EntityCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.PharmacyID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.PharmacyName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.PharmacyType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.EntityKey);
                if (obj.Geolocation != null)
                {
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.GEO_DISTANCE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.GEO_LATITUDE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.GEO_LONGITUDE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.LOC_ADDRESS);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.LOC_NAME);
                }
                else
                {
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                }

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.mobileno);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.address);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.location);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.city);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Discount);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Entity_ContactNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.aggregator_type);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.onlineOrderFlow);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Pharmacy> GetPharmacyAvailableCenters_Deserialize(string Response, string token)
        {
            List<Pharmacy> obj = new List<Pharmacy>();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);

            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<Pharmacy>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Pharmacy obj1 = new Pharmacy();
                                string[] values = innerlist.Split(ListProperty_Split);
                                obj1.EntityCode = values[0];
                                if (!string.IsNullOrWhiteSpace(values[1]))
                                    obj1.PharmacyID = Convert.ToInt32(values[1]);
                                obj1.PharmacyName = values[2];
                                if (!string.IsNullOrWhiteSpace(values[3]))
                                    obj1.PharmacyType = Convert.ToInt32(values[3]);
                                obj1.EntityKey = values[4];
                                obj1.Geolocation = new GeoLocation();
                                if (values.Length > 5)
                                {
                                    if (!string.IsNullOrWhiteSpace(values[5]))
                                        obj1.Geolocation.GEO_DISTANCE = Convert.ToDouble(values[5]);
                                    if (!string.IsNullOrWhiteSpace(values[6]))
                                        obj1.Geolocation.GEO_LATITUDE = Convert.ToDouble(values[6]);
                                    if (!string.IsNullOrWhiteSpace(values[7]))
                                        obj1.Geolocation.GEO_LONGITUDE = Convert.ToDouble(values[7]);
                                    obj1.Geolocation.LOC_ADDRESS = values[8];
                                    obj1.Geolocation.LOC_NAME = values[9];
                                }
                                if (!string.IsNullOrWhiteSpace(values[10]))
                                    obj1.mobileno = Convert.ToString(values[10]);

                                obj1.address = values[11];
                                obj1.location = values[12];
                                obj1.city = values[13];
                                if (!string.IsNullOrWhiteSpace(values[14]))
                                    obj1.Discount = Convert.ToDecimal(values[14]);
                                if (!string.IsNullOrWhiteSpace(values[15]))
                                    obj1.Entity_ContactNo = Convert.ToString(values[15]);
                                if (!string.IsNullOrWhiteSpace(values[16]))
                                    obj1.aggregator_type = Convert.ToInt32(values[16]);
                                if (!string.IsNullOrWhiteSpace(values[17]))
                                    obj1.onlineOrderFlow = Convert.ToInt32(values[17]);
                                obj.Add(obj1);
                            }

                        }
                    }
                }
            }

            return obj;
        }
        public string GetOrderdetails_Serialize(List<Oderdetails> lstOdr, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (lstOdr != null && lstOdr.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Oderdetails objPre in lstOdr)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objPre.order_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.OrderStatus);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.orderdate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.PayerOrderId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.pharmacyname);
                    strOutPut.Append(ListProperty_Split);
                    if (objPre.lstOrderItem != null && objPre.lstOrderItem.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (OrderItemDetails objlst in objPre.lstOrderItem)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.order_id);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.drug_name);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.mg_ml);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.quntity);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.drug_type);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.mrp);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.discount);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.offer_price);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Status);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.drugcode);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Mobile_no);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Rate);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.PLACE_ORDER_MULTIPLE);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.EntityCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.OrderStatusID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.ConsignmentNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.DeliveryPartner);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.DeliveryNote);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.PayerRemarks);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.InvoiceNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.CS_Number);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.Aggregator_Type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.pharmacyType);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.isOnlineFlow);
                    strOutPut.Append(ListProperty_Split);
                    
                    if (objPre.lstPaymentDet != null && objPre.lstPaymentDet.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (PaymentDetails objlst in objPre.lstPaymentDet)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.Order_Id);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Ext_Payment_Link);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Ext_Payment_Status);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Payment_Amount);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Payment_Date);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Payment_Id);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Payment_Type);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Transaction_type);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.OTP_VALUE);                   
                    strOutPut.Append(ListElement_End);
                    
                }
                strOutPut.Append(ListIdentifier_End);
            }

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Oderdetails> GetOrderdetails_Deserialize(string Response, string Token)
        {
            List<Oderdetails> lstPre = new List<Oderdetails>();
            string strResponse = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Oderdetails objPre = new Oderdetails();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            objPre.order_id = attri[0];
                            objPre.OrderStatus = attri[1];
                            objPre.orderdate = attri[2];
                            objPre.PayerOrderId = attri[3];
                            objPre.pharmacyname = attri[4];

                            if (!string.IsNullOrEmpty(attri[5]))
                            {
                                objPre.lstOrderItem = new List<OrderItemDetails>();
                                foreach (string list1 in attri[5].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                OrderItemDetails objlst = new OrderItemDetails();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objlst.order_id = attri1[0];
                                                objlst.drug_name = attri1[1];
                                                objlst.mg_ml = attri1[2];
                                                objlst.quntity = attri1[3];
                                                objlst.drug_type = attri1[4];
                                                objlst.mrp = attri1[5];
                                                objlst.discount = attri1[6];
                                                objlst.offer_price = attri1[7];
                                                objlst.Status = attri1[8];
                                                objlst.drugcode = attri1[9];
                                                objlst.Mobile_no = attri1[10];
                                                objlst.Rate = attri1[11];
                                                if (attri1.Count() > 12)
                                                {
                                                    if (!string.IsNullOrEmpty(attri1[12]))
                                                        objlst.PLACE_ORDER_MULTIPLE = Convert.ToInt32(attri1[12]);
                                                }
                                                objPre.lstOrderItem.Add(objlst);
                                            }
                                        }

                                    }
                                }
                            }
                            objPre.EntityCode = attri[6];
                            objPre.OrderStatusID = attri[7];
                            objPre.ConsignmentNo = attri[8];
                            objPre.DeliveryPartner = attri[9];
                            objPre.DeliveryNote = attri[10];
                            objPre.PayerRemarks = attri[11];
                            objPre.InvoiceNo = attri[12];
                            objPre.CS_Number = attri[13];
                            objPre.Aggregator_Type = attri[14];
                            objPre.pharmacyType = attri[15];
                            objPre.isOnlineFlow = attri[16];

                            if (!string.IsNullOrEmpty(attri[17]))
                            {
                                objPre.lstPaymentDet = new List<PaymentDetails>();
                                foreach (string list1 in attri[17].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                PaymentDetails objlst = new PaymentDetails();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objlst.Order_Id = attri1[0];
                                                objlst.Ext_Payment_Link = attri1[1];
                                                objlst.Ext_Payment_Status = attri1[2];
                                                objlst.Payment_Amount = attri1[3];
                                                objlst.Payment_Date = attri1[4];
                                                objlst.Payment_Id = attri1[5];
                                                objlst.Payment_Type = attri1[6];
                                                objlst.Transaction_type = attri1[7];
                                                objPre.lstPaymentDet.Add(objlst);
                                            }
                                        }

                                    }
                                }
                            }
                            objPre.OTP_VALUE = attri[18];






                            lstPre.Add(objPre);
                        }

                    }
                }
            }

            return lstPre;
        }
        public string GetPolicyCoverGroupItems_Serialize(GetPolicyCoverGroupItems Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response.ITEMNAME != null && Response.ITEMNAME.Count() > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (string itemname in Response.ITEMNAME)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(itemname);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public GetPolicyCoverGroupItems GetPolicyCoverGroupItems_Deserialize(string Response, string token)
        {
            GetPolicyCoverGroupItems objGetPolicyCoverGroupItems = new GetPolicyCoverGroupItems();

            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                List<string> items = new List<string>();
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                items.Add(innerlist);
                            }

                        }
                    }
                }
                objGetPolicyCoverGroupItems.ITEMNAME = items;
            }
            return objGetPolicyCoverGroupItems;
        }


        public string GetPolicyType_Serialize(GetPolicyType Response, string token)
        {
            StringBuilder outPut = new StringBuilder();


            if (Response != null)
            {
                outPut.Append(Response.PolicyType);

                outPut.Append(split);

                outPut.Append(Response.MemberNo);

                outPut.Append(split);
            }
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public GetPolicyType GetPolicyType_Deserialize(string Response, string token)
        {
            GetPolicyType objGetPolicyType = null;

            if (Response != null)
            {
                PolicyCover objPolyCov = new PolicyCover();
                string strResponse = StringCipher.Decrypt(Response, token);
                string[] attri = strResponse.Split(split);
                if (attri != null && attri.Count() > 0)
                {
                    objGetPolicyType = new GetPolicyType();
                    objGetPolicyType.PolicyType = attri[0];
                    objGetPolicyType.MemberNo = attri[1];
                }
            }


            return objGetPolicyType;
        }

        public string GetProductPolicyHealthCheckup_Serialize(List<HealthCheckup> Response, string token)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(ListIdentifier_Start);
            foreach (HealthCheckup healthCheckup in Response)
            {
                stringBuilder.Append(ListElement_Start);
                stringBuilder.Append(healthCheckup.HCCode);
                stringBuilder.Append(ListProperty_Split);
                stringBuilder.Append(healthCheckup.HCName);
                stringBuilder.Append(ListProperty_Split);
                if (healthCheckup.lstDiagTest != null && healthCheckup.lstDiagTest.Count > 0)
                {
                    stringBuilder.Append(Inner_ListIdentifier_Start);
                    foreach (Diagnosis diagnosis in healthCheckup.lstDiagTest)
                    {
                        stringBuilder.Append(Inner_ListElement_Start);
                        stringBuilder.Append(diagnosis.DiagnosisName);
                        stringBuilder.Append(Inner_ListProperty_Split);
                        stringBuilder.Append(diagnosis.DiagnosisID);
                        stringBuilder.Append(Inner_ListProperty_Split);
                        stringBuilder.Append(diagnosis.HC_CODE);
                        stringBuilder.Append(Inner_ListElement_End);
                    }
                    stringBuilder.Append(Inner_ListIdentifier_End);
                }
                else
                    stringBuilder.Append("");
                stringBuilder.Append(ListElement_End);
            }
            stringBuilder.Append(ListIdentifier_End);
            return StringCipher.Encrypt(stringBuilder.ToString(), token);
        }

        public List<HealthCheckup> GetProductPolicyHealthCheckup_Deserialize(string Response, string token)
        {
            List<HealthCheckup> healthCheckupList = new List<HealthCheckup>();
            List<Diagnosis> diagnosisList = new List<Diagnosis>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            HealthCheckup healthCheckup = new HealthCheckup();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            healthCheckup.HCCode = attri[0];
                            healthCheckup.HCName = attri[1];

                            if (!string.IsNullOrEmpty(attri[2]))
                            {
                                healthCheckup.lstDiagTest = new List<Diagnosis>();

                                foreach (string list1 in attri[2].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        diagnosisList = new List<Diagnosis>();
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Diagnosis diagnosis = new Diagnosis();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                diagnosis.DiagnosisName = attri1[0];
                                                if (attri1[1] != string.Empty)
                                                    diagnosis.DiagnosisID = Convert.ToInt32(attri1[1]);
                                                diagnosis.HC_CODE = attri1[2];
                                                diagnosisList.Add(diagnosis);
                                            }
                                        }

                                    }

                                }
                                healthCheckup.lstDiagTest = diagnosisList;
                            }
                            healthCheckupList.Add(healthCheckup);
                        }

                    }
                }
            }
            return healthCheckupList;
        }


        public string GetHCAvailableCenters_Serialize(List<Diagnostic> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Diagnostic obj in Response)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(obj.DiagnosticID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.DiagnosticName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.EntityCode);
                if (obj.Geolocation != null)
                {
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.GEO_DISTANCE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.GEO_LATITUDE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.GEO_LONGITUDE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.LOC_ADDRESS);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Geolocation.LOC_NAME);
                }
                else
                {
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(string.Empty);
                }

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.mobileno);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.location);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.city_name);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Entity_ContactNo);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Diagnostic> GetHCAvailableCenters_Deserialize(string Response, string token)
        {
            List<Diagnostic> objList = new List<Diagnostic>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Diagnostic obj = new Diagnostic();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                obj.DiagnosticID = Convert.ToInt32(attri[0]);

                            obj.DiagnosticName = attri[1];
                            obj.EntityCode = attri[2];

                            obj.Geolocation = new GeoLocation();
                            if (attri.Length > 3)
                            {
                                if (!string.IsNullOrWhiteSpace(attri[3]))
                                    obj.Geolocation.GEO_DISTANCE = Convert.ToDouble(attri[3]);
                                if (!string.IsNullOrWhiteSpace(attri[4]))
                                    obj.Geolocation.GEO_LATITUDE = Convert.ToDouble(attri[4]);
                                if (!string.IsNullOrWhiteSpace(attri[5]))
                                    obj.Geolocation.GEO_LONGITUDE = Convert.ToDouble(attri[5]);
                                obj.Geolocation.LOC_ADDRESS = attri[6];
                                obj.Geolocation.LOC_NAME = attri[7];
                            }
                            if (!string.IsNullOrWhiteSpace(attri[8]))
                                obj.mobileno = Convert.ToString(attri[8]);

                            obj.location = attri[9];
                            obj.city_name = attri[10];
                            if (!string.IsNullOrWhiteSpace(attri[11]))
                                obj.Entity_ContactNo = Convert.ToString(attri[11]);
                            objList.Add(obj);
                        }

                    }
                }
            }
            return objList;
        }

        public string GetAppointmentDashbroad_Pat_Serialize(List<Appointment> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (Appointment objApp in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objApp.AppointmentID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.AppointmentDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.CAN_CANCEL);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.MemberID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PhysicianId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PhysicianName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.ServiceType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.ServiceTypeDesc);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SlotTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SpecialityDec);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Status);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Status_Desc);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Integration_Appointment_Id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.OrderByAppDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Integration_Id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Intergration_code);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PractoAcessToken);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientMobileNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientEmailID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.MODIFIED_BY);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.VISITORIP);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.DEVICEID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.APPOINTMENT_BY_ADMIN);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Appointment> GetAppointmentDashbroad_Pat_Deserialize(string Response, string Token)
        {
            List<Appointment> objapp = new List<Appointment>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Appointment obj = new Appointment();
                            if (attri[0] != string.Empty)
                                obj.AppointmentID = Convert.ToInt32(attri[0]);
                            obj.AppointmentDate = attri[1];
                            if (attri[2] != string.Empty)
                                obj.CAN_CANCEL = Convert.ToInt32(attri[2]);
                            if (attri[3] != string.Empty)
                                obj.EntityID = Convert.ToInt32(attri[3]);
                            obj.MemberID = attri[4];
                            if (attri[5] != string.Empty)
                                obj.PatientId = Convert.ToInt32(attri[5]);
                            obj.PatientName = attri[6];
                            if (attri[7] != string.Empty)
                                obj.PhysicianId = Convert.ToInt32(attri[7]);
                            obj.PhysicianName = attri[8];
                            if (attri[9] != string.Empty)
                                obj.ServiceType = Convert.ToInt16(attri[9]);
                            obj.ServiceTypeDesc = attri[10];
                            if (attri[11] != string.Empty)
                                obj.SlotID = Convert.ToInt16(attri[11]);
                            obj.SlotTime = attri[12];
                            obj.SpecialityDec = attri[13];
                            if (attri[14] != string.Empty)
                                obj.Status = Convert.ToInt16(attri[14]);
                            obj.Status_Desc = attri[15];
                            obj.Integration_Appointment_Id = attri[16];
                            if (attri.Count() > 17)
                            {
                                if (!string.IsNullOrEmpty(attri[17]))
                                    try
                                    {
                                        obj.OrderByAppDate = Convert.ToDateTime(attri[17], culture);
                                    }
                                    catch (Exception)
                                    {

                                    }

                            }
                            if (attri.Count() > 18)
                            {
                                if (!string.IsNullOrEmpty(attri[18]))
                                    obj.Integration_Id = Convert.ToInt32(attri[18]);
                            }
                            if (attri.Count() > 19)
                            {
                                if (!string.IsNullOrEmpty(attri[19]))
                                    obj.Intergration_code = Convert.ToString(attri[19]);
                            }
                            if (attri.Count() > 20)
                            {
                                if (!string.IsNullOrEmpty(attri[20]))
                                    obj.PractoAcessToken = Convert.ToString(attri[20]);
                            }
                            if (attri.Count() > 21)
                            {
                                if (!string.IsNullOrEmpty(attri[21]))
                                    obj.PatientMobileNo = Convert.ToString(attri[21]);
                            }
                            if (attri.Count() > 22)
                            {
                                if (!string.IsNullOrEmpty(attri[22]))
                                    obj.PatientEmailID = Convert.ToString(attri[22]);
                            }
                            if (attri.Count() > 23)
                            {
                                if (!string.IsNullOrEmpty(attri[23]))
                                    obj.MODIFIED_BY = Convert.ToInt32(attri[23]);
                            }
                            if (attri.Count() > 24)
                            {
                                if (!string.IsNullOrEmpty(attri[24]))
                                    obj.VISITORIP = Convert.ToString(attri[24]);
                            }
                            if (attri.Count() > 25)
                            {
                                if (!string.IsNullOrEmpty(attri[25]))
                                    obj.DEVICEID = Convert.ToString(attri[25]);
                            }
                            if (attri.Count() > 26)
                            {
                                if (!string.IsNullOrEmpty(attri[26]))
                                    obj.APPOINTMENT_BY_ADMIN = Convert.ToInt16(attri[26]);
                            }
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetPhysicianSearch_Pat_Serialize(List<Physician> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();

            if (Response != null && Response.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Physician obj in Response)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.PhysicianID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.UserName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ClinicAddress);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.EntityCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Experience);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Qualification);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Speciality);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.SpecialityID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Integration_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Integration_Code);
                    if (obj.Geolocation != null)
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_DISTANCE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LATITUDE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LONGITUDE);
                    }
                    else
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.EntityId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PROFILE_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.RegistrationNo);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }
        public string Get_resend_Serialize(List<Resend_otp> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();

            if (Response != null && Response.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Resend_otp obj in Response)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.ENTITY_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PATIENT_PAYABLE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ELIGIBLE_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.OTP_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.INTEGRATION_APPOINTMENT_ID);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }
        public List<Resend_otp> String_getresend_Response_Deserialize(string Response, string token)
        {
            List<Resend_otp> objList = new List<Resend_otp>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Resend_otp obj = new Resend_otp();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            
                            obj.ENTITY_CODE = attri[0];
                            obj.PATIENT_PAYABLE = attri[1];
                            obj.ELIGIBLE_AMOUNT = attri[2];
                            obj.OTP_VALUE = attri[3];
                            obj.INTEGRATION_APPOINTMENT_ID = attri[4];
                            objList.Add(obj);
                        }
                    }
                }
            }
            return objList;


        }


        public List<Physician> GetPhysicianSearch_Pat_Deserialize(string Response, string token)
        {
            List<Physician> obj = new List<Physician>();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);

            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {

                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Physician obj1 = new Physician();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.PhysicianID = Convert.ToInt32(values[0]);
                                obj1.UserName = values[1];
                                obj1.ClinicAddress = values[2];
                                obj1.EntityCode = values[3];
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.Experience = Convert.ToInt32(values[4]);
                                obj1.Qualification = values[5];
                                obj1.Speciality = values[6];
                                if (!string.IsNullOrWhiteSpace(values[7]))
                                    obj1.SpecialityID = Convert.ToInt32(values[7]);
                                if (!string.IsNullOrWhiteSpace(values[8]))
                                    obj1.Integration_Id = Convert.ToInt32(values[8]);
                                obj1.Integration_Code = values[9];
                                obj1.Geolocation = new GeoLocation();
                                if (values.Length > 10)
                                {
                                    if (!string.IsNullOrWhiteSpace(values[10]))
                                        obj1.Geolocation.GEO_DISTANCE = Convert.ToDouble(values[10]);
                                    if (!string.IsNullOrWhiteSpace(values[11]))
                                        obj1.Geolocation.GEO_LATITUDE = Convert.ToDouble(values[11]);
                                    if (!string.IsNullOrWhiteSpace(values[12]))
                                        obj1.Geolocation.GEO_LONGITUDE = Convert.ToDouble(values[12]);
                                }
                                if (!string.IsNullOrWhiteSpace(values[13]))
                                    obj1.EntityId = Convert.ToInt32(values[13]);
                                obj1.PROFILE_CODE = values[14];
                                obj1.RegistrationNo = values[15];
                                obj.Add(obj1);
                            }

                        }
                    }
                }
            }

            return obj;
        }
        public string GetReminderDetails_Serialize(ReminderList objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objResposne.Prescription_Id);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.MemberId);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.PatientName);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.PrescDate);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.Ailment_Name);
            strOutPut.Append(split);
            if (objResposne.lstReminder != null)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (ReminderV1 obj in objResposne.lstReminder)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.MorningTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.AfternoonTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.NightTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DurationDays);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Is_Active);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Created_Date);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DrugName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DrugCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ReminderDateTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Morning);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Evening);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Night);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.BeforeFood);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ReminderId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IsDeleted);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append(split);
            }
            strOutPut.Append(split);
            strOutPut.Append(objResposne.IP_Address);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.Modified_by);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.Device_id);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public ReminderList GetReminderDetails_Deserialize(string Response, string Token)
        {
            ReminderList objList = new ReminderList();
            string[] values = StringCipher.Decrypt(Response, Token).Split(split);
            objList.Prescription_Id = values[0];
            objList.MemberId = values[1];
            objList.PatientName = values[2];
            objList.PrescDate = values[3];
            objList.Ailment_Name = values[4];
            if (!string.IsNullOrEmpty(values[5]))
            {
                objList.lstReminder = new List<ReminderV1>();
                foreach (string list in values[5].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                ReminderV1 obj = new ReminderV1();
                                string[] attri = innerlist.Split(ListProperty_Split);

                                obj.MorningTime = attri[0];
                                obj.AfternoonTime = attri[1];
                                obj.NightTime = attri[2];
                                if (attri[3] != string.Empty)
                                    obj.DurationDays = Convert.ToInt16(attri[3]);
                                if (attri[4] != string.Empty)
                                    obj.Is_Active = Convert.ToInt16(attri[4]);
                                obj.Created_Date = attri[5];
                                obj.DrugName = attri[6];
                                obj.DrugCode = attri[7];
                                obj.ReminderDateTime = attri[8];
                                if (attri[9] != string.Empty)
                                    obj.Morning = Convert.ToInt16(attri[9]);
                                if (attri[10] != string.Empty)
                                    obj.Evening = Convert.ToInt16(attri[10]);
                                if (attri[11] != string.Empty)
                                    obj.Night = Convert.ToInt16(attri[11]);
                                if (attri[12] != string.Empty)
                                    obj.BeforeFood = Convert.ToInt16(attri[12]);
                                obj.ReminderId = attri[13];
                                if (attri[14] != string.Empty)
                                    obj.IsDeleted = Convert.ToInt16(attri[14]);
                                objList.lstReminder.Add(obj);
                            }
                        }
                    }
                }
            }

            if (values.Length > 6)
            {
                if (!string.IsNullOrEmpty(values[6]))
                {
                    objList.IP_Address = values[6];
                }
                if (!string.IsNullOrEmpty(values[7]))
                {
                    objList.Modified_by = values[7];
                }
                if (!string.IsNullOrEmpty(values[8]))
                {
                    objList.Device_id = values[8];
                }
            }

            return objList;
        }
        public string GetEntityList_Response_Serialize(List<Entity> Response)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);

            foreach (Entity objEntity in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objEntity.EntityCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objEntity.EntityName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), key);
        }

        //public List<Entity> GetEntityList_Response_Deserialize(string Response)
        //{
        //    List<Entity> EntityList = new List<Entity>();
        //    string strResponse = StringCipher.Decrypt(Response, key);
        //    foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
        //    {
        //        if (list != string.Empty)
        //        {
        //            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
        //            {
        //                if (innerlist != string.Empty)
        //                {
        //                    Entity objEntity = new Entity();
        //                    string[] attri = innerlist.Split(ListProperty_Split);
        //                    if (attri[0] != string.Empty)
        //                        //  objEntity.EntityID = Convert.ToInt32(attri[0]);
        //                        objEntity.EntityCode = attri[0];
        //                    objEntity.EntityName = attri[1];
        //                    EntityList.Add(objEntity);
        //                }
        //            }
        //        }
        //    }


        //    return EntityList;
        //}

        public List<Entity> GetEntityList_Response_Deserialize(string Response)
        {
            List<Entity> EntityList = new List<Entity>();
            string[] values1 = StringCipher.Decrypt(Response, key).Split(split);
            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Entity objEntity = new Entity();
                                string[] attri = innerlist.Split(ListProperty_Split);
                                if (attri[0] != string.Empty)
                                    //  objEntity.EntityID = Convert.ToInt32(attri[0]);
                                    objEntity.EntityCode = attri[0];
                                objEntity.EntityName = attri[1];
                                EntityList.Add(objEntity);
                            }

                        }
                    }
                }
            }

            return EntityList;
        }

        public string GetSymptons_Response_Serialize(List<PrescriptionClass.complaint> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);

            foreach (PrescriptionClass.complaint obj in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(obj.name);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<PrescriptionClass.complaint> GetSymptons_Response_Deserialize(string Response, string token)
        {
            List<PrescriptionClass.complaint> objList = new List<PrescriptionClass.complaint>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PrescriptionClass.complaint com = new PrescriptionClass.complaint();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                com.name = attri[0];
                            objList.Add(com);
                        }
                    }
                }
            }


            return objList;
        }

        public string GetSearchCityMenu_Com_Serialize(List<OP_Menu_Search> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response != null && Response.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (OP_Menu_Search obj in Response)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IMAGE_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_DISPLAY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TRANSACTION_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TYPE_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.VALUE_ID);

                    if (obj.Geolocation != null)
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_DISTANCE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LATITUDE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LONGITUDE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.LOC_NAME);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.CITY_ID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.CITY);
                    }
                    else
                    {
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(string.Empty);
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IMAGE_NAME1);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<OP_Menu_Search> GetSearchCityMenu_Com_Deserialize(string Response, string token)
        {
            List<OP_Menu_Search> obj = new List<OP_Menu_Search>();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                OP_Menu_Search obj1 = new OP_Menu_Search();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(values[0]);
                                obj1.DISPLAY_TEXT = values[1];
                                obj1.IMAGE_NAME = values[2];
                                if (!string.IsNullOrWhiteSpace(values[3]))
                                    obj1.IS_DISPLAY = Convert.ToInt32(values[3]);
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.TRANSACTION_TYPE = Convert.ToInt32(values[4]);
                                if (!string.IsNullOrWhiteSpace(values[5]))
                                    obj1.TYPE_ID = Convert.ToInt32(values[5]);
                                if (!string.IsNullOrWhiteSpace(values[6]))
                                    obj1.VALUE_ID = Convert.ToInt32(values[6]);
                                obj1.Geolocation = new GeoLocation();
                                if (!string.IsNullOrWhiteSpace(values[7]))
                                    obj1.Geolocation.GEO_DISTANCE = Convert.ToDouble(values[7]);
                                if (!string.IsNullOrWhiteSpace(values[8]))
                                    obj1.Geolocation.GEO_LATITUDE = Convert.ToDouble(values[8]);
                                if (!string.IsNullOrWhiteSpace(values[9]))
                                    obj1.Geolocation.GEO_LONGITUDE = Convert.ToDouble(values[9]);
                                obj1.Geolocation.LOC_NAME = values[10];
                                if (!string.IsNullOrWhiteSpace(values[11]))
                                    obj1.Geolocation.CITY_ID = Convert.ToInt16(values[11]);
                                obj1.Geolocation.CITY = values[12];
                                obj1.IMAGE_NAME1 = values[13];
                                obj.Add(obj1);
                            }

                        }
                    }
                }
            }

            return obj;
        }

        public string VitalsControls_Serialize(List<Vital_Controls> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response != null && Response.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Vital_Controls obj in Response)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.CONTROL_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_STYLE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DATA_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXPAND);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.SPECIALITY_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.SPECIALITY_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_2TEXTBOX);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TEXT_LEN);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Vital_Controls> VitalsControls_Deserialize(string Response, string token)
        {
            List<Vital_Controls> obj = new List<Vital_Controls>();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Vital_Controls obj1 = new Vital_Controls();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.CONTROL_ID = Convert.ToInt32(values[0]);
                                obj1.CONTROL_TEXT = values[1];
                                obj1.CONTROL_TEXT_STYLE = values[2];
                                obj1.CONTROL_TEXT_VALUE = values[3];
                                obj1.CONTROL_TYPE = values[4];
                                obj1.DATA_TYPE = values[5];
                                if (!string.IsNullOrWhiteSpace(values[6]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(values[6]);
                                if (!string.IsNullOrWhiteSpace(values[7]))
                                    obj1.IS_EXPAND = Convert.ToInt32(values[7]);
                                if (!string.IsNullOrWhiteSpace(values[8]))
                                    obj1.SPECIALITY_ID = Convert.ToInt32(values[8]);
                                obj1.SPECIALITY_NAME = values[9];
                                if (!string.IsNullOrWhiteSpace(values[10]))
                                    obj1.IS_2TEXTBOX = Convert.ToInt32(values[10]);
                                if (!string.IsNullOrWhiteSpace(values[11]))
                                    obj1.TEXT_LEN = Convert.ToInt32(values[11]);
                                obj.Add(obj1);
                            }

                        }
                    }
                }
            }

            return obj;
        }

        public string Vitals_Dashboard_Serialize(Vitals_Dashboard Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response != null && Response.lstMonitorDate != null && Response.lstMonitorDate.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (string obj in Response.lstMonitorDate)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);
            if (Response != null && Response.lstVitalsDetails != null && Response.lstVitalsDetails.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Vital_Controls obj in Response.lstVitalsDetails)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.CLAIM_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXPAND);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.MONITOR_DATE);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public Vitals_Dashboard Vitals_Dashboard_Deserialize(string Response, string token)
        {
            Vitals_Dashboard _objvit = new Vitals_Dashboard();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                _objvit.lstMonitorDate = new List<string>();
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                _objvit.lstMonitorDate.Add(innerlist);
                            }
                        }
                    }
                }
            }

            if (values1[1] != string.Empty)
            {
                _objvit.lstVitalsDetails = new List<Vital_Controls>();
                foreach (string list in values1[1].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Vital_Controls obj1 = new Vital_Controls();
                                string[] values = innerlist.Split(ListProperty_Split);
                                obj1.CLAIM_ID = values[0];
                                obj1.CONTROL_TEXT = values[1];
                                obj1.CONTROL_TEXT_VALUE = values[2];
                                obj1.CONTROL_TYPE = values[3];
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(values[4]);
                                if (!string.IsNullOrWhiteSpace(values[5]))
                                    obj1.IS_EXPAND = Convert.ToInt32(values[5]);
                                obj1.MONITOR_DATE = values[6];
                                _objvit.lstVitalsDetails.Add(obj1);
                            }
                        }
                    }
                }
            }

            return _objvit;
        }

        public string MedicalSummaryDashboard_Serialize(MedicalSummaryDashboard Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response != null && Response.lstMonitorDate != null && Response.lstMonitorDate.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (string obj in Response.lstMonitorDate)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);
            // vitals
            if (Response != null && Response.lstVitalsDetails != null && Response.lstVitalsDetails.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Vital_Controls obj in Response.lstVitalsDetails)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.CLAIM_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.CONTROL_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXPAND);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.MONITOR_DATE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.STANDARD_VALUE);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);
            //Diagnostic list
            if (Response.DiagnosisDetail != null && Response.DiagnosisDetail.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Diagnosis objdia in Response.DiagnosisDetail)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objdia.DiagnosisName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.ClaimID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.DiagnosisCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.RESULT_VALUE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objdia.Date);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            //Diagnostic_Range
            if (Response.Diagnostic_Range != null && Response.Diagnostic_Range.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (DiagnosticRange obj in Response.Diagnostic_Range)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DIAGNOSTIC_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.KEY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.VALUE);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }



            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public MedicalSummaryDashboard MedicalSummaryDashboard_Deserialize(string Response, string token)
        {
            MedicalSummaryDashboard _obj = new MedicalSummaryDashboard();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                _obj.lstMonitorDate = new List<string>();
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                _obj.lstMonitorDate.Add(innerlist);
                            }
                        }
                    }
                }
            }

            if (values1[1] != string.Empty)
            {
                _obj.lstVitalsDetails = new List<Vital_Controls>();
                foreach (string list in values1[1].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Vital_Controls obj1 = new Vital_Controls();
                                string[] values = innerlist.Split(ListProperty_Split);
                                obj1.CLAIM_ID = values[0];
                                obj1.CONTROL_TEXT = values[1];
                                obj1.CONTROL_TEXT_VALUE = values[2];
                                obj1.CONTROL_TYPE = values[3];
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(values[4]);
                                if (!string.IsNullOrWhiteSpace(values[5]))
                                    obj1.IS_EXPAND = Convert.ToInt32(values[5]);
                                obj1.MONITOR_DATE = values[6];
                                obj1.STANDARD_VALUE = values[7];
                                _obj.lstVitalsDetails.Add(obj1);
                            }
                        }
                    }
                }
            }

            if (values1[2] != null && values1[2] != string.Empty)
            {
                _obj.DiagnosisDetail = new List<Diagnosis>();
                List<Diagnosis> objList = new List<Diagnosis>();
                foreach (string list in values1[2].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Diagnosis objDrug = new Diagnosis();

                                objDrug.DiagnosisName = attri[0];
                                objDrug.ClaimID = attri[1];
                                objDrug.DiagnosisCode = Convert.ToString(attri[2]);
                                objDrug.RESULT_VALUE = Convert.ToString(attri[3]);
                                objDrug.Date = Convert.ToString(attri[4]);
                                objList.Add(objDrug);
                            }
                        }
                    }
                }
                _obj.DiagnosisDetail = objList;
            }

            if (values1[3] != null && values1[3] != string.Empty)
            {
                _obj.Diagnostic_Range = new List<DiagnosticRange>();
                foreach (string list in values1[3].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                DiagnosticRange objDR = new DiagnosticRange();
                                objDR.DIAGNOSTIC_CODE = attri[0];
                                objDR.KEY = attri[1];
                                objDR.VALUE = attri[2];
                                _obj.Diagnostic_Range.Add(objDR);
                            }
                        }
                    }
                }

            }

            return _obj;
        }

        public string GetPatientVitalDashboard_Pat_Serialize(List<PrescriptionClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass PreClass in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(PreClass.prescriptionId);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patientName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.MobileNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.Vital_ID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);

                if (PreClass.VitalsLst != null && PreClass.VitalsLst.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Vital_Controls obj in PreClass.VitalsLst)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(obj.CLAIM_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TEXT);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TEXT_STYLE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TYPE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.DISPLAY_ORDER);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Vital_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.IS_2TEXTBOX);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.IS_EXPAND);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CREATED_BY);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.MODIFIED_BY);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.DEVICEID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.VISITORSIP);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(ListProperty_Split);
                if (PreClass.AttachmentsLst != null && PreClass.AttachmentsLst.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (OP_Attachments obj in PreClass.AttachmentsLst)
                    {
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(obj.AttachFileName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.AttachmentRemarks);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Claim_Id);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Member_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.PatientId);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.CREATED_BY);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.MODIFIED_BY);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.DEVICEID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.VISITORSIP);
                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.patient_id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.MemberID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.AppointmentId);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetPatientVitalDashboard_Pat_Deserialize(string Response, string Token)
        {
            List<PrescriptionClass> objList = new List<PrescriptionClass>();
            string[] arr = StringCipher.Decrypt(Response, Token).Split(split);
            foreach (string strval in arr)
            {
                if (strval.Contains(ListIdentifier_Start))
                {
                    foreach (string list in strval.Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass objPres = new PrescriptionClass();
                                    string[] values = innerlist.Split(ListProperty_Split);

                                    objPres.prescriptionId = values[0];
                                    objPres.patientName = values[1];
                                    objPres.MobileNo = values[2];
                                    objPres.Vital_ID = values[3];
                                    objPres.prescriptionDate = values[4];

                                    if (values[5] != null && values[5] != string.Empty)
                                    {
                                        List<Vital_Controls> objLst = new List<Vital_Controls>();
                                        foreach (string list1 in values[5].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (innerlist1 != string.Empty)
                                                    {
                                                        string[] attri = innerlist1.Split(Inner_ListProperty_Split);
                                                        Vital_Controls Obj = new Vital_Controls();
                                                        Obj.CLAIM_ID = attri[0];
                                                        Obj.CONTROL_TEXT = attri[1];
                                                        Obj.CONTROL_TEXT_STYLE = attri[2];
                                                        Obj.CONTROL_TEXT_VALUE = attri[3];
                                                        Obj.CONTROL_TYPE = attri[4];
                                                        if (!string.IsNullOrEmpty(attri[5]))
                                                            Obj.DISPLAY_ORDER = Convert.ToInt32(attri[5]);
                                                        Obj.Vital_ID = attri[6];
                                                        if (!string.IsNullOrEmpty(attri[7]))
                                                            Obj.IS_2TEXTBOX = Convert.ToInt32(attri[7]);
                                                        if (!string.IsNullOrEmpty(attri[8]))
                                                            Obj.IS_EXPAND = Convert.ToInt32(attri[8]);
                                                        if (attri.Length >= 10)
                                                            Obj.CREATED_BY = attri[9];
                                                        if (attri.Length >= 11)
                                                            Obj.MODIFIED_BY = attri[10];
                                                        if (attri.Length >= 12)
                                                            Obj.DEVICEID = attri[11];
                                                        if (attri.Length >= 13)
                                                            Obj.VISITORSIP = attri[12];
                                                        objLst.Add(Obj);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.VitalsLst = objLst;
                                    }

                                    if (values[6] != null && values[6] != string.Empty)
                                    {
                                        List<OP_Attachments> objLst = new List<OP_Attachments>();
                                        foreach (string list1 in values[6].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                        {
                                            if (list1 != string.Empty)
                                            {
                                                foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                                {
                                                    if (innerlist1 != string.Empty)
                                                    {
                                                        string[] attri = innerlist1.Split(Inner_ListProperty_Split);
                                                        OP_Attachments Obj = new OP_Attachments();
                                                        Obj.AttachFileName = attri[0];
                                                        Obj.AttachmentRemarks = attri[1];
                                                        Obj.Claim_Id = attri[2];
                                                        Obj.Member_ID = attri[3];
                                                        if (!string.IsNullOrEmpty(attri[4]))
                                                            Obj.PatientId = Convert.ToInt32(attri[4]);
                                                        if (attri.Length >= 6)
                                                            Obj.CREATED_BY = attri[5];
                                                        if (attri.Length >= 7)
                                                            Obj.MODIFIED_BY = attri[6];
                                                        if (attri.Length >= 8)
                                                            Obj.DEVICEID = attri[7];
                                                        if (attri.Length >= 9)
                                                            Obj.VISITORSIP = attri[8];
                                                        objLst.Add(Obj);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.AttachmentsLst = objLst;
                                    }
                                    objPres.patient_id = values[7];
                                    objPres.MemberID = values[8];
                                    if (values.Count() > 9 && !string.IsNullOrEmpty(values[9]))
                                    {
                                        objPres.AppointmentId = Convert.ToInt32(values[9]);
                                    }
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string GetIntegrationAuthTokens_Serialize(IntegrationAuthTokens Response, string token)
        {
            StringBuilder objOutput = new StringBuilder();
            objOutput.Append(Response.PatientId);
            objOutput.Append(split);
            objOutput.Append(Response.Authorizationcode);
            objOutput.Append(split);
            objOutput.Append(Response.Accesstoken);
            objOutput.Append(split);
            objOutput.Append(Response.RefreshToken);
            objOutput.Append(split);
            objOutput.Append(Response.CLIENT_ID);
            objOutput.Append(split);
            objOutput.Append(Response.Redirect_Uri);
            objOutput.Append(split);
            objOutput.Append(Response.Practo_Auth_Uri);
            objOutput.Append(split);
            objOutput.Append(Response.Practo_Book_Uri);
            objOutput.Append(split);
            objOutput.Append(Response.IsReAuthorizationReq);
            objOutput.Append(split);

            return StringCipher.Encrypt(objOutput.ToString(), token);
        }

        public IntegrationAuthTokens GetIntegrationAuthTokens_Deserialize(string Response, string token)
        {
            IntegrationAuthTokens objPat = new IntegrationAuthTokens();
            string strResponse = StringCipher.Decrypt(Response, token);
            string[] attri = strResponse.Split(split);
            if (attri != null && attri.Count() > 0)
            {
                objPat.PatientId = attri[0];
                objPat.Authorizationcode = attri[1];
                objPat.Accesstoken = attri[2];
                objPat.RefreshToken = attri[3];
                objPat.CLIENT_ID = attri[4];
                objPat.Redirect_Uri = attri[5];
                objPat.Practo_Auth_Uri = attri[6];
                objPat.Practo_Book_Uri = attri[7];
                if (!string.IsNullOrEmpty(Convert.ToString(attri[8])))
                    objPat.IsReAuthorizationReq = Convert.ToBoolean(attri[8]);
            }

            return objPat;
        }

        public string GetNotification_Pat_Serialize(List<NotificationClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (NotificationClass objApp in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objApp.CLAIM_ID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.NOTIFICATION_MSG);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.NOTIFICATION_TITLE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.NOTIFICATION_TYPE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.USER_ID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.SENTON);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.ISREFUNDNOTIFICATION);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.ORDERID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.ONEMG_ORDER_ID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.NOTIFICATION_DAYS);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.ORDER_DATE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<NotificationClass> GetNotificationDashbroad_Pat_Deserialize(string Response, string Token)
        {
            List<NotificationClass> objapp = new List<NotificationClass>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            NotificationClass obj = new NotificationClass();
                            if (attri[0] != string.Empty)
                                obj.CLAIM_ID = Convert.ToString(attri[0]);
                            if (attri[1] != string.Empty)
                                obj.NOTIFICATION_MSG = attri[1];
                            if (attri[2] != string.Empty)
                                obj.NOTIFICATION_TITLE = Convert.ToString(attri[2]);
                            if (attri[3] != string.Empty)
                                obj.NOTIFICATION_TYPE = Convert.ToString(attri[3]);
                            if (attri[4] != string.Empty)
                                obj.USER_ID = attri[4];
                            if (attri[5] != string.Empty)
                                obj.SENTON = Convert.ToString(attri[5]);
                            if (attri[6] != string.Empty)
                                obj.ISREFUNDNOTIFICATION = Convert.ToInt32(attri[6]);
                            if (attri[7] != string.Empty)
                                obj.ORDERID = Convert.ToString(attri[7]);
                            if (attri[8] != string.Empty)
                                obj.ONEMG_ORDER_ID = Convert.ToString(attri[8]);
                            if (attri[9] != string.Empty)
                                obj.NOTIFICATION_DAYS = Convert.ToString(attri[9]);
                            if (attri[10] != string.Empty)
                                obj.ORDER_DATE = Convert.ToDateTime(attri[10], culture);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetDrugGenericMaster_Phy_Serialize(List<DrugGeneric> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (DrugGeneric objPro in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objPro.GenericName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.GenericCode);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<DrugGeneric> GetDrugGenericMaster_Phy_Deserialize(string Response, string Token)
        {
            List<DrugGeneric> objapp = new List<DrugGeneric>();
            string strResposne = StringCipher.Decrypt(Response, Token);
            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            DrugGeneric obj = new DrugGeneric();
                            obj.GenericName = attri[0];
                            obj.GenericCode = attri[1];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetProfileDetails_Pat_Serialize(ProfileDetails Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response != null && Response.lstFeedback != null && Response.lstFeedback.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (ServiceFeedBack obj in Response.lstFeedback)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.FeedbackRemarks);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.FeedbackDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PatientName);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);

            if (Response != null && Response.lstService != null && Response.lstService.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (EntityServices obj in Response.lstService)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.Service);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);

            if (Response.lstWorkHours != null && Response.lstWorkHours.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (WorkingHours obj in Response.lstWorkHours)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.Day);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Timings);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.SlotType);

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            if (Response.lstServiceImage != null && Response.lstServiceImage.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (ServiceImage obj in Response.lstServiceImage)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.ImageName);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);
            strOutPut.Append(Response.ServiceImageUrl);
            strOutPut.Append(split);
            strOutPut.Append(Response.VoteInPerc);
            strOutPut.Append(split);
            strOutPut.Append(Response.Vote);
            strOutPut.Append(split);

            if (Response.lstFacilities != null && Response.lstFacilities.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (ServiceFacilities obj in Response.lstFacilities)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.Facilities);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }

            strOutPut.Append(split);
            strOutPut.Append(Response.feedback_rating);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }
        public ProfileDetails GetProfileDetails_Pat_Deserialize(string Response, string token)
        {
            ProfileDetails _obj = new ProfileDetails();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                _obj.lstFeedback = new List<ServiceFeedBack>();
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                ServiceFeedBack objF = new ServiceFeedBack();
                                string[] values = innerlist.Split(ListProperty_Split);
                                objF.FeedbackRemarks = values[0];
                                objF.FeedbackDate = values[1];
                                objF.PatientName = values[2];
                                _obj.lstFeedback.Add(objF);
                            }
                        }
                    }
                }
            }

            if (values1[1] != string.Empty)
            {
                _obj.lstService = new List<EntityServices>();
                foreach (string list in values1[1].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                EntityServices obj1 = new EntityServices();
                                string[] values = innerlist.Split(ListProperty_Split);
                                obj1.Service = values[0];
                                _obj.lstService.Add(obj1);
                            }
                        }
                    }
                }
            }

            if (values1[2] != null && values1[2] != string.Empty)
            {
                _obj.lstWorkHours = new List<WorkingHours>();
                foreach (string list in values1[2].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                WorkingHours objW = new WorkingHours();
                                objW.Day = attri[0];
                                objW.Timings = attri[1];
                                objW.SlotType = attri[2];
                                _obj.lstWorkHours.Add(objW);
                            }
                        }
                    }
                }
            }
            if (values1[3] != null && values1[3] != string.Empty)
            {
                _obj.lstServiceImage = new List<ServiceImage>();
                foreach (string list in values1[3].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ServiceImage objW = new ServiceImage();
                                objW.ImageName = attri[0];
                                _obj.lstServiceImage.Add(objW);
                            }
                        }
                    }
                }
            }
            if (values1[4] != null && values1[4] != string.Empty)
                _obj.ServiceImageUrl = values1[4];
            if (values1[5] != null && values1[5] != string.Empty)
                _obj.VoteInPerc = values1[5];
            if (values1[6] != null && values1[6] != string.Empty)
                _obj.Vote = values1[6];

            if (values1[7] != null && values1[7] != string.Empty)
            {
                _obj.lstFacilities = new List<ServiceFacilities>();
                foreach (string list in values1[7].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                ServiceFacilities objW = new ServiceFacilities();
                                objW.Facilities = attri[0];
                                _obj.lstFacilities.Add(objW);
                            }
                        }
                    }
                }
            }

            if (values1[8] != null && values1[8] != string.Empty)
                _obj.feedback_rating = values1[8];

            return _obj;
        }

        public QueryRequest ForgotMpinSendOTP_Request_Deserialize(string Request, string token)
        {
            token = key;
            QueryRequest obj = new QueryRequest();
            string[] values = StringCipher.Decrypt(Request, token).Split(split);
            obj.param = new List<string>();
            foreach (string strval in values)
            {
                if (!strval.Contains(ListIdentifier_Start))
                {
                    obj.param.Add(strval);
                }
            }
            return obj;
        }
        public string ForgotMpinSendOTP_Request_serialize(int userType, string userID, string mobileNo = null, string token = "")
        {
            string outPut = string.Empty;
            token = key;
            outPut = userType.ToString() + split + userID + split + mobileNo;

            return StringCipher.Encrypt(outPut, token);
        }

        public string ForgotMpinSendOTP_Response_serialize(string Otp, string token)
        {
            string outPut = string.Empty;

            outPut = Otp;
            token = key;
            return StringCipher.Encrypt(outPut, token);
        }


        public string ForgotMpinSendOTP_Request_serialize_V2(int userType, string userID, string mobileNo = null, string token = "", string IPAddress = "", string DeviceID = "")
        {
            string outPut = string.Empty;
            token = key;
            outPut = userType.ToString() + split + userID + split + mobileNo + split + IPAddress + split + DeviceID;

            return StringCipher.Encrypt(outPut, token);
        }



        public string ForgotMpinSendOTP_Response_Deserialize(string Request, string token)
        {
            string outPut = string.Empty;
            token = key;
            outPut = StringCipher.Decrypt(Request, token);

            return outPut;
        }

        public string MAPPInfoService_Response_Serialize(MAPPInfoService obj)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(obj.AppVersionCode);
            strOutPut.Append(split);
            strOutPut.Append(obj.AppVersionName);
            strOutPut.Append(split);
            strOutPut.Append(obj.APP_URL);
            strOutPut.Append(split);
            strOutPut.Append(obj.DeviceId);
            strOutPut.Append(split);
            strOutPut.Append(obj.DeviceScreenHeight);
            strOutPut.Append(split);
            strOutPut.Append(obj.DeviceScreenWidth);
            strOutPut.Append(split);
            strOutPut.Append(obj.ForcedLogout);
            strOutPut.Append(split);
            strOutPut.Append(obj.ForcedUpdated);
            strOutPut.Append(split);
            strOutPut.Append(obj.PackageName);
            strOutPut.Append(split);
            strOutPut.Append(obj.ReleasedOn);
            strOutPut.Append(split);
            strOutPut.Append(obj.ForcedLogoutMsg);
            strOutPut.Append(split);
            strOutPut.Append(obj.ForcedUpdatedMsg);
            strOutPut.Append(split);
            strOutPut.Append(obj.AppVersionName_v1);
            return StringCipher.Encrypt(strOutPut.ToString(), key);
        }

        public MAPPInfoService MAPPInfoService_Response_Deserialize(string Response)
        {
            MAPPInfoService obj = new MAPPInfoService();
            string[] values = StringCipher.Decrypt(Response, key).Split(split);

            if (values[0] != string.Empty)
                obj.AppVersionCode = Convert.ToInt32(values[0]);
            if (values[1] != string.Empty)
                obj.AppVersionName = Convert.ToDecimal(values[1]);
            obj.APP_URL = values[2];
            obj.DeviceId = values[3];
            if (values[4] != string.Empty)
                obj.DeviceScreenHeight = Convert.ToDouble(values[4]);
            if (values[5] != string.Empty)
                obj.DeviceScreenWidth = Convert.ToDouble(values[5]);
            if (values[6] != string.Empty)
                obj.ForcedLogout = Convert.ToInt32(values[6]);
            if (values[7] != string.Empty)
                obj.ForcedUpdated = Convert.ToInt32(values[7]);
            obj.PackageName = values[8];
            obj.ReleasedOn = values[9];
            obj.ForcedLogoutMsg = values[10];
            obj.ForcedUpdatedMsg = values[11];
            obj.AppVersionName_v1 = values[12];
            return obj;
        }

        public string GetPartialPrescriptionDetail_Diag_Serialize(PrescriptionClass Prescription, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Prescription != null)
            {
                strOutPut.Append(Prescription.Is_health_check);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.prescriptionId);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.physicianName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.physician_id);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.patientName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.prescriptionDate);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.patient_id);//7
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentName);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ailmentid);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PrescriptionType);//11
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryCity);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryAddress);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.DeliveryPinCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PrecFileName);//15
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PatientGender);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PatientAge);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.MobileNo);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.PharmacyRemarks);//19
                strOutPut.Append(split);

                #region Drug List

                if (Prescription.Druglist != null && Prescription.Druglist.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Drug obj in Prescription.Druglist)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(obj.DrugID);//1
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.NoOfDays);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DrugQuantity);//5
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Afternoon);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Morning);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Night);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Rate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.OrderId);//10
                        strOutPut.Append(ListProperty_Split);//new
                        strOutPut.Append(obj.No_of_Ordered_Tablet);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.Is_Ordered);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.IsFullOrdered);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.No_of_Tablet);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.SubstituteWithDrugId);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.MRP);
                        strOutPut.Append(ListProperty_Split);//end
                        strOutPut.Append(obj.Evening);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.BillAmt);//21
                strOutPut.Append(split);

                #region Pharmacy List

                if (Prescription.pharmacyDetail != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Prescription.pharmacyDetail.PharmacyID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.PharmacyName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.ShippingCharge);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.DeliveryMinTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.DeliveryMaxTime);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.pharmacyDetail.Discount);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.diagnosticId);//23
                strOutPut.Append(split);

                #region Diagnostic List

                if (Prescription.DiagnosisDetail != null && Prescription.DiagnosisDetail.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Diagnosis objdia in Prescription.DiagnosisDetail)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objdia.DiagnosisID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.filename);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.DiagnosisRate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.Is_Ordered);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.OrderId);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.Discount);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objdia.Is_Rate_Defined);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);

                #region Oderdetails List

                if (Prescription.Orderdetails != null && Prescription.Orderdetails.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Oderdetails objorder in Prescription.Orderdetails)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objorder.order_id);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.prescription_id);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.orderdate);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.Order_Amt);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.OrderStatus);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objorder.OrderStatusID);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.IsView);//26
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ErrorCode);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ErrorDesc);
                strOutPut.Append(split);
                #region Shipping Address

                if (Prescription.ShippingAdr != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Prescription.ShippingAdr.AddressId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.AddressTitle);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.Street1);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.Street2);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.StateID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.CityID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.PinCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.Country);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.MobileNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.ShippingAdr.consumer_name);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);
                strOutPut.Append(Prescription.TransactionType);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.EntityKey);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.GUID);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.EntityCode);
                strOutPut.Append(split);
                #endregion

                #region Symptoms List
                if (Prescription.complaints != null && Prescription.complaints.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (PrescriptionClass.complaint objSymptom in Prescription.complaints)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objSymptom.name);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);
                #endregion

                #region Diagnosis List
                if (Prescription.secondaryAilments != null && Prescription.secondaryAilments.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (PrescriptionClass.SecondaryAilment objAilment in Prescription.secondaryAilments)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objAilment.SecondaryAilmentname);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                #endregion

                strOutPut.Append(split);
                strOutPut.Append(Prescription.physician_Speciality);
                strOutPut.Append(split);
                strOutPut.Append(Prescription.ServiceAccessTypeID);
                strOutPut.Append(split);
                if (Prescription.Consultation != null)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(Prescription.Consultation.ConsultationFee);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.Consultation.ReviewDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(Prescription.Consultation.Speciality);
                    strOutPut.Append(ListElement_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(split);
                //minor procedure list
                if (Prescription.Proclist != null && Prescription.Proclist.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Procedure objProc in Prescription.Proclist)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objProc.ProcedureID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objProc.ProcedureCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objProc.ProcedureName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objProc.ReportName);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
                strOutPut.Append(split);

                //minor Test list
                if (Prescription.Testlist != null && Prescription.Testlist.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Procedure objTest in Prescription.Testlist)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(objTest.ProcedureID);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objTest.ProcedureCode);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objTest.ProcedureName);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(objTest.ReportName);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }

                strOutPut.Append(split);
                //Vitals 
                if (Prescription.VitalsLst != null && Prescription.VitalsLst.Count > 0)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    foreach (Vital_Controls obj in Prescription.VitalsLst)
                    {
                        strOutPut.Append(ListElement_Start);
                        strOutPut.Append(obj.CONTROL_TEXT);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TEXT_STYLE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TEXT_VALUE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.CONTROL_TYPE);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.DISPLAY_ORDER);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.IS_EXPAND);
                        strOutPut.Append(ListProperty_Split);
                        strOutPut.Append(obj.IS_2TEXTBOX);
                        strOutPut.Append(ListElement_End);
                    }
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass GetPartialPrescriptionDetail_Diag_Deserialize(string Response, string token)
        {
            PrescriptionClass Prescription = new PrescriptionClass();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            if (values.Length > 1)
            {
                if (!string.IsNullOrEmpty(values[0]))
                    Prescription.Is_health_check = Convert.ToInt32(values[0]);
                Prescription.prescriptionId = values[1];
                Prescription.physicianName = values[2];
                Prescription.physician_id = values[3];
                Prescription.patientName = values[4];
                Prescription.prescriptionDate = values[5];
                Prescription.patient_id = values[6];
                Prescription.ailmentName = values[7];
                Prescription.ailmentCode = values[8];
                Prescription.ailmentid = values[9];
                if (!string.IsNullOrEmpty(values[10]))
                    Prescription.PrescriptionType = Convert.ToInt32(values[10]);
                Prescription.DeliveryCity = values[11];
                Prescription.DeliveryAddress = values[12];
                Prescription.DeliveryPinCode = values[13];
                Prescription.PrecFileName = values[14];
                Prescription.PatientGender = values[15];
                Prescription.PatientAge = values[16];
                Prescription.MobileNo = values[17];
                Prescription.PharmacyRemarks = values[18];

                if (values[19] != null && values[19] != string.Empty)
                {
                    #region Drug List
                    Prescription.Druglist = new List<Drug>();
                    foreach (string list in values[19].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Drug objDrug = new Drug();
                                    if (attri[0] != string.Empty)
                                        objDrug.DrugID = Convert.ToInt32(attri[0]);
                                    objDrug.DrugCode = attri[1];
                                    objDrug.DrugName = attri[2];
                                    if (attri[3] != string.Empty)
                                        objDrug.NoOfDays = Convert.ToInt32(attri[3]);
                                    if (attri[4] != string.Empty)
                                        objDrug.DrugQuantity = Convert.ToInt32(attri[4]);
                                    if (attri[5] != string.Empty)
                                        objDrug.Afternoon = Convert.ToDecimal(attri[5]);
                                    if (attri[6] != string.Empty)
                                        objDrug.Morning = Convert.ToDecimal(attri[6]);
                                    if (attri[7] != string.Empty)
                                        objDrug.Night = Convert.ToDecimal(attri[7]);
                                    if (attri[8] != string.Empty)
                                        objDrug.Rate = Convert.ToDecimal(attri[8]);
                                    objDrug.OrderId = attri[9];
                                    if (attri[10] != string.Empty)
                                        objDrug.No_of_Ordered_Tablet = Convert.ToInt32(attri[10]);
                                    if (attri[11] != string.Empty)
                                        objDrug.Is_Ordered = Convert.ToInt32(attri[11]);
                                    if (attri[12] != string.Empty)
                                        objDrug.IsFullOrdered = Convert.ToInt32(attri[12]);
                                    if (attri[13] != string.Empty)
                                        objDrug.No_of_Tablet = Convert.ToInt32(attri[13]);
                                    if (attri[14] != string.Empty)
                                        objDrug.SubstituteWithDrugId = Convert.ToInt32(attri[14]);
                                    if (attri[15] != string.Empty)
                                        objDrug.MRP = Convert.ToDecimal(attri[15]);
                                    if (attri[16] != string.Empty)
                                        objDrug.Evening = Convert.ToDecimal(attri[16]);
                                    Prescription.Druglist.Add(objDrug);
                                }
                            }
                        }
                    }
                    #endregion
                }
                if (!string.IsNullOrEmpty(values[20]))
                    Prescription.BillAmt = Convert.ToDecimal(values[20]);

                if (values[21] != null && values[21] != string.Empty)
                {
                    #region Pharmacy List
                    Prescription.pharmacyDetail = new Pharmacy();
                    foreach (string innerlist in values[21].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                Prescription.pharmacyDetail.PharmacyID = Convert.ToInt32(attri[0]);
                            Prescription.pharmacyDetail.PharmacyName = attri[1];
                            if (attri[2] != string.Empty)
                                Prescription.pharmacyDetail.ShippingCharge = Convert.ToDecimal(attri[2]);
                            if (attri[3] != string.Empty)
                                Prescription.pharmacyDetail.DeliveryMinTime = Convert.ToInt32(attri[3]);
                            if (attri[4] != string.Empty)
                                Prescription.pharmacyDetail.DeliveryMaxTime = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                Prescription.pharmacyDetail.Discount = Convert.ToDecimal(attri[5]);
                        }
                    }
                    #endregion Pharmacy List
                }
                Prescription.diagnosticId = values[22];
                if (values[23] != null && values[23] != string.Empty)
                {
                    #region Diagnostic List
                    Prescription.DiagnosisDetail = new List<Diagnosis>();
                    foreach (string list in values[23].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    Diagnosis objDrug = new Diagnosis();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        if (attri[0] != string.Empty)
                                            objDrug.DiagnosisID = Convert.ToInt32(attri[0]);
                                        objDrug.DiagnosisName = attri[1];
                                        objDrug.DiagnosisCode = attri[2];
                                        objDrug.filename = attri[3];
                                        if (attri[4] != string.Empty)
                                            objDrug.DiagnosisRate = Convert.ToDecimal(attri[4]);
                                        if (attri[5] != string.Empty)
                                            objDrug.Is_Ordered = Convert.ToInt16(attri[5]);
                                        if (attri[6] != string.Empty)
                                            objDrug.OrderId = Convert.ToString(attri[6]);
                                        if (attri[7] != string.Empty)
                                            objDrug.Discount = Convert.ToInt16(attri[7]);
                                        if (attri[8] != string.Empty)
                                            objDrug.Is_Rate_Defined = Convert.ToInt16(attri[8]);
                                        Prescription.DiagnosisDetail.Add(objDrug);
                                    }
                                }
                            }
                        }
                    }

                    #endregion Diagnosis List
                }

                if (values[24] != null && values[24] != string.Empty)
                {

                    #region Oderdetails List
                    Prescription.Orderdetails = new List<Oderdetails>();
                    foreach (string list in values[24].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Oderdetails ObjOrder = new Oderdetails();
                                    if (attri.Length > 0)
                                    {
                                        ObjOrder.order_id = attri[0];
                                        ObjOrder.prescription_id = attri[1];
                                        ObjOrder.orderdate = attri[2];
                                        ObjOrder.Order_Amt = attri[3];
                                        ObjOrder.OrderStatus = attri[4];
                                        ObjOrder.OrderStatusID = attri[5];
                                        Prescription.Orderdetails.Add(ObjOrder);
                                    }
                                }
                            }
                        }
                    }

                    #endregion Oderdetails List
                }

                if (values[25] != null && values[25] != string.Empty)
                {
                    Prescription.IsView = values[25].ToUpper() == "TRUE" ? true : false;
                }
                Prescription.ErrorCode = values[26];
                Prescription.ErrorDesc = values[27];
                if (values[28] != null && values[28] != string.Empty)
                {
                    #region Shipping Address
                    Prescription.ShippingAdr = new ShippingAddress();
                    foreach (string innerlist in values[28].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            Prescription.ShippingAdr.AddressId = attri[0];
                            Prescription.ShippingAdr.AddressTitle = attri[1];
                            Prescription.ShippingAdr.Street1 = attri[2];
                            Prescription.ShippingAdr.Street2 = attri[3];
                            Prescription.ShippingAdr.StateID = attri[4];
                            Prescription.ShippingAdr.CityID = attri[5];
                            Prescription.ShippingAdr.PinCode = attri[6];
                            Prescription.ShippingAdr.Country = attri[7];
                            Prescription.ShippingAdr.MobileNo = attri[8];
                            Prescription.ShippingAdr.consumer_name = attri[9];
                        }
                    }
                    #endregion
                }
                Prescription.TransactionType = values[29];
                Prescription.EntityKey = values[30];
                Prescription.GUID = values[31];
                Prescription.EntityCode = values[32];

                if (values[33] != null && values[33] != string.Empty)
                {
                    #region Symptoms List
                    Prescription.complaints = new List<PrescriptionClass.complaint>();
                    foreach (string list in values[33].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass.complaint objComplaint = new PrescriptionClass.complaint();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        objComplaint.name = attri[0];
                                        Prescription.complaints.Add(objComplaint);
                                    }
                                }
                            }
                        }
                    }
                    #endregion Symptoms List
                }

                if (values[34] != null && values[34] != string.Empty)
                {
                    #region Diagnosis List
                    Prescription.secondaryAilments = new List<PrescriptionClass.SecondaryAilment>();
                    foreach (string list in values[34].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    PrescriptionClass.SecondaryAilment objAilment = new PrescriptionClass.SecondaryAilment();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    if (attri.Length > 0)
                                    {
                                        objAilment.SecondaryAilmentname = attri[0];
                                        Prescription.secondaryAilments.Add(objAilment);
                                    }
                                }
                            }
                        }
                    }
                    #endregion Diagnosis List
                }
                Prescription.physician_Speciality = values[35];
                Prescription.ServiceAccessTypeID = values[36];
                if (values[37] != null && values[37] != string.Empty)
                {
                    Consultation obj = new Consultation();
                    foreach (string innerlist in values[37].Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            obj.ConsultationFee = attri[0];
                            obj.ReviewDate = attri[1];
                            obj.Speciality = attri[2];
                        }
                    }
                    Prescription.Consultation = obj;
                }

                if (values[38] != null && values[38] != string.Empty)
                {
                    List<Procedure> objList = new List<Procedure>();
                    foreach (string list in values[38].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Procedure ObjProc = new Procedure();
                                    ObjProc.ProcedureID = Convert.ToInt32(attri[0]);
                                    ObjProc.ProcedureCode = attri[1];
                                    ObjProc.ProcedureName = attri[2];
                                    ObjProc.ReportName = attri[3];
                                    objList.Add(ObjProc);
                                }
                            }
                        }
                    }

                    Prescription.Proclist = objList;
                }

                if (values[39] != null && values[39] != string.Empty)
                {
                    List<Procedure> objList = new List<Procedure>();
                    foreach (string list in values[39].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    Procedure ObjTest = new Procedure();
                                    ObjTest.ProcedureID = Convert.ToInt32(attri[0]);
                                    ObjTest.ProcedureCode = attri[1];
                                    ObjTest.ProcedureName = attri[2];
                                    ObjTest.ReportName = attri[3];

                                    objList.Add(ObjTest);
                                }
                            }
                        }
                    }

                    Prescription.Testlist = objList;
                }

                if (values.Length > 40 && values[40] != null && values[40] != string.Empty)
                {
                    Prescription.VitalsLst = new List<Vital_Controls>();
                    foreach (string list in values[40].Split(ListIdentifier_Start, ListIdentifier_End))
                    {
                        if (list != string.Empty)
                        {
                            foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                            {
                                if (innerlist != string.Empty)
                                {
                                    Vital_Controls obj1 = new Vital_Controls();
                                    string[] attri = innerlist.Split(ListProperty_Split);
                                    obj1.CONTROL_TEXT = attri[0];
                                    obj1.CONTROL_TEXT_STYLE = attri[1];
                                    obj1.CONTROL_TEXT_VALUE = attri[2];
                                    obj1.CONTROL_TYPE = attri[3];
                                    if (!string.IsNullOrWhiteSpace(attri[4]))
                                        obj1.DISPLAY_ORDER = Convert.ToInt32(attri[4]);
                                    if (!string.IsNullOrWhiteSpace(attri[5]))
                                        obj1.IS_EXPAND = Convert.ToInt32(attri[5]);
                                    if (!string.IsNullOrWhiteSpace(attri[6]))
                                        obj1.IS_2TEXTBOX = Convert.ToInt32(attri[6]);
                                    Prescription.VitalsLst.Add(obj1);
                                }
                            }
                        }
                    }

                }
            }
            return Prescription;
        }

        public string GetPhysicianSearch_Com_request_Serialize(OP_Consumer_Search request, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (request != null)
            {
                strOutPut.Append(request.PinCode);
                strOutPut.Append(split);
                strOutPut.Append(request.SearchKey);
                strOutPut.Append(split);
                if (request.filterBy != null)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    strOutPut.Append(request.filterBy.All_Test);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.filterBy.DiagnosticName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.filterBy.DiscountSort);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.filterBy.DistanceSort);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.filterBy.ExperienceSort);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.filterBy.Online);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.filterBy.RateSheet);
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                    strOutPut.Append("");
                strOutPut.Append(split);
                if (request.GeoLoc != null)
                {
                    strOutPut.Append(ListIdentifier_Start);
                    strOutPut.Append(request.GeoLoc.CITY_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.GeoLoc.GEO_LATITUDE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.GeoLoc.GEO_LONGITUDE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(request.GeoLoc.SpecialityId);
                    strOutPut.Append(ListIdentifier_End);
                }
                else
                    strOutPut.Append("");
                strOutPut.Append(split);
                strOutPut.Append(request.Radius);
                strOutPut.Append(split);
                strOutPut.Append(request.IsMapDataRequest);
                strOutPut.Append(split);
                strOutPut.Append(request.visitType); 

            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public OP_Consumer_Search GetPhysicianSearch_Com_request_Deserialize(string Response, string token)
        {
            OP_Consumer_Search obj = new OP_Consumer_Search();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);


            obj.PinCode = values[0];
            obj.SearchKey = values[1];
            if (values[2] != string.Empty)
            {
                foreach (string list in values[2].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        FilterBy objF = new FilterBy();
                        string[] val = list.Split(ListProperty_Split);
                        if (!string.IsNullOrWhiteSpace(val[0]))
                            objF.All_Test = Convert.ToInt16(val[0]);
                        if (!string.IsNullOrWhiteSpace(val[1]))
                            objF.DiagnosticName = Convert.ToInt16(val[1]);
                        if (!string.IsNullOrWhiteSpace(val[2]))
                            objF.DiscountSort = Convert.ToInt16(val[2]);
                        if (!string.IsNullOrWhiteSpace(val[3]))
                            objF.DistanceSort = Convert.ToInt16(val[3]);
                        if (!string.IsNullOrWhiteSpace(val[4]))
                            objF.ExperienceSort = Convert.ToInt16(val[4]);
                        if (!string.IsNullOrWhiteSpace(val[5]))
                            objF.Online = Convert.ToInt16(val[5]);
                        if (!string.IsNullOrWhiteSpace(val[6]))
                            objF.RateSheet = Convert.ToInt16(val[6]);
                        obj.filterBy = objF;
                    }
                }
            }
            if (values[3] != string.Empty)
            {
                foreach (string list in values[3].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        GeoLocation geo = new GeoLocation();
                        string[] val = list.Split(ListProperty_Split);
                        if (!string.IsNullOrWhiteSpace(val[0]))
                            geo.CITY_ID = Convert.ToInt16(val[0]);
                        if (!string.IsNullOrWhiteSpace(val[1]))
                            geo.GEO_LATITUDE = Convert.ToDouble(val[1]);
                        if (!string.IsNullOrWhiteSpace(val[2]))
                            geo.GEO_LONGITUDE = Convert.ToDouble(val[2]);
                        if (!string.IsNullOrWhiteSpace(val[3]))
                            geo.SpecialityId = Convert.ToInt16(val[3]);

                        obj.GeoLoc = geo;
                    }
                }
            }
            if (!string.IsNullOrEmpty(values[4]))
                obj.Radius = Convert.ToInt32(values[4]);
            if (!string.IsNullOrEmpty(values[5]))
                obj.IsMapDataRequest = Convert.ToInt32(values[5]);
            if (!string.IsNullOrEmpty(values[6]))
                obj.visitType = Convert.ToInt32(values[6]);

            return obj;
        }


        public string GetPhysicianSplSearchMenu_v1_Com_Serialize(List<OP_Menu_Search> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response != null && Response.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (OP_Menu_Search obj in Response)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.DISPLAY_ORDER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.DISPLAY_TEXT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IMAGE_NAME);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_DISPLAY);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TRANSACTION_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TYPE_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.VALUE_ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ALT_IMAGE_NAME);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<OP_Menu_Search> GetPhysicianSplSearchMenu_v1_Com_Deserialize(string Response, string token)
        {
            List<OP_Menu_Search> searchMenu = new List<OP_Menu_Search>();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        searchMenu = new List<OP_Menu_Search>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                OP_Menu_Search obj1 = new OP_Menu_Search();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.DISPLAY_ORDER = Convert.ToInt32(values[0]);
                                obj1.DISPLAY_TEXT = values[1];
                                obj1.IMAGE_NAME = values[2];
                                if (!string.IsNullOrWhiteSpace(values[3]))
                                    obj1.IS_DISPLAY = Convert.ToInt32(values[3]);
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.TRANSACTION_TYPE = Convert.ToInt32(values[4]);
                                if (!string.IsNullOrWhiteSpace(values[5]))
                                    obj1.TYPE_ID = Convert.ToInt32(values[5]);
                                if (!string.IsNullOrWhiteSpace(values[6]))
                                    obj1.VALUE_ID = Convert.ToInt32(values[6]);
                                obj1.ALT_IMAGE_NAME = values[7];
                                searchMenu.Add(obj1);
                            }

                        }
                    }
                }

            }

            return searchMenu;
        }

        public string GetPhysicianSearch_Com_Serialize(List<Physician> Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response != null && Response.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Physician obj in Response)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.PhysicianID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.UserName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ClinicAddress);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.EntityCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Experience);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Qualification);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Speciality);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.SpecialityID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Integration_Id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Integration_Code);
                    strOutPut.Append(ListProperty_Split);
                    if (obj.Geolocation != null)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(obj.Geolocation.GEO_DISTANCE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LATITUDE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.GEO_LONGITUDE);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.CITY_ID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(obj.Geolocation.CITY);
                        strOutPut.Append(Inner_ListElement_End);
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.EntityId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ClinicName);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Distance);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.MobileNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PROFILE_CODE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.RegistrationNo);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ConsultFee);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.soryby_fee);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ENTITY_MOBILENO);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TELE_CONSULT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.TELE_CONSULT_NUMBER);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.HOME_VISIT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.VIDEO_CONSULTATION);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.PHYSICAL_CONSULTATION);
                    strOutPut.Append(ListElement_End);

                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Physician> GetPhysicianSearch_Com_Deserialize(string Response, string token)
        {
            List<Physician> obj = new List<Physician>();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);

            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {

                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Physician obj1 = new Physician();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.PhysicianID = Convert.ToInt32(values[0]);
                                obj1.UserName = values[1];
                                obj1.ClinicAddress = values[2];
                                obj1.EntityCode = values[3];
                                if (!string.IsNullOrWhiteSpace(values[4]))
                                    obj1.Experience = Convert.ToInt32(values[4]);
                                obj1.Qualification = values[5];
                                obj1.Speciality = values[6];
                                if (!string.IsNullOrWhiteSpace(values[7]))
                                    obj1.SpecialityID = Convert.ToInt32(values[7]);
                                if (!string.IsNullOrWhiteSpace(values[8]))
                                    obj1.Integration_Id = Convert.ToInt32(values[8]);
                                obj1.Integration_Code = values[9];

                                if (values[10] != string.Empty)
                                {
                                    obj1.Geolocation = new GeoLocation();
                                    foreach (string list1 in values[10].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                    {
                                        if (list1 != string.Empty)
                                        {

                                            foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                            {
                                                if (innerlist1 != string.Empty)
                                                {
                                                    string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                    if (!string.IsNullOrWhiteSpace(attri1[0]))
                                                        obj1.Geolocation.GEO_DISTANCE = Convert.ToDouble(attri1[0]);
                                                    if (!string.IsNullOrWhiteSpace(attri1[1]))
                                                        obj1.Geolocation.GEO_LATITUDE = Convert.ToDouble(attri1[1]);
                                                    if (!string.IsNullOrWhiteSpace(attri1[2]))
                                                        obj1.Geolocation.GEO_LONGITUDE = Convert.ToDouble(attri1[2]);
                                                    if (!string.IsNullOrWhiteSpace(attri1[3]))
                                                        obj1.Geolocation.CITY_ID = Convert.ToInt16(attri1[3]);
                                                    obj1.Geolocation.CITY = attri1[4];

                                                }
                                            }
                                        }
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(values[11]))
                                    obj1.EntityId = Convert.ToInt32(values[11]);
                                if (!string.IsNullOrWhiteSpace(values[12]))
                                    obj1.ClinicName = values[12];
                                if (!string.IsNullOrWhiteSpace(values[13]))
                                    obj1.Distance = values[13];
                                if (!string.IsNullOrWhiteSpace(values[14]))
                                    obj1.MobileNo = values[14];
                                if (!string.IsNullOrWhiteSpace(values[15]))
                                    obj1.PROFILE_CODE = values[15];
                                if (!string.IsNullOrWhiteSpace(values[16]))
                                    obj1.RegistrationNo = values[16];
                                if (!string.IsNullOrWhiteSpace(values[17]))
                                    obj1.ConsultFee = Convert.ToDecimal(values[17]);
                                if (!string.IsNullOrWhiteSpace(values[18]))
                                    obj1.soryby_fee = Convert.ToDecimal(values[18]);
                                if (!string.IsNullOrWhiteSpace(values[19]))
                                    obj1.ENTITY_MOBILENO = Convert.ToString(values[19]);
                                if (values.Count() > 20 && !string.IsNullOrWhiteSpace(values[20]))
                                    obj1.TELE_CONSULT = Convert.ToInt32(values[20]);
                                if (values.Count() > 21 && !string.IsNullOrWhiteSpace(values[21]))
                                    obj1.TELE_CONSULT_NUMBER = Convert.ToString(values[21]);
                                if (values.Count() > 22 && !string.IsNullOrWhiteSpace(values[22]))
                                    obj1.HOME_VISIT = Convert.ToString(values[22]);
                                if (values.Count() > 23 && !string.IsNullOrWhiteSpace(values[23]))
                                    obj1.VIDEO_CONSULTATION = Convert.ToString(values[23]);
                                if (values.Count() > 24 && !string.IsNullOrWhiteSpace(values[24]))
                                    obj1.PHYSICAL_CONSULTATION = Convert.ToString(values[24]);
                                obj.Add(obj1);
                            }

                        }
                    }
                }

            }

            return obj;
        }

        public string GetEntityList_Search_Serialize(List<Entity> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);

            foreach (Entity objEntity in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objEntity.EntityID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objEntity.EntityCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objEntity.EntityName);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Entity> GetEntityList_Search_Deserialize(string Response, string token)
        {
            List<Entity> EntityList = new List<Entity>();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Entity objEntity = new Entity();
                                string[] attri = innerlist.Split(ListProperty_Split);
                                if (attri[0] != string.Empty)
                                    objEntity.EntityID = Convert.ToInt32(attri[0]);
                                objEntity.EntityCode = attri[1];
                                objEntity.EntityName = attri[2];
                                EntityList.Add(objEntity);
                            }
                        }
                    }
                }
            }
            return EntityList;
        }

        public string GetTeleConsultCount_Serialize(TeleConsultUtilization Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(Response.Teleconsult_Count_Config);
            outPut.Append(split);
            outPut.Append(Response.Teleconsult_Utilized);
            outPut.Append(split);
            outPut.Append(Response.Teleconsult_Available);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }


        public TeleConsultUtilization GetTeleConsultCount_Deserialize(string Response, string token)
        {
            TeleConsultUtilization objTeleConsult = new TeleConsultUtilization();
            string strResponse = StringCipher.Decrypt(Response, token);
            string[] attri = strResponse.Split(split);
            objTeleConsult.Teleconsult_Count_Config = attri[0];
            objTeleConsult.Teleconsult_Utilized = attri[1];
            objTeleConsult.Teleconsult_Available = attri[2];
            return objTeleConsult;
        }

    }
}

