using Core.Interfaces;
using Entities;
using EntitiesDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepository.Generic;
using UnitOfWorkRepository.Repository.Models;
using static Infraestructura.Excepciones.Exceptions;
using AutoMapper;
using DataAccess.DataContext;
namespace Core.Services
{
    public class OrdenService : IOrdenService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrdenRepository _ordenRepository;
        private readonly IMapper _mapper;
        private readonly ActivoService _activoService;

        public OrdenService(IOrdenRepository ordenRepository, IUnitOfWork unitOfWork, IMapper mapper, ActivoService activoService)
        {
            _unitOfWork = unitOfWork;
            _ordenRepository = ordenRepository;
            _mapper = mapper;
            _activoService = activoService;

        }

        public bool CreateOrden(OrdenDTO orden)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateOrdenAsync(OrdenDTO ordenDTO)
        {
            Orden orden = new Orden();

            orden.CuentaId = ordenDTO.CuentaId;
            orden.Cantidad = ordenDTO.Cantidad;
            orden.Operacion = ordenDTO.Operacion;
            orden.Activo = _activoService.GetActivoById(ordenDTO.ActivoId);
            orden.MontoTotal = orden.Activo.CalcularMontoTotal(orden.Cantidad);
            orden.TipoEstadoId = 1;
            orden.Precio = 1;
            orden.Borrado = false;


            _unitOfWork.BeginTransaction();

            var created = await _ordenRepository.CreateAsync(orden);

            if (created)
               await _unitOfWork.CommitAsync();
            else
                throw new FailedDependency("Hubo un error al cargar la orden");

            _unitOfWork.CommitTransaction();
            return created;
        }

        public async Task<bool> DeleteOrden(int idOrden)
        {
            var orden = _ordenRepository.FirstOrDefault(x => x.Id == idOrden);

            orden.Borrado = true;

            return true;
        }

        public async Task<Orden> GetOrden(int idOrden)
        {
            var orden = await _ordenRepository.FirstOrDefaultAsync(x => x.Id == idOrden);

            return orden;
        }

      
        public Task<bool> UpdateOrden(OrdenDTO orden)
        {
            throw new NotImplementedException();
        }
    }
}
