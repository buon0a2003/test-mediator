﻿using MediatR;
using nalys.Models;
using nalys.Queries;
using nalys.Handlers;
using nalys.Commands;


namespace nalys.Commands
{
    public class UpdateStudentCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ClassName { get; set; }
    }
}
