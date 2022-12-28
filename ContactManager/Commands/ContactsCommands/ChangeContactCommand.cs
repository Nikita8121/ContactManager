using ContactManager.Commands.ContactsCommands;
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
    public class ChangeContactCommand : ContactCommandBase
    {
        private readonly string _contactName;
        public ChangeContactCommand(AddOrChangeContactViewModel changeContactViewModel, ContactsBook contactsBook, NavigationService homeViewNavigationSevice, string contactName) : base(changeContactViewModel, contactsBook, homeViewNavigationSevice)
        {
            _contactName = contactName;
        }
        public override void Execute(object? parameter)
        {
            _contactsBook.UpdateContact(_contactName, new Contact(_contactViewModel.Name, _contactViewModel.Email, _contactViewModel.PhoneNumber));
            _homeViewNavigationSevice.Navigate();
        }
    }
}
