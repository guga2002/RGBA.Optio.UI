using Optio.Core.Interfaces;
using RGBA.Optio.Core.Entities;
using System.Numerics;

namespace RGBA.Optio.Core.Interfaces
{
    public interface IValuteCourse:ICrudRepo<ValuteCourse, BigInteger>
    {
        Task<IEnumerable<ValuteCourse>> GetAllActiveValuteAsync();
    }
}
