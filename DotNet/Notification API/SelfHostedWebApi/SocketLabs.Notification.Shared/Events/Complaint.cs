using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SocketLabs.Notification.Shared.Events
{
    public class Complaint : EventBase
    {
        public Complaint(IEnumerable<KeyValuePair<string, string>> formDataCollection):base (formDataCollection)
        {
        }

        public Complaint()
        {
            Type = "Complaint";
        }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public string MailingId { get; set; }
        public string MessageId { get; set; }
        public string Address { get; set; }
        public int ServerId { get; set; }
        public string SecretKey { get; set; }
        public string UserAgent { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Length { get; set; }
    }
}
