using ProyectoSC_601.Entities;
using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace ProyectoSC_601.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModel modelProducto = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultarProducto()
        {
            var datos = modelProducto.ConsultarProductos();

            return View(datos);
        }


        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarProducto(HttpPostedFile ImgProducto, ProductoEnt entidad)
        {


            entidad.Imagen = String.Empty;
            entidad.Estado = true;

            long conProducto = modelProducto.RegistrarProducto(entidad);

                if(conProducto > 0)
                {
                    string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName));
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + conProducto + extension;
                    ImgProducto.SaveAs(ruta);

                    entidad.Imagen = "/Images/" + conProducto + extension;
                    entidad.conProducto = conProducto;
                    modelProducto.ActualizarRutaProducto(entidad);

                    return RedirectToAction("ConsultarProducto", "Producto");
                }
                else
                {
                ViewBag.MensajeUsuario = "No se a podido registrar su producto";
                return View();
                }
        }
    }
}


