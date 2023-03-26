using ExpensesApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using static ExpensesApp.ViewModels.NewExpenseVM;

namespace ExpensesApp.ViewModels
{
    public class NewExpenseVM : BaseViewModel
    {
        private string expenseName;
        public string ExpenseName
        {
            get => expenseName;
            set => SetProperty(ref expenseName, value);
        }

        private string expenseDescription;
        public string ExpenseDescription
        {
            get => expenseDescription;
            set => SetProperty(ref expenseDescription, value);
        }

        private float expenseAmount;
        public float ExpenseAmount
        {
            get => expenseAmount;
            set => SetProperty(ref expenseAmount, value);
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get => expenseDate;
            set => SetProperty(ref expenseDate, value);
        }

        private string expenseCategory;
        public string ExpenseCategory
        {
            get => expenseCategory;
            set => SetProperty(ref expenseCategory, value);
        }

        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<ExpensesStatus> ExpenseStatus { get; set; }

        public ICommand SaveExpenseCommand { get; }

        public NewExpenseVM()
        {
            Categories = new ObservableCollection<string>();
            ExpenseStatus = new ObservableCollection<ExpensesStatus>();
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(InsertExpense);
            GetCategories();
        }

        // Se llamará desde el VM -> newExpenseVM.InsertExpense
        public async void InsertExpense()
        {
            var vm = this;
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            int response = Expense.InsertExpense(expense);
            if (response > 0)
                await Application.Current.MainPage.Navigation.PopAsync();
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "Ok");
        }

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

        public void GetExpenseStatus()
        {
            ExpenseStatus.Clear();
            ExpenseStatus.Add(new ExpensesStatus
            {
                Name = "Random",
                Status = true
            });
            ExpenseStatus.Add(new ExpensesStatus
            {
                Name = "Random 2",
                Status = true
            });
            ExpenseStatus.Add(new ExpensesStatus
            {
                Name = "Random 3",
                Status = false
            });
        }

        public class ExpensesStatus
        {
            public string Name { get; set; }
            public bool Status { get; set; }            
        }
    }
}
