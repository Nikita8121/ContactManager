using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services.ContactsProvider
{
    public interface IContactsProvider
    {
        public List<Contact> GetAllContacts();
        public List<Contact> GetContactsByPath(string filePath);
    }
}
