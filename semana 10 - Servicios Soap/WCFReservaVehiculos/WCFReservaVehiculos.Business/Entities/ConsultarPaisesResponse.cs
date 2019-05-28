using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WCFReservaVehiculos.Business.DataBaseModel;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ConsultarPaisesResponse
    {
        public ConsultarPaisesResponse(DateTime timeStamp, List<PaisEntity> paises)
        {
            TimeStamp = timeStamp;
            Paises = paises;
        }

        [DataMember]
        public DateTime TimeStamp { get; set; }

        [DataMember]
        public List<PaisEntity> Paises { get; set; }
    }
}