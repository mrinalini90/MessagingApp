
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
using System.Threading;

namespace IntraChat
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

            //var myServer = new MyServer();
            //int milliseconds = 5000;
            //Thread.Sleep(milliseconds);
            //var myClient = new MyClient();
            //var myRegistration = new Registration();
            var myLogin = new Login();


            //myClient.Show();
            //myServer.Show();
            myLogin.Show();
            //myRegistration.Show();
            
            Application.Run();
        }
    }
}