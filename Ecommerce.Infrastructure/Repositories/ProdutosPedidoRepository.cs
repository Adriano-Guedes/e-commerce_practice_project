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
    public class ProdutosPedidoRepository : RepositoryBase<ProdutosPedido>, IProdutosPedidoRepository
    {
        private readonly EcommerceDbContext _context;
        public ProdutosPedidoRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutosPedido>> GetAllByPedidoIdAsync(Guid pedidoId)
        {
            var produtosPedido = _context.ProdutosPedidos.Where(pp => pp.ChavePedido == pedidoId).ToList();
            return produtosPedido;
        }
    }
}
