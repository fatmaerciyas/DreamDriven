using DreamDriven.Application.Bases;

namespace DreamDriven.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Invalid username or password") { }
    }
}
