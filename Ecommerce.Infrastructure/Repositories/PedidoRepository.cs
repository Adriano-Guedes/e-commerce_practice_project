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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceDbContext _context;
        public async Task AddAsync(Pedido pedido)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Pedido>> GetAllAsync()
        {
            var pedidos = _context.Pedidos.ToList();
            return Task.FromResult<IEnumerable<Pedido>>(pedidos);
        }

        public Task<IEnumerable<Pedido>> GetByUsuarioIdAsync(Guid usuarioId)
        {
            var pedidos = _context.Pedidos.Where(p => p.ChaveUsuario == usuarioId).ToList();
            return Task.FromResult<IEnumerable<Pedido>>(pedidos);
        }

        public Task<Pedido> GetByIdAsync(Guid id)
        {
            var pedido = _context.Pedidos.Find(id);
            return Task.FromResult(pedido);
        }

    }
}
