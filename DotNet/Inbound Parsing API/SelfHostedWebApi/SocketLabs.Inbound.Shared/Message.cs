namespace SocketLabs.Inbound.Shared
{
    public class Message
    {
        public string TextCharSet { get; set; }
        public string HtmlCharSet { get; set; }
        public Attachment[] EmbeddedMedia { get; set; }
        public string MailingId { get; set; }
        public string MessageId { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public CustomHeader[] CustomHeaders { get; set; }
        public Address[] To { get; set; }
        public Address[] Cc { get; set; }
        public Address[] Bcc { get; set; }
        public Address From { get; set; }
        public Address ReplyTo { get; set; }
        public Attachment[] Attachments { get; set; }
    }
}
