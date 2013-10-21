using SendGridWebHookLibrary.Managers;
using SendGridWebHookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "SendGrid Webhook Event Example";
            List<SendGridEvent> sgEvents = SendGridEventManager.GetEvents(0, 100);
            return View(sgEvents);
        }
    }
}
