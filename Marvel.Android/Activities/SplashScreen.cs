using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Marvel.Core.Mvvm;
using Marvel.Core.Service.MarvelService;
using Marvel.Core.ViewModels.Login;
using Marvel.Core.ViewModels.Main;

namespace Marvel.Android.Activities
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : AppCompatActivity
    {
        private readonly MainViewModel MainViewModel = ServiceContainer.Resolve<MainViewModel>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            base.OnCreate(savedInstanceState);

        }

        protected override void OnStart()
        {
            base.OnStart();

            Task.Run(async () =>
            {
                await MainViewModel.GetComics();
            });

            StartActivity(typeof(LoginActivity));
        }


    }
}