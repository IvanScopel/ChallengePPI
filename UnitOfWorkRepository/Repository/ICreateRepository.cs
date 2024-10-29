using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkRepository.Repository
{
    public interface ICreateRepository<T> where T : class
    {
        bool Create(T entity);
        void Create(IEnumerable<T> entity);
        Task CreateAsync(IEnumerable<T> entity);
        Task<bool> CreateAsync(T entity);
    }
}
