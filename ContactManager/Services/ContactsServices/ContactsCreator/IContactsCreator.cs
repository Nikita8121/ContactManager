using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services.ContactsCreator
{
    public interface IContactsCreator
    {
        void CreateContact(Contact contact);
    }
}
