using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1.SocketServer
{
    public class Lesson_2
    {
        public static void SocketServer()
        {
            // 28.09.21 Socket Server

            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 5001);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Ожидаем смс от клиента");

            listener.Bind(ipEndPoint);
            listener.Listen(10);

            while (true)
            {
                Socket handler = listener.Accept();
                try
                {
                    string data = null;

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    Console.WriteLine("receive: " + data + "\n\n");
                    string reply = "Данные получены " + DateTime.Now;

                    byte[] replyMsg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(replyMsg);

                    if (data.IndexOf("<eof>") > -1)
                    {
                        Console.WriteLine("Сервер завершил соединение с клиентом");
                        break;
                    }

                    handler.Shutdown(SocketShutdown.Both);

                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    handler.Close();
                }
            }

        }
    }
}
