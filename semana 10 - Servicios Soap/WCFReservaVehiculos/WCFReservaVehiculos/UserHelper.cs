using System.ServiceModel;
using System.ServiceModel.Security;
using WCFExtrasPlus.Soap;
using WCFReservaVehiculos.Business;

namespace ServicioWeb
{
    public class UserHelper
    {
        public static string GetUserName()
        {

            CredentialsHeader soapHeader = SoapHeaderHelper<CredentialsHeader>.GetInputHeader("Credentials");
            if (soapHeader != null)
            {
                return soapHeader.UserName;    
            }
            return "TEST";
        }

        public static bool ValidateUser(ReservaVehiculosBl bll)
        {

            CredentialsHeader soapHeader = SoapHeaderHelper<CredentialsHeader>.GetInputHeader("Credentials");

            return soapHeader != null && bll.ValidarUsuario(soapHeader.UserName, soapHeader.Password);
        }
    }
}