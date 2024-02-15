using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This checks if the user is signed in
            //If signed in user then set the panel of signed in to be visible
            if (Global.signedIn)
            {
                signedInPanel.Visible = true;
                logInPanel.Visible = false;
            }
            //If not set the panel to log in as visible
            else
            {
                signedInPanel.Visible = false;
                logInPanel.Visible = true;
                //Server.Transfer("~/Default.aspx");
            }
        }

        //When user clicks on sign out redirect user to the default page
        protected void signOut_Click(object sender, EventArgs e)
        {
            //sign out the user first
            System.Web.Security.FormsAuthentication.SignOut();
            signedInPanel.Visible = false;
            //set the log in panel to be visible
            logInPanel.Visible = true;
            //set the variable for signed in to be false
            Global.signedIn = false;
            //transfer user to the default page
            Server.Transfer("~/Default.aspx");
        }
    }
}