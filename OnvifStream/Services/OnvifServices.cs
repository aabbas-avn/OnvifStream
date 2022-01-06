using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using OnvifStream.Authentication;
using OnvifStream.Device;
using OnvifStream.Media;
using OnvifStream.PTZ;

namespace OnvifStream.Services
{
    static class OnvifServices
    {
        static PTZClient ptzclient;
        static MediaClient mediaclient;
        static DeviceClient deviceclient;
        static MediaUri mediauri;
        public static PTZClient GetOnvifPTZClient(string IPAddress, string username = "", string password = "")
        {
            try
            {
                var httpTransportBinding = new HttpTransportBindingElement { AuthenticationScheme = System.Net.AuthenticationSchemes.Digest };
                var textMessageEncodingBinding = new TextMessageEncodingBindingElement { MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None) };
                var customBinding = new CustomBinding(textMessageEncodingBinding, httpTransportBinding);

                EndpointAddress PTZEndPoint = new EndpointAddress("http://" + IPAddress + "/onvif/ptz_service");
                ptzclient = new PTZClient(customBinding, PTZEndPoint);
                if (username != string.Empty && username != null)
                {
                    PasswordDigestBehavior passwordDigestBehavior = new PasswordDigestBehavior(username, password);
                    ptzclient.Endpoint.Behaviors.Add(passwordDigestBehavior);
                }
                //Method#2 for Authentication 
                //else if (username != string.Empty && username != null)
                //{
                //    ptzclient.ClientCredentials.HttpDigest.ClientCredential.UserName = username;
                //    ptzclient.ClientCredentials.HttpDigest.ClientCredential.Password = password;
                //    ptzclient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                //}
                return ptzclient;

            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: GetOnvifPTZClient()" + ex);
                return ptzclient;
            }

        }

        public static MediaClient GetOnvifMediaClient(string IPAddress, string username = "", string password = "")
        {
            try
            {
                var httpTransportBinding = new HttpTransportBindingElement { AuthenticationScheme = System.Net.AuthenticationSchemes.Digest };
                var textMessageEncodingBinding = new TextMessageEncodingBindingElement { MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None) };
                var customBinding = new CustomBinding(textMessageEncodingBinding, httpTransportBinding);

                EndpointAddress MediaEndpoint = new EndpointAddress("http://" + IPAddress + "/onvif/media_service");
                mediaclient = new MediaClient(customBinding, MediaEndpoint);
                if (username != string.Empty && username != null)
                {
                    PasswordDigestBehavior passwordDigestBehavior = new PasswordDigestBehavior(username, password);
                    mediaclient.Endpoint.Behaviors.Add(passwordDigestBehavior);
                }
                //Method#2 for Authentication
                //else if (username != string.Empty && username != null)
                //{
                //    mediaclient.ClientCredentials.HttpDigest.ClientCredential.UserName = username;
                //    mediaclient.ClientCredentials.HttpDigest.ClientCredential.Password = password;
                //    mediaclient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                //}
                return mediaclient;
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: GetOnvifMediaClient()" + ex);
                return mediaclient;
            }
        }

        public static DeviceClient GetOnvifDeviceClient(string IPAddress, string username = "", string password = "")
        {
            try
            {
                var httpTransportBinding = new HttpTransportBindingElement { AuthenticationScheme = System.Net.AuthenticationSchemes.Digest };
                var textMessageEncodingBinding = new TextMessageEncodingBindingElement { MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None) };
                var customBinding = new CustomBinding(textMessageEncodingBinding, httpTransportBinding);

                EndpointAddress DeviceEndpoint = new EndpointAddress("http://" + IPAddress + "/onvif/device_service");
                deviceclient = new DeviceClient(customBinding, DeviceEndpoint);
                if (username != string.Empty && username != null)
                {
                    PasswordDigestBehavior passwordDigestBehavior = new PasswordDigestBehavior(username, password);
                    deviceclient.Endpoint.Behaviors.Add(passwordDigestBehavior);
                }
                //Method#2 for Authentication
                //else if (username != string.Empty && username != null)
                //{
                //    deviceclient.ClientCredentials.HttpDigest.ClientCredential.UserName = username;
                //    deviceclient.ClientCredentials.HttpDigest.ClientCredential.Password = password;
                //    deviceclient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                //}
                return deviceclient;

            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: GetOnvifDeviceClientx()" + ex);
                return deviceclient;
            }
        }

        public static MediaUri GetStreamURI(MediaClient mediaclient, string token)
        {
            try
            {

                var StreamSetup = new StreamSetup()
                {
                    Stream = StreamType.RTPUnicast,
                    Transport = new Transport()
                    {
                        Protocol = TransportProtocol.UDP
                    }
                };

                mediauri = mediaclient.GetStreamUri(StreamSetup, token);
                return mediauri;
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: GetStreamURI()" + ex);
                return mediauri;
            }
        }
    }
}
