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
    public class FacturacionController : ApiController
    {
        [HttpGet]
        [Route("ConsultaFacturasCliente")]
        public List<Factura_Encabezado> ConsultaFacturasCliente(long q)
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return (from x in context.Factura_Encabezado
                        where x.ID_Usuario == q
                        select x).ToList();
            }
        }

        [HttpGet]
        [Route("ConsultaFacturasAdmin")]
        public object ConsultaFacturasAdmin()
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {

                context.Configuration.LazyLoadingEnabled = false;
                return (from x in context.Factura_Encabezado
                        join y in context.Clientes on x.ID_Usuario equals y.ID_Cliente
                        select new
                        {
                            x.ID_Factura,
                            NombreCliente = y.Nombre_Cliente,
                            ApellidoCliente = y.Apellido_Cliente,
                            x.FechaCompra,
                            x.TotalCompra,
                        }).ToList();
            }
        }

        [HttpGet]
        [Route("ConsultaDetalleFactura")]
        public object ConsultaDetalleFactura(long q)
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return (from x in context.Factura_Detalle
                        join y in context.Producto on x.ID_Producto equals y.ID_Producto
                        where x.ID_Factura == q
                        select new
                        {
                            x.ID_Factura,
                            y.Nombre,
                            x.PrecioPagado,
                            x.CantidadPagado,
                            x.ImpuestoPagado,
                            SubTotal = (x.PrecioPagado * x.CantidadPagado),
                            Impuesto = (x.ImpuestoPagado * x.CantidadPagado),
                            Total = (x.PrecioPagado * x.CantidadPagado) + (x.ImpuestoPagado * x.CantidadPagado),
                        }).ToList();
            }
        }

        [HttpGet]
        [Route("ContarVentas")]
        public int ContarVentas()
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return context.Factura_Encabezado.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}