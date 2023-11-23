using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using ProyectoSC_601.Entities;
using System.Configuration;
using System.Web.Mvc;

namespace ProyectoSC_601.Models
{
    public class InventarioModel
    {
        //Se hace referencia a la ruta del servidor configurada en Web.config
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        //Funcion para consultar todos los productos por parte del administrador
        public List<InventarioEnt> ConsultarInventario()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarInventario";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<InventarioEnt>>().Result;
            }
        }

        //Funcion para consultar las categorias
        public List<SelectListItem> ConsultarCategorias()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarCategorias";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        //Funcion para registrar el producto
        public long RegistrarProducto(InventarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RegistrarProducto";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<long>().Result;
            }
        }

        //Funcion para actualizar la ruta de la imagen del producto
        public string ActualizarRutaProducto(InventarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ActualizarRutaProducto";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PutAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }

    }
}