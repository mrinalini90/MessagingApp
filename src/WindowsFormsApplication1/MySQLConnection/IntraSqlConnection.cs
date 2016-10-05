using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace IntraChat.IntraSqlConnection
{
    class IntraSqlConnection
    {

        MySqlConnection con;
        MySqlCommand cmd;

        public IntraSqlConnection()
        {
            con = new MySqlConnection("server=localhost; user id=root; database=intra_db; password=1234;");

        }


        public void createNewUser(string username, string password, string firstname, string lastname, string ip_address, string online_status, int port)
        {
            string command = "INSERT INTO intra_db.user VALUES ('" + username + "', '" + password + "', '" + firstname + "', '" + lastname + "','" + ip_address + "', " + 0 + ", '" + port + "')";

            try
            {
                con.Open();
                cmd = new MySqlCommand(command, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("User inserted!");
                MessageBox.Show("Registration completed!");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("This username is already existed!");
                Console.WriteLine("Username is already existed!");
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("This username is already existed!");
            }
            con.Close();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="ip_address"></param>
        /// <param name="online_status"></param>
        /// <param name="port"></param>
        /// <param name="regisForm"></param>
        public void updateLoggedinUser(string username, string ip_address, int online_status)
        {
            string command = "UPDATE intra_db.user SET ip_address='" + ip_address + "',online_status=" + online_status + " WHERE Username='" + username + "';";

            try
            {
                con.Open();
                cmd = new MySqlCommand(command, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("User information updated!");
                //MessageBox.Show("Registration completed!");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("This username is already existed!");
                Console.WriteLine("Username is already existed!");
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("This username is already existed!");
            }
            con.Close();
        }



        /// <summary>
        /// This method used to verify the user information inputs in login page by user.
        /// The value of 'verify' wil be 0 if no matching otherwise 1
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="login"></param>
        /// <returns>true/false</returns>
        public bool verifyUserInformation(string username, string password, Login login)
        {

            string query = "Select count(*) FROM intra_db.user where Username='" + username + "' and Pwd='" + password + "';";
            con.Open();
            cmd = new MySqlCommand(query, con);
            Int32 verify = Convert.ToInt32(cmd.ExecuteScalar());
            if (verify >= 1)
            {
                //MessageBox.Show("Matched");
                con.Close();
                return true;
            }
            con.Close();

            return false;
        }

        public bool isUserNameAlreadyExist(string Username)
        {
            bool exist = false;
            string query1 = "SELECT COUNT(*) FROM intra_db.user WHERE Username='" + Username + "'";
            con.Open();

            cmd = new MySqlCommand(query1, con);
            exist = int.Parse(cmd.ExecuteScalar().ToString()) > 0;

            con.Close();
            return exist;
        }

    }
}

