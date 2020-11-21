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
        private int userGuess;
        private int target;
        private Boolean userWon = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            getUserGuess.Focus();

            if (!IsPostBack)
            {
                if (PreviousPage != null && PreviousPageViewState != null)
                {
                    playerName = (string)PreviousPageViewState[SharedValues.VIEWSTATE_PLAYERNAME];
                    minGuess = SharedValues.DEFAULT_MINGUESS;
                    Int32.TryParse(PreviousPageViewState[SharedValues.VIEWSTATE_MAXGUESS].ToString(), out maxGuess);

                    ViewState[SharedValues.VIEWSTATE_PLAYERNAME] = playerName;
                    ViewState[SharedValues.VIEWSTATE_MINGUESS] = minGuess;
                    ViewState[SharedValues.VIEWSTATE_MAXGUESS] = maxGuess;

                    Random r = new Random(DateTime.Now.Millisecond);
                    ViewState[SharedValues.VIEWSTATE_TARGETGUESS] = r.Next(minGuess, maxGuess);

                }
            }
            else
            {
                playerName = (string)ViewState[SharedValues.VIEWSTATE_PLAYERNAME];
                minGuess = (int)ViewState[SharedValues.VIEWSTATE_MINGUESS];
                maxGuess = (int)ViewState[SharedValues.VIEWSTATE_MAXGUESS];
                Int32.TryParse(getUserGuess.Text, out userGuess);
                target = (int)ViewState[SharedValues.VIEWSTATE_TARGETGUESS];

                errorText.InnerHtml = "";

                if (getUserGuess.Text == String.Empty)
                {
                    errorText.InnerHtml = "Input cannot be blank";
                }
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

            

            salutationLabel.Text =  "Hello, " + playerName + ". Your allowable guessing range is any value " +
                                    "between " + minGuess + " and " + maxGuess + " inclusive.";

        }


        private Boolean DetermineIfWon()
        {
            Boolean isWin = false;

            if (target == userGuess)
            {
                isWin = true;
            }
            else if (userGuess > maxGuess || userGuess < minGuess)
            {
                errorText.InnerHtml = "Guess must be within specified range";
            }
            else if (userGuess < target)
            {
                minGuess = userGuess + 1;
                ViewState[SharedValues.VIEWSTATE_MINGUESS] = minGuess;
            }
            else if (userGuess > target)
            {
                maxGuess = userGuess - 1;
                ViewState[SharedValues.VIEWSTATE_MAXGUESS] = maxGuess;
            }
            


            return isWin;
        }


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

        protected void makeThisGuess_Click(object sender, EventArgs e)
        {
            if (userWon == true)
            {
                Server.Transfer("gameWon.aspx");
            }


        }


        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}