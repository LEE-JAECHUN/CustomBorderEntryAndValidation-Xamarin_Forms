/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/validation/
 */
namespace EntryEffectAndValidation.Validations
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }

        bool Check(T value);
    }
}