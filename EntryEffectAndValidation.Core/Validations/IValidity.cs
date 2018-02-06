/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/validation/
 */
namespace EntryEffectAndValidation.Validations
{
    public interface IValidity
    {
        bool IsValid { get; set; }
    }
}
