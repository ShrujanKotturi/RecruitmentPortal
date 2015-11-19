<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true"
    CodeBehind="ApplicantDetails.aspx.cs" Inherits="RPPresentationLayer.ApplicantDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Wrapper">
        <div class="row" style="display: table-row">
            <div class="cell">
                Candidate name:</div>
            <div class="cell">
                <asp:TextBox ID="candidateNameTextBox" runat="server" Enabled="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            </div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Years of experience:</div>
            <div class="cell">
                <asp:TextBox ID="yearsOfExperienceTextBox" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
            </div>
        </div>
        <div class="row">
            <div class="cell">
                Skill set</div>
            <div class="cell">
                <asp:TextBox ID="skillSetTextBox" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Address:</div>
            <div class="cell">
                <asp:TextBox ID="addressTextBox4" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Email id:</div>
            <div class="cell">
                <asp:TextBox ID="emailIdTextBox" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Phone number:</div>
            <div class="cell">
                <asp:TextBox ID="phoneNumberTextBox" runat="server" Enabled="False"></asp:TextBox></div>
        </div>
        &nbsp;<br />
        <div class="row">
            <div class="cell">
                Industry:</div>
            <div class="cell">
                <asp:TextBox ID="industryTextBox" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Current Position:</div>
            <div class="cell">
                <asp:TextBox ID="currentPositionTextBox" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Current Salary:</div>
            <div class="cell">
                <asp:TextBox ID="currentSalaryTextBox" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Expected Position:</div>
            <div class="cell">
                <asp:TextBox ID="expectedPositionTextBox" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
        </div>
        <br />
        <div class="row">
            <div class="cell">
                Expected Job Location:</div>
            <div class="cell">
                <asp:TextBox ID="expectedJobLocationTextBox" runat="server" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;</div>
        </div>
    </div>
</asp:Content>
