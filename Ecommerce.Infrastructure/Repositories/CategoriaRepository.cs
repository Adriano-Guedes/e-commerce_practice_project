using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly EcommerceDbContext _context;
        public async Task AddAsync(Categoria categoria)
        {
           _context.Add(categoria);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null) 
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Categoria>> GetAllAsync()
        {
            var categorias = _context.Categorias.ToList();
            return Task.FromResult<IEnumerable<Categoria>>(categorias);
        }

        public Task<Categoria> GetByIdAsync(int id)
        {
            var categoria = _context.Categorias.Find(id);
            return Task.FromResult(categoria);
        }

        public Task<bool> GetByNameAsync(string name)
        {
            var exists = _context.Categorias.Any(c => c.Nome == name);
            return Task.FromResult(exists);
        }
    }
}
