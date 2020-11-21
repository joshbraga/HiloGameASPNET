/*
* FILE          : getGameNumbers.aspx.cs
* PROJECT       : HiloGameASPNET
* PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
* FIRST VERSION : 11/20/2020
* DESCRIPTION   :
*      The purpose of this file is to prompt the user for their max guess and transfer 
*      to the next page where they guess for the winning number.
*/



using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace HiloGameASPNET
{
    public partial class getGameNumbers : System.Web.UI.Page
    {
        public const int MINGUESS = 1; //Minimum guess the max guess can be
        private string playerName;     //holds the player's name from the previous page

        /* 
         * METHOD      : Page_Load()
         * DESCRIPTION :
         *      This method sets view state for player name equal to what it was set to in the 
         *      last page. If the view state is null then a default player name will be used. 
         *      Additionally, the minimum and maximum values for the range validator are set.
         * PARAMETERS  :
         *         object : sender
         *      EventArgs : e
         * RETURNS     :
         *      void : void
         */
        protected void Page_Load(object sender, EventArgs e)
        {  
           if (!IsPostBack)
            {
                if (PreviousPage != null && PreviousPageViewState != null)
                {
                    playerName = (string)PreviousPageViewState[SharedValues.VIEWSTATE_PLAYERNAME];
                }
                else
                {
                    playerName = SharedValues.DEFAULT_PLAYERNAME;
                }
            }
            else
            {
                playerName = (string)ViewState[SharedValues.VIEWSTATE_PLAYERNAME];
            }

            salutationLabel.Text = "Welcome " + playerName + ". Please enter the maximum guess number below:";

            //Assign minimum and maximum values of the range 
            maxGuessRangeValidator.MinimumValue = SharedValues.DEFAULT_MINGUESS.ToString();
            maxGuessRangeValidator.MaximumValue = SharedValues.DEFAULT_MAXGUESS.ToString();
            maxGuessRangeValidator.ErrorMessage = "Must be an integer greater than " + SharedValues.DEFAULT_MINGUESS;
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
                    MethodInfo objMethod = objPreviousPage.GetType().GetMethod("ReturnViewState");      //System.Reflection class
                    return (StateBag)objMethod.Invoke(objPreviousPage, null);
                }
                return returnValue;
            }
        }

        /* 
         * METHOD      : next_Click()
         * DESCRIPTION :
         *      This method transfers the ser to the next page, "gameMainLoop.aspx"
         * PARAMETERS  :
         *      void : void
         * RETURNS     :
         *      StateBag
         */
        protected void next_Click(object sender, EventArgs e)
        {
            ViewState[SharedValues.VIEWSTATE_MAXGUESS] = getMaxGuess.Text;
            Server.Transfer("gameMainLoop.aspx");
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