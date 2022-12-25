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
        public AddContactCommand(AddContactViewModel addContactViewModel, ContactsBook contactsBook, NavigationService HomeViewNavigationSevice)
        {

        }
        public override void Execute(object? parameter)
        {
            
        }

        public override bool CanExecute(object? parameter)
        {

            return base.CanExecute(parameter);
        }
    }
}
