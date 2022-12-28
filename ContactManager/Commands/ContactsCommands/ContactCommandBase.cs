using ContactManager.Models;
using ContactManager.Services;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Commands.ContactsCommands
{
    public abstract class ContactCommandBase : CommandBase
    {
        protected readonly AddOrChangeContactViewModel _contactViewModel;
        protected readonly ContactsBook _contactsBook;
        protected readonly NavigationService _homeViewNavigationSevice;

        public ContactCommandBase(AddOrChangeContactViewModel contactViewModel, ContactsBook contactsBook, NavigationService homeViewNavigationSevice)
        {
            _contactViewModel = contactViewModel;
            _contactsBook = contactsBook;
            _homeViewNavigationSevice = homeViewNavigationSevice;

            _contactViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _contactViewModel.CanCreateContact && base.CanExecute(parameter);
        }


        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_contactViewModel.Name) ||
                e.PropertyName == nameof(_contactViewModel.Email) ||
                e.PropertyName == nameof(_contactViewModel.PhoneNumber))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
