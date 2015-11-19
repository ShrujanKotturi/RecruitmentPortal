<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true"
    CodeBehind="ShowPostings.aspx.cs" Inherits="RPPresentationLayer.ShowPostings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:LoginStatus ID="logoutLoginStatus" runat="server" 
    onloggingout="logoutLoginStatus_LoggingOut" />
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="showPostingsGridView" runat="server" 
    EnableModelValidation="True" DataKeyNames="PostId"
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="editButton" runat="server" OnClick="editButton_Click" Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="showApplicantsDetailsButton" runat="server" OnClick="showApplicantsDetailsButton_Click"
        Text="Show Applicants Details" Width="163px" CssClass="button" />
    <br />
    <br />
</asp:Content>
