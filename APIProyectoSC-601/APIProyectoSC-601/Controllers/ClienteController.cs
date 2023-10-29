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
    public class ClienteController : ApiController
    {
        Utilitarios util = new Utilitarios();

        [HttpPost]
        [Route("RegistroCliente")]
        public string RegistroCliente(ClienteEnt entidad)
        {
            try
            {
                entidad.Direccion_Cliente = string.Empty;
                entidad.Tel_Cliente = string.Empty;
                using (var context = new ImportadoraMoyaUlateEntities())
                {

                    context.RegistrarClienteSP(entidad.Ced_Cliente, entidad.Nombre_Cliente, entidad.Apellido_Cliente, entidad.Correo_Cliente, entidad.Contrasenna_Cliente, entidad.Direccion_Cliente, entidad.Tel_Cliente);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpPost]
        [Route("Login")]
        public IniciarSesionSP_Result Login(ClienteEnt entidad)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    return context.IniciarSesionSP(entidad.Correo_Cliente, entidad.Contrasenna_Cliente).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("RecuperarCuentaCliente")]
        public string RecuperarCuentaCliente(string Identificacion)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    var datos = context.RecuperarCuentaClienteSP(Identificacion).FirstOrDefault();

                    if (datos != null)
                    {
                        string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "Templates\\Contrasenna.html";
                        string html = File.ReadAllText(rutaArchivo);

                        html = html.Replace("@@Nombre", datos.Nombre_Cliente + " "+datos.Apellido_Cliente);
                        html = html.Replace("@@Contrasenna", datos.Contrasenna_Cliente);

                        util.EnviarCorreo(datos.Correo_Cliente, "Contraseña de Acceso", html);
                        return "OK";
                    }
                    else
                    {
                        return string.Empty;
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
