using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.V1;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly MovementCore _movementCore;
        public MovementsController(ILogger<Movement> logger,IMapper mapper,IMovementRepository context) {
            _movementCore = new MovementCore(logger, mapper, context);
        }

        // GET: api/<MovementsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movement>>> Get()
        {
            var response=await _movementCore.GetMovementsAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<MovementsController>
        [HttpPost]
        public async Task<ActionResult<Movement>> Post([FromBody] MovementCreateDto movement)
        {
            var response=await _movementCore.AddMovementAsync(movement);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
