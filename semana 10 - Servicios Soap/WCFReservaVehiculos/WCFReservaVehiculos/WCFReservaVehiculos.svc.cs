using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFReservaVehiculos.Business;
using WCFReservaVehiculos.Business.Entities;
using WCFReservaVehiculos.Business.ExceptionHandling;

namespace ServicioWeb
{
    public class WCFReservaVehiculos : IWCFReservaVehiculos
    {
        public ConsultarVehiculosDisponiblesResponse ConsultarVehiculosDisponibles(ConsultarVehiculosRequest ConsultarVehiculosRequest)
        {

            try
            {
                using (var bll = new ReservaVehiculosBl())
                {

                    if (!UserHelper.ValidateUser(bll))
                    {
                        throw new CustomException(90, "Usuario desconocido o password incorrecta.");
                    }
                    return bll.ConsultarVehiculosDisponibles(ConsultarVehiculosRequest, UserHelper.GetUserName());
                }
            }
            catch (CustomException ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
            catch (Exception ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
        }

        public ReservarVehiculoResponse ReservarVehiculo(ReservarVehiculoRequest ReservarVehiculoRequest)
        {
            try
            {
                using (var bll = new ReservaVehiculosBl())
                {

                    if (!UserHelper.ValidateUser(bll))
                    {
                        throw new CustomException(90, "Usuario desconocido o password incorrecta.");
                    }
                    return bll.ReservarVehiculo(ReservarVehiculoRequest, UserHelper.GetUserName());
                }
            }
            catch (CustomException ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
            catch (Exception ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
        }

        public ConsultarReservasResponse ConsultarReserva(ConsultarReservasRequest ConsultarReservaRequest)
        {
            try
            {
                using (var bll = new ReservaVehiculosBl())
                {

                    if (!UserHelper.ValidateUser(bll))
                    {
                        throw new CustomException(90, "Usuario desconocido o password incorrecta.");
                    }
                    return bll.ConsultarReserva(ConsultarReservaRequest, UserHelper.GetUserName());
                }
            }
            catch (CustomException ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
            catch (Exception ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
        }

        public CancelarReservaResponse CancelarReserva(CancelarReservaRequest CancelarReservaRequest)
        {
            try
            {
                using (var bll = new ReservaVehiculosBl())
                {

                    if (!UserHelper.ValidateUser(bll))
                    {
                        throw new CustomException(90, "Usuario desconocido o password incorrecta.");
                    }
                    return bll.CancelarReserva(CancelarReservaRequest, UserHelper.GetUserName());
                }
            }
            catch (CustomException ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
            catch (Exception ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
        }

        public ConsultarCiudadesResponse ConsultarCiudades(ConsultarCiudadesRequest ConsultarCiudadesRequest)
        {
            try
            {
                using (var bll = new ReservaVehiculosBl())
                {

                    //if (!UserHelper.ValidateUser(bll))
                    //{
                    //    throw new CustomException(90, "Usuario desconocido o password incorrecta.");
                    //}
                    return bll.ConsultarCiudades(ConsultarCiudadesRequest, UserHelper.GetUserName());
                }
            }
            catch (CustomException ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
            catch (Exception ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
        }

        public ConsultarPaisesResponse ConsultarPaises()
        {
            try
            {
                using (var bll = new ReservaVehiculosBl())
                {

                    if (!UserHelper.ValidateUser(bll))
                    {
                        throw new CustomException(90, "Usuario desconocido o password incorrecta.");
                    }
                    return bll.ConsultarPaises(UserHelper.GetUserName());
                }
            }
            catch (CustomException ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
            catch (Exception ex)
            {
                throw new FaultException<StatusResponse>(new StatusResponse(ex));
            }
        }
    }
}
