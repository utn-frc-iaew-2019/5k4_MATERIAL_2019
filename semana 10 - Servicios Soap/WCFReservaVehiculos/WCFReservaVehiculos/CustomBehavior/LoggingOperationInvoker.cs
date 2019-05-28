using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Web;
using ServicioWeb;
using WCFExtrasPlus.Soap;

namespace WCFReservaVehiculos.CustomBehavior
{
    public class LoggingOperationInvoker : IOperationInvoker
    {
        IOperationInvoker _baseInvoker;
        string _operationName;

        public LoggingOperationInvoker(IOperationInvoker baseInvoker, DispatchOperation operation)
        {
            _baseInvoker = baseInvoker;
            _operationName = operation.Name;
        }

        // (TODO stub implementations)

        public object[] AllocateInputs()
        {
            return null;
            //throw new NotImplementedException();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            CredentialsHeader soapHeader = SoapHeaderHelper<CredentialsHeader>.GetInputHeader("Credentials");
            string value = soapHeader.UserName; 
            try
            {
                return _baseInvoker.Invoke(instance, inputs, out outputs);
            }
            catch (Exception ex)
            {
                
                outputs =  null;
            }

            return null;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return null;
            //throw new NotImplementedException();
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            outputs = null;
            return null;
        }

        public bool IsSynchronous { get; private set; }
    }
}