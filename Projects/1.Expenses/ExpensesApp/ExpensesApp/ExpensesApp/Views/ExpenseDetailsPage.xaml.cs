using ExpensesApp.Models;
using ExpensesApp.ViewModels;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class ExpenseDetailsPage : ContentPage
    {
        readonly ExpenseDetailsViewModel ViewModel;
        public ExpenseDetailsPage()
        {
            InitializeComponent();
        }

        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();

            ViewModel = Resources["viewModel"] as ExpenseDetailsViewModel;
            ViewModel.Expense = expense;
        }
    }
}
