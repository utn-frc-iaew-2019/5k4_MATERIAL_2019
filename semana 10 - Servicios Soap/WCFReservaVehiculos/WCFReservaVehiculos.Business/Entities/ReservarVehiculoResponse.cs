using System;
using System.Data.Entity;
using System.Runtime.Serialization;
using WCFReservaVehiculos.Business.DataBaseModel;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ReservarVehiculoResponse
    {
        [DataMember]
        public DateTime TimeStamp { get; set; }
        
        [DataMember]
        public ReservaEntity Reserva { get; set; }

        public ReservarVehiculoResponse(DateTime timeStamp, ReservaEntity reserva)
        {
            TimeStamp = timeStamp;
            Reserva = reserva;
        }
    }
}