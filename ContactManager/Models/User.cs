using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class User
    {
        public string Name { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        private List<Call> _callsHistory;

        public User (string name, string email, string phoneNumber)
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
