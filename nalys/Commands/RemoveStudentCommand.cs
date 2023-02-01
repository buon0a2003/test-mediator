﻿using MediatR;
using nalys.Models;
using nalys.Queries;
using nalys.Handlers;
using nalys.Commands;


namespace nalys.Commands
{
    public record RemoveStudentCommand(string id) : IRequest<string>;
    
    
}
