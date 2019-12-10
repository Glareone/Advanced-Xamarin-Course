using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        private readonly CategoriesViewModel _viewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            // get certain viewModel which described in Resource block and used directly in xaml file.
            // IT MUST BE AFTER INITIALIZE COMPONENT. OTHERWISE Resources is empty.
            _viewModel = Resources["viewModel"] as CategoriesViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel?.GetExpensesPerCategory();
        }
    }
}