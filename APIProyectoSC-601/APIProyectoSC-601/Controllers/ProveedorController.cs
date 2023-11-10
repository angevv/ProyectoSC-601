﻿using APIProyectoSC_601.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProyectoSC_601.Controllers
{
    public class ProveedorController : ApiController
    {
        //En este metodo post se van a hacer todos los registros de proveedor
        [HttpPost]
        [Route("RegistrarProveedor")]
        public string RegistrarProveedor(ProveedorEnt entidad)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {

                    context.RegistrarProveedorSP(entidad.Nombre_Proveedor,entidad.Apellido_Proveedor,entidad.Cedula_Proveedor,entidad.Direccion_Exacta,entidad.Estado_Proveedor,entidad.Empresa);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        [HttpGet]
        [Route("ConsultarEmpresas")]
        public List<System.Web.Mvc.SelectListItem> ConsultarEmpresas()
        {
            using (var contexto = new ImportadoraMoyaUlateEntities())
            {
                var datos = (from x in contexto.Empresa
                             select x).ToList();

                var combo = new List<System.Web.Mvc.SelectListItem>();
                foreach (var item in datos)
                {
                    combo.Add(new System.Web.Mvc.SelectListItem
                    {
                        Value = item.ID_Empresa.ToString(),
                        Text = item.Nombre_empresa
                    });
                }

                return combo;
            }
        }



        [HttpGet]
        [Route("ConsultaProveedores")]
        public List<Proveedores> ConsultaProveedores()
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.Proveedores
                            select x).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Proveedores>();
            }
        }

        [HttpGet]
        [Route("ConsultaProveedor")]
        public Proveedores ConsultaProveedor(long q)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.Proveedores
                            where x.ID_Proveedor == q
                            select x).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpPut]
        [Route("ActualizarEstadoProveedor")]
        public string ActualizarEstadoProveedor(ProveedorEnt entidad)
        {
            using (var context = new ImportadoraMoyaUlateEntities())
            {
                context.ActualizarEstadoProveedorSP(entidad.ID_Proveedor);
                return "OK";
            }
        }


        [HttpPut]
        [Route("ActualizarProveedor")]
        public string ActualizarProveedor(ProveedorEnt entidad)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    context.ActualizarProveedorSP(entidad.ID_Proveedor,entidad.Nombre_Proveedor,entidad.Apellido_Proveedor,entidad.Cedula_Proveedor,entidad.Direccion_Exacta,entidad.Empresa);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }



        [HttpDelete]
        [Route("EliminarProveedor")]
        public string EliminarProveedor(long q)
        {
            try
            {
                using (var context = new ImportadoraMoyaUlateEntities())
                {
                    var proveedorAEliminar = context.Proveedores.FirstOrDefault(p => p.ID_Proveedor == q);

                    if (proveedorAEliminar != null)
                    {
                        context.Proveedores.Remove(proveedorAEliminar);
                        context.SaveChanges();
                        return "OK";
                    }
                    else
                    {
                        return "Proveedor no encontrado.";
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