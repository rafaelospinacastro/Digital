using Facturacion.Core.Repositories.Base;
using Facturacion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FacturacionContext _facturacionContext;

        public Repository(FacturacionContext facturacionContext)
        {
            _facturacionContext = facturacionContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _facturacionContext.Set<T>().AddAsync(entity);
            await _facturacionContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _facturacionContext.Set<T>().Remove(entity);
            await _facturacionContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _facturacionContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _facturacionContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
