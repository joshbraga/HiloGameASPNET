/*
* FILE          : gameMainLoop.aspx.cs
* PROJECT       : HiloGameASPNET
* PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
* FIRST VERSION : 11/20/2020
* DESCRIPTION   :
*      The purpose of this file is to prompt the user for their next guess and transfer 
*      to this page again until the user guesses the winning number. Once the user wins, 
*      the server transfers the user to the game won aspx page. 
*/



using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace HiloGameASPNET
{
    public partial class gameMainLoop : System.Web.UI.Page
    {
        private string playerName;
        private int minGuess;
        private int maxGuess;

        /* 
         * METHOD      : Page_Load()
         * DESCRIPTION :
         *      This method sets view state for player name equal to what it was 
         *      set to in the last page. Additionally, if the view state is null 
         *      then a default player name will be used.
         * PARAMETERS  :
         *         object : sender
         *      EventArgs : e
         * RETURNS     :
         *      void : void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserGuess.Focus();

            if (!IsPostBack)
            {
                if (PreviousPage != null && PreviousPageViewState != null)
                {
                    playerName = (string)PreviousPageViewState[SharedValues.VIEWSTATE_PLAYERNAME];


                    ViewState[SharedValues.VIEWSTATE_PLAYERNAME] = playerName;
                }
                else
                {
                    playerName = SharedValues.DEFAULT_PLAYERNAME;
                }
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
         * METHOD      : makeThisGuess_Click()
         * DESCRIPTION :
         *      This method attempts to submit the form by making the guess the user 
         *      currently has in the guess text box.
         * PARAMETERS  :
         *         object : sender
         *      EventArgs : e
         * RETURNS     :
         *      void : void
         */
        protected void makeThisGuess_Click(object sender, EventArgs e)
        {

        }
    }
}