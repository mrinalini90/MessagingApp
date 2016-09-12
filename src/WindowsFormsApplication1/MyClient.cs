
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
using System.Collections.Generic;

namespace IntraChat
{
    public partial class MyClient : Form
    {
        public SharpMessagingClient client;
        private IntraSqlConnection.IntraSqlConnection con = new IntraSqlConnection.IntraSqlConnection();
        private User current_user_session;
        private List<Contact> current_contact_session;
        private MyServer myServer;

        public MyClient(MyServer server, User session)
        {

            InitializeComponent();
            this.current_user_session = session;
            initialClient();
            this.myServer = server;

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
            client.Start("localhost", current_user_session.getPortNumber());

            current_contact_session = con.retrieveContactList(current_user_session.getUsername(), this);
            /*contact_data_table.Columns[1].Name = "Friends";
            contact_data_table.Columns[1].DataPropertyName = "My Contacts";
            contact_data_table.Columns[0].Name = "Added Date";
            contact_data_table.Columns[0].DataPropertyName = "Date Added";*/
            contact_data_table.AutoGenerateColumns = false;
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

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            con.logout(current_user_session.getUsername());
            client.Close();
            myServer.Close();
            var myLogin = new Login();
            myLogin.Show();
        }
    }
}
