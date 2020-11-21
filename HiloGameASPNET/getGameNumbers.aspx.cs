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
        public const int MINGUESS = 1;
        private string playerName;



        protected void Page_Load(object sender, EventArgs e)
        {  
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
            else
            {
                playerName = (string)ViewState[SharedValues.VIEWSTATE_PLAYERNAME];
            }

            salutationLabel.Text = "Welcome " + playerName + ". Please enter the maximum guess number below:";

            maxGuessRangeValidator.MinimumValue = SharedValues.DEFAULT_MINGUESS.ToString();
            maxGuessRangeValidator.MaximumValue = SharedValues.DEFAULT_MAXGUESS.ToString();
            maxGuessRangeValidator.ErrorMessage = "Must be an integer greater than " + SharedValues.DEFAULT_MINGUESS;
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

        protected void next_Click(object sender, EventArgs e)
        {
            ViewState[SharedValues.VIEWSTATE_MAXGUESS] = getMaxGuess.Text;
            Server.Transfer("gameMainLoop.aspx");
        }

        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}