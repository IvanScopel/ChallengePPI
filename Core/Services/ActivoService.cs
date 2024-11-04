using Core.Interfaces;
using DataAccess.DataContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ActivoService : IActivoService
    {
        private readonly ChallengePPIContext _context;

        public ActivoService(ChallengePPIContext context)
        {
            _context = context;
        }

        public Activo GetActivoById(int activoId)
        {
            return _context.Activos.FirstOrDefault(x => x.Id == activoId);
        }
    }
}
