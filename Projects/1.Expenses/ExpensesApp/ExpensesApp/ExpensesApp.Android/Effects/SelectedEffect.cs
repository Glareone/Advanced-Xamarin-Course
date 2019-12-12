using ExpensesApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// Only Group name here (first part before dot, which comes from SelectedEffect.cs file in .net Standard library project)
[assembly: ResolutionGroupName("ExpensesApp")]
// unique name comes from the second part after dot.
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.Droid.Effects
{
    public class SelectedEffect: PlatformEffect
    {
        protected override void OnAttached()
        {
            
        }

        protected override void OnDetached()
        {
            
        }
    }
}