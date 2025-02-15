﻿using LibraryManagementSystem.Models.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Models.Repositories
{
    public class GenericRepository<T>(AppDbContext context) where T : class
    {
        public readonly DbSet<T> DbSet = context.Set<T>();

        public IQueryable<T> Where(Func<T, bool> predicate)
        {

            return DbSet.Where(predicate).AsQueryable();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {


            return await DbSet.AnyAsync(predicate);
        }

        public async Task<List<T>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public T Add(T entity)
        {
            DbSet.Add(entity);

            return entity;
        }
        public void Update(T entity)
        {
            DbSet.Update(entity);


        }
        public async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity!);
        }

    }
}
