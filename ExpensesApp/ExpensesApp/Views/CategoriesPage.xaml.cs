using ExpensesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        private readonly CategoriesVM vm;

        public CategoriesPage()
        {
            InitializeComponent();
            // Obtenemos el view model de los recursos del XAML
            vm = Resources["vm"] as CategoriesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.GetExpensesPerCategory();                
        }
    }
}