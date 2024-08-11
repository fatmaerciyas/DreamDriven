using FluentValidation;

namespace DreamDriven.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("Name Surname");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(60)
                .EmailAddress()
                .MinimumLength(8)
                .WithName("E-mail");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("Password");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("Confirm Password");
        }
    }
}
