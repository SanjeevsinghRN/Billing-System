<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery.validate.js"></script>
    <script src="Scripts/aes.js"></script>
    <script src="Scripts/md5.js"></script>
    <script type="text/javascript">

          $(document).ready(function () {
              $.getJSON('//jsonip.com/?callback=?', function (data) {
                 // alert(data.ip);
                document.getElementById('<%=hidipadd.ClientID%>').value = data.ip;
            });
        });

        function UnableToLogin(result) {
            if (result) {
                bootbox.hideAll();
                document.getElementById("<%=btnUnableToLogin.ClientID%>").click();
            }
        }

        function SendMail() {
            var $element = document.createElement("a");
            $element.setAttribute('href', $("[id$='hdnEmail']").val());
            $element.click(function (e) { e.preventDefault(); });
        }

        $(document).ready(function () {
            if ($('.bootbox-confirm in').is(':visible')) {
                bootbox.hideAll();
            }
            window.history.pushState(null, "", window.location.href);
        });

        function GeneratePwd() {
    
            if (document.getElementById("<%=txtPassword.ClientID%>").value != "") {
                 
                //document.getElementById("txtPassword").value = hex_md5(document.getElementById("txtPassword").value);
                var key = CryptoJS.enc.Utf8.parse(document.getElementById("hdnkey").value);
                var iv = CryptoJS.enc.Utf8.parse(document.getElementById("hdnkey").value);
                 
                var encryptedpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(document.getElementById("<%=txtPassword.ClientID%>").value.trim()), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });

                document.getElementById("<%=txtPassword.ClientID%>").value = encryptedpassword;
                return true;
            }
        }

    </script>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
