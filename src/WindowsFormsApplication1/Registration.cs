using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntraChat
{
    public partial class Registration : Form
    {

        private IntraSqlConnection.IntraSqlConnection con = new IntraSqlConnection.IntraSqlConnection();

        public Registration()
        {
            InitializeComponent();
        }

        private void RegisConfirmBtn_Click(object sender, EventArgs e)
        {

            if(UsernameTextBox.Text != "" && PasswordTextBox.Text != "" && FirstNameTextBox.Text != "" && LastNameTextBox.Text != "")
            {
                if (con.isUserNameAlreadyExist(UsernameTextBox.Text))
                {
                    MessageBox.Show("This Username is already exist. Please change your Username and try again.");
                    this.UsernameTextBox.Clear();
                    this.PasswordTextBox.Clear();
                    this.FirstNameTextBox.Clear();
                    this.LastNameTextBox.Clear();
                }
                else {
                    con.createNewUser(UsernameTextBox.Text, PasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, NetworkConfiguration.getLocalIPAddress(), 0, NetworkConfiguration.getPortNumber());
                    this.Close();
                }    
            }
            else
            {

                MessageBox.Show("Please complete all fields..");
                Console.WriteLine("All fields cannot be left blank!!");
            }

        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void RegisCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
