using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Exceptions
{
    public class PropertiesInContactsListAreEqualException : Exception
    {
        public PropertiesInContactsListAreEqualException(string filePath) : base($"Some properties in json array are equal. Filename: {filePath}")
        {
        }
    }
}
