using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFExtrasPlus.Soap;
using WCFReservaVehiculos.Business.Entities;
using WCFReservaVehiculos.Business.ExceptionHandling;
using WCFReservaVehiculos.CustomBehavior;

namespace ServicioWeb
{
    [SoapHeaders]
    [ServiceContract]

    public interface IWCFReservaVehiculos
    {

        [OperationContract]
        [FaultContract(typeof(StatusResponse))]
        [SoapHeader("Credentials", typeof(CredentialsHeader), Direction = SoapHeaderDirection.In)]
        ConsultarCiudadesResponse ConsultarCiudades(ConsultarCiudadesRequest ConsultarCiudadesRequest);

        [OperationContract]
        [FaultContract(typeof(StatusResponse))]
        [SoapHeader("Credentials", typeof(CredentialsHeader), Direction = SoapHeaderDirection.In)]
        ConsultarVehiculosDisponiblesResponse ConsultarVehiculosDisponibles(ConsultarVehiculosRequest ConsultarVehiculosRequest);

        [OperationContract]
        [FaultContract(typeof(StatusResponse))]
        [SoapHeader("Credentials", typeof(CredentialsHeader), Direction = SoapHeaderDirection.In)]
        ReservarVehiculoResponse ReservarVehiculo(ReservarVehiculoRequest ReservarVehiculoRequest);


        [OperationContract]
        [FaultContract(typeof(StatusResponse))]
        [SoapHeader("Credentials", typeof(CredentialsHeader), Direction = SoapHeaderDirection.In)]
        ConsultarReservasResponse ConsultarReserva(ConsultarReservasRequest ConsultarReservaRequest);


        [OperationContract]
        [FaultContract(typeof(StatusResponse))]
        [SoapHeader("Credentials", typeof(CredentialsHeader), Direction = SoapHeaderDirection.In)]
        CancelarReservaResponse CancelarReserva(CancelarReservaRequest CancelarReservaRequest);

        [OperationContract]
        [FaultContract(typeof(StatusResponse))]
        [SoapHeader("Credentials", typeof(CredentialsHeader), Direction = SoapHeaderDirection.In)]
        ConsultarPaisesResponse ConsultarPaises();

    }

    [DataContract(Name = "Credentials")]
    public class CredentialsHeader
    {
        [DataMember(Order = 1, IsRequired = true)]
        public string UserName { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        public string Password { get; set; }
    }
}
