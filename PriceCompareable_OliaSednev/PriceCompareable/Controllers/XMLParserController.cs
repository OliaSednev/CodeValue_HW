using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceCompareable.Controllers
{
    public class XMLParserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }
    }
}