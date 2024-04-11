using Optio.Core.Interfaces;
using RGBA.Optio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Core.Interfaces
{
    public interface ICurrencyRepository:ICrudRepo<Currency,int>
    {
        Task<IEnumerable<Currency>> GetAllActiveAsync();

    }
}
