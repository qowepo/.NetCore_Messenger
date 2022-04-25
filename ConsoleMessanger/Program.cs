using System;
using Newtonsoft.Json;

namespace MyMessanger
{
    class Program
    {
        private static int MessageID;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();

        private static void GetNewMessages()
        {
            Messange msg = API.GetMessage(MessageID);
            while (msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }
        static void Main(string[] args)
        {
            //Messange msg = new Messange();
            //Console.WriteLine(msg.ToString());
            //Messange msg2 = new Messange("Nikita","Hello, how are you?", DateTime.UtcNow);
            //string output = JsonConvert.SerializeObject(msg2);
            //Console.WriteLine(output);
            //Messange deserializedMsg = JsonConvert.DeserializeObject<Messange>(output);
            //Console.WriteLine(deserializedMsg);
            //Console.WriteLine("Hello World!");

            MessageID = 1;
            Console.WriteLine("Enter Your Name:");
            //UserName = "RusAl";
            UserName = Console.ReadLine();
            string MessageText = "";
            while (MessageText != "exit")
            {
                GetNewMessages();
                MessageText = Console.ReadLine();
                if (MessageText.Length > 1)
                {
                    Messange Sendmsg = new Messange(UserName, MessageText, DateTime.Now);
                    API.SendMessage(Sendmsg);
                }
            }
        }
    }
}