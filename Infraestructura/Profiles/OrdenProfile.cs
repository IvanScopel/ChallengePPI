
using AutoMapper;
using DataAccess.DataContext;
using Entities;
using Entities.Activos;
using EntitiesDTO;

namespace Infraestructura.Profiles
{
    public class OrdenProfile : Profile
    {
        

        public OrdenProfile() {
            CreateMap<OrdenDTO, Orden>();
        }


    }


}
