using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Views;
using Marvel.Android.Activities.Base;
using Marvel.Core.ViewModels.Main;

namespace Marvel.Android
{
    [Activity(MainLauncher = false, Theme = "@style/MyTheme.Base", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

           // Set our view from the "main" layout resource
             SetContentView(Resource.Layout.Main);
        }
    }
}

