using ContactManager.DTOs;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services.ContactsCreator
{
    public class DataBaseContactsCreator : IContactsCreator
    {
        private JsonService _jsonService;

        public DataBaseContactsCreator(JsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public void CreateContact(Contact contact)
        {
            ContactDTO contactDTO = ToContactDto(contact);
            List<ContactDTO> previousData = _jsonService.Get<List<ContactDTO>>();
            previousData.Add(contactDTO);
            _jsonService.Write(previousData);
        }


        private ContactDTO ToContactDto(Contact contact)
        {
            return new ContactDTO()
            {
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                CallHistory = new List<Call>()
            };
        }
    }
}
