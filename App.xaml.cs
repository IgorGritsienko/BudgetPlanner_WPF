using BudgetPlanner_WPF.DbContexts;
using BudgetPlanner_WPF.Models;
using BudgetPlanner_WPF.Services;
using BudgetPlanner_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetPlanner_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly Planner _planner;
        App()
        {
            IDataBaseProvider dataBaseProvider = new DataBaseProvider();
            _planner = new Planner(dataBaseProvider);
        }

        protected override void OnStartup(StartupEventArgs e)
        {


            using (OperationDbContext db = new OperationDbContext())
            {

            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_planner)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
