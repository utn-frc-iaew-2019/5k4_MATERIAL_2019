﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFReservaVehiculos.Business.DataBaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReservaVehiculosDataBaseEntities : DbContext
    {
        public ReservaVehiculosDataBaseEntities()
            : base("name=ReservaVehiculosDataBaseEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<VehiculoEntity> Vehiculo { get; set; }
        public virtual DbSet<ReservaEntity> Reserva { get; set; }
        public virtual DbSet<CiudadEntity> Ciudad { get; set; }
        public virtual DbSet<PaisEntity> Pais { get; set; }
        public virtual DbSet<TransaccionEntity> Transaccion { get; set; }
        public virtual DbSet<UsuarioEntity> Usuario { get; set; }
        public virtual DbSet<VehiculoPorCiudadEntity> VehiculoPorCiudad { get; set; }
    }
}
