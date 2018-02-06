/*
 * 참조 : https://developer.xamarin.com/guides/xamarin-forms/enterprise-application-patterns/validation/
 */
using System.ComponentModel.DataAnnotations;

namespace EntryEffectAndValidation.Validations
{
    public class EmailRule<T> : IValidationRule<T>
    {
        public EmailRule()
        {
            ValidationMessage = "Should be an email address";
        }

        public string ValidationMessage { get ; set ; }

        public bool Check(T value)
        {
            /*
            //PCL Project 의 경우 주석 처리된 코드 사용 -> System.ComponentModel.Annotations Package 가 참조 되지 않음
            if(value == null)
            {
                return false;
            }

            if(!(value is string))
            {
                return false;
            }

            var str = value as string;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");  
            Match match = regex.Match(str);  

            return match.Success; 
            */

            return new EmailAddressAttribute().IsValid(value) ;
        }
    }
}
