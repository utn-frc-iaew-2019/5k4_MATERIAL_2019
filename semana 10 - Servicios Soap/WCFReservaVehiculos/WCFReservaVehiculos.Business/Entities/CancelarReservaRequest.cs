using System.Runtime.Serialization;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class CancelarReservaRequest
    {
        [DataMember]
        public string CodigoReserva { get; set; }
    }
}