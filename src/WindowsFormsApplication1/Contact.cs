using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntraChat
{
    partial class Contact
    {

        private int id;
        private string username, contact_username;
        private DateTime dateAdded;

        public Contact(int id, string username, string contact_username, DateTime dateAdded)
        {

            this.id = id;
            this.username = username;
            this.contact_username = contact_username;
            this.dateAdded = dateAdded;

        }

        public int getId()
        {
            return id;
        }

        public string getUsername()
        {
            return username;
        }

        public string getContactUsername()
        {
            return contact_username;
        }

        public DateTime getDateAdded()
        {
            return dateAdded;
        }

    }
}
