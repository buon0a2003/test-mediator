using MediatR;
using nalys.Models;
using nalys.Queries;
using nalys.Handlers;
using nalys.Commands;


namespace nalys.Handlers
{
    public class RemoveStudentHandler : IRequestHandler<RemoveStudentCommand, string>
    {
        private readonly svEntities _svEntities;

        public RemoveStudentHandler(svEntities svEntities)
        {
            _svEntities = svEntities;
        }
        
        public async Task<string> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = _svEntities.Students.Where(i => i.StudentID == request.id).FirstOrDefault();
            if (entity != null)
            {
                _svEntities.RemoveRange(entity);
                await _svEntities.SaveChangesAsync();
                return new string("da xong");
            }
            else
                return new string("ko thanh cong");
        }
    }
}
