/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/
 */
using System.Threading.Tasks;
using System.Windows.Input;
using EntryEffectAndValidation.Core.ViewModels.Base;
using EntryEffectAndValidation.Validations;
using Xamarin.Forms;

namespace EntryEffectAndValidation.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Private fields Area
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private ICommand _signInCommand;
        #endregion

        public LoginViewModel()
        {
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }

        #region Property Area
        public ValidatableObject<string> UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command Area
        public ICommand SignInCommand => _signInCommand ??
                                                    (
                                                         _signInCommand = new Command
                                                                                (
                                                                                    async () =>
                                                                                    {
                                                                                        IsBusy = true;
                                                                                        
                                                                                        await Task.Delay(1500); //실제 운영 코드에서는 사용 하지 마세요

                                                                                        bool isValid = Validate();
                                                                                        if(isValid)
                                                                                        {
                                                                                            //Do login action
                                                                                        }
                                                                                        IsBusy = false;
                                                                                    }
                                                                                )
                                                    );
        #endregion

        #region Private Method Area
        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmtpyRule<string>(){ ValidationMessage = "Username should not be empty" });
            _userName.Validations.Add(new EmailRule<string>());
            _password.Validations.Add(new IsNotNullOrEmtpyRule<string>(){ ValidationMessage = "Password showld not be empty" });
        }

        private bool Validate()
        {
            bool isValidUser = _userName.Validate();
            bool isValidPassword = _password.Validate();

            return isValidUser && isValidPassword;
        }
        #endregion
    }
}
