using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using IntraChat;

namespace IntraChat.IntraSqlConnection
{
    class IntraSqlConnection
    {

        private MySqlConnection con;
        private MySqlCommand cmd;
        private DataTable dataTable = new DataTable();

        public IntraSqlConnection()
        {
            con = new MySqlConnection("server=localhost; user id=root; database=intra_db; password=1123;");

        }


        public void createNewUser(string username, string password, string firstname, string lastname, string ip_address, int online_status, int port)
        {
            string command = "INSERT INTO intra_db.user VALUES ('" + username + "', '" + password + "', '" + firstname +
                "', '" + lastname + "','" + ip_address + "', " + online_status + ", " + port + ")";

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

        internal User userInitiate(string username)
        {
            User retrieved_user;
            string data_username = "", data_firstname = "", data_lastname = "", data_ip_address = null;
            int data_online = 0, data_port = 0;

            try
            {

                string command = "SELECT * from intra_db.user where username = '" + username + "'";
                cmd = new MySqlCommand(command, con);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (con != null) con.Close();

            }

            foreach (DataRow dr in dataTable.Rows)
            {
                data_username = dr.Field<string>("username");

                data_firstname = dr.Field<string>("first_name");
                data_lastname = dr.Field<string>("last_name");


                Console.WriteLine(data_firstname);
                data_ip_address = dr.Field<string>("ip_address");
                data_online = dr.Field<int>("online_status");
                data_port = dr.Field<int>("port");

            }

            retrieved_user = new User(data_username, data_firstname, data_lastname, data_ip_address, data_online, data_port);

            return retrieved_user;

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
        public void updateLoggedinUser(string username, string ip_address, int online_status, int port)
        {
            string command = "UPDATE intra_db.user SET ip_address='" + ip_address + "', online_status=" + online_status + ", port=" + port + " WHERE Username='" + username + "';";

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
        /// This method used for changing online_status in database
        /// The value wil be 0 or 1. 1 for online and 0 for offline
        /// </summary>
        public void logout(string username)
        {
            string command = "UPDATE intra_db.user SET online_status =" + 0 + " where Username = '" + username + "';";

            con.Open();
            cmd = new MySqlCommand(command, con);
            cmd.ExecuteNonQuery();
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
        public bool verifyUserInformation(string username, string password)
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

        public bool isUserNameAlreadyExist(string username)
        {
            bool exist = false;
            string query1 = "SELECT COUNT(*) FROM intra_db.user WHERE Username='" + username + "'";
            con.Open();

            cmd = new MySqlCommand(query1, con);
            exist = int.Parse(cmd.ExecuteScalar().ToString()) > 0;

            con.Close();
            return exist;
        }

        public List<Contact> retrieveContactList(string username, IntraChat.MyClient client)
        {
            string contact_command = "SELECT * FROM intra_db.contact WHERE Username='" + username + "'";
            List<Contact> contact_list = new List<Contact>();
            con.Open();
            DataTable dt = new DataTable();

            cmd = new MySqlCommand(contact_command, con);
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
                dt.Columns["idcontact"].ColumnName = "ID";
                dt.Columns["username"].ColumnName = "Me";
                dt.Columns["contact_username"].ColumnName = "My Contacts";
                dt.Columns["date_added"].ColumnName = "Date Added";
                
      
                client.contact_data_table.DataSource = dt;
            }
            /*
            if(dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    
                    int id = (int)dr["idcontact"];
                    string contact_username = (string)dr["username"];
                    string contact_contactname = (string)dr["contact_username"];
                    DateTime date = (DateTime)dr["date_added"];
                    Contact contact = new Contact(id, contact_username, contact_contactname, date);
                    contact_list.Add(contact);
                    

                }
            }
            */
            return contact_list;


        }


        // Getting all ip addresses from database
        public List<string> retrieveIPAddress()
        {
            return null;
        }


        // Getting all port numbers from database
        public List<int> retrievePortNumber()
        {
            DataTable dataTable = new DataTable();
            List<int> portList;

            try
            {

                string command = "SELECT * from intra_db.user";
                cmd = new MySqlCommand(command, con);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (con != null) con.Close();

            }

            portList = new List<int>(dataTable.Rows.Count);

            foreach (DataRow dr in dataTable.Rows)
            {
                portList.Add((int)dr["port"]);
            }

            return portList;

        }

    }
}

