using ContactManager.Models;
using ContactManager.Services;
using ContactManager.Stores;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            JsonService jsonService = new JsonService(homeDir);


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
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact("gandon", "gandon", "gandon"));
            contacts.Add(new Contact("gandon", "gandon", "gandon"));
            contacts.Add(new Contact("gandon", "gandon", "gandon"));
            return new HomeViewModel(contacts);
        }
    }
}
