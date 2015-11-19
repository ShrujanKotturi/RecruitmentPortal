<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitmentPortal.Master" AutoEventWireup="true" CodeBehind="JobPostingApprovalByAdmin.aspx.cs" Inherits="RPPresentationLayer.JobPostingApprovalByAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 309px;
            height: 97px;
        }
        .style4
        {
            width: 308px;
        }
        .style5
        {
            width: 282px;
        }
        .style6
        {
            width: 282px;
            height: 97px;
        }
    </style>
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 192px">
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
   
    <asp:LoginStatus ID="logoutLoginStatus" runat="server" 
    onloggingout="logoutLoginStatus_LoggingOut" />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" BackColor="White" 
            BorderColor="#666699" BorderStyle="Solid" BorderWidth="2px" Font-Size="Large" 
            Font-Underline="True" ForeColor="Black" onclick="LinkButton1_Click" 
            Width="194px">Job Posting Approvals</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" BackColor="Gray" 
            BorderColor="#666699" BorderStyle="Solid" BorderWidth="2px" Font-Size="Large" 
            Font-Underline="True" ForeColor="Black" onclick="LinkButton2_Click" 
            Width="171px">Interview Approvals</asp:LinkButton>
        <br />
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server" EnableTheming="False">
            <div id="ViewBy" align="center">
        <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Larger" 
                    Text="Jop Posting Approvals"></asp:Label>
        <br />
        <br />
        <div id="ViewByDiv">
        <asp:Label ID="Label1" runat="server" Text="View by : "></asp:Label>
        &nbsp;&nbsp;
        <asp:RadioButton ID="AllRadioButton" runat="server" AutoPostBack="True" 
            Checked="True" GroupName="ViewByGroup1" Value="All" 
            oncheckedchanged="AllRadioButton_CheckedChanged" />
            &nbsp;All&nbsp;&nbsp;
            <asp:RadioButton ID="RecruiterRadioButton" runat="server" AutoPostBack="True" 
                GroupName="ViewByGroup1" oncheckedchanged="RecruiterRadioButton_CheckedChanged" 
                Value="Recruiter" />
            &nbsp;Recriter&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="StatusRadioButton" runat="server" AutoPostBack="True" 
            GroupName="ViewByGroup1" Value="Status" 
            oncheckedchanged="RadioButton3_CheckedChanged" />
            &nbsp;Status&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</div>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" Height="59px" style="margin-left: 55px" 
            Width="567px" Visible="False">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="EnterCompanyNameLabel" runat="server" 
                Text="Enter Company Name :"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="ViewByCompanyNameTextBox" runat="server" Height="25px" 
                Width="170px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ViewByCompanyNameButton" runat="server" Text="View" 
                Width="74px" onclick="ViewByCompanyNameButton_Click1" CssClass="button" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="SelectStatusLabel" runat="server" Text="Select Status : "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="ViewByStatusDropDownList" runat="server" Height="25px" 
                Width="170px" AutoPostBack="True" 
                onselectedindexchanged="ViewByStatusDropDownList_SelectedIndexChanged">
                <asp:ListItem Selected="True">--Select Status--</asp:ListItem>
                <asp:ListItem>Approved</asp:ListItem>
                <asp:ListItem>Rejected</asp:ListItem>
                <asp:ListItem>Closed</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
        <br />
         </div>
         <div style="height: 410px">
         
             <br />
             <asp:GridView ID="DetailsGridView" runat="server" AllowPaging="True" 
                 CellPadding="4" EnableModelValidation="True" GridLines="None" 
                 HorizontalAlign="Center" ForeColor="#333333">
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                     <asp:TemplateField HeaderText="Approve">
                         <ItemTemplate>
                             <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Group1" />
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Reject">
                         <ItemTemplate>
                             <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Group1" />
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Close">
                         <ItemTemplate>
                             <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Group1" />
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <EditRowStyle BackColor="#2461BF" />
                 <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EFF3FB" />
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             </asp:GridView>
         
             <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="SaveButton" runat="server" onclick="SaveButton_Click" 
                 Text="Save" CssClass="button" Height="34px" Width="66px" />
         
    </div>
            </asp:View>

            <!--***********************************************************************************-->

            <asp:View ID="View2" runat="server" EnableTheming="False">
            <div align="center">
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Larger" 
                    Text="Interview Approvals"></asp:Label>
                </div>
                  <div id="Div1" align="left">
                      <br />
        <br />
        <table style="height: 183px; margin-left: 123px; width: 786px;" >
            <tr>
                <td class="style6">
                    <asp:Panel ID="SortByPanel" runat="server" Height="29px"
                    Width="295px">
                    
                        <asp:Label ID="Label2" runat="server" Text="Sort Details by : "></asp:Label>
                            &nbsp; &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Height="20px" 
                        Width="113px" style="margin-left: 0px" AutoPostBack="True" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Selected="True">--Select--</asp:ListItem>
                  <asp:ListItem Value="UniqueCode">Unique Code</asp:ListItem>
                  <asp:ListItem Value="CompanyName">Company Name</asp:ListItem>
                  <asp:ListItem Value="InterviewDate">Interview Date</asp:ListItem>
                </asp:DropDownList>
                </asp:Panel>
                </td>
                <td class="style3">
                    <asp:Panel ID="LoadByPanel" runat="server" Height="52px"
                    Width="498px" style="margin-left: 5px">
                      
                        Get Details By&nbsp;&nbsp; :&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="CompanyNameRadioButton1" runat="server" 
                            oncheckedchanged="CompanyNameRadioButton1_CheckedChanged1" 
                            Value="CompanyName" AutoPostBack="True" GroupName="Group1" />
                        &nbsp;&nbsp;Company Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="IVDateRadioButton1" runat="server" 
                            oncheckedchanged="IVDateRadioButton1_CheckedChanged1" 
                            Value="InterviewDate" AutoPostBack="True" GroupName="Group1" />
                     
                        &nbsp;Interview Date</asp:Panel>
                </td>
            </tr>

            <tr>
                <td class="style5"></td>
                <td class="style4">
                    <asp:Panel ID="LoadPanel" runat="server" Height="81px" style="margin-left: 0px" 
                     Width="453px" Visible="False">
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" 
                Text="Enter Company Name :"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:TextBox ID="ViewByCompanyNameTextBox2" runat="server" Height="25px" 
                Width="170px"></asp:TextBox>
                         &nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <br />
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ViewButton" runat="server" Text="View" onclick="ViewButton_Click" 
                             CssClass="button" Width="61px" />
                     </asp:Panel>
                </td>
            </tr>
        </table>
                <br />
         </div>
    
        <br />
       
         
         <div style="height: 410px">
         
                          <asp:GridView ID="DetailsGridView2" runat="server" CellPadding="3" 
                 EnableModelValidation="True" GridLines="Vertical" AllowPaging="True" 
                 BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                 HorizontalAlign="Center" AutoGenerateColumns="False">
                 <AlternatingRowStyle BackColor="Gainsboro" />
                 <Columns>
                     <asp:TemplateField HeaderText="Approve">
                         <ItemTemplate>
                             <asp:RadioButton ID="ApproveRadioButton1" runat="server" GroupName="Group1"/>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:BoundField DataField="UniqueCode" HeaderText="Unique Code" />

                     <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />

                     <asp:BoundField DataField="PostId" HeaderText="Post Id" />

                     <asp:BoundField DataField="PositionName" HeaderText="Position Name" />

                     <asp:BoundField DataField="InterviewDatetime" HeaderText="Interview Datetime" />

                     <asp:BoundField DataField="LoginId" HeaderText="Login Id" />
                     <asp:TemplateField HeaderText="Login Id">
                            <ItemTemplate>
                                <asp:HyperLink ID="LoginIdHyperLink"  text='<% #Bind("LoginId")%>'
                                ToolTip='<% #Bind("LoginId") %>' 
                                onclick="ApplicantDetails(this)"
                                style="text-decoration:underline;
                                cursor: pointer;
                                color:Blue;"
                                    runat="server">
                                    </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                     

                     
                 </Columns>
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
             </asp:GridView>

         
             <br />
         
             <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="SaveIVDetailsButton" runat="server" onclick="SaveIVDetailsButton_Click" 
                 Text="Save" CssClass="button" Height="38px" Width="62px" />
         
    </div>
            </asp:View>
        </asp:MultiView>    
    </div>

</asp:Content>
