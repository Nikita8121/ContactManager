using ContactManager.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters.")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Must not be empty.")]
        [PhoneNumberCustom(ErrorMessage = "Fill up your phone number")]
        public string PhoneNumber { get; set; }
        public List<Call> CallHistory => _callsHistory;
        private List<Call> _callsHistory;

        public Contact(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            _callsHistory = new List<Call>();
        }

        public Contact(string name, string email, string phoneNumber, List<Call> callsHistory)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            _callsHistory = callsHistory;
        }

        public void AddCall(Call call)
        {
            _callsHistory.Add(call);
        }

        public static bool Validate(Contact contact)
        {
            ValidationContext context = new ValidationContext
            (contact, null, null);
            List<ValidationResult> validationResults = new
            List<ValidationResult>();
            return Validator.TryValidateObject
            (contact, context, validationResults, true);
        }
    }
}
