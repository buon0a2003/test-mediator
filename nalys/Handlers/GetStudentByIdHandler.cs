using MediatR;
using nalys.Models;
using Microsoft.EntityFrameworkCore;
using nalys.Queries;

namespace nalys.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentById, Student>
    {
        private readonly svEntities _svEntities;

        public GetStudentByIdHandler(svEntities svEntities)
        {
            _svEntities = svEntities;
        }

        public Task<Student> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_svEntities.Students.Where(i => i.StudentID == request.id).FirstOrDefault());
        }

    }
}
