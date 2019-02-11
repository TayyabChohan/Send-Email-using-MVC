using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MailSend.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(string recieveEmail, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var sendermail = new MailAddress("tayyabchohan7@gmail.com", "tayyab");
                    var recievermail = new MailAddress(recieveEmail , "Reciever");
                    var password = "03076818836";
                    var sub = subject;
                    var mag = message;

                    var smt = new SmtpClient
                    {
                        Host = "smpt.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(sendermail.Address, password)
                    };
                    using (var mess = new MailMessage(sendermail, recievermail)
                    {
                        Subject = sub,
                        Body = mag
                    }
                        )
                    {
                        smt.Send(mess);
                    }
                    return View();
                }
            }
            catch(Exception )
            {
                ViewBag.Error = "There are some Problems";
            }
            return View();
        }

    }
}