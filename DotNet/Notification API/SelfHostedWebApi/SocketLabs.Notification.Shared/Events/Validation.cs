using System.Collections.Generic;

namespace SocketLabs.Notification.Shared.Events
{
    public class Validation : EventBase
    {
        public Validation(IEnumerable<KeyValuePair<string, string>> formDataCollection)
            : base(formDataCollection)
        {
        }

        public Validation()
        {
            Type = "Validation";
        }
        public string SecretKey { get; set; }
        public int ServerId { get; set; }
        public string Type { get; set; }
    }
}
