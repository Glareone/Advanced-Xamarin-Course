using System.Threading.Tasks;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using Xamarin.Forms;

// DI Registration. 
// Another approach is use DependencyService.Register<IShare, Share>(); in MainActivity;
[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.Droid.Dependencies
{
    public class Share: IShare
    {
        public Task Show(string title, string message, string filePath)
        {
            return Task.CompletedTask;
        }
    }
}