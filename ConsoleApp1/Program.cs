using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Example_04();
        }

    /*    public static void Example_01()
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead("http://www.google.com"); // открой поток для чтения вот этого http://www.google.com

            using (StreamReader reader = new StreamReader(data))
            {
                string str = reader.ReadToEnd();

                Console.WriteLine(str);
            }

            data.Close();
        }*/

     /*   public static void Example_02(string url, string data)
        {
            byte[] postArr = Encoding.ASCII.GetBytes(data);

            WebClient client = new WebClient();
            Stream stream = client.OpenWrite(url);
            stream.Write(postArr, 0, postArr.Length);
            stream.Close();
        }

        public static void Example_03(string url, string data)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.UploadString(url, data);
            Console.WriteLine(result);
        }*/

        public static void Example_04()
        {
            WebRequest request = WebRequest.Create("http://www.google.com");

            request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Console.WriteLine(response.StatusDescription);

            StreamReader reader = new StreamReader(response.GetResponseStream());

            Console.WriteLine(reader.ReadToEnd());

        }
    }
}
