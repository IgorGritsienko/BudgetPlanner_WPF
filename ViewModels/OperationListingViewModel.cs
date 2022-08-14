using BudgetPlanner_WPF.Commands;
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
        private Planner _planner;

        private readonly ObservableCollection<OperationViewModel> _operations;
        public IEnumerable<OperationViewModel> Operations => _operations;

        public OperationListingViewModel(Planner planner)
        {
            _planner = planner;
            _operations = new ObservableCollection<OperationViewModel>();

            GetRecords();
        }

        public void GetRecords()
        {
            _operations.Clear();

            try
            {
                foreach (Operation opType in _planner.GetRecords())
                {
                    _operations.Add(ToOperationVM(opType));
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Bad data in database.", "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static OperationViewModel ToOperationVM(Operation operation)
        {
            string operType = DisplayName.GetDisplayName(operation.OperationType);
            string categ;
            if (operType == "Income")
            {            
                   categ = DisplayName.GetDisplayName(operation.IncomeCategory);
            }
            else
            {
                categ = DisplayName.GetDisplayName(operation.ExpenseCategory);
            }
            return new OperationViewModel()
            {
                OperationType = operType,
                Sum = operation.Sum,
                Category = categ,
                Comment = operation.Comment,
            };
        }
    }
}
