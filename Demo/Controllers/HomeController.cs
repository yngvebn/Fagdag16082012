using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Infrastructure.DomainEvents;
using DomainEventExtensions;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDomainEvents _domainEvents;

        public HomeController(IDomainEvents domainEvents)
        {
            _domainEvents = domainEvents;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
