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

        public User current_user_session;

        public MyServer(User session)
        {
            InitializeComponent();
            this.current_user_session = session;

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
            Console.WriteLine(current_user_session.getPortNumber());
            server.Start(current_user_session.getPortNumber());
            this.recievedTextBox.Text = "Server Started!";


            var myClient = new MyClient(this, current_user_session);
            myClient.Show();

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
                this.recieveMessage.AppendText("Message From " + current_user_session.getFirstName() + ": " +message + "\r\n");
            });
        }
    }
}
