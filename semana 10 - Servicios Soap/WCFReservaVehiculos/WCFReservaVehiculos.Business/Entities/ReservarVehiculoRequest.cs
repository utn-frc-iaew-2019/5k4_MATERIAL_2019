using System;
using System.Runtime.Serialization;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ReservarVehiculoRequest
    {
        [DataMember]
        public int IdVehiculoCiudad { get; set; }

        [DataMember]
        public DateTime FechaHoraRetiro { get; set; }

        [DataMember]
        public DateTime FechaHoraDevolucion { get; set; }

        [DataMember]
        public string ApellidoNombreCliente { get; set; }

        [DataMember]
        public string NroDocumentoCliente { get; set; }

        [DataMember]
        public LugarRetiroDevolucion LugarRetiro { get; set; }

        [DataMember]
        public LugarRetiroDevolucion LugarDevolucion { get; set; }

        public ReservarVehiculoRequest(int idVehiculoCiudad, DateTime fechaHoraRetiro, DateTime fechaHoraDevolucion)
        {
            IdVehiculoCiudad = idVehiculoCiudad;
            FechaHoraRetiro = fechaHoraRetiro;
            FechaHoraDevolucion = fechaHoraDevolucion;
        }

        public override string ToString()
        {
            return string.Format("IdVehiculoCiudad: {0}, FechaHoraRetiro: {1}, FechaHoraDevolucion: {2}, ApellidoNombreCliente: {3}, NroDocumentoCliente: {4}, LugarRetiro: {5}, LugarDevolucion: {6}", IdVehiculoCiudad, FechaHoraRetiro, FechaHoraDevolucion, ApellidoNombreCliente, NroDocumentoCliente, LugarRetiro, LugarDevolucion);
        }
    }

    public enum LugarRetiroDevolucion
    {
        Aeropuerto,
        TerminalBuses,
        Hotel
    }
}