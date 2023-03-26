using ExpensesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        private readonly NewExpenseVM vm;

        public NewExpensePage()
        {
            InitializeComponent();
            vm = Resources["vm"] as NewExpenseVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.GetExpenseStatus();

            int idx = 0;
            var section = new TableSection("Statuses");
            foreach(var es in vm.ExpenseStatus)
            {
                var cell = new SwitchCell() { Text = es.Name };
                Binding binding = new Binding()
                {
                    Source = vm.ExpenseStatus[idx], // No podemos vincularlo con 'es' porque es una variable que solo está en C# no en XAML
                    Path = "Status",
                    Mode = BindingMode.TwoWay
                };
                cell.SetBinding(SwitchCell.OnProperty, binding);
                section.Add(cell);                
                idx++;
            }
            mTableView.Root.Add(section);
        }
    }
}