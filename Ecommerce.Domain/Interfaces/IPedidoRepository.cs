using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido> GetByIdAsync(Guid id);
        Task<IEnumerable<Pedido>> GetByUsuarioIdAsync(Guid usuarioId);
        Task AddAsync(Pedido pedido);
    }
}

