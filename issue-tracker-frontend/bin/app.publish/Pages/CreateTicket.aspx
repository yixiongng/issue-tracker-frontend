<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTicket.aspx.cs" Inherits="issue_tracker_frontend.Pages.CreateTicket" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">  
            <tr>  
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Ticket Details"></asp:Label>
                </td>  
            </tr>  
                <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label8" runat="server" Text="Ticket Name :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:TextBox ID="TicketName" runat="server"></asp:TextBox>  
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label3" runat="server" Text="Description :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:TextBox ID="Description" runat="server" Height="150"></asp:TextBox>  
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
               <td style="text-align: center">  
                    <asp:Label ID="Label5" runat="server" Text="Assignee :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:DropDownList ID="DdlAssignee" runat="server" Width="128" DataTextField = "FullName" DataValueField = "UserId">
                    </asp:DropDownList>
                </td>    
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
               <td style="text-align: center">  
                    <asp:Label ID="Label6" runat="server" Text="Category :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:DropDownList ID="DdlCategory" runat="server" Width="128" DataTextField = "Name" DataValueField = "CategoryId">
                    </asp:DropDownList>
                </td>    
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr> 
            <tr>  
                <td> </td>  
               <td style="text-align: center">  
                    <asp:Label ID="Label7" runat="server" Text="Status :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:DropDownList ID="DdlStatus" runat="server" Width="128" DataTextField = "Status" DataValueField = "Status">
                    </asp:DropDownList>
                </td>    
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr> 
                <tr>
                    <td> </td>  
                <td> </td>  
                <td> </td>  
                    <td> </td>  
                <td> </td>  
                <td> </td>  
                </tr>
            <tr>  
                <td> </td>  
                <td style="text-align: center"> 
                    <asp:Button ID="CancelButton" runat="server" BorderStyle="None" OnClick="CancelButton_Click" Text="Cancel"/>
                </td>  
                <td style="text-align: center">  
                    <asp:Button ID="SubmitButton" runat="server" BorderStyle="None" OnClick="SubmitButton_Click" Text="Save"/>  
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td> </td>  
                <td>  
                    <asp:Label ID="Message" runat="server" Font-Size="X-Large"></asp:Label>  
                </td>  
                <td> 
                </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
                <tr>  
                <td> </td>  
                <td> </td>  
                <td>  
                    <asp:Label ID="APIRespond" runat="server" Font-Size="X-Large"></asp:Label>  
                </td>  
                <td> 
                </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
        </table>  
        </div>
        <br />
         <asp:Button ID="LogoutButton" runat="server" BorderStyle="None" OnClick="LogoutButton_Click" Text="Logout"/>

    </form>
</body>
</html>
