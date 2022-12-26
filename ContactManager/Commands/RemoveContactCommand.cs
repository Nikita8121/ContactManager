using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Commands
{
    public class RemoveContactCommand : CommandBase
    {
        private readonly string _contactName;
        private readonly ContactsBook _contactsBook;

        public RemoveContactCommand(string contactName, ContactsBook contactsBook)
        {
            _contactName = contactName;
            _contactsBook = contactsBook;
        }
        public override void Execute(object? parameter)
        {
            _contactsBook.DeleteContactByName(_contactName);
        }
    }
}
