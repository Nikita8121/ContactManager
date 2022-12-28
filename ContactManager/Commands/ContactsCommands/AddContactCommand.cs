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
using System.Windows;

namespace ContactManager.Commands
{
    public class AddContactCommand : ContactCommandBase
    {
        
        public AddContactCommand(AddOrChangeContactViewModel addContactViewModel, ContactsBook contactsBook, NavigationService homeViewNavigationSevice) : base(addContactViewModel, contactsBook, homeViewNavigationSevice)
        {

        }
        public override void Execute(object? parameter)
        {
            try
            {
                _contactsBook.AddUserToBook(new Contact(_contactViewModel.Name, _contactViewModel.Email, _contactViewModel.PhoneNumber));
                MessageBox.Show("Contact added");
                _homeViewNavigationSevice.Navigate();
            } catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                MessageBox.Show(exceptionMessage);
            }
           
                
        }
    }
}
