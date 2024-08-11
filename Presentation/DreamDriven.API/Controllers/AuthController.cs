using DreamDriven.Application.Features.Auth.Command.Login;
using DreamDriven.Application.Features.Auth.Command.RefreshToken;
using DreamDriven.Application.Features.Auth.Command.Register;
using DreamDriven.Application.Features.Auth.Command.Revoke;
using DreamDriven.Application.Features.Auth.Command.RevokeAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetAllCategories() // GetAllCategories(GettAllCategoriesQueryRequest request)
        //{

        //    var response = await mediator.Send(new GettAllCategoriesQueryRequest()); //herhangi bir querye gore donmek istemedigim icin boyle yoksa // Send( request )

        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {

            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {

            await mediator.Send(new RevokeAllCommandRequest()); //kullanicidan request almayacagim
            return Ok();
        }


    }
}
