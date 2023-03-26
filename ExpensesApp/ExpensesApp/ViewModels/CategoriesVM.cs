using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using PCLStorage;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }

        public ICommand ExportCommand { get; set; }

        public CategoriesVM()
        {
            ExportCommand = new Command(ShareReport);
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();

            GetCategories();
            GetExpensesPerCategory();
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

        public void GetExpensesPerCategory()
        {
            CategoryExpensesCollection.Clear();
            foreach (string c in Categories)
            {
                var expenses = Expense.GetExpenses(c);
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);
                CategoryExpensesCollection.Add(new CategoryExpenses
                {
                    Category = c,
                    ExpensesPercentage = expensesAmountInCategory / Expense.TotalExpensesAmount()
                });
            }
        }

        public async void ShareReport()
        {
            // Create a TXT file ( Install NuGet Package -> PCL Storage)
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var txtFile = await reportsFolder.CreateFileAsync("reports.txt", CreationCollisionOption.ReplaceExisting);
            using(StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                foreach (var cat in CategoryExpensesCollection)
                {
                    sw.WriteLine($"{cat.Category} - {cat.ExpensesPercentage:p}"); // :p en %
                }               
            }           

            IShare shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Expense Report", "Here is your expenses report", txtFile.Path);
        }
    }

    public class CategoryExpenses
    {
        public string Category { get; set; }
        public float ExpensesPercentage { get; set; }       
    }
}
