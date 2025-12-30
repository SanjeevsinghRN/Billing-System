using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class ReqRes_Diagnostic
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
        public static string EncryptKey()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes("M+PRbWXZn4j3QIJjMfjtltFkRS4A4XgdH9zfLY4NKG0=");
            byte[] messageBytes = encoding.GetBytes("ICICI");
            System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);
            byte[] bytes = cryptographer.ComputeHash(messageBytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public string GetOrderDashboardDetails_V2_Dia_Serialize(List<PrescriptionClass> lstPre, string token)
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
                            strOutPut.Append(objlst.Order_Amt);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Is_health_check);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }

               
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.orderID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.prescriptionDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.LastFetchTime);
                    strOutPut.Append(ListProperty_Split);
                    if (objPre.Diagnosis!= null )
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        
                        //strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objPre.Diagnosis.OrderId);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.ClaimID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.Date);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.DiagnosisName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.DiagnosisRate);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.isHc);
                        //strOutPut.Append(Inner_ListElement_End);
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.Is_health_check);
                    strOutPut.Append(ListProperty_Split);
                    if (objPre.DiagnosisDetail != null && objPre.DiagnosisDetail.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (Diagnosis objlst in objPre.DiagnosisDetail)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.OrderId);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.filename);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.DiagnosisID);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Discount);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }

                    strOutPut.Append(ListProperty_Split); 
                    strOutPut.Append(objPre.MobileNo);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetOrderDashboardDetails_V2_Dia_Deserialize(string Response, string token)
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
                                                objlst.Order_Amt = attri1[4];
                                                if (!string.IsNullOrEmpty(attri1[5]))
                                                objlst.Is_health_check = Convert.ToInt16(attri1[5]);
                                                objPre.Orderdetails.Add(objlst);
                                            }
                                        }

                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(attri[8]))
                            {
                                objPre.orderID = attri[8];
                            }

                            if (!string.IsNullOrEmpty(attri[9]))
                            {
                                objPre.prescriptionDate = attri[9];
                            }
                            if (!string.IsNullOrEmpty(attri[10]))
                            {
                                objPre.LastFetchTime = attri[10];
                            }
                            if (!string.IsNullOrEmpty(attri[11]))
                            {
                                
                                foreach (string list1 in attri[11].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        Diagnosis objlst = new Diagnosis();
                                        string[] attri1 = list1.Split(Inner_ListProperty_Split);
                                        objlst.OrderId = attri1[0];
                                        objlst.ClaimID = attri1[1];
                                        objlst.Date = attri1[2];
                                        objlst.DiagnosisName = attri1[3];
                                        if (!string.IsNullOrEmpty(attri1[4]))
                                            objlst.DiagnosisRate = Convert.ToDecimal(attri1[4]);
                                        if (!string.IsNullOrEmpty(attri1[5]))
                                            objlst.isHc = Convert.ToInt16(attri1[5]);
                                        objPre.Diagnosis = objlst;
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(attri[12]))
                            {
                                objPre.Is_health_check = Convert.ToInt16(attri[12]);
                            }
                        
                            if (!string.IsNullOrEmpty(attri[13]))
                            {
                                objPre.DiagnosisDetail = new List<Diagnosis>();
                                foreach (string list1 in attri[13].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Diagnosis objlst = new Diagnosis();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                    objlst.OrderId = attri1[0];
                                                    objlst.filename = attri1[1];
                                                    objlst.DiagnosisID = Convert.ToInt16(attri1[2]);
                                                    objlst.Discount = Convert.ToInt16(attri1[3]);
                                                    objPre.DiagnosisDetail.Add(objlst);

                                            }
                                        }

                                    }
                                }
                            }
                            objPre.MobileNo = attri[14];
                            lstPre.Add(objPre);
                        }

                    }
                }
            }
            return lstPre;
        }


        public string GetOrderDashboardDetails_V3_Dia_Serialize(List<PrescriptionClass> lstPre, string token)
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
                            strOutPut.Append(objlst.Order_Amt);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Is_health_check);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.ORDER_DATE);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }


                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.orderID);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.prescriptionDate);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.LastFetchTime);
                    strOutPut.Append(ListProperty_Split);
                    if (objPre.Diagnosis != null)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);

                        //strOutPut.Append(Inner_ListElement_Start);
                        strOutPut.Append(objPre.Diagnosis.OrderId);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.ClaimID);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.Date);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.DiagnosisName);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.DiagnosisRate);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.isHc);
                        //strOutPut.Append(Inner_ListElement_End);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objPre.Diagnosis.order_date);
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.Is_health_check);
                    strOutPut.Append(ListProperty_Split);
                    if (objPre.DiagnosisDetail != null && objPre.DiagnosisDetail.Count > 0)
                    {
                        strOutPut.Append(Inner_ListIdentifier_Start);
                        foreach (Diagnosis objlst in objPre.DiagnosisDetail)
                        {
                            strOutPut.Append(Inner_ListElement_Start);
                            strOutPut.Append(objlst.OrderId);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.filename);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.DiagnosisID);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Discount);
                            strOutPut.Append(Inner_ListProperty_Split);
                            strOutPut.Append(objlst.Order_Status);
                            strOutPut.Append(Inner_ListElement_End);
                        }
                        strOutPut.Append(Inner_ListIdentifier_End);
                    }
                    else
                    {
                        strOutPut.Append("");
                    }

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(objPre.MobileNo);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<PrescriptionClass> GetOrderDashboardDetails_V3_Dia_Deserialize(string Response, string token)
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
                                                objlst.Order_Amt = attri1[4];
                                                if (!string.IsNullOrEmpty(attri1[5]))
                                                    objlst.Is_health_check = Convert.ToInt16(attri1[5]);
                                               

                                                try
                                                {
                                                    objlst.ORDER_DATE = Convert.ToDateTime(attri1[6], culture);
                                                }
                                                catch (Exception)
                                                {

                                                }

                                                objPre.Orderdetails.Add(objlst);
                                            }
                                        }

                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(attri[8]))
                            {
                                objPre.orderID = attri[8];
                            }

                            if (!string.IsNullOrEmpty(attri[9]))
                            {
                                objPre.prescriptionDate = attri[9];
                            }
                            if (!string.IsNullOrEmpty(attri[10]))
                            {
                                objPre.LastFetchTime = attri[10];
                            }
                            if (!string.IsNullOrEmpty(attri[11]))
                            {

                                foreach (string list1 in attri[11].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        Diagnosis objlst = new Diagnosis();
                                        string[] attri1 = list1.Split(Inner_ListProperty_Split);
                                        objlst.OrderId = attri1[0];
                                        objlst.ClaimID = attri1[1];
                                        objlst.Date = attri1[2];
                                        objlst.DiagnosisName = attri1[3];
                                        if (!string.IsNullOrEmpty(attri1[4]))
                                            objlst.DiagnosisRate = Convert.ToDecimal(attri1[4]);
                                        if (!string.IsNullOrEmpty(attri1[5]))
                                            objlst.isHc = Convert.ToInt16(attri1[5]);
                                      
                                        try
                                        {
                                            objlst.order_date = Convert.ToDateTime(attri1[6], culture);
                                        }
                                        catch (Exception)
                                        {

                                        }
                                        objPre.Diagnosis = objlst;
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(attri[12]))
                            {
                                objPre.Is_health_check = Convert.ToInt16(attri[12]);
                            }

                            if (!string.IsNullOrEmpty(attri[13]))
                            {
                                objPre.DiagnosisDetail = new List<Diagnosis>();
                                foreach (string list1 in attri[13].Split(Inner_ListIdentifier_Start, Inner_ListIdentifier_End))
                                {
                                    if (list1 != string.Empty)
                                    {
                                        foreach (string innerlist1 in list1.Split(Inner_ListElement_Start, Inner_ListElement_End))
                                        {
                                            if (innerlist1 != string.Empty)
                                            {
                                                Diagnosis objlst = new Diagnosis();
                                                string[] attri1 = innerlist1.Split(Inner_ListProperty_Split);
                                                objlst.OrderId = attri1[0];
                                                objlst.filename = attri1[1];
                                                objlst.DiagnosisID = Convert.ToInt16(attri1[2]);
                                                objlst.Discount = Convert.ToInt16(attri1[3]);
                                                if(attri1.Length > 4)
                                                {
                                                    objlst.Order_Status = Convert.ToString(attri1[4]);
                                                }
                                                objPre.DiagnosisDetail.Add(objlst);

                                            }
                                        }

                                    }
                                }
                            }
                            objPre.MobileNo = attri[14];
                            lstPre.Add(objPre);
                        }

                    }
                }
            }
            return lstPre;
        }


        public string GetAppointment_Diag_Serialize(List<Appointment> objResposne, string token)
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
                strOutPut.Append(objApp.PatientEmailID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objApp.PatientMobileNo);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }


        public List<Appointment> GetAppointment_Diag_Deserialize(string Response, string Token)
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
                                obj.EntityID = Convert.ToInt16(attri[4]);
                            obj.EntityName = attri[5];
                            obj.MemberID = attri[6];
                            if (attri[7] != string.Empty)
                                obj.PatientId = Convert.ToInt16(attri[7]);
                            obj.PatientName = attri[8];
                            if (attri[9] != string.Empty)
                                obj.PhysicianId = Convert.ToInt16(attri[9]);
                            obj.PhysicianName = attri[10];
                            obj.PolicyNo = attri[11];
                            if (attri[12] != string.Empty)
                                obj.SlotID = Convert.ToInt16(attri[12]);
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
                                obj.PatientEmailID = Convert.ToString(attri[23]);
                            if (attri[24] != string.Empty)
                                obj.PatientMobileNo = Convert.ToString(attri[24]);
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }

    }
}
