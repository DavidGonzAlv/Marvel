using System;
using Android.App;
using Android.Runtime;
using Marvel.Core.Mvvm;
using Marvel.Core.Service.MarvelService;
using Marvel.Core.ViewModels.Login;
using Marvel.Core.ViewModels.Main;
using Xamarin.Android;

namespace Marvel.Android
{
    [Application(Debuggable = true)]
    public class Applications : Application
    {
        public Applications(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
          
           
        }

        public override void OnCreate()
        {
            base.OnCreate();

            ServiceContainer.Register<LoginViewModel>(() => new LoginViewModel());
            ServiceContainer.Register<MainViewModel>(() => new MainViewModel());

            ServiceContainer.Register<IMarvelService>(() => new MarvelService());
        }
    }
}