<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="issue_tracker_frontend.Pages.Register" Async="true" %>

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
            <table>  
            <tr>  
                <td colspan="6" vertical-align: top">  
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Register"></asp:Label>  
                </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="First Name :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:TextBox ID="FirstName" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  

                <td> <asp:Label ID="FirstNameMessage" runat="server" Font-Size="X-Large" CssClass="error"></asp:Label> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Last Name :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:TextBox ID="LastName" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  
                <td><asp:Label ID="LastNameMessage" runat="server" Font-Size="X-Large" CssClass="error"></asp:Label>  </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
                 <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="Email :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:TextBox ID="Email" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  

                <td><asp:Label ID="EmailMessage" runat="server" Font-Size="X-Large" CssClass="error"></asp:Label> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label5" runat="server" Font-Size="X-Large" Text="Password :"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:TextBox ID="Password" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>  
                </td>  
                <td> <asp:Label ID="PasswordMessage" runat="server" Font-Size="X-Large" CssClass="error"></asp:Label></td>  
                <td> </td>  
                <td> </td>  
            </tr> 
                <tr>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Label ID="Label6" runat="server" Font-Size="X-Large" Text="Confirm Password :"></asp:Label>  
                </td>  
                <td>  
                    <asp:TextBox ID="ConfirmPassword" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>  
                </td>  
                <td><asp:Label ID="ConfirmPasswordError" runat="server" Font-Size="X-Large" CssClass="error"></asp:Label>   </td>  
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
                <td style="text-align: center">  
                    <asp:Button ID="RegisterButton" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="RegisterButton_Click" Text="Register"/>  
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
            <a href="Login.aspx" style="font-size: 30px">Login</a>
        </div>
    </form>
</body>
</html>
