<%@ Page Title="" MasterPageFile="~/MasterPage/MasterMenu.master" Language="C#" AutoEventWireup="true" CodeFile="ConsumerHomePage.aspx.cs" Inherits="Modules_ConsumerHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/masterMenu.js"></script>

    <script>
        function DivClicked() {
            var btnHidden = $('#<%= btnFamilyCard.ClientID %>');
            if (btnHidden != null) {
                btnFamilyCard.click();
            }
        }
    </script>

    <style>
        .BackGroundImageClass {
            background-image: url(<%=BG_IMAGEIN%>);
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-horizontal" oncontextmenu="return false" style="margin: 0 -15px">
        <div class="container" style="height: 100%;">
            <div class="row">
                <div class="col-md-6 col-xs-6">
                </div>
                <div class="col-md-6 col-xs-6" style="padding: 0">
                    <div class="pull-right homePageLogo" style="position: fixed; top: 0px; z-index: 4446; right: 1px;">
                        <img src=<%=LOGO%> height="50" width="60" />
                    </div>
                </div>
            </div>
            <div class="row mx-0 px-0 loginbox" style="margin-top: -1px; padding-bottom: 10px;">
                <div class="mx-0 px-0" style="margin-top: 5px; background-image: url('../images/SAST/TEST/test.png');">
                    <div class="col-lg-4 col-sm-4 col-xs-4 col-md-4" id="divProfileImg" runat="server" style="margin-top: 20px; margin-right: 5px">
                        <img src="../images/01_Male-Profile.png" id="imgProfile" runat="server" class="img-circle" width="90" height="90" />
                    </div>

                    <div class="col-lg-7 col-sm-7 col-xs-7 col-md-7" style="margin-top: 17px;">
                        <div class="row">
                            <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12 p0px" style="margin-top: 5px; display: flex;">
                                <asp:Label ID="lblUserName" runat="server" Font-Bold="true" CssClass="fontSize13px control-label NameTextColor labelWrapStyle1"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12 p0px" style="display: none;" id="divCorporate" runat="server">
                                <asp:Label ID="lblCoporate" runat="server" Font-Bold="false" CssClass="ontrol-label NameTextColor new-font-size2"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12 p0px">
                                <asp:Label ID="lblCardNo" runat="server" CssClass="control-label NameTextColor new-font-size2"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12 p0px">
                                <asp:Label ID="lblPolicyNumber" runat="server" Font-Bold="false" Visible="true" CssClass="ontrol-label NameTextColor new-font-size2"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12 p0px">
                                <asp:Label ID="lblLastVisit" runat="server" CssClass="new-font-size1 control-label NameTextColor"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mx-0 px-0 loginbox heigth100p ">

                <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12">
                    <div class="row loginbox_family" id="divFamilyDetails" onclick="javascript:DivClicked(); return true;" runat="server" visible="false" style="height: 55px">
                        <div class="col-lg-2 col-sm-2 col-xs-2 col-md-2" style="margin-top: 5px; margin-left: 25px; height: 40px">
                            <img src="../images/12_Family.png" class="" style="border-color: white; padding-top: 4px; padding-bottom: 4px" width="40" height="40" />
                        </div>

                        <div class="col-lg-7 col-sm-7 col-xs-7 col-md-7" style="margin-top: 13px; padding-right: 0">
                            <div class="row">
                                <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12">
                                    <asp:Label ID="Label3" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Family" Font-Bold="true"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12" style="padding-right: 0">
                                    <asp:Label ID="Label5" runat="server" CssClass="control-label DefaultTextColor new-font-size3" Text="View e-card and family profile from here" Font-Size="10px"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-1 col-sm-1 col-xs-1 col-md-1" style="margin-top: 18px; height: 20px;">
                            <asp:ImageButton ID="btnFamilyCard" runat="server" Width="20" Height="20" ImageUrl="../images/13_Righ-Arrow.png" ClientIDMode="Static" OnClick="btnFamilyCard_Click" />
                        </div>
                    </div>

                    <div class="container-fluid loginbox" style="margin-top: 5px; margin-left: -5px; margin-right: -5px;">

                        <div class="row" style="margin-bottom: 8px; margin-top: 5px; margin-left: 0; margin-right: 0">
                            <asp:Label ID="Label18" runat="server" CssClass="fontSize13px control-label HomePageTextColor" Font-Bold="true" Text="Speciality Wise Hospital List"></asp:Label>
                        </div>
                        <div class="row" style="margin-bottom: 45px; margin-top: 8px">

                            <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-center pdlr-0px" style="margin-top: 2px; height: 75px;">
                                <asp:ImageButton ID="btnBookConsultation" runat="server" OnClientClick="showLoader();" ImageUrl="~/Images/Sast/Hospital.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnBookConsultation_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label6" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Hospitals"></asp:Label>
                                </div>
                            </div>

                            <div id="divhide" runat="server" >
                         <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-center pdlr-0px" style="margin-top: 2px; height: 75px;">

                                <asp:ImageButton ID="btnEligiblityCheck" OnClientClick="showLoader();" runat="server" ImageUrl="../images/Sast/eligible.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnEligiblityCheck_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label7" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Eligibility Check"></asp:Label>
                                </div>
                            </div>

                           <%--    <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;display:none">

                                <asp:ImageButton ID="btnBookDiagnostic" OnClientClick="showLoader();" runat="server" ImageUrl="../images/04_Diagnostic.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnBookDiagnostic_Click" />

                                <div class="PB4px">
                                    <asp:Label ID="Label8" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Diagnostics"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;display:none">

                                <asp:ImageButton ID="btnBookHealthcheckup" OnClientClick="showLoader();" runat="server" ImageUrl="../images/HealthCheckup_V1.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnBookHealthcheckup_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label9" runat="server" CssClass="new-font-size1 control-label Color  HomePageTextColor" Text="Health Check-up"></asp:Label>
                                </div>
                            </div>

                             <div style="margin-top: 75px;" runat="server" id="divHospitals" visible="false">
                                <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;">

                                    <asp:ImageButton ID="btnHospital" runat="server" OnClientClick="showLoader();" ImageUrl="../images/01_Consultation.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnBookHospital_Click" />
                                    <div class="PB4px">
                                        <asp:Label ID="Label2" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Hospital"></asp:Label>
                                    </div>
                                </div>
                            </div>--%>
                            </div>
                        </div>

                        <div class="row Border" style="margin-bottom: 8px; padding-top: 4px; margin-left: 0; margin-right: 0" runat="server" visible="false" >
                            <asp:Label ID="Label19" runat="server" CssClass="fontSize13px control-label HomePageTextColor" Font-Bold="true" Text="Coverage"></asp:Label>
                        </div>
                        <div class="row" style="margin-bottom: 25px; margin-top: 8px" runat="server" visible="false">

                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;">
                                <asp:ImageButton ID="btnPolicyCoverage" OnClientClick="showLoader();" runat="server" ImageUrl="../images/10_Policy-Cover.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnPolicyCoverage_Click" />

                                <div class="PB4px">
                                    <asp:Label ID="Label10" runat="server" CssClass="new-font-size2 control-label TextColor1" Text="Policy Cover"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;">

                                <asp:ImageButton ID="btnConsulat_Coverage" OnClientClick="showLoader();" runat="server" ImageUrl="../images/02_Consultation_Benefits.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnConsulat_Coverage_Click" />

                                <div class="PB4px">
                                    <asp:Label ID="Label11" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Consultation"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;">

                                <asp:ImageButton ID="btnPharmacy_coverage" OnClientClick="showLoader();" runat="server" ImageUrl="../images/08_Pharmacy_Benefits.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnPharmacy_coverage_Click" />

                                <div class="PB4px">
                                    <asp:Label ID="Label12" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Pharmacy"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;">
                                <asp:ImageButton ID="btnDiagnostic_coverage" OnClientClick="showLoader();" runat="server" ImageUrl="../images/05_Diagnostic_Benefits.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnDiagnostic_coverage_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label13" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Diagnostic"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row Border" style="margin-bottom: 8px; padding-top: 4px; margin-left: 0; margin-right: 0">
                            <asp:Label ID="Label20" runat="server" CssClass="fontSize13px control-label HomePageTextColor" Font-Bold="true" Text="Transaction History"></asp:Label>
                        </div>
                        <div class="row" style="margin-top: 8px; margin-bottom: 25px;">
                           <%-- <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;">--%>
                                 <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-center pdlr-0px" style="margin-top: 2px; height: 75px;">
                                <asp:ImageButton ID="btnAllHistory" OnClientClick="showLoader();" runat="server" ImageUrl="../images/11_All-Transaction.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnAllHistory_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label14" runat="server" CssClass="new-font-size2 control-label TextColor1" Text="All"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-center pdlr-0px" style="margin-top: 2px; height: 75px; display:none">
                                <asp:ImageButton ID="btnConsultationHistory" OnClientClick="showLoader();" runat="server" ImageUrl="../images/03_Consultation_Utilize.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnConsultationHistory_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label15" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Consultation"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" runat="server" visible="false">
                                <asp:ImageButton ID="btnPharmacyHistory" OnClientClick="showLoader();" runat="server" ImageUrl="../images/09_Pharmacy_Utilize.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnPharmacyHistory_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label16" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Pharmacy"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" runat="server" visible="false">
                                <asp:ImageButton ID="btnDiagnosticHistory" OnClientClick="showLoader();" runat="server" ImageUrl="../images/06_Diagnostic_Utilize.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnDiagnosticHistory_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label17" runat="server" CssClass="new-font-size2 control-label HomePageTextColor" Text="Diagnostic"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-top: 8px; margin-bottom: 40px;" runat="server" visible="false">
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" runat="server" id="divReimbursementHistory" visible="false">
                                <asp:ImageButton ID="btnReimbursementHistory" OnClientClick="showLoader();" runat="server" ImageUrl="../images/11_All-Transaction.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnReimbursementHistory_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label23" runat="server" CssClass="new-font-size1 control-label TextColor1" Text="Reimbursement"></asp:Label>
                                </div>
                            </div>

                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" id="divInpatientDetails" runat="server" visible="false">
                                <asp:ImageButton ID="btnInPatientDetails" OnClientClick="showLoader();" runat="server" ImageUrl="../images/11_All-Transaction.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnInPatientDetails_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label4" runat="server" CssClass="new-font-size1 control-label HomePageTextColor" Text="InPatient Details"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" id="divNetWorkHospital" runat="server" >
                                <asp:ImageButton ID="imgBtnNetwrkHosp" OnClientClick="showLoader();" runat="server" ImageUrl="../images/11_All-Transaction.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="imgBtnNetwrkHosp_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label1" runat="server" CssClass="new-font-size1 control-label HomePageTextColor" Text="Network Hospital"></asp:Label>
                                </div>
                            </div>
                             <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" id="divClaimSData" runat="server" >
                                <asp:ImageButton ID="imgBtnClaimsData" OnClientClick="showLoader();" runat="server" ImageUrl="../images/11_All-Transaction.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="imgBtnClaimsData_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label21" runat="server" CssClass="familyMemberCardHeaderFont control-label HomePageTextColor" Text="Claims Data"></asp:Label>
                                </div>
                            </div>
                             <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" id="divClaimIntimation" runat="server">
                                <asp:ImageButton ID="imgBtnClaimIntimation" OnClientClick="showLoader();" runat="server" ImageUrl="../images/11_All-Transaction.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="imgBtnClaimIntimation_Click" />
                                <div class="PB4px">
                                    <asp:Label ID="Label22" runat="server" CssClass="familyMemberCardHeaderFont control-label HomePageTextColor" Text="Claim Intimation"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 text-center pdlr-0px" style="margin-top: 2px; height: 40px;" runat="server" id="divOfflinePrescription" visible="false">
                                <asp:ImageButton ID="btnOfflinePrescription" OnClientClick="showLoader();" runat="server" ImageUrl="../images/03_Consultation_Utilize.png" Style="max-height: 100%; max-width: 100%" ClientIDMode="Static" OnClick="btnOfflinePrescription_Click"  />
                                <div class="PB4px">
                                    <asp:Label ID="Label24" runat="server" CssClass="new-font-size1 control-label HomePageTextColor" Text="Offline Prescription"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
