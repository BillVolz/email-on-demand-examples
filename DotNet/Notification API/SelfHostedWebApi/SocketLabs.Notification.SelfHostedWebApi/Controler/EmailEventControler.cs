using System;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Http;
using SocketLabs.Notification.Shared.Events;

namespace SocketLabs.Notification.SelfHostedWebApi.Controler
{
    public class EmailEventController : ApiController
    {
        private readonly string _validationKey = ConfigurationManager.AppSettings["ValidationKey"];

        private void OnComplaint(Complaint model)
        {
           Console.WriteLine(model.ToString());
        }
        private void OnDelivered(Delivered model)
        {
            Console.WriteLine(model.ToString());
        }
        private void OnFailed(Failed model)
        {
            Console.WriteLine(model.ToString());
        }
        private void OnTracking(Tracking model)
        {
            Console.WriteLine(model.ToString());
        }
        private void OnValidation(Validation model)
        {
            Console.WriteLine(model.ToString());
        }

#region FormDataToModelCode
        public string Post([FromBody] FormDataCollection formDataCollection)
        {
            
            if (formDataCollection != null)
            {
                var type = formDataCollection.Get("Type");
                switch (type)
                {
                    case "Complaint":
                         OnComplaint(new Complaint(formDataCollection));
                        break;
                    case "Delivered":
                        OnDelivered(new Delivered(formDataCollection));
                        break;
                    case "Failed":
                        OnFailed(new Failed(formDataCollection));
                        break;
                    case "Tracking":
                        OnTracking(new Tracking(formDataCollection));
                        break;
                    case "Validation":
                        OnValidation(new Validation(formDataCollection));
                        break;
                }
                
            }
            return _validationKey;
        }
#endregion   
    }
}
