//using Microsoft.AspNetCore.Mvc;
//using MediatR;
//using System.Threading.Tasks;
//using application.Todos.Commands;

//namespace api.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class TodosController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public TodosController(IMediator mediator) => _mediator = mediator;

//        //[HttpPut("{id}")]
//        //public async Task<IActionResult> Update(int id, [FromBody] CreateTenantCommand command)
//        //{
//        //    if (id != command.Id) return BadRequest();

//        //    var updated = await _mediator.Send(command);
//        //    if (!updated) return NotFound();

//        //    return NoContent();
//        //}

//        // helper endpoint to add a todo for testing
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateTenantCommand command)
//        {
//            var data = await _mediator.Send(command);
//            // reuse repository via MediatR handler? For simplicity, create minimal flow via repository directly is avoided here.
//            // Instead, the client can call infrastructure directly later. For now, treat Create as Update with Add.
//            return BadRequest("Use repository or seed data directly for creating test data.");
//        }
//    }
//}