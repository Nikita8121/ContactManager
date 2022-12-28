using ContactManager.Commands.ContactsCommands;
using ContactManager.Models;
using ContactManager.Services;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                _contactsBook.UpdateContact(_contactName, new Contact(_contactViewModel.Name, _contactViewModel.Email, _contactViewModel.PhoneNumber));
                MessageBox.Show("Contact updated");
                _homeViewNavigationSevice.Navigate();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                MessageBox.Show(exceptionMessage);
            }
        }
    }
}
