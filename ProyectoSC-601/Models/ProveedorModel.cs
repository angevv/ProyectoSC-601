﻿using ProyectoSC_601.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Models
{
    public class ProveedorModel
    {
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        public string RegistrarProveedor(ProveedorEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RegistrarProveedor";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }


        public List<SelectListItem> ConsultarEmpresas()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarEmpresas";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }


        public List<ProveedorEnt> ConsultaProveedores()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultaProveedores";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<ProveedorEnt>>().Result;
            }
        }



        public string ActualizarEstadoProveedor(ProveedorEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ActualizarEstadoProveedor";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PutAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }


        public string ActualizarProveedor(ProveedorEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ActualizarProveedor";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PutAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }


        public ProveedorEnt ConsultaProveedor(long q)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultaProveedor?q=" + q;
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<ProveedorEnt>().Result;
            }
        }


        public string EliminarProveedor(long idProveedor)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + $"EliminarProveedor?q={idProveedor}";
                var res = client.DeleteAsync(urlApi).Result;

                if (res.IsSuccessStatusCode)
                {
                    var respuestaJson = res.Content.ReadAsStringAsync().Result;

                    if (respuestaJson.Contains("OK"))
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Error en la respuesta del servicio.";
                    }
                }
                else
                {
                    return "Error en la solicitud al servicio.";
                }
            }
        }




    }
}