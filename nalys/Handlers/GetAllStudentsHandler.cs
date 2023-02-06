using MediatR;
using nalys.Models;
using Microsoft.EntityFrameworkCore;
using nalys.Queries;

namespace nalys.Handlers
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudents, List<StudentView>>
    {
        private readonly svEntities _svEntities;

        public GetAllStudentsHandler(svEntities svEntities)
        {
            _svEntities = svEntities;
        }

        public Task<List<StudentView>> Handle(GetAllStudents request, CancellationToken cancellationToken)
        {
            var res = from sv in _svEntities.Students
                      join c in _svEntities.Class on sv.ClassID equals c.ClassID
                      select new StudentView
                      {
                          StudentID = sv.StudentID,
                          Name = sv.Name,
                          Phone = sv.Phone,
                          Email = sv.Email,
                          Address = sv.Address,
                          ClassName = c.ClassName
                      };
                      
            return Task.FromResult(res.ToList());
        }
    }
}
