<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gameMainLoop.aspx.cs" Inherits="HiloGameASPNET.gameMainLoop" %>
<!DOCTYPE html>

<!-- 
FILE          : gameMainLoop.aspx
PROJECT       : HiloGameASPNET
PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
FIRST VERSION : 11/20/2020
DESCRIPTION   : 
    The purpose of this file is to prompt the user for their next guess and transfer 
    to this page again until the user guesses the winning number. Once the user wins, 
    the server transfers the user to the game won aspx page.
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
    <div class = "formContainer">
        <form runat = "server">
            <h1>Hi-Lo Game!</h1>                

            <!-- Prompts user for a new guess -->
            <asp:Label ID = "salutationLabel" runat = "server" class="labels"></asp:Label>

            <!-- Tables contains the text box and the button -->
            <table>
                <tr>
                    <td><asp:TextBox runat = "server" ID = "getUserGuess" Placeholder = "eg. 2" class = "textBox"/></td>
                    <td><asp:Button runat = "server" ID = "makeThisGuess" Text = "Make this Guess" class = "orangeButton" OnClick="makeThisGuess_Click"/></td>                    
                </tr>
            </table>

            <!-- Validator for checking if the text box is empty -->
            <asp:RequiredFieldValidator 
                ID = "userGuessRequiredValidator"
                runat = "server" 
                ControlToValidate = "getUserGuess"
                class = "validator">
            </asp:RequiredFieldValidator>
        </form>
    </div>
</body>
</html>