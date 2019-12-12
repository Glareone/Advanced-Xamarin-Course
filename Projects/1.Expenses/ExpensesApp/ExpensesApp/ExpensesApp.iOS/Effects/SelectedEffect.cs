using System.ComponentModel;
using ExpensesApp.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// Only Group name here (first part before dot, which comes from SelectedEffect.cs file in .net Standard library project)
[assembly: ResolutionGroupName("ExpensesApp")]
// unique name comes from the second part after dot.
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.iOS.Effects
{
    public class SelectedEffect: PlatformEffect
    {
        private UIColor _selectedColor;

        protected override void OnAttached()
        {
            _selectedColor = new UIColor(176/255, 152/255, 164/255, 255/255);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsFocused")
            {
                if (Control.BackgroundColor != _selectedColor)
                {
                    Control.BackgroundColor = _selectedColor;
                }
                else
                {
                    Control.BackgroundColor = UIColor.White;
                }
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}