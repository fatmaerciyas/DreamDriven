﻿using DreamDriven.Application.Bases;
using DreamDriven.Application.Features.Auth.Rules;
using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Application.Tokens;
using DreamDriven.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DreamDriven.Application.Features.Auth.Command.RefreshToken
{
    //RefreshToken --> Kac gun sonra tekrar login olsun?
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        public RefreshTokenCommandHandler(IMapper mapper, AuthRules authRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }
        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email); // emaili bul

            User? user = await userManager.FindByEmailAsync(email); // useri bul
            IList<string> roles = await userManager.GetRolesAsync(user); // rolleri getir

            await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime); // Kurala uyup uymadigina bak

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles); //user ve rolleri ver
            string newRefreshToken = tokenService.GenerateRefreshToken();

            //Guncelle
            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };
        }
    }
}
