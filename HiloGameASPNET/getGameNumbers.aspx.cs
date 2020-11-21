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

        protected void Page_Load(object sender, EventArgs e)
        {
            string playerName;

            if (PreviousPage != null && PreviousPageViewState != null)
            {
                playerName = (string)PreviousPageViewState["vsPlayerName"];
                

                ViewState["vsPlayerName"] = playerName;
            }
            else
            {
                playerName = "DEFAULT";
            }

            welcomeMessage.InnerHtml = "Welcome " + playerName + ". Please enter the maximum guess number below:";

            maxGuessBoxRangeValidator.MinimumValue = MINGUESS.ToString();
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
    }
}