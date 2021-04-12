using System;
using System.Net;
using System.Threading.Tasks;

namespace AsyncServerV2._0
{
    class Program
    {
       static void Main(string[] args)
        {
            AsyncServer server = new AsyncServer(IPAddress.Loopback.ToString(), 11000);//этот порт буду использвоать для получения строки подключения
            server.StartServer();
            
            Console.WriteLine("Satrt Server to take conection string to data base");

           

            AsyncServer server2 = new AsyncServer(IPAddress.Loopback.ToString(), 11001);//этот порт буду использвоать для работы с базой
            server.StartServer();


            Console.Read();

        }
    }
}
