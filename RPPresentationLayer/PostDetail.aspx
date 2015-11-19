<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true"
    CodeBehind="PostDetail.aspx.cs" Inherits="RPPresentationLayer.PostDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="PostDetailGridView" runat="server" OnSelectedIndexChanged="PostDetailGridView_SelectedIndexChanged">
        </asp:GridView>
    </div>
</asp:Content>
