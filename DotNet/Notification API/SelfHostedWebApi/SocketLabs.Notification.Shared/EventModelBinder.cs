using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.ModelBinding;
using SocketLabs.Notification.Shared.Events;

namespace SocketLabs.Notification.Shared
{
    public class EventModelBinder : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var Type = bindingContext.ValueProvider.GetValue("Type");

            
            bindingContext.Model = new Complaint();
            return true;
        }
    }
}
