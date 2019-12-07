using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using EMI.Models;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EMI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            Session["Status"] = "empty";
            return View();
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult Contact(ContactUseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(
                   model.Email, "info@emichurch.org.za", model.Name + " " + model.Surname + " " + model.Subject, model.Message
                   +
                   "<br/>" + "Name : " + model.Name +
                   "<br/>" + "Surname : " + model.Surname +
                   "<br/>" + "Email : " + model.Email +
                   "<br/>" + "Cellphone : " + model.Cellphone +
                   "<br/>" + "Address : " + model.Address +
                   "<br/> <br/>" + "<b> Kind Regards <b/>" +
                   "<br/> " + model.Name + " " + model.Surname);

                    // SET "True" IF THE BODY OF THE MAIL IS IN HTML FORMAT.
                    mail.IsBodyHtml = true;

                    // THE "SmtpClient() CLASS" AND ITS PROPERTIES.
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

                    client.Host = "mail.emichurch.org.za";   // SOME SMTP SERVER. FOR EXAMPLE smpt.gmail.com
                    client.Port = 587;
                    client.UseDefaultCredentials = true;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    new System.Net.NetworkCredential("info@emichurch.org.za", "emichurch2019");
                    client.Send(mail);


                    Session["Status"] = "Email Sent Successfully.";
                    ModelState.Clear();
                    model = new ContactUseModel();
                   
                
                }
                catch (Exception ex)
                {
                    Session["Status"] = "Problem while sending email, Please check details." + ex.Message;

                }
            }
            else
            {
                Session["Status"] = "empty";
                ModelState.AddModelError("", "");

            }
           

            return View(model);
        }

        public ActionResult Sermons()
        {
            Media media = new Media();
            return View(media.GetMedia());

          
        }
        [HttpGet]
        public ActionResult Ministry(string ministry)
        {
            Session["Status"] = "empty";
            if(!String.IsNullOrEmpty(ministry))
            {
                
                if(ministry.Equals("Marketing Ministry", StringComparison.OrdinalIgnoreCase))
                {
                    
                    Session["Ministry"] = ministry;
                    Session["Description"] = "This ministry is mainly responsible for sending out information about the church,events and other activities to the nation at large.This can be done through local and national newspapers,social media and the internet.";
                }
                else if (ministry.Equals("Bookstore Ministry", StringComparison.OrdinalIgnoreCase))
                {
                    
                    Session["Ministry"] = ministry;
                    Session["Description"] = "This ministry is responsible for marketing CD's and DVD recording of sermons and books written and published within our church.";
                }
                else if (ministry.Equals("Global Missions Outreach", StringComparison.OrdinalIgnoreCase))
                {
                    
                    Session["Ministry"] = ministry;
                    Session["Description"] = "This ministry takes pride on what it does,caring for our congregants and the community at large especially people who are needy and need to be provided for.";
                }
                else if (ministry.Equals("Bereavement Ministry", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry is responsible for being there for those who have lost their loved ones and those who are in grief.This ministry takes pride in making sure our people are showed love and taken care of at all the times.";
                    Session["Ministry"] = ministry;
                }
               
                else if (ministry.Equals("Men's Ministry", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry takes pride in building real men looking forward to knowing the word more and living Chirst-like life.The ministry empowers young and old men at all times and teaches them the basic priniciples of being a man. ";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Ushers", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry is reponsible for directing and coordinating congregants during church,they take care of the congregants and ensure that they get immediate help. ";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Band & Drums Crew", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry takes pride in making sure that the band and drum sound is working properly as well as giving congregants good bands and drums during session.";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Women's Ministry", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry takes pride in building real women looking forward to knowing the word more and living Chirst-like life.The ministry empowers young and old women at all times and teaches them the basic priniciples of being a woman.";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Kingdom Kids Ministry", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry is for children at the age of 3- 14 years old,giving them basic bible principles and teaching them about the word of God.";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Youth Ministry Team", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry is for youth at the age of 18 - 35 who are keen in the word of God and want to know more about God and living a Christ-like life";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Sound, Graphics & Media", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry is responsible for ensuring that visual graphics are displayed correctly as well as presentations.These are tech-experts always making sure that the church delivers to everybody around the church and outside.";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Praise & Worship", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "Praise & Worship leads the congregation in song during weekly and other services.";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Hospitality", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "The mission of the Hospitality ministry is to provide a welcoming environment of love, comfort, support and care for our guest Pastors and music Minstrels.";
                    Session["Ministry"] = ministry;
                }
                else if (ministry.Equals("Evangelism", StringComparison.OrdinalIgnoreCase))
                {
                    Session["Description"] = "This ministry is responsible for winning souls in the local communities and the aim is to win people back to God and restore them.";
                }
                
            }

            return View();
        }
        [HttpPost] 
         public ActionResult Ministry(Email model)
        {

            if(ModelState.IsValid)
            {
                try
                {

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(
                   model.EmailAddress, "info@emichurch.org.za", model.Name + " " + model.Surname + " enquiry to join " + Session["Ministry"], model.Message
                   +
                   "<br/>" + "Name : " + model.Name+
                   "<br/>" + "Surname : " + model.Surname+
                   "<br/>" + "Email : " + model.EmailAddress+
                   "<br/>" + "Cellphone : "+ model.Cellphone +
                   "<br/>" + "Address : " +  model.Address +
                   "<br/> <br/>" + "<b> Kind Regards <b/>" + 
                   "<br/> " + model.Name + " " + model.Surname);

                    // SET "True" IF THE BODY OF THE MAIL IS IN HTML FORMAT.
                    mail.IsBodyHtml = true;

                    // THE "SmtpClient() CLASS" AND ITS PROPERTIES.
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                    
                    client.Host = "mail.emichurch.org.za";   // SOME SMTP SERVER. FOR EXAMPLE smpt.gmail.com
                    client.Port = 587; 
                    client.UseDefaultCredentials = true;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    new System.Net.NetworkCredential("info@emichurch.org.za", "emichurch2019");
                    client.Send(mail);

                   
                    Session["Status"] = "Email Sent Successfully.";
                    ModelState.Clear();
                    model = new Email();
                   
                }
                catch(Exception ex)
                {
                    Session["Status"] = "Problem while sending email, Please check details." + ex.Message;

                }
            }
            else
            {
                Session["Status"] = "empty";
                ModelState.AddModelError("","");
            }
            return View(model);
        }
        private bool RemoteServerCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
           
            return true;
        }
        public ActionResult Events()
        {
            ViewBag.Message = "Your events page";
            return View();

        }

        public ActionResult EventInfo(string eventName)
        {
            return View();
        }
       

        public ActionResult Homecells()
        {
            Session["Status"] = "empty";
            return View();
        }
        [HttpPost]public ActionResult Homecells(Email model)
        {

            if(ModelState.IsValid)
            {
                try
                {

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(
                   model.EmailAddress, "info@emichurch.org.za", model.Name + " " + model.Surname + " enquiry to join Homecell ", model.Message
                   +
                   "<br/>" + "Name : " + model.Name +
                   "<br/>" + "Surname : " + model.Surname +
                   "<br/>" + "Email : " + model.EmailAddress +
                   "<br/>" + "Cellphone : " + model.Cellphone +
                   "<br/>" + "Address : " + model.Address +
                   "<br/> <br/>" + "<b> Kind Regards <b/>" +
                   "<br/> " + model.Name + " " + model.Surname);

                    // SET "True" IF THE BODY OF THE MAIL IS IN HTML FORMAT.
                    mail.IsBodyHtml = true;

                    // THE "SmtpClient() CLASS" AND ITS PROPERTIES.
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

                    client.Host = "mail.emichurch.org.za";   // SOME SMTP SERVER. FOR EXAMPLE smpt.gmail.com
                    client.Port = 587;
                    client.UseDefaultCredentials = true;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    new System.Net.NetworkCredential("info@emichurch.org.za", "emichurch2019");
                    client.Send(mail);


                    Session["Status"] = "Email Sent Successfully.";
                    ModelState.Clear();
                    model = new Email();
                   
                }
                catch (Exception ex)
                {
                    Session["Status"] = "Problem while sending email, Please check details." + ex.Message;

                }
            }
            else
            {
                Session["Status"] = "empty";
                ModelState.AddModelError("", "");
            }

            return View();
        }
        public ActionResult Giving()
        {
            ViewBag.Message = "Your givings page";
            return View();

        }
        public ActionResult Ministries()
        {
            ViewBag.Message = "Your location page";
            return View();
        }
        [HttpPost]public ActionResult Ministries(string sd)
        {
            ViewBag.Message = sd;
            return View();
        }
        public ActionResult G12()
        {
            Session["Status"] = "empty";
            return View();
        }
        [HttpPost,ValidateInput(false)]public ActionResult G12(Email model)
        {
            if(ModelState.IsValid)
            {
                try
                {

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(
                   model.EmailAddress, "info@emichurch.org.za", model.Name + " " + model.Surname + " enquiry to join G12 ", model.Message
                   +
                   "<br/>" + "Name : " + model.Name +
                   "<br/>" + "Surname : " + model.Surname +
                   "<br/>" + "Email : " + model.EmailAddress +
                   "<br/>" + "Cellphone : " + model.Cellphone +
                   "<br/>" + "Address : " + model.Address +
                   "<br/> <br/>" + "<b> Kind Regards <b/>" +
                   "<br/> " + model.Name + " " + model.Surname);

                    // SET "True" IF THE BODY OF THE MAIL IS IN HTML FORMAT.
                    mail.IsBodyHtml = true;

                    // THE "SmtpClient() CLASS" AND ITS PROPERTIES.
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

                    client.Host = "mail.emichurch.org.za";   // SOME SMTP SERVER. FOR EXAMPLE smpt.gmail.com
                    client.Port = 587;
                    client.UseDefaultCredentials = true;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    new System.Net.NetworkCredential("info@emichurch.org.za", "emichurch2019");
                    client.Send(mail);


                    Session["Status"] = "Email Sent Successfully.";
                    ModelState.Clear();
                    model = new Email();
                    
                }
                catch (Exception ex)
                {
                    Session["Status"] = "Problem while sending email, Please check details." + ex.Message;

                }
            }
            else
            {
                Session["Status"] = "empty";
                ModelState.AddModelError("", "");
            }



            return View(model);
        }

    }
} 