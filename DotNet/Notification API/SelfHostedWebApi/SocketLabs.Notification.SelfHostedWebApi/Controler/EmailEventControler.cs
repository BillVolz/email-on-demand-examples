using System.Configuration;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using SocketLabs.Notification.Shared;
using SocketLabs.Notification.Shared.Events;

namespace SocketLabs.Notification.SelfHostedWebApi.Controler
{
    public class EmailEventController : ApiController
    {
        private readonly string _validationKey = ConfigurationManager.AppSettings["ValidationKey"];
        
        public string Index(Complaint model)
        {
            return "";
        }
      
        public string Index(Delivered model)    
        {
            return "";
        }
        public string Index(Failed model)
        {
            return "";
        }
        public string Index(Tracking model)
        {
            return "";
        }
        public string Index(Validation model)
        {
            return _validationKey;
        }
         
    }
}
