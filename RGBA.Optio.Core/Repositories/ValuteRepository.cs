using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Repositories;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;
using System.Numerics;

namespace RGBA.Optio.Core.Repositories
{
    public class ValuteRepository : AbstractClass, IValuteCourse
    {
        private readonly DbSet<ValuteCourse> courses;
        public ValuteRepository(OptioDB optioDB) : base(optioDB)
        {
            courses = context.Set<ValuteCourse>();
        }

        public async Task<bool> AddAsync(ValuteCourse entity)
        {
            try
            {
                if(! await context.Currencies.AnyAsync(io=>io.Id==entity.CurrencyID))
                {
                    throw new ArgumentNullException(" no such a Currency  Exist!");
                }
                if (!await courses.AnyAsync(io => io.CurrencyID == entity.CurrencyID && io.DateOfValuteCourse == entity.DateOfValuteCourse))
                {
                    await courses.AddAsync(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException("Error while adding entity, Entity already exist in same Date");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ValuteCourse>> GetAllAsync()
        {
            try
            {
                return await courses
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ValuteCourse>> GetAllActiveValuteAsync()
        {
            try
            {
                return await courses
                    .AsNoTracking()
                    .Where(io=>io.IsActive)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ValuteCourse> GetByIdAsync(long id)
        {
            try
            {
                return await courses.
                    AsNoTracking()
                    .FirstOrDefaultAsync(io => io.Id == id && io.IsActive) 
                    ?? throw new ArgumentException(" No user exist on this Id");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveAsync(ValuteCourse entity)
        {
            try
            {
                var course = await courses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(io => io.Id == entity.Id);

                if (course is not null)
                {
                    courses.Remove(course);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(long id)
        {
            try
            {
                var course = await courses.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id);
                if (course is not null)
                {
                    course.IsActive = false;
                    await context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(long id, ValuteCourse entity)
        {
            try
            {
                var course = await courses.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id);
                if (course is not null)
                {
                    context.Entry(course).CurrentValues.SetValues(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ent=ex.Entries.Single();
                var act =(ValuteCourse)ent.Entity;
                ent.CurrentValues.SetValues(act);
                throw;
            }
        }
    }
}
