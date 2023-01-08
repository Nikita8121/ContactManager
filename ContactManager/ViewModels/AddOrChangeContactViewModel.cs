using ContactManager.Annotations;
using ContactManager.Commands;
using ContactManager.Models;
using ContactManager.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManager.ViewModels
{
    public class AddOrChangeContactViewModel : ViewModelBase
    {
        private string _name;
        private string _email;
        private string _phoneNumber;
        private string _title;
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public bool CanCreateContact => Contact.Validate(new Contact(_name, _email, _phoneNumber));


        public AddOrChangeContactViewModel(ContactsBook contactsBook, NavigationService homeViewNavigationSevice)
        {
            SubmitCommand = new AddContactCommand(this, contactsBook, homeViewNavigationSevice);
            CancelCommand = new NavigateCommand(homeViewNavigationSevice);
            Title = "Add contact";
        }

        public AddOrChangeContactViewModel(ContactsBook contactsBook, NavigationService homeViewNavigationSevice, string name)
        {
            Contact currentContact = contactsBook.GetContactByName(name);

            Name = currentContact.Name;
            Email = currentContact.Email ?? string.Empty;
            PhoneNumber = currentContact.PhoneNumber;

            SubmitCommand = new ChangeContactCommand(this, contactsBook, homeViewNavigationSevice, name);
            CancelCommand = new NavigateCommand(homeViewNavigationSevice);

            Title = "Change contact";
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }

        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters.")]
        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                ValidateProperty(value, "Name");
            }
        }
        [EmailOptional]
        public string Email
        {
            get { return _email; }
            set {
                _email = value;
                OnPropertyChanged(nameof(Email));
                ValidateProperty(value, "Email");
            }
        }

        [Required(ErrorMessage = "Must not be empty.")]
        [PhoneNumberCustom(ErrorMessage = "Fill up your phone number")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
                ValidateProperty(value, "PhoneNumber");  
            }
        }



        private void ValidateProperty<T>(T value, string name)
        {
            Console.WriteLine(value);
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

    }
}
