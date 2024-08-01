﻿using Microsoft.AspNetCore.Identity;

namespace DreamDriven.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Username { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
