﻿using ExpensesApp.Models;
using ExpensesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailsPage : ContentPage
    {
        public ExpenseDetailsVM ViewModel;

        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as ExpenseDetailsVM;
            ViewModel.Expense = expense;            
        }
    }
}