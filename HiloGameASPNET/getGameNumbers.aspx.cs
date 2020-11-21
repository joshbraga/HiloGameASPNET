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
                    playerName = (string)PreviousPageViewState[SharedValues.viewStatePlayerName];


                    ViewState[SharedValues.viewStatePlayerName] = playerName;
                }
                else
                {
                    playerName = SharedValues.defaultPlayerName;
                }
            }
            else
            {
                playerName = (string)ViewState[SharedValues.viewStatePlayerName];
            }

            salutationLabel.Text = "Welcome " + playerName + ". Please enter the maximum guess number below:";

            maxGuessRangeValidator.MinimumValue = MINGUESS.ToString();
            maxGuessRangeValidator.MaximumValue = Int32.MaxValue.ToString();
            maxGuessRangeValidator.ErrorMessage = "Must be an integer greater than " + MINGUESS;
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
            ViewState[SharedValues.viewStateMaxGuess] = getMaxGuess.Text;
            Server.Transfer("gameMainLoop.aspx");
        }

        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}