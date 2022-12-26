using ContactManager.Stores;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigateStore;
        private readonly Func<ViewModelBase> _createViewModel;
        private readonly  Func<object?, ViewModelBase>? _createViewModelWithProps;



        public NavigationService(NavigationStore navigateStore, Func<ViewModelBase> createViewModel)
        {
            _navigateStore = navigateStore;
            _createViewModel = createViewModel;
        }
        public NavigationService(NavigationStore navigateStore, Func<object?, ViewModelBase> createViewModelWithProps)
        {
            _navigateStore = navigateStore;
            _createViewModelWithProps = createViewModelWithProps;
        }


        public void Navigate()
        {
            _navigateStore.CurrentViewModel = _createViewModel();
        }

        public void Navigate(object? parameter)
        {
            _navigateStore.CurrentViewModel = _createViewModelWithProps(parameter);
        }

    }
}
