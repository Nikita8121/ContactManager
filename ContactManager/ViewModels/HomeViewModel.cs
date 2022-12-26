﻿using ContactManager.Commands;
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
        private readonly ContactsBook _contactsBook;
        public IEnumerable<ContactViewModel> Contacts => _contacts;
        public ICommand ImportContacts { get; }
        public ICommand AddContact { get; }

        public HomeViewModel(ContactsBook contactsBook, NavigationService addContactNavigationService)
        {
            _contacts = new ObservableCollection<ContactViewModel>();

            _contactsBook = contactsBook;

            AddContact = new NavigateCommand(addContactNavigationService);

            InitializeContacts(_contactsBook.GetAllContacts());
        }


        private void InitializeContacts(List<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                ContactViewModel contactViewModel = new ContactViewModel(contact, _contactsBook);
                _contacts.Add(contactViewModel);
            }
        }


    }
}
