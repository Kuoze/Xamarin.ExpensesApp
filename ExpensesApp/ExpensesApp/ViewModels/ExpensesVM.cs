using ExpensesApp.Models;
using ExpensesApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesVM
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public ICommand AddExpenseCommand { get; }

        public ExpensesVM()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);
            GetExpenses();
        }

        public void GetExpenses()
        {
            var expenses = Expense.GetExpenses();
            Expenses.Clear();
            foreach(var exp in expenses)
            {
                Expenses.Add(exp);
            }
        }

        public void AddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }        
    }
}
