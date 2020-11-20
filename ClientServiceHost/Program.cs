using ClientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ClientService.ClientService)))
            {
                host.Open();
                Console.WriteLine("Host started at " + DateTime.Now);
                Console.ReadKey();
            }
        }
    }
}
