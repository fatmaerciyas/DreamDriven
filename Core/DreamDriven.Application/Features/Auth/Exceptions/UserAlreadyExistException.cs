using DreamDriven.Application.Bases;

namespace DreamDriven.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("This user is already exist") { }
    }
}
