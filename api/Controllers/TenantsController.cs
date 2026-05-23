using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using application.Todos.Commands;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTenantCommand command)
        {
            var id = await _mediator.Send(command);
            if(!(id > 0)) return BadRequest("Create Failed");
            return Ok(id);
        }
    }
}