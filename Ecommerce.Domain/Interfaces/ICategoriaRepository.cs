using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task<bool> GetByNameAsync(string name);
        Task<Categoria> AddAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        void DeleteAsync(int id);
    }
}
