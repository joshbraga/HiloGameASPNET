<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HiloGameASPNET._default" %>
<!DOCTYPE html>

<!-- 
FILE          : default.aspx
PROJECT       : HiloGameASPNET
PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
FIRST VERSION : 11/20/2020
DESCRIPTION   : 
    The purpose of this file is to prompt the user for their name and transfer 
    to the next page where they get prompted for a max guess of the game. The 
    name is validated to ensure it is not empty.
-->



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel = "stylesheet" type = "text/css" href = "hilo.css" />
    <title>Assignment 5 Hi-Lo Game</title>

    <!-- 
        REFERENCE: 
        Cindy, L. (N.D.). Numbers Icon. IconFinder. https://www.iconfinder.com/search/?q=Numbers

        The following image is free for use with the above attribution
    -->
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
                    <td>
                        <asp:TextBox ID="getPlayerName" runat="server" placeholder="eg. John" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="register" runat="server" Text="Register" CssClass="orangeButton" OnClick="register_Click" />
                    </td>               
                </tr>
            </table>

            <!-- Validator to check if the user entered a name -->
            <div id="nameError" style="color:red" class = "validator">
                <asp:RequiredFieldValidator ID="getPlayerNameValidator"
                        runat="server" ControlToValidate="getPlayerName"
                        ErrorMessage="Sorry this is a required field">
                    </asp:RequiredFieldValidator>
            </div> 
        </form>
    </div>
</body>
</html>