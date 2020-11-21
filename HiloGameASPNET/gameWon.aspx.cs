using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiloGameASPNET
{
    public partial class gameWon : System.Web.UI.Page`
    {
        private string playerName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPageViewState != null)
            {
                playerName = (string)PreviousPageViewState[SharedValues.viewStatePlayerName];
                ViewState[SharedValues.viewStatePlayerName] = playerName;
                ViewState[SharedValues.viewStateMaxGuess] = "";
                ViewState[SharedValues.viewStateMinGuess] = "";
                ViewState[SharedValues.viewStatePlayerGuess] = "";
            }
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

        public StateBag ReturnViewState()
        {
            return ViewState;
        }

        protected void playAgainOnClick(object sender, EventArgs e)
        {
            Server.Transfer("getGameNumbers.aspx");
        }
    }
}