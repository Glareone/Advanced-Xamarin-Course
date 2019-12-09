﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ExpensesApp.Models;
using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public Command AddExpenseCommand { get; set; }

        public ExpensesViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);
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

        public void AddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }
    }
}
