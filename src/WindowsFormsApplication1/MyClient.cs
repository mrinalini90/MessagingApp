
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
    public partial class MyClient : Form
    {
        public SharpMessagingClient client;

        public MyClient()
        {

            InitializeComponent();
            initialClient();


        }


        public void initialClient()
        {

            var registry = new ExtensionRegistry();
            registry.AddRequiredExtension(new AckExtension()
            {
                MessagesPerAck = 10,
                AckExpireTime = TimeSpan.FromSeconds(1)
            });

            client = new SharpMessagingClient("MyClient", registry);
            client.Start("localhost", 8334);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Send(new MessageFrame(this.clientMessage.Text));
            clearInput();
            this.clientMessage.Select();
        }
        

        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                client.Send(new MessageFrame(this.clientMessage.Text));
                clearInput();
            }
        }

        public void clearInput()
        {
            Invoke((MethodInvoker)delegate {
                this.clientMessage.Clear();
            });
        }

    }
}
