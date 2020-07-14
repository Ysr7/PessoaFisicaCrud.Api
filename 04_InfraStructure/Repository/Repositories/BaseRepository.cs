using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
         private readonly DbSet<T> _entity;
         private readonly WG2RContext _context;

         public BaseRepository(WG2RContext context, DbSet<T> entity)
         {
             _entity = entity;
             _context = context;
         }

        public async Task AddAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public T FirstOrDefault(Func<T, bool> criteria) => _entity.FirstOrDefault(criteria);

        public IEnumerable<T> GetAll() => _entity.ToList();

        public IEnumerable<T> Where(Func<T, bool> criteria) => _entity.Where(criteria);

        public async Task UpdateAsync(T entity) 
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity) 
        {
            _context.Remove(entity);
        }

        public bool Exists(Func<T, bool> criteria) => _entity.Any(criteria);


    }


}