/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/validation/
 */
namespace EntryEffectAndValidation.Validations
{
    public class IsNotNullOrEmtpyRule<T> : IValidationRule<T>
    {
        public IsNotNullOrEmtpyRule()
        {
            ValidationMessage = "Should not be empty";
        }

        public string ValidationMessage { get ; set; }

        public bool Check(T value)
        {
            if(value == null)
            {
                return false;
            }

            var str = value as string;

            return !string.IsNullOrEmpty(str);
        }
    }
}
