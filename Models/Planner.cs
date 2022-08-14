using BudgetPlanner_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.Models
{
    public class Planner
    {
        private readonly IDataBaseProvider _dataBaseProvider;

        public Planner(IDataBaseProvider dataBaseProvider)
        {
            _dataBaseProvider = dataBaseProvider;
        }

        public IEnumerable<Operation> GetRecords()
        {
            return _dataBaseProvider.GetRecords();
        }

        public void AddOperation(Operation operation)
        {
            _dataBaseProvider.AddRecord(operation);
        }
    }
}
