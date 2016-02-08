using System;
using System.Collections.Generic;

namespace SocketLabs.Notification.Shared.Events
{
    public class Tracking : EventBase
    {
        public Tracking(IEnumerable<KeyValuePair<string, string>> formDataCollection)
            : base(formDataCollection)
        {
        }

        public Tracking()
        {
            Type = "Tracking";
        }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public string MailingId { get; set; }
        public string MessageId { get; set; }
        public string Address { get; set; }
        public int ServerId { get; set; }
        public string SecretKey { get; set; }
        public string ClientIp { get; set; }
        public int TrackingType { get; set; }
        public string Url { get; set; }
        public string UserAgent { get; set; }
    }
}
