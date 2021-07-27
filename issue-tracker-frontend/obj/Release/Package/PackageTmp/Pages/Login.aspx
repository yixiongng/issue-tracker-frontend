<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="issue_tracker_frontend.Pages.Login" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title></title>  
    <style type="text/css">  
        .auto-style1 {  
            width: 100%;  
        }  
        .error{
            color: crimson
        }
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
      
        <table >  
            <tr>  
                <td colspan="6" vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Log In "></asp:Label>  
                </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Email :"></asp:Label>  
                </td>  
                <td>  
                    <asp:TextBox ID="Email" runat="server" Font-Size="X-Large"></asp:TextBox>   
                </td>  
                <td> <asp:Label ID="EmailMessage" runat="server" Font-Size="X-Large" CssClass="error"></asp:Label> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Password :"></asp:Label>  
                </td>  
                <td>  
                    <asp:TextBox ID="Password" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>  
                </td>  
                <td><asp:Label ID="PasswordMessage" runat="server" Font-Size="X-Large" CssClass="error"></asp:Label>   </td>  
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
                <td> </td>  
                <td>  
                    <asp:Button ID="LoginButton" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="LogInButton_Click" Text="Log In"/>  
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td> </td>  
                <td>  
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
        </table>  
        <a href="Register.aspx" style="font-size: 30px">Register</a>

      
    </div>  
    </form>  
</body>    
</html>
