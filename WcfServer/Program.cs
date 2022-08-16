using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(WcfServiceLibrary.Lab3Service), new Uri($"http://{Config.Default.Host}:{Config.Default.Port}/{Config.Default.Name}"));
            host.Description.Behaviors.Add(new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
            });
            host.AddServiceEndpoint(typeof(WcfServiceLibrary.ILab3Service), new BasicHttpBinding(), "basic");
            host.Open();
            Console.WriteLine("Server is running...");
            Console.ReadLine();
        }
    }
}
