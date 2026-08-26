using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProdutosPedidoRepository : IRepositoryBase<ProdutosPedido>
    {
        Task<IEnumerable<ProdutosPedido>> GetAllByPedidoIdAsync(Guid pedidoId);
    }
}
