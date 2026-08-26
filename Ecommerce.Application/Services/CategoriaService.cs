using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        public ICategoriaRepository _categoriaRepository;
        public IUnitOfWork _unitOfWork;

        public CategoriaService(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
