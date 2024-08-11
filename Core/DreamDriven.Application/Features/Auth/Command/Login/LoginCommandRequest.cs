using MediatR;
using System.ComponentModel;

namespace DreamDriven.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("user@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("123456")]
        public string Password { get; set; }
    }
}
