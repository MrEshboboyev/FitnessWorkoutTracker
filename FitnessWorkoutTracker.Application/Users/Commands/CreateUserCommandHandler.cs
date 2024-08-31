using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Interfaces;
using FitnessWorkoutTracker.Domain.Entities;
using MediatR;

namespace FitnessWorkoutTracker.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        // inject IUserRepository
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password) // Example hashing
            };

            await _userRepository.AddAsync(user);

            return new UserDTO
            {
                Id = user.Id,
                Username = request.Username,
                Email = request.Email
            };
        }
    }
}
