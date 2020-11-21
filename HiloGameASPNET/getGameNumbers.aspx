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
        <link rel = "icon" href = "./Images/numbersIcon.png"></link>
</head>
<body class = "gameBody">
    <div id = "section2" class = "formContainer">
        <form name="getGameNumbers.asp">

            <h1>Hi-Lo Game!</h1>

            <!-- Gets the user's name from the query string and prints it out in a response when promptng for a max guess -->
            <p>Welcome INSERT_NAME_HERE. Please enter the maximum guess number below:</p>

            <!-- Tables contains the text box and the button -->
            <table>
                <tr>
                    <td><input id = "maxGuessBox" name = "maxGuess" placeholder = "eg. 1000" type = "text" class = "textBox" autofocus/></td>
                    <td><input type="submit" id="next" value=" Next " class = "orangeButton"/></td>                    
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
