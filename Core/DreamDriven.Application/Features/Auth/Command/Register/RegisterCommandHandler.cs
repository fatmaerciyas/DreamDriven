using DreamDriven.Application.Bases;
using DreamDriven.Application.Features.Auth.Rules;
using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DreamDriven.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {

        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));// emaile gore kullaninin olup olmadigini kontrol et

            User user = mapper.Map<User, RegisterCommandRequest>(request); // RegisterCommandRequest ve User 'i maple

            //user.Username = request.Email;  // Username, email olsun

            user.SecurityStamp = Guid.NewGuid().ToString(); //Aynı anda yapilan aynı islemden once yapilan guncelleme gecerli oldugunda ikinci kisi guncellerken error gorecek yoksa karisiklik olur

            //Olustur
            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if ( result.Succeeded )
            {
                //Eger rolu yoksa rol ata
                if ( !await roleManager.RoleExistsAsync("user") )
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });
                //Rolu kullaniciya ata
                await userManager.AddToRoleAsync(user, "user");
            }

            //else
            //{
            //    // Oturum açma başarısızsa uygun bir hata mesajı döndür
            //    return Unauthorize("Kullanıcı adı veya şifre hatalı.");
            //}

            return Unit.Value;
        }
    }

}

