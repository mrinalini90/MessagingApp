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

namespace IntraChat
{
    public partial class MyServer : Form
    {
        

        public MyServer()
        {
            InitializeComponent();
            initiateServer();

            //Application.Run(new MyClient());

        }

        public void initiateServer()
        {
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
            this.recievedTextBox.Text = "Server Started!";
            


        }

        private void OnFrame(ServerClient channel, MessageFrame frame)
        {
            var msg = Encoding.ASCII.GetString(frame.PayloadBuffer.Array, frame.PayloadBuffer.Offset,
                frame.PayloadBuffer.Count);

            UpdateTextBox(msg, channel.ClientName);

            Console.WriteLine();
            Console.WriteLine("Received '" + msg + "' from " + channel.RemoteEndPoint);

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void UpdateTextBox(string message, string sender)
        {
            Invoke((MethodInvoker)delegate {
                this.recieveMessage.AppendText("Message From " + sender + ": " +message + "\r\n");
            });
        }
    }
}
