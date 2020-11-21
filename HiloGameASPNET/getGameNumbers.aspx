<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getGameNumbers.aspx.cs" Inherits="HiloGameASPNET.getGameNumbers" %>

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
        <link rel = "icon" href = "./Images/numbersIcon.png" />
</head>
<body class = "gameBody">
    <div class = "formContainer">
        <form name="getGameNumbers" runat = "server">

            <h1>Hi-Lo Game!</h1>

            <!-- Gets the user's name from the query string and prints it out in a response when prompting for a max guess -->
            <asp:Label ID = "salutationLabel" runat = "server" class="labels"></asp:Label>

            <!-- Tables contains the text box and the button -->
            <table>
                <tr>
                    <td><asp:TextBox runat = "server" ID = "getMaxGuess" Name = "maxGuess" Placeholder = "eg. 1000" class = "textBox"/></td>
                    <td><asp:Button runat = "server" ID = "next" ValidationGroup="maxGuessValidationGroup" Text = " Next " class = "orangeButton"/></td>                    
                </tr>
            </table>

            <!-- Validator for checking if the text box is empty -->
            <asp:RequiredFieldValidator 
                ID = "maxGuessRequiredValidator"
                runat = "server" 
                ControlToValidate = "getMaxGuess"
                ErrorMessage = "Cannot be empty"
                ValidationGroup="maxGuessValidationGroup"
                Display="Dynamic"
                class = "validator">
            </asp:RequiredFieldValidator>

            <!-- Validator for checking if the user entered a value above 1 -->
            <asp:RangeValidator 
                ID = "maxGuessRangeValidator" 
                runat = "server" 
                ControlToValidate = "getMaxGuess" 
                Type = "Integer"
                ValidationGroup="maxGuessValidationGroup"
                Display="Dynamic"
                class = "validator">
            </asp:RangeValidator>
        </form>
    </div>
</body>
</html>