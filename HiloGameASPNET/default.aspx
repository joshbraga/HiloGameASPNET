<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HiloGameASPNET._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel = "stylesheet" type = "text/css" href = "hilo.css" />
    <title>Assignment 5 Hi-Lo Game</title>

    <link rel = "icon" href = "./Images/numbersIcon.png" />
</head>
<body class = "gameBody">
    <!-- This div encompasses everything (The opaque black box)-->
    <div id="section1" class = "formContainer">
        <h1>Hi-Lo Game!</h1>        

        <!-- Form prompts user for their name, and submits as long as it is not empty -->
        <form id="form1" runat="server">
            <p class="labels">Please enter your name:</p>            
            <table>
                <tr>                    
                    <!--<td><input id="getPlayerName" name = "userName" type="text" class = "textBox" placeholder = "eg. John"/></td>-->
                   
                    <td>
                        <asp:TextBox ID="getPlayerName" runat="server" placeholder="eg. John" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="register" runat="server" Text="Register" CssClass="orangeButton" OnClick="register_Click" />
                        <!--<input type="submit" id="register" value="Register" class = "orangeButton"/>-->
                    </td>               
                </tr>
            </table>
            <div id="nameError" style="color:red">
                <asp:RequiredFieldValidator ID="getPlayerNameValidator"
                        runat="server" ControlToValidate="getPlayerName"
                        ErrorMessage="Sorry this is a required field">
                    </asp:RequiredFieldValidator>
            </div> 
        </form>
    </div>
</body>
</html>