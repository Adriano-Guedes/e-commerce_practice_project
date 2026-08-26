using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Task<bool> ExistsByNameAsync(string name, int? ignoreId = null, CancellationToken ct = default);
    }
}
