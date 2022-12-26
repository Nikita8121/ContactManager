using ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;


        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            if (parameter == null)
            {
                _navigationService.Navigate();
            }
            else
            {
                _navigationService.Navigate(parameter);
            }
        }
    }
}
