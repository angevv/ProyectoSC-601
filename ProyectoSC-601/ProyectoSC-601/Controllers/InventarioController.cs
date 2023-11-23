using ProyectoSC_601.Entities;
using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ProyectoSC_601.Controllers
{
    public class InventarioController : Controller
    {
        
        InventarioModel modelInventario=new InventarioModel();


        /* Consulta todos los productos registrados en el sistema */
        [HttpGet]
        public ActionResult ConsultaInventario()
        {
            //var datos = modelInventario.ConsultarInventario();
            //return View(datos);
            return View();
        }

        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ModificarProducto()
        {
            return View();
        }

    }
}