using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using aspnet_tthk.Models;

namespace aspnet_tthk.Controllers
{

    public class HomeController : Controller
    {
        string permaMail;
        public ActionResult Index()
        {
            if (DateTime.Now.Month.ToString("00") == "03")
            {
                ViewBag.Message = "Ootan 8 märtsi peole!";
            }
            else if (DateTime.Now.ToString("00") == "04")
            {
                ViewBag.Message = "Ootan 1 aprilli peole!";
            }
            else if (DateTime.Now.ToString("00") == "05")
            {
                ViewBag.Message = "Ootan emade päeva peole!";
            }


            int hour = DateTime.Now.Hour;
            if (hour >= 4 && hour < 12)
            {
                ViewBag.Greeting = "Tere hommikust";
            }
            else if (hour >= 12 && hour < 16)
            {
                ViewBag.Greeting = "Tere päevast";
            }
            else if (hour >= 16 && hour < 23)
            {
                ViewBag.Greeting = "Tere õhtust";
            }
            else if (hour == 23 || hour < 4)
            {
                ViewBag.Greeting = "Head ööd";
            }
            return View();
        }

        [HttpGet]

        public ViewResult Ankeet()
        {
            return View();
        }

        [HttpPost]

        public ViewResult Ankeet(Guest guest)
        {
            E_Mail(guest);
            permaMail = guest.Email;
            if (ModelState.IsValid)
            { return View("Thanks", guest); }
            else
            { return View(); }
        }

        public void E_Mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "";
                WebMail.Password = "";
                WebMail.From = "";
                WebMail.Send("krostislav468@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ?
                    "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud";
                WebMail.Send(guest.Email, "Peo", ((bool)guest.WillAttend ? "Ootan teid peole!" : "Nägemist!"
                    ));
                
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }
        }

        public ActionResult sendTulus(string email)
        {
            tulus(email);
            return RedirectToAction("Index");
        }

        public void tulus(string email)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "";
                WebMail.Password = "";
                WebMail.From = "";
                WebMail.Send(email, "Peo", "Ära unusta ootame teid peos!", filesToAttach: new String[] {System.IO.Path.Combine(Server.MapPath("~/Images/"), System.IO.Path.GetFileName("party.jpg") )});

            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }

        }
    }
}