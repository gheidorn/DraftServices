using DraftServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftServices.Controllers
{
    public class HomeController : Controller
    {
        static readonly IDraftRepository repository = new DraftRepository();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(repository.GetAll());
        }
    }
}
