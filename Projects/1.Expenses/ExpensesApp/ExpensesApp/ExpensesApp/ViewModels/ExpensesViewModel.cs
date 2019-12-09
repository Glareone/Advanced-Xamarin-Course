using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ExpensesApp.Models;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public ExpensesViewModel()
        {
            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = Expense.GetExpenses().ToList();

            Expenses.Clear();

            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }
    }
}
