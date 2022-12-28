using ContactManager.DTOs;
using ContactManager.Services.ContactsProvider;
using ContactManager.Services.ContactsCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Services.ContactsUpdater;
using ContactManager.Exceptions;

namespace ContactManager.Models
{
    public class ContactsBook
    {
        private List<Contact> _usersBook;
        private readonly IContactsProvider _contactsProvider;
        private readonly IContactsCreator _contactsCreator;
        private readonly IContactsUpdater _contactsUpdater;
        public event Action ContactsUpdated;

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

        public Contact GetContactByName(string name)
        {
            return _usersBook.Single(x => x.Name == name);
        }

        public List<Call> GetContactsCallsByName(string name)
        {
            return _usersBook.Single(x => x.Name == name).CallHistory.ToList();
        }

        public void MergeContacts(string filePath)
        {
            List<Contact> contacts = _contactsProvider.GetContactsByPath(filePath);

            bool isWrongJsonStructure = contacts.Any(x => x.Name == null || x.PhoneNumber == null);
            if (isWrongJsonStructure)
            {
                throw new RequiredPropertiesNullException(filePath);
            }

            bool isContactsListConflicts = IsContactListsConflicts(_usersBook, contacts);
            if(isContactsListConflicts)
            {
                throw new PropertiesInContactsListAreEqualException(filePath);
            }

            _usersBook = _usersBook.Concat(contacts).ToList();
            _contactsUpdater.UpdateContacts(_usersBook);
            OnContactsUpdated();
        }

        private bool IsContactListsConflicts(List<Contact> contactsList1, List<Contact> contactsList2)
        {
            return contactsList1.Any(contact1 =>
            {
                return contactsList2.Any(contact2 => IsContactsConflicts(contact1, contact2));
            });
        }
        private bool IsContactsConflicts(Contact contact1, Contact contact2)
        {
            return contact1.Name == contact2.Name || 
                contact1.PhoneNumber == contact2.PhoneNumber ||
                (contact1.Email != null && contact2.Email != null) && (contact1.Email == contact2.Email);
        }

        public void AddUserToBook(Contact contact)
        {
            bool isContactExist = _usersBook.Any(c => c.Name == contact.Name || c.PhoneNumber == contact.PhoneNumber);
            if(isContactExist)
            {
                throw new ContactExistException(contact.Name, contact.PhoneNumber);
            }
            _contactsCreator.CreateContact(contact);
        }

        public void AddCallToContactByName(string name)
        {
            Contact contact = _usersBook.Single(x => x.Name == name);
            contact.AddCall(new Call() { callDate = DateTime.Now });
            _contactsUpdater.UpdateContacts(_usersBook);
        }

        public void UpdateContact(string name, Contact contact)
        {
            Contact contactToUpdate = _usersBook.Single(x => x.Name == name);
            bool isContactExist = _usersBook.Any(c => (c.Name == contact.Name || c.PhoneNumber == contact.PhoneNumber) && contactToUpdate != c);
            if (isContactExist)
            {
                throw new ContactExistException(contact.Name, contact.PhoneNumber);
            }
            contactToUpdate.Name = contact.Name;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
            contactToUpdate.Email = contact.Email;
            _contactsUpdater.UpdateContacts(_usersBook);
        }

        public void DeleteContactByName(string name)
        {
            Contact contactToRemove = _usersBook.Single(x => x.Name == name);
            _usersBook.Remove(contactToRemove);
            _contactsUpdater.UpdateContacts(_usersBook);
            OnContactsUpdated();
        }


        private void OnContactsUpdated()
        {
            ContactsUpdated?.Invoke();
        }
    }
}
