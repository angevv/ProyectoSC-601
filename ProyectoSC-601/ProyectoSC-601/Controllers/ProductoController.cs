using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index_Prod()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }


    }
}