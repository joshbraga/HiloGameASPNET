<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gameWon.aspx.cs" Inherits="HiloGameASPNET.gameWon" %>
<!DOCTYPE html>

<!-- 
FILE          : gameWon.aspx
PROJECT       : HiloGameASPNET
PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
FIRST VERSION : 11/20/2020
DESCRIPTION   : 
    The purpose of this file is to prompt the user if they would like to play 
    the Hi-Lo game again. If yes, then the user is transfered to the second 
    aspx page to enter another max guess, and the current viewstate is reset.
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
    <link rel = "icon" href = "./Images/numbersIcon.png"></link>
</head>
<body class = "winBody">
    <div class = "formContainer">
        <form runat = "server">

            <!-- Prompts user if they would like to play the game again -->
            <h1>You Win!!</h1>
            <h2>You guessed the right number!!</h2>

            <div align ="center">
                <asp:Button runat = "server" ID = "playAgain" Text = "Play Again" OnClick="playAgainOnClick" class = "orangeButton"/> 
            </div>                   
        </form>
    </div>
</body>
</html>