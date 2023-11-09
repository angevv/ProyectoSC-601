using ProyectoSC_601.Entities;
using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Controllers
{
    public class ClienteController : Controller
    {

        ClienteModel modelCliente = new ClienteModel();

        [HttpGet]
        public ActionResult RegistroCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistroCliente(ClienteEnt entidad)
        {
            string respuesta = modelCliente.RegistroCliente(entidad);

             if (respuesta == "OK")
            {
                ViewBag.MensajeExitoso = "La información se ha registrado exitosamente";
                return View();
            }
            else
            {
                ViewBag.MensajeNoExitoso = "No se ha podido registrar la información";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ClienteEnt entidad)
        {
            var respuesta = modelCliente.Login(entidad);

            if (respuesta != null && respuesta.Rol_Cliente==2)
            {
                Session["Ced_Cliente"] = respuesta.Ced_Cliente;
                Session["Nombre_Cliente"] = respuesta.Nombre_Cliente;
                Session["Apellido_Cliente"] = respuesta.Apellido_Cliente;
                Session["Correo_Cliente"] = respuesta.Correo_Cliente;
                Session["Direccion_Cliente"] = respuesta.Direccion_Cliente;
                Session["Tel_Cliente"] = respuesta.Tel_Cliente;
                Session["Rol_Cliente"] = respuesta.Rol_Cliente;
                return RedirectToAction("Index", "Home");
            }
            else if (respuesta != null && respuesta.Rol_Cliente==1)
            {
                Session["Ced_Cliente"] = respuesta.Ced_Cliente;
                Session["Nombre_Cliente"] = respuesta.Nombre_Cliente;
                Session["Apellido_Cliente"] = respuesta.Apellido_Cliente;
                Session["Correo_Cliente"] = respuesta.Correo_Cliente;
                Session["Direccion_Cliente"] = respuesta.Direccion_Cliente;
                Session["Tel_Cliente"] = respuesta.Tel_Cliente;
                Session["Rol_Cliente"] = respuesta.Rol_Cliente;


                return RedirectToAction("IndexAdmin", "Home");

            }
            else
            {
                ViewBag.MensajeNoExitoso = "Credenciales Inválidos";
                return View();
            }
        }

        [HttpGet]
        public ActionResult RecuperarCuentaCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarCuentaCliente(ClienteEnt entidad)
        {
            string respuesta = modelCliente.RecuperarCuentaCliente(entidad);

            if (respuesta == "OK")
            {
                return RedirectToAction("Login", "Cliente");
            }
            else
            {
                ViewBag.MensajeNoExitoso = "No se ha podido recuperar su información";
                return View();
            }
        }

        [HttpGet]
        public ActionResult PerfilCliente()
        {
            var modelo = new ProyectoSC_601.Entities.ClienteEnt();
            modelo.Ced_Cliente = Session["Ced_Cliente"] as string;
            modelo.Nombre_Cliente = Session["Nombre_Cliente"] as string;
            modelo.Apellido_Cliente = Session["Apellido_Cliente"] as string;
            modelo.Correo_Cliente = Session["Correo_Cliente"] as string;
            modelo.Direccion_Cliente = Session["Direccion_Cliente"] as string;
            modelo.Tel_Cliente = Session["Tel_Cliente"] as string;
            return View(modelo);
        }

        [HttpGet]
        public ActionResult CerrarSesionCliente()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // FALTA ACTUALIZAR PERFIL E INACTIVAR PERFIL
        // FALTA CAMBIO DE CONTRASENNA EN EL PERFIL DEL CLIENTE (AGREGAR ATRIBUTOS ENTIDAD)
        // FALTA NO PERMITIR 2 CORREOS IGUALES
        // MEJORAR INTERFAZ
        // MENSAJES PERSONALIZADOS EN ACCIONES DE ACTUALIZAR O BORRAR PERFIL

    }
}