using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAllByPapelAsync(string papel);
        Task<Usuario> GetByCpfAsync(string cpf);
        Task<bool> GetByNameAsync(string name);
    }
}
