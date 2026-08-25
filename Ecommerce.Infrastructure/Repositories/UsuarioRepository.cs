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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EcommerceDbContext _context;
        public async Task AddAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = _context.Usuarios.ToList();
            return Task.FromResult<IEnumerable<Usuario>>(usuarios);
        }

        public Task<IEnumerable<Usuario>> GetAllByPapelAsync(string papel)
        {
            var usuarios = _context.Usuarios.Where(u => u.Papel == papel).ToList();
            return Task.FromResult<IEnumerable<Usuario>>(usuarios);
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            return Task.FromResult(usuario);
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

