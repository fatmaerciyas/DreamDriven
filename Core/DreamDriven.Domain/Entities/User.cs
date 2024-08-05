using Microsoft.AspNetCore.Identity;

namespace DreamDriven.Domain.Entities
{
    //Userlari hangi tip key ile tutacagimi da veriyorum
    public class User : IdentityUser<Guid>
    {
        public string Username { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        //Notifications
        public ICollection<Notificatin> Notifications { get; set; }
        //Todos
        public ICollection<Todo> Todos { get; set; }
        //UserUploads
        public ICollection<UserUpload> UserUploads { get; set; }
        //Counters
        public ICollection<Counter> Counters { get; set; }

    }
}
