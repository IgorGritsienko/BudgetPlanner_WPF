using BudgetPlanner_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.Services
{
    public interface IDataBaseProvider
    {
        void AddRecord(Operation operation);
        IEnumerable<Operation> GetRecords();
    }
}
