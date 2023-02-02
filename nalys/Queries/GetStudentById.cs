using MediatR;
using nalys.Models;

namespace nalys.Queries
{
    public record GetStudentById(int id) : IRequest<Student>;
    
}
