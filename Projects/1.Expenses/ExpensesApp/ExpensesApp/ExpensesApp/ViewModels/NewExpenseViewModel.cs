using System;
using System.Collections.ObjectModel;
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

        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }

        public Command SaveExpense { get; set; }

        public NewExpenseViewModel()
        {
            ExpenseDate = DateTime.Today;
            Categories = new ObservableCollection<string>();
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            SaveExpense = new Command(InsertExpense);

            GetCategories();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense()
        {
            // this property to test how Statuses work using rough c# code approach.
            var vm = this;

            var expense = new Expense
            {
                Amount = ExpenseAmount,
                Name = ExpenseName,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription,
                // and there you could assign "Statuses" (after creating this prop in model). their values are located inside vm.
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

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        // Demo how to bind async data to form.
        // TableView (in xaml) doesn't contain ItemSource property
        public void GetExpenseStatus()
        {
            ExpenseStatuses.Clear();

            // let's imagine that this code is pseudo-async.
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random 2",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random 3",
                Status = false
            });
        }

        public class ExpenseStatus {
            public string Name { get; set; }
            public bool Status { get; set; }
        }
    }
}
