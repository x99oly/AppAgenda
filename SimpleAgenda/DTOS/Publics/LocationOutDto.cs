using SimpleAgenda.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleAgenda.DTOS.Publics
{
    public class LocationOutDto
    {
        public string Street { get; set; } = string.Empty;        
        public string Number { get; set; } = string.Empty;        
        public string City { get; set; } = string.Empty;        
        public string PostalCode { get; set; } = string.Empty;        
        public string Country { get; set; } = string.Empty;        
        public BrazilStatesEnum State { get; set; } = default;
        public string? Complement { get; set; }

    }
}
