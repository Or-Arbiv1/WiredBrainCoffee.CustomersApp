using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{

    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSideEnum _navigationSide;


        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }

        public DelegateCommand DeleteCommand { get; }
        public NavigationSideEnum NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }


        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

    

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChange();

            }
        }

        public bool IsCustomerSelected()
        {
            return SelectedCustomer is not null;
        }

        public async Task LoadAsync()
        {
            if (Customers.Any()) { return; }
            var customers = await _customerDataProvider.GetAllAsync();
            if (customers == null) { return; }
            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }

        }

        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModelCustomer = new CustomerItemViewModel(customer);
            Customers.Add(viewModelCustomer);
            SelectedCustomer = viewModelCustomer;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSideEnum.Left? NavigationSideEnum.Right : NavigationSideEnum.Left;
        }

        private void Delete(object? parameter)
        {
             if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private bool CanDelete(object? parameter)
        {
           return SelectedCustomer is not null;
        }

        public enum NavigationSideEnum
        {
            Left,Right 
        }
    }
}
