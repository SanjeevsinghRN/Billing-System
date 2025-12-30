 
<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web" %>
 <%@ Import Namespace="RN.MOBILE_COMMON" %>

<script runat="server">



    void Application_Start(object sender, EventArgs e)
    {

    }


    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }

    void Application_Error(object sender, EventArgs e)
    {
        //Exception objErr = Server.GetLastError().GetBaseException();
        //ErrorLogger.LogMessage(objErr, ConfigurationManager.AppSettings.Get("ErrorLogPath"));
        //Response.Redirect("~/Login.aspx");

    }

    void Session_Start(object sender, EventArgs e)
    {
        //Session["tpaZone"] = "";
        //Session["msg"]="";

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        // Session.Clear();
        //  GC.Collect();


        #region Login_Audit_Log
        if (Application[Session.SessionID] == null || Convert.ToString(Application[Session.SessionID]) != "1")
        {
            string Auditlog_result = UserModel.loginAuditLog(Convert.ToString(Session[SessionConstant.UserID]), "", "", "", Session.SessionID, "", "Session_out");
            Application.Remove(Session.SessionID);
            string is_broker = ConfigurationManager.AppSettings.Get("is_broker");

            if (is_broker == "1")
            {
                string LogoutQuery = Request.Cookies["LogoutQuery"] != null ? Request.Cookies["LogoutQuery"].Value : "";
                Utils.ExpireAllCookies();
                if (!string.IsNullOrEmpty(LogoutQuery) && is_broker == "1")
                {
                    Response.Redirect("~/Login.aspx" + LogoutQuery + "", false);
                }
                else Response.Redirect("~/Login.aspx", false);
            }
        }
        #endregion

        Session.Abandon();
        //Session.RemoveAll();

        //Session.Clear();
        GC.Collect();


        /* SessionIDManager manager = new SessionIDManager();
         manager.RemoveSessionID(Context);
         var newId = manager.CreateSessionID(Context);
         var isRedirected = true;
         var isAdded = true;
         manager.SaveSessionID(System.Web.HttpContext.Current, newId, out isRedirected, out isAdded);*/

        //if (Request.Cookies["ASP.NET_SessionId"] != null)
        //{
        //    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
        //    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
        //}

        //SessionIDManager manager = new SessionIDManager();
        //manager.RemoveSessionID(System.Web.HttpContext.Current);
    }


</script>
