﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcommerceDbContext context;
       
        public GenericRepository(EcommerceDbContext _context)
        {
            this.context = _context;
            
        }

        public async Task <IEnumerable<T>> GetAll() => await context.Set<T>().ToListAsync();
       
        public async Task<T> GetById(object id)
        {
            var result = await context.Set<T>().FindAsync(id);
            return result;
            
        }

        public async Task Insert(T obj)
        {
            await context.Set<T>().AddAsync(obj);
            await Save();
        }

        public async Task<T> Find(T obj)
        {
            var res = await context.Set<T>().ToListAsync();
            return res.FirstOrDefault(n => n == obj);
            
        }

        public async Task Update(T obj)
        {
            context.Set<T>().Update(obj);
            await Save();
        }

        public async Task Delete(T obj)
        {
            T result = await Find(obj);
            context.Set<T>().Remove(result);
            await Save();
        }

        public async Task Save()
        {
             await context.SaveChangesAsync();
        }

        

        
    }
}
