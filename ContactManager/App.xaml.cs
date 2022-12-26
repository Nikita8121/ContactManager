using ContactManager.Models;
using ContactManager.Services;
using ContactManager.Services.ContactsProvider;
using ContactManager.Services.ContactsCreator;
using ContactManager.Stores;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ContactManager.Services.ContactsUpdater;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ContactsBook _contactsBook;

        public App()
        {
            string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            JsonService jsonService = new JsonService($"{homeDir}/contactBook.json");

            IContactsProvider contactsProvider = new DataBaseContactProvider(jsonService);
            IContactsCreator contactsCreator = new DataBaseContactsCreator(jsonService);
            IContactsUpdater contactsUpdater = new DataBaseContactsUpdater(jsonService);

            _contactsBook = new ContactsBook(contactsProvider, contactsCreator, contactsUpdater);


            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            _navigationStore.CurrentViewModel = CreateHomeViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private HomeViewModel CreateHomeViewModel()
        {
            Dictionary<string, NavigationService> dictionaryOfNavigationServices = new Dictionary<string, NavigationService>
            {
                {"CreateAddContactViewModel", new NavigationService(_navigationStore, CreateAddContactViewModel)},
                {"CreateChangeContactViewModel", new NavigationService(_navigationStore, CreateChangeContactViewModel)}
            };
            return new HomeViewModel(_contactsBook, dictionaryOfNavigationServices);
        }

        private AddOrChangeContactViewModel CreateAddContactViewModel()
        {
            return new AddOrChangeContactViewModel(_contactsBook, new NavigationService(_navigationStore, CreateHomeViewModel));
        }

        private AddOrChangeContactViewModel CreateChangeContactViewModel(object param)
        {
            return new AddOrChangeContactViewModel(_contactsBook, new NavigationService(_navigationStore, CreateHomeViewModel), (string)param);
        }
    }
}
