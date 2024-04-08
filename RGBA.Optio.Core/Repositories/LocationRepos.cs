using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using SharpCompress.Common;

namespace Optio.Core.Repositories
{
    public class LocationRepos : AbstractClass, ILocationRepo
    {
        private readonly DbSet<Location> locations;

        public LocationRepos(OptioDB optioDB):base(optioDB)
        {
            locations=context.Set<Location>();
        }
      

        public async Task<bool> Add(Location entity)
        {
            try
            {
                var city = await locations.SingleOrDefaultAsync(i => i.LocationName.ToLower() == entity.LocationName.ToLower());
                if (city != null)
                {
                    throw new InvalidOperationException("Such a city already exists");
                }
                else
                {
                    await locations.AddAsync(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            try
            {
                if (locations.IsNullOrEmpty())
                {
                    throw new InvalidOperationException("No cities found");
                }
                return await locations.AsNoTracking().ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Location>> GetAllActiveLocation()
        {
            try
            {
                var city = await locations.AsNoTracking().Where(i => i.IsActive == true).ToListAsync();
                if (city == null)
                {
                    throw new InvalidOperationException("No active city found");
                }
                else
                {
                    return city;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Location> GetById(Guid id)
        {
            try
            {
                var city = await locations.Where(i => i.Id == id).SingleOrDefaultAsync();
                if (city == null)
                {
                    throw new InvalidOperationException("No such city was found");
                }
                else return city;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Remove(Location entity)
        {
            try
            {
                var city = await locations.SingleOrDefaultAsync(i => i.LocationName.ToLower() == entity.LocationName.ToLower());
                if (city == null)
                {
                    throw new InvalidOperationException("No such city was found");
                }
                else
                {
                    locations.Remove(entity);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SoftDelete(Guid id)
        {
            try
            {
            var city = await locations.SingleOrDefaultAsync(i => i.Id == id);
                if (city == null)
                {
                    throw new InvalidOperationException("No such city was found");
                }
                else
                {
                    city.IsActive = false;
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Location entity)
        {
            try
            {
                var city = await locations.SingleOrDefaultAsync(i => i.Id == entity.Id);
                if (city == null)
                {
                    throw new InvalidOperationException("No such city was found");
                }
                else
                {
                    city.IsActive = entity.IsActive;
                    city.LocationName = entity.LocationName;
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
