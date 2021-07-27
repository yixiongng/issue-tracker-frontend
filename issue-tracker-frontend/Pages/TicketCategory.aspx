<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketCategory.aspx.cs" Inherits="issue_tracker_frontend.Pages.TicketCategory" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            text-align:center;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .auto-style1 {
            width: 278px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="All Ticket Categories"></asp:Label>  

       <asp:ListView ID="lvTicketCategory" runat="server" GroupPlaceholderID="groupPlaceHolder1"
        ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
        <LayoutTemplate>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th>
                        Ticket Category
                    </th>
                </tr>
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                <tr>
                    <td colspan="3">
                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvTicketCategory" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                    ShowNextPageButton="false" />
                                <asp:NumericPagerField ButtonType="Link" />
                                <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false"
                                    ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr>
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td>
                <%# Eval("Name") %>
            </td>
            <td>
                <asp:Button ID="EditButton" runat="server" BorderStyle="None" CommandArgument='<%# Eval("CategoryId") %>'  OnClick="EditButton_Click" Text="Edit"/>  
            </td>
            <td>
                <asp:Button ID="DeleteButton" runat="server" BorderStyle="None" CommandArgument='<%# Eval("CategoryId") %>'  OnClick="DeleteButton_Click" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?')"/>  
            </td>
        </ItemTemplate>
    </asp:ListView>
        </div>
        <br />
        <div>
                    <asp:TextBox ID="NewCategory" runat="server" ></asp:TextBox>  

                    <asp:Button ID="NewButton" runat="server" BorderStyle="None"  OnClick="NewButton_Click" Text="Add"/>
                </div>
    <br />
     <div >
         <table id="EditTable" runat="server" visible="false">
             <tr>
                 <td>
                    <asp:TextBox ID="CategoryName" runat="server" ></asp:TextBox>  
                 </td>
                 <td>
                    <asp:Button ID="SaveBotton" runat="server" BorderStyle="None" CommandArgument='<%# Eval("CategoryId") %>' OnClick="SaveBotton_Click" Text="Save"/> 
                 </td>
                 <td>
                    <asp:Button ID="CancelButton" runat="server" BorderStyle="None"  OnClick="CancelButton_Click" Text="Cancel"/> 
                 </td>
                 <td>
                        <asp:TextBox ID="CategoryId" runat="server" visible="false"></asp:TextBox>  

                 </td>
             </tr>
         </table>

                </div>
          <div>
    <a href="Home.aspx" style="font-size: 20px">Back</a>

     </div>
   
   <br />
         <asp:Button ID="LogoutButton" runat="server" BorderStyle="None" OnClick="LogoutButton_Click" Text="Logout"/>
    </form>
   

</body>
</html>
