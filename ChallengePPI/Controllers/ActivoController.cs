using Core.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ActivoController : ControllerBase
    {
        private readonly IActivoService _activo;

        public ActivoController(IActivoService activoService)
        {

            _activo = activoService;
        }

        [HttpGet]
        public Activo GetActivoBy(int id)
        {
            var result = _activo.GetActivoById(id);
            
           return result;

        }
    }
}
