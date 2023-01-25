﻿using System;
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

namespace WiredBrainCoffee.CustomersApp.View
{
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //var colume = (int) customerListGrid.GetValue(Grid.ColumnProperty);
            // var newColume = colume == 0 ? 2 : 0;
            // customerListGrid.SetValue(Grid.ColumnProperty, newColume);
            var colume = Grid.GetColumn(customerListGrid);
            var newColume = colume == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, newColume);
        }
    }
}