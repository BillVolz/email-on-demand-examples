using System;
using System.Configuration;
using System.Web.Http;
using SocketLabs.Inbound.Shared;

namespace SocketLabs.Inbound.SelfHostedWebApi.Controler
{
    public class InboundController : ApiController
    {
        private readonly string _validationKey = ConfigurationManager.AppSettings["ValidationKey"];
        private readonly string _secretKey = ConfigurationManager.AppSettings["SecretKey"];

        public string Post([FromBody] MessageEnvelope messageEnvelope)
        {
            //Make sure the request is coming from SocketLabs.
            if (messageEnvelope.SecretKey != _secretKey)
            {
                return "Invalid Key";
            }

            Console.Write(PrettyPrint.ToString(messageEnvelope));
           
            return _validationKey;
        }   
    }
}
