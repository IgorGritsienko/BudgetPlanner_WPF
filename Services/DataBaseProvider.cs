using BudgetPlanner_WPF.DbContexts;
using BudgetPlanner_WPF.DTOs;
using BudgetPlanner_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BudgetPlanner_WPF.Models.Operation;

namespace BudgetPlanner_WPF.Services
{
    public class DataBaseProvider : IDataBaseProvider
    {
        public void AddRecord(Operation operation)
        {
            using (var context = new OperationDbContext())
            {
                OperationDTO operationDTO = ToOperationDTO(operation);
                context.Operations.Add(operationDTO);
                context.SaveChanges();
            }
        }

        private static OperationDTO ToOperationDTO(Operation operation)
        {
            string operType = operation.OperationType.ToString();
            string categ;
            if (operType == "Income")
            {
                categ = operation.IncomeCategory.ToString();
            }
            else
            {
                categ = operation.ExpenseCategory.ToString();

            }

            return new OperationDTO()
            {
                OperationType = operType,
                Sum = operation.Sum,
                Category = categ,
                Comment = operation.Comment,
            };
        }
       
        public IEnumerable<Operation> GetRecords()
        {
            using (var context = new OperationDbContext())
            {
                IEnumerable<OperationDTO> operationDTOs = context.Operations.ToList();

                return operationDTOs.Select(r => ToOperation(r));
            }
        }

        private static Operation ToOperation(OperationDTO operationDTO)
        {
            if (!Enum.TryParse(operationDTO.OperationType, out OperationTypes opType))
                throw new InvalidCastException("Cannot convert string to enum OperationTypes.");

            if (opType is OperationTypes.Income)
            {
                if (!Enum.TryParse(operationDTO.Category, out IncomeCategories income))
                    throw new InvalidCastException("Cannot convert string to enum IncomeCategories.");

                return new Operation
                {
                    OperationType = opType,
                    Sum = operationDTO.Sum,
                    IncomeCategory = income,
                    Comment = operationDTO.Comment
                };
            }
            else
            {
                if (!Enum.TryParse(operationDTO.Category, out ExpenseCategories expense))
                    throw new InvalidCastException("Cannot convert string to enum ExpenseCategories.");

                return new Operation
                {
                    OperationType = opType,
                    Sum = operationDTO.Sum,
                    ExpenseCategory = expense,
                    Comment = operationDTO.Comment
                };
            }
        }
    }
}
