using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Controllers
{
    public class FacturacionController : Controller
    {
        [HttpGet]
        public ActionResult Facturacion()
        {
            return View();

        }

        [HttpGet]
        public ActionResult FacturaDetalle()
        {
            return View();

        }

        [HttpGet]
        public ActionResult FacturacionCliente()
        {
            return View();

        }

        [HttpGet]
        public ActionResult FacturaDetalleCliente()
        {
            return View();

        }
    }
}