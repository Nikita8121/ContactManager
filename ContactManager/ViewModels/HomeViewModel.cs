using ContactManager.Models;
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

        public HomeViewModel(List<Contact> contacts)
        {
            _contacts = new ObservableCollection<ContactViewModel>();

            foreach(Contact contact in contacts)
            {
                ContactViewModel contactViewModel = new ContactViewModel(contact);
                _contacts.Add(contactViewModel);
            }
        }




    }
}
