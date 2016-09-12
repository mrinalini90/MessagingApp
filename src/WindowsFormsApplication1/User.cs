using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntraChat
{
    public partial class User
    {

        private string username, firstName, lastName, ip_address;

        private int online_status, port;

        public User(string username, string firstName, string lastName, string ipAddress, int online_status, int port)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.ip_address = ipAddress;
            this.online_status = online_status;
            this.port = port;

        }

        public string getUsername()
        {
            return this.username;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public string getLastName()
        {
            return this.lastName;
        }

        public string getIpAddress()
        {
            return this.ip_address;
        }

        public int getOnlineStatus()
        {
            return this.online_status;
        }

        public int getPortNumber()
        {
            return this.port;
        }

    }
}
