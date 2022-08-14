using BudgetPlanner_WPF.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner_WPF.DbContexts
{
    public class OperationDbContext : DbContext
    {
        public OperationDbContext(DbContextOptions options) : base(options)
        {
        }

        public OperationDbContext() => Database.EnsureCreated();
        public DbSet<OperationDTO> Operations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=operations.db");
        }
    }
}
    
