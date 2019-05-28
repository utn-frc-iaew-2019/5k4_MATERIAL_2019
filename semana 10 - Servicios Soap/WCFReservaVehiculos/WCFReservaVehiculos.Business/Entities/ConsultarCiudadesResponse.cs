using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WCFReservaVehiculos.Business.DataBaseModel;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ConsultarCiudadesResponse
    {
        public ConsultarCiudadesResponse(DateTime timeStamp, List<CiudadEntity> ciudades)
        {
            TimeStamp = timeStamp;
            Ciudades = ciudades;
        }

         [DataMember]
        public List<CiudadEntity> Ciudades { get; set; }

         [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}