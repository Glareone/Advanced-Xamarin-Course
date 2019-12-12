using Xamarin.Forms;

namespace ExpensesApp.Effects
{
    public class SelectedEffect : RoutingEffect
    {
        // variable - is ID (Group Name) to determine that this Effect comes not from XamarinForms.
        // is used in SelectedEffect.cs file in Android and IOS projects.
        // You can choose whatever you want, but dot is needed because first part will be used in th
        public SelectedEffect(): base("ExpensesApp.SelectedEffect")
        {
            
        }
    }
}
