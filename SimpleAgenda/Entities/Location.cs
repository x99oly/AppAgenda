using SimpleAgenda.Aid.ExtensionClasses;
using SimpleAgenda.Enums;

namespace SimpleAgenda.Entities
{
    internal class Location(string street,
        string city,
        string postalCode,
        string country,
        string state,
        string complement = "")
    {
        internal string Street { get; private set; } = street.NullOrEmptyValidator();
        internal string City { get; private set; } = city.NullOrEmptyValidator();
        internal string PostalCode { get; private set; } = PostalCodeValidator(postalCode);
        internal string Country { get; private set; } = country.NullOrEmptyValidator();
        internal BrazilStatesEnum State { get; private set; } = StateValidator(state);
        internal string Complement { get; private set; } = complement.NullOrEmptyValidator();

        private static string PostalCodeValidator(string value)
        {
            if (value.Count(d => char.IsDigit(d)) < 8)
                throw new ArgumentException("The provided value doesn't have the correct number of digits of a postal code.");

            return value.NullOrEmptyValidator();
        }

        private static BrazilStatesEnum StateValidator(string value)
        {
            value = value.NullOrEmptyValidator();
            if (!Enum.TryParse(value, out BrazilStatesEnum estado))
                throw new ArgumentException("The provided value is not a valid state of Brazil.");

            return estado;
        }
    }
}