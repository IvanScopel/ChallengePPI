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


        /// <summary>
        /// Creo una orden de manera asíncrona a partir de un OrdenDTO
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost("CreateOrden")]
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
        /// <summary>
        /// Obtengo una Orden a partir del id ingreesado
        /// </summary>
        /// <returns>Orden</returns>
        [HttpGet("GetOrden")]
        public async Task<Orden> GetOrden(int id)
        {
            var orden = await _orden.GetOrden(id);

            return orden;
        }
        /// <summary>
        /// Borra una Orden de manera lógica utilizando un id
        /// </summary>
        /// <returns>Orden</returns>
        [HttpDelete("LogicDeleteOrden")]
        public ActionResult LogicDeleteOrden(int id)
        {

            var result = _orden.LogicDeleteOrden(id);

            if (result)
                return Ok();

            return NotFound($"No se encontró una orden con id {id}");
        }

        /// <summary>
        /// Actualiza una orden a través del id de orden y un estadoId
        /// </summary>
        /// <returns>Orden</returns>
        [HttpPatch("UpdateOrden")]
        public ActionResult UpdateOrden(int idOrden, int nuevoEstadoId)
        {

            var result = _orden.UpdateOrden(idOrden, nuevoEstadoId);

            if (result)
                return Ok();

            return NotFound($"No se encontró una orden con id {idOrden} para actualizar");
        }
    }
}
