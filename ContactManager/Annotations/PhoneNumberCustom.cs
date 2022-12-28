using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Annotations
{
    public class PhoneNumberCustom : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string phoneNumber = value as string;
            if(phoneNumber.IndexOf("_") >= 0) return false;
            return true;
        }
    }
}
