using Android.Content;
using Android.Net;
using AndroidX.Core.Content;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.Droid.Dependencies
{
    public class Share : IShare
    {
        public Task Show(string title, string message, string filePath)
        {
            // Requerimos permisos de lectura y escritura (External storage)

            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain"); // txt file // image/png | application/pdf ,...

            // Crear carpeta 'xml' dentro de Resources, con file_provider_paths (folder reports/)
            // Ir al manifest dentro de application tag poner el provider
            var documentUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, 
                "com.companyname.expensesapp.provider", new Java.IO.File(filePath));

            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);            

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission | ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(chooserIntent);
            //return Task.CompletedTask;
            return Task.FromResult(true);
        }

    }
}