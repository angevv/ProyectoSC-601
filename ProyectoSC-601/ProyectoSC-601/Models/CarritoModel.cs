﻿using Newtonsoft.Json;
using ProyectoSC_601.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSC_601.Models
{
    public class CarritoModel
  {
            public long Carrito { get; set; }
            public long ID_Cliente { get; set; }
            public long ID_Producto { get; set; }
            public int Cantidad { get; set; }
            public DateTime FechaCarrito { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public decimal SubTotal { get; set; }
            public decimal Impuesto { get; set; }
            public decimal Total { get; set; }
        }

    }
