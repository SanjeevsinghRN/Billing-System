using RN.MOBILE_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Web.Security;

public partial class MasterPage_MasterMenu : System.Web.UI.MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    public static string MENU_BACKROUND_COLOR = string.Empty;
    public static string COLOR1 = string.Empty;
    public static string MenuColor = string.Empty;
    public static string SINGLE_BUTTON_ENDLAYOUT = string.Empty;
    public static string ENDLAYOUT_BUTTON_1 = string.Empty;
    public static string ENDLAYOUT_BUTTON_2 = string.Empty;
    public static string NORMAL_BUTTON = string.Empty;
    public static string NORMAL_BUTTON2 = string.Empty;
    public static string NORMAL_BUTTON3 = string.Empty;
    public static string ENTITY_FONT_COLOR = string.Empty;
    public static string HOME_PAGE_LOGO = string.Empty;
    public static string  HEADER_BACKROUND_COLOR = string.Empty;
    public static string menuArrow = string.Empty;
    public static string MenuSeperator = string.Empty;
    public static string NORMAL_BUTTON4 = string.Empty;
    public static string is_broker = ConfigurationManager.AppSettings.Get("is_broker");

    public string PageTitle = string.Empty;
    public string PageDescription = string.Empty;
    public string PageKeyWrod = string.Empty;

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
    public string evaluate(string normalBtncolor) {
        if (string.IsNullOrEmpty(normalBtncolor)) return "linear-gradient(to bottom, #f68121 0%, #f68121 100%)";
        else return "none !important";
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

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string is_broker = System.Configuration.ConfigurationManager.AppSettings.Get("is_broker");
                if (is_broker.Equals("1"))
                {

                    string BrokerName = System.Configuration.ConfigurationManager.AppSettings.Get("Broker_name");
                    PageTitle = BrokerName;
                    PageDescription = BrokerName;
                    PageKeyWrod = "Book Appointments with doctors,Medical Tests,Pharmacy Expenses,Cashless Insurance,online medicine";

                    metadescription.Content = PageDescription;
                    metakeyword.Content = PageKeyWrod;

                    if (!string.IsNullOrEmpty(Convert.ToString(Session[SessionConstant.UserID])))
                    {
                       // string APItoken = Validation.GetToken(MUtils.GetEncryptedKey(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy")));
                        string UserID = Convert.ToString(Session[SessionConstant.UserID]);
                        Consumer_Theme cTheme = new Consumer_Theme();
                        if (Session["Theme"] == null)
                        {
                           // cTheme = PatientModel.GetConsumerTheme(UserID, Convert.ToString(Session[SessionConstant.token]));
                            Session["Theme"] = cTheme;
                        }
                        else
                        {
                            cTheme = (Consumer_Theme)Session["Theme"];
                        }
                        MENU_BACKROUND_COLOR = cTheme.MENU_BACKROUND_COLOR;
                        COLOR1 = cTheme.COLOR1;
                        MenuColor = cTheme.MENU_TEXT_COLOR;
                        SINGLE_BUTTON_ENDLAYOUT = cTheme.SINGLE_BUTTON_ENDLAYOUT;
                        ENDLAYOUT_BUTTON_1 = cTheme.ENDLAYOUTBUTTON1;
                        ENDLAYOUT_BUTTON_2 = cTheme.ENDLAYOUTBUTTON2;
                        NORMAL_BUTTON = cTheme.NORMAL_BUTTON;
                        NORMAL_BUTTON2= cTheme.NORMAL_BUTTON2;
                        NORMAL_BUTTON3 = cTheme.NORMAL_BUTTON3;
                        NORMAL_BUTTON4 = cTheme.NORMAL_BUTTON3;
                        ENTITY_FONT_COLOR = "#469289";
                        HOME_PAGE_LOGO = "none";

                        string host = HttpContext.Current.Request.Url.AbsoluteUri;
                        if (host.Contains("ConsumerHomePage.aspx"))
                        {
                            HEADER_BACKROUND_COLOR = cTheme.HOMEPAGE_HEADER_COLOR;
                        }
                        else
                        {
                            HEADER_BACKROUND_COLOR = cTheme.HEADER_BACKROUND_COLOR;
                        }
                        menuArrow = cTheme.MENUARROW_COLOR;
                        MenuSeperator = cTheme.MENU_HEADER_COLOR;
                        imgLoader.ImageUrl = "../Images/loader-loop-loader-rn.gif?v=1.1";
                    }
                }
                else
                {
                    PageTitle = "Billing Details"; //"IL Take Care";
                    PageDescription = "Billing Details";
                    PageKeyWrod = "Billing Details";
                    metadescription.Content = PageDescription;
                    metakeyword.Content = PageKeyWrod;

                    ENTITY_FONT_COLOR = "#FFF";
                    HOME_PAGE_LOGO = "block";

                    SINGLE_BUTTON_ENDLAYOUT = "#ea5b0c";
                    ENDLAYOUT_BUTTON_1 = "#ea5b0c";
                    ENDLAYOUT_BUTTON_2 = "#a41c2b";
                    NORMAL_BUTTON = "#ea5b0c";
                    NORMAL_BUTTON2 = "#e8353b";
                    NORMAL_BUTTON3 = "#ea5b0c";
                    MenuColor= "#FFFFFF";
                    MenuSeperator = "#505050";
                    menuArrow = "#0d4083";
                    HEADER_BACKROUND_COLOR = "#ca5100";
                    imgLoader.ImageUrl = "../Images/Loyal/loading-animations-preloader-gifs-ui-ux-effects-19.gif?v=1.1";
                    NORMAL_BUTTON4 = "#ea5b0c";
                }

            }

            if (string.IsNullOrEmpty(Audit_LogUpdate.Value))
            {
                Audit_LogUpdate.Value = Session.SessionID;
            }
            if (!ValidateUserSession())
            {
                #region Login_Audit_Log

                string Auditlog_result = UserModel.loginAuditLog("", "", Utils.GetIPAddress(), "", Session.SessionID, "", "Session_out");

                #endregion


                string LogoutQuery = Request.Cookies["LogoutQuery"] != null ? Request.Cookies["LogoutQuery"].Value : "";
                if (!string.IsNullOrEmpty(LogoutQuery) && is_broker == "1")
                {
                    Response.Redirect("~/Login.aspx" + LogoutQuery + "", false);
                }
                else Response.Redirect("~/Login.aspx",false);
            }
            else
            {
                if (string.IsNullOrEmpty(Audit_UserId.Value))
                {
                    Audit_UserId.Value = Convert.ToString(Session[SessionConstant.UserID]);
                }
            }

            if (!Page.IsPostBack)
            {
                lblYear.Text = DateTime.Now.Year.ToString();

                if (Request.RawUrl.Contains("SearchBySpecialtyV") || Request.RawUrl.Contains("SearchLocationPage") || Request.RawUrl.Contains("DiagnosticSearch") || Request.RawUrl.Contains("SearchByPharmacyV") || Request.RawUrl.Contains("PrescriptionList.aspx") || Request.RawUrl.Contains("HospitalSearch.aspx"))
                {

                    imgCity.Visible = true;
                    btncityName.Visible = true;
                    if (Request.RawUrl.Contains("SearchLocationPage"))
                    {
                        imgCity.Visible = false;
                        btncityName.Enabled = false;
                    }
                }
                if (Request.RawUrl.Contains("Appointment.aspx") || Request.RawUrl.Contains("VitalDashBoardPage.aspx"))
                    btnFilterMaster.Visible = true;
                else
                    btnFilterMaster.Visible = false;

                if (Request.RawUrl.Contains("CustomerSupport.aspx"))
                    btnCall.Visible = true;
                else
                    btnCall.Visible = false;

                MenuListData();
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.LogMessage(ex, Utils.ErrorLogPath);
            throw;
        }
    }
    //public void MenuListData()
    //{
    //    MenuItemList menuItemList = null;
    //    string is_broker = ConfigurationManager.AppSettings["is_broker"];

    //    // Fetch the menu item list
    //    menuItemList = PatientModel.GenerateMenuListConsumer("0", Convert.ToString(Session[SessionConstant.token]));

    //    StringBuilder strb = new StringBuilder();
    //    if (Session != null && Session[SessionConstant.AuthStatus] != null && menuItemList != null && menuItemList.ParentMenu != null)
    //    {
    //        strb.Append("<ul class='nav navbar-nav desktopView'>");

    //        // Build the parent menu
    //        foreach (MenuItemData menu in menuItemList.ParentMenu)
    //        {
    //            // Skip certain menus based on conditions
    //            if (menu.Title.ToUpper() == "REIMBURSEMENT" &&
    //                (!string.IsNullOrEmpty(Convert.ToString(Session["IS_REM_ENABLED"])) && Convert.ToString(Session["IS_REM_ENABLED"]) == "0"))
    //            {
    //                continue;
    //            }

    //            // Handle specific menu actions
    //            if (menu.Title == "Policy Copy")
    //            {
    //                menu.Action += "?query=" + Utils.Encrypt("DownloadType=PolicyCopy&PolicyFileName=" + Session["PolicyFileName"]);
    //            }
    //            if (menu.Title == "Prescription Upload" &&
    //                (Session[SessionConstant.IsPrimaryMember] != null && Convert.ToBoolean(Session[SessionConstant.IsPrimaryMember])))
    //            {
    //                menu.Action += "?query=" + Utils.Encrypt("OfflinePrescription=1");
    //            }

    //            // Create the menu item
    //            strb.Append("<li class='DN' style='height:40px;line-height:39px' parent='" + menu.ParentMenuId + "'>");
    //            strb.Append("<a class='DB menu-color' href=\"" + menu.Action + "\" id=\"Menu" + menu.ID + "\">");
    //            strb.Append("<img class='menuIcon' src='../Images/" + menu.Title.Replace(" ", "_") + ".png' alt=''>" + menu.Title + "</a>");

    //            // Check for child menus
    //            if (menu.ChildMenu != null && menu.ChildMenu.Count > 0)
    //            {
    //                strb.Append("<ul class='dropdown-menu'>");
    //                foreach (var subMenu in menu.ChildMenu)
    //                {
    //                    // Create the submenu item
    //                    strb.Append("<li class='DN'>");
    //                    strb.Append("<a href=\"" + subMenu.Action + "\" id=\"Menu" + subMenu.ID + "\">" + subMenu.Title + "</a>");

    //                    // Check for sub-submenus
    //                    if (subMenu.ChildMenu != null && subMenu.ChildMenu.Count > 0)
    //                    {
    //                        strb.Append("<ul class='dropdown-menu'>");
    //                        foreach (var subSubMenu in subMenu.ChildMenu)
    //                        {
    //                            strb.Append("<li class='DN'>");
    //                            strb.Append("<a href=\"" + subSubMenu.Action + "\" id=\"Menu" + subSubMenu.ID + "\">" + subSubMenu.Title + "</a>");
    //                            strb.Append("</li>");
    //                        }
    //                        strb.Append("</ul>");
    //                    }
    //                    strb.Append("</li>");
    //                }
    //                strb.Append("</ul>");
    //            }

    //            strb.Append("</li>");
    //        }

    //        strb.Append("</ul>");
    //    }

    //    liMenuItem.InnerHtml = strb.ToString();
    //}
    public void MenuListData()
    {

        MenuItemList menuItemList = null;
        string is_broker = ConfigurationManager.AppSettings["is_broker"];
        // if (Session["CorporateCode"] != null && Session["CorporateCode"].ToString().Length > 0)
        // {
        ////     menuItemList = PatientModel.GenerateMenuListConsumer(Convert.ToString(Session["CorporateCode"]), Convert.ToString(Session[SessionConstant.token]));
        // }
        // else menuItemList = PatientModel.GenerateMenuListConsumer("0", Convert.ToString(Session[SessionConstant.token]));

        menuItemList = PatientModel.GenerateMenuListConsumer("0", Convert.ToString(Session[SessionConstant.token]));

        List<MenuItemData> lstMenu = new List<MenuItemData>();
        StringBuilder strb = new StringBuilder();
        if (Session != null && Session[SessionConstant.AuthStatus] != null && menuItemList != null && menuItemList.ParentMenu != null)
        {
            strb = new StringBuilder();
            strb.Append("<ul class='nav navbar-nav desktopView' style=''>");
            foreach (MenuItemData menu in menuItemList.ParentMenu)
            {
                if (menu.Title.ToUpper() == "REIMBURSEMENT")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["IS_REM_ENABLED"])) && Convert.ToString(Session["IS_REM_ENABLED"]) == "0")
                    {
                        continue;
                    }
                }

                if (menu.Title == "Policy Copy")
                {
                    menu.Action = menu.Action + "?query=" + Utils.Encrypt("DownloadType=PolicyCopy&PolicyFileName=" + Session["PolicyFileName"]);
                }
                if (menu.Title == "Prescription Upload")
                {
                    if (Session[SessionConstant.IsPrimaryMember] != null)
                    {
                        if (Convert.ToBoolean(Session[SessionConstant.IsPrimaryMember]))
                        {
                            menu.Action = menu.Action + "?query=" + Utils.Encrypt("OfflinePrescription=1");
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (menu.NewTab == 0)
                    strb.Append("<li class='DN' isMobile='1' style='height:40px;line-height:39px' onclick='showLoader();' parent='" + menu.ParentMenuId + "'>" + "<ul class='menu-wrapper'><li class='w90p fl'><a class='DB  menu-color' href=\"" + menu.Action + "\" id=\"Menu" + menu.ID + "\"><img class='menuIcon' src='../Images/" + menu.Title.Replace(" ", "_") + ".png' alt=''></img>" + menu.Title + "</a></li><li class='text-right menuArrow'>></li></ul></li>" + "");
                else strb.Append("<li class='DN' isMobile='1' style='height:40px;line-height:39px'  parent='" + menu.ParentMenuId + "'>" + "<ul class='menu-wrapper'><li class='w90p fl'><a class='DB  menu-color' href=\"" + menu.Action + "\" id=\"Menu" + menu.ID + "\" target='_blank'><img class='menuIcon' src='../Images/" + menu.Title.Replace(" ", "_") + ".png' alt=''></img>" + menu.Title + "</a></li><li class='text-right menuArrow'>></li></ul></li>" + "");
                if (menu.ParentMenuId == 0)
                {
                    if (menu.NewTab == 0)
                        strb.Append("<li class='DN' onclick='showLoader();' isMobile='0'>" + "<a href=\"" + menu.Action + "\" id=\"Menu" + menu.ID + "\">" + menu.Title + "</a>" + "</li>");
                    else
                        strb.Append("<li class='DN'  isMobile='0'>" + "<a href=\"" + menu.Action + "\" id=\"Menu" + menu.ID + "\" target='_blank'>" + menu.Title + "</a>" + "</li>");
                }
            }
            if (menuItemList.ChildMenu != null)
            {
                foreach (var SubMenu in menuItemList.ChildMenu)
                {
                    if (SubMenu.Title.ToUpper() == "REIMBURSEMENT")
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["IS_REM_ENABLED"])) && Convert.ToString(Session["IS_REM_ENABLED"]) == "0")
                        {
                            continue;
                        }
                    }

                    if (string.IsNullOrEmpty(SubMenu.Action))
                    {

                        strb.Append("<li isMobile='0' class='DN dropdown'>");
                        strb.Append("<a href='" + SubMenu.Action + "' class='dropdown-toggle' data-toggle='dropdown'>" + SubMenu.Title + "<b class='caret'></b></a>");
                        strb.Append("<ul class='dropdown-menu'>");
                    }

                    if (SubMenu.NewTab == 0)
                        strb.Append("<li class='DN' onclick='showLoader();' isMobile='0'>" + "<a href=\"" + SubMenu.Action + "\" id=\"Menu" + SubMenu.ID + "\">" + SubMenu.Title + "</a>" + "</li>");
                    else
                        strb.Append("<li class='DN'  isMobile='0'>" + "<a href=\"" + SubMenu.Action + "\" id=\"Menu" + SubMenu.ID + "\" target='_blank'>" + SubMenu.Title + "</a>" + "</li>");
                }
                strb.Append("</ul>");
                strb.Append("</li>");
            }
            strb.Append("</ul>");
        }
        liMenuItem.InnerHtml = strb.ToString();
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

                if (!string.IsNullOrEmpty(Convert.ToString(Session[SessionConstant.UserID].ToString())))
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

    protected void btncityName_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["TRANS_TYPE"] != null && Convert.ToInt16(Session["TRANS_TYPE"]) == (int)Enumerations.TRANSACTION_TYPE.DIAGNOSTIC)
                if (HttpContext.Current.Request.UrlReferrer.LocalPath.Contains("DiagnosticSearch"))
                {
                    if (((System.Web.UI.WebControls.HiddenField)(ContentPlaceHolder1.FindControl("hdnIsMap"))).Value == "true")
                    {
                        Session["IsMapView"] = "true";
                    }
                }
        }
        catch (Exception ex)
        {

        }

        Response.Redirect("SearchLocationPage.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(lblBAckUrl.Text);
    }

    protected void btnCall_Click(object sender, ImageClickEventArgs e)
    {
        string PhoneNumber = UserModel.GetCustomerSupportNumber(Convert.ToString(Session[SessionConstant.token]));
        Response.Redirect("tel:" + PhoneNumber, true);
    }
}
