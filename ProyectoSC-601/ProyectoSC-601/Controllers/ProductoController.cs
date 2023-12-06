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
        InventarioModel modelInventario = new InventarioModel();

        [HttpGet]
        public ActionResult Catalogo()
        {
            ViewBag.TotalInventario = modelInventario.ContarTotalInventario();
            var datos = modelInventario.ConsultarInventario();
            return View(datos);
        }

    }
}