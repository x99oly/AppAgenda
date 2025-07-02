using Duckendar.Aid.ExtensionClasses;
using System.Text.RegularExpressions;

namespace Duckendar.Model.Entities.ComposeEntities
{
    public class Email(string email)
    {
        public string Value { get; private set; } = EmailValidator(email);
                
        private static string EmailValidator(string value)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                throw new ArgumentException("The provided value doesn't match with a valid email.");

            return value.NullOrEmptyValidator();
        }
    }
}
