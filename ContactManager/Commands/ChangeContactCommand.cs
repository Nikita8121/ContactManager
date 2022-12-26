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
    public class ChangeContactCommand : CommandBase
    {
        private readonly AddOrChangeContactViewModel _changeContactViewModel;
        private readonly ContactsBook _contactsBook;
        private readonly NavigationService _homeViewNavigationSevice;
        private readonly string _contactName;
        public ChangeContactCommand(AddOrChangeContactViewModel changeContactViewModel, ContactsBook contactsBook, NavigationService homeViewNavigationSevice, string contactName)
        {
            _changeContactViewModel = changeContactViewModel;
            _contactsBook = contactsBook;
            _homeViewNavigationSevice = homeViewNavigationSevice;
            _contactName = contactName;
        }
        public override void Execute(object? parameter)
        {
            _contactsBook.UpdateContact(_contactName, new Contact(_changeContactViewModel.Name, _changeContactViewModel.Email, _changeContactViewModel.PhoneNumber));
            _homeViewNavigationSevice.Navigate();
        }
    }
}
