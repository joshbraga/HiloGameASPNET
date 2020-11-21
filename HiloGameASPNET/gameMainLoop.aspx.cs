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

        }


        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}