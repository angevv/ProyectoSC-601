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

        Utilitarios util = new Utilitarios();

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
        [Route("ConsultarDatosEnviarCorreo")]
        public object ConsultarDatosEnviarCorreo(long q)
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return (from x in context.Factura_Encabezado
                        join y in context.Clientes on x.ID_Usuario equals y.ID_Cliente
                        join z in context.Factura_Detalle on x.ID_Factura equals z.ID_Factura
                        where x.ID_Usuario == q
                        select new
                        {

                            x.ID_Factura,
                            NombreCliente = y.Nombre_Cliente,
                            ApellidoCliente = y.Apellido_Cliente,
                            CorreoCliente = y.Correo_Cliente,
                            x.FechaCompra,
                            x.TotalCompra,
                            Subtotal = (x.TotalCompra / Decimal.Parse(Convert.ToString(1, 13))),
                            Impuesto = (x.TotalCompra - (x.TotalCompra / Decimal.Parse(Convert.ToString(1, 13))))
                        });
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

        [HttpPost]
        [Route("EnviarFacturaCorreo")]
        public string EnviarFacturaCorreo(FacturaEnt entidad, string correo)
        {
            try
            {

                if (entidad != null)
                {
                    string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "Templates\\FacturaCorreo.html";
                    string html = File.ReadAllText(rutaArchivo);

                    string numFactura = entidad.ID_Factura.ToString();
                    string cliente = entidad.NombreCliente + " " + entidad.ApellidoCliente;
                    string fecha = entidad.FechaCompra.ToString();
                    string subtotal = entidad.SubTotal.ToString();
                    string impuesto = entidad.Impuesto.ToString();
                    string total = entidad.Total.ToString();

                    html = html.Replace("@@factutra", numFactura);
                    html = html.Replace("@@Cliente", cliente);
                    html = html.Replace("@@Fecha", fecha);
                    html = html.Replace("@@Subtotal", subtotal);
                    html = html.Replace("@@Subtotal", impuesto);
                    html = html.Replace("@@Subtotal", total);

                    util.EnviarCorreo(correo, "Factura Electrónica", html);
                    return "OK";
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}