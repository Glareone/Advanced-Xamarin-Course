using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        private readonly ExpensesViewModel _viewModel;

        public ExpensesPage()
        {
            InitializeComponent();
            // get certain viewModel which described in Resource block and used directly in xaml file.
            // IT MUST BE AFTER INITIALIZE COMPONENT. OTHERWISE Resources is empty.
            _viewModel = Resources["viewModel"] as ExpensesViewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel?.GetExpenses();
        }
    }
}