using System.Runtime.Serialization;

namespace WCFReservaVehiculos.Business.Entities
{
    [DataContract]
    public class ConsultarCiudadesRequest
    {
         [DataMember]
        public int IdPais { get; set; }
    }
}