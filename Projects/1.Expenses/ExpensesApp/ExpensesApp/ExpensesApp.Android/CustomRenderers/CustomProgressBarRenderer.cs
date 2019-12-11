using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ExpensesApp.Droid.CustomRenderers;

// Necessary attribute
[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    // Custom renderer which replace default renderer on CategoriesPage for IOS devices.
    // It makes progress bar a bit wider
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            // Change the progress bar color is it's nan.
            // and little differentiation by colors

            // pay attention. Control here has a different type and different methods rather than Control from IOS Renderer
            if (double.IsNaN(e.NewElement.Progress))
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#00B9AE").ToAndroid());
            }
            else if (e.NewElement.Progress < 0.3)
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#00BDD5").ToAndroid());
            }
            else if (e.NewElement.Progress < 0.7)
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#B3316A").ToAndroid());
            }

            Control.ScaleY = 3.0f;
        }
    }
}