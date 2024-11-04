using Core.Interfaces;
using Entities;
using EntitiesDTO;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkRepository.Repository.Models;
using static Infraestructura.Excepciones.Exceptions;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {

        private readonly IOrdenService _orden;

        public OrdenController(IOrdenService ordenService)
        {
                  _orden = ordenService;
        }

        [HttpPost("CrearOrden")]
        public async Task<ActionResult> CrearOrden(OrdenDTO orden)
        {
            var result = await _orden.CreateOrdenAsync(orden);
            if (result)
                return Ok("Orden creado Con éxito");
            else
            {
                throw new FailedDependency("Hubo un error al crear la orden");
            }
        }

        [HttpGet("GetOrden")]
        public async Task<Orden> GetOrden(int id)
        {
            var orden = await _orden.GetOrden(id);

            return orden;
        }
    }
}
