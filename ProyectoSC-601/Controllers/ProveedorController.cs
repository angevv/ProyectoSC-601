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
                TempData["SuccessMessage"] = "El movimiento se realizó correctamente.";
                return RedirectToAction("IndexAdmin", "Home");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                ViewBag.combo = modelProveedor.ConsultarEmpresas();
                return View();
            }
        }


        [HttpGet]
        public ActionResult ConsultaProveedor()
        {
            var datos = modelProveedor.ConsultaProveedor();
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
                return RedirectToAction("ConsultaProveedor", "Proveedor");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido cambiar el estado del usuario";
                return View();
            }
        }

    }
}