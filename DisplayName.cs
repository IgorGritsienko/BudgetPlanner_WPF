using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF
{
    public static class DisplayName
    {
        public static readonly Dictionary<string, string> enum_dict = new Dictionary<string, string>()
        {
            { "Доход", "Income" },
            { "Расход", "Expense" },
            { "Зарплата", "Salary" },
            { "Возврат долга", "Dept_repayment" },
            { "Дивиденды", "Dividends" },
            { "Развлечение", "Entertainment" },
            { "Еда", "Food" },
            { "Транспорт", "Transport" },
        };

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()?
                            .GetMember(enumValue.ToString())?
                            .First()?
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name;
        }   
        

    }

}
