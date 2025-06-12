using MediatR;
using Microsoft.Extensions.Logging;
using RideAway.Application.Features.Rides.Commands;
using RideAway.Application.IRepositories;
using RideAway.Domain.Entities;
using System.Security.Cryptography;

namespace RideAway.Application.Features.Rides.Handlers.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUserHandler> _logger;
        public CreateUserHandler(IUnitOfWork unitOfWork, ILogger<CreateUserHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Hash the password before storing
            string passwordHash = string.Empty;
            if (!string.IsNullOrWhiteSpace(request.createUserDTO.Password))
            {
                using var sha256 = SHA256.Create();
                var bytes = System.Text.Encoding.UTF8.GetBytes(request.createUserDTO.Password);
                var hash = sha256.ComputeHash(bytes);
                passwordHash = Convert.ToBase64String(hash);
            }
            var user = new User
            {
                Name = request.createUserDTO.Name,
                Role = request.createUserDTO.Role,
                PasswordHash = passwordHash
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("New user created with ID: {UserId} and Role: {Role}", user.Id, user.Role);

            return user;
        }
    }
}
