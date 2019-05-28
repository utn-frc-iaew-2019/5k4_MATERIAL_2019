using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WCFReservaVehiculos.CustomBehavior
{
    public class LoggingOperationBehavior : IOperationBehavior
    {
        public void Validate(OperationDescription operationDescription)
        {
            //throw new NotImplementedException();
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new LoggingOperationInvoker(dispatchOperation.Invoker, dispatchOperation);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            //throw new NotImplementedException();
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }

        // (TODO stub implementations)
    }
}