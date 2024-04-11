using RGBA.Optio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces.InterfacesForTransaction
{
    public interface IGetInfo<T,K> where T : class
    {
        Task<T> GetByIdAsync(K id,T Identify);

        Task<IEnumerable<T>> GetAllAsync(T Identify);

        Task<IEnumerable<T>> GetAllActiveAsync(T Identify);
    }
}
