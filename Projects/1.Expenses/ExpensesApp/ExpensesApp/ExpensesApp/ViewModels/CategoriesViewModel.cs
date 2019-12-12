using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using PCLStorage;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {
        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpense> CategoryExpenses { get; set; }

        public Command ExportCommand { get; set; }

        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpenses = new ObservableCollection<CategoryExpense>();

            ExportCommand = new Command(ShareReport);

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

        public class CategoryExpense
        {
            public string Category { get; set; }

            public float ExpensesPercentage { get; set; }
        }

        // Write reports to the file with platform specific logic located in Share classes inside droid and iOS projects
        public async void ShareReport()
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var txtFile = await reportsFolder.CreateFileAsync("reports.txt", CreationCollisionOption.ReplaceExisting);

            using (StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                foreach (var categoryExpense in CategoryExpenses)
                {
                    sw.WriteLine($"{categoryExpense.Category} - {categoryExpense.ExpensesPercentage}");
                }
            }

            var shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Expense Reports", "Here is your expense report", txtFile.Path);
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
    }
}