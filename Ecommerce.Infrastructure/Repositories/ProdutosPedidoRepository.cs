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
    public class ProdutosPedidoRepository : IProdutosPedidoRepository
    {
        private readonly EcommerceDbContext _context;

        public async Task AddAsync(ProdutosPedido produtosPedido)
        {
            _context.Add(produtosPedido);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProdutosPedido>> GetAllByPedidoIdAsync(Guid pedidoId)
        {
            var produtosPedido = _context.ProdutosPedidos.Where(pp => pp.ChavePedido == pedidoId).ToList();
            return produtosPedido;
        }
    }
}
