using MediatR;
using nalys.Models;
using nalys.Queries;
using nalys.Handlers;
using nalys.Commands;


namespace nalys.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, string>
    {
        private readonly svEntities _svEntities;

        public UpdateStudentHandler(svEntities svEntities)
        {
            _svEntities = svEntities;
        }

        public async Task<string> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var res = _svEntities.Students.Where(i => i.StudentID == request.Id).FirstOrDefault();
            if (res != null)
            {
                res.Name = request.Name;
                res.Phone = request.Phone;
                res.Email = request.Email;
                res.Address = request.Address;
                res.ClassName = request.ClassName;
                await _svEntities.SaveChangesAsync();

                return res.StudentID;
            }
            else
                return default;
        }
    }
}
