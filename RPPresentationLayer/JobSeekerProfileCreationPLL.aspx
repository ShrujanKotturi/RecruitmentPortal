<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobSeekerProfileCreationPLL.aspx.cs"
    Inherits="RPPresentationLayer.JobSeekerProfileCreationPLL" MasterPageFile="~/RecruitmentPortal.Master" %>
    <%@ MasterType VirtualPath="~/RecruitmentPortal.Master" %> 
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        A:link
        {
            color: black;
            text-decoration: none;
            font-weight: normal;
        }
        A:visited
        {
            color: black;
            text-decoration: none;
            font-weight: normal;
        }
        A:active
        {
            color: black;
            text-decoration: none;
        }
        A:hover
        {
            color: blue;
            text-decoration: none;
            font-weight: none;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <form id="form1" >
        <div>
            <div id="Wrapper">
            <div  class="Row">
   
    <asp:LoginStatus ID="logoutLoginStatus" runat="server" 
    onloggingout="logoutLoginStatus_LoggingOut" />
                <br />
                <asp:Label ID="userNameLabel" runat="server" Text="user name"></asp:Label>
               
            </div>
                <div class="row" style="display: table-row">
                    <div class="cell">
                        Candidate name:</div>
                    <div class="cell">
                        <asp:TextBox ID="candidateNameTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="candidateNameTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="candidateNameTextBox"
                            ErrorMessage="should contain only alphabhets" 
                            ValidationExpression="^([a-zA-Z\s])+$" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:RegularExpressionValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Years of experience:</div>
                    <div class="cell">
                        <asp:TextBox ID="yearsOfExperienceTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="yearsOfExperienceTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Skill set</div>
                    <div class="cell">
                        <asp:TextBox ID="skillSetTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="skillSetTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Address:</div>
                    <div class="cell">
                        <asp:TextBox ID="addressTextBox4" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="addressTextBox4"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Email id:</div>
                    <div class="cell">
                        <asp:TextBox ID="emailIdTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="emailIdTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Phone number:</div>
                    <div class="cell">
                        <asp:TextBox ID="phoneNumberTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="phoneNumberTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="phoneNumberTextBox"
                            ErrorMessage="phone no should be like these 011 – 2239920" 
                            ValidationExpression="^([0-9]{3}[-][0-9]{7})$" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:RegularExpressionValidator></div>
                </div>
                &nbsp;<br />
                <br />
                <div class="row">
                    <div class="cell">
                        Industry:</div>
                    <div class="cell">
                        <asp:TextBox ID="industryTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="industryTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Current Position:</div>
                    <div class="cell">
                        <asp:TextBox ID="currentPositionTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator8" runat="server" ControlToValidate="currentPositionTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Current Salary:</div>
                    <div class="cell">
                        <asp:TextBox ID="currentSalaryTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator9" runat="server" ControlToValidate="currentSalaryTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Expected Position:</div>
                    <div class="cell">
                        <asp:TextBox ID="expectedPositionTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator10" runat="server" ControlToValidate="expectedPositionTextBox"
                            ErrorMessage="*mandatory field" ValidationGroup="JobSeekerValidationGroup"></asp:RequiredFieldValidator></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="cell">
                        Expected Job Location:</div>
                    <div class="cell">
                        <asp:TextBox ID="expectedJobLocationTextBox" runat="server" 
                            ValidationGroup="JobSeekerValidationGroup"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                         <div class="row">
                    <div class="cell">
                        Upload Resume:</div>
                    <div class="cell">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                       <%-- <script type="text/javascript">

                            $(document).ready(function () {
                                $("#FileUpload1").focusouts(function () {
                                    jQuery.validator.setDefaults({
                                        debug: true,
                                        sucess: "valid"
                                    });
                                    $("#FileUpload1").validate({
                                        rules: {
                                            field: {
                                                required: true,
                                                accept: "pdf/doc/docx"
                                            }
                                        }
                                    });
                                });
                            });
                        </script>--%>
                    <!--<asp:Label ID="messageLabel" runat="server" Text="messageLabel"></asp:Label>-->
                    <br />
                    <br />
                    <div class="row">
                        <div class="cell">
                            <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" 
                                Text="save" CssClass="button" Width="89px" 
                                ValidationGroup="JobSeekerValidationGroup" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="cancelButton" runat="server" Text="Cancel" CssClass="button" 
                                Width="90px" onclick="cancelButton_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                <a href="#" onServerClick="jobSearchAndApply" runat="server">Job Search and Apply</a><br />
                            <br />
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="cell">
                            </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
   
</asp:Content>
