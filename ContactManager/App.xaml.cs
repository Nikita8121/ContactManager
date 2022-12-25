using ContactManager.Models;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = CreateHomeViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private HomeViewModel CreateHomeViewModel()
        {
            List<User> users = new List<User>();
            users.Add(new User("gandon", "gandon", "gandon"));
            users.Add(new User("gandon", "gandon", "gandon"));
            users.Add(new User("gandon", "gandon", "gandon"));
            return new HomeViewModel(users);
        }
    }
}
