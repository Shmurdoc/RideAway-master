using MediatR;
using RideAway.Domain.Entities;
using RideAway.Application.IRepositories;

namespace RideAway.Application.Features.Users.Queries
{
    /// <summary>
    /// Handler for GetUserByEmailOrPhoneQuery.
    /// </summary>
    public class GetUserByEmailOrPhoneQueryHandler : IRequestHandler<GetUserByEmailOrPhoneQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByEmailOrPhoneQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> Handle(GetUserByEmailOrPhoneQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(u => u.Email == request.EmailOrPhone || u.PhoneNumber == request.EmailOrPhone);
            return users.ToList();
        }
    }
}
