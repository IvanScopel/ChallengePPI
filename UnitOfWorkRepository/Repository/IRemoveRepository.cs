using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitOfWorkRepository.Repository.Interfaces
{
    public interface IRemoveRepository<T> where T : class
    {
 
        void Remove(T t);

        void Remove(IEnumerable<T> t);
    }
}
