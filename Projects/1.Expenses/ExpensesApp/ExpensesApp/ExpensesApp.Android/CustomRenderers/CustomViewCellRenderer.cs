using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ExpensesApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

// Necessary attribute
// you could declare all assemblies in one place or for every class itself.
[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]

namespace ExpensesApp.Droid.CustomRenderers
{
    // Custom View cell renderer for ExpensePage (to test it - select any cell).
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private View _cell;
        private bool _isSelected;
        private Drawable _defaultBackground;

        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;
            _defaultBackground = _cell.Background;

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            // if cell selected\unselected - his property with name "IsSelected" will be changed
            // we catch this situation and add color changing action.
            if (e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                    // change the default selection color (orange) to gray.
                    _cell.SetBackgroundColor(Color.FromHex("#E6E6E6").ToAndroid());
                }
                else
                {
                    _cell.Background = _defaultBackground;
                }
            }
        }
    }
}