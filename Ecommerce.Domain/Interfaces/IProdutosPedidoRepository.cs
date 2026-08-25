using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProdutosPedidoRepository 
    {
        Task<IEnumerable<ProdutosPedido>> GetAllByPedidoIdAsync(Guid pedidoId);
        Task AddAsync(ProdutosPedido produtosPedido );
    }
}
