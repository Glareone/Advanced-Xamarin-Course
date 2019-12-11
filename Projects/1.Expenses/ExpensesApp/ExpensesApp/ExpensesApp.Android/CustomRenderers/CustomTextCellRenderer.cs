using Android.Content;
using Android.Views;
using ExpensesApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

// Necessary attribute
// you could declare all assemblies in one place or for every class itself. (like i do here. Then there is no reason to declare them in other places)
[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]


namespace ExpensesApp.Droid.CustomRenderers
{
    // Customize Text cells from ExpensesPage (instead of Ios where we added a new control to right side of each cell - here we only changed a color)
    // for demo purposes, cell contains a lot of SetXX abilities
    public class CustomTextCellRenderer : TextCellRenderer
    {
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            // based on styleId which could be defined directly in ExpensePage.xaml
            switch (item.StyleId)
            {
                case "none":
                    cell.SetBackgroundColor(Android.Graphics.Color.AliceBlue);
                    break;
                case "checkmark":
                    cell.SetBackgroundColor(Android.Graphics.Color.Aqua);
                    break;
                case "detail-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Beige);
                    break;
                case "detail-disclosure-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Chartreuse);
                    break;
                case "disclosure":
                default:
                    cell.SetBackgroundColor(Android.Graphics.Color.DarkKhaki);
                    break;
            }

            return cell;
        }
    }
}