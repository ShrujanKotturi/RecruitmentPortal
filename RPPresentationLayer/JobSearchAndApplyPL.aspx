<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true"
    CodeBehind="JobSearchAndApplyPL.aspx.cs" Inherits="RPPresentationLayer.JobSearchAndApplyPL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1089px">
        <asp:LoginStatus ID="logoutLoginStatus" runat="server" OnLoggingOut="logoutLoginStatus_LoggingOut" />
        <br />
        <asp:Label ID="CompanyNameLabel" runat="server" Text="Company Name"></asp:Label></div>
    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
    <div>
        <asp:TextBox ID="CompanyNameTextBox" runat="server"></asp:TextBox></div>
    <br />
    <div>
        <asp:Label ID="PositionNameLabel" runat="server" Text="Position Name"></asp:Label></div>
    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
    <div>
        <asp:TextBox ID="PositionNameTextBox" runat="server"></asp:TextBox></div>
    <br />
    <div>
        <asp:Label ID="ExperienceRequiredLabel" runat="server" Text="Experience Required"></asp:Label></div>
    <%--&nbsp;&nbsp;--%>
    <div>
        <asp:TextBox ID="ExperianceRequiredTextBox" runat="server" CssClass="textbox"></asp:TextBox></div>
    <br />
    <div>
        <asp:Label ID="LocationOfOpeningLabel" runat="server" Text="Location Of Opening"></asp:Label></div>
    <%--&nbsp;--%>
    <div>
        <asp:TextBox ID="LocationOfOpeningTextBox" runat="server"></asp:TextBox></div>
    <br />
    <div>
        <asp:Label ID="SkillsetLabel" runat="server" Text="SkillSet"></asp:Label></div>
    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
    <div>
        <asp:TextBox ID="SkillSetTextBox" runat="server"></asp:TextBox></div>
    <br />
    <%--</div>--%>
    <div style="height: 25px">
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
    </div>
    <div>
        <asp:GridView ID="SearchResultGridView" runat="server" OnDataBound="SearchResultGridView_DataBound"
            OnSelectedIndexChanged="SearchResultGridView_SelectedIndexChanged" OnRowCommand="SearchResultGridView_RowCommand"
            CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField Text="Apply Now" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
                <asp:BoundField DataField="UniqueCode" HeaderText="UniqueCode" />
                <asp:BoundField DataField="LocationOfOpening" HeaderText="LocationOfOpening" />
                <asp:BoundField DataField="Skillset" HeaderText="Skillset" />
                <asp:BoundField DataField="TentativeSalary" HeaderText="TentativeSalary" />
                <asp:BoundField DataField="ExperienceRequired" HeaderText="ExperienceRequired" />
                <asp:BoundField DataField="PositionName" HeaderText="PositionName" />
                <asp:BoundField DataField="NumberOfOpening" HeaderText="NumberOfOpening" />
                <asp:BoundField DataField="CloseDate" HeaderText="CloseDate" />
                <asp:TemplateField HeaderText="PostId">
                    <ItemTemplate>
                        <asp:HyperLink ID="PostIdHyperLink" Text='<% #Bind("PostId")%>' ToolTip='<% #Bind("PostId") %>'
                            onclick="PostDetail(this)" Style="text-decoration: underline; cursor: pointer;
                            color: Blue;" runat="server">
                        </asp:HyperLink>
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
        <asp:Label ID="YouHaveAlreadyApplyedLabel" runat="server" Text="You have applied these jobs"
            Visible="False"></asp:Label>
    </div>
    <asp:GridView ID="AppliedJobSearchGridView" runat="server" CellPadding="4" EnableModelValidation="True"
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Already Applied"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
            <asp:BoundField DataField="UniqueCode" HeaderText="UniqueCode" />
            <asp:BoundField DataField="LocationOfOpening" HeaderText="LocationOfOpening" />
            <asp:BoundField DataField="Skillset" HeaderText="Skillset" />
            <asp:BoundField DataField="TentativeSalary" HeaderText="TentativeSalary" />
            <asp:BoundField DataField="ExperienceRequired" HeaderText="ExperienceRequired" />
            <asp:BoundField DataField="PositionName" HeaderText="PositionName" />
            <asp:BoundField DataField="NumberOfOpening" HeaderText="NumberOfOpening" />
            <asp:BoundField DataField="CloseDate" HeaderText="CloseDate" />
            <asp:TemplateField HeaderText="PostId">
                <ItemTemplate>
                    <asp:HyperLink ID="PostIdHyperLink" Text='<% #Bind("PostId")%>' ToolTip='<% #Bind("PostId") %>'
                        onclick="PostDetail(this)" Style="text-decoration: underline; cursor: pointer;
                        color: Blue;" runat="server">
                    </asp:HyperLink>
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
</asp:Content>
