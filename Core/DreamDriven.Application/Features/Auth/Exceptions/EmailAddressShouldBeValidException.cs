using DreamDriven.Application.Bases;

namespace DreamDriven.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("There is no such an email address") { }
    }
}
