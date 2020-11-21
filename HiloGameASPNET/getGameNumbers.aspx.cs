using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiloGameASPNET
{
    public partial class getGameNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getMaxGuess.Focus();
            salutationLabel.Text = "Welcome " + ". Please enter the maximum guess number below:";
        }

        protected void nextOnClick(object sender, EventArgs e)
        {
            Server.Transfer("mainGameLoop.aspx");
        }
    }
}