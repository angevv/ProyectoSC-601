//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIProyectoSC_601
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public long ID_Cliente { get; set; }
        public string Ced_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Apellido_Cliente { get; set; }
        public string Correo_Cliente { get; set; }
        public string Contrasenna_Cliente { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Tel_Cliente { get; set; }
        public int Est_Cliente { get; set; }
        public int Rol_Cliente { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
