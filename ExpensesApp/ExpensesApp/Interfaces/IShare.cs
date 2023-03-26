using System.Threading.Tasks;

namespace ExpensesApp.Interfaces
{
    // Interfaz que implementará cada plataforma y que mediante DependencyService en el Shared Project llamaremos
    public interface IShare
    {
        Task Show(string title, string message, string filePath);
    }
}
