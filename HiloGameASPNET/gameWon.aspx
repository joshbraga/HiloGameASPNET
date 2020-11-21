<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gameWon.aspx.cs" Inherits="HiloGameASPNET.gameWon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel = "stylesheet" type = "text/css" href = "hilo.css" />
    <title>Assignment 5 Hi-Lo Game</title>

    <!-- 
        REFERENCE: 
        Cindy, L. (N.D.). Numbers Icon. IconFinder. https://www.iconfinder.com/search/?q=Numbers

        The following image is free for use with the above attribution
    -->
    <link rel = "icon" href = "./Images/numbersIcon.png"></link>
</head>
<body class = "winBody">
    <div class = "formContainer">
        <form runat = "server">

            <!-- Prompts user if they would like to play the game again -->
            <h1>You Win!!</h1>
            <h2>You guessed the right number!!</h2>
            <table>
                <tr>
                    <td><asp:Button runat = "server" ID = "playAgain" Text = "Play Again" OnClick="playAgainOnClick" class = "orangeButton"/></td>                    
                </tr>
            </table>
        </form>
    </div>
</body>
</html>