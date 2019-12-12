using System.Threading.Tasks;
using Android.Content;
using Android.Support.V4.Content;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using Plugin.CurrentActivity;
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
            var intent = new Intent(Intent.ActionSend);

            // Exception - calling startActivity From outside of an Activity (Issue Fix)
            //intent.AddFlags(ActivityFlags.NewTask);
            //intent.AddFlags(ActivityFlags.MultipleTask);
            //Android.App.Application.Context.StartActivity(intent);

            // "image/png", "text/pdf"
            intent.SetType("text/plain");
            // Forms.Context.ApplicationContext is deprecated
            // that's why CrossCurrentActivity.Current.AppContext is used
            // authority - name of your package + .provider. It is declared in androidManifest file.
            var documentUri = FileProvider.GetUriForFile(CrossCurrentActivity.Current.AppContext,
                "com.companyname.expensesapp.fileprovider", new Java.IO.File(filePath));

            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);

            var chooserIntent = Intent.CreateChooser(intent, title);

            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(chooserIntent);

            return Task.CompletedTask;
        }
    }
}