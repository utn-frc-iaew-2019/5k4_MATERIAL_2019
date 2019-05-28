using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFReservaVehiculos.Business.ExceptionHandling
{
    public class StatusResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string InnerExceptionDescription { get; set; }

        public StatusResponse()
        {

        }

        public StatusResponse(int errorCode, string errorDescription, string innerExceptionDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            InnerExceptionDescription = innerExceptionDescription;
        }

        public StatusResponse(Exception ex)
        {
            ErrorDescription = ex.Message;
            if (ex.InnerException != null)
                InnerExceptionDescription = ex.InnerException.Message;

            var exception = ex as CustomException;
            ErrorCode = exception != null ? exception.ErrorCode : 99;
        }
    }
}