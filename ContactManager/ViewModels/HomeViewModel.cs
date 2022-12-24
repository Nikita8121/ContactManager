using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ObservableCollection<UserViewModel> _users;
        public IEnumerable<UserViewModel> Users => _users;
        public ICommand ImportContacts { get; }
        public ICommand DeleteContacts { get; }
        public ICommand ShowCallHistory { get; }
        public ICommand Delete { get; }
        public ICommand Call { get; }

    }
}
