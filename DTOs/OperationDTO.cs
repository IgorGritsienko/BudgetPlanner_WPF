using BudgetPlanner_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.DTOs
{
    public class OperationDTO
    {
        private OperationViewModel _operationViewModel;
        public string OperationType => _operationViewModel.OperationType;
        public int Sum => _operationViewModel.Sum;
        public string Category => _operationViewModel.Category;
        public string? Comment => _operationViewModel.Comment;

        public OperationDTO(OperationViewModel operationViewModel)
        {
            _operationViewModel = operationViewModel;
        }
        public OperationDTO(string operationType, int sum, string category, string comment)
        {
            _operationViewModel = new OperationViewModel(operationType, sum, category, comment);
        }
    }
}
