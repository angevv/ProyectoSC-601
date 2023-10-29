using Newtonsoft.Json;
using ProyectoSC_601.Entities;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace ProyectoSC_601.Models
{
    public class ClienteModel
    {
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        public string RegistroCliente(ClienteEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RegistroCliente";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public ClienteEnt Login(ClienteEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "Login";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<ClienteEnt>().Result;
            }
        }

        public string RecuperarCuentaCliente(ClienteEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RecuperarCuentaCliente?Identificacion=" + entidad.Ced_Cliente;
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }
}