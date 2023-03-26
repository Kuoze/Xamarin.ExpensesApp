using ExpensesApp.Models;
using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp.Behaviours
{
    // Para navegar en vez de usar el evento ItemSelected
    public class ListViewBehavior : Behavior<ListView>
    {
        //private ListView _listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            //_listView = bindable;
            //_listView.ItemSelected += _listView_ItemSelected;
            bindable.ItemSelected += OnListViewItemSelected;
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Expense selectedExpense = _listView.SelectedItem as Expense;
            var selectedExpense = e.SelectedItem as Expense;
            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(selectedExpense));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnListViewItemSelected;
        }
    }
}
