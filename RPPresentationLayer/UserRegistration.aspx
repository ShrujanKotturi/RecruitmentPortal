<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs"
    Inherits="RPPresentationLayer.UserRegistration" MasterPageFile="~/RecruitmentPortal.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1">
    <div>
        <div class="table">
            <div class="row">
                <div class="cell">
                    User ID:</div>
                <div class="cell">
                    <asp:TextBox ID="userIdTextBox" runat="server" MaxLength="30"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="userIdTextBox"
                        ErrorMessage="*mandatory filed"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="cell">
                    User Name:</div>
                <div class="cell">
                    <asp:TextBox ID="userNameTextBox" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="userNameTextBox"
                        ErrorMessage="*mandatory filed"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="cell">
                    Password:</div>
                <div class="cell">
                    <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="passwordTextBox"
                        ErrorMessage="*mandatory filed"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="passwordTextBox"
                        ErrorMessage=" should have minimum 8 chars ,1 spl char" SetFocusOnError="True"
                        ValidationExpression="^(?=.*[a-zA-Z])(?=.*[#?!@$%^&amp;*-]).{8,}$"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="cell">
                    Role:</div>
                <div class="cell">
                    <asp:DropDownList ID="roleDropDownLis" runat="server" CssClass="white">
                        <asp:ListItem>--select--</asp:ListItem>
                        <asp:ListItem>JobSeeker</asp:ListItem>
                        <asp:ListItem>Recruiter</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="roleDropDownLis"
                        ErrorMessage="*mandatory filed"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="cell">
                    <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" 
                        Text="Create" CssClass="button" Height="31px" Width="100px" />
                    <br />
                    <br />
                    <br />
                </div>
                <!--<asp:Label ID="messageLabel" runat="server" Text="Label"></asp:Label>-->
                <br />
            </div>
        </div>
    </div>
    </form>
</asp:Content>
