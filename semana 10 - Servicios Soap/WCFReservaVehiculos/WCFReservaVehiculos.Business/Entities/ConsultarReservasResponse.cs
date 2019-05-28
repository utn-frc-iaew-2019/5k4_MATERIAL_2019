using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WCFReservaVehiculos.Business.DataBaseModel;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ConsultarReservasResponse
    {
        [DataMember]
        public DateTime TimeStamp { get; set; }

        [DataMember]
        public ReservaEntity Reserva { get; set; }

        public ConsultarReservasResponse(DateTime timeStamp, ReservaEntity reserva)
        {
            TimeStamp = timeStamp;
            Reserva = reserva;
        }
    }
}