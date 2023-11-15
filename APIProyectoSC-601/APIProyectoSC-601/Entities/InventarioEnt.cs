using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProyectoSC_601.Entities
{
    public class InventarioEnt
    {
        public int ID_Inventario { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}