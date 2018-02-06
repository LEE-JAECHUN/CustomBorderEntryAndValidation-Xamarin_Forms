using System;
using Xamarin.Forms;

namespace EntryEffectAndValidation.Core.ViewModels.Base
{
    public class ViewModelBase : BindableObject
    {
        private bool _isBusy;

        public ViewModelBase()
        {
            
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
    }
}
