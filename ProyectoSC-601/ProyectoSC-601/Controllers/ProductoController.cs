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
            var datos = modelInventario.ConsultarInventario();
            ViewBag.Categorias = modelInventario.ConsultarCategorias();
            return View(datos);
        }

        [HttpGet]
        public ActionResult CatalogoMujer()
        {
            var datos = modelInventario.ConsultarInventario();
            return View(datos);
        }

        [HttpGet]
        public ActionResult CatalogoHombre()
        {
            var datos = modelInventario.ConsultarInventario();
            return View(datos);
        }

        [HttpGet]
        public ActionResult CatalogoNinos()
        {
            var datos = modelInventario.ConsultarInventario();
            return View(datos);
        }


        [HttpGet]
        public ActionResult AdquisicionesProductos()
        {
           
            var productos = new List<ProductoViewModel>
        {
            new ProductoViewModel { Nombre = "Producto 1", Precio = 20.0 },
            new ProductoViewModel { Nombre = "Producto 2", Precio = 30.0 },
          
        };
            return View();
        }

        [HttpGet]
        public ActionResult ProductoDetalle(long q)
        {
            var datos = modelInventario.ConsultaProductoEspecifico(q);
            return View(datos);
        }

    }
}