using ContactManager.Models;
using ContactManager.Services;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Commands
{
    public class AddContactCommand : CommandBase
    {
        private readonly AddContactViewModel _addContactViewModel;
        private readonly ContactsBook _contactsBook;
        private readonly NavigationService _homeViewNavigationSevice;
        public AddContactCommand(AddContactViewModel addContactViewModel, ContactsBook contactsBook, NavigationService homeViewNavigationSevice)
        {
            _addContactViewModel = addContactViewModel;
            _contactsBook = contactsBook;
            _homeViewNavigationSevice = homeViewNavigationSevice;
        }
        public override void Execute(object? parameter)
        {
            _contactsBook.AddUserToBook(new Contact(_addContactViewModel.Name, _addContactViewModel.Email, _addContactViewModel.PhoneNumber));
            _homeViewNavigationSevice.Navigate();
        }

        //public override bool CanExecute(object? parameter)
        //{

        //    return base.CanExecute(parameter);
        //}
    }
}