<link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/components/logins/login-3/assets/css/login-3.css">
    <style>
        ::-webkit-input-placeholder {
            color: #DED7BD;
            opacity: 1; /* Firefox and Chrome */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: #DED7BD;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
            color: #DED7BD;
        }
         .loginbox {
   
    background: #0000006b;
    
}
         .Moving {
    background-size: 200% auto;
    color: #fff;
    background-clip: text;
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-image: linear-gradient(-225deg, #e61515 10%, #1b20cc 99%, #d46c17 67%, #0af5ed 100%);
    animation: textclip 3s ease infinite;
    font-weight: bold !important;
    font-size: 1.5rem; /* Adjust the font size as needed */
}

@keyframes textclip {
    0% {
        background-position: 0% 50%;
    }
    100% {
        background-position: 100% 50%;
    }
}

         @keyframes textclip {
    0% {
        background-position: 0% 50%;
    }
    100% {
        background-position: 100% 50%;
    }
}
    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:HiddenField ID="hidipadd" runat="server" />
     
  
        
       <!-- Login 3 - Bootstrap Brain Component -->
<section class="p-3 p-md-4 p-xl-5" id="loginForm">
  <div class="container">
    <div class="row">
      <div class="col-12 col-md-6 bsb-tpl-bg-platinum">
        <div class="d-flex flex-column justify-content-between h-100 p-3 p-md-4 p-xl-5">
          <h3 class="m-0">Welcome!</h3>
           

        <img src="Images/Loyal/draw22.svg" class="img-fluid" alt="Phone image" />
          <%--<p class="mb-0">Not a member yet? <a href="#!" class="link-secondary text-decoration-none">Register now</a></p>--%>
        </div>
      </div>
      <div class="col-12 col-md-6 bsb-tpl-bg-lotion">
        <div class="p-3 p-md-4 p-xl-5">
          <div class="row">
            <div class="col-12">
              <div class="mb-5">
                <h3>Log in</h3>
              </div>
            </div>
          </div>
          
            <div class="row gy-3 gy-md-4 overflow-hidden">
              <div class="col-12">
                <label for="txtUserName" class="form-label">User Id : <span class="text-danger">*</span></label>
                 <asp:TextBox ID="txtUserName" CssClass="fontSize12px logintextboxheight form-control" placeholder="User Id" Width="100%" runat="server" MaxLength="20" ></asp:TextBox>
              </div>
              <div class="col-12">
                <label for="password" class="form-label">Password <span class="text-danger">*</span></label>
               <asp:TextBox ID="txtPassword" CssClass="fontSize12px logintextboxheight form-control" placeholder="Please Enter Your Password" Width="100%" runat="server" TextMode="Password"  autocomplete="off" AutoCompleteType="None"></asp:TextBox>
              </div>
              <div class="col-12">
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="" name="remember_me" id="remember_me">
                  <label class="form-check-label text-secondary" for="remember_me">
                    Keep me logged in
                  </label>
                </div>
              </div>
              <div class="col-12">
                <div class="d-grid">
                     <asp:Button ID="btnLogin" runat="server" Text="Log in now" OnClick="btnLogin_Click" class="btn bsb-btn-xl btn-primary" OnClientClick="return GeneratePwd();" />
                  
                </div>
              </div>
            </div>
         
          <div class="row">
            <div class="col-12">
              <hr class="mt-5 mb-4 border-secondary-subtle">
              <div class="text-end">
                <a href="#!" class="link-secondary text-decoration-none">Forgot password</a>
              </div>
            </div>
          </div>
        
        </div>
      </div>
    </div>
  </div>
</section>
        <section  style="display:none;">
       
            <div class="form-group">
               
                <div class="col-md-offset-4 col-md-onset-4 col-md-4">
                   <%-- <asp:TextBox ID="txtUserName" CssClass="fontSize12px logintextboxheight form-control" placeholder="User Id" Width="100%" runat="server" MaxLength="20" ></asp:TextBox>--%>
                </div>
            </div>
            <div class="form-group">
               
                <div class="col-md-offset-4 col-md-onset-4 col-md-4" style="margin-top: -8px;">
                    <%--<asp:TextBox ID="txtPassword" CssClass="fontSize12px logintextboxheight form-control" placeholder="Please Enter Your Password" Width="100%" runat="server" TextMode="Password"  autocomplete="off" AutoCompleteType="None"></asp:TextBox>--%>
                </div>
            </div>
            <div class="form-group" style="display:none">
                <div class="col-md-offset-4 col-md-onset-4 col-md-4" style="margin-top: -8px;">
                    <div style="float: left; width: 40%; padding-top:1px; border-radius:3px; background-color:#fbfbf1" align="center">
                        <asp:Image ID="imgCaptcha" runat="server" />
                    </div>
                    <div style="float: left; width: 50%; padding-left:5px;" align="center">
                        <asp:TextBox ID="txtCaptcha" CssClass="fontSize12px logintextboxheight form-control" placeholder="Please Enter Captcha" Width="100%" runat="server" MaxLength="6" autocomplete="off" AutoCompleteType="None"></asp:TextBox>
                    </div>
                     <div style="float: right; width: 10%; padding-left:5px; padding-top:5px;" align="right">
                         <asp:ImageButton ID="imgbtnCaptcha" runat="server" ImageUrl="~/Images/RefreshCaptcha.png" OnClick="imgbtnCaptcha_Click" Width="30px" />
                    </div>
                </div>
            </div>
            <div class="form-group" style="display:none">
                <div class="col-md-offset-4 col-md-onset-4 col-md-4 ft-small">
                    <div class="row">
                        <%--<div class="col-lg-6 col-sm-6 col-xs-6 col-md-6">
                            <asp:LinkButton ID="lnkbtnSendOTP" runat="server" Text="Forgot MPIN" Style="color: white;" OnClick="lnkbtnSendOTP_Click"></asp:LinkButton>
                        </div>--%>
                        <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6" align="right">
                            <asp:LinkButton ID="lnkUnableToLogin" runat="server" Text="Unable to login?" Style="color: white;" OnClick="lnkUnableToLogin_Click"></asp:LinkButton>
                            <asp:Button ID="btnUnableToLogin" runat="server" Style="display: none" OnClick="btnUnableToLogin_Click" />
                            <asp:HiddenField ID="hdnEmail" runat="server" Value="" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="col-md-offset-4 col-md-onset-4 col-md-4 Moving" align="center">
                    <label style="color: white; margin-bottom: 18px; font-size: medium;">----- OR -----</label>
                </div>
                <div class="col-md-offset-4 col-md-onset-4 col-md-4 ft-small" align="center" style="margin-bottom: 8px">
                    <asp:LinkButton ID="lnkbtnLoginOption" runat="server" Text="Login with OTP" Style="color: white;" OnClick="lnkbtnLoginOption_Click"></asp:LinkButton>
                </div>
            </div>
            <div class="form-group" style="margin-top: 7px; margin-bottom: 7px;">
                <div class="col-md-offset-4 col-md-onset-4 col-md-4">
                   <%-- <asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" CssClass="button-radius-none btn btn-default" styele="background-color: #25b271 !important;" Width="100%" Height="40px" OnClientClick="return GeneratePwd();" />--%>
                </div>
            </div>
            <div class="form-group" style="margin-top: 14px;display:none">
                <div class="col-md-offset-4 col-md-onset-4 col-md-4">
                    <asp:Button ID="btnRegister" runat="server" Text="New User? Register Here!" OnClick="btnRegister_Click" CssClass="fontSize12px button-radius-none buttonShadow btn btn-transperent" Width="100%" Height="50px" />
                </div>
            </div>

       </section>


    <input type="hidden" value="8070506040201090" name="hdnkey" id="hdnkey" />

   <style>
        .well.form-horizontal.loginbox {
            position: relative;
            padding: 20px;
            border: 2px solid #ccc;
            transition: box-shadow 0.5s ease-in-out;
        }

        /* Glow effect when hovered */
        .well.form-horizontal.loginbox:hover {
            box-shadow: 0 0 20px 5px rgba(0, 123, 255, 0.7); /* Blue glow */
        }
    </style>
    <style>
        /* Add a transition effect to the inputs */
        .form-control {
            border: 2px solid #ccc;
            padding: 10px;
            transition: border-color 0.3s ease, transform 0.3s ease;
        }
        /* Welcome header styling */
        .login-header {
            text-align: center;
            margin-bottom: 20px;
            color: #007bff;
        }

        .login-header h2 {
            font-size: 24px;
            font-weight: bold;
        }
         @keyframes fadeSlideUp {
            0% {
                opacity: 0;
                transform: translateY(-20px);
            }
            100% {
                opacity: 1;
                transform: translateY(0);
            }
        }
      

        /* Glow effect when focused */
        .form-control:focus {
            box-shadow: 0 0 10px 2px rgba(0, 123, 255, 0.8);
            border-color: #007bff;
        }
    </style>


</asp:Content>

