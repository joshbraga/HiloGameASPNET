<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getGameNumbers.aspx.cs" Inherits="HiloGameASPNET.getGameNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="hilo.css" />
    <title>Assignment 5 Hi-Lo Game</title>

    <!-- 
            REFERENCE: 
            Cindy, L. (N.D.). Numbers Icon. IconFinder. https://www.iconfinder.com/search/?q=Numbers

            The following image is free for use with the above attribution
        -->
    <link rel="icon" href="./Images/numbersIcon.png" />
</head>
<body class="gameBody">
    <div id="section2" class="formContainer">
        <form runat="server">

            <h1>Hi-Lo Game!</h1>

            <!-- Gets the user's name from the query string and prints it out in a response when promptng for a max guess -->
            <p id="welcomeMessage" runat="server"></p>

            <!-- Tables contains the text box and the button -->
            <table>
                <tr>
                    <td>
                        <%--<input id = "maxGuessBox" name = "maxGuess" placeholder = "eg. 1000" type = "text" class = "textBox" autofocus/>--%>
                        <asp:TextBox ID="maxGuessBox" runat="server" placeholder="eg. 1000" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="maxGuessBoxRequiredValidator"
                            runat="server" ControlToValidate="maxGuessBox"
                            ErrorMessage="Sorry this is a required field">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="maxGuessBoxRangeValidator" 
                            runat="server" ControlToValidate="maxGuessBox"
                            ErrorMessage="RangeValidator">
                        </asp:RangeValidator>

                    </td>
                    <td>
                        <%--<input type="submit" id="next" value=" Next " class = "orangeButton"/>--%>
                        <asp:Button ID="next" runat="server" Text="Next" CssClass="orangeButton" />
                    </td>
                </tr>
            </table>
            <div id="numberError" style="color: red">
                <asp:ValidationSummary ID="maxGuessValidationSummary" runat="server" />
            </div>
        </form>
    </div>
</body>
</html>
