using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using application.Tenants;

namespace api.Controllers
{
    [ApiController]
    [Route("api/admin/tenants")]
    [Authorize] /*// Require JWT auth; ensure SuperAdmin role is checked in your auth policy*/
    public class AdminTenantsController : ControllerBase    
    {
        private readonly IMediator _mediator;
        public AdminTenantsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? planType = null, [FromQuery] bool? isActive = null)
        {
            var result = await _mediator.Send(new ListTenantsQuery(page, pageSize, planType, isActive));
            return Ok(result.Items);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tenant = await _mediator.Send(new GetTenantByIdQuery(id));
            if (tenant == null) return NotFound();
            return Ok(tenant);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] UpdateTenantCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");
            var updated = await _mediator.Send(command);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new SoftDeleteTenantCommand(id));
            return NoContent();
        }
    }
}