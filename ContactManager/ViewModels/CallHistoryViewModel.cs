using ContactManager.Commands;
using ContactManager.Models;
using ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModels
{
    public class CallHistoryViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CallViewModel> _calls;
        private string _title;
        public IEnumerable<CallViewModel> Calls => _calls;
        public bool HasCalls => _calls.Any();

        public ICommand BackCommand { get; }

        public CallHistoryViewModel(ContactsBook contactsBook, NavigationService homeViewNavigationSevice, string contactName)
        {
            _calls = new ObservableCollection<CallViewModel>();
            Initialize(contactsBook.GetContactsCallsByName(contactName));

            _calls.CollectionChanged += OnCallsChanged;

            BackCommand = new NavigateCommand(homeViewNavigationSevice);

            Title = $"Name: {contactName}";
        }


        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private void Initialize(List<Call> callsList)
        {
            _calls.Clear();

            foreach (Call call in callsList)
            {
                _calls.Add(new CallViewModel()
                {
                    callDate = call.callDate
                });;
            }
        }

        private void OnCallsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasCalls));
        }
    }
}
