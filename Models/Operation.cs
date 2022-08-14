using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.Models
{
    public class Operation
    {
        public enum OperationTypes
        {
            [Display(Name = "Доход")]
            Income,
            [Display(Name = "Расход")]
            Expense
        }

        public enum IncomeCategories
        {
            [Display(Name = "Зарплата")]
            Salary,
            [Display(Name = "Возврат долга")]
            Debt_repayment,
            [Display(Name = "Дивиденды")]
            Dividends
        }

        public enum ExpenseCategories
        {
            [Display(Name = "Развлечение")]
            Entertainment,
            [Display(Name = "Еда")]
            Food,
            [Display(Name = "Транспорт")]
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
