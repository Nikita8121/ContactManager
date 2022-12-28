using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Exceptions
{
    public class ContactExistException : Exception
    {
        public ContactExistException(string name, string phoneNumber) : base($"Contact with name {name} or phone number {phoneNumber} alreaady exists")
        {

        }

    }
}
