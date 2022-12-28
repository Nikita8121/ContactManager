using ContactManager.Commands.ContactsCommands;
using ContactManager.Models;
using ContactManager.Services;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Commands
{
    public class AddContactCommand : ContactCommandBase
    {
        
        public AddContactCommand(AddOrChangeContactViewModel addContactViewModel, ContactsBook contactsBook, NavigationService homeViewNavigationSevice) : base(addContactViewModel, contactsBook, homeViewNavigationSevice)
        {

        }
        public override void Execute(object? parameter)
        {
            _contactsBook.AddUserToBook(new Contact(_contactViewModel.Name, _contactViewModel.Email, _contactViewModel.PhoneNumber));
            _homeViewNavigationSevice.Navigate();
        }
    }
}
