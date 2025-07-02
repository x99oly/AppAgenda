using Duckendar.Aid.ExtensionClasses;
using Duckendar.Model.Enums;
using System;

namespace Duckendar.Model.Entities.ComposeEntities
{
    public class Address
    (string street, string city, string postalCode, string country, string state, string complement)
    {
        public string Street { get; private set; } = street.NullOrEmptyValidator();
        public string City { get; private set; } = city.NullOrEmptyValidator();
        public string PostalCode { get; private set; } = PostalCodeValidator(postalCode);
        public string Country { get; private set; } = country.NullOrEmptyValidator();
        public BrazilStatesEnum State { get; private set; } = StateValidator(state);
        public string Complement { get; private set; } = complement.NullOrEmptyValidator();

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
