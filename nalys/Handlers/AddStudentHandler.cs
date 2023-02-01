using MediatR;
using nalys.Models;
using Microsoft.EntityFrameworkCore;
using nalys.Queries;
using nalys.Commands;

namespace nalys.Handlers
{
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly svEntities _svEntities;

        public AddStudentHandler(svEntities svEntities)
        {
            _svEntities = svEntities;
        }

        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            await _svEntities.Students.AddAsync(request.student);
            await _svEntities.SaveChangesAsync();

            return request.student;
        }

    }
}
