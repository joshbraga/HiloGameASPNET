/*
* FILE          : gameMainLoop.aspx.cs
* PROJECT       : HiloGameASPNET
* PROGRAMMER    : Balazs Karner 8646201 & Josh Braga 5895818
* FIRST VERSION : 11/20/2020
* DESCRIPTION   :
*       This purpose of this file is to store the user entered current guess and
*       transfer the server back to this page until the user enters the winning 
*       number. THen the server is transfered to the game won aspx page
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
        private string playerName;       //The player's name from the previous page
        private int minGuess;            //The player's minimum allowable guess in the current range
        private int maxGuess;            //The player's maximum allowable guess in the current range
        private int userGuess;           //The player's current guess
        private int target;              //The player's winning (randomly generated) number
        private Boolean userWon = false; //Flag to see if user won

        /* 
         * METHOD      : Page_Load()
         * DESCRIPTION :
         *      This method sets the minimum, maximum guessing range, the player 
         *      name and target guess from the previous page's values
         * PARAMETERS  :
         *         object : sender
         *      EventArgs : e
         * RETURNS     :
         *      void : void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            //Focus on the text box
            getUserGuess.Focus();

            //If postback enter here
            if (!IsPostBack)
            {
                //If previous page isn't null then set viewstate
                if (PreviousPage != null && PreviousPageViewState != null)
                {
                    playerName = (string)PreviousPageViewState[SharedValues.VIEWSTATE_PLAYERNAME];
                    minGuess = SharedValues.DEFAULT_MINGUESS;
                    Int32.TryParse(PreviousPageViewState[SharedValues.VIEWSTATE_MAXGUESS].ToString(), out maxGuess);

                    //Set min, max, and player name to previous page's values
                    ViewState[SharedValues.VIEWSTATE_PLAYERNAME] = playerName;
                    ViewState[SharedValues.VIEWSTATE_MINGUESS] = minGuess;
                    ViewState[SharedValues.VIEWSTATE_MAXGUESS] = maxGuess;

                    Random r = new Random(DateTime.Now.Millisecond);
                    ViewState[SharedValues.VIEWSTATE_TARGETGUESS] = r.Next(minGuess, maxGuess);

                }
            }
            //If this is the first time loading this page enter here
            else
            {
                //Set viewstate and min/max values
                playerName = (string)ViewState[SharedValues.VIEWSTATE_PLAYERNAME];
                minGuess = (int)ViewState[SharedValues.VIEWSTATE_MINGUESS];
                maxGuess = (int)ViewState[SharedValues.VIEWSTATE_MAXGUESS];
                Int32.TryParse(getUserGuess.Text, out userGuess);
                target = (int)ViewState[SharedValues.VIEWSTATE_TARGETGUESS];

                errorText.InnerHtml = "";

                //If text box for guessing is empty display an error
                if (getUserGuess.Text == String.Empty)
                {
                    errorText.InnerHtml = "Input cannot be blank";
                }
                //If text box for guessing is not an integer display an error
                else if (!Int32.TryParse(getUserGuess.Text, out userGuess))
                {
                    errorText.InnerHtml = "Input must be an integer in the specified range";
                }                
                else
                {
                    userWon = DetermineIfWon();                    
                }

                getUserGuess.Text = String.Empty;
                
                
            }

            
            //Display the salutation message with the user entered data from the previous pages
            salutationLabel.Text =  "Hello, " + playerName + ". Your allowable guessing range is any value " +
                                    "between " + minGuess + " and " + maxGuess + " inclusive.";

        }

        /* 
         * METHOD      : DetermineIfWon()
         * DESCRIPTION :
         *      This method determines if the user has guessed the winning number in the hi lo 
         *      game or not.If the guess is withing the allowable range, but not the winning 
         *      number, the range is updated and the user is informed
         * PARAMETERS  :
         *      void: void
         * RETURNS     :
         *      void : void
         */
        private Boolean DetermineIfWon()
        {
            Boolean isWin = false;

            if (target == userGuess)
            {
                isWin = true;
            }
            else if (userGuess > maxGuess || userGuess < minGuess)
            {
                //Display error if guess was outside allowable range
                errorText.InnerHtml = "Guess must be within specified range";
            }
            else if (userGuess < target)
            {
                //If guess within range but not winning number. Update minimum range
                minGuess = userGuess + 1;
                ViewState[SharedValues.VIEWSTATE_MINGUESS] = minGuess;
            }
            else if (userGuess > target)
            {
                //If guess within range but not winning number. Update maximum range
                maxGuess = userGuess - 1;
                ViewState[SharedValues.VIEWSTATE_MAXGUESS] = maxGuess;
            }
            


            return isWin;
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
         * METHOD      : makeThisGuess_Click()
         * DESCRIPTION :
         *      This method attempts transfer the server to the game won aspx 
         *      page if the guess is the winning target
         * PARAMETERS  :
         *         object : sender
         *      EventArgs : e
         * RETURNS     :
         *      void : void
         */
        protected void makeThisGuess_Click(object sender, EventArgs e)
        {
            if (userWon == true)
            {
                Server.Transfer("gameWon.aspx");
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
    }
}