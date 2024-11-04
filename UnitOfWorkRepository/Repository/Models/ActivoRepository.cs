using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepository.Generic;
using UnitOfWorkRepository.Repository.Interfaces;

namespace UnitOfWorkRepository.Repository.Models
{
    public interface IActivoRepository : IReadRepository<Activo>, ICreateRepository<Activo>, IUpdateRepository<Activo>, IRemoveRepository<Activo>
    { }
    public class ActivoRepository : GenericRepository<Activo>, IActivoRepository
    {
        public ActivoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }

}