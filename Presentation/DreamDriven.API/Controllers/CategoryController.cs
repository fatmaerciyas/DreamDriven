using DreamDriven.Application.Features.Categories.Queries.GettAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts() // GetAllProducts(GettAllCategoriesQueryRequest request)
        {

            var response = await mediator.Send(new GettAllCategoriesQueryRequest()); //herhangi bir querye gore donmek istemedigim icin boyle yoksa // Send( request )

            return Ok(response);
        }
    }
}
