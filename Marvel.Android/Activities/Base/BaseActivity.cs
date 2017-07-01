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
using Marvel.Core.ViewModels.Base;
using Marvel.Core.Mvvm;

namespace Marvel.Android.Activities.Base
{
    [Activity(Icon = "@drawable/icon")]
    public class BaseActivity<TViewModel> : AppCompatActivity where TViewModel : BaseViewModel
    {

        protected readonly TViewModel ViewModel;
        protected ProgressDialog ProgressDialog;


        public BaseActivity()
        {
            ViewModel = ServiceContainer.Resolve<TViewModel>();
        }


    }
}