using Duckendar.Model.Entities.ComposeEntities;

namespace Duckendar.Model.Entities.MainEntities
{
    public class TraineeManager
    {
        public SortedDictionary<int, Trainee> Trainees = [];

        /// <summary>
        /// Try instantiate and add new Trainee to collection.
        /// Could throw a InvalidArgumentException.
        /// </summary>
        public void AddNewTrainee(string name, Address address, Duckendar.Model.Entities.ComposeEntities.Email email, Phone phone)
        {
            Trainee tNew = new(name, address, email, phone);
            Trainees.Add(tNew.Id, tNew);
        }
    }
}
