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
    public interface IOrdenRepository : IReadRepository<Orden>, ICreateRepository<Orden>, IUpdateRepository<Orden>, IRemoveRepository<Orden>
    {
    }

    public class OrdenRepository : GenericRepository<Orden>, IOrdenRepository {

        public OrdenRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
