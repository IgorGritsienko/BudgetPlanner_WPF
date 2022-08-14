using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModel;
        public BaseViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                OnPropertyChanged(nameof(ViewModel));
            }
        }

        public MainViewModel()
        {
            _viewModel = new OperationListingViewModel();
        }
    }
}
