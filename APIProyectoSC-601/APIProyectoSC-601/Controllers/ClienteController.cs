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
        //Se crea instancia para usar herramientas necesarias para enviar correo de recuperacion al cliente
        Utilitarios util = new Utilitarios();


        //Conexion a procedimiento para registrar clientes
        [HttpPost]
        [Route("RegistroCliente")]
        public string RegistroCliente(ClienteEnt entidad)
        {
            try
            {
                //Se asgina inicialmente la direccion y telefono como vacio
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

        //Conexion a procedimiento para verificar los datos del login y permitir o negar el inicio de sesion
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

        //Se comprueba si existe la cedula ingresada y se envia correo de recuperacion con nombre y contrasenna al cliente
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

        //Devuelve los datos de la entidad basados en la cedula recibida
        [HttpGet]
        [Route("ConsultaClienteEspecifico")]
        public Clientes ConsultaClienteEspecifico(long q)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.Clientes
                            where x.ID_Cliente == q
                            select x).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Conexion a procedimiento para actualizar los datos del cliente desde el perfil
        [HttpPut]
        [Route("ActualizarCuentaCliente")]
        public string ActualizarCuentaCliente(ClienteEnt entidad)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.ActualizarCuentaClienteSP(entidad.Ced_Cliente, entidad.Nombre_Cliente, entidad.Apellido_Cliente, entidad.Correo_Cliente, entidad.Direccion_Cliente, entidad.Tel_Cliente, entidad.ID_Cliente);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        //Conexion a procedimiento para inactivar al cliente
        [HttpPut]
        [Route("InactivarCliente")]
        public void InactivarCliente(ClienteEnt entidad)
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                context.InactivarClienteSP(entidad.ID_Cliente);
            }
        }

        //Devuelve todos los clientes registrados, solo rol de usuario
        [HttpGet]
        [Route("ConsultarClientesAdministrador")]
        public List<Clientes> ConsultarClientesAdministrador()
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.Clientes
                            where x.Rol_Cliente == 2 && x.Est_Cliente==1
                            select x).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
