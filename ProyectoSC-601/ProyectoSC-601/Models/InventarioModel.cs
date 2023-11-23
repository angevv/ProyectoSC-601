using Newtonsoft.Json;
using ProyectoSC_601.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Models
{
    public class InventarioModel
    {
        //Se hace referencia a la ruta del servidor configurada en Web.config
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        //Funcion para consultar todos los clientes por parte del administrador
        public List<InventarioEnt> ConsultarInventario()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarInventario";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<InventarioEnt>>().Result;
            }
        }

    }
}