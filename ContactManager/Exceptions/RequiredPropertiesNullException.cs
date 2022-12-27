using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Exceptions
{
    public class RequiredPropertiesNullException : Exception
    {
        public RequiredPropertiesNullException(string filePath) : base($"Required properties as name or phone number are null, or provided json is not in the right structure. FilePath {filePath}. Look for rigth json strcuture in your homedir/contactBook.json")
        {

        }
    }
}
