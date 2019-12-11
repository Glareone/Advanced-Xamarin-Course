using System.Collections.ObjectModel;
using System.Linq;
using ExpensesApp.Models;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {
        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpense> CategoryExpenses { get; set; }

        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpenses = new ObservableCollection<CategoryExpense>();
            GetCategories();
            GetExpensesPerCategory();
        }

        public void GetExpensesPerCategory()
        {
            CategoryExpenses.Clear();
            var totalExpensesAmount = Expense.GetTotalExpensesAmount();
            foreach (var category in Categories)
            {
                var expenses = Expense.GetExpenses(category);
                var expensesAmountInCategory = expenses.Sum(e => e.Amount);

                var categoryExpense = new CategoryExpense
                {
                    Category = category,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };

                CategoryExpenses.Add(categoryExpense);
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

        public class CategoryExpense
        {
            public string Category { get; set; }

            public float ExpensesPercentage { get; set; }
        }
    }
}