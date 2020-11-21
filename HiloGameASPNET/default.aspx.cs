/*
* FILE          : default.aspx.cs
* PROJECT       : HiloGameASPNET
* PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
* FIRST VERSION : 11/20/2020
* DESCRIPTION   :
*       This purpose of this file is to store the user entered name 
*       using the viewstate and then transfer to the next aspx page.
*/



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

        }

        /* 
         * METHOD      : register_Click()
         * DESCRIPTION :
         *      This method sets view state for player name equal to what the user
         *      has entered as long as it passes the validator checks. Additionaly, 
         *      the user is transfered to the, "getGameNumbers.aspx" page.
         * PARAMETERS  :
         *         object : sender
         *      EventArgs : e
         * RETURNS     :
         *      void : void
         */
        protected void register_Click(object sender, EventArgs e)
        {
            ViewState[SharedValues.VIEWSTATE_PLAYERNAME] = getPlayerName.Text;
            Server.Transfer("getGameNumbers.aspx");
        }

        /* 
         * METHOD      : ReturnViewState()
         * DESCRIPTION :
         *      This method returns the view state
         * PARAMETERS  :
         *      void : void
         * RETURNS     :
         *      StateBag
         */
        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}