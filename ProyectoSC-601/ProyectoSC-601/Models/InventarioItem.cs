using ProyectoSC_601.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace ProyectoSC_601.Models
{
    public class InventarioModel
    {
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        public string RegistrarInventario(InventarioEnt entidad)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlApi = rutaServidor + "RegistrarInventario";
                    var jsonData = JsonContent.Create(entidad);
                    var res = client.PostAsync(urlApi, jsonData).Result;
                    return res.Content.ReadFromJsonAsync<string>().Result;
                }
            }
            catch (Exception ex)
            {
                return "Error al intentar comunicarse con el servidor: " + ex.Message;
            }
        }

        public List<InventarioEnt> ConsultaInventario()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlApi = rutaServidor + "ConsultaInventario";
                    var res = client.GetAsync(urlApi).Result;
                    return res.Content.ReadFromJsonAsync<List<InventarioEnt>>().Result;
                }
            }
            catch (Exception)
            {
                return new List<InventarioEnt>();
            }
        }

        public string ActualizarEstadoInventario(InventarioEnt entidad)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlApi = rutaServidor + "ActualizarEstadoInventario";
                    var jsonData = JsonContent.Create(entidad);
                    var res = client.PutAsync(urlApi, jsonData).Result;
                    return res.Content.ReadFromJsonAsync<string>().Result;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string ActualizarInventario(InventarioEnt entidad)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlApi = rutaServidor + "ActualizarInventario";
                    var jsonData = JsonContent.Create(entidad);
                    var res = client.PutAsync(urlApi, jsonData).Result;
                    return res.Content.ReadFromJsonAsync<string>().Result;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public InventarioEnt ConsultaInventario(int q)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlApi = rutaServidor + "ConsultaInventario?q=" + q;
                    var res = client.GetAsync(urlApi).Result;
                    return res.Content.ReadFromJsonAsync<InventarioEnt>().Result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string EliminarInventario(int idInventario)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlApi = rutaServidor + $"EliminarInventario?q={idInventario}";
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
            catch (Exception)
            {
                return "Error en la ejecución del servicio.";
            }
        }
    }
}
