using Marvel.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Core.ViewModels.Base
{
    public class BaseViewModel : PropertyChangedBase
    {
        public event EventHandler IsBusyChanged;
        public event EventHandler IsLogOutChanged;

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged("IsBusy");
                    OnIsBusyChanged();
                }
            }
        }

        private bool _isLogOut;
        public bool IsLogOut
        {
            get => _isLogOut;
            set
            {
                if (_isLogOut != value)
                {
                    _isLogOut = value;
                    OnPropertyChanged("IsLogOut");
                    OnIsLogOutChanged();
                }
            }
        }

        public event EventHandler IsValidChanged;

        readonly List<string> _errors = new List<string>();

        public BaseViewModel()
        {
            Validate();
        }

        public bool IsValid => _errors.Count == 0;

        protected List<string> Errors => _errors;

        public virtual string Error
        {
            get
            {
                return _errors.Aggregate(new StringBuilder(), (b, s) => b.AppendLine(s)).ToString().Trim();
            }
        }

        protected virtual void Validate()
        {
            OnPropertyChanged("IsValid");
            OnPropertyChanged("Errors");
            OnPropertyChanged("IsLogOut");

            //var method = IsValidChanged;
            //if (method != null)
            //    method(this, EventArgs.Empty);
            var method = IsValidChanged;
            method?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void ValidateProperty(Func<bool> validate, string error)
        {
            if (validate())
            {
                if (!Errors.Contains(error))
                    Errors.Add(error);
            }
            else
            {
                Errors.Remove(error);
            }
        }

        protected virtual void OnIsBusyChanged()
        {
            var method = IsBusyChanged;
            if (method != null)
                IsBusyChanged(this, EventArgs.Empty);
        }

        protected virtual void OnIsLogOutChanged()
        {
            var method = IsLogOutChanged;
            if (method != null)
                IsLogOutChanged(this, EventArgs.Empty);
        }


      
    }
}
