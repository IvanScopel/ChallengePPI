using Entities;
using EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrdenService
    {
        bool CreateOrden(OrdenDTO orden);
        Task<bool> CreateOrdenAsync(OrdenDTO orden);
        Task<bool> DeleteOrden(int idOrden);
        Task<Orden> GetOrden(int idOrden);
        Task<bool> UpdateOrden(OrdenDTO orden);
    }
}
