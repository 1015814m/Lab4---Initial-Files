<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team 12 System - Login</title>
    <style>
        body {
            background-image: url(Images/ss-blue-valley-shenandoah.jpg);
            
        }

        .login {
            display:table-cell;
            text-align: center;
            vertical-align:middle;
        }

        .parent {
            display: table;
            width: 100%;
        }
    </style>
</head>
<body>
    <div class="parent">
    <form id="form1" 
        runat="server" 
        class="login" 
        >
        
            <asp:Login 
                ID="login" 
                runat="server" 
                BackColor="#EFF3FB" 
                BorderColor="#B5C7DE" 
                BorderPadding="5" 
                BorderStyle="Solid" 
                BorderWidth="2px" 
                Font-Names="Verdana" 
                Font-Size="0.8em" 
                ForeColor="#333333" 
                Height="150px" 
                style="margin-left:45%; margin-top:20%; "
                >

                <InstructionTextStyle 
                    Font-Italic="True" 
                    ForeColor="Black" />

                <LoginButtonStyle 
                    BackColor="White" 
                    BorderColor="#507CD1" 
                    BorderStyle="Solid" 
                    BorderWidth="1px" 
                    Font-Names="Verdana" 
                    Font-Size="0.8em" 
                    ForeColor="#284E98" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                
        
            </asp:Login>
        
        <br />
        <a href="WebPages/Home.aspx">Navigate Home</a>
    </form>
    </div>
</body>
</html>
