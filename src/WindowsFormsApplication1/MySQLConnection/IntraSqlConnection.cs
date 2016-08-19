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
            con = new MySqlConnection("server=127.0.0.1; user id=root; database=my_test; password=1123;");
            con.Open();
        }


        public void createNewUser(string username, string password, string firstname, string lastname, Registration regisForm)
        {
            string command = "INSERT INTO my_test.user VALUES ('" + username + "', '" + password + "', '" + firstname + "', '" + lastname + "');";
            
            try
            {
                cmd = new MySqlCommand(command, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("User inserted!");
                MessageBox.Show("Registration completed!");
                regisForm.Close();
                
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
        
    }
}
