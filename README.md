## Xamarin Advanced Repos

### CustomRenderer

To decorate or entirely change elements (like a buttons) to make them platform specific (different buttons for iOS and Droid)

demo: CustomViewCellRenderer, CustomTextCellRenderer, CustomProgressBarRenderer in CustomRenderers folders (in iOS project and Droid)

### Writing file using FileProvider

Share.cs classes (in iOS project and Droid project) contain platform specific code.
IShare - its interface.

demo: It is used in ShareReport method + platform specific logic inside Share.cs files.

### Dependency Services:

Called it:
var shareDependency = DependencyService.Get<IShare>();
registration using attribute:
[assembly: Dependency(typeof(Share))]

custom renderers registration:
[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]

### Behaviors

It is useful to decorate some buttons with additional actions (when CustomRenderer is not suitable):
[microsoft behavior documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/)

registration:
xmlns:behaviors="clr-namespace:ExpensesApp.Behaviors"

use:
<ListView.Behaviors>
	<behaviors:ListViewBehavior />
</ListView.Behaviors>

demo: some examples on ExpensesPage + ListViewBehavior. Added onClick event to move us to details page.
Other listViews on another pages dont have such action.

### Effects:

to make some styles to selected components (with has different types) without using CustomRenderer or StaticResource Styles.
I would like to emphasize the next: One Effect could work for different type of controls.

Demo: SelectedEffect.cs files and NewExpensesPage (<DatePicker.Effects> + its namespace at the top of the file)
<DatePicker.Effects></DatePicker.Effects> is a list of effects. Several effects could be assigned.
