<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true"
    CodeBehind="ShowApplicantsDetailsPL.aspx.cs" Inherits="RPPresentationLayer.ShowApplicantsDetailsPL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function trigger() {
        alert("hi");
    }
</script>
    <div>
        <asp:LoginStatus ID="logoutLoginStatus" runat="server" OnClientClick="aspnetForm.target ='_self';" OnLoggingOut="logoutLoginStatus_LoggingOut" />
        <br />
        Show Applicants Details&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <div>
        &nbsp;&nbsp;&nbsp;
    </div>
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <div style="width: 743px; height: 258px">
        <asp:GridView ID="applicantsDetailsGridView" runat="server" Width="189px" AutoGenerateRows="False"
            Font-Size="Medium" AutoGenerateColumns="False" OnSelectedIndexChanged="applicantsDetailsGridView_SelectedIndexChanged"
            EnableModelValidation="True" OnRowCancelingEdit="applicantsDetailsGridView_RowCancelingEdit"
            OnRowEditing="applicantsDetailsGridView_RowEditing" OnRowUpdating="applicantsDetailsGridView_RowUpdating"
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" AllowPaging="True" PageSize="5" OnPageIndexChanging="applicantsDetailsGridView_PageIndexChanging"
            DataSourceID="SqlDataSource1" Style="margin-bottom: 0px" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="CandidateName">
                    <ItemTemplate>
                        <asp:HyperLink ID="CandidateNameHyperLink" Text='<% #Bind("CandidateName")%>' ToolTip='<% #Bind("CandidateName") %>'
                            onclick="JobSeekerDetails(this)" Style="text-decoration: underline; cursor: pointer;
                            color: Blue;" runat="server">
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="YearsOfExp" HeaderText="YearsOfExp" />
                <asp:BoundField DataField="SkillSet" HeaderText="SkillSet" />
                <asp:BoundField DataField="PostId" HeaderText="PostId" />
                <asp:TemplateField HeaderText="InterviewStatus">
                    <ItemTemplate>
                        <asp:CheckBox ID="interviewStatusCheckBox" runat="server" Checked="false" AutoPostBack="true"
                            OnCheckedChanged="InterviewStatusCheckBox_CheckedChanged" ValidationGroup="interviewDateValidateGroup" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="InterviewDatetime">
                    <ItemTemplate>
                        <asp:TextBox ID="interviewDatetimeTextBox" runat="server" Enabled="true" AutoPostBack="true"
                            ReadOnly="true" Text='<%# Eval("InterviewDatetime") %>' CausesValidation="True"
                            ValidationGroup="interviewDateValidateGroup" OnTextChanged="interviewDatetimeTextBox_TextChanged"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="interviewDatetimeValidator" runat="server" ControlToValidate="interviewDatetimeTextBox"
                            ErrorMessage="Incorrect Data" ValidationExpression="([0][0-9]|[1][0-9]|[2][0-9]|[3][0-1])[ ](Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[ ](2[0][0-9][0-9])[ ]([0][0-9]|[1][0-9]|[2][0-4])[:]([0][0-9]|[1][0-9]|[2][0-9]|[3][0-9]|[4][0-9]|[5][0-9])[:]([0][0-9]|[1][0-9]|[2][0-9]|[3][0-9]|[4][0-9]|[5][0-9])"
                            Display="Dynamic" ValidationGroup="interviewDateValidateGroup"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Comments" HeaderText="Comments" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Buttonid" runat="server" HeaderText="Resume`" CommandName="LoanItem"
                        OnClientClick="aspnetForm.target ='_blank';"
                        Text="Resume"
                            OnClick="Button_click_event"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle ForeColor="Black" BackColor="#EEEEEE" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RecruitmentPortalDBConnectionString %>"
            SelectCommand="uspShowApplicantsDetails" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="2" Name="RecruiterLoginId" SessionField="LoginId"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;<asp:Button ID="UpdateAllButton" runat="server" Text="UpdateAll" OnClientClick="aspnetForm.target ='_self';" OnClick="updateButton_Click"
            CssClass="button" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="findMoreProfileButton" runat="server" Text="Find More Profiles" OnClientClick="aspnetForm.target ='_self';" OnClick="findMoreProfileButton_Click"
            CssClass="button" />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
