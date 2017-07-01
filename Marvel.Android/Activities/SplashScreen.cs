using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Marvel.Android.Activities
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            base.OnCreate(savedInstanceState);

        }

        protected override void OnStart()
        {
            base.OnStart();
            StartActivity(typeof(LoginActivity));
        }
    }
}