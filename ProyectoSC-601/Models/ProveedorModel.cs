using ProyectoSC_601.Entities;
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
    }
}