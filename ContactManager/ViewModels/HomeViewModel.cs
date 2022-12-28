using ContactManager.Commands;
using ContactManager.Models;
using ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ContactViewModel> _contacts;
        private readonly ContactsBook _contactsBook;
        private string _searchValue;
        public bool HasContacts => _contacts.Any();
        Dictionary<string, NavigationService> _navigationServicesDictionary;
        public IEnumerable<ContactViewModel> Contacts => _contacts;
        public ICommand ImportContacts { get; }
        public ICommand AddContact { get; }

        public HomeViewModel(ContactsBook contactsBook, Dictionary<string, NavigationService> navigationServicesDictionary)
        {
            _contacts = new ObservableCollection<ContactViewModel>();

            _contactsBook = contactsBook;

            AddContact = new NavigateCommand(navigationServicesDictionary["CreateAddContactViewModel"]);

            ImportContacts = new ImportContactsCommand(contactsBook);

            SearchContacts(_contactsBook.GetAllContacts(), navigationServicesDictionary);

            _navigationServicesDictionary = navigationServicesDictionary;

            _contactsBook.ContactsUpdated += delegate () { SearchContacts(_contactsBook.GetAllContacts(), _navigationServicesDictionary, _searchValue); };

            _contacts.CollectionChanged += OnContactsChanged;

        }


        private void SearchContacts(List<Contact> contacts, Dictionary<string, NavigationService> navigationServicesDictionary, string searchValue = null)
        {
            _contacts.Clear();
            searchValue = searchValue?.Trim();

            ContactViewModel createContactViewModel(Contact contact, ContactsBook contactsBook, Dictionary<string, NavigationService> navigationServicesDictionary)
            {
                return new ContactViewModel(contact, contactsBook, navigationServicesDictionary);
            }

            foreach (Contact contact in contacts)
            {
                if(searchValue == null)
                {
                    _contacts.Add(createContactViewModel(contact, _contactsBook, navigationServicesDictionary));
                    continue;
                }

                if (!contact.Name.Contains(searchValue)) continue;

                _contacts.Add(createContactViewModel(contact, _contactsBook, navigationServicesDictionary));
            }
        }

        public string SearchValue 
        {
            get { return _searchValue; }
            set
            {
                _searchValue = value;
                SearchContacts(_contactsBook.GetAllContacts(), _navigationServicesDictionary, _searchValue);
                OnPropertyChanged(nameof(SearchValue));
            }
        }

        private void OnContactsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasContacts));
        }
    }
}
