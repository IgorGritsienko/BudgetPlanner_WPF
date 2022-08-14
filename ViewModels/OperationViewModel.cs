using BudgetPlanner_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BudgetPlanner_WPF.Models.Operation;

namespace BudgetPlanner_WPF.ViewModels
{
    public class OperationViewModel : BaseViewModel
    {
        public string OperationType { get; set; }
        public int Sum { get; set; }
        public string Category { get; set; }
        public string? Comment { get; set; }

        public OperationViewModel() { }

    }
}
