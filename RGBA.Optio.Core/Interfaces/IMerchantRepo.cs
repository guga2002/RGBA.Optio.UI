﻿using Optio.Core.Entities;

namespace Optio.Core.Interfaces
{
    public interface IMerchantRepo:ICrudRepo<Merchant, Guid>
    {
        Task<IEnumerable<Merchant>> GetAllActiveMerchantAsync();
    }
}
