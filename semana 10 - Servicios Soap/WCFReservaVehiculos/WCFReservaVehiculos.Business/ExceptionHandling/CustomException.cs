using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFReservaVehiculos.Business.ExceptionHandling
{
    public class CustomException : Exception
    {
        private readonly int _errorCode;

        public int ErrorCode
        {
            get { return _errorCode; }
        }

        public CustomException(int errorCode, string message, Exception innerException = null)
            : base(message, innerException)
        {
            _errorCode = errorCode;
        }

    }
}
