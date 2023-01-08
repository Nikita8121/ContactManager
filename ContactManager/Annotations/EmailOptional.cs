using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactManager.Annotations
{
    public class EmailOptional : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = (value as string).Trim();
            if (email == null || email == string.Empty) return true;

            if (!RegexEmailCheck(email)) return false;

            return true;
        }

        public static bool RegexEmailCheck(string input)
        {
            // returns true if the input is a valid email
            return Regex.IsMatch(input, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
