using BudgetPlanner_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.DTOs
{
    public class OperationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string OperationType { get; set; }
        public int Sum { get; set; }
        public string Category { get; set; }
        public string? Comment { get; set; }
    }
}
