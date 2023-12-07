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
        public ActionResult RegistrarCarrito()
        {
            //  var entidad = new CarritoEnt();
            //   entidad.ID_Cliente = long.Parse(Session["ConUsuario"].ToString());
            // entidad.ID_Producto = conProducto;
            //  entidad.Cantidad = cantidad;
            // entidad.FechaCarrito = DateTime.Now;

            //  modelCarrito.RegistrarCarrito(entidad);

            //  var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
            //  Session["Cant"] = datos.AsEnumerable().Sum(x => x.Cantidad);
            //  Session["SubT"] = datos.AsEnumerable().Sum(x => x.SubTotal);

            //return Json("OK", JsonRequestBehavior.AllowGet);
            return View();
        }

        [HttpGet]
        public ActionResult ConsultaCarrito()
        {
            //var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
            //Session["TotalPago"] = datos.AsEnumerable().Sum(x => x.Total);
            //return View(datos);
            return View();
        }

        [HttpGet]
        public ActionResult ConsultaFacturas()
        {
            // var datos = modelCarrito.ConsultaFacturas(long.Parse(Session["ConUsuario"].ToString()));
            // return View(datos);
            return View();
        }

        [HttpGet]
        public ActionResult ConsultaDetalleFactura()
        {
            //  var datos = modelCarrito.ConsultaDetalleFactura(q);
            //return View(datos);
            return View();
        }

        [HttpPost]
        public ActionResult PagarCarrito()
        {
            // var entidad = new CarritoEnt();
            // entidad.ConUsuario = long.Parse(Session["ConUsuario"].ToString());

            // var respuesta = modelCarrito.PagarCarrito(entidad);
            //var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
            // Session["Cant"] = datos.AsEnumerable().Sum(x => x.Cantidad);
            //Session["SubT"] = datos.AsEnumerable().Sum(x => x.SubTotal);

            //if (respuesta > 0)
            //  {
            //      //     return RedirectToAction("Index", "Login");
            // }
            // else
            //  {
            //    ViewBag.MensajeUsuario = "No se ha podido procesar su pago, verifica las unidades disponibles";
            // return View("ConsultaCarrito", datos);
            //}
            return View();
        }

        [HttpGet]
        public ActionResult EliminarRegistroCarrito()
        {
            //   modelCarrito.EliminarRegistroCarrito(q);

            // var datos = modelCarrito.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
            // Session["Cant"] = datos.AsEnumerable().Sum(x => x.Cantidad);
            // Session["SubT"] = datos.AsEnumerable().Sum(x => x.SubTotal);
            //return RedirectToAction("ConsultaCarrito", "Carrito");
            return View();
        }

    }
}