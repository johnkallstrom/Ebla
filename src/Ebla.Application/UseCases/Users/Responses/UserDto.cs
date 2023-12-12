﻿namespace Ebla.Application.UseCases.Users.Responses
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string[] Roles { get; set; }
    }
}