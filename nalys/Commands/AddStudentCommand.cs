using MediatR;
using nalys.Models;
using Microsoft.EntityFrameworkCore;
using nalys.Queries;

namespace nalys.Commands
{
    public record AddStudentCommand(Student student) : IRequest;
    
}
