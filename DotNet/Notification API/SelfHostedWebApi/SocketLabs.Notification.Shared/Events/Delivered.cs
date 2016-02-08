using System;
using System.Collections.Generic;

namespace SocketLabs.Notification.Shared.Events
{
    public class Delivered : EventBase
    {
        public Delivered(IEnumerable<KeyValuePair<string, string>> formDataCollection)
            : base(formDataCollection)
        {
        }

        public Delivered()
        {
            Type = "Delivered";
        }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public string MailingId { get; set; }
        public string MessageId { get; set; }
        public string Address { get; set; }
        public int ServerId { get; set; }
        public string SecretKey { get; set; }
        public string RemoteMta { get; set; }
        public string Response { get; set; }
        public string LocalIp { get; set; }
    }
}
