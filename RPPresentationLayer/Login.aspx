<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RPPresentationLayer.Login"
    MasterPageFile="~/RecruitmentPortal.Master" %>
    <%@ MasterType VirtualPath="~/RecruitmentPortal.Master" %> 
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 312px">
        <div class="table">
            <div class="row">
                <div class="cell">
                    Username:</div>
                <div class="cell">
                    <asp:TextBox ID="userNameTextBox" runat="server" />
                    &nbsp;<asp:RequiredFieldValidator ID="rfvUser" ErrorMessage="Please enter Username" ControlToValidate="userNameTextBox"
                        runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
            </div>
            <div class="row">
                <div class="cell">
                    Password:</div>
                <div class="cell">
                    <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPWD" runat="server" ControlToValidate="passwordTextBox"
                        ErrorMessage="Please enter Password" />
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <div >
                    
                    <asp:Button ID="submitButton" runat="server" Text="Login" OnClick="submitButton_Click"
                         CssClass="button"  ForeColor="White" Width="175px" Height="43px" /></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <div class="cell">
                        <asp:HyperLink ID="newUserLink" runat="server" NavigateUrl="~/UserRegistration.aspx">New user register here</asp:HyperLink></div>
                </div>
            </div>
    </div>
</asp:Content>
