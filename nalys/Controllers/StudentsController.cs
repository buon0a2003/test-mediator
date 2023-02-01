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
        public async Task<List<Student>> Get()
        {
            return await _mediator.Send(new GetAllStudents());
        }

        [HttpGet("{id}")]
        public async Task<Student> Get(string id)
        {
            return await _mediator.Send(new GetStudentById(id));
        }

        [HttpPost]
        public async Task<Student> Post(Student student)
        {
            return await _mediator.Send(new AddStudentCommand(student));
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            return await _mediator.Send(new RemoveStudentCommand(id));
        }

        [HttpPut("{id}")]
        public async Task<string> Update(UpdateStudentCommand command, string id)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        
    }
}
