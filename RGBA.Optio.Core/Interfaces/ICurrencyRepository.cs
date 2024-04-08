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
        Task<bool> Add(Currency entity);
        Task<bool> Remove(Currency entity);
        Task<bool> Update(Currency entity);
        Task<bool> SoftDelete(int id);
        Task<IEnumerable<Currency>> GetAll();
        Task<Currency> GetById(int id);
    }
}
