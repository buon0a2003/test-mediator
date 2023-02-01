using MediatR;
using nalys.Models;
using Microsoft.EntityFrameworkCore;
using nalys.Queries;

namespace nalys.Handlers
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudents, List<Student>>
    {
        private readonly svEntities _svEntities;

        public GetAllStudentsHandler(svEntities svEntities)
        {
            _svEntities = svEntities;
        }

        public Task<List<Student>> Handle(GetAllStudents request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_svEntities.Students.ToList());
        }
    }
}
