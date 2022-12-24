using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User _user;

        public string Name => _user.Name;
        public string Email => _user.Email;
        public string PhoneNumber => _user.PhoneNumber;

        public UserViewModel(User user) 
        {
            _user = user;
        }
    }
}
