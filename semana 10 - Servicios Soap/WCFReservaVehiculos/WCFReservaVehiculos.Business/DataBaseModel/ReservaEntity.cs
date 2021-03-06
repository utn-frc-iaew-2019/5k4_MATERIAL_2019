//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ReservaEntity
    {
        public int Id { get; set; }
        public string CodigoReserva { get; set; }
        public System.DateTime FechaReserva { get; set; }
        public string UsuarioReserva { get; set; }
        public decimal TotalReserva { get; set; }
        public string ApellidoNombreCliente { get; set; }
        public string NroDocumentoCliente { get; set; }
        public string LugarRetiro { get; set; }
        public string LugarDevolucion { get; set; }
        public System.DateTime FechaHoraRetiro { get; set; }
        public System.DateTime FechaHoraDevolucion { get; set; }
        public EstadoReservaEnum Estado { get; set; }
        public Nullable<System.DateTime> FechaCancelacion { get; set; }
        public string UsuarioCancelacion { get; set; }
        public int VehiculoPorCiudadId { get; set; }
    
        public virtual VehiculoPorCiudadEntity VehiculoPorCiudadEntity { get; set; }
    }
}
