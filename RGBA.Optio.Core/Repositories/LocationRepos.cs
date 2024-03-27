using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Repositories
{
    public class LocationRepos : AbstractClass, ILocationRepo
    {
        private readonly DbSet<Location> locations;

        public LocationRepos(OptioDB optioDB):base(optioDB)
        {
            locations=context.Set<Location>();
        }
      

        public Task<bool> Add(Location entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Location>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Location entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Location entity)
        {
            throw new NotImplementedException();
        }
    }
}
