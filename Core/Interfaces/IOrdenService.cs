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
        void DeleteOrden(int idOrden);
        bool LogicDeleteOrden(int idOrden);

        Task<Orden> GetOrden(int idOrden);
        bool UpdateOrden(int id, int nuevoEstadoId);
    }
}
