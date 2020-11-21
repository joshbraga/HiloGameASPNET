/*
* FILE          : gameWon.aspx.cs
* PROJECT       : HiloGameASPNET
* PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
* FIRST VERSION : 11/20/2020
* DESCRIPTION   :
*       The purpose of this file is to transfer the user to the second aspx 
*       file where they are prompted for a new max guess value, and can play 
*       the game again if they press the, "Play Again" button.
*/



using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace HiloGameASPNET
{
    public partial class gameWon : System.Web.UI.Page
    {
        private string playerName;

        /* 
         * METHOD      : Page_Load()
         * DESCRIPTION :
         *      This method sets view state for player name equal to what it was 
         *      set to in the last page. Additionally, if the view state is null 
         *      then a default player name will be used. All other state 
         *      management values are reset.
         * PARAMETERS  :
         *         object : sender
         *      EventArgs : e
         * RETURNS     :
         *      void : void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPageViewState != null)
            {
                playerName = (string)PreviousPageViewState[SharedValues.VIEWSTATE_PLAYERNAME];
                ViewState[SharedValues.VIEWSTATE_PLAYERNAME] = playerName;
                ViewState[SharedValues.VIEWSTATE_MAXGUESS] = null;
                ViewState[SharedValues.VIEWSTATE_MINGUESS] = null;
                ViewState[SharedValues.VIEWSTATE_PLAYERGUESS] = null;
            }
        }

        /* 
         * METHOD      : PreviousPageViewState()
         * DESCRIPTION :
         *      This method returns the values of the viewstate of the previous page
         * PARAMETERS  :
         *      void : void
         * RETURNS     :
         *      Statebag
         */
        private StateBag PreviousPageViewState
        {
            get
            {
                StateBag returnValue = null;
                if (Page.PreviousPage != null)
                {
                    Object objPreviousPage = (Object)PreviousPage;
                    MethodInfo objMethod = objPreviousPage.GetType().GetMethod("ReturnViewState"); //System.Reflection class
                    return (StateBag)objMethod.Invoke(objPreviousPage, null);
                }
                return returnValue;
            }
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

        /* 
         * METHOD      : playAgainOnClick()
         * DESCRIPTION :
         *      This method transfers the user to the "getGameNumbers.aspx" aspx page
         * PARAMETERS  :
         *      void : void
         * RETURNS     :
         *      void : void
         */
        protected void playAgainOnClick(object sender, EventArgs e)
        {
            Server.Transfer("getGameNumbers.aspx");
        }
    }
}