using System;

namespace SocketLabs.Inbound.Generator
{
    /// <summary>
    /// This tool will actually generate test inbound messages.
    /// Use this to test your self hosted web api.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Port number must match server port number.
        /// </summary>
        private static int _portNumber = 8099;

        static void Main(string[] args)
        {
            using (var inboundClient = new Client(string.Format("http://localhost:{0}", _portNumber)))
            {
                var result = inboundClient.SendSampleMessage();
                Console.WriteLine("SendValidation status code: {0}", result.StatusCode);
                
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }

        }
    }
}
