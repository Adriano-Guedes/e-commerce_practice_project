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
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        private readonly EcommerceDbContext _context;

        public ProdutoRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Produto>> GetByCategoriaIdAsync(int chaveCategoria)
        {
            var produtos = _context.Produtos.Where(p => p.CategoriaId == chaveCategoria).ToList();
            return Task.FromResult<IEnumerable<Produto>>(produtos);
        }

        public Task<bool> GetByNameAsync(string name)
        {
            var exists = _context.Produtos.Any(p => p.Nome == name);
            return Task.FromResult(exists);
        }
    }
}
