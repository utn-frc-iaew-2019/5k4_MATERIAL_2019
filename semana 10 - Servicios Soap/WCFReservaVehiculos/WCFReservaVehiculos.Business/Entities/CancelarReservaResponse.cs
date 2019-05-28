using System;
using System.Runtime.Serialization;
using WCFReservaVehiculos.Business.DataBaseModel;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class CancelarReservaResponse
    {

        [DataMember]
        public DateTime TimeStamp { get; set; }

        [DataMember]
        public ReservaEntity Reserva { get; set; }

        public CancelarReservaResponse(DateTime timeStamp, ReservaEntity reserva)
        {
            TimeStamp = timeStamp;
            Reserva = reserva;
        }
    }
}