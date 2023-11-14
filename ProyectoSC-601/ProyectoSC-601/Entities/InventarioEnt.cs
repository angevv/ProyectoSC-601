using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSC_601.Entities
{
    public class InventarioEnt
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}