using Duckendar.Aid.AidClasses;
using Duckendar.Aid.ExtensionClasses;
using Duckendar.Model.Entities.ComposeEntities;

namespace Duckendar.Model.Entities.MainEntities
{
    /// <summary>
    /// The value of the Email and Phone, must be passed using named argument syntax.
    /// </summary>
    /// <param name="name">The pupil's name.</param>
    /// <param name="address">The training address.</param>
    /// <param name="email">The pupil's email.</param>
    /// <param name="phone">The pupil's phone.</param>
    public class Trainee(string name, Address address, Duckendar.Model.Entities.ComposeEntities.Email? email=null, Phone? phone=null)
    {
        public int Id = AidIdentifier.RandomIntId(5);
        public string Name { get; private set; } = name.NullOrEmptyValidator();
        public Duckendar.Model.Entities.ComposeEntities.Email? Email { get; private set; } = email;
        public Address Address { get; private set; } = address;
        public Phone? Phone { get; private set; } = phone;

        public void UpdateName(string name) => Name = name.NullOrEmptyValidator();
        public void UpdatePhone(Phone phone) => Phone = phone;
        public void UpdateEmail(Duckendar.Model.Entities.ComposeEntities.Email email) => Email = email;
    }
}
