using DreamDriven.Application.Bases;
using DreamDriven.Application.Features.Auth.Rules;
using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Application.Tokens;
using DreamDriven.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace DreamDriven.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration, ITokenService tokenService, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByEmailAsync(request.Email); // User varsa
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password); // Password'u check et

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);  //username ve password var mi

            IList<string> roles = await userManager.GetRolesAsync(user); // token olustururken rolleri de vermemiz gerek bu yuzden aldik

            JwtSecurityToken token = await tokenService.CreateToken(user, roles); // Token olustur

            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays); //JWT nin icindeki degeri int'e cevir 

            user.RefreshToken = refreshToken;

            DateTime utcNow = DateTime.UtcNow; // UTC zamanını alır
            user.RefreshTokenExpiryTime = utcNow.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token); // Token'i yazdir

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };

        }
    }
}
