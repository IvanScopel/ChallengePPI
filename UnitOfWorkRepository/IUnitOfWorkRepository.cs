using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepository.Generic;
using UnitOfWorkRepository.Repository.Models;

namespace UnitOfWorkRepository
{
    public interface IUnitOfWorkRepository
    {
        IOrdenRepository OrdenRepository { get; }
    }

    public class UOWRepository : IUnitOfWorkRepository
    {
        private readonly IOrdenRepository _ordenRepository;

        public IUnitOfWork UnitOfWork { get; }

        public IOrdenRepository OrdenRepository => _ordenRepository;

        public UOWRepository(IUnitOfWork unitOfWork, IOrdenRepository ordenRepository)
        {
            UnitOfWork = unitOfWork;
            _ordenRepository = ordenRepository;
        }
    }

}
