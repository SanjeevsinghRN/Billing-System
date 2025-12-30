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
    public class ReqRes_Physician
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
                            lstPayDet.Add(obj);
                        }
                    }
                }
            }
            return lstPayDet;
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
            strOutPut.Append(split);
            strOutPut.Append(objResposne.Experience);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.StateName);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.Gender);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.GenderID);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.PAYEE_NAME);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.BANK_NAME);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.BRANCH_NAME);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.ACCOUNT_TYPE);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.ACCOUNT_NUMBER);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.MICR_CODE);
            strOutPut.Append(split);
            strOutPut.Append(objResposne.IFSC_CODE);

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
            if (values[13] != string.Empty)
                obj.Experience = Convert.ToInt32(values[13]);
            obj.StateName = values[14];
            obj.Gender = values[15];
            if (values[16] != string.Empty)
                obj.GenderID = Convert.ToInt32(values[16]);

            if (values.Length > 16)
            {
                if (values[17] != string.Empty)
                    obj.PAYEE_NAME = Convert.ToString(values[17]);

                if (values[18] != string.Empty)
                    obj.BANK_NAME = Convert.ToString(values[18]);

                if (values[19] != string.Empty)
                    obj.BRANCH_NAME = Convert.ToString(values[19]);

                if (values[20] != string.Empty)
                    obj.ACCOUNT_TYPE = Convert.ToString(values[20]);

                if (values[21] != string.Empty)
                    obj.ACCOUNT_NUMBER = Convert.ToString(values[21]);

                if (values[22] != string.Empty)
                    obj.MICR_CODE = Convert.ToString(values[22]);

                if (values[23] != string.Empty)
                    obj.IFSC_CODE = Convert.ToString(values[23]);

            }

            return obj;
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
                strOutPut.Append(objPro.Evening);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.Night);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DRUG_TYPE_DESC);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DrugCode);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DRUG_TYPE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DosageA);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DosageM);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.DosageN);
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
                                obj.Morning = Convert.ToInt32(attri[4]);
                            if (attri[5] != string.Empty)
                                obj.Evening = Convert.ToInt32(attri[5]);
                            if (attri[6] != string.Empty)
                                obj.Night = Convert.ToInt32(attri[6]);
                            obj.DRUG_TYPE_DESC = attri[7];
                            obj.DrugCode = attri[8];
                            if (attri[9] != string.Empty)
                                obj.DRUG_TYPE = Convert.ToInt32(attri[9]);
                            obj.DosageA = attri[10];
                            obj.DosageM = attri[11];
                            obj.DosageN = attri[12];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }
        
        public string GetDosageRange_List_Serialize(List<Drug_Dosage_Range> lstObj, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            if (lstObj != null && lstObj.Count > 0)
            {
                strOutPut.Append(ListIdentifier_Start);
                foreach (Drug_Dosage_Range obj in lstObj)
                {
                    strOutPut.Append(ListElement_Start);
                    strOutPut.Append(obj.Dosage_Name);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Dosage_type_id);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Incr_Value);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Max_Value);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Min_Value);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.Unit_Value);
                    strOutPut.Append(ListElement_End);
                }
                strOutPut.Append(ListIdentifier_End);
            }
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<Drug_Dosage_Range> GetDosageRange_List_Deserialize(string Response, string token)
        {
            List<Drug_Dosage_Range> lstobj = new List<Drug_Dosage_Range>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            Drug_Dosage_Range obj = new Drug_Dosage_Range();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            obj.Dosage_Name = attri[0];
                            if (!string.IsNullOrEmpty(attri[1]))
                                obj.Dosage_type_id = Convert.ToInt32(attri[1]);
                            if (!string.IsNullOrEmpty(attri[2]))
                                obj.Incr_Value = Convert.ToDecimal(attri[2]);
                            if (!string.IsNullOrEmpty(attri[3]))
                                obj.Max_Value = Convert.ToDecimal(attri[3]);
                            if (!string.IsNullOrEmpty(attri[4]))
                                obj.Min_Value = Convert.ToDecimal(attri[4]);
                            obj.Unit_Value = attri[5];
                            lstobj.Add(obj);
                        }
                    }
                }
            }
            return lstobj;
        }
        public string GetAllAppTimeSlot_Serialize(List<AppSlotMaster> Response, string token)
        {
            StringBuilder objOut = new StringBuilder();
            objOut.Append(ListIdentifier_Start);
            foreach (AppSlotMaster obj in Response)
            {
                objOut.Append(ListElement_Start);
                objOut.Append(obj.SlotID);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.SlotType);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.SlotFrom);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.SlotTo);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.Interval);
                objOut.Append(ListProperty_Split);
                objOut.Append(obj.Day);
                objOut.Append(ListElement_End);



            }

            objOut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(objOut.ToString(), token);
        }

        public List<AppSlotMaster> GetAllAppTimeSlot_Deserialize(string Response, string token)
        {
            List<AppSlotMaster> objSlotLst = new List<AppSlotMaster>();
            string strResponse = StringCipher.Decrypt(Response, token);
            foreach (string list in strResponse.Split(ListIdentifier_Start, ListIdentifier_End))
            {
                if (list != string.Empty)
                {
                    foreach (string innerlist in list.Split(ListElement_Start, ListElement_End))
                    {
                        if (innerlist != string.Empty)
                        {
                            AppSlotMaster objSlot = new AppSlotMaster();
                            string[] attri = innerlist.Split(ListProperty_Split);
                            if (attri[0] != string.Empty)
                                objSlot.SlotID = Convert.ToInt16(attri[0]);
                            if (attri[1] != string.Empty)
                                objSlot.SlotType = Convert.ToInt16(attri[1]);
                            objSlot.SlotFrom = attri[2];
                            objSlot.SlotTo = attri[3];
                            if (attri[4] != string.Empty)
                                objSlot.Interval = Convert.ToInt16(attri[4]);
                            if (attri[5] != string.Empty)
                                objSlot.Day = Convert.ToInt16(attri[5]);

                            objSlotLst.Add(objSlot);
                        }
                    }
                }
            }
            return objSlotLst;
        }

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
                        strOutPut.Append(objdrug.DrugCode);
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
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.PayerPayable);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.PatientPayable);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.UNITS);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.UNIT_COST);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objProc.STANDARD_DISCOUNT);
                        
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
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.PayerPayable);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.PatientPayable);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.UNITS);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.UNIT_COST);
                        strOutPut.Append(Inner_ListProperty_Split);
                        strOutPut.Append(objTest.STANDARD_DISCOUNT);
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
                strOutPut.Append(objpre.MemberID);

                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.is_checkbalance);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.PayerPayable);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.PatientPayable);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objpre.total_billAmount);
                                                
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
                                                            objDrug.DrugCode = Convert.ToString(attri[13]);
                                                        if (attri[14] != string.Empty)
                                                            objDrug.DRUG_TYPE = Convert.ToInt32(attri[14]);
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
                                                        if (attri.Length > 6)
                                                        {
                                                            ObjProc.PayerPayable = attri[6];
                                                            ObjProc.PatientPayable = attri[7];
                                                            ObjProc.UNITS = attri[8];
                                                            ObjProc.UNIT_COST = attri[9];
                                                            ObjProc.STANDARD_DISCOUNT = attri[10];
                                                        }
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
                                                            if (attri.Length > 6)
                                                            {
                                                                ObjTest.PayerPayable = attri[6];
                                                                ObjTest.PatientPayable = attri[7];
                                                                ObjTest.UNITS = attri[8];
                                                                ObjTest.UNIT_COST = attri[9];
                                                                ObjTest.STANDARD_DISCOUNT = attri[10];
                                                            }
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

                                    if (values[50] != null && values[50] != string.Empty)
                                    {
                                        objPres.MemberID = values[50];
                                    }

                                    if (values.Length > 51 && values[51] != null && values[51] != string.Empty)
                                    {
                                        objPres.is_checkbalance = values[51];
                                    }
                                    if (values.Length > 52 && values[52] != null && values[52] != string.Empty)
                                    {
                                        objPres.PayerPayable = values[52];
                                    }
                                    if (values.Length > 53 && values[53] != null && values[53] != string.Empty)
                                    {
                                        objPres.PatientPayable = values[53];
                                    }
                                    if (values.Length > 54 && values[54] != null && values[54] != string.Empty)
                                    {
                                        objPres.total_billAmount = values[54];
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

        public string Appointment_Cancel_Serialize(Appointment Response, string token)
        {
            StringBuilder objOut = new StringBuilder();
            objOut.Append(Response.AppointmentID);
            objOut.Append(split);
            objOut.Append(Response.CANCEL_REASON);
            objOut.Append(split);
            objOut.Append(Response.MODIFIED_BY);
            objOut.Append(split);
            objOut.Append(Response.VISITORIP);

            return StringCipher.Encrypt(objOut.ToString(), token);
        }

        public Appointment Appointment_Cancel_DeSerialize(string Response, string token)
        {
            Appointment obj = new Appointment();
            string[] values = StringCipher.Decrypt(Response, token).Split(split);

            obj.AppointmentID = Convert.ToInt32(values[0]);
            obj.CANCEL_REASON = values[1];
            if (values[2] != string.Empty)
                obj.MODIFIED_BY = Convert.ToInt32(values[2]);
            obj.VISITORIP = values[3];
            return obj;
        }

        public string GetConsulTaionMaster_Phy_Serialize(List<ConsultaionMasterClass> objResposne, string token)
        {
            StringBuilder strOutPut = new StringBuilder();
            strOutPut.Append(ListIdentifier_Start);
            foreach (ConsultaionMasterClass objPro in objResposne)
            {
                strOutPut.Append(ListElement_Start);
                strOutPut.Append(objPro.FEE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.CONSULTATION_TYPE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.CONSULTATION_TYPE_CODE);
                strOutPut.Append(ListProperty_Split);
                strOutPut.Append(objPro.VISIT_TYPE);
                strOutPut.Append(ListElement_End);
            }

            strOutPut.Append(ListIdentifier_End);
            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public List<ConsultaionMasterClass> GetConsulTaionMaster_Phy_Deserialize(string Response, string Token)
        {
            List<ConsultaionMasterClass> objapp = new List<ConsultaionMasterClass>();
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
                            ConsultaionMasterClass obj = new ConsultaionMasterClass();
                            if (attri[0] != string.Empty)
                                obj.FEE = attri[0];
                            obj.CONSULTATION_TYPE = attri[1];
                            obj.CONSULTATION_TYPE_CODE = attri[2];
                            obj.VISIT_TYPE = attri[3];
                            objapp.Add(obj);
                        }
                    }
                }
            }
            return objapp;
        }


        public string PrescriptionClass_V1_Serialize(PrescriptionClass objpre, string token)
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

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.BILL_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.is_rate_enabled);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.is_unit_enabled);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.FEE_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXCL);

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

                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.BILL_AMOUNT);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.is_rate_enabled);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.is_unit_enabled);                    
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.ProcedureType);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.FEE_TYPE);
                    strOutPut.Append(ListProperty_Split);
                    strOutPut.Append(obj.IS_EXCL);

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
            strOutPut.Append(objpre.TOTAL_BILL_AMOUNT);
            strOutPut.Append(split);
            strOutPut.Append(objpre.TOTAL_PAYER_PAYABLE);
            strOutPut.Append(split);
            strOutPut.Append(objpre.TOTAL_PATIENT_PAYABLE);
            strOutPut.Append(split);

            return StringCipher.Encrypt(strOutPut.ToString(), token);
        }

        public PrescriptionClass PrescriptionClass_V1_Deserialize(string Response, string token)
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
                                    objDrug.Evening = Convert.ToInt32(attri[4]);
                                if (attri[5] != string.Empty)
                                    objDrug.Morning = Convert.ToInt32(attri[5]);
                                if (attri[6] != string.Empty)
                                    objDrug.Night = Convert.ToInt32(attri[6]);
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
                                    Objpay.User_Id = Convert.ToInt16(attri[2]);
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

                                if (attri[10] != string.Empty)
                                    objP.BILL_AMOUNT = Convert.ToString(attri[10]);
                                if (attri[11] != string.Empty)
                                    objP.is_rate_enabled = Convert.ToBoolean(attri[11]);
                                if (attri[12] != string.Empty)
                                    objP.is_unit_enabled = Convert.ToBoolean(attri[12]);
                                if (attri[13] != string.Empty && !string.IsNullOrEmpty(attri[13]))
                                    objP.FEE_TYPE = Convert.ToInt32(attri[13]);
                                if (attri[14] != string.Empty)
                                    objP.IS_EXCL = Convert.ToString(attri[14]);

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

                                if (attri[9] != string.Empty)
                                    objP.BILL_AMOUNT = Convert.ToString(attri[9]);
                                if (attri[10] != string.Empty)
                                    objP.is_rate_enabled = Convert.ToBoolean(attri[10]);
                                if (attri[11] != string.Empty)
                                    objP.is_unit_enabled = Convert.ToBoolean(attri[11]);
                                if (!string.IsNullOrEmpty(attri[12]))
                                    objP.ProcedureType = Convert.ToInt32(attri[12]);
                                if (attri[13] != string.Empty && !string.IsNullOrEmpty(attri[13]))
                                    objP.FEE_TYPE = Convert.ToInt32(attri[13]);
                                if (attri[14] != string.Empty)
                                    objP.IS_EXCL = Convert.ToString(attri[14]); 
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
                objPres.TOTAL_BILL_AMOUNT = values[i];
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
                objPres.TOTAL_PAYER_PAYABLE = values[i];
            i++;
            if (i < values.Count() && values[i] != null && values[i] != string.Empty)
                objPres.TOTAL_PATIENT_PAYABLE = values[i];
            return objPres;
        }

    }
}
