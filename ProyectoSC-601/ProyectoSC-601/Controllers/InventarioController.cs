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
        InventarioModel modelInventario = new InventarioModel();

        /* This returns the view to register an inventory item */
        [HttpGet]
        public ActionResult RegistrarInventario()
        {
            try
            {
                // You might need to replace this with the appropriate data retrieval for your case
                ViewBag.combo = modelInventario.ConsultarProveedores();
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /* Called when the form to register an inventory item is submitted */
        [HttpPost]
        public ActionResult RegistrarInventario(InventarioEnt entidad)
        {
            try
            {
                // Replace this with the actual method to register an inventory item
                string respuesta = modelInventario.RegistrarInventario(entidad);

                if (respuesta == "OK")
                {
                    TempData["RegistroExito"] = "El item de inventario se registró correctamente.";
                    return RedirectToAction("ConsultaInventario", "Inventario");
                }
                else
                {
                    ViewBag.MensajeUsuario = "No se ha podido registrar la información del item de inventario.";
                    ViewBag.combo = modelInventario.ConsultarProveedores();
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /* Called when requesting the inventory items page to display data for all inventory items */
        [HttpGet]
        public ActionResult ConsultaInventario()
        {
            try
            {
                var datos = modelInventario.ConsultaInventario();
                return View(datos);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /* Called when you want to update the state of an inventory item */
        [HttpGet]
        public ActionResult ActualizarEstadoInventario(long q)
        {
            try
            {
                var entidad = new InventarioEnt();
                entidad.ID_Inventario = q;

                // Replace this with the actual method to update the state of an inventory item
                string respuesta = modelInventario.ActualizarEstadoInventario(entidad);

                if (respuesta == "OK")
                {
                    return RedirectToAction("ConsultaInventario", "Inventario");
                }
                else
                {
                    ViewBag.MensajeUsuario = "No se ha podido cambiar el estado del item de inventario.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /* Called when you want to update the information of a modified inventory item */
        [HttpGet]
        public ActionResult ActualizarInventario(long q)
        {
            try
            {
                var datos = modelInventario.ConsultaInventario(q);
                // You might need to replace this with the appropriate data retrieval for your case
                ViewBag.combo = modelInventario.ConsultarProveedores();
                return View(datos);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /* Processes the update of data for an inventory item from a form and redirects */
        [HttpPost]
        public ActionResult ActualizarInventario(InventarioEnt entidad)
        {
            try
            {
                // Replace this with the actual method to update an inventory item
                string respuesta = modelInventario.ActualizarInventario(entidad);

                if (respuesta == "OK")
                {
                    TempData["ActualizacionExito"] = "Item de inventario actualizado con éxito";
                    return RedirectToAction("ConsultaInventario", "Inventario");
                }
                else
                {
                    ViewBag.MensajeUsuario = "No se ha podido actualizar la información del item de inventario.";
                    ViewBag.combo = modelInventario.ConsultarProveedores();
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /* Called when you request to delete an inventory item */
        [HttpGet]
        public ActionResult EliminarInventario(long q)
        {
            try
            {
                // Replace this with the actual method to delete an inventory item
                string respuesta = modelInventario.EliminarInventario(q);

                // Print the response to the console for debugging
                Console.WriteLine($"Service response: {respuesta}");

                if (respuesta == "OK")
                {
                    TempData["ActualizacionExito"] = "Item de inventario eliminado con éxito";
                    return RedirectToAction("ConsultaInventario", "Inventario");
                }
                else
                {
                    ViewBag.MensajeUsuario = "No se ha podido eliminar el item de inventario.";
                    return View("ConsultaInventario", "Inventario");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
