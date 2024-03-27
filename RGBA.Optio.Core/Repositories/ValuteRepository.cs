using Optio.Core.Data;
using Optio.Core.Repositories;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;

namespace RGBA.Optio.Core.Repositories
{
    public class ValuteRepository : AbstractClass, IValuteCourse
    {
        public ValuteRepository(OptioDB optioDB) : base(optioDB)
        {
        }

        public Task<bool> Add(ValuteCourse entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ValuteCourse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ValuteCourse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(ValuteCourse entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ValuteCourse entity)
        {
            throw new NotImplementedException();
        }
    }
}
