using ContactManager.Commands;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly Contact _contact;
        private readonly ContactsBook _contactsBook;
        public string Name => _contact.Name;
        public string Email => _contact.Email;
        public string PhoneNumber => _contact.PhoneNumber;
        public ICommand DeleteContacts { get; }
        public ICommand ShowCallHistory { get; }
        public ICommand Delete { get; }
        public ICommand Call { get; }

        public ContactViewModel(Contact contact, ContactsBook contactsBook) 
        {
            _contact = contact;
            _contactsBook = contactsBook;
            Call = new AddCallToHistoryCommand(_contact.Name, _contactsBook);
        }
    }
}
