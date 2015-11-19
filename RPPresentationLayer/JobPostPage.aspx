<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true"
    CodeBehind="JobPostPage.aspx.cs" Inherits="RPPresentationLayer.JobPostPage" %>

   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LoginStatus ID="logoutLoginStatus" runat="server" OnLoggingOut="logoutLoginStatus_LoggingOut" />
    <br />
    <asp:Label ID="uniqueCodeLabel" runat="server" Text="Unique Code"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="uniqueCodeTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="companyNameLabel" runat="server" Text="Company Name"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="companyNameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="postingIdLabel" runat="server" Text="Posting Id"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;
    <asp:TextBox ID="postingIdTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="positionNameLabel" runat="server" Text="Position Name"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="positionNameTextBox" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="positionNameTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="numberOfOpeningsLabel" runat="server" Text="Number of Openings"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="numberOfOpeningsTextBox" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="numberOfOpeningsTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:RegularExpressionValidator ID="numberOfOpeningsRegularExpressionValidator" runat="server"
        ControlToValidate="numberOfOpeningsTextBox" ErrorMessage="Should be numeric"
        ValidationExpression="([0-9]+)" ValidationGroup="jobPostGroup"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="locationOfOpeningsLabel" runat="server" Text="Location of Openings"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="locationOfOpeningsTextBox" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="locationOfOpeningsTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Experience Required"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="experienceRequiredTextBox" runat="server" ValidationGroup="jobPostGroup"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="experienceRequiredTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="skillSetLabel" runat="server" Text="Skill Set"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;
    <asp:TextBox ID="skillSetTextBox" runat="server" ValidationGroup="jobPostGroup"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="skillSetTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="tentativeSalaryLabel" runat="server" Text="Tentative Salary"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tentativeSalaryTextBox" runat="server" ValidationGroup="jobPostGroup"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tentativeSalaryTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="offerCloseDateLabel" runat="server" Text="Offer Close Date"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:TextBox ID="offerCloseDateTextBox" runat="server" ValidationGroup="jobPostGroup"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="offerCloseDateTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RegularExpressionValidator ID="offerCloseDateRegularExpressionValidator" runat="server"
        ErrorMessage="Enter date in dd/mm/yyyy format" ValidationExpression="((0[0-9]|[0-9]|1[0-9]|2[0-9]|3[0-1])[/]([0-9]|0[0-9]|1[0-2])[/](1[9][0-9][0-9]|2[0-9][0-9][0-9]))"
        ControlToValidate="offerCloseDateTextBox" ValidationGroup="jobPostGroup"></asp:RegularExpressionValidator>
    <br />
    &nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="expectedJoiningDateLabel" runat="server" Text="Expected Joining Date "></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="expectedJoiningDateTextBox" runat="server" ValidationGroup="jobPostGroup"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="expectedJoiningDateTextBox"
        ErrorMessage="Mandatory Field" ValidationGroup="jobPostGroup"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RegularExpressionValidator ID="expectedJoiningDateRegularExpressionValidator"
        runat="server" ErrorMessage="Enter date in dd/mm/yyyy format" ValidationExpression="((0[0-9]|[0-9]|1[0-9]|2[0-9]|3[0-1])[/]([0-9]|0[0-9]|1[0-2])[/](1[9][0-9][0-9]|2[0-9][0-9][0-9]))"
        ControlToValidate="expectedJoiningDateTextBox" ValidationGroup="jobPostGroup"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Button ID="jobPostButton" runat="server" OnClick="jobPostButton_Click" Text="Job Post"
        ValidationGroup="jobPostGroup" CssClass="button" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="showPostingsButton" runat="server" Enabled="False" Text="Show Postings"
        Visible="False" OnClick="showPostingsButton_Click" CssClass="button" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Button ID="updateButton" runat="server" Enabled="False" OnClick="updateButton_Click"
        Text="Update" Visible="False" Width="76px" CssClass="button" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="showApplicantsDetailsButton" runat="server" Enabled="False" Text="Show Applicants Details "
        Visible="False" Width="155px" OnClick="showApplicantsDetailsButton_Click" CssClass="button" />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <br />
</asp:Content>
