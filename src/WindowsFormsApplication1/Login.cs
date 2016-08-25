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
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (loginUsernameTextBox.Text != "" || loginPasswordTextBox.Text != "")
            {
                if (con.verifyUserInformation(loginUsernameTextBox.Text, loginPasswordTextBox.Text, this)){
                    //update ip address and online status in the database 
                    con.updateLoggedinUser(loginUsernameTextBox.Text,Registration.GetLocalIPAddress(),"T");

                    //start local server and client
                    var myServer = new MyServer();
                    var myClient = new MyClient();
                    Close();
                    myClient.Show();
                    myServer.Show();
                }
                else {
                    MessageBox.Show("Wrong Username or Password. Please enter again.");
                    loginUsernameTextBox.Clear();
                    loginPasswordTextBox.Clear();
                }               
            }
            else {
                MessageBox.Show("Please Insert your Username and Password");
            }

            
        }
    }
}
