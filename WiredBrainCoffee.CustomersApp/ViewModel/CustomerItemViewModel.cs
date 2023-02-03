using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer _model;
        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }

        public int Id { get; }


        public string? FirstName
        {
            get { return _model.FirstName; }
            set
            {
                _model.FirstName = value;
                RaisePropertyChanged();
            }
        }


        public string? LastName
        {
            get { return _model.LastName; }
            set
            {
                _model.LastName = value;
                RaisePropertyChanged();
            }
        }


        public bool IsDeveloper
        {
            get { return _model.IsDeveloper; }
            set
            {
                _model.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }

    }
}
