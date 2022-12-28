using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManager.Commands
{
    public class AddCallToHistoryCommand : CommandBase
    {
        private readonly string _contactName;
        private readonly ContactsBook _contactsBook;

        public AddCallToHistoryCommand(string contactName, ContactsBook contactsBook)
        {
            _contactName = contactName;
            _contactsBook = contactsBook;
        }
        public override void Execute(object? parameter)
        {
            _contactsBook.AddCallToContactByName(_contactName);
            MessageBox.Show("Call made");
        }
    }
}
