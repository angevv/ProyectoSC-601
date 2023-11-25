using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using APIProyectoSC_601;

namespace APIProyectoSC_601.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarProductos")]
        public List<Producto> ConsultarProductos()
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                return context.Producto.ToList();
            }

        }


        [HttpPost]
        [Route("RegistrarProducto")]
        public string RegistrarProducto(Producto producto)
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {

                context.Producto.Add(producto);
                context.SaveChanges();

                return "OK";
            }
        }


        /*private ImportadoraMoyaUlateEntities db = new ImportadoraMoyaUlateEntities();

       

        // GET: api/Producto/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult GetProducto(long id)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Producto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducto(long id, Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.ID_Producto)
            {
                return BadRequest();
            }

            db.Entry(producto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

       

        // DELETE: api/Producto/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult DeleteProducto(long id)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.Producto.Remove(producto);
            db.SaveChanges();

            return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(long id)
        {
            return db.Producto.Count(e => e.ID_Producto == id) > 0;
        }
        */
    }
}