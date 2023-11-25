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
            ProductoModel modelProducto = new ProductoModel();

            [HttpGet]
            public ActionResult ConsultarProducto()
            {
                var datos = modelProducto.ConsultarProductos();
                return View();
            }
        }
}


