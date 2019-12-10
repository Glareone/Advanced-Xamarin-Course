using System.Collections.ObjectModel;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();
            GetCategories();
        }

        public ObservableCollection<string> Categories { get; set; }

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