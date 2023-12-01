using ProyectoSC_601.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Configuration;

namespace ProyectoSC_601.Models
{
    public class ProductoModel
    {
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];
        public long RegistrarProducto(ProductoEnt entidad)
        {

            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RegistrarProducto";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<long>().Result;
            }

        }
        public List<ProductoEnt> ConsultarProductos()
        {

            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarProductos";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }


        public string ActualizarRutaProducto(ProductoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ActualizarRutaProducto";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;

            }
        }
    }
 }



