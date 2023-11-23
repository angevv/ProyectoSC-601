using ProyectoSC_601.Entities;
using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            var datos = modelInventario.ConsultarInventario();
            return View(datos);
        }

        //Devuele la vista de registrar productos con las categorias 
        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            ViewBag.Categorias = modelInventario.ConsultarCategorias();
            return View();
        }

        //Registra un producto 
        [HttpPost]
        public ActionResult RegistrarProducto(HttpPostedFileBase ImgProducto, InventarioEnt entidad)
        {
            entidad.Imagen = string.Empty;
            entidad.Estado = 1;

            long ID_Producto = modelInventario.RegistrarProducto(entidad);

            if (ID_Producto > 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName));
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + ID_Producto + extension;
                ImgProducto.SaveAs(ruta);

                entidad.Imagen = "/Images/" + ID_Producto + extension;
                entidad.ID_Producto = ID_Producto;

                modelInventario.ActualizarRutaProducto(entidad);

                return RedirectToAction("ConsultaInventario", "Inventario");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar el producto";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ModificarProducto()
        {
            return View();
        }

    }
}