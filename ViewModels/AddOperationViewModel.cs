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
    public class AddOperationViewModel : BaseViewModel
    {
        private ObservableCollection<string> opTypes = new ObservableCollection<string>();

        private ObservableCollection<string> categoryTypesToString = new ObservableCollection<string>();

        private Planner _planner;

        public ObservableCollection<string> OpTypesList
        {
            get
            {
                return opTypes;
            }
            set
            {
                opTypes = value;
                OnPropertyChanged(nameof(OpTypesList));
            }
        }

        private int _sum;
        public int Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                _sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }

        public ObservableCollection<string> CategoryList
        {
            get
            {
                return categoryTypesToString;
            }
            set
            {
                categoryTypesToString = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }

        private string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                UpdateCategory();
            }
        }


        private string _selectedCategory;
        public string SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      DisplayName.enum_dict.TryGetValue(SelectedItem, out string opTypeString);
                      Enum.TryParse(opTypeString, out OperationTypes opType);
                      Operation operation;
                      if (opType is OperationTypes.Income)
                      {
                          DisplayName.enum_dict.TryGetValue(SelectedCategory, out string income_str);
                          Enum.TryParse(income_str, out IncomeCategories income);

                          operation = new Operation()
                          {
                              OperationType = opType,
                              Sum = Sum,
                              IncomeCategory = income,
                              Comment = Comment
                          };
                      }
                      else
                      {
                          DisplayName.enum_dict.TryGetValue(SelectedItem, out string expense_str);
                          Enum.TryParse(expense_str, out ExpenseCategories expense);

                          operation = new Operation()
                          {
                              OperationType = opType,
                              Sum = Sum,
                              ExpenseCategory = expense,
                              Comment = Comment
                          };

                      }
                      _planner.AddOperation(operation);
                      MessageBox.Show("Операция зафиксирована.", "Успешно.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                  },
                  (obj) => Sum > 0 && SelectedCategory != null));
            }
        }

        public AddOperationViewModel(Planner planner)
        {
            _planner = planner;
            opTypes = new ObservableCollection<string>();
            foreach (OperationTypes opType in Enum.GetValues(typeof(OperationTypes)))
            {
                opTypes.Add(DisplayName.GetDisplayName(opType));
            }
        }

        public void UpdateCategory()
        {
            categoryTypesToString.Clear();
            DisplayName.enum_dict.TryGetValue(SelectedItem, out string value);
            if (value == "Income")
            {
                foreach (IncomeCategories catType in Enum.GetValues(typeof(IncomeCategories)))
                {
                    categoryTypesToString.Add(DisplayName.GetDisplayName(catType));
                }
            }
            else
            {
                foreach (ExpenseCategories catType in Enum.GetValues(typeof(ExpenseCategories)))
                {
                    categoryTypesToString.Add(DisplayName.GetDisplayName(catType));
                }
            }
        }
    }
}
