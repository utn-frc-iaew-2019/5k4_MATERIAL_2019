using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WCFReservaVehiculos.Business.DataBaseModel;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ConsultarVehiculosDisponiblesResponse
    {
        [DataMember]
        public DateTime TimeStamp { get; set; }

        [DataMember]
        public List<VehiculoModel> VehiculosEncontrados { get; set; }

        public ConsultarVehiculosDisponiblesResponse(DateTime timeStamp, List<VehiculoModel> resultadoConsulta)
        {
            TimeStamp = timeStamp;
            VehiculosEncontrados = resultadoConsulta;
        }

    }
}