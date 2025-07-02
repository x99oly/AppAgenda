
using Duckendar.Model.Entities.DTOs;

namespace Duckendar.Model.Interfaces
{
    public interface IDtoConvertable<T>
    {
        T ToDto(); 
    }
}