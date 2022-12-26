using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
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

        public void AddCall(Call call)
        {
            _callsHistory.Add(call);
        }
    }
}
