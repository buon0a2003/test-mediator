using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using nalys.Models;
using nalys.Queries;
using nalys.Handlers;
using nalys.Commands;

namespace nalys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students =  await _mediator.Send(new GetAllStudents());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var stduent =  await _mediator.Send(new GetStudentById(id));

            return Ok(stduent);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            await _mediator.Send(new AddStudentCommand(student));

            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _mediator.Send(new RemoveStudentCommand(id));

            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateStudentCommand command, int id)
        {
            command.Id = id;
            await _mediator.Send(command);

            return StatusCode(200);
        }
        
    }
}
