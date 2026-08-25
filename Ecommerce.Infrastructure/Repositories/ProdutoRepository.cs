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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EcommerceDbContext _context;
        public async Task AddAsync(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Produto>> GetAllAsync()
        {
            var produtos = _context.Produtos.ToList();
            return Task.FromResult<IEnumerable<Produto>>(produtos);
        }
        
        public Task<IEnumerable<Produto>> GetByCategoriaIdAsync(int chaveCategoria)
        {
            var produtos = _context.Produtos.Where(p => p.CategoriaId == chaveCategoria).ToList();
            return Task.FromResult<IEnumerable<Produto>>(produtos);
        }

        public Task<Produto> GetByIdAsync(Guid id)
        {
            var produto = _context.Produtos.Find(id);
            return Task.FromResult(produto);
        }

        public Task<bool> GetByNameAsync(string name)
        {
            var exists = _context.Produtos.Any(p => p.Nome == name);
            return Task.FromResult(exists);
        }

    }
}
