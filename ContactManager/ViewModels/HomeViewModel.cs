using ContactManager.Commands;
using ContactManager.Models;
using ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ContactViewModel> _contacts;
        public IEnumerable<ContactViewModel> Contacts => _contacts;
        public ICommand ImportContacts { get; }
        public ICommand DeleteContacts { get; }
        public ICommand ShowCallHistory { get; }
        public ICommand Delete { get; }
        public ICommand Call { get; }
        public ICommand AddContact { get; }

        public HomeViewModel(List<Contact> contacts, NavigationService addContactNavigationService)
        {
            _contacts = new ObservableCollection<ContactViewModel>();


            AddContact = new NavigateCommand(addContactNavigationService);

            Call = new AddCallToHistoryCommand();

            foreach (Contact contact in contacts)
            {
                ContactViewModel contactViewModel = new ContactViewModel(contact);
                _contacts.Add(contactViewModel);
            }
        }




    }
}
