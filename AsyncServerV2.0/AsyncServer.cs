using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Text.Json;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AsyncServerV2._0
{
    class AsyncServer
    {
        IPEndPoint endP;
        Socket socket;
        public String conectionstr { get; set; }
        public AsyncServer(string strAddr, int port)
        {
            endP = new IPEndPoint(IPAddress.Parse(strAddr), port);
        }
        void MyAcceptCallbakFunction(IAsyncResult ia)
        {
            //получаем ссылку на слушающий сокет
            Socket socket = (Socket)ia.AsyncState;
            //получаем сокет для обмена данными с клиентом
            Socket ns = socket.EndAccept(ia);
            //выводим в консоль информацию о подключении
            Console.WriteLine(ns.RemoteEndPoint.ToString());

            // получаем ответ
            byte[] data = new byte[256]; // буфер для ответа
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт


            ///Получаем сообщение от клиента
            do
            {
                bytes = ns.Receive(data, data.Length, 0);


                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
              
            }
            while (socket.Available > 0);
            Console.WriteLine("ответ от клинета: " + builder.ToString());

            //разворачиваем базу данных если прилетела строка подключения
            if ( builder.ToString().Contains("Server"))
            {
                ConectToDB(builder.ToString());
                DbContextOptionsBuilder<AdressContext> optionsBuilder = new DbContextOptionsBuilder<AdressContext>();
                optionsBuilder.UseSqlServer(this.conectionstr);
                var options = optionsBuilder.Options;
                using (AdressContext db = new AdressContext(options))
                {

                   


                    var streets = db.streetsAdreses;

                    ////тест отправки сериализованнного обьекта в сервер
                    ////---------------------------------------------------------------------------
                    string json = System.Text.Json.JsonSerializer.Serialize(streets);
                    ////сериализуем и отправлем список улиц и индексов
                    byte[] serialalData = Encoding.Unicode.GetBytes(json);


                    





                    //BinaryFormatter formatter = new BinaryFormatter();

                    //MemoryStream mem_stream = new MemoryStream();
                    //formatter.Serialize(mem_stream, streets);

                    //ns.BeginSend(mem_stream.GetBuffer(), 0, mem_stream.GetBuffer().Length, SocketFlags.None, new AsyncCallback(MySendCallbackFunction), ns);


                    ns.BeginSend(serialalData, 0, serialalData.Length, SocketFlags.None, new AsyncCallback(MySendCallbackFunction), ns);









                }
            }
            //иначе обращаемся к индексам
            else
            {
                Console.WriteLine("Upssssssssss");
            }
            //отправляем клиенту текущщее время асинхронно, по завершении //операции отправки
            //будет вызван метод MySendCallbackFunction
            //byte[] sendBufer = System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString());
            //ns.BeginSend(sendBufer, 0, sendBufer.Length, SocketFlags.None, new
            //AsyncCallback(MySendCallbackFunction), ns);
            ////возобновляем асинхронный Accept
            socket.BeginAccept(new AsyncCallback(MyAcceptCallbakFunction), socket);
            conectionstr = builder.ToString();
        }
        /// <summary>
        /// метод развертывания баззы данных
        /// </summary>
        void ConectToDB(string buld)
        {
            // "Server=(localdb)\\MSSQLLocalDB;Database=AdressForLabWork;Trusted_Connection=true";
           this.conectionstr = buld;
            DbContextOptionsBuilder<AdressContext> optionsBuilder = new DbContextOptionsBuilder<AdressContext>();
            optionsBuilder.UseSqlServer(this.conectionstr);

            var options = optionsBuilder.Options;
            using (AdressContext context = new AdressContext(options))
            {
                StreetsAdres streetsAdres = context.streetsAdreses.FirstOrDefault();
                if (streetsAdres != null)
                {

                    Console.WriteLine ($"Base sucesful create  {streetsAdres.IndexStreet}  {streetsAdres.Sreet}");
                }
            }

        }





        void MySendCallbackFunction(IAsyncResult ia)
        {
            //по завершению отправки данных на клиента
            //закрываем сокет (если бы нам понадобился
            //дальнейший обмен данными, мы могли бы его
            //здесь организовать)
            Socket ns = (Socket)ia.AsyncState;
            int n = ((Socket)ia.AsyncState).EndSend(ia);
            ns.Shutdown(SocketShutdown.Send);
            ns.Close();
        }
        public void StartServer()
        {
            if (socket != null)
                return;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.IP);
            socket.Bind(endP);
            socket.Listen(10);
            //начинаем асинхронный Accept, при подключении
            //клиента вызовется обработчик MyAcceptCallbakFunction
            socket.BeginAccept(new AsyncCallback(MyAcceptCallbakFunction), socket);
        }
    }


  
}
