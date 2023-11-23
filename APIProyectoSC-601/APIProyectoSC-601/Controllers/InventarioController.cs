using APIProyectoSC_601.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProyectoSC_601.Controllers
{
    public class InventarioController : ApiController
    {
        //Devuelve una lista con todos los productos registrados en la base de datos

        [HttpGet]
        [Route("ConsultarInventario")]
        public List<Producto> ConsultarInventario()
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return context.Producto.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Producto>();
            }
           
        }

        //Devuelve una lista con las categorias que existen para los productos
        [HttpGet]
        [Route("ConsultarCategorias")]
        public List<System.Web.Mvc.SelectListItem> ConsultarCategorias()
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    var datos = (from x in context.Categorias
                                 select x).ToList();

                    List<System.Web.Mvc.SelectListItem> categorias = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        categorias.Add(new System.Web.Mvc.SelectListItem
                        {
                            Value = item.ID_Categoria.ToString(),
                            Text = item.Nombre
                        });
                    }

                    return categorias;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }


        //Conexion a procedimiento para registrar productos
        [HttpPost]
        [Route("RegistrarProducto")]
        public long RegistrarProducto(Producto producto)
        {  
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return producto.ID_Producto;
            }
        }


        //Actualiza la ruta de la imagen del producto en la base de datos
        [HttpPut]
        [Route("ActualizarRutaProducto")]
        public string ActualizarRutaProducto(Producto producto)
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                var datos = context.Producto.Where(x => x.ID_Producto == producto.ID_Producto).FirstOrDefault();
                datos.Imagen = producto.Imagen;
                context.SaveChanges();
                return "OK";
            }
        }

    }
}
