using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace Networking
{
    class Program
    {
        static void Main(string[] args)
        {
            WevServer server = new WevServer("http://localhost:51111/myapp/", @"C:\Users\Student\Desktop\serverFolder");
            try
            {
                server.Start();
                Console.ReadLine();
            }
            finally
            {
                server.Stop();
            }
        }               
    }
}
