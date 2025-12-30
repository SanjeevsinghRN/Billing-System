using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    
    public class ResRes_Pharmacy
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
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.orderID);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.prescriptionDate);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.LastFetchTime);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.BillAmt);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(PreClass.OrderByModifiedDate);
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
                                    if (!string.IsNullOrEmpty(values[4]))
                                    {
                                        objPres.orderID = values[4];
                                    }

                                    if (!string.IsNullOrEmpty(values[5]))
                                    {
                                        objPres.prescriptionDate = values[5];
                                    }

                                    if (!string.IsNullOrEmpty(values[6]))
                                    {
                                        objPres.LastFetchTime = values[6];
                                    }
                                    if (!string.IsNullOrEmpty(values[7]))
                                    {
                                        objPres.BillAmt = Convert.ToDecimal(values[7]);
                                    }
                                    if (values[8].Length > 15 && values[8] != string.Empty)
                                        objPres.OrderByModifiedDate = Convert.ToDateTime(values[8], culture);
                                    objList.Add(objPres);
                                }
                            }
                        }
                    }
                }
            }

            return objList;
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
                        strOutPut.Append(obj.Evening);
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
                        strOutPut.Append(ListProperty_Split);//end
                        strOutPut.Append(obj.MRP);
                        strOutPut.Append(ListProperty_Split);//end
                        strOutPut.Append(obj.DRUG_TYPE_DESC);
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
                                        objDrug.Evening = Convert.ToInt32(attri[5]);
                                    if (attri[6] != string.Empty)
                                        objDrug.Morning = Convert.ToInt32(attri[6]);
                                    if (attri[7] != string.Empty)
                                        objDrug.Night = Convert.ToInt32(attri[7]);
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
                                        objDrug.DRUG_TYPE_DESC = attri[16];
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

    }
}
