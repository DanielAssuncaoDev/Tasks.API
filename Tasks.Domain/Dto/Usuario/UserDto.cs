using System;

namespace Tasks.Domain.Dto.Usuario
{
    public class UserDto
    {
        public int Id{ get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Refreshtoken { get; set; }
        public DateTime? ExpirationRefreshToken { get; set; }
        public bool IsActiveEmail { get; set; } = false;
        public int? KeyActiveEmail { get; set; }
        public DateTime DateInclusion { get; set; }
        public DateTime DateChange { get; set; }
        public bool IsInactive { get; set; }
    }
}
