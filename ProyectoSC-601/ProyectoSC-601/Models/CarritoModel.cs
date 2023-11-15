using Newtonsoft.Json;
using ProyectoSC_601.Entities;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace ProyectoSC_601.Models
{
    public class CarritoModel
    {
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        public string RegistroCliente(ClienteEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "carrito";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }

    }
}