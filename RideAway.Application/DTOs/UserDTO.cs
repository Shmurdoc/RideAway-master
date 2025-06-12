using RideAway.Domain.Entities;
using RideAway.Domain.Entities.Enum;
using RideAway.Domain.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideAway.Application.DTOs
{

    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        //public string PasswordHash { get; set; } = string.Empty;
        //public string PhoneNumber { get; set; } = string.Empty;
        public UserRole Role { get; set; }  // Enum: Rider, Driver, Admin
    }

    // This file is now obsolete. All user-related DTOs have been moved to DTOs/User/ for DDD compliance.

}
