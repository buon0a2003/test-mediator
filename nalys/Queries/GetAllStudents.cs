using MediatR;
using nalys.Models;

namespace nalys.Queries
{
    public record GetAllStudents : IRequest<List<StudentView>>;
    

    
}
