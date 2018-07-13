using SuperheroesInc.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SuperheroesInc.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our Mission:";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Superheroes, Inc!";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            contact.DateSent = DateTime.Now;
            contact.Subject = "From Website: " + contact.Subject;

            string messageContent = $"Name: {contact.FirstName} {contact.LastName}<br/>" +
                $"Email: {contact.Email}<br />Subject: {contact.Subject}<br/>" +
                $"<h3>Message</h3>: {contact.Message}<br /> Date Sent: {contact.DateSent}";

            MailMessage m = new MailMessage("no-reply@codingbychad.com", "chad@codingbychad.com", contact.Subject, messageContent);

            //Allow HTML in body of email
            m.IsBodyHtml = true;

            //Reply to original emailer
            m.ReplyToList.Add(contact.Email);

            //SMTP Client
            SmtpClient client = new SmtpClient("mail.codingbychad.com");

            client.Credentials = new NetworkCredential("no-reply@codingbychad.com", "Ma774ew.");

            using (client)
            {
                try
                {
                    client.Send(m);
                }//end try
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "There was an error sending your message. Please try again";

                    return View(contact);

                }

                return View("ContactConfirm", contact);
            }


        }
    }
}