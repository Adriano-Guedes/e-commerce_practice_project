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
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        private readonly EcommerceDbContext _context;

        public PedidoRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Pedido>> GetByUsuarioIdAsync(Guid usuarioId)
        {
            var pedidos = _context.Pedidos.Where(p => p.ChaveUsuario == usuarioId).ToList();
            return Task.FromResult<IEnumerable<Pedido>>(pedidos);
        }
    }
}
