using ExpensesApp.Models;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailsVM : BaseViewModel
    {
        private Expense _expense;
        public Expense Expense 
        {
            get => _expense;
            set => SetProperty(ref _expense, value);
        }

        public ExpenseDetailsVM()
        {

        }
    }
}
