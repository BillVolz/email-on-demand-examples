using System;

namespace SocketLabs.Notification.Shared.Events
{
    public class Delivered
    {
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
