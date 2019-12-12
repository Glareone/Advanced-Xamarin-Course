using System;
using System.ComponentModel;
using Android.Graphics.Drawables;
using ExpensesApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

// Only Group name here (first part before dot, which comes from SelectedEffect.cs file in .net Standard library project)
[assembly: ResolutionGroupName("ExpensesApp")]
// unique name comes from the second part after dot.
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.Droid.Effects
{
    public class SelectedEffect: PlatformEffect
    {
        // it is an Android.Graphics.Color
        private Color _selectedColor;

        protected override void OnAttached()
        {
            _selectedColor = new Color(229, 235,234);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            // change color only on focus event (when IsFocused prop is changed)
            // we need try-catch block because Control.IsFocus is always false for datepicker and Eduardo tried to find bypass.
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((ColorDrawable) Control.Background).Color != _selectedColor)
                    {
                        Control.SetBackgroundColor(_selectedColor);
                    }
                    else
                    {
                        // set to default when unfocus is happened
                        Control.SetBackgroundColor(Color.White);
                    }
                }
            }
            catch (InvalidCastException)
            {
                Control.SetBackgroundColor(_selectedColor);
            }
            
        }

        protected override void OnDetached()
        {
            
        }
    }
}