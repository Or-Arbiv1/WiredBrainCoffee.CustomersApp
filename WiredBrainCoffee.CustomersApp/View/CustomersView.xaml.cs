using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp.View
{
    public partial class CustomersView : UserControl
    {
        private CustomersViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext= _viewModel;
            Loaded += CustomersView_LoadedAsync;
        }

        private async void CustomersView_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        //NO NEED ANYMORE. WE HAVE COMMAND INSTEAD
        //private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        //{
        //    //var colume = (int) customerListGrid.GetValue(Grid.ColumnProperty);
        //    // var newColume = colume == 0 ? 2 : 0;
        //    // customerListGrid.SetValue(Grid.ColumnProperty, newColume);

        //    _viewModel.
        //}

        //private void ButtonAdd_click(object sender, RoutedEventArgs e)
        //{
        //    _viewModel.Add();
        //}
    }
}
