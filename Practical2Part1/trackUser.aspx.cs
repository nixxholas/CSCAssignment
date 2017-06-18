using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCAssignment
{
    public partial class trackUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string browser = null;

            // Getting IP of visitor
            string ipClient = Request.ServerVariables["REMOTE_ADDR"];

            // Getting IP of server
            string ipServer = Request.ServerVariables["LOCAL_ADDR"];

            // GET? POST? retrieves the type of what the method is
            string RequestMethod = Request.ServerVariables["REQUEST_METHOD"];

            // Getting the page
            string reqURL = Request.ServerVariables["URL"];
            string referrerPage = Request.ServerVariables["HTTP_REFERRER"];

            // Getting the visitor's browser
            switch (Request.ServerVariables["HTTP_USER_AGENT"]) {
                case "Firefox":
                    browser = "Fire fox";
                    break;
                case "Opera":
                    browser = "Opera";
                    break;
                case "Chrome":
                    browser = "Chrome";
                    break;
                case "Microsoft Edge":
                    browser = "Microsoft Edge";
                    break;
                default:
                    browser = "Internet Explorer";
                    break;
            }

            // Detects if the user is on mobile
            Response.Write(Request.UserAgent + "</br>");
            Response.Write(" Your HTTP Method: " + RequestMethod);
            Response.Write("<br />");
            Response.Write(" Your browser: " + browser);
            Response.Write("<br />");
            Response.Write(" Client IP Address: " + ipClient);
            Response.Write("<br />");
            Response.Write(" Server IP Address: " + ipServer);
            Response.Write("<br />");
            Response.Write(" Your Requested URL: " + reqURL);
            Response.Write("<br />");
            Response.Write(" Your Referral URL: " + referrerPage);
        }
    }
}