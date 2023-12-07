using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using WebKN.Entities;

namespace WebKN.Models
{
  public class CarritoModel
  {

    public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        public string RegistrarCarrito(CarritoEnt entidad)
        {
            using (var client = new HttpClient())
            {
              var urlApi = rutaServidor + "RegistrarCarrito";
              var jsonData = JsonContent.Create(entidad);
              var res = client.PostAsync(urlApi, jsonData).Result;
              return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<CarritoEnt> ConsultarCarrito(long q)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarCarrito?q=" + q;
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<CarritoEnt>>().Result;
            }
        }

        public int PagarCarrito(CarritoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "PagarCarrito";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<int>().Result;
            }
        }
        
    }
}