using System;
using System.Runtime.Serialization;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ConsultarVehiculosRequest
    {
        [DataMember(Order = 1)]
        public int IdCiudad { get; set; }

        [DataMember(Order = 2)]
        public DateTime FechaHoraRetiro { get; set; }

        [DataMember(Order = 3)]
        public DateTime FechaHoraDevolucion { get; set; }
        
        public ConsultarVehiculosRequest(int idCiudad, DateTime fechaHoraRetiro, DateTime fechaHoraDevolucion)
        {
            IdCiudad = idCiudad;
            FechaHoraRetiro = fechaHoraRetiro;
            FechaHoraDevolucion = fechaHoraDevolucion;
        }
    }
}