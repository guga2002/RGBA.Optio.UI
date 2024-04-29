﻿namespace RGBA.Optio.Domain.Interfaces.InterfacesForTransaction
{
    public interface IAddInfo<T> where T : class
    {
        Task<bool> AddAsync(T entity);
    }
}
