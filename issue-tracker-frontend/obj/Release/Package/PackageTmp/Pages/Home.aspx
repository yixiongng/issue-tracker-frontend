<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="issue_tracker_frontend.Pages.Home" Async="true" %>

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
            width: 200px;
        }
        .auto-style2 {
            width: 100px;
        }
    </style>
</head>
<body>
     
    <form id="form1" runat="server">
                    <asp:Label ID="Title" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="All Tickets"></asp:Label>  
        <table>
            <tr>
                <td><asp:Button ID="NewButton" runat="server" BorderStyle="None"  OnClick="NewButton_Click" Text="New"/></td>
                <td class="auto-style1"> </td>
                <td><asp:Button ID="AllButton" runat="server" BorderStyle="None"  OnClick="AllButton_Click" Text="All"/></td>
                 <td><asp:Button ID="AssignedButton" runat="server" BorderStyle="None"  OnClick="AssignedButton_Click" Text="Assigned"/>  </td>
             <td><asp:Button ID="OwnedButton" runat="server" BorderStyle="None"  OnClick="OwnedButton_Click" Text="Owned"/></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="Search" runat="server" class="auto-style1"></asp:TextBox>  

                </td>
                <td>
                    <asp:Button ID="SearchButton" runat="server" BorderStyle="None"  OnClick="SearchButton_Click" Text="Search"/>
                </td>
                <td>
                    Filter:
                </td>
                <td>
                     <asp:DropDownList ID="DdlStatus" runat="server" DataTextField = "Status" DataValueField = "Status" CssClass="auto-style2" OnSelectedIndexChanged = "OnSelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    <asp:ListView ID="lvTicket" runat="server" GroupPlaceholderID="groupPlaceHolder1"
        ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
        <LayoutTemplate>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th>
                        Ticket Name
                    </th>
                    <th>
                        Assignee Name
                    </th>
                    <th>
                        Owner Name
                    </th>
                    <th>
                        Category
                    </th>
                     <th>
                        Status
                    </th>
                </tr>
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                <tr>
                    <td colspan="3">
                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvTicket" PageSize="5">
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
                <%# Eval("TicketName") %>
            </td>
            <td>
                <%# Eval("AssigneeName.FirstName") %> <%# Eval("AssigneeName.LastName") %>
            </td>
            <td>
                <%# Eval("OwnerName.FirstName") %> <%# Eval("OwnerName.LastName") %>
            </td>
             <td>
                <%# Eval("CategoryName") %>
            </td>
            <td>
                <%# Eval("Status") %>
            </td>
            <td>
                <asp:Button ID="EditButton" runat="server" BorderStyle="None" CommandArgument='<%# Eval("TicketId") %>'  OnClick="EditButton_Click" Text="View"/>  
            </td>
           
        </ItemTemplate>
    </asp:ListView>
            <a href="TicketCategory.aspx" style="font-size: 20px">Category</a>
    <br />
    <br />
    <div>
    <br />
         <asp:Button ID="LogoutButton" runat="server" BorderStyle="None" OnClick="LogoutButton_Click" Text="Logout"/>

    </div>
    </form>

</body>
</html>
