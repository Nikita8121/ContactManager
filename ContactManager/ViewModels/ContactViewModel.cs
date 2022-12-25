using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly Contact _contact;

        public string Name => _contact.Name;
        public string Email => _contact.Email;
        public string PhoneNumber => _contact.PhoneNumber;

        public ContactViewModel(Contact contact) 
        {
            _contact = contact;
        }
    }
}
