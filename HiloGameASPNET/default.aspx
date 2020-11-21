<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HiloGameASPNET._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel = "stylesheet" type = "text/css" href = "hilo.css" />
    <title>Assignment 5 Hi-Lo Game</title>

    <link rel = "icon" href = "./Images/numbersIcon.png"></link>
</head>
<body class = "gameBody">
    <!-- This div encompasses everything (The opaque black box)-->
    <div id="section1" class = "formContainer">
        <h1>Hi-Lo Game!</h1>        

        <!-- Form prompts user for their name, and submits as long as it is not empty -->
        <form name="hiloStart.html">
            <p>Please enter your name:</p>           
            <table>
                <tr>                    
                    <td><input id="getPlayerName" name = "userName" type="text" class = "textBox" placeholder = "eg. John"/></td>
                    <td><input type="submit" id="register" value="Register" class = "orangeButton"/></td>                    
                </tr>
            </table>
            <div id="nameError" style="color:red"></div> 
        </form>
    </div>
</body>
</html>