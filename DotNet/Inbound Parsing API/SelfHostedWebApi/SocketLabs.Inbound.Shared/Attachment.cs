namespace SocketLabs.Inbound.Shared
{
    public class Attachment
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public CustomHeader[] CustomHeaders { get; set; }
        public string ContentId { get; set; }
    }
}
