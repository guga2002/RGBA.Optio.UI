using Optio.Core.Interfaces;
using RGBA.Optio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Core.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<bool> AddAsync(Currency entity);
        Task<bool> RemoveAsync(Currency entity);
        Task<bool> UpdateAsync(Currency entity);
        Task<bool> SoftDeleteAsync(int id);
        Task<IEnumerable<Currency>> GetAllAsync();
        Task<IEnumerable<Currency>> GetAllActiveAsync();
        Task<Currency> GetByIdAsync(int id);
    }
}
