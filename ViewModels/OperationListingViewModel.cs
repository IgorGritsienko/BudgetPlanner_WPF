using BudgetPlanner_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static BudgetPlanner_WPF.Models.Operation;

namespace BudgetPlanner_WPF.ViewModels
{
    public class OperationListingViewModel : BaseViewModel
    {
        //BugdetPlan _bugdetPlanner;

        private readonly ObservableCollection<OperationViewModel> _operations;
        public IEnumerable<OperationViewModel> Operations => _operations;


        private readonly List<string> opTypesToString;
        public List<string> OpTypesToString => opTypesToString;

        public ICommand AddReservationCommand { get; }

        public OperationListingViewModel()
        {
            //_bugdetPlanner = budgetPlan;
            _operations = new ObservableCollection<OperationViewModel>();
            opTypesToString = new List<string>();


            GetRecords();
        }

        public void GetRecords()
        {
            _operations.Clear();

            try
            {
                foreach (OperationTypes opType in Enum.GetValues(typeof(OperationTypes)))
                {
                    opTypesToString.Add(opType.ToString());
                }

                //foreach (Operation operation in _bugdetPlanner.GetRecords())
                //{
                //    OperationViewModel operationViewModel = new OperationViewModel(operation);
                //    _operations.Add(operationViewModel);
                //}
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Bad data in database.", "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
