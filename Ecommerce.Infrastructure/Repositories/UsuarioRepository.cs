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
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly EcommerceDbContext _context;
        public UsuarioRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Usuario>> GetAllByPapelAsync(string papel)
        {
            var usuarios = _context.Usuarios.Where(u => u.Papel == papel).ToList();
            return Task.FromResult<IEnumerable<Usuario>>(usuarios);
        }

        public Task<Usuario> GetByCpfAsync(string cpf)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Cpf == cpf   );
            return Task.FromResult(usuario);
        }

        public Task<bool> GetByNameAsync(string name)
        {
            var exists = _context.Usuarios.Any(u => u.Nome == name);
            return Task.FromResult(exists);
        }
    }
}

