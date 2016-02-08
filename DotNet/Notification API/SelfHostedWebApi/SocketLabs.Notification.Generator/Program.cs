using System;

namespace SocketLabs.Notification.Generator
{
    /// <summary>
    /// This tool will actually generate test notification messages.
    /// Use this to test your self hosted web api.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Port number must match server port number.
        /// </summary>
        private static int _portNumber = 8090;

        static void Main(string[] args)
        {
            using (var notificationClient = new Client(string.Format("http://localhost:{0}", _portNumber)))
            {
                var result = notificationClient.SendValidation();
                Console.WriteLine("SendValidation status code: {0}", result.StatusCode);
                result = notificationClient.SendComplaint();
                Console.WriteLine("SendComplaint status code: {0}", result.StatusCode);
                result = notificationClient.SendDelivered();
                Console.WriteLine("SendDelivered status code: {0}", result.StatusCode);
                result = notificationClient.SendFailed();
                Console.WriteLine("SendFailed status code: {0}", result.StatusCode);
                result = notificationClient.SendTracking();
                Console.WriteLine("SendTracking status code: {0}", result.StatusCode);
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }

        }
    }
}
