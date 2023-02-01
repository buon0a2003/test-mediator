using MediatR;
using nalys.Models;

namespace nalys.Queries
{
    public record GetStudentById(string id) : IRequest<Student>;
    
}
