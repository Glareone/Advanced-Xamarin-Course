using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Environment = System.Environment;
using Platform = Xamarin.Essentials.Platform;

namespace ExpensesApp.Droid
{
    [Activity(Label = "ExpensesApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            var dbName = "expenses_db.db3";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var fullPath = Path.Combine(folderPath, dbName);

            // Another approach to use DI registration. Other one - is use [assembly: Dependency attribute]
            //DependencyService.Register<IShare, Share>();
            // OR
            //DependencyService.Register<Share>();

            LoadApplication(new App(fullPath));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}