using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public partial class Form1 : Form
    {
        List<StreetsAdres> listAdress;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDB_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Loopback, 11000);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);

                string message = textBox1.Text;
                //тест отправки сериализованнного обьекта в сервер
                //---------------------------------------------------------------------------
                //string json = JsonSerializer.Serialize<Test>(new Test());
                byte[] data = Encoding.Unicode.GetBytes(message);

                //-----------------------------------------------------------------------          
                socket.Send(data);

                // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {



                    //сериализуем и отправлем список улиц и индексов
                    //byte[] serialalData = Encoding.Unicode.GetBytes(json);

                    bytes = socket.Receive(data, data.Length, 0);

                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    //var json = System.Text.Json.JsonSerializer.Deserialize<AdressContext>(builder.ToString());
                    //foreach (var item in json as IEnumerable<AdressContext>)
                    //{
                    //    textBox2.Text += item.streetsAdreses;
                    //}
                }
                while (socket.Available > 0);

                // textBox1.Text = "ответ сервера: " + builder.ToString();
                try
                {
                 
                  //десиариализация колекции улиц
                  var json = JsonConvert.DeserializeObject<List<StreetsAdres>>(builder.ToString());
                    listAdress = json.ToList<StreetsAdres>();
                    foreach (var item in json as IEnumerable<StreetsAdres> )
                    {
                      
                        listBox1.Items.Add(item.IndexStreet);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                






                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
          var indx =  listBox1.SelectedItem;

            foreach (var item in listAdress)
            {
                if (item.IndexStreet.ToString() == indx.ToString())
                {
                    textBox2.Text += item.Sreet;
                }
            }
        }
    }
}
