using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Marvel.Android.Activities.Base;
using Marvel.Core.ViewModels.Login;
using System.Collections.Generic;

namespace Marvel.Android.Activities
{
    [Activity(MainLauncher = false, Theme = "@style/MyTheme.Base", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : BaseActivity<LoginViewModel>
    {
        #region Propiedades

        private Button LoginBtn { get; set; }

        #endregion

        #region Metodos del Activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            #region Boton de GetComics

            LoginBtn = FindViewById<Button>(Resource.Id.btnGetComics);
            LoginBtn.Click += Login;

            #endregion


        }

        #endregion

        #region Metodos 

        private  void Login(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(MainActivity));
        }

        #endregion
    }
}