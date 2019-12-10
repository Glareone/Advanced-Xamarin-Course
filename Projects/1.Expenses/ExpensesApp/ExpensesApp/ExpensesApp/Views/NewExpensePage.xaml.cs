using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        private readonly NewExpenseViewModel _viewModel;

        public NewExpensePage()
        {
            InitializeComponent();

            _viewModel = Resources["viewModel"] as NewExpenseViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Complex example with Statuses continues
            _viewModel.GetExpenseStatus();

            // Set Bindings to Statuses collection from c# code.
            var count = 0;
            foreach (var viewModelExpenseStatus in _viewModel.ExpenseStatuses)
            {
                var cell = new SwitchCell{ Text = viewModelExpenseStatus.Name };

                // create a new binding (similar to any "Binding" from xaml files)
                Binding binding = new Binding();
                // we set source binding to certain element, not for variable inside foreach loop.
                binding.Source = _viewModel.ExpenseStatuses[count];
                // Binding to property like in the next string: "{Binding Source={StaticResource viewModel}, Path=SaveExpense}"
                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;

                // Create a cell and set this binding between this cell and previously created binding
                cell.SetBinding(SwitchCell.OnProperty, binding);

                // Create a new TableSection on UI
                var section = new TableSection("Statuses");
                section.Add(cell);

                // Using x:Name from our TableView which is presented in xaml code - we add our section with a cell
                // To check how it works - set a breakpoint in InsertExpense method
                ExpenseTableView.Root.Add(section);

                count++;
            }
        }
    }
}