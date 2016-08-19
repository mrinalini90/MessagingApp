using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intrachat
{
    class User
    {

        private string username, firstName, lastName;

        public User(string username, string firstName, string lastName)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;

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
    }
}
