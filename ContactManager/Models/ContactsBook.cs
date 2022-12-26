using ContactManager.DTOs;
using ContactManager.Services.ContactsProvider;
using ContactManager.Services.ContactsCreator;
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
        private readonly IContactsCreator _contactsCreator;

        public ContactsBook(IContactsProvider contactsProvider, IContactsCreator conctactsCreator)
        {
            _contactsProvider = contactsProvider;
            _contactsCreator = conctactsCreator;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactsProvider.GetAllContacts().ToList();
        }

        public void AddUserToBook(Contact contact)
        {
            
            _contactsCreator.CreateContact(contact);
        }
    }
}
