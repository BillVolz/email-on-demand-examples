using System;

namespace SocketLabs.Notification.Shared.Events
{
    public class Failed
    {
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public string MailingId { get; set; }
        public string MessageId { get; set; }
        public string Address { get; set; }
        public int ServerId { get; set; }
        public string SecretKey { get; set; }      
        public string BounceStatus { get; set; }
        public string FromAddress { get; set; }
        public string DiagnosticCode { get; set; }
        public int FailureCode { get; set; }
        public int FailureType { get; set; }
        public string Reason { get; set; }
        public string RemoteMta { get; set; }
        
    }
}
