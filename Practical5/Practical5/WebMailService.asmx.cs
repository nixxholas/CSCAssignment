using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace Practical5
{
    /// <summary>
    /// Summary description for WebMailService
    /// </summary>
    [WebService(Namespace = "http://www.mdad.edu")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebMailService : System.Web.Services.WebService
    {
        public WebMailService()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [WebMethod(Description = "Send an SMTP mail message")]
        public string Send(string msgFrom, [XmlElementAttribute(IsNullable = true)]string msgTo, string msgSubject, string msgBody)
        {
            string functionReturnValue = null;
            try
            {
                SmtpClient SendMailClient = new SmtpClient("smtp.sp.edu.sg");
                MailAddress fromAddress = new MailAddress(msgFrom);
                MailAddress toAddress = new MailAddress(msgTo);
                MailMessage msg = new MailMessage(fromAddress, toAddress);
                SendMailClient.Port = 25;
                SendMailClient.UseDefaultCredentials = false;
                SendMailClient.Credentials = new System.Net.NetworkCredential("uid",
                                "password");

                msg.Subject = msgSubject;
                msg.Body = msgBody;
                SendMailClient.Send(msg);

                functionReturnValue = "OK";
            }
            catch (Exception ex)
            {
                functionReturnValue = "ERROR ";
            }
            return functionReturnValue;
        }

        [WebMethod(Description = "Send an Gmail mail message")]
        public string SendGmail(string msgFrom, [XmlElementAttribute(IsNullable = true)]string msgTo, string msgSubject, string msgBody)
        {
            string functionReturnValue = null;
            try
            {
                // Gmail SMTP server address
                SmtpClient SendMailClient = new SmtpClient("smtp.gmail.com");
                MailAddress fromAddress = new MailAddress(msgFrom);
                MailAddress toAddress = new MailAddress(msgTo);
                MailMessage msg = new MailMessage(fromAddress, toAddress);
                // Set 465 or 587 port
                SendMailClient.Port = 587;
                SendMailClient.EnableSsl = true;
                SendMailClient.UseDefaultCredentials = false;
                //*put your own gmail account information below
                SendMailClient.Credentials = new
                System.Net.NetworkCredential("nicholaschen35@gmail.com", "nicholaschen29");
                msg.Subject = msgSubject;
                msg.Body = msgBody;
                SendMailClient.Send(msg);
                functionReturnValue = "OK";
            }
            catch (Exception ex)
            {
                functionReturnValue = "ERROR " + ex.ToString();
            }
            return functionReturnValue;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
