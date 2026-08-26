using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        private readonly EcommerceDbContext _context;
        public CategoriaRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name, int? ignoreId = null, CancellationToken ct = default)
        {
            var nomeNormalizado = name.Trim().ToLower();
            return await _dbSet.AnyAsync(c => c.Nome.ToLower() == nomeNormalizado && (!ignoreId.HasValue || c.Id != ignoreId.Value), ct);
        }
    }
}
