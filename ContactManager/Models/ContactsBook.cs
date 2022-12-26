using ContactManager.DTOs;
using ContactManager.Services.ContactsProvider;
using ContactManager.Services.ContactsCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Services.ContactsUpdater;

namespace ContactManager.Models
{
    public class ContactsBook
    {
        private List<Contact> _usersBook;
        private readonly IContactsProvider _contactsProvider;
        private readonly IContactsCreator _contactsCreator;
        private readonly IContactsUpdater _contactsUpdater;

        public ContactsBook(IContactsProvider contactsProvider, IContactsCreator conctactsCreator, IContactsUpdater contactsUpdater)
        {
            _contactsProvider = contactsProvider;
            _contactsCreator = conctactsCreator;
            _contactsUpdater = contactsUpdater;
        }

        public List<Contact> GetAllContacts()
        {
            _usersBook = _contactsProvider.GetAllContacts().ToList();
            return _usersBook;
        }

        public void AddUserToBook(Contact contact)
        {
            
            _contactsCreator.CreateContact(contact);
        }

        public void AddCallToContactByName(string name)
        {
            Contact contact = _usersBook.Single(x => x.Name == name);
            contact.AddCall(new Call() { callDate = new DateTime() });
            _contactsUpdater.UpdateContacts(_usersBook);
        }
    }
}
