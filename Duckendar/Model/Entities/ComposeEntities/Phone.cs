using System.Text.RegularExpressions;

namespace Duckendar.Model.Entities.ComposeEntities
{
    public class Phone(string phone)
    {
        public string Value { get; private set; } = PhoneValidator(phone);
        private static string PhoneValidator(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Phone number cannot be null or empty.");

            // Remove tudo que não for dígito
            string digits = Regex.Replace(input, @"\D", "");

            // Deve ter entre 10 e 11 dígitos após limpar (fixo: 10, celular: 11)
            if (digits.Length < 10 || digits.Length > 11)
                throw new ArgumentException("Invalid phone number length.");

            // Validação básica do DDD (01 a 99)
            string ddd = digits.Substring(0, 2);
            if (!Regex.IsMatch(ddd, @"^[1-9][0-9]$"))
                throw new ArgumentException("Invalid area code (DDD).");

            // Validação do número
            string number = digits.Substring(2);

            if (number.Length == 9 && number[0] != '9')
                throw new ArgumentException("Invalid mobile number format. It should start with 9.");

            if (number.Length == 8 && number[0] == '9')
                throw new ArgumentException("Invalid landline number format. It cannot start with 9.");

            return $"55{digits}";
        }
    }
}
