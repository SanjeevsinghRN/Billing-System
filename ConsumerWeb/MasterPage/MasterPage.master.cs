using RN.MOBILE_COMMON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MasterPage_MasterPage : System.Web.UI.MasterPage
{
    public static string urlImage = string.Empty;
    public static string urllogos = string.Empty;
    public static string btncolor = string.Empty;
    public string PageTitle = string.Empty;
    public string PageDescription = string.Empty;
    public string PageKeyWrod = string.Empty;
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    public static string ENTITY_LOGO = string.Empty;
    public static string ENTITY_FONT_COLOR = string.Empty;
    public static string ENTITY_BG_IMG = string.Empty;
    public static string is_broker = ConfigurationManager.AppSettings.Get("is_broker");
    protected void Page_Init(object sender, EventArgs e)
    {
        //First, check for the existence of the Anti-XSS cookie
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        Page.ViewStateUserKey = RN.MOBILE_COMMON.MUtils.EncryptPassword(Session.SessionID);
        //If the CSRF cookie is found, parse the token from the cookie.
        //Then, set the global page variable and view state user
        //key. The global variable will be used to validate that it matches in the view state form field in the Page.PreLoad
        //method.
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            //Set the global token variable so the cookie value can be
            //validated against the value in the view state form field in
            //the Page.PreLoad method.
            _antiXsrfTokenValue = requestCookie.Value;

            //Set the view state user key, which will be validated by the
            //framework during each request
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        //If the CSRF cookie is not found, then this is a new session.
        else
        {
            //Generate a new Anti-XSRF token
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");

            //Set the view state user key, which will be validated by the
            //framework during each request
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            //Create the non-persistent CSRF cookie
            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                //Set the HttpOnly property to prevent the cookie from
                //being accessed by client side script
                HttpOnly = true,

                //Add the Anti-XSRF token to the cookie value
                Value = _antiXsrfTokenValue
            };

            //If we are using SSL, the cookie should be set to secure to
            //prevent it from being sent over HTTP connections
            if (System.Web.Security.FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                responseCookie.Secure = true;

            //Add the CSRF cookie to the response
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

            //If a user name is assigned, set the user name
            ViewState[AntiXsrfUserNameKey] = RN.MOBILE_COMMON.MUtils.EncryptPassword(Session.SessionID);
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue || (string)ViewState[AntiXsrfUserNameKey] != RN.MOBILE_COMMON.MUtils.EncryptPassword(Session.SessionID))
            {
                UserModel.loginAuditLog(Audit_UserId.Value, "", "", "", Audit_LogUpdate.Value, "", "logout");
                string LogoutQuery = Request.Cookies["LogoutQuery"] != null ? Request.Cookies["LogoutQuery"].Value : "";
                if (!string.IsNullOrEmpty(LogoutQuery) && is_broker == "1")
                {
                    Response.Redirect("~/Login.aspx" + LogoutQuery + "");
                }
                else Response.Redirect("~/Login.aspx");
             
            }
        }
    }

    public string EvaluateBG(string backgroundImage)
    {
        if (!string.IsNullOrEmpty(backgroundImage)) return backgroundImage;
        else
        {
           
           
            return "none";
        }
    }
    public string EvaluateBG_logo(string backgroundImage)
    {
        if (!string.IsNullOrEmpty(backgroundImage)) return backgroundImage;
        else
        {

            return "none";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (is_broker=="1")
        {
            string broker_code = Request.Cookies["EntityCode"]!=null? Request.Cookies["EntityCode"].Value:null;
            string BrokerName = System.Configuration.ConfigurationManager.AppSettings.Get("Broker_name");
            PageTitle = BrokerName;            
            PageDescription = BrokerName;
            PageKeyWrod = "Book Appointments with doctors,Medical Tests,Pharmacy Expenses,Cashless Insurance,online medicine";

            metadescription.Content = PageDescription;
            metakeyword.Content = PageKeyWrod;

            string brokerLogo = "";// PatientModel.GetEntityLogo(broker_code, Convert.ToString(Session[SessionConstant.token]));
            brokerLogo = brokerLogo.Substring(1, brokerLogo.Length - 2);
            if (!string.IsNullOrEmpty(brokerLogo) && brokerLogo !="null")
            {
                ENTITY_LOGO = "~/Images/BrokerCorpLogo/" + brokerLogo;
               imgEntityLogo.Visible = true;
               
            }
            else
            {
                ENTITY_LOGO = "";
                imgEntityLogo.Visible = false;
            }
            ENTITY_FONT_COLOR = "#fff";
            ENTITY_BG_IMG = "~/Images/background_login.jpg";

        }
        else
        {
            PageTitle = "Billing Login";//"IL Take Care";
            PageDescription = "Billing Login";
            PageKeyWrod = "Billing Login";
            metadescription.Content = PageDescription;
            metakeyword.Content = PageKeyWrod;
            ENTITY_LOGO = "~/Images/splash_logo.png";
            ENTITY_FONT_COLOR = "#fff";
            ENTITY_BG_IMG = "~/Images/background_login.jpg";
            //ENTITY_BG_IMG = "~/Images/SATS/TEST/background_login.jpg";
        }
        imgEntityLogo.ImageUrl = EvaluateBG_logo(ENTITY_LOGO);
        if (string.IsNullOrEmpty(Audit_LogUpdate.Value))
        {
            Audit_LogUpdate.Value = Session.SessionID;
        }

        if (!string.IsNullOrEmpty(Convert.ToString(Session[SessionConstant.UserID])))
        {
            if (string.IsNullOrEmpty(Audit_UserId.Value))
            {
                Audit_UserId.Value = Convert.ToString(Session[SessionConstant.UserID]);
            }
        }

       
    }

    public bool ValidateUserSession()
    {
        bool IsValid = false;
        try
        {
            if (Session[SessionConstant.AuthStatus] != null && Session[SessionConstant.UserID] != null)
            {
                if (Convert.ToBoolean(Session[SessionConstant.AuthStatus].ToString()))
                    IsValid = true;

                if (Convert.ToInt32(Session[SessionConstant.UserID].ToString()) > 0)
                    IsValid = true;
            }
            else
                IsValid = false;
        }
        catch (Exception)
        {
            IsValid = false;
        }
        return IsValid;
    }
}
