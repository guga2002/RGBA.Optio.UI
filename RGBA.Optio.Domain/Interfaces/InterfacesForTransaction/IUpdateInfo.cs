using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces.InterfacesForTransaction
{
    public interface IUpdateInfo<T,K> where T : class
    {
        Task<bool> UpdateAsync(K id, T entity);
    }
}
