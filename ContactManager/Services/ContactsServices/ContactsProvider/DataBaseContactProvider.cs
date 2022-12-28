using ContactManager.DTOs;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services.ContactsProvider
{
    public class DataBaseContactProvider : IContactsProvider
    {
        JsonService _jsonService;

        public DataBaseContactProvider(JsonService jsonService)
        {
            _jsonService = jsonService;
        }
        public List<Contact> GetAllContacts()
        {
            IEnumerable<ContactDTO> contactDTOs = _jsonService.Get<List<ContactDTO>>();
            return contactDTOs.Select(r => ToContact(r)).ToList();
        }

        public List<Contact> GetContactsByPath(string filePath)
        {
            string prevfilePath = _jsonService.FilePath;
            _jsonService.FilePath = filePath;
            List<ContactDTO> contactDTOs = _jsonService.Get<List<ContactDTO>>();
            _jsonService.FilePath = prevfilePath;
            return contactDTOs.Select(r => ToContact(r)).ToList();
        }

        private Contact ToContact(ContactDTO contactDTO)
        {
            return new Contact(contactDTO.Name, contactDTO.Email, contactDTO.PhoneNumber, contactDTO.CallHistory);
        }
    }
}
