/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/validation/
 */
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace EntryEffectAndValidation.Validations
{
    public class ValidatableObject<T> : BindableObject, IValidity
    {
        #region Private Fields
        private readonly List<IValidationRule<T>> _validations;
        private readonly ObservableCollection<string> _errors;
        private T _value;
        private bool _isValid;
        #endregion

        public ValidatableObject()
        {
            _isValid = true;
            _validations = new List<IValidationRule<T>>();
            _errors = new ObservableCollection<string>();
        }

        #region Property Area
        public List<IValidationRule<T>> Validations => _validations;

        public ObservableCollection<string> Errors => _errors;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        #region IValidity Interface
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                _errors.Clear();
                OnPropertyChanged();
            }
        }
        #endregion
        #endregion

        #region Public Method
        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                                                     .Select(v => v.ValidationMessage);

            foreach(var error in errors)
            {
                Errors.Add(error);
            }

            IsValid = !Errors.Any();

            return this.IsValid;
        }
        #endregion
    }
}
