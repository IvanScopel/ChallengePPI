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

        public OrdenService(IOrdenRepository ordenRepository, IUnitOfWork unitOfWork, IMapper mapper, ActivoService activoService, IActivoRepository activoRepository)
        {
            _unitOfWork = unitOfWork;
            _ordenRepository = ordenRepository;
            _mapper = mapper;
            _activoService = activoService;

        }

        public bool CreateOrden(OrdenDTO ordenDTO)
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

            var created =  _ordenRepository.Create(orden);

            if (created)
                _unitOfWork.Commit();
            else
                throw new FailedDependency("Hubo un error al cargar la orden");

            _unitOfWork.CommitTransaction();
            return created;
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

        public void DeleteOrden(int idOrden)
        {
            var orden = _ordenRepository.FirstOrDefault(x => x.Id == idOrden);

            if (orden == null)
                throw new NotAcceptable("No se encontró la orden que quiere borrar");

            _ordenRepository.Remove(orden);
            _unitOfWork.Commit();
        }

        public async Task<Orden> GetOrden(int idOrden)
        {
            var orden = await _ordenRepository.FirstOrDefaultAsync(x => x.Id == idOrden);

            return orden;
        }

        public bool LogicDeleteOrden(int idOrden)
        {
            var orden = _ordenRepository.FirstOrDefault(x => x.Id == idOrden);

            if (orden == null)
            {
                throw new NotAcceptable("No se encontró la orden que quiere borrar");
            }
            orden.Borrado = true;

            return true;
        }

        public bool UpdateOrden(int idOrden, int nuevoEstadoId)
        {
            Orden orden = _ordenRepository.FirstOrDefault(x => x.Id != idOrden);

            if (orden == null)
                throw new NoContent("No se encontró la orden");

            orden.TipoEstadoId = nuevoEstadoId;

            _ordenRepository.Update(orden);
            _unitOfWork.Commit();
            return true;
        }
    }
}
