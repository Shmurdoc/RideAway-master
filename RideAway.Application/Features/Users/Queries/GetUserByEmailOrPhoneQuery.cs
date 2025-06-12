using MediatR;
using RideAway.Domain.Entities;

namespace RideAway.Application.Features.Users.Queries
{
    /// <summary>
    /// Query to get user(s) by email or phone for login.
    /// </summary>
    public class GetUserByEmailOrPhoneQuery : IRequest<List<User>>
    {
        public string EmailOrPhone { get; }
        public GetUserByEmailOrPhoneQuery(string emailOrPhone)
        {
            EmailOrPhone = emailOrPhone;
        }
    }
}
