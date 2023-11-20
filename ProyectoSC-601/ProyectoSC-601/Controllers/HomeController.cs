using ProyectoSC_601.Entities;
using ProyectoSC_601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Controllers
{
    public class HomeController : Controller
    {

        ContactoModel modelContacto = new ContactoModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Se llama al modelo para enviar la informacion de la seccion contactenos
        [HttpPost]
        public ActionResult Index(InfoContacto entidad)
        {
            string respuesta = modelContacto.EnviarInformacion(entidad);

            if (respuesta == "OK")
            {
                ViewBag.MensajeExitoso = "La información se ha enviado con éxito";
                return View();
            }
            else
            {
                ViewBag.MensajeNoExitoso = "No se ha podido enviar la informacion";
                return View();
            }
        }

        public ActionResult IndexAdmin() 
        {
            return View();
        }


    }
}