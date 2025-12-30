using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class ReqRes_Consumer
    {
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

        public string GetConsumerTheme_Response_Serialize(Consumer_Theme obj, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(obj.ADDRESSTEXT_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.BAR_BACKGROUND);
            strOutPut.Append(split);
            strOutPut.Append(obj.BUTTONTEXT_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.COLOR1);
            strOutPut.Append(split);
            strOutPut.Append(obj.COLOR2);
            strOutPut.Append(split);
            strOutPut.Append(obj.COLOR3);
            strOutPut.Append(split);
            strOutPut.Append(obj.COLOR4);
            strOutPut.Append(split);
            strOutPut.Append(obj.COLOR5);
            strOutPut.Append(split);
            strOutPut.Append(obj.COLOR6);
            strOutPut.Append(split);
            strOutPut.Append(obj.COLOR7);
            strOutPut.Append(split);
            strOutPut.Append(obj.CONTENTPAGE_BACKGROUND);
            strOutPut.Append(split);
            strOutPut.Append(obj.CORPORATE_CODE);
            strOutPut.Append(split);
            strOutPut.Append(obj.DASHBOARD_BACKGROUND);
            strOutPut.Append(split);
            strOutPut.Append(obj.DASHBOARD_SPLIT_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.ENDLAYOUTBUTTON1);
            strOutPut.Append(split);
            strOutPut.Append(obj.ENDLAYOUTBUTTON2);
            strOutPut.Append(split);
            strOutPut.Append(obj.ENTRYTEXT_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.HEADER_BACKROUND_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.HEADER_LABLE_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.HOMEPAGE_HEADER_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.LABLE_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.LINK_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.MENUARROW_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.MENU_BACKROUND_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.MENU_HEADER_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.MENU_TEXT_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.NORMAL_BUTTON);
            strOutPut.Append(split);
            strOutPut.Append(obj.PLACEHOLDER_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.PROFILELBL_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.SINGLE_BUTTON_ENDLAYOUT);
            strOutPut.Append(split);
            strOutPut.Append(obj.TITLE_COLOR);
            strOutPut.Append(split);
            strOutPut.Append(obj.HOMEPAGE_BGIMG);
            strOutPut.Append(split);
            strOutPut.Append(obj.NORMAL_BUTTON2);
            strOutPut.Append(split);
            strOutPut.Append(obj.NORMAL_BUTTON3);
            strOutPut.Append(split);
            strOutPut.Append(obj.ECARD_LOGO);
            strOutPut.Append(split);
            strOutPut.Append(obj.ECARD_WATERMARK1);
            strOutPut.Append(split);
            strOutPut.Append(obj.ECARD_WATERMARK2);
            strOutPut.Append(split);
            strOutPut.Append(obj.ECARD_CONTENT);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
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
            strOutPut.Append(obj.ShowReportAutomatic);
            strOutPut.Append(split);
            strOutPut.Append(obj.is_show_prescription_depend);
            strOutPut.Append(split);
            strOutPut.Append(obj.CorporateCode);
            strOutPut.Append(split);
            strOutPut.Append(obj.broker_code);

            return StringCipher.Encrypt(strOutPut.ToString(), key);
        }

        public Consumer_Theme GetConsumerTheme_Response_Deserialize(string Response,string token)
        {
            Consumer_Theme obj = new Consumer_Theme();

            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            obj.ADDRESSTEXT_COLOR = values[0];
            obj.BAR_BACKGROUND = values[1];
            obj.BUTTONTEXT_COLOR = values[2];
            obj.COLOR1 = values[3];
            obj.COLOR2 = values[4];
            obj.COLOR3 = values[5];
            obj.COLOR4 = values[6];
            obj.COLOR5 = values[7];
            obj.COLOR6 = values[8];
            obj.COLOR7 = values[9];
            obj.CONTENTPAGE_BACKGROUND = values[10];
            obj.CORPORATE_CODE = values[11];
            obj.DASHBOARD_BACKGROUND = values[12];
            obj.DASHBOARD_SPLIT_COLOR = values[13];
            obj.ENDLAYOUTBUTTON1 = values[14];
            obj.ENDLAYOUTBUTTON2 = values[15];
            obj.ENTRYTEXT_COLOR = values[16];
            obj.HEADER_BACKROUND_COLOR = values[17];
            obj.HEADER_LABLE_COLOR = values[18];
            obj.HOMEPAGE_HEADER_COLOR = values[19];
            obj.LABLE_COLOR = values[20];
            obj.LINK_COLOR = values[21];
            obj.MENUARROW_COLOR = values[22];
            obj.MENU_BACKROUND_COLOR = values[23];
            obj.MENU_HEADER_COLOR = values[24];
            obj.MENU_TEXT_COLOR = values[25];
            obj.NORMAL_BUTTON = values[26];
            obj.PLACEHOLDER_COLOR = values[27];
            obj.PROFILELBL_COLOR = values[28];
            obj.SINGLE_BUTTON_ENDLAYOUT = values[29];
            obj.TITLE_COLOR = values[30];
            obj.HOMEPAGE_BGIMG = values[31];
            obj.NORMAL_BUTTON2 = values[32];
            obj.NORMAL_BUTTON3 = values[33];
            obj.ECARD_LOGO = values[34];
            obj.ECARD_WATERMARK1 = values[35];
            obj.ECARD_WATERMARK2 = values[36];
            obj.ECARD_CONTENT = values[37];

            return obj;
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

            if (!string.IsNullOrEmpty(values[22]))
                obj.ShowReportAutomatic = Convert.ToInt32(values[22]);

            if (!string.IsNullOrEmpty(values[23]))
                obj.is_show_prescription_depend = Convert.ToInt32(values[23]);

            if (values.Length > 24 && !string.IsNullOrEmpty(values[24]))
                obj.CorporateCode = values[24];
            if (values.Length > 25 && !string.IsNullOrEmpty(values[25]))
                obj.broker_code = values[25];
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
        public static string EncryptKey()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes("M+PRbWXZn4j3QIJjMfjtltFkRS4A4XgdH9zfLY4NKG0=");
            byte[] messageBytes = encoding.GetBytes("ICICI");
            System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);
            byte[] bytes = cryptographer.ComputeHash(messageBytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public string Utils_Config_Serialize(Utils_Config ObjIssue, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ObjIssue.Location_Capping_KM);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.Location_Capping_Timeout_HR);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }
        public Utils_Config Utils_Config_DeSerialize(string Response, string token)
        {
            Utils_Config objCustomerIssue = new Utils_Config();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objCustomerIssue.Location_Capping_KM = Convert.ToDouble(values[0]);
            if (values[1] != string.Empty)
                objCustomerIssue.Location_Capping_Timeout_HR = Convert.ToInt32(values[1]);
            return objCustomerIssue;
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
                outPut.Append(objRem.OrderByDateTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.LastFetchTime);
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
                            if (!string.IsNullOrEmpty(attri[14]))
                                objRem.OrderByDateTime = Convert.ToDateTime(attri[14], culture);
                            if (attri.Length > 15 && !string.IsNullOrEmpty(attri[15]))
                                objRem.LastFetchTime = attri[15];

                            RemList.Add(objRem);
                        }
                    }
                }
            }
            return RemList;
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
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
        }

        public string City_Serialize(City Response, string token)
        {
            StringBuilder objOutPut = new StringBuilder();
            objOutPut.Append(Response.CityID);
            objOutPut.Append(split);
            objOutPut.Append(Response.CityName);
            return StringCipher.Encrypt(objOutPut.ToString(), token);
        }


        public City City_Deserialize(string Response, string token)
        {
            City obj = new City();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                obj.CityID = Convert.ToInt32(values[0]);
            obj.CityName = values[1];
            return obj;
        }

        public string GetPresc_Sync_Serialize(List<PrescriptionClass> lstobjpre, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (PrescriptionClass objpre in lstobjpre)
            {
                strOutPut.Append(ListElement_Start);

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
                        strOutPut.Append(objdrug.Evening);
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
                        strOutPut.Append(objdrug.DRUG_TYPE);
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

                strOutPut.Append(ListProperty_Split);

                //FeedBackDetails
                if (objpre.FeedBackDetails != null && objpre.FeedBackDetails.Count > 0)
                {
                    strOutPut.Append(Inner_ListIdentifier_Start);
                    foreach (Feedback objOrder in objpre.FeedBackDetails)
                    {
                        strOutPut.Append(Inner_ListElement_Start);

                        strOutPut.Append(objOrder.OrderID);
                        strOutPut.Append(Inner_ListProperty_Split);

                        strOutPut.Append(objOrder.prescription_id);
                        strOutPut.Append(Inner_ListProperty_Split);

                        strOutPut.Append(objOrder.Order_Date);
                        strOutPut.Append(Inner_ListProperty_Split);

                        strOutPut.Append(objOrder.PatientName);
                        strOutPut.Append(Inner_ListProperty_Split);

                        strOutPut.Append(objOrder.ServiceEntityName);
                        strOutPut.Append(Inner_ListProperty_Split);

                        strOutPut.Append(objOrder.Transaction_Type);

                        strOutPut.Append(Inner_ListElement_End);
                    }
                    strOutPut.Append(Inner_ListIdentifier_End);
                }
                else
                {
                    strOutPut.Append("");
                }


                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.Hasfeedback);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.LastFetchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.IsOfflinePrescription);
                strOutPut.Append(ListElement_End);

            }
            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetPresc_Sync_Deserialize(string Response, string token)
        {
            List<PrescriptionClass> lstpres = new List<PrescriptionClass>();

            string strResponse = StringCipher.Decrypt(Response, token);

            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {


                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            PrescriptionClass objPres = new PrescriptionClass();
                            string[] values = innerlist.Split(ListProperty_Split); ;

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
                                foreach (string innerElement in values[18].Split(Inner_ListElement_Start, Inner_ListElement_End))
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

                            if (values[19] != null && values[19] != string.Empty)
                            {
                                List<Drug> objList = new List<Drug>();
                                foreach (string innerIdentifier in values[19].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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
                                                    objDrug.Evening = Convert.ToInt32(attri[4]);
                                                if (attri[5] != string.Empty)
                                                    objDrug.Morning = Convert.ToInt32(attri[5]);
                                                if (attri[6] != string.Empty)
                                                    objDrug.Night = Convert.ToInt32(attri[6]);
                                                if (attri[7] != string.Empty)
                                                    objDrug.BeforeFood = Convert.ToInt32(attri[7]);
                                                objDrug.DRUG_TYPE_DESC = attri[8];
                                                objDrug.DosageA = attri[9];
                                                objDrug.DosageM = attri[10];
                                                objDrug.DosageN = attri[11];
                                                objDrug.Prescription_id = attri[12];
                                                if (attri[13] != string.Empty)
                                                    objDrug.DRUG_TYPE = Convert.ToInt32(attri[13]);
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
                                foreach (string innerElement in values[20].Split(Inner_ListElement_Start, Inner_ListElement_End))
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

                            if (values[21] != null && values[21] != string.Empty)
                            {

                                List<Diagnosis> objList = new List<Diagnosis>();
                                foreach (string innerIdentifier in values[21].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            if (values[22] != null && values[22] != string.Empty)
                            {
                                List<Oderdetails> objList = new List<Oderdetails>();
                                foreach (string InnerIdentifier in values[22].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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


                            if (values[23] != null && values[23] != string.Empty)
                            {
                                List<Procedure> objList = new List<Procedure>();
                                foreach (string InnerIdentifier in values[23].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            if (values[24] != null && values[24] != string.Empty)
                            {
                                List<Procedure> objList = new List<Procedure>();
                                foreach (string InnerIdentifier in values[24].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            if (values[25] != null && values[25] != string.Empty)
                            {
                                List<Ailment> objList = new List<Ailment>();
                                foreach (string InnerIdentifier in values[25].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            if (values[26] != null && values[26] != string.Empty)
                            {
                                List<PrescriptionClass.complaint> objList = new List<PrescriptionClass.complaint>();
                                foreach (string InnerIdentifier in values[26].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            objPres.pharmacyId = values[27];
                            if (values[28] != string.Empty)
                                objPres.Is_health_check = Convert.ToInt32(values[28]);

                            if (values[29] != null && values[29] != string.Empty)
                            {
                                objPres.HCU = new HealthCheckup();
                                foreach (string InnerIdentifier in values[29].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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
                            if (values[30] != string.Empty)
                                objPres.AutoShowReport = Convert.ToInt32(values[30]);


                            if (values[31] != null && values[31] != string.Empty)
                            {
                                objPres.AttachmentsLst = new List<OP_Attachments>();
                                foreach (string InnerIdentifier in values[31].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            if (values.Length > 32 && values[32] != null && values[32] != string.Empty)
                            {
                                objPres.VitalsLst = new List<Vital_Controls>();
                                foreach (string InnerIdentifier in values[32].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            if (values.Length > 33 && values[33] != null && values[33] != string.Empty)
                            {
                                objPres.Diagnostic_Range = new List<DiagnosticRange>();
                                foreach (string InnerIdentifier in values[33].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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

                            if (values[34] != null && values[34] != string.Empty)
                            {
                                List<PrescriptionClass.SecondaryAilment> objList = new List<PrescriptionClass.SecondaryAilment>();
                                foreach (string InnerIdentifier in values[34].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
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
                            if (values[35] != null && values[35] != string.Empty)
                            {
                                objPres.HasDiagnostic = Convert.ToInt32(values[35].ToString());
                            }

                            if (values[36] != null && values[36] != string.Empty)
                            {
                                objPres.HasDiagnosticOrder = Convert.ToInt32(values[36].ToString());
                            }
                            if (values[37] != null && values[37] != string.Empty)
                            {
                                objPres.OrderByOrderDate = Convert.ToDateTime(values[37].ToString(), culture);
                            }
                            if (values[38] != null && values[38] != string.Empty)
                            {
                                objPres.OrderByPrescDate = Convert.ToDateTime(values[38].ToString(), culture);
                            }
                            if (values[39] != null && values[39] != string.Empty)
                            {
                                objPres.IsView = Convert.ToBoolean(values[39].ToString());
                            }
                            if (values[40] != null && values[40] != string.Empty)
                            {
                                objPres.HasDrug = Convert.ToInt32(values[40].ToString());
                            }
                            if (values[41] != null && values[41] != string.Empty)
                            {
                                objPres.patient_id = Convert.ToString(values[41]);
                            }
                            if (values[42] != null && values[42] != string.Empty)
                            {
                                objPres.HasPharmachyOrder = Convert.ToInt32(values[42]);
                            }

                            if (values[43] != null && values[43] != string.Empty)
                            {
                                List<Feedback> objFeedBackDetails = new List<Feedback>();
                                foreach (string InnerIdentifier in values[43].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (InnerIdentifier != string.Empty)
                                    {
                                        foreach (string InnerElement in InnerIdentifier.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (InnerElement != string.Empty)
                                            {
                                                string[] attri = InnerElement.Split(Inner_ListProperty_Split);
                                                Feedback ObjOrder = new Feedback();
                                                ObjOrder.OrderID = attri[0];
                                                ObjOrder.prescription_id = attri[1];
                                                ObjOrder.Order_Date = attri[2];
                                                ObjOrder.PatientName = attri[3];
                                                ObjOrder.ServiceEntityName = attri[4];
                                                ObjOrder.Transaction_Type = Convert.ToInt32(attri[5]);


                                                objFeedBackDetails.Add(ObjOrder);
                                            }
                                        }
                                    }
                                }


                                objPres.FeedBackDetails = objFeedBackDetails;
                                if (values[44] != null && values[44] != string.Empty)
                                {
                                    objPres.Hasfeedback = Convert.ToInt32(values[44]);
                                }
                            }

                            if (values.Count() > 45 && values[45] != null && values[45] != string.Empty)
                            {
                                objPres.LastFetchTime = values[45];
                            }

                            if (values.Count() > 46 && values[46] != null && values[46] != string.Empty)
                            {
                                objPres.IsOfflinePrescription =Convert.ToInt32(values[46]);
                            }

                            lstpres.Add(objPres);
                        }
                    }

                }
            }
            return lstpres;
        }

        public string GetPatientVitalDashboardV1_Pat_Serialize(List<PrescriptionClass> objResposne, string token)
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
                strOutPut.Append(PreClass.OrderByPrescDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.LastFetchTime);
                strOutPut.Append(ListElement_End);
            }
            strOutPut.Append(ListIdentifier_End);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetPatientVitalDashboardV1_Pat_Deserialize(string Response, string Token)
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

                                                        objLst.Add(Obj);
                                                    }
                                                }
                                            }
                                        }

                                        objPres.AttachmentsLst = objLst;
                                    }
                                    objPres.patient_id = values[7];
                                    objPres.MemberID = values[8];
                                    if (!string.IsNullOrEmpty(values[9]))
                                    {
                                        objPres.OrderByPrescDate = Convert.ToDateTime(values[9], culture);
                                    }

                                    if (values.Count() > 9 && !string.IsNullOrEmpty(values[10]))
                                    {
                                        objPres.LastFetchTime = values[10];
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

        public string GetPatientAddress_Serialize(List<ShippingAddress> objRes, string token)
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
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.locality);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.company_name);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.primary_emailid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.secondary_emailid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.address_type);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<ShippingAddress> GetPatientAddress_Deserialize(string Response, string Token)
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
                            obj.locality = attri[11];
                            obj.company_name = attri[12];
                            obj.primary_emailid = attri[13];
                            obj.secondary_emailid = attri[14];
                            obj.address_type = attri[15];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetPatientAddress_Serialize_V1(List<ShippingAddress> objRes, string token)
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
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.locality);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.company_name);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.primary_emailid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.secondary_emailid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.address_type);

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.UserID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.IPAddress);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.DeviceID);

                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<ShippingAddress> GetPatientAddress_Deserialize_V1(string Response, string Token)
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
                            obj.locality = attri[11];
                            obj.company_name = attri[12];
                            obj.primary_emailid = attri[13];
                            obj.secondary_emailid = attri[14];
                            obj.address_type = attri[15];

                            obj.UserID = attri[16];
                            obj.IPAddress = attri[17];
                            obj.DeviceID = attri[18];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetAppDashV1_Pat_Serialize(List<Appointment> objResposne, string token)
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
                strOutPut.Append(objApp.LastFetchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Integration_Id);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.Intergration_code);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PractoAcessToken);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityName);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.EntityMobileNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientMobileNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientEmailID);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Appointment> GetAppDashV1_Pat_Deserialize(string Response, string Token)
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
                                obj.PatientId = Convert.ToInt16(attri[5]);
                            obj.PatientName = attri[6];
                            if (attri[7] != string.Empty)
                                obj.PhysicianId = Convert.ToInt16(attri[7]);
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
                                    obj.OrderByAppDate = Convert.ToDateTime(attri[17], culture);
                            }

                            if (attri.Count() > 18)
                            {
                                if (!string.IsNullOrEmpty(attri[18]))
                                    obj.LastFetchTime = attri[18];
                            }
                            if (attri.Count() > 19)
                            {
                                if (!string.IsNullOrEmpty(attri[19]))
                                    obj.Integration_Id = Convert.ToInt32(attri[19]);
                            }
                            if (attri.Count() > 20)
                            {
                                if (!string.IsNullOrEmpty(attri[20]))
                                    obj.Intergration_code = attri[20];
                            }
                            if (attri.Count() > 21)
                            {
                                if (!string.IsNullOrEmpty(attri[21]))
                                    obj.PractoAcessToken = attri[21];
                            }
                            if (!string.IsNullOrEmpty(attri[22]))
                                obj.EntityName = attri[22];
                            if (!string.IsNullOrEmpty(attri[23]))
                                obj.EntityMobileNo = attri[23];
                            if (!string.IsNullOrEmpty(attri[24]))
                                obj.PatientMobileNo = attri[24];
                            if (!string.IsNullOrEmpty(attri[25]))
                                obj.PatientEmailID = attri[25];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string Boolean_Response_serialize(bool Response, string token)
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

        public string GetNotiV1_Pat_Serialize(List<NotificationClass> objResposne, string token)
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
                strOutPut.Append(objApp.LastFetchTime);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<NotificationClass> GetNotiV1_Pat_Deserialize(string Response, string Token)
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

                            if (attri.Count() > 11 && !string.IsNullOrEmpty(attri[11]))
                            {
                                obj.LastFetchTime = attri[11];
                            }

                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
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
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.locality);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.company_name);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.primary_emailid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.secondary_emailid);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objS.address_type);
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
                            obj.locality = attri[11];
                            obj.company_name = attri[12];
                            obj.primary_emailid = attri[13];
                            obj.secondary_emailid = attri[14];
                            obj.address_type = attri[15];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

        public string GetCustomerIssueMaster_Serialize(List<CustomerIssue> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);
            foreach (CustomerIssue CustomerIssueMasterList in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(CustomerIssueMasterList.ISSUE_ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(CustomerIssueMasterList.ISSUE_NAME);
                outPut.Append(ListProperty_Split);
                outPut.Append(CustomerIssueMasterList.ToEmailId);
                outPut.Append(ListElement_End);
            }
            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<CustomerIssue> GetCustomerIssueMaster_Deserialize(string Response, string token)
        {
            List<CustomerIssue> CustomerIssueMasterList = new List<CustomerIssue>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            CustomerIssue CustomerIssueMaster = new CustomerIssue();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                CustomerIssueMaster.ISSUE_ID = Convert.ToInt32(attri[0]);
                            if (attri[1] != string.Empty)
                                CustomerIssueMaster.ISSUE_NAME = attri[1];
                            if (attri.Length > 2 && attri[2] != string.Empty)
                                CustomerIssueMaster.ToEmailId = attri[2];

                            CustomerIssueMasterList.Add(CustomerIssueMaster);
                        }
                    }
                }
            }
            return CustomerIssueMasterList;
        }

        public string OP_CustomerIssue_Serialize(CustomerIssue ObjIssue, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ObjIssue.ISSUE_ID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.ISSUE_NAME);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.ISSUE_DESCRIPTION);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.PatienID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.Payercode);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.CREATED_BY);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.MODIFIED_BY);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.DEVICEID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.VISITORSIP);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public CustomerIssue OP_CustomerIssue_DeSerialize(string Response, string token)
        {
            CustomerIssue objCustomerIssue = new CustomerIssue();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objCustomerIssue.ISSUE_ID = Convert.ToInt16(values[0]);
            if (values[1] != string.Empty)
                objCustomerIssue.ISSUE_NAME = Convert.ToString(values[1]);
            if (values[2] != string.Empty)
                objCustomerIssue.ISSUE_DESCRIPTION = Convert.ToString(values[2]);
            if (values[3] != string.Empty)
                objCustomerIssue.PatienID = Convert.ToString(values[3]);
            if (values[4] != string.Empty)
                objCustomerIssue.Payercode = Convert.ToString(values[4]);
            if (values.Length >= 6 && values[5] != string.Empty)
                objCustomerIssue.CREATED_BY = Convert.ToString(values[5]);
            if (values.Length >= 7 && values[6] != string.Empty)
                objCustomerIssue.MODIFIED_BY = Convert.ToString(values[6]);
            if (values.Length >= 8 && values[7] != string.Empty)
                objCustomerIssue.DEVICEID = Convert.ToString(values[7]);
            if (values.Length >= 9 && values[8] != string.Empty)
                objCustomerIssue.VISITORSIP = Convert.ToString(values[8]);
            return objCustomerIssue;
        }

        public string OP_OfflineCheckList_Serialize(OP_OfflineCheckList obj, string token)
        {
            StringBuilder strOutPut = new StringBuilder();

            strOutPut.Append(obj.Appointment_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.FAQ_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.GetcontactEmalID);
            strOutPut.Append(split);
            strOutPut.Append(obj.GetCoverages);
            strOutPut.Append(split);
            strOutPut.Append(obj.HowToUse);
            strOutPut.Append(split);
            strOutPut.Append(obj.InsBenefitUtil_Consult_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.InsBenefitUtil_Diag_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.InsBenefitUtil_Phar_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.InsPolicyCoverData);
            strOutPut.Append(split);
            strOutPut.Append(obj.LookUp_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.Medicine_Reminder_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.NotificationDashboard_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.RateUs_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.Transaction_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.Utils_Config_Count);
            strOutPut.Append(split);
            strOutPut.Append(obj.VitalsDashboard_Count);

            //Webapi_Para class
            strOutPut.Append(split);
            if (obj.Webapi_Para != null)
            {
                strOutPut.Append(obj.Webapi_Para.Appointment_LastFeatchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.MemberNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.Mobile);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.Notification_LastFeatchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.PayerCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.Reminder_LastFeatchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.Trans_LastFeatchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.Trans_NumRow);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.Trans_PageNo);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.UserID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.UserType);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(obj.Webapi_Para.Vital_LastFeatchTime);
            }
            else
                strOutPut.Append("");

            strOutPut.Append(split);
            strOutPut.Append(obj.Reimbursement_Count);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public OP_OfflineCheckList OP_OfflineCheckList_Deserialize(string Response, string token)
        {
            OP_OfflineCheckList obj = new OP_OfflineCheckList();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                obj.Appointment_Count = Convert.ToInt32(values[0]);
            if (values[1] != string.Empty)
                obj.FAQ_Count = Convert.ToInt32(values[1]);
            obj.GetcontactEmalID = values[2];
            if (values[3] != string.Empty)
                obj.GetCoverages = Convert.ToInt32(values[3]);
            if (values[4] != string.Empty)
                obj.HowToUse = Convert.ToInt32(values[4]);
            if (values[5] != string.Empty)
                obj.InsBenefitUtil_Consult_Count = Convert.ToInt32(values[5]);
            if (values[6] != string.Empty)
                obj.InsBenefitUtil_Diag_Count = Convert.ToInt32(values[6]);
            if (values[7] != string.Empty)
                obj.InsBenefitUtil_Phar_Count = Convert.ToInt32(values[7]);
            if (values[8] != string.Empty)
                obj.InsPolicyCoverData = Convert.ToInt32(values[8]);
            if (values[9] != string.Empty)
                obj.LookUp_Count = Convert.ToInt32(values[9]);
            if (values[10] != string.Empty)
                obj.Medicine_Reminder_Count = Convert.ToInt32(values[10]);
            if (values[11] != string.Empty)
                obj.NotificationDashboard_Count = Convert.ToInt32(values[11]);
            if (values[12] != string.Empty)
                obj.RateUs_Count = Convert.ToInt32(values[12]);
            if (values[13] != string.Empty)
                obj.Transaction_Count = Convert.ToInt32(values[13]);
            if (values[14] != string.Empty)
                obj.Utils_Config_Count = Convert.ToInt32(values[14]);
            if (values[15] != string.Empty)
                obj.VitalsDashboard_Count = Convert.ToInt32(values[15]);

            if (values[16] != string.Empty)
            {
                obj.Webapi_Para = new OfflineCheckList_Para();
                string[] values1 = values[16].Split(ListProperty_Split);

                obj.Webapi_Para.Appointment_LastFeatchTime = values1[0];
                obj.Webapi_Para.MemberNo = values1[1];
                obj.Webapi_Para.Mobile = values1[2];
                obj.Webapi_Para.Notification_LastFeatchTime = values1[3];
                obj.Webapi_Para.PayerCode = values1[4];
                obj.Webapi_Para.Reminder_LastFeatchTime = values1[5];
                obj.Webapi_Para.Trans_LastFeatchTime = values1[6];
                if (values1[7] != string.Empty)
                    obj.Webapi_Para.Trans_NumRow = Convert.ToInt32(values1[7]);
                if (values1[8] != string.Empty)
                    obj.Webapi_Para.Trans_PageNo = Convert.ToInt32(values1[8]);
                obj.Webapi_Para.UserID = values1[9];
                if (values1[10] != string.Empty)
                    obj.Webapi_Para.UserType = Convert.ToInt32(values1[10]);
                obj.Webapi_Para.Vital_LastFeatchTime = values1[11];

            }

            if (values.Length > 16)
            {
                if (values[17] != string.Empty)
                    obj.Reimbursement_Count = Convert.ToInt32(values[17]);
            }
            return obj;
        }

        public string OP_IntegrationRequestLogs_Serialize(IntegrationRequestLogs ObjIssue, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ObjIssue.Integration_Request);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.Source);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.TRIGGER_USER_ID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.PATIENT_ID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.GUID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.INTEGRATION_ID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.IPAddress);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.DeviceID);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.Latitude);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.Longitude);
            strOutPut.Append(split);
            strOutPut.Append(ObjIssue.City_ID);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public IntegrationRequestLogs OP_IntegrationRequestLogs_DeSerialize(string Response, string token)
        {
            IntegrationRequestLogs objIntegrationRequestLogs = new IntegrationRequestLogs();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objIntegrationRequestLogs.Integration_Request = Convert.ToString(values[0]);
            if (values[1] != string.Empty)
                objIntegrationRequestLogs.Source = Convert.ToString(values[1]);
            if (values[2] != string.Empty)
                objIntegrationRequestLogs.TRIGGER_USER_ID = Convert.ToString(values[2]);
            if (values[3] != string.Empty)
                objIntegrationRequestLogs.PATIENT_ID = Convert.ToString(values[3]);
            if (values[4] != string.Empty)
                objIntegrationRequestLogs.GUID = Convert.ToString(values[4]);
            if (values.Count() > 5 && !string.IsNullOrEmpty(values[5]))
            {
                objIntegrationRequestLogs.INTEGRATION_ID = Convert.ToInt32(values[5]);
                objIntegrationRequestLogs.IPAddress = Convert.ToString(values[6]);
                objIntegrationRequestLogs.DeviceID = Convert.ToString(values[7]);
            }
            if (values.Count() > 8 && !string.IsNullOrEmpty(values[8]))
            {
                objIntegrationRequestLogs.Latitude = Convert.ToString(values[8]);
                objIntegrationRequestLogs.Longitude = Convert.ToString(values[9]);
                if (!string.IsNullOrEmpty(values[10]))
                    objIntegrationRequestLogs.City_ID = Convert.ToInt32(values[10]);
            }
            return objIntegrationRequestLogs;
        }

        public string OP_HardwareExceptionLogs_Serialize(List<HardwareException> objlist, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);

            foreach (HardwareException objHardExc in objlist)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objHardExc.ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.PatientID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.ModelNo);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.Make);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.ExceptionMsg);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.StackTrace);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.NetworkType);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.OsVersion);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.Memory);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.AppName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.BandWidthSpeed);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.isHostReachable);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.ErrorDate);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.OsType);
                outPut.Append(ListProperty_Split);
                outPut.Append(objHardExc.HardwareDevice);
                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<HardwareException> OP_HardwareExceptionLogs_DeSerialize(string Response, string token)
        {
            List<HardwareException> ListobjHardExc = new List<HardwareException>();
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
                            HardwareException objHardExc = new HardwareException();
                            if (attri[0] != string.Empty)
                                objHardExc.ID = Convert.ToInt16(attri[0]);
                            if (attri[1] != string.Empty)
                                objHardExc.PatientID = Convert.ToString(attri[1]);
                            if (attri[2] != string.Empty)
                                objHardExc.ModelNo = Convert.ToString(attri[2]);
                            if (attri[3] != string.Empty)
                                objHardExc.Make = Convert.ToString(attri[3]);
                            if (attri[4] != string.Empty)
                                objHardExc.ExceptionMsg = Convert.ToString(attri[4]);
                            if (attri[5] != string.Empty)
                                objHardExc.StackTrace = Convert.ToString(attri[5]);
                            if (attri[6] != string.Empty)
                                objHardExc.NetworkType = Convert.ToString(attri[6]);
                            if (attri[7] != string.Empty)
                                objHardExc.OsVersion = Convert.ToString(attri[7]);
                            if (attri[8] != string.Empty)
                                objHardExc.Memory = Convert.ToString(attri[8]);
                            if (attri[9] != string.Empty)
                                objHardExc.AppName = Convert.ToString(attri[9]);
                            if (attri[10] != string.Empty)
                                objHardExc.BandWidthSpeed = Convert.ToString(attri[10]);
                            if (attri[11] != string.Empty)
                                objHardExc.isHostReachable = Convert.ToString(attri[11]);
                            if (attri[12] != string.Empty)
                                objHardExc.ErrorDate = Convert.ToString(attri[12]);
                            if (attri[13] != string.Empty)
                                objHardExc.OsType = Convert.ToString(attri[13]);
                            if (attri[14] != string.Empty)
                                objHardExc.HardwareDevice = Convert.ToString(attri[14]);

                            ListobjHardExc.Add(objHardExc);
                        }
                    }
                }
            }
            return ListobjHardExc;
        }
        public string PharmacyRefundUpdate_Serialize(PharmacyRefundUpdate ObjPharRef, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ObjPharRef.ORDER_ID);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.USER_ID);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.ISRECIVED);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.PayerCode);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.OneMgOrderId);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.CREATED_BY);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.MODIFIED_BY);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.DEVICEID);
            strOutPut.Append(split);
            strOutPut.Append(ObjPharRef.VISITORIP);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PharmacyRefundUpdate PharmacyRefundUpdate_DeSerialize(string Response, string token)
        {
            PharmacyRefundUpdate objPharmacyRefundUpdate = new PharmacyRefundUpdate();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            if (values[0] != string.Empty)
                objPharmacyRefundUpdate.ORDER_ID = Convert.ToString(values[0]);
            if (values[1] != string.Empty)
                objPharmacyRefundUpdate.USER_ID = Convert.ToString(values[1]);
            if (values[2] != string.Empty)
            {
                objPharmacyRefundUpdate.ISRECIVED = Convert.ToInt32(values[2]);
            }
            if (values[3] != string.Empty)
                objPharmacyRefundUpdate.PayerCode = Convert.ToString(values[3]);
            if (values[4] != string.Empty)
                objPharmacyRefundUpdate.OneMgOrderId = Convert.ToString(values[4]);
            if (values[5] != string.Empty)
                objPharmacyRefundUpdate.CREATED_BY = Convert.ToString(values[5]);
            if (values[6] != string.Empty)
                objPharmacyRefundUpdate.MODIFIED_BY = Convert.ToString(values[6]);
            if (values[7] != string.Empty)
                objPharmacyRefundUpdate.DEVICEID = Convert.ToString(values[7]);
            if (values[8] != string.Empty)
                objPharmacyRefundUpdate.VISITORIP = Convert.ToString(values[8]);

            return objPharmacyRefundUpdate;
        }

        public string GetOnemgURLToken_Serialize(OnemgTokenClassRequest obj, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (obj != null)
            {
                strOutPut.Append(obj.doctor_id);
                strOutPut.Append(split);
                strOutPut.Append(obj.clinic_id);
                strOutPut.Append(split);
                strOutPut.Append(obj.patient_uhid);
                strOutPut.Append(split);
                strOutPut.Append(obj.patient_name);
                strOutPut.Append(split);
                strOutPut.Append(obj.patient_email);
                strOutPut.Append(split);
                strOutPut.Append(obj.patient_mobile_number);
                strOutPut.Append(split);
                strOutPut.Append(obj.patient_gender);
                strOutPut.Append(split);
                strOutPut.Append(obj.patient_age);
                strOutPut.Append(split);
                strOutPut.Append(obj.IPAddress);
                strOutPut.Append(split);
                strOutPut.Append(obj.DeviceID);
                strOutPut.Append(split);
                strOutPut.Append(obj.TRIGGER_USER_ID);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public OnemgTokenClassRequest GetOnemgURLToken_DeSerialize(string Response, string token)
        {

            OnemgTokenClassRequest obj = null;
            if (!string.IsNullOrEmpty(Response))
            {
                obj = new OnemgTokenClassRequest();
                string[] values = StringCipher.Decrypt(Response, token).Split(split);

                obj.doctor_id = values[0];
                obj.clinic_id = values[1];
                obj.patient_uhid = values[2];
                obj.patient_name = values[3];
                obj.patient_email = values[4];
                obj.patient_mobile_number = values[5];
                obj.patient_gender = values[6];
                obj.patient_age = values[7];
                if (values.Count() > 8 && !string.IsNullOrEmpty(values[8]))
                {
                    obj.IPAddress = values[8];
                    obj.DeviceID = values[9];
                    obj.TRIGGER_USER_ID = values[10];
                }
            }
            return obj;
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


        public string GetReimbursementData_Serialize(List<ReimbursementClass> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(ListIdentifier_Start);

            foreach (ReimbursementClass objRem in Response)
            {
                outPut.Append(ListElement_Start);
                outPut.Append(objRem.REM_ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.REM_STATUS);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.HISTORY_ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.DIAG_TOTAL_BILL_AMT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.DIAG_PAYER_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.DIAG_PAT_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CONS_PAT_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CONS_PAYER_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CONS_TOTAL_BILL_AMT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PHAR_PAT_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PHAR_PAYER_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PHAR_TOTAL_BILL_AMT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PAYER_REMARKS);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CONSUMER_REMARKS);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.REM_Date);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.LastFetchTime);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PatientName);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.TotalClaimedAmt);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Approved_Amt);
                outPut.Append(ListElement_End);
            }

            outPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<ReimbursementClass> GetReimbursementData_Deserialize(string Response, string token)
        {
            List<ReimbursementClass> RemList = new List<ReimbursementClass>();
            string strResposne = StringCipher.Decrypt(Response, token);
            CultureInfo ci = new CultureInfo("en-GB");

            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            string[] attri = innerlist.Split(ListProperty_Split);
                            ReimbursementClass objRem = new ReimbursementClass();
                            objRem.REM_ID = attri[0];
                            if (attri[1] != string.Empty)
                                objRem.REM_STATUS = attri[1];
                            if (attri[2] != string.Empty)
                                objRem.HISTORY_ID = Convert.ToInt32(attri[2]);
                            if (attri[3] != string.Empty)
                                objRem.DIAG_TOTAL_BILL_AMT = attri[3];
                            if (attri[4] != string.Empty)
                                objRem.DIAG_PAYER_PAYABLE = attri[4];
                            if (attri[5] != string.Empty)
                                objRem.DIAG_PAT_PAYABLE = attri[5];
                            if (attri[6] != string.Empty)
                                objRem.CONS_PAT_PAYABLE = attri[6];
                            if (attri[7] != string.Empty)
                                objRem.CONS_PAYER_PAYABLE = attri[7];
                            if (attri[8] != string.Empty)
                                objRem.CONS_TOTAL_BILL_AMT = attri[8];
                            if (attri[9] != string.Empty)
                                objRem.PHAR_PAT_PAYABLE = attri[9];
                            if (attri[10] != string.Empty)
                                objRem.PHAR_PAYER_PAYABLE = attri[10];
                            if (attri[11] != string.Empty)
                                objRem.PHAR_TOTAL_BILL_AMT = attri[11];
                            if (attri[12] != string.Empty)
                                objRem.PAYER_REMARKS = attri[12];
                            if (attri[13] != string.Empty)
                                objRem.CONSUMER_REMARKS = attri[13];
                            if (attri[14] != string.Empty)
                                objRem.REM_Date = attri[14];
                            if (attri[15] != string.Empty)
                                objRem.LastFetchTime = attri[15];
                            if (attri[16] != string.Empty)
                                objRem.PatientName = attri[16];
                            if (attri[17] != string.Empty)
                                objRem.TotalClaimedAmt = attri[17];
                            if (attri.Count() > 17 && attri[18] != string.Empty)
                                objRem.Approved_Amt = attri[18];

                            RemList.Add(objRem);
                        }
                    }
                }
            }
            return RemList;
        }

        public string AutoRegistration_Request_Serialize(string policyno, string uhid, string mobileno, string emailid, string DeviceId = null)
        {
            string outPut = string.Empty;
            outPut = policyno + split + uhid + split + mobileno + split + emailid + split + DeviceId;
            return StringCipher.Encrypt(outPut, key);
        }

        public string String_Response_serialize(string Response)
        {
            string outPut = string.Empty;

            outPut = Response.ToString();
            return StringCipher.Encrypt(outPut, key);
        }

        public string String_Response_Deserialize(string Resposne)
        {
            string outPut = string.Empty;
            // "EMPTY" need to handle at page level.. if empty string return
            outPut = StringCipher.Decrypt(Resposne, key);

            return outPut;
        }

        public string GetUserDetails_V1_Request_Serialize(int userType, string userID, string password, string MemberId, string entityCode = null, string AppName = null, string DeviceId = null, string patientId = null)
        {
            string outPut = string.Empty;
            outPut = userType.ToString() + split + userID + split + password + split + entityCode + split + AppName + split + DeviceId + split + MemberId + split + patientId;
            return StringCipher.Encrypt(outPut, key);
        }

        public QueryRequest GetUserDetails_V1_Request_Deserialize(string Request)
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


        public string AutoLoginLog_Request_Serialize(string requestUrl, string registrationResponse, string loginResponse, string PolicyNo, string UHID)
        {
            string outPut = string.Empty;
            outPut = requestUrl + split + registrationResponse + split + loginResponse + split + PolicyNo + split + UHID;
            return StringCipher.Encrypt(outPut, key);
        }

        public string Reimbursement_Serialize(Reimbursement objRem, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(objRem.Rem_id);
            strOutPut.Append(split);
            strOutPut.Append(objRem.PATIENT_ID);
            strOutPut.Append(split);
            strOutPut.Append(objRem.MEMBER_ID);
            strOutPut.Append(split);
            strOutPut.Append(objRem.SUBMIT_DATE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.CONSULTATION_FEE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.VALIDATIONTYPE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.IS_HEALTH_CHECK);
            strOutPut.Append(split);
            strOutPut.Append(objRem.NO_BSI_DEDUCT);
            strOutPut.Append(split);
            strOutPut.Append(objRem.SERVICE_ACCESS_TYPE_ID);
            strOutPut.Append(split);
            strOutPut.Append(objRem.ISREIMBURSEMENT);
            strOutPut.Append(split);
            strOutPut.Append(objRem.GUID);
            strOutPut.Append(split);
            strOutPut.Append(objRem.REIMCON_BILL_AMOUNT);
            strOutPut.Append(split);
            strOutPut.Append(objRem.REIMPHAR_BILL_AMOUNT);
            strOutPut.Append(split);
            strOutPut.Append(objRem.REIMDIAG_BILL_AMOUNT);
            strOutPut.Append(split);
            strOutPut.Append(objRem.CON_PAYER_PAYABLE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.PHAR_PAYER_PAYABLE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.DIAG_PAYER_PAYABLE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.CON_PAT_PAYABLE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.PHAR_PAT_PAYABLE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.DIAG_PAT_PAYABLE);
            strOutPut.Append(split);
            strOutPut.Append(objRem.IP_ADDRESS);
            strOutPut.Append(split);
            strOutPut.Append(objRem.Device_Id);
            strOutPut.Append(split);
            strOutPut.Append(objRem.Created_By);
            strOutPut.Append(split);
            strOutPut.Append(objRem.Modified_By);
            strOutPut.Append(split);
            strOutPut.Append(objRem.ErrorCode);
            strOutPut.Append(split);
            strOutPut.Append(objRem.ErrorDesc);
            strOutPut.Append(split);
            strOutPut.Append(objRem.History_id);
            strOutPut.Append(split);
            strOutPut.Append(objRem.PAYER_REMARKS);
            strOutPut.Append(split);
            strOutPut.Append(objRem.CONSUMER_REMARKS);
            strOutPut.Append(split);
            strOutPut.Append(objRem.SAVE_DRAFT);
            strOutPut.Append(split);
            strOutPut.Append(objRem.BILL_AMOUNT);
            strOutPut.Append(split);
            //files
            if (objRem.FILES != null && objRem.FILES.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Reimburse_Attachments objFiles in objRem.FILES)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objFiles.Rem_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.History_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.File_Name);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.Bill_Amt);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.Transaction_type);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.Ip_Address);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.Device_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.FileName_NEFT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.FileName_Bill);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.FileName_Prescription);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objFiles.FileName_Others);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public Reimbursement Reimbursement_Deserialize(string Response, string token)
        {
            Reimbursement objRem = new Reimbursement();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);
            int i = 0;
            objRem.Rem_id = values[i];
            objRem.PATIENT_ID = values[++i];
            objRem.MEMBER_ID = values[++i];
            objRem.SUBMIT_DATE = values[++i];
            objRem.CONSULTATION_FEE = Convert.ToInt32(values[++i]);
            objRem.VALIDATIONTYPE = Convert.ToInt32(values[++i]);
            objRem.IS_HEALTH_CHECK = Convert.ToInt32(values[++i]);
            objRem.NO_BSI_DEDUCT = Convert.ToInt32(values[++i]);
            objRem.SERVICE_ACCESS_TYPE_ID = Convert.ToInt32(values[++i]);
            objRem.ISREIMBURSEMENT = Convert.ToInt32(values[++i]);
            objRem.GUID = values[++i];
            objRem.REIMCON_BILL_AMOUNT = Convert.ToDouble(values[++i]);
            objRem.REIMPHAR_BILL_AMOUNT = Convert.ToDouble(values[++i]);
            objRem.REIMDIAG_BILL_AMOUNT = Convert.ToDouble(values[++i]);
            objRem.CON_PAYER_PAYABLE = Convert.ToDouble(values[++i]);
            objRem.PHAR_PAYER_PAYABLE = Convert.ToDouble(values[++i]);
            objRem.DIAG_PAYER_PAYABLE = Convert.ToDouble(values[++i]);
            objRem.CON_PAT_PAYABLE = Convert.ToDouble(values[++i]);
            objRem.PHAR_PAT_PAYABLE = Convert.ToDouble(values[++i]);
            objRem.DIAG_PAT_PAYABLE = Convert.ToDouble(values[++i]);
            objRem.IP_ADDRESS = values[++i];
            objRem.Device_Id = values[++i];
            objRem.Created_By = values[++i];
            objRem.Modified_By = values[++i];
            objRem.ErrorCode = values[++i];
            objRem.ErrorDesc = values[++i];
            objRem.History_id = values[++i];
            objRem.PAYER_REMARKS = values[++i];
            objRem.CONSUMER_REMARKS = values[++i];
            objRem.SAVE_DRAFT = Convert.ToInt32(values[++i]);
            if (!string.IsNullOrEmpty(values[i + 1]) && values[i + 1] != "null")
                objRem.BILL_AMOUNT = Convert.ToDouble(values[++i]);
            else
            {
                objRem.BILL_AMOUNT = null;
                ++i;
            }
            i++;

            if (values[i] != null && values[i] != string.Empty)
            {
                List<Reimburse_Attachments> objList = new List<Reimburse_Attachments>();
                foreach (string list in values[i].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                Reimburse_Attachments Files = new Reimburse_Attachments();
                                Files.Rem_id = attri[0];
                                Files.History_id = attri[1];
                                Files.File_Name = attri[2];
                                Files.Bill_Amt = attri[3];
                                Files.Transaction_type = attri[4];
                                Files.Ip_Address = attri[5];
                                Files.Device_id = attri[6];
                                Files.FileName_NEFT = attri[7];
                                Files.FileName_Bill = attri[8];
                                Files.FileName_Prescription = attri[9];
                                Files.FileName_Others = attri[10];
                                objList.Add(Files);
                            }
                        }
                    }
                }
                objRem.FILES = objList;
            }
            i++;

            return objRem;
        }

        public string GetReimbursementList_Serialize(List<Reimbursement> Response, string token)
        {
            StringBuilder outPut = new StringBuilder();
            foreach (Reimbursement objRem in Response)
            {
                outPut.Append(ListIdentifier_Start);
                outPut.Append(objRem.Rem_id);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PATIENT_ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.MEMBER_ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.SUBMIT_DATE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CONSULTATION_FEE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.VALIDATIONTYPE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.IS_HEALTH_CHECK);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.NO_BSI_DEDUCT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.SERVICE_ACCESS_TYPE_ID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.ISREIMBURSEMENT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.GUID);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.REIMCON_BILL_AMOUNT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.REIMPHAR_BILL_AMOUNT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.REIMDIAG_BILL_AMOUNT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CON_PAYER_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PHAR_PAYER_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.DIAG_PAYER_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CON_PAT_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PHAR_PAT_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.DIAG_PAT_PAYABLE);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.IP_ADDRESS);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Device_Id);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Created_By);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.Modified_By);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.ErrorCode);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.ErrorDesc);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.History_id);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.REM_STATUS);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.PAYER_REMARKS);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.CONSUMER_REMARKS);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.APPROVED_AMOUNT);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.AUTHORIZATION_LETTER);
                outPut.Append(ListProperty_Split);
                outPut.Append(objRem.IS_DRAFT);
                outPut.Append(ListProperty_Split);

                //files
                if (objRem.FILES != null && objRem.FILES.Count > 0)
                {
                    //outPut.Append(ListIdentifier_Start);
                    foreach (Reimburse_Attachments objFiles in objRem.FILES)
                    {
                        outPut.Append(ListElement_Start);
                        outPut.Append(objFiles.Rem_id);
                        outPut.Append(split);
                        outPut.Append(objFiles.History_id);
                        outPut.Append(split);
                        outPut.Append(objFiles.File_Name);
                        outPut.Append(split);
                        outPut.Append(objFiles.Bill_Amt);
                        outPut.Append(split);
                        outPut.Append(objFiles.Transaction_type);
                        outPut.Append(split);
                        outPut.Append(objFiles.Ip_Address);
                        outPut.Append(split);
                        outPut.Append(objFiles.Device_id);
                        outPut.Append(split);
                        outPut.Append(objFiles.FileName_NEFT);
                        outPut.Append(split);
                        outPut.Append(objFiles.FileName_Bill);
                        outPut.Append(split);
                        outPut.Append(objFiles.FileName_Prescription);
                        outPut.Append(split);
                        outPut.Append(objFiles.FileName_Others);
                        outPut.Append(ListElement_End);
                    }
                    //outPut.Append(ListIdentifier_End);
                }

                outPut.Append(ListProperty_Split);

                //Validation Breakup
                if (objRem.Validation_Breakup != null)
                {
                    if (objRem.Validation_Breakup.CON_BREAKUP_DETAILS != null && objRem.Validation_Breakup.CON_BREAKUP_DETAILS.Count > 0)
                    {
                        //outPut.Append(Inner_ListElement_Start);
                        foreach (Rem_Breakup_Details objBreakupDetails in objRem.Validation_Breakup.CON_BREAKUP_DETAILS)
                        {
                            outPut.Append(Inner_ListElement_Start);
                            outPut.Append("1");
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objBreakupDetails.ValidationMsg);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objBreakupDetails.ValidationAmount);
                            outPut.Append(Inner_ListElement_End);
                        }
                    }
                    if (objRem.Validation_Breakup.DIAG_BREAKUP_DETAILS != null && objRem.Validation_Breakup.DIAG_BREAKUP_DETAILS.Count > 0)
                    {
                        foreach (Rem_Breakup_Details objBreakupDetails in objRem.Validation_Breakup.DIAG_BREAKUP_DETAILS)
                        {
                            outPut.Append(Inner_ListElement_Start);
                            outPut.Append("2");
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objBreakupDetails.ValidationMsg);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objBreakupDetails.ValidationAmount);
                            outPut.Append(Inner_ListElement_End);
                        }
                    }
                    if (objRem.Validation_Breakup.PHAR_BREAKUP_DETAILS != null && objRem.Validation_Breakup.PHAR_BREAKUP_DETAILS.Count > 0)
                    {
                        foreach (Rem_Breakup_Details objBreakupDetails in objRem.Validation_Breakup.PHAR_BREAKUP_DETAILS)
                        {
                            outPut.Append(Inner_ListElement_Start);
                            outPut.Append("3");
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objBreakupDetails.ValidationMsg);
                            outPut.Append(Inner_ListProperty_Split);
                            outPut.Append(objBreakupDetails.ValidationAmount);
                            outPut.Append(Inner_ListElement_End);
                        }
                    }
                    //outPut.Append(Inner_ListElement_End);
                }

                outPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(outPut.ToString(), token);
        }

        public List<Reimbursement> GetReimbursementList_Deserialize(string Response, string token)
        {
            List<Reimbursement> RemList = new List<Reimbursement>();
            string strResposne = StringCipher.Decrypt(Response, token);
            CultureInfo ci = new CultureInfo("en-GB");

            foreach (string list in strResposne.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    string[] attri = list.Split(ListProperty_Split);
                    Reimbursement objRem = new Reimbursement();
                    int i = 0;
                    objRem.Rem_id = attri[i];
                    objRem.PATIENT_ID = attri[++i];
                    objRem.MEMBER_ID = attri[++i];
                    objRem.SUBMIT_DATE = attri[++i];
                    objRem.CONSULTATION_FEE = Convert.ToInt32(attri[++i]);
                    objRem.VALIDATIONTYPE = Convert.ToInt32(attri[++i]);
                    objRem.IS_HEALTH_CHECK = Convert.ToInt32(attri[++i]);
                    objRem.NO_BSI_DEDUCT = Convert.ToInt32(attri[++i]);
                    objRem.SERVICE_ACCESS_TYPE_ID = Convert.ToInt32(attri[++i]);
                    objRem.ISREIMBURSEMENT = Convert.ToInt32(attri[++i]);
                    objRem.GUID = attri[++i];
                    objRem.REIMCON_BILL_AMOUNT = Convert.ToDouble(attri[++i]);
                    objRem.REIMPHAR_BILL_AMOUNT = Convert.ToDouble(attri[++i]);
                    objRem.REIMDIAG_BILL_AMOUNT = Convert.ToDouble(attri[++i]);
                    objRem.CON_PAYER_PAYABLE = Convert.ToDouble(attri[++i]);
                    objRem.PHAR_PAYER_PAYABLE = Convert.ToDouble(attri[++i]);
                    objRem.DIAG_PAYER_PAYABLE = Convert.ToDouble(attri[++i]);
                    objRem.CON_PAT_PAYABLE = Convert.ToDouble(attri[++i]);
                    objRem.PHAR_PAT_PAYABLE = Convert.ToDouble(attri[++i]);
                    objRem.DIAG_PAT_PAYABLE = Convert.ToDouble(attri[++i]);
                    objRem.IP_ADDRESS = attri[++i];
                    objRem.Device_Id = attri[++i];
                    objRem.Created_By = attri[++i];
                    objRem.Modified_By = attri[++i];
                    objRem.ErrorCode = attri[++i];
                    objRem.ErrorDesc = attri[++i];
                    objRem.History_id = attri[++i];
                    objRem.REM_STATUS = attri[++i];
                    objRem.PAYER_REMARKS = attri[++i];
                    objRem.CONSUMER_REMARKS = attri[++i];
                    objRem.APPROVED_AMOUNT = attri[++i];
                    objRem.AUTHORIZATION_LETTER = attri[++i];
                    objRem.IS_DRAFT = Convert.ToInt32(attri[++i]);
                    i++;

                    if (attri[i] != null && attri[i] != string.Empty)
                    {
                        List<Reimburse_Attachments> objList = new List<Reimburse_Attachments>();
                        foreach (string innerlist1 in attri[i].Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist1 != string.Empty)
                            {
                                string[] attri1 = innerlist1.Split(split);
                                Reimburse_Attachments Files = new Reimburse_Attachments();
                                Files.Rem_id = attri1[0];
                                Files.History_id = attri1[1];
                                Files.File_Name = attri1[2];
                                Files.Bill_Amt = attri1[3];
                                Files.Transaction_type = attri1[4];
                                Files.Ip_Address = attri1[5];
                                Files.Device_id = attri1[6];
                                Files.FileName_NEFT = attri1[7];
                                Files.FileName_Bill = attri1[8];
                                Files.FileName_Prescription = attri1[9];
                                Files.FileName_Others = attri1[10];
                                objList.Add(Files);
                            }
                        }
                        objRem.FILES = objList;
                    }
                    i++;

                    Reimburse_Breakup _remBreakup = new Reimburse_Breakup();
                    if (attri[i] != null && attri[i] != string.Empty)
                    {
                        List<Rem_Breakup_Details> objConList = new List<Rem_Breakup_Details>();
                        List<Rem_Breakup_Details> objDiagList = new List<Rem_Breakup_Details>();
                        List<Rem_Breakup_Details> objPharList = new List<Rem_Breakup_Details>();
                        foreach (string innerlist1 in attri[i].Split(Inner_ListElement_Start, Inner_ListElement_End))
                        {
                            if (innerlist1 != string.Empty)
                            {
                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                Rem_Breakup_Details Rem_Breakup_Details = new Rem_Breakup_Details();
                                Rem_Breakup_Details.TransactionType = attri1[0];
                                Rem_Breakup_Details.ValidationMsg = attri1[1];
                                Rem_Breakup_Details.ValidationAmount = Convert.ToDouble(attri1[2]);
                                if (Rem_Breakup_Details.TransactionType == "1")
                                    objConList.Add(Rem_Breakup_Details);
                                else if (Rem_Breakup_Details.TransactionType == "2")
                                    objDiagList.Add(Rem_Breakup_Details);
                                else if (Rem_Breakup_Details.TransactionType == "3")
                                    objPharList.Add(Rem_Breakup_Details);
                            }
                        }
                        _remBreakup.CON_TOTAL_BILL_AMOUNT = objRem.REIMCON_BILL_AMOUNT;
                        _remBreakup.DIAG_TOTAL_BILL_AMOUNT = objRem.REIMDIAG_BILL_AMOUNT;
                        _remBreakup.PHAR_TOTAL_BILL_AMOUNT = objRem.REIMPHAR_BILL_AMOUNT;
                        _remBreakup.CON_BREAKUP_DETAILS = objConList;
                        _remBreakup.DIAG_BREAKUP_DETAILS = objDiagList;
                        _remBreakup.PHAR_BREAKUP_DETAILS = objPharList;

                        objRem.Validation_Breakup = _remBreakup;
                    }

                    RemList.Add(objRem);
                }
            }
            return RemList;
        }
        public string Consumer_Menu_Serialize(MenuItemList objpre, string token)
        {
            string _PharmacyId = string.Empty;
            StringBuilder strOutPut = new StringBuilder();

            //DrugList
            if (objpre.ParentMenu != null && objpre.ParentMenu.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (MenuItemData objMenu in objpre.ParentMenu)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objMenu.Action);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Controller);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.NewTab);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.ParentMenuId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Icon);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Title);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.HasSubMenu);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Value_Enum);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            else
            {
                strOutPut.Append("");
            }
            strOutPut.Append(split);

            if (objpre.ChildMenu != null && objpre.ChildMenu.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (MenuItemData objMenu in objpre.ChildMenu)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(objMenu.Action);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Controller);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.NewTab);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.ID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.ParentMenuId);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Icon);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Title);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.HasSubMenu);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objMenu.Value_Enum);
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

        public MenuItemList Consumer_Menu_DeSerialize(string Response, string token)
        {
            MenuItemList objPres = new MenuItemList();
            string[] values = StringCipher.Decrypt(Response, token).Split(split); ;



            if (values[0] != null && values[0] != string.Empty)
            {
                List<MenuItemData> objList = new List<MenuItemData>();
                foreach (string list in values[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                MenuItemData objDrug = new MenuItemData();
                                if (attri[0] != string.Empty)
                                    objDrug.Action = attri[0];
                                objDrug.Controller = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.NewTab = Convert.ToInt32(attri[2]);
                                if (attri[3] != string.Empty)
                                    objDrug.ID = Convert.ToInt32(attri[3]);
                                if (attri[4] != string.Empty)
                                    objDrug.ParentMenuId = Convert.ToInt32(attri[4]);
                                if (attri[5] != string.Empty)
                                    objDrug.Icon = attri[5];
                                if (attri[6] != string.Empty)
                                    objDrug.Title = attri[6];
                                if (attri[7] != string.Empty)
                                    objDrug.HasSubMenu = Convert.ToBoolean(attri[7]);
                                if (attri.Count() >8 && attri[8] != string.Empty)
                                    objDrug.Value_Enum = Convert.ToString(attri[8]);

                                objList.Add(objDrug);
                            }
                        }

                    }
                }
                objPres.ParentMenu = objList;
            }

            if (values[1] != null && values[1] != string.Empty)
            {
                List<MenuItemData> objList = new List<MenuItemData>();
                foreach (string list in values[1].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                string[] attri = innerlist.Split(ListProperty_Split);
                                MenuItemData objDrug = new MenuItemData();
                                if (attri[0] != string.Empty)
                                    objDrug.Action = attri[0];
                                objDrug.Controller = attri[1];
                                if (attri[2] != string.Empty)
                                    objDrug.NewTab = Convert.ToInt32(attri[2]);
                                if (attri[3] != string.Empty)
                                    objDrug.ID = Convert.ToInt32(attri[3]);
                                if (attri[4] != string.Empty)
                                    objDrug.ParentMenuId = Convert.ToInt32(attri[4]);
                                if (attri[5] != string.Empty)
                                    objDrug.Icon = attri[5];
                                if (attri[6] != string.Empty)
                                    objDrug.Title = attri[6];
                                if (attri[7] != string.Empty)
                                    objDrug.HasSubMenu = Convert.ToBoolean(attri[7]);
                                if (attri.Count() > 8 && attri[8] != string.Empty)
                                    objDrug.Value_Enum = Convert.ToString(attri[8]);

                                objList.Add(objDrug);
                            }
                        }

                    }
                }
                objPres.ChildMenu = objList;
            }



            return objPres;
        }
        public string GetHospital_Serialize(HospitalSearch Response, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (Response.HospitalLst != null && Response.HospitalLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Hospital obj in Response.HospitalLst)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.EntityCode);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.HospitalID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.HospitalName);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            strOutPut.Append(split);

            if (Response.HospitalLst != null && Response.HospitalLst.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Hospital obj in Response.HospitalLst)
                {


                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.HospitalID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.HospitalName);
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

                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public HospitalSearch GetHospital_Deserialize(string Response, string token)
        {
            HospitalSearch _search = new HospitalSearch();
            string[] values1 = StringCipher.Decrypt(Response, token).Split(split);
            if (values1[0] != string.Empty)
            {
                List<Hospital> obj = null;
                foreach (string list in values1[0].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<Hospital>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Hospital obj1 = new Hospital();
                                string[] values = innerlist.Split(ListProperty_Split);
                                obj1.EntityCode = values[0];
                                if (!string.IsNullOrWhiteSpace(values[1]))
                                    obj1.HospitalID = Convert.ToInt32(values[1]);
                                obj1.HospitalName = values[2];
                                obj.Add(obj1);
                            }

                        }
                    }
                }
                _search.HospitalLst = new List<Hospital>();
                _search.HospitalLst = obj;
            }

            if (values1[1] != string.Empty)
            {
                List<Hospital> obj = null;
                foreach (string list in values1[1].Split(ListIdentifier_Start, ListIdentifier_End))
                {
                    if (list != string.Empty)
                    {
                        obj = new List<Hospital>();
                        foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                        {
                            if (innerlist != string.Empty)
                            {
                                Hospital obj1 = new Hospital();
                                string[] values = innerlist.Split(ListProperty_Split);
                                if (!string.IsNullOrWhiteSpace(values[0]))
                                    obj1.HospitalID = Convert.ToInt32(values[0]);
                                obj1.HospitalName = values[1];
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

                                obj.Add(obj1);
                            }

                        }
                    }
                }
                _search.HospitalLst = new List<Hospital>();
                _search.HospitalLst = obj;
            }

            return _search;
        }
    }
}
