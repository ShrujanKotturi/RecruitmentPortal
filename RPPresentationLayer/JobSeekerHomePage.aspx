<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true" CodeBehind="JobSeekerHomePage.aspx.cs" Inherits="RPPresentationLayer.JobSeekerHomePage" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:LoginStatus ID="logoutLoginStatus" runat="server" 
    onloggingout="logoutLoginStatus_LoggingOut" />
<br />
   
    <br />
    <a href="#" onServerClick="editJobseekerProfileAnchor" runat="server">Edit Job Seeker Profile..</a><br />
    <br />
    <br />
    <a href="#" onServerClick="jobSearchAndApplyAnchor" runat="server">Job Search and Apply..</a><br />
    <br />
    <br />
    <a href="#" onServerClick="interviewScheduleAnchor" runat="server">Get Interview Schedule..</a><br />
    <br />
    <br />
    <a id="A1" href="#" onServerClick="viewMatchingJobAnchor" runat="server">view matching jobs..</a><br />
    <br />
    <br />
</asp:Content>
