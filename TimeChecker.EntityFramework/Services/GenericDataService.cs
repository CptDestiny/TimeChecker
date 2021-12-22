using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TimeChecker.Domain;
using TimeChecker.Domain.Services;

namespace TimeChecker.EntityFramework.Services
{

    /*DataService to handle the sql DB
     *
     */

    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {

        private readonly TimeCheckerDbContextFactory _contextFactory;

        public GenericDataService(TimeCheckerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (TimeCheckerDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }

        }

        public async Task<T> Get(int id)
        {
            using (TimeCheckerDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<T> Create(T entity)
        {
            using (TimeCheckerDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (TimeCheckerDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
              
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (TimeCheckerDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
                //we dont have error handling 
            }
        }
    }
}
