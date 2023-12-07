using ProyectoSC_601.Entities;
using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Controllers
{
    public class CarritoController : Controller
    {


        CarritoModel modelCarrito = new CarritoModel();


        [HttpGet]
        public ActionResult RegistrarCarrito(int cantidad, long ID_Producto)
        {
            var entidad = new CarritoEnt();
            entidad.ID_Usuario = long.Parse(Session["ID_Cliente"].ToString());
            entidad.ID_Producto = ID_Producto;
            entidad.Cantidad = cantidad;
            entidad.FechaCarrito = DateTime.Now;

            modelCarrito.RegistrarCarrito(entidad);

            var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["ID_Cliente"].ToString()));
            Session["Cant"] = datos.AsEnumerable().Sum(x => x.Cantidad);
            Session["SubT"] = datos.AsEnumerable().Sum(x => x.SubTotal);

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Carrito()
        {
            
                var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["ID_Cliente"].ToString()));
                Session["TotalPago"] = datos.AsEnumerable().Sum(x => x.Total);
                return View(datos);
         
        }

        [HttpGet]
        public ActionResult EliminarRegistroCarrito(long q)
        {
            modelCarrito.EliminarRegistroCarrito(q);

            var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["ID_Cliente"].ToString()));
            Session["Cant"] = datos.AsEnumerable().Sum(x => x.Cantidad);
            Session["SubT"] = datos.AsEnumerable().Sum(x => x.SubTotal);
            return RedirectToAction("Carrito", "Carrito");
        }

    }
}


