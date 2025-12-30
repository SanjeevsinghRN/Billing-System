using RN.MOBILE_COMMON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_ConsumerHomePage : System.Web.UI.Page
{
    string token = string.Empty;
    public static string BG_IMAGEIN = string.Empty;
    public static string LOGO = string.Empty;
    public static string CorporateCode = string.Empty;
    public static string VirtualPath = string.Empty;
    public static string VirtualPathExit = string.Empty;
    //public static string HOMEPAGE_BGCOLOR = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string ImagePath = System.Configuration.ConfigurationManager.AppSettings.Get("IMAGE_FOLDER");
            Session["is_Diagnostics"] = null;
            Session["is_Pharmacy"] = null;
            Session["is_Consultation"] = null;
            Session["is_all"] = null;

            string is_broker = System.Configuration.ConfigurationManager.AppSettings.Get("is_broker");
            if (is_broker.Equals("1"))
            {
                BG_IMAGEIN = "";
                LOGO = "";

                if (!string.IsNullOrEmpty(Convert.ToString(Session[SessionConstant.UserID])))
                {
                    string UserID = Convert.ToString(Session[SessionConstant.UserID]);
                    Consumer_Theme cTheme = new Consumer_Theme();
                    if (Session["Theme"] == null)
                    {
                        cTheme = PatientModel.GetConsumerTheme(UserID, Convert.ToString(Session[SessionConstant.token]));
                        Session["Theme"] = cTheme;
                    }
                    else
                    {
                        cTheme = (Consumer_Theme)Session["Theme"];
                    }
                    //string broker_code = Request.Cookies["EntityCode"] != null ? Request.Cookies["EntityCode"].Value : null;
                    CorporateCode = Convert.ToString(Session["CorporateCode"]) != null ? Convert.ToString(Session["CorporateCode"]) : null;
                    VirtualPath = "../images/BrokerCorpLogo/CorporateImages/" + CorporateCode + "/";
                    VirtualPathExit = Server.MapPath("~/images/BrokerCorpLogo/CorporateImages/" + CorporateCode + "/");
                    //HOMEPAGE_BGCOLOR = cTheme.HOMEPAGE_BGCOLOR;   
                    try
                    {
                        //string rootPath = Server.MapPath("~/images/BrokerCorpLogo/");
                        //string rootPath = Server.MapPath("~/images/BrokerCorpLogo/CorporateImages/" + CorporateCode + "/");
                        if (!string.IsNullOrEmpty(CorporateCode))
                            BG_IMAGEIN = VirtualPath + cTheme.HOMEPAGE_BGIMG;
                        //BG_IMAGEIN = "../images/BrokerCorpLogo/" + CorporateCode + "/" + cTheme.HOMEPAGE_BGIMG;
                    }
                    catch { }
                }
            }
            else
            {
                //BG_IMAGEIN = "../images/01_Orange-Colour_800-x-800-px.jpg";
                BG_IMAGEIN = "../images/SAST/TEST/test1.jfif";
                LOGO = "../images/SAST/landing_logo.png";
            }


            if (Session["FILTER_BY"] != null)
                Session.Remove("FILTER_BY");

            if (!IsPostBack)
            {
                if (Session["WebApiToken"] == null || string.IsNullOrEmpty(token))
                {
                    token = Validation.GetToken(MUtils.GetEncryptedKey(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy")));
                    Session["WebApiToken"] = token;
                }
                string imagepth = ConfigurationManager.AppSettings["ProfilePhotoPath"];

                // List<Patient> patientdetails = PatientModel.GetPatients(Session[SessionConstant.MobileNo].ToString(), token);

                if (Session[SessionConstant.UserID] == null)
                    return;


                
                lblUserName.Text = "Hello " + Session[SessionConstant.UserName].ToString();
                lblUserName.ToolTip = Session[SessionConstant.UserName].ToString();
                lblCardNo.Text = "User Role : " + Session[SessionConstant.UserRole].ToString(); 
                lblPolicyNumber.Text = "Mobile No :" + Session[SessionConstant.MobileNo].ToString(); 

                //List<Patient> patientdetails = PatientModel.GetPatients_V1(Session[SessionConstant.UserID].ToString(), token);
                //if (patientdetails.Count > 0)
                //{
                //    Session["IS_REM_ENABLED"] = Convert.ToString(patientdetails[0].REM_ENABLED);
                //    Session["IS_OFF_PRESC_ENABLED"] = Convert.ToString(patientdetails[0].OFFLINE_PRESC_ENABLED);
                //    Session[SessionConstant.MemberId] = patientdetails[0].MemberNo;
                //    Session[SessionConstant.PatientPolicyNumber] = patientdetails[0].PolicyNo;
                //    lblUserName.Text = "Hello " + Session[SessionConstant.UserName].ToString();
                //    lblUserName.ToolTip = Session[SessionConstant.UserName].ToString();
                //    lblCardNo.Text = "Card Number : " + patientdetails[0].MemberNo;
                //    lblPolicyNumber.Text = "Policy Number : " + patientdetails[0].PolicyNo;
                //    Session["POLICYNO"] = patientdetails[0].PolicyNo;
                //    //Nik 281122 -start
                //    Session["RelationShipID"] = patientdetails[0].RelationShipID;
                //    //Nik 281122 -end
                //    if (!string.IsNullOrEmpty(patientdetails[0].CorporateName))
                //    {
                //        lblCoporate.Text = patientdetails[0].CorporateName;
                //        Session["Corporate_name"] = lblCoporate.Text;
                //        divCorporate.Attributes.Add("style", "display:block;");
                //    }
                //    else
                //    {
                //        divProfileImg.Attributes.Add("style", "margin-top:15px;");
                //    }
                //}

                imagepth = imagepth + "/Patient/";
                string Path = Server.MapPath(imagepth);
                string _filename = string.Empty;//PatientModel.GetProfilePhotoName(Session[SessionConstant.UserID].ToString(), token);

                FileInfo fileInfo = new FileInfo(Path + _filename);
                if (fileInfo.Exists)
                {
                    imgProfile.Src = imagepth + _filename;
                }
                else
                {
                    string gender = "Male";
                   // if (patientdetails[0].Gender.ToString().Trim().ToUpper() == "FEMALE")
                    if (gender == "Female")
                    {
                        imgProfile.Src = "../images/02_Female-Profile.png";
                    }
                    else
                    {
                        imgProfile.Src = "../images/01_Male-Profile.png";
                    }
                }
                Session["ISOnlinePahrmacy"] = null;
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Session["IS_REM_ENABLED"])) && Convert.ToString(Session["IS_REM_ENABLED"]) == "1")
                divReimbursementHistory.Visible = true;

            if (Session["IS_OFF_PRESC_ENABLED"] != null && Convert.ToString(Session["IS_OFF_PRESC_ENABLED"]) == "1")
            {
                divOfflinePrescription.Visible = true;
            }
            else
            {
                divOfflinePrescription.Visible = false;
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("is_broker")))
            {
                if (ConfigurationManager.AppSettings.Get("is_broker") == "1")
                {
                    divInpatientDetails.Visible = true;
                    //divHospitals.Visible = true;
                    string tpaCode = PatientModel.GetInSuranceCode(Convert.ToString(Session[SessionConstant.PatientPolicyNumber]));
                    string healthIndiaTpa = ConfigurationManager.AppSettings.Get("Health_India_TPA");
                    Session["TPA_CODE"] = tpaCode;
                    if (tpaCode == healthIndiaTpa)
                    {
                        Session["Health_India_TPA"] = "1";
                        divNetWorkHospital.Visible = true;
                        divClaimSData.Visible = true;
                        divClaimIntimation.Visible = true;
                    }
                    else
                    {
                        Session["Health_India_TPA"] = "0";
                        divNetWorkHospital.Visible = false;
                        divClaimSData.Visible = false;
                        divClaimIntimation.Visible = false;

                    }
                }
                else
                {
                   // divHospitals.Visible = false;
                    Session["Health_India_TPA"] = "0";
                    divNetWorkHospital.Visible = false;
                    divClaimSData.Visible = false;
                    divClaimIntimation.Visible = false;
                }
            }

            CultureInfo culture = new CultureInfo("en-IN");
            if (Session[SessionConstant.LastLoginTime] != null)
            {
                DateTime dt = Convert.ToDateTime(Session[SessionConstant.LastLoginTime], culture);
                if (dt != null)
                    lblLastVisit.Text = "Last visited: " + dt.ToString("dd-MMM-yy hh:mm tt").ToUpper();
                // lblLastVisit.Text = "Last visited: " + dt.Day + "-" + String.Format("{0:MMM}", dt).ToUpper() + "-" + String.Format("{0:yy}", dt) + " " + String.Format("{HH:MM}", dt);
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
    }
    protected void btnFamilyCard_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FamilyDetails.aspx", true);
    }
    protected void btnBookConsultation_Click(object sender, ImageClickEventArgs e)
    {
        Session["IsPolicycover"] = false;
        if (Session[SessionConstant.IS_MOBILE_INTEGRATION] != null)
        {
            if (Session[SessionConstant.IS_MOBILE_INTEGRATION].ToString() != "1")
                Session.Remove("GeoLocation");

        }
        else
            Session.Remove("GeoLocation");

        Response.Redirect("SearchBySpecialtyV.aspx");
    }
    protected void btnBookPharmacy_Click(object sender, ImageClickEventArgs e)
    {
        Session["IsPolicycover"] = false;
        if (Session[SessionConstant.IS_MOBILE_INTEGRATION] != null)
        {
            if (Session[SessionConstant.IS_MOBILE_INTEGRATION].ToString() != "1")
                Session.Remove("GeoLocation");

        }
        else
            Session.Remove("GeoLocation");

        //Response.Redirect("SearchByPharmacyV.aspx");
        int transaction_type = (int)Enumerations.TRANSACTION_TYPE.PHARMACY;
        string key = Utils.Encrypt(transaction_type.ToString());
        Response.Redirect("PrescriptionList.aspx?TransactionType=" + key);
    }
    protected void btnBookDiagnostic_Click(object sender, ImageClickEventArgs e)
    {
        Session["Is_HC"] = false;
        Session["IsPolicycover"] = false;
        Response.Redirect("SearchByDiag.aspx");
    }
    protected void btnBookHealthcheckup_Click(object sender, ImageClickEventArgs e)
    {
        Session["Is_HC"] = true;
        Session["IsPolicycover"] = false;
        Response.Redirect("SearchByDiag.aspx");

    }
    protected void btnBookHospital_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("HospitalSearch.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    protected void btnPolicyCoverage_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            GetPolicyType objpolicytype = PatientModel.GetPolicyType(Session[SessionConstant.UserID].ToString(), Session["WebApiToken"].ToString());
            if (objpolicytype.PolicyType.ToString() == "1")
                Response.Redirect("PolicyCoverView.aspx", false);

            else
                Response.Redirect("MemberListPage.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }

    }
    protected void btnConsulat_Coverage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("BenifitConsultation.aspx");
    }
    protected void btnPharmacy_coverage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Benifitpharmacy.aspx");
    }
    protected void btnDiagnostic_coverage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Benifitdiagnostic.aspx");
    }
    protected void btnAllHistory_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        Response.Redirect("TransactionPage.aspx", true);
    }
    protected void btnConsultationHistory_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        string key = Utils.Encrypt(((int)Enumerations.TRANSACTION_TYPE.CONSULTATION).ToString());
        Response.Redirect("TransactionPage.aspx?TransactionType=" + key, true);
    }
    protected void btnPharmacyHistory_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        string key = Utils.Encrypt(((int)Enumerations.TRANSACTION_TYPE.PHARMACY).ToString());
        Response.Redirect("TransactionPage.aspx?TransactionType=" + key, true);
    }
    protected void btnDiagnosticHistory_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        string key = Utils.Encrypt(((int)Enumerations.TRANSACTION_TYPE.DIAGNOSTIC).ToString());
        Response.Redirect("TransactionPage.aspx?TransactionType=" + key, true);
    }
    protected void btnReimbursementHistory_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        Response.Redirect("ReimbursementTransactionPage.aspx", true);
    }

    protected void btnInPatientDetails_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        Response.Redirect("InpatientDashboard.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    protected void imgBtnNetwrkHosp_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        Response.Redirect("NetworkHospitals.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    protected void imgBtnClaimIntimation_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        Response.Redirect("claimIntimation.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    protected void imgBtnClaimsData_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        Response.Redirect("ClaimsData.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    protected void btnOfflinePrescription_Click(object sender, ImageClickEventArgs e)
    {
        Session["ActiveTransactionTab"] = null;
        string key = Utils.Encrypt(((int)Enumerations.TRANSACTION_TYPE.CONSULTATION).ToString());
        string isOffine = Utils.Encrypt("1");
        Response.Redirect("TransactionPage.aspx?TransactionType=" + key + "&isOffine=" + isOffine, true);
    }

    protected void btnEligiblityCheck_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("http://175.100.150.187/mizoram_dev/Payer/PayerMemberSearch.aspx");
        Response.Redirect("https://claim.cmchistn.com/Payer/PayerMembersearch.aspx");
    }
}