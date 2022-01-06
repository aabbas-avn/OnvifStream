using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace OnvifStream.Authentication
{

        public class PasswordDigestBehavior : IEndpointBehavior
        {
            public String Username { get; set; }
            public String Password { get; set; }


            public PasswordDigestBehavior(String username, String password)
            {
                this.Username = username;
                this.Password = password;
            }


            public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
                // do nothing
            }

            public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
            {
                //clientRuntime.MessageInspectors.Add(new PasswordDigestMessageInspector(this.Username, this.Password));
                clientRuntime.MessageInspectors.Add(new PasswordDigestMessageInspector(this.Username, this.Password));
            }

            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
            {
                throw new NotImplementedException();
            }

            public void Validate(ServiceEndpoint endpoint)
            {
                // do nothing...
            }
        }
    
}
