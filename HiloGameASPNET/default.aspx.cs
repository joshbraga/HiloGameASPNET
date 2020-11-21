using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiloGameASPNET
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getPlayerName.Focus();
        }


        protected void register_Click(object sender, EventArgs e)
        {
            ViewState[SharedValues.VIEWSTATE_PLAYERNAME] = getPlayerName.Text;
            Server.Transfer("getGameNumbers.aspx");
        }

        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}