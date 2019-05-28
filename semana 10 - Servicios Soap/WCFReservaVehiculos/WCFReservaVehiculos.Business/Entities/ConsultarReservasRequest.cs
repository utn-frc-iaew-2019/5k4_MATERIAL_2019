using System.Runtime.Serialization;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ConsultarReservasRequest
    {
        [DataMember]
        public string CodigoReserva { get; set; }
    }
}