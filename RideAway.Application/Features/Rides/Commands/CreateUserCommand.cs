using MediatR;
using RideAway.Application.DTOs.User;
using RideAway.Domain.Entities;
using Stripe.Forwarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideAway.Application.Features.Rides.Commands
{
    public record CreateUserCommand(global::RideAway.Application.DTOs.User.CreateUserDTO createUserDTO) : IRequest<User>;
}
