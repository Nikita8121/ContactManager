using ContactManager.DTOs;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services.ContactsUpdater
{
    public class DataBaseContactsUpdater : IContactsUpdater
    {
        private JsonService _jsonService;

        public DataBaseContactsUpdater(JsonService jsonService)
        {
            _jsonService = jsonService;
        }
        public void UpdateContacts(List<Contact> contacts)
        {
            _jsonService.Write(contacts.Select(r => ToContactDto(r)));
        }

        private ContactDTO ToContactDto(Contact contact)
        {
            return new ContactDTO()
            {
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                CallHistory = contact.CallHistory
            };
        }
    }
}
