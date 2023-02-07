using Microsoft.EntityFrameworkCore;
using SolutionDynamicPage.Infra.Data.Context;
using SolutionDynamicPage.Infra.Domain.Entities;
using SolutionDynamicPage.Infra.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Data.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly SQLServerContext _context;

        public BaseRepository(SQLServerContext context)
        {
            _context = context;
        }

        public Task<int> Delete(T entity)
        {
           this._context.Set<T>().Remove(entity);
           return this._context.SaveChangesAsync();
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>();
        }

        public async Task<T> FindById(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public Task<int> Save(T entity)
        {
            this._context.Set<T>().Add(entity);
            return this._context.SaveChangesAsync();
        }

        public Task<int> Update(T entity)
        {
        
           this._context.Set<T>().Update(entity);
           return this._context.SaveChangesAsync();
            
        }

        public async Task<int> ExecuteCommand(string sqlCommand)
        {
            return await this._context.Database.ExecuteSqlRawAsync(sqlCommand);
        }
    }
}
