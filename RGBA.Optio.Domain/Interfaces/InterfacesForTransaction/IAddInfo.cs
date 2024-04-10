using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces.InterfacesForTransaction
{
    public interface IAddInfo<T> where T : class
    {
        Task<bool> AddAsync(T entity);
    }
}
