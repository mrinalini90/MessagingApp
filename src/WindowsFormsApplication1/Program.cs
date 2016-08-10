
using System;
using System.Text;
using SharpMessaging.Extensions;
using SharpMessaging.Extensions.Ack;
using SharpMessaging.Extensions.Payload.DotNet;
using SharpMessaging.fastJSON;
using SharpMessaging.Frames;
using SharpMessaging.Server;
using System.Windows.Forms;
using SharpMessaging;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MyServer());
            var myServer = new MyServer();
            var myClient = new MyClient();

            /*
            var registry = new ExtensionRegistry();
            registry.AddOptionalExtension(new AckExtension()
            {
                MessagesPerAck = 200,
                AckExpireTime = TimeSpan.FromSeconds(1)
            });
            registry.AddOptionalExtension(new DotNetTypeExtension());
            registry.AddOptionalExtension(new FastJsonExtension());
            var server = new SharpMessagingServer(registry);
            server.FrameReceived = OnFrame;
            server.Start(8334);

            CreateClient();

            Console.ReadLine();
            */

            myClient.Show();
            myServer.Show();

            Application.Run();


        }

        public static void CreateClient()
        {
            var registry = new ExtensionRegistry();
            registry.AddRequiredExtension(new AckExtension()
            {
                MessagesPerAck = 10,
                AckExpireTime = TimeSpan.FromSeconds(1)
            });
            //registry.AddRequiredExtension(new FastJsonExtension());
            var client = new SharpMessagingClient("MyClient", registry);
            client.Start("localhost", 8334);
            client.Send(new MessageFrame("Hi, How are you?"));
            Console.WriteLine("Sent!");
            Console.ReadLine();
        }

        //private static int batch;
        private static void OnFrame(ServerClient channel, MessageFrame frame)
        {
            var msg = Encoding.ASCII.GetString(frame.PayloadBuffer.Array, frame.PayloadBuffer.Offset,
                frame.PayloadBuffer.Count);

            Console.WriteLine();
            Console.WriteLine("Received '" + msg + "' from " + channel.RemoteEndPoint);

            
            recievedMessage(msg);
            
        }

        public static void sendBtnOnClick(string message)
        {
            var registry = new ExtensionRegistry();
            registry.AddRequiredExtension(new AckExtension()
            {
                MessagesPerAck = 10,
                AckExpireTime = TimeSpan.FromSeconds(1)
            });
            //registry.AddRequiredExtension(new FastJsonExtension());
            var client = new SharpMessagingClient("MyClient", registry);
            client.Start("localhost", 8334);
            client.Send(new MessageFrame(message));
            Console.WriteLine("Sent!");
            Console.ReadLine();

        }

        public static string recievedMessage(string message)
        {

            return message;

        }
    }

    
}
