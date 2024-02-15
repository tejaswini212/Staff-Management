using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //This method is used to view student's xml when trying to access it from dashboard
        protected void ViewStudentsXml(object sender, EventArgs e)
        {
            Response.Clear();
            //set the response buffer to true
            Response.Buffer = true;
            //set the charset of response to empty
            Response.Charset = "";
            //set caching to false
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //set the content type of response to xml
            Response.ContentType = "application/xml";
            //write the response with Students.xml present in the App_Data folder
            Response.WriteFile(Server.MapPath(@"~/App_Data/Students.xml"));
            Response.Flush();
            Response.End();
        }

        //This method is used to view admin's xml when trying to access it from dashboard
        protected void ViewAdminXml(object sender, EventArgs e)
        {
            Response.Clear();
            //set the response buffer to true
            Response.Buffer = true;
            //set the charset of response to empty
            Response.Charset = "";
            //set caching to false
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //set the content type of response to xml
            Response.ContentType = "application/xml";
            //write the response with Administrators.xml present in the App_Data folder
            Response.WriteFile(Server.MapPath(@"~/App_Data/Administrators.xml"));
            Response.Flush();
            Response.End();
        }
    }
}