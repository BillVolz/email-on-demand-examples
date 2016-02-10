namespace SocketLabs.Inbound.Shared
{
    public class MessageEnvelope
    {
        public string SecretKey { get; set; }
        public Message Message { get; set; }
        public string InboundMailFrom { get; set; }
        public string InboundRcptTo { get; set; }
        public string InboundIpAddress { get; set; }
        public string ErrorLog { get; set; }
        public float SpamScore { get; set; }
        public string SpamDetails { get; set; }
    }
}
