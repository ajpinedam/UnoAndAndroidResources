using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace GeoTest.Droid;
[Activity(
    MainLauncher = true,
    ConfigurationChanges = global::Uno.UI.ActivityHelper.AllConfigChanges,
    WindowSoftInputMode = SoftInput.AdjustNothing | SoftInput.StateHidden
)]
public class MainActivity : Microsoft.UI.Xaml.ApplicationActivity
{
    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);


    }

    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);

        SupportFragmentManager.BeginTransaction()
                      .Add(Android.Resource.Id.Content, new ImageRecorderView())
                      .Commit();
    }
}
