using MediatR;
using nalys.Models;
using Microsoft.EntityFrameworkCore;
using nalys.Queries;

namespace nalys.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentById, StudentView>
    {
        private readonly svEntities _svEntities;

        public GetStudentByIdHandler(svEntities svEntities)
        {
            _svEntities = svEntities;
        }

        public Task<StudentView> Handle(GetStudentById request, CancellationToken cancellationToken)
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
                  

            return Task.FromResult(res.Where(i => i.StudentID == request.id).FirstOrDefault());
        }

    }
}
