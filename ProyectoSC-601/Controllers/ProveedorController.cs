using ProyectoSC_601.Entities;
using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProyectoSC_601.Controllers
{
    public class ProveedorController : Controller
    {
        
        ProveedorModel modelProveedor=new ProveedorModel();


        [HttpGet]
        public ActionResult RegistrarProveedor()
        {
            try
            {
                ViewBag.combo = modelProveedor.ConsultarEmpresas();
                return View();
            }
            catch (Exception ex)
            {
                return ViewBag.Empresas;
            }
        }

        //Procesa el formulario de registro de proveedores
        [HttpPost]
        public ActionResult RegistrarProveedor(ProveedorEnt entidad)
        {
            string respuesta = modelProveedor.RegistrarProveedor(entidad);

            if (respuesta == "OK")
            {
                TempData["RegistroExito"] = "El proveedor se registró correctamente.";
                return RedirectToAction("ConsultaProveedores", "Proveedor");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar la informacón del proveedor";
                ViewBag.combo = modelProveedor.ConsultarEmpresas();
                return View();
            }
        }


        [HttpGet]
        public ActionResult ConsultaProveedores()
        {
            var datos = modelProveedor.ConsultaProveedores();
            return View(datos);

        }


        [HttpGet]
        public ActionResult ActualizarEstadoProveedor(long q)
        {
            var entidad = new ProveedorEnt();
            entidad.ID_Proveedor = q;

            string respuesta = modelProveedor.ActualizarEstadoProveedor(entidad);

            if (respuesta == "OK")
            {
                return RedirectToAction("ConsultaProveedores", "Proveedor");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido cambiar el estado del proveedor";
                return View();
            }
        }


        [HttpGet]
        public ActionResult ActualizarProveedor(long q)
        {
            var datos = modelProveedor.ConsultaProveedor(q);
            ViewBag.combo = modelProveedor.ConsultarEmpresas();
            return View(datos);
        }


        [HttpPost]
        public ActionResult ActualizarProveedor(ProveedorEnt entidad)
        {
            string respuesta = modelProveedor.ActualizarProveedor(entidad);

            if (respuesta == "OK")
            {
                TempData["ActualizacionExito"] = "Proveedor actualizado con éxito";
                return RedirectToAction("ConsultaProveedores", "Proveedor");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido actualizar la información del proveedor";
                ViewBag.combo = modelProveedor.ConsultarEmpresas();
                return View();
            }
        }



        [HttpGet]
        public ActionResult EliminarProveedor(long q)
        {
            string respuesta = modelProveedor.EliminarProveedor(q);

            // Imprime la respuesta en la consola para depuración
            Console.WriteLine($"Respuesta del servicio: {respuesta}");

            if (respuesta == "OK")
            {
                TempData["ActualizacionExito"] = "Proveedor eliminado con éxito";
                return RedirectToAction("ConsultaProveedores", "Proveedor");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido eliminar el proveedor.";
                return View("ConsultaProveedores", "Proveedor");
            }
        }




    }
}