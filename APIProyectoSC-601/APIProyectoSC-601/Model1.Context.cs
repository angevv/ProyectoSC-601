﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ImportadoraMoyaUlateEntities : DbContext
    {
        public ImportadoraMoyaUlateEntities()
            : base("name=ImportadoraMoyaUlateEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }
    
        public virtual ObjectResult<IniciarSesionSP_Result> IniciarSesionSP(string correo, string contrasenna)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IniciarSesionSP_Result>("IniciarSesionSP", correoParameter, contrasennaParameter);
        }
    
        public virtual ObjectResult<RecuperarCuentaClienteSP_Result> RecuperarCuentaClienteSP(string identificacion)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RecuperarCuentaClienteSP_Result>("RecuperarCuentaClienteSP", identificacionParameter);
        }
    
        public virtual int RegistrarClienteSP(string identificacion, string nombre, string apellido, string correo, string contrasenna, string direccion, string telefono)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarClienteSP", identificacionParameter, nombreParameter, apellidoParameter, correoParameter, contrasennaParameter, direccionParameter, telefonoParameter);
        }
    
        public virtual int RegistrarProveedorSP(string nombre_Proveedor, string apellido_Proveedor, string cedula_Proveedor, string direccion_Exacta, Nullable<int> estado_Proveedor, Nullable<long> empresa)
        {
            var nombre_ProveedorParameter = nombre_Proveedor != null ?
                new ObjectParameter("Nombre_Proveedor", nombre_Proveedor) :
                new ObjectParameter("Nombre_Proveedor", typeof(string));
    
            var apellido_ProveedorParameter = apellido_Proveedor != null ?
                new ObjectParameter("Apellido_Proveedor", apellido_Proveedor) :
                new ObjectParameter("Apellido_Proveedor", typeof(string));
    
            var cedula_ProveedorParameter = cedula_Proveedor != null ?
                new ObjectParameter("Cedula_Proveedor", cedula_Proveedor) :
                new ObjectParameter("Cedula_Proveedor", typeof(string));
    
            var direccion_ExactaParameter = direccion_Exacta != null ?
                new ObjectParameter("Direccion_Exacta", direccion_Exacta) :
                new ObjectParameter("Direccion_Exacta", typeof(string));
    
            var estado_ProveedorParameter = estado_Proveedor.HasValue ?
                new ObjectParameter("Estado_Proveedor", estado_Proveedor) :
                new ObjectParameter("Estado_Proveedor", typeof(int));
    
            var empresaParameter = empresa.HasValue ?
                new ObjectParameter("Empresa", empresa) :
                new ObjectParameter("Empresa", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarProveedorSP", nombre_ProveedorParameter, apellido_ProveedorParameter, cedula_ProveedorParameter, direccion_ExactaParameter, estado_ProveedorParameter, empresaParameter);
        }
    
        public virtual int ActualizarEstadoProveedorSP(Nullable<long> iD_Proveedor)
        {
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarEstadoProveedorSP", iD_ProveedorParameter);
        }
    
        public virtual int ActualizarProveedorSP(Nullable<long> iD_Proveedor, string nombre_Proveedor, string apellido_Proveedor, string cedula_Proveedor, string direccion_Exacta, Nullable<long> empresa)
        {
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(long));
    
            var nombre_ProveedorParameter = nombre_Proveedor != null ?
                new ObjectParameter("Nombre_Proveedor", nombre_Proveedor) :
                new ObjectParameter("Nombre_Proveedor", typeof(string));
    
            var apellido_ProveedorParameter = apellido_Proveedor != null ?
                new ObjectParameter("Apellido_Proveedor", apellido_Proveedor) :
                new ObjectParameter("Apellido_Proveedor", typeof(string));
    
            var cedula_ProveedorParameter = cedula_Proveedor != null ?
                new ObjectParameter("Cedula_Proveedor", cedula_Proveedor) :
                new ObjectParameter("Cedula_Proveedor", typeof(string));
    
            var direccion_ExactaParameter = direccion_Exacta != null ?
                new ObjectParameter("Direccion_Exacta", direccion_Exacta) :
                new ObjectParameter("Direccion_Exacta", typeof(string));
    
            var empresaParameter = empresa.HasValue ?
                new ObjectParameter("Empresa", empresa) :
                new ObjectParameter("Empresa", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarProveedorSP", iD_ProveedorParameter, nombre_ProveedorParameter, apellido_ProveedorParameter, cedula_ProveedorParameter, direccion_ExactaParameter, empresaParameter);
        }
    
        public virtual int EliminarProveedorSP(Nullable<long> iD_Proveedor)
        {
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarProveedorSP", iD_ProveedorParameter);
        }
    }
}
