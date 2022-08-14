using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.Models
{
    public class Operation
    {
        public enum OperationTypes
        {
            Income,
            Expense
        }

        public enum IncomeCategories
        {
            Salary,
            Debt_repayment,
            Dividends
        }

        public enum ExpenseCategories
        {
            Entertainment,
            Food,
            Transport
        }

        public OperationTypes OperationType { get; set; }

        public int Sum { get; set; }

        public IncomeCategories IncomeCategory { get; set; }

        public ExpenseCategories ExpenseCategory { get; set; }

        public string? Comment { get; set; }

        public Operation() { }

        public Operation(OperationTypes operationType, int sum, IncomeCategories incomeCategories, string comment)
        {
            OperationType = operationType;
            Sum = sum;
            IncomeCategory = incomeCategories;
            Comment = comment;
        }

        public Operation(OperationTypes operationType, int sum, ExpenseCategories expenseCategory, string comment)
        {
            OperationType = operationType;
            Sum = sum;
            ExpenseCategory = expenseCategory;
            Comment = comment;
        }
    }
}
