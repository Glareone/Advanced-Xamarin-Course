using System;
using CoreGraphics;
using ExpensesApp.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.iOS.CustomRenderers
{
    // Custom renderer which replace default renderer on CategoriesPage for IOS devices.
    // It makes progress bar a bit wider
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            // Change the progress bar color is it's nan.
            // and little differentiation by colors
            if (double.IsNaN(e.NewElement.Progress))
            {
                Control.ProgressTintColor = Color.FromHex("#00B9AE").ToUIColor();
            }
            else if (e.NewElement.Progress < 0.3)
            {
                Control.ProgressTintColor = Color.FromHex("#00BDD5").ToUIColor();
            }
            else if (e.NewElement.Progress < 0.7)
            {
                Control.ProgressTintColor = Color.FromHex("#B3316A").ToUIColor();
            }

            LayoutSubviews();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            float x = 1.0f;
            float y = 4.0f;

            CGAffineTransform transform = CGAffineTransform.MakeScale(x, y);
            Transform = transform;
        }
    }
}
