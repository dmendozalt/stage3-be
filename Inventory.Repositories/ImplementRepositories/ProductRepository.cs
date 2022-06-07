using Inventory.Contracts.Repository;
using Inventory.DataAccess.Context;
using Inventory.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Repositories.ImplementRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;

        public ProductRepository()
        {
            _context = new SqlServerContext();
        }
        public async Task<Tuple<Product, bool>> AddAsync(Product entity)
        {
            try
            {
                var result = _context.Product.Add(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var result = await _context.Product.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Product>> GetByFilterAsync(Expression<Func<Product, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.Product.Where<Product>(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Product.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tuple<Product,bool>> UpdateAsync(Product entity)
        {
            try
            {
                var result = _context.Product.Update(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
