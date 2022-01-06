using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OnvifStream.Enum;

namespace OnvifStream.Authentication
{
    public class PasswordDigestMessageInspector : IClientMessageInspector
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public PasswordDigestMessageInspector(String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // do nothing
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            var option = PasswordOption.SendHashed;
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                option = PasswordOption.SendPlain;

            UsernameToken token = new UsernameToken(this.Username, this.Password, option);
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement securityToken = token.GetXml(xmlDoc);
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
            XmlNamespaceManager wsumgr = new XmlNamespaceManager(xmlDoc.NameTable);
            wsumgr.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            nsMgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

            string nonce = securityToken.SelectSingleNode("//wsse:Nonce", nsMgr).InnerText;
            string pass = securityToken.SelectSingleNode("//wsse:Password", nsMgr).InnerText;
            string time = securityToken.SelectSingleNode("//wsu:Created", wsumgr).InnerText;

            XmlNodeList nonces = securityToken.SelectNodes("//wsse:Nonce", nsMgr);
            XmlAttribute encodingAttr = xmlDoc.CreateAttribute("EncodingType");
            encodingAttr.Value = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";
            if (nonces.Count > 0)
            {
                nonces[0].Attributes.Append(encodingAttr);
            }


            string headerText = "<wsse:UsernameToken xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" +
                    "<wsse:Username>" + Username + "</wsse:Username>" +
                    "<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest\">" + pass + "</wsse:Password>" +
                    "<wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">" + nonce + "</wsse:Nonce>" +
                    "<wsu:Created xmlns=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" + time + "</wsu:Created>" +
                    "</wsse:UsernameToken>";

            XmlDocument MyDoc = new XmlDocument();
            MyDoc.LoadXml(headerText);
            MessageHeader myHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", MyDoc.DocumentElement, false);
            request.Headers.Add(myHeader);
            return Convert.DBNull;
        }
    }

}
