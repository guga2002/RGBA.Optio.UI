using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces.InterfacesForTransaction
{
    public interface IRemoveInfo<T,K> where T : class
    {
        Task<bool> RemoveAsync(T entity);

        Task<bool> SoftDeleteAsync(K id,T Identify);
    }
}
