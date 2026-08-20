using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        //private readonly EcommerceDbContext _context;
        public Task<Categoria> AddAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> UpdateAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
