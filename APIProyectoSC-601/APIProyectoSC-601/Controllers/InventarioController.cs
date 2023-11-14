using APIProyectoSC_601.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProyectoSC_601.Controllers
{
    public class InventarioController : ApiController
    {
        [HttpPost]
        [Route("RegistrarInventario")]
        public string RegistrarInventario(InventarioEnt entidad)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    // Replace with the actual stored procedure for registering inventory
                    context.RegistrarInventarioSP(entidad.Nombre_Producto, entidad.Cantidad, entidad.Precio_Unitario, entidad.Total, entidad.Fecha_Registro);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpGet]
        [Route("ConsultarProductos")]
        public List<System.Web.Mvc.SelectListItem> ConsultarProductos()
        {
            try
            {
                using (var contexto = new ImportadoraMoyaUlateEntities())
                {
                    var datos = (from x in contexto.Producto
                                 select x).ToList();

                    var combo = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        combo.Add(new System.Web.Mvc.SelectListItem
                        {
                            Value = item.ID_Producto.ToString(),
                            Text = item.Nombre_Producto
                        });
                    }

                    return combo;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpGet]
        [Route("ConsultaInventario")]
        public List<Inventario> ConsultaInventario()
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.Inventario
                            select x).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Inventario>();
            }
        }

        [HttpGet]
        [Route("ConsultaProducto")]
        public Inventario ConsultaProducto(long q)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.Inventario
                            where x.ID_Inventario == q
                            select x).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPut]
        [Route("ActualizarProducto")]
        public string ActualizarProducto(InventarioEnt entidad)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    // Replace with the actual stored procedure for updating inventory
                    context.ActualizarProductoSP(entidad.ID_Inventario, entidad.Nombre_Producto, entidad.Cantidad, entidad.Precio_Unitario, entidad.Total, entidad.Fecha_Registro);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public string EliminarProducto(long q)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    var productoAEliminar = context.Inventario.FirstOrDefault(p => p.ID_Inventario == q);

                    if (productoAEliminar != null)
                    {
                        context.Inventario.Remove(productoAEliminar);
                        context.SaveChanges();
                        return "OK";
                    }
                    else
                    {
                        return "Producto no encontrado.";
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
