using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.SelfHost;
using SocketLabs.Notification.Shared;
using SocketLabs.Notification.Shared.Events;

namespace SocketLabs.Notification.SelfHostedWebApi
{
    /* 
     * (Optional) Add an HTTP URL Namespace Reservation

        This application listens to http://localhost:8090/. By default, listening at a particular HTTP address requires administrator privileges. 
        When you run the tutorial, therefore, you may get this error: "HTTP could not register URL http://+:8080/" There are two ways to avoid this error:

        Run Visual Studio with elevated administrator permissions, or
        Use Netsh.exe to give your account permissions to reserve the URL.
        To use Netsh.exe, open a command prompt with administrator privileges and enter the following command:following command:

        netsh http add urlacl url=http://+:8090/ user=machine\username
        where machine\username is your user account.

        When you are finished self-hosting, be sure to delete the reservation:

        netsh http delete urlacl url=http://+:8090/
     *
     */
    class Program
    {
        /// <summary>
        /// Port number must match client.  This can be any open port.
        /// </summary>
        private static int PortNumber = 8090;

        static void Main(string[] args)
        {
            //Create the configuration object.
            var config = new HttpSelfHostConfiguration(
                string.Format("http://localhost:{0}", PortNumber));
           
            //Map routes.  Controlers are in \Controler directory
            //Single EmailEventsController for this project.
            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/",
                new { controller = "EmailEvent"});

            //Start the server
            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
