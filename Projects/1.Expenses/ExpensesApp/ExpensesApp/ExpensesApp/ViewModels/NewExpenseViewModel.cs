using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExpensesApp.Annotations;
using ExpensesApp.Models;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpenseViewModel: INotifyPropertyChanged
    {
        private string expenseName;
        public string ExpenseName
        {
            get => expenseName;
            set
            {
                expenseName = value;
                OnPropertyChanged(nameof(ExpenseName));
            }
        }

        private string expenseDescription;
        public string ExpenseDescription
        {
            get => expenseDescription;
            set
            {
                expenseDescription = value;
                OnPropertyChanged(nameof(ExpenseDescription));
            }
        }

        private float expenseAmount;
        public float ExpenseAmount
        {
            get => expenseAmount;
            set
            {
                expenseAmount = value;
                OnPropertyChanged(nameof(ExpenseAmount));
            }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get => expenseDate;
            set
            {
                expenseDate = value;
                OnPropertyChanged(nameof(ExpenseDate));
            }
        }

        private string expenseCategory;
        public string ExpenseCategory
        {
            get => expenseCategory;
            set
            {
                expenseCategory = value;
                OnPropertyChanged(nameof(ExpenseCategory));
            }
        }

        public Command SaveExpense { get; set; }

        public NewExpenseViewModel()
        {
            SaveExpense = new Command(InsertExpense);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense()
        {
            var expense = new Expense
            {
                Amount = ExpenseAmount,
                Name = ExpenseName,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            var count = Expense.InsertExpense(expense);

            if (count > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "No items to be inserted", "Ok");
            }
        }
    }
}
