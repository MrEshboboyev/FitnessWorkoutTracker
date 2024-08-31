using FitnessWorkoutTracker.Application.DTOs;
using MediatR;

namespace FitnessWorkoutTracker.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
