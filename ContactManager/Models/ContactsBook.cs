using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class ContactsBook
    {
        private List<Contact> _usersBook;
        public List<Contact> UsersBook => _usersBook;

        public List<Contact> GetUsersBook() { return _usersBook; }

        public void AddUserToBook(Contact user)
        {
            _usersBook.Add(user);
        }
    }
}
