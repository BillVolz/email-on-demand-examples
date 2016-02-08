using System;
using System.Net.Http;
using SocketLabs.Notification.Shared.Events;

namespace SocketLabs.Notification.Generator
{
    class Client : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        private const int ServerId = 1000;
        private const string SecretKey = "BLABLABLA";

        public Client(string baseUri)
        {
            _client.BaseAddress = new Uri(baseUri);
            
        }
        public HttpResponseMessage SendComplaint(string messageId = "1111", string mailingId = "1111", string address="test@example.com")
        {
            var complaint = new Complaint
            {
                DateTime = DateTime.Now,
                MailingId = mailingId,
                MessageId = messageId,
                Address = address,
                ServerId = ServerId,
                SecretKey = SecretKey,
                Length = 1000,
                From = "angrysender@example.com",
                To = "complaints@example.com",
                UserAgent = "Complaint Processor (example.com)"
            };
            return _client.PostAsJsonAsync<Complaint>("/api/EmailEvent/", complaint).Result;
         
        }
        public HttpResponseMessage SendDelivered(string messageId = "1111", string mailingId = "1111", string address = "test@example.com")
        {
            var delivered = new Delivered()
            {
                DateTime = DateTime.Now,
                MailingId = mailingId,
                MessageId = messageId,
                Address = address,
                ServerId = ServerId,
                SecretKey = SecretKey,
                RemoteMta = "mx1.example.com",
                Response = "250 2.6.0 Message received and queued.",
                LocalIp = "127.0.0.1"
            };
            return _client.PostAsJsonAsync<Delivered>("/api/EmailEvent/", delivered).Result;

        }
        public HttpResponseMessage SendFailed(string messageId = "1111", string mailingId = "1111", string address = "test@example.com")
        {
            var failed = new Failed()
            {
                DateTime = DateTime.Now,
                MailingId = mailingId,
                MessageId = messageId,
                Address = address,
                ServerId = ServerId,
                SecretKey = SecretKey,
                BounceStatus = "5.0.0",
                FromAddress = "sender@example.com",
                DiagnosticCode = "smtp;550 Requested action not taken: mailbox unavailable",
                FailureCode = 2001,
                FailureType = 0,
                Reason = "550 Requested action not taken: mailbox unavailable",
                RemoteMta = "mx1.example.com"
            };
            return _client.PostAsJsonAsync<Failed>("/api/EmailEvent/", failed).Result;

        }
        public HttpResponseMessage SendTracking(string messageId = "1111", string mailingId = "1111", string address = "test@example.com")
        {
            var tracking = new Tracking()
            {
                DateTime = DateTime.Now,
                MailingId = mailingId,
                MessageId = messageId,
                Address = address,
                ServerId = ServerId,
                SecretKey = SecretKey,
                ClientIp = "127.0.01",
                TrackingType = 0,
                Url = "http://www.socketlabs.com",
                UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.110 Safari/537.36"
            };
            return _client.PostAsJsonAsync<Tracking>("/api/EmailEvent/", tracking).Result;

        }

        public HttpResponseMessage SendValidation(string messageId = "1111", string mailingId = "1111", string address = "test@example.com")
        {
            var validation = new Validation()
            {
                ServerId = ServerId,
                SecretKey = SecretKey
            };
            return _client.PostAsJsonAsync<Validation>("/api/EmailEvent/", validation).Result;

        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
