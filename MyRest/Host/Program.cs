using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(MyRest.RestService),
                new Uri("http://localhost:8080"));

            ServiceEndpoint ep = host.AddServiceEndpoint(
                typeof(MyRest.IRestService), new WebHttpBinding(), "");

            host.Description.Endpoints[0].Behaviors.Add(
                new WebHttpBehavior { HelpEnabled = true });

            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();

            sdb.IncludeExceptionDetailInFaults = true;
            //sdb.HttpsHelpPageEnabled = true;

            host.Open();
            Console.WriteLine("Service is running");
            Console.ReadLine();
            host.Close();
        }
    }
}
