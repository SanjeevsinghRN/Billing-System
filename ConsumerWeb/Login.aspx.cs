using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RN.MOBILE_COMMON;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Web.SessionState;
using System.Reflection;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    public static string WebApiToken;
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    static string memberId = string.Empty;
    public static string ENTITY_CAPTCHA = string.Empty;
    public static string is_broker = ConfigurationManager.AppSettings.Get("is_broker");
    //static string corporateCode = string.Empty;

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    //First, check for the existence of the Anti-XSS cookie
    //    var requestCookie = Request.Cookies[AntiXsrfTokenKey];
    //    Guid requestCookieGuidValue;
    //    Page.ViewStateUserKey = RN.MOBILE_COMMON.MUtils.EncryptPassword(Session.SessionID);
    //    //If the CSRF cookie is found, parse the token from the cookie.
    //    //Then, set the global page variable and view state user
    //    //key. The global variable will be used to validate that it matches in the view state form field in the Page.PreLoad
    //    //method.
    //    if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
    //    {
    //        //Set the global token variable so the cookie value can be
    //        //validated against the value in the view state form field in
    //        //the Page.PreLoad method.
    //        _antiXsrfTokenValue = requestCookie.Value;

    //        //Set the view state user key, which will be validated by the
    //        //framework during each request
    //        Page.ViewStateUserKey = _antiXsrfTokenValue;
    //    }
    //    //If the CSRF cookie is not found, then this is a new session.
    //    else
    //    {
    //        //Generate a new Anti-XSRF token
    //        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");

    //        //Set the view state user key, which will be validated by the
    //        //framework during each request
    //        Page.ViewStateUserKey = _antiXsrfTokenValue;

    //        //Create the non-persistent CSRF cookie
    //        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
    //        {
    //            //Set the HttpOnly property to prevent the cookie from
    //            //being accessed by client side script
    //            HttpOnly = true,

    //            //Add the Anti-XSRF token to the cookie value
    //            Value = _antiXsrfTokenValue
    //        };

    //        //If we are using SSL, the cookie should be set to secure to
    //        //prevent it from being sent over HTTP connections
    //        if (System.Web.Security.FormsAuthentication.RequireSSL && Request.IsSecureConnection)
    //            responseCookie.Secure = true;

    //        //Add the CSRF cookie to the response
    //        Response.Cookies.Set(responseCookie);
    //    }

    //    Page.PreLoad += master_Page_PreLoad;
    //}

    //protected void master_Page_PreLoad(object sender, EventArgs e)
    //{
    //    //During the initial page load, add the Anti-XSRF token and user
    //    //name to the ViewState
    //    if (!IsPostBack)
    //    {
    //        //Set Anti-XSRF token
    //        ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

    //        //If a user name is assigned, set the user name
    //        ViewState[AntiXsrfUserNameKey] = RN.MOBILE_COMMON.MUtils.EncryptPassword(Session.SessionID);
    //    }
    //    //During all subsequent post backs to the page, the token value from
    //    //the cookie should be validated against the token in the view state
    //    //form field. Additionally user name should be compared to the
    //    //authenticated users name
    //    else
    //    {
    //        //Validate the Anti-XSRF token
    //        if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue || (string)ViewState[AntiXsrfUserNameKey] != RN.MOBILE_COMMON.MUtils.EncryptPassword(Session.SessionID))
    //        {
    //            throw new InvalidOperationException("Validation of Anti - XSRF token failed.");

    //        }
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Add("IPAddress", hidipadd.Value);
        Application[Session.SessionID] = "0";
  
       
        
        #region Captcha button Configuration

        string is_broker = ConfigurationManager.AppSettings.Get("is_broker");
        if (is_broker == "1")
        {
            string query = HttpUtility.UrlDecode(Request.QueryString.Get("query"));
            Response.Cookies["LogoutQuery"].Value = Request.Url.Query;
            if (!string.IsNullOrEmpty(query) && query.Split('|').Length > 0)
            {
                Response.Cookies["EntityCode"].Value = query.Split('|')[0];
                Response.Cookies["EntityName"].Value = query.Split('|')[1];
            }
            else
            {
                Response.Cookies["EntityCode"].Value = string.Empty;
                Response.Cookies["EntityName"].Value = string.Empty;
            }
            ENTITY_CAPTCHA = "~/Images/RefreshCaptcha_green.png";
        }
        else
        {
            ENTITY_CAPTCHA = "~/Images/RefreshCaptcha.png";
        }
        imgbtnCaptcha.ImageUrl = ENTITY_CAPTCHA;

        #endregion

        if (!Page.IsPostBack)
        {
            //Title = "Login";
            //Session.Clear();
            //Session.Abandon();
            //Session.RemoveAll();
            AddImageToCaptcha();
            txtUserName.Focus();
            lnkbtnLoginOption_Click(null, EventArgs.Empty);
            CheckBrowser();

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "<script type=\"text/javascript\">CheckBrowser2();</script>", false);

        }
        Session["IL_INTEGRATION_SERVICE_TYPE"] = "0";
    }

    protected void AddImageToCaptcha()
    {
        MemoryStream ms = null;
        try
        
        {
            txtCaptcha.Text = "";
            ViewState["captcha"] = Utils.RandomAlphaNumericString(6);
           // txtCaptcha.Text = ViewState["captcha"].ToString();
           // txtUserName.Text = "8109149740";
            ms = CreateCaptcha(ViewState["captcha"].ToString());
            imgCaptcha.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
            ms.Dispose();
        }
        catch
        {
            throw;
        }
        finally
        {
            if (ms != null)
                ms.Dispose();
        }
    }

    private MemoryStream CreateCaptcha(string MyString)
    {
        MemoryStream objms = new MemoryStream();
        Bitmap bmp = null;
        Graphics g = null;
        try
        {
            int height = 35;
            int width = 100;
            bmp = new Bitmap(width, height);

            RectangleF rectf = new RectangleF(8, 5, 0, 0);

            g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#fbfbf1"));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(MyString, new Font("--abhiswiss721btroman", 14, FontStyle.Regular), Brushes.Green, rectf);

            //g.DrawRectangle(new Pen(Color.Blue), 1, 1, width - 2, height - 2);
            g.Flush();
            bmp.Save(objms, ImageFormat.Jpeg);
            g.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (g != null)
            {
                g.Dispose();
            }

            if (bmp != null)
                bmp.Dispose();

        }
        return objms;
    }

    private bool CheckBrowser()
    {
        bool IsRedReq = false;
        try
        {
            //HttpRequestBase baseRequest = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request as HttpRequestBase;
            //HttpBrowserCapabilitiesBase browser = baseRequest.Browser;
            System.Web.HttpBrowserCapabilities browser = Request.Browser;

            if (browser.Browser.Contains("Firefox") || browser.Browser.Contains("Opera") || browser.Browser.Contains("IE") || browser.Browser.Contains("InternetExplorer") || browser.Browser.Contains("Mozilla"))
            {
                Server.Transfer("~/BrowserCompatiability.aspx", false);
            }
            if (Request.UserAgent.Contains("OPR/") || Request.UserAgent.Contains("UCBrowser/") || Request.UserAgent.Contains("Firefox/") || Request.UserAgent.Contains("MiuiBrowser/")
                || Request.UserAgent.Contains("Opera/") || Request.UserAgent.Contains("MSIE") || Request.UserAgent.Contains("Edge/") || Request.UserAgent.Contains("FxiOS") || Request.UserAgent.Contains("OPiOS/") || Request.UserAgent.Contains("EdgA"))
            {
                Server.Transfer("~/BrowserCompatiability.aspx", false);
            }
            if (!Request.UserAgent.Contains("Chrome") && !Request.UserAgent.Contains("Safari"))
            {
                Server.Transfer("~/BrowserCompatiability.aspx", false);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return IsRedReq;
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string Message = string.Empty;
            //bool IsOTPLogin = false;
            //if (lnkbtnSendOTP.Text.Contains("OTP"))
            //    IsOTPLogin = true;

            if (string.IsNullOrEmpty(txtUserName.Text) )
            {
                Message = Resources.AlertMessage.Invalid_Login_UserId;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
               // if (IsOTPLogin)
                    Message += "<br/>" + Resources.AlertMessage.Invalid_Login_Password;
                
            }
          
           
            // regenerateId();
            if (string.IsNullOrEmpty(Message))
            {
                //if (IsOTPLogin)
                //    CheckOTPCredentials();
               // else
                    CheckCredentials();
            }
            else
            {
                ShowAlert(Message, Utils.AlertHeader);
            }
            Response.Redirect("~/Modules/Dashboard_Emp.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
    }


    private void CheckCredentials()
    {
        bool isNewEncryption = false;
        try
        {
            LoginUser _user = new LoginUser();
            string pwd = AESEncrytDecry.DecryptStringAES(txtPassword.Text.Trim());

            string EncrPass = MUtils.EncryptPassword(pwd);
            string EncrPass_new = MUtils.EncryptPassword_New(pwd);

            _user = UserModel.CheckCredential( txtUserName.Text, pwd);
            if (_user != null)
            {
                if (_user.Error != "001" && _user.Error != "006")
                {
                    isNewEncryption = true;
                    _user = UserModel.CheckCredential( txtUserName.Text, EncrPass_new);
                }
                if (_user != null)
                {
                    if (_user.Error == "001")
                    {
                        int IsAgreed = 0;
                        string sessionID = regenerateId();
                        ViewState[AntiXsrfUserNameKey] = MUtils.EncryptPassword(sessionID);
                        Session[SessionConstant.UserID] = _user.UserID.ToString();
                        //Session[SessionConstant.EmailID] = _user.EmailID;
                        //Session[SessionConstant.LoginID] = _user.LoginID;
                        //Session[SessionConstant.MobileNo] = _user.MobileNo;
                        //Session[SessionConstant.UserName] = _user.UserName;
                        //Session[SessionConstant.UserType] = _user.UserType;
                        //Session[SessionConstant.LastLoginTime] = _user.LastLoginTime;
                        if (isNewEncryption)
                            Session[SessionConstant.Password] = EncrPass_new;
                        else
                            Session[SessionConstant.Password] = EncrPass;

                        Session[SessionConstant.token] = _user.token;
                        //Session[SessionConstant.IsPrimaryMember] = (_user.IsPrimaryMember == "1") ? true : false;
                        //Session[SessionConstant.Is_Disable_flag] = _user.Is_Disable_flag;
                        Session[SessionConstant.AuthStatus] = true;
                        //IsAgreed = _user.IsDisclaimerAgreed;
                        //Session["CorporateCode"] = _user.CorporateCode;

                        ////Session["broker_code"] = _user.broker_code;
                        //Utils.broker_code = _user.broker_code;
                        Session.Add("IPAddress", hidipadd.Value);

                        //string PolicyFileName = UserModel.GetPolicyNumber(Session[SessionConstant.UserID].ToString(), Utils.PayerCode);
                        //Session["PolicyFileName"] = PolicyFileName;


                        //if (string.IsNullOrWhiteSpace(memberId))
                        //    memberId = PatientModel.GetMemberID(Convert.ToString(Session[SessionConstant.UserID]), Utils.PayerCode);
                        //Session[SessionConstant.MemberID] = memberId;

                        //corporateCode = PatientModel.GetCorporateCode(memberId, Utils.PayerCode);
                        //Session[SessionConstant.corporateCode] = corporateCode;

                        //UserModel.UpdateUserLoginTime(_user.UserID.ToString());
                        Response.Redirect("~/Modules/Dashboard_Emp.aspx", false);

                        #region Login_Audit_Log

                        // regenerateId();
                      //  string Auditlog_result = UserModel.loginAuditLog(_user.UserID.ToString(), "", Convert.ToString(Session["IPAddress"]), "", sessionID, "", "Login");

                        #endregion
                    }
                    //else if (_user.Error == "006")
                    //{
                    //    ShowAlert(_user.ErrorDesc, Utils.AlertHeader);
                    //}
                    else
                    {
                        AddImageToCaptcha();
                        ShowAlert(Resources.AlertMessage.Wrong_Login_Credentials, Utils.AlertHeader);
                    }
                }
                else
                {
                    AddImageToCaptcha();
                    ShowAlert(Resources.AlertMessage.Wrong_Login_Credentials, Utils.AlertHeader);
                }
            }
            else
            {
                AddImageToCaptcha();
                ShowAlert(Resources.AlertMessage.Wrong_Login_Credentials, Utils.AlertHeader);
            }

        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }

    }
    protected void lnkbtnLoginOption_Click(object sender, EventArgs e)
    {
        try
        {
            if (lnkbtnLoginOption.Text.Contains("MPIN"))
            {
               // lnkbtnSendOTP.Text = "Forgot MPIN";
                // lblOTP.Text = "M-PIN";
                txtPassword.Attributes.Add("placeholder", "Please Enter MPIN");
                lnkbtnLoginOption.Text = "Login with OTP";
            }
            else
            {
                //lnkbtnSendOTP.Text = "Send OTP";
                // lblOTP.Text = "OTP";
                txtPassword.Attributes.Add("placeholder", "Please Enter Your Password");
                lnkbtnLoginOption.Text = "Login with MPIN";
            }
            if (string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text.Length != 10)
                txtUserName.Focus();
            else
                txtPassword.Focus();
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string LogoutQuery = Request.Cookies["LogoutQuery"]!=null?Request.Cookies["LogoutQuery"].Value:"";
        if (!string.IsNullOrEmpty(LogoutQuery) && is_broker == "1")
        {
            Response.Redirect("Registration.aspx" + LogoutQuery + "", true);
        }
        else {
            Response.Redirect("Registration.aspx", true);
        }
    }
    //protected void lnkbtnSendOTP_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (lnkbtnSendOTP.Text.Contains("OTP"))
    //        {
    //            if (string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text.Length != 10)
    //            {
    //                ShowAlert(Resources.AlertMessage.Invalid_Login_Mobile_No, Utils.AlertHeader);
    //                txtUserName.Focus();
    //                return;
    //            }
    //            ValidateMobileNoAndSendOTP();

    //        }
    //        else
    //        {
    //            string LogoutQuery = Request.Cookies["LogoutQuery"] != null ? Request.Cookies["LogoutQuery"].Value : "";
    //            if (!string.IsNullOrEmpty(LogoutQuery) && is_broker == "1")
    //            {
    //                Response.Redirect("ForgotMPIN.aspx" + LogoutQuery + "", true);
    //            }
    //            else Response.Redirect("ForgotMPIN.aspx");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
    //    }
    //}

   
    public void ShowAlert(string msg, string title = "")
    {
        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("is_broker")))
        {
            if (ConfigurationManager.AppSettings.Get("is_broker") == "1")
            {
                title = Utils.AlertHeader;
            }
        }
        if (string.IsNullOrEmpty(title))
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Show Alert", "bootbox.alert('" + msg + "')", true);
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Show Alert", "bootbox.alert({title: '" + title + "',message:'" + msg + "'})", true);
    }
    protected void btnbrowsercheck_Click(object sender, EventArgs e)
    {
        try
        {
            Server.Transfer("~/BrowserCompatiability.aspx", false);
            //Response.Redirect("~/BrowserCompatiability.aspx");
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
    }
    protected void lnkUnableToLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("is_broker")))
            {
                if (ConfigurationManager.AppSettings.Get("is_broker") == "1")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Show Alert", "bootbox.confirm({title:'" + Utils.AlertHeader + "',message: '" + Resources.AlertMessage.UnableToLogin + "',buttons: {cancel: {label: 'Cancel',className: 'invisible'},confirm: {label: 'ok',className: 'btn-primary'}},callback: function (result) {UnableToLogin(result);}})", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Show Alert", "bootbox.confirm({title:'" + Utils.AlertHeader + "',message: '" + Resources.AlertMessage.UnableToLogin + "',buttons: {cancel: {label: 'Cancel',className: 'invisible'},confirm: {label: 'ok',className: 'btn-primary'}},callback: function (result) {UnableToLogin(result);}})", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Show Alert", "bootbox.confirm({title:'" + Utils.AlertHeader + "',message: '" + Resources.AlertMessage.UnableToLogin + "',buttons: {cancel: {label: 'Cancel',className: 'invisible'},confirm: {label: 'ok',className: 'btn-primary'}},callback: function (result) {UnableToLogin(result);}})", true);

            }

        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
    }


    protected void btnUnableToLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string contact_email_id = string.Empty;
            //if (string.IsNullOrWhiteSpace(contact_email_id))
            //    contact_email_id = PatientModel.GetcontactEmalID();

            string subject = "OPD-Unable to login";
            string uriString = "mailto:" + contact_email_id + "?subject=" + subject + "&body=";
            hdnEmail.Value = uriString;
            ScriptManager.RegisterStartupScript(Page, GetType(), "SendMail", "<script>SendMail();</script>", false);
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
    }

    protected void imgbtnCaptcha_Click(object sender, ImageClickEventArgs e)
    {
        AddImageToCaptcha();
    }


    private string regenerateId()
    {
        string newId = string.Empty;
        System.Web.SessionState.SessionIDManager manager = null;
        try
        {
            manager = new System.Web.SessionState.SessionIDManager();
            string oldId = manager.GetSessionID(Context);
            newId = manager.CreateSessionID(Context);
            bool isAdd = true, isRedir = true;
            manager.SaveSessionID(System.Web.HttpContext.Current, newId, out isRedir, out isAdd);
            HttpApplication ctx = (HttpApplication)HttpContext.Current.ApplicationInstance;
            HttpModuleCollection mods = ctx.Modules;
            System.Web.SessionState.SessionStateModule ssm = (SessionStateModule)mods.Get("Session");
            System.Reflection.FieldInfo[] fields = ssm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            SessionStateStoreProviderBase store = null;
            System.Reflection.FieldInfo rqIdField = null, rqLockIdField = null, rqStateNotFoundField = null;
            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.Name.Equals("_store")) store = (SessionStateStoreProviderBase)field.GetValue(ssm);
                if (field.Name.Equals("_rqId")) rqIdField = field;
                if (field.Name.Equals("_rqLockId")) rqLockIdField = field;
                if (field.Name.Equals("_rqSessionStateNotFound")) rqStateNotFoundField = field;
            }
            object lockId = rqLockIdField.GetValue(ssm);
            if ((lockId != null) && (oldId != null)) store.ReleaseItemExclusive(Context, oldId, lockId);
            rqStateNotFoundField.SetValue(ssm, true);
            rqIdField.SetValue(ssm, newId);
        }
        catch (Exception ex)
        {
            //WriteCustomErrorLog("", ex.Message.ToString(), "regenerateId", "loginppn.aspx.cs");
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
        }
        finally
        {
            if (manager != null)
                manager = null;
        }
        return newId;
    }
}

