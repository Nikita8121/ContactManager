using ContactManager.Services.ContactsProvider;
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

        private readonly IContactsProvider _contactsProvider;

        public ContactsBook(IContactsProvider contactsProvider)
        {
            _contactsProvider = contactsProvider;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactsProvider.GetAllContacts().ToList();
        }

        public void AddUserToBook(Contact user)
        {
            _usersBook.Add(user);
        }
    }
}
