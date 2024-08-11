using DreamDriven.Application.Bases;
using DreamDriven.Application.Features.Auth.Command.Revoke;
using DreamDriven.Application.Features.Auth.Rules;
using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> userManager;
    private readonly AuthRules authRules;

    // Burada UserManager ve AuthRules bağımlılıklarını enjekte edin
    public RevokeCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        UserManager<User> userManager,
        AuthRules authRules)
        : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        this.authRules = authRules ?? throw new ArgumentNullException(nameof(authRules));
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByEmailAsync(request.Email); // email ile user'i bul
        await authRules.EmailAddressShouldBeValid(user); // emaili dogrula

        user.RefreshToken = null; // daha fazla refresh token'in tutulmamasi icin null yap
        await userManager.UpdateAsync(user); // bilgileri guncelle

        return Unit.Value;
    }
}
