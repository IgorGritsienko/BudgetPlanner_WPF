using BudgetPlanner_WPF.Commands;
using BudgetPlanner_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetPlanner_WPF.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public BaseViewModel _viewModel;
        private Planner _planner;

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

        public ICommand DisplayAddOperationView
        {
            get
            {
                return new RelayCommand(action => ViewModel = new AddOperationViewModel(_planner));
            }
        }

        public ICommand DisplayOperationListingView
        {
            get
            {
                return new RelayCommand(action => ViewModel = new OperationListingViewModel(_planner));
            }
        }

        public MainViewModel(Planner planner)
        {
            _planner = planner;
            _viewModel = new OperationListingViewModel(_planner);
        }
    }
}
