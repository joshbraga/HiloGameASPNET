<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gameMainLoop.aspx.cs" Inherits="HiloGameASPNET.gameMainLoop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel = "stylesheet" type = "text/css" href = "hilo.css" />
    <title>Assignment 4 Hi-Lo Game</title>

    <!-- 
        REFERENCE: 
        Cindy, L. (N.D.). Numbers Icon. IconFinder. https://www.iconfinder.com/search/?q=Numbers

        The following image is free for use with the above attribution
    -->
    <link rel = "icon" href = "./Images/numbersIcon.png"></link>
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
                    <td><asp:Button runat = "server" ID = "makeThisGuess" ValidationGroup="userGuessValidationGroup" Text = "Make this Guess!" class = "orangeButton"/></td>                    
                </tr>
            </table>

            <!-- Validator for displaying error message of user input -->
            <asp:ValidationSummary 
                ID="ValidationSummary" 
                runat="server" 
                ValidationGroup="getUserGuessValidationGroup" 
                DisplayMode="BulletList" 
                ShowSummary="true"
                HeaderText="<b>Error:</b>"/>

            <!-- Validator for checking if the text box is empty -->
            <asp:RequiredFieldValidator 
                ID = "userGuessRequiredValidator"
                runat = "server" 
                ControlToValidate = "getUserGuess"
                ValidationGroup="getUserGuessValidationGroup"
                class = "validator">
            </asp:RequiredFieldValidator>

            <!-- Validator for checking if the user entered a valid value -->
            <asp:RangeValidator 
                ID = "userGuessRangeValidator" 
                runat = "server" 
                ControlToValidate = "getUserGuess"  
                Type = "Integer"
                ValidationGroup="getUserGuessValidationGroup"
                class = "validator">
            </asp:RangeValidator>
        </form>
    </div>
</body>
</html>
