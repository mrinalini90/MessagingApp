
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntraChat
{
    public partial class Login : Form
    {
        private IntraSqlConnection.IntraSqlConnection con = new IntraSqlConnection.IntraSqlConnection();
        private User current_user_session;

        public Login()
        {
            InitializeComponent();

        }

        private void regisBtn_Click(object sender, EventArgs e)
        {
            Registration regisForm = new Registration();
            regisForm.Show();
        }

        /// <summary>
        /// User login when login button pressed.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            if (loginUsernameTextBox.Text != "" || loginPasswordTextBox.Text != "")
            {
                if (con.verifyUserInformation(loginUsernameTextBox.Text, loginPasswordTextBox.Text))
                {
                    //update ip address and online status in the database 
                    con.updateLoggedinUser(loginUsernameTextBox.Text, NetworkConfiguration.getLocalIPAddress(), 1, NetworkConfiguration.getPortNumber());

                    

                    current_user_session = con.userInitiate(loginUsernameTextBox.Text);
                    //Console.WriteLine("Number of contact : " + current_contact_session.Count);
                    //Console.WriteLine("Corrent IP fron current user : " + current_user_session.getIpAddress());
                    
                    Close();

                    /*
                    Console.WriteLine(current_user_session.getFirstName());
                    Console.WriteLine(current_user_session.getLastName());
                    Console.WriteLine(current_user_session.getIpAddress());*/
                    //start local server and client
                    var myServer = new MyServer(current_user_session);
                    myServer.Show();

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password. Please enter again.");
                    loginUsernameTextBox.Clear();
                    loginPasswordTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Insert your Username and Password");
            }


        }
    }
}
